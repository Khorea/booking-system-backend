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

        private readonly LayoutService _layoutService;

        public TrainService(ITrainRepository trainRepository,
                            IStationRepository stationRepository,
                            ICarRepository carRepository,
                            ISeatRepository seatRepository,
                            IMapper mapper,
                            LayoutService layoutService)
        {
            _trainRepository = trainRepository;
            _stationRepository = stationRepository;
            _carRepository = carRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
            _layoutService = layoutService;
        }

        public async Task<Train> InsertTrain(TrainDTO trainDTO)
        {
            //Train train = _mapper.Map<Train>(trainDTO);
            Train train = new Train();
            train.TrainType = trainDTO.TrainType;
            train = await _trainRepository.Add(train);

            List<Station> stations = _mapper.Map<List<Station>>(trainDTO.Stations);
            TrainLayout trainLayout = trainDTO.TrainLayout;

            train.Cars = await _layoutService.CreateTrainLayout(trainLayout, train.TrainId);

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

        public async Task UpdateTrain(int trainId, TrainDTO trainDTO)
        {
            Train oldTrain = await _trainRepository.Get(trainId);
            TrainLayout oldLayout = _mapper.Map<TrainLayout>(oldTrain.Cars);

            oldTrain.TrainType = trainDTO.TrainType;
            oldTrain.Stations = _mapper.Map<ICollection<Station>>(trainDTO.Stations);
            await _trainRepository.Update(oldTrain);
            await _layoutService.ChangeLayout(trainId, oldLayout, trainDTO.TrainLayout);
        }
    }
}
