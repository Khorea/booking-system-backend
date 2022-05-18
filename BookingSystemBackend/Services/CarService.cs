using AutoMapper;
using BookingSystemBackend.Models;
using BookingSystemBackend.Repos;
using System.Threading.Tasks;

namespace BookingSystemBackend.Services
{
    public class CarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository,
                          ISeatRepository seatRepository,
                          IMapper mapper)
        {
            _carRepository = carRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        public async Task<Car> InsertCar(Car car)
        {
            car = await _carRepository.Add(car);

            if (car.CarType.Equals("firstClass"))
            {
                for (int j = 0; j < 20; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
            } 
            else if (car.CarType.Equals("secondClass"))
            {
                for (int j = 0; j < 50; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
            }
            else if (car.CarType.Equals("sleeper"))
            {
                for (int j = 0; j < 10; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
            }
            else if (car.CarType.Equals("couchette"))
            {
                for (int j = 0; j < 60; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
            }

            return car;
        }

        public async Task<Car> RemoveCar(int trainId, string carType)
        {
            return await _carRepository.RemoveCar(trainId, carType);
        }
    }
}
