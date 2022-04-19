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
    public class TrainController : ControllerBase
    {
        private readonly TrainService _trainService;

        public TrainController(TrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Train>> Post(TrainDTO trainDTO)
        {
            Train train = await _trainService.InsertTrain(trainDTO);
            return CreatedAtAction("GetTrain", new { id = train.TrainId }, train);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<TrainDTO>> GetTrain(int trainId)
        {
            return Ok(await _trainService.GetTrain(trainId));
        }

        [HttpGet]
        [Authorize]
        [Route("AllTrains")]
        public async Task<ActionResult<List<TrainDetails>>> GetAllTrains()
        {
            return Ok(await _trainService.GetAllTrains());
        }

        [HttpGet]
        [Authorize]
        [Route("client-all-trains")]
        public async Task<ActionResult<List<TrainDTOClient>>> GetTrainsForClient()
        {
            return Ok(await _trainService.GetTrainsForClient());
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> DeleteTrain(int trainId)
        {
            Train t = await _trainService.Delete(trainId);
            if (t != null)
            {
                return Ok(t);
            }
            return NotFound();
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateTrain(int trainId, TrainDTO trainModel)
        {
            await _trainService.UpdateTrain(trainId, trainModel);
            return Ok();
        }
    }
}
