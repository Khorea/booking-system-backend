using BookingSystemBackend.Models.DTOs;
using BookingSystemBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class StationController : ControllerBase
	{
		private readonly StationService _stationService;

		public StationController(StationService trainService)
		{
			_stationService = trainService;
		}

		[HttpGet]
		[Route("get-all")]
		public async Task<ActionResult<List<StationDTO>>> GetStations(int stationId)
		{
			return Ok(await _stationService.GetStations());
		}

		[HttpPost]
		public async Task<ActionResult<StationDTO>> AddStation(StationDTO stationDTO)
		{
			return Ok(await _stationService.AddStation(stationDTO));
		}

		[HttpDelete]
		public async Task<ActionResult<StationDTO>> DeleteStation(int stationId)
		{
			return Ok(await _stationService.DeleteStationById(stationId));
		}
	}
}
