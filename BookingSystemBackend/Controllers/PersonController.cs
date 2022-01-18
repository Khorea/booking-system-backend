using BookingSystemBackend.Models;
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

        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Person>>> Get()
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
    }
}
