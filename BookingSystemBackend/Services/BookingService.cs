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

        public BookingService(IBookingRepository bookingRepository,
            ISubBookingRepository subBookingRepository,
            IPersonRepository personRepo,
            ICarRepository carRepository,
            ISeatRepository seatRepository)
        {
            _bookingRepository = bookingRepository;
            _subBookingRepository = subBookingRepository;
            _personRepo = personRepo;
            _carRepository = carRepository;
            _seatRepository = seatRepository;
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
    }
}
