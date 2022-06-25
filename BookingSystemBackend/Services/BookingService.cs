using AutoMapper;
using BookingSystemBackend.Models;
using BookingSystemBackend.Models.DTOs;
using BookingSystemBackend.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Services
{
	public class BookingService
	{
		private readonly IBookingRepository _bookingRepository;
        private readonly ISubBookingRepository _subBookingRepository;
        private readonly IPersonRepository _personRepo;
        private readonly ICarRepository _carRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IConnectionRepository _connectionRepository;
        private readonly IStationRepository _stationRepository;
        private readonly ITrainRepository _trainRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository,
            ISubBookingRepository subBookingRepository,
            IPersonRepository personRepo,
            ICarRepository carRepository,
            ISeatRepository seatRepository,
            IConnectionRepository connectionRepository,
            IStationRepository stationRepository,
            ITrainRepository trainRepository,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _subBookingRepository = subBookingRepository;
            _personRepo = personRepo;
            _carRepository = carRepository;
            _seatRepository = seatRepository;
            _connectionRepository = connectionRepository;
            _stationRepository = stationRepository;
            _trainRepository = trainRepository;
            _mapper = mapper;
        }

        public async Task<bool> Book(BookingDTO bookingDTO)
		{
            Booking booking = new Booking();
            booking.Person = await _personRepo.GetByUsername(bookingDTO.Username);
            booking.PersonId = booking.Person.PersonId;
            booking.SubBookings = new List<SubBooking>();

            List<Car> cars = await _carRepository.GetAll();

            foreach (SubBookingDTO subBookingDTO in bookingDTO.SubBookings)
			{
                cars = cars.Where(car => car.TrainId == subBookingDTO.TrainId && car.CarType == subBookingDTO.CarType).ToList();
                List<Seat> seats = await _seatRepository.GetByCarIds(cars.Select(x => x.CarId).ToList());
                List<SubBooking> subBookings = await _subBookingRepository.GetByTrainIdAndDate(subBookingDTO.TrainId, subBookingDTO.BookingDate);
                List<int> bookedSeatsIds = subBookings.Select(x => x.SeatId).ToList();
                List<Seat> freeSeats = seats.Where(x => !bookedSeatsIds.Contains(x.SeatId)).ToList();

                if (freeSeats.Count <= 0)
				{
                    return false;
				}
               
                SubBooking subBooking = new SubBooking
                {
                    BookingDate = subBookingDTO.BookingDate,
                    TrainId = subBookingDTO.TrainId,
                    SeatId = freeSeats[0].SeatId,
                    FirstStationId = subBookingDTO.FirstStationId,
                    SecondStationId = subBookingDTO.SecondStationId,
                    Price = 15
                };
                booking.SubBookings.Add(subBooking);
            }

            await _bookingRepository.Add(booking);
            return true;
		}

        public async Task<List<BookingDTO>> GenerateRoutes(int firstStationId, int secondStationId)
		{
            Station startStation = await _stationRepository.Get(firstStationId);
            Station endStation = await _stationRepository.Get(secondStationId);
            List<Connection> connections = await _connectionRepository.GetAllIncludeEverythingAsync();
            List<BookingDTO> routes = new List<BookingDTO>();
            List<List<Connection>> allPaths = new List<List<Connection>>();
            DFS(allPaths, new List<Connection>(), connections, startStation, endStation, new List<int>());

            Console.WriteLine(allPaths);

            foreach (var path in allPaths)
			{
                var trainGroupping = path.GroupBy(x => x.TrainId);
                var route = new BookingDTO() { SubBookings = new List<SubBookingDTO>(), Username = "" };
                foreach (var trainConnections in trainGroupping)
				{
                    SubBookingDTO subBookingDTO = new SubBookingDTO();
                    var firstStation = trainConnections.First().StartStation;
                    var secondStation = trainConnections.Last().EndStation;
                    subBookingDTO.FirstStation = _mapper.Map<StationDTO>(firstStation);
                    subBookingDTO.FirstStationId = firstStation.StationId;
                    subBookingDTO.SecondStation = _mapper.Map<StationDTO>(secondStation);
                    subBookingDTO.SecondStationId = secondStation.StationId;
                    subBookingDTO.CarType = "firstClass";
                    subBookingDTO.BookingDate = DateTime.UtcNow;
                    subBookingDTO.Train = _mapper.Map<TrainDTOClient>(trainConnections.First().Train);
                    route.SubBookings.Add(subBookingDTO);
                }
                routes.Add(route);
			}

            return routes;
		}

        private void DFS(List<List<Connection>> allPaths, List<Connection> currentPath, List<Connection> connections, Station currentStation, Station endStation, List<int> visited)
		{
            if (currentStation.StationId == endStation.StationId)
			{
                allPaths.Add(currentPath);
                return;
			}
            
            List<Connection> availableConnections = connections
                .Where(c => c.StartStation.StationId == currentStation.StationId 
                && !visited.Contains(c.EndStation.StationId)).ToList();

            foreach (Connection connection in availableConnections)
			{
                DFS(allPaths, currentPath.Append(connection).ToList(), connections, connection.EndStation, endStation, visited.Append(currentStation.StationId).ToList());
			}
		}
    }
}
