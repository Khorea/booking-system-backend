using BookingSystemBackend.Models;
using BookingSystemBackend.Models.DTOs;
using BookingSystemBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly BookingService _bookingService;

		public BookingController(BookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<bool>> Post(BookingDTO bookingDTO)
		{
			return Ok(await _bookingService.Book(bookingDTO));
		}

		[HttpGet]
		[Route("generate-routes")]
		public async Task<ActionResult<List<BookingDTO>>> GenerateRoutes([FromQuery] int departureStationId, [FromQuery] int arrivalStationId)
		{
			return Ok(await _bookingService.GenerateRoutes(departureStationId, arrivalStationId));
		}
	}
}
