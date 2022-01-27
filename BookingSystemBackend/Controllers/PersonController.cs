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
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepo, IAccountRepository accountRepository, IMapper mapper)
        {
            _personRepo = personRepo;
            _accountRepo = accountRepository;
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
        public async Task<ActionResult<PersonDetails>> GetPersonDetails(string username)
        {
            return Ok(_mapper.Map<PersonDetails>((await _personRepo.GetByUsername(username))));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<PersonDetails>> UpdatePersonDetails(User user, string oldUsername)
        {
            
            Person oldPerson = await _personRepo.GetByUsername(oldUsername);
            await _personRepo.Delete(oldPerson.PersonId);
            Account oldAccount = oldPerson.Account;

            oldAccount.Username = user.Username;
            if (!string.IsNullOrEmpty(user.Password))
            {
                oldAccount.Password = user.Password;
            }
            Account newAccount = await _accountRepo.Update(oldAccount);

            Person newPerson = new Person();
            newPerson.Name = user.Name;
            newPerson.Address = user.Address;
            newPerson.Email = user.Email;
            newPerson.Username = user.Username;
            newPerson.Account = newAccount;
            newPerson.Bookings = oldPerson.Bookings;

            return Ok(await _personRepo.Add(newPerson));
        }
    }
}
