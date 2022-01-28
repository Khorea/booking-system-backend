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
        public async Task<ActionResult<List<PersonDetails>>> GetAll()
        {
            return Ok(_mapper.Map<List<PersonDetails>>(await _personRepo.GetAllWithAccounts()));
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
            Person newPerson;
            Person oldPerson = await _personRepo.GetByUsername(oldUsername);
            if (oldPerson == null)
                return NotFound();

            if (user.Username.Equals(oldPerson.Username))
            {
                oldPerson.Name = user.Name;
                oldPerson.Address = user.Address;
                oldPerson.Email = user.Email;
                oldPerson.Account.Password = string.IsNullOrEmpty(user.Password) ? oldPerson.Account.Password : user.Password;

                newPerson = await _personRepo.Update(oldPerson);
            }
            else
            {
                Account acc = await _accountRepo.Get(user.Username);
                if (acc != null)
                    return Conflict();

                _personRepo.UpdatePersonDetails(oldPerson.PersonId, user.Name, user.Address,
                                                user.Email, user.Username,
                                                string.IsNullOrEmpty(user.Password) ? oldPerson.Account.Password : user.Password,
                                                user.Role, oldPerson.Username);

                newPerson = new Person();
                newPerson.Name = user.Name;
                newPerson.Address = user.Address;
                newPerson.Email = user.Email;
                newPerson.Account = new Account();
                newPerson.Account.Username = user.Username;
                newPerson.Account.Role = user.Role;
            }

            return Ok(_mapper.Map<PersonDetails>(newPerson));
        }
    }
}
