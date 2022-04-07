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
		public ActionResult<List<StationDTO>> GetTrain(int trainId)
		{
			return Ok(_stationService.GetStations());
		}
	}
}
