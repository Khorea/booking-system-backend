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
	public class StationService
	{
		private readonly IStationRepository _stationRepository;
        private readonly IMapper _mapper;

        public StationService(IStationRepository stationRepository,
                            IMapper mapper)
        {
            _stationRepository = stationRepository;
            _mapper = mapper;
        }

        public async Task<List<StationDTO>> GetStations()
		{
            List<Station> stations = await _stationRepository.GetAll();
            return _mapper.Map<List<StationDTO>>(stations);
        }
    }
}
