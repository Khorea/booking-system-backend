using AutoMapper;
using BookingSystemBackend.Models;
using BookingSystemBackend.Models.DTOs;
using BookingSystemBackend.Repos;
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
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepo;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepo, IMapper mapper)
        {
            _personRepo = personRepo;
            _mapper = mapper;   
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            return Ok(await _personRepo.GetAll());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Person>> Post(Person person)
        {
            await _personRepo.Add(person);
            return CreatedAtAction("Get", new { id = person.PersonId }, person);
        }

        [HttpGet]
        [Route("PersonDetails")]
        [Authorize]
        public async Task<ActionResult<Person>> GetPersonDetails(string username)
        {
            return Ok(_mapper.Map<PersonDetails>((await _personRepo.GetByUsername(username))));
        } 
    }
}
