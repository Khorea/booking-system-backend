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
        private readonly IConnectionRepository _connectionRepository;
        private readonly IStationRepository _stationRepository;
        private readonly ICarRepository _carRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        private readonly LayoutService _layoutService;

        public TrainService(ITrainRepository trainRepository,
                            IConnectionRepository connectionRepository,
                            IStationRepository stationRepository,
                            ICarRepository carRepository,
                            ISeatRepository seatRepository,
                            IMapper mapper,
                            LayoutService layoutService)
        {
            _trainRepository = trainRepository;
            _connectionRepository = connectionRepository;
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

            List<Connection> connections = _mapper.Map<List<Connection>>(trainDTO.Connections);
            TrainLayout trainLayout = trainDTO.TrainLayout;

            train.Cars = await _layoutService.CreateTrainLayout(trainLayout, train.TrainId);

            for (int i = 0; i < connections.Count; i++)
            {
                connections[i].TrainId = train.TrainId;
                connections[i] = await _connectionRepository.Add(connections[i]);
                train.Connections.Add(connections[i]);
            }
            return train;
        }

        public async Task<Train> Delete(int trainId)
        {
            Train t = await _trainRepository.Get(trainId);
            if (t == null) return null;
            await _connectionRepository.DeleteRange(t.Connections);
            await _seatRepository.RemoveByCarIds(t.Cars.Select(c => c.CarId).ToList());
            await _carRepository.DeleteRange(t.Cars);
            await _trainRepository.Delete(t.TrainId);
            return t;
        }

        public async Task<TrainDTO> GetTrain(int trainId)
        {
            Train train = await _trainRepository.Get(trainId);
            List<ConnectionDTO> connections = _mapper.Map<List<ConnectionDTO>>(train.Connections);
            TrainLayout trainLayout = _mapper.Map<TrainLayout>(train.Cars);
            TrainDTO trainDTO = new TrainDTO(train.TrainType, connections, trainLayout);
            return _mapper.Map<TrainDTO>(trainDTO);
        }

        public async Task<List<TrainDetails>> GetAllTrains()
        {
            List<Train> trains = await _trainRepository.GetAll();
            List<TrainDetails> trainDetails = _mapper.Map<List<TrainDetails>>(trains);
            return trainDetails;
        }

        public async Task<List<TrainDTOClient>> GetTrainsForClient()
        {
            List<Train> trains = await _trainRepository.GetAll();
            return _mapper.Map<List<TrainDTOClient>>(trains);
        }

        public async Task UpdateTrain(int trainId, TrainDTO trainDTO)
        {
            Train oldTrain = await _trainRepository.Get(trainId);
            TrainLayout oldLayout = _mapper.Map<TrainLayout>(oldTrain.Cars);
            oldTrain.TrainType = trainDTO.TrainType;
            oldTrain.Connections = _mapper.Map<ICollection<Connection>>(trainDTO.Connections);
            await _trainRepository.Update(oldTrain);
            await _layoutService.ChangeLayout(trainId, oldLayout, trainDTO.TrainLayout);
        }
    }
}
