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
    public class TrainService
    {
        private readonly ITrainRepository _trainRepository;
        private readonly IStationRepository _stationRepository;
        private readonly ICarRepository _carRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public TrainService(ITrainRepository trainRepository,
                            IStationRepository stationRepository,
                            ICarRepository carRepository,
                            ISeatRepository seatRepository,
                            IMapper mapper)
        {
            _trainRepository = trainRepository;
            _stationRepository = stationRepository;
            _carRepository = carRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        public async Task<Train> InsertTrain(TrainDTO trainDTO)
        {
            //Train train = _mapper.Map<Train>(trainDTO);
            Train train = new Train();
            train.TrainType = trainDTO.TrainType;
            train = await _trainRepository.Add(train);

            List<StationDTO> stationDTOs = trainDTO.Stations;
            List<Station> stations = _mapper.Map<List<Station>>(stationDTOs);
            TrainLayout trainLayout = trainDTO.TrainLayout;

            for (int i = 0; i < trainLayout.FirstClass; i++)
            {
                Car car = new Car("First Class", train.TrainId);
                car = await _carRepository.Add(car);
                for (int j = 0; j < 20; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
                train.Cars.Add(car);
            }

            for (int i = 0; i < trainLayout.SecondClass; i++)
            {
                Car car = new Car("Second Class", train.TrainId);
                car = await _carRepository.Add(car);
                for (int j = 0; j < 50; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
                train.Cars.Add(car);
            }

            for (int i = 0; i < trainLayout.FirstClassSleeper; i++)
            {
                Car car = new Car("First Class Sleeper", train.TrainId);
                car = await _carRepository.Add(car);
                for (int j = 0; j < 10; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
                train.Cars.Add(car);
            }

            for (int i = 0; i < trainLayout.Couchette; i++)
            {
                Car car = new Car("Couchette", train.TrainId);
                car = await _carRepository.Add(car);
                for (int j = 0; j < 60; j++)
                {
                    Seat seat = new Seat(car.CarId);
                    seat = await _seatRepository.Add(seat);
                    car.Seats.Add(seat);
                }
                train.Cars.Add(car);
            }

            for (int i = 0; i < stations.Count; i++)
            {
                stations[i].TrainId = train.TrainId;
                stations[i] = await _stationRepository.Add(stations[i]);
                train.Stations.Add(stations[i]);
            }

            return train;
        }

        public async Task<Train> Delete(int trainId)
        {
            return await _trainRepository.Delete(trainId);
        }

        public async Task<TrainDTO> GetTrain(int trainId)
        {
            Train train = await _trainRepository.Get(trainId);
            List<StationDTO> stations = _mapper.Map<List<StationDTO>>(train.Stations);
            TrainLayout trainLayout = _mapper.Map<TrainLayout>(train.Cars);
            TrainDTO trainDTO = new TrainDTO(train.TrainType, stations, trainLayout);
            return _mapper.Map<TrainDTO>(trainDTO);
        }

        public async Task<List<TrainDetails>> GetAllTrains()
        {
            List<Train> trains = await _trainRepository.GetAll();
            List<TrainDetails> trainDetails = _mapper.Map<List<TrainDetails>>(trains);
            return trainDetails;
        }
    }
}
