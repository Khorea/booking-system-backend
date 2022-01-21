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

        public TrainService(ITrainRepository trainRepository, 
                            IStationRepository stationRepository, 
                            ICarRepository carRepository, 
                            ISeatRepository seatRepository)
        {
            _trainRepository = trainRepository;
            _stationRepository = stationRepository;
            _carRepository = carRepository;
            _seatRepository = seatRepository;
        }

        public async Task<bool> InsertTrain(TrainDTO trainDTO)
        {
            return false;
        }
    }
}
