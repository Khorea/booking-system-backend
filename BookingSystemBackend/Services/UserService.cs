using BookingSystemBackend.Models;
using BookingSystemBackend.Models.DTOs;
using BookingSystemBackend.Models.DTOs.Builders;
using BookingSystemBackend.Repos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemBackend.Services
{
    public class UserService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IAccountRepository _accountRepository;

        public UserService(IPersonRepository personRepository, IAccountRepository accountRepository)
        {
            _personRepository = personRepository;
            _accountRepository = accountRepository;
        }

        public async Task<Person> PostUser(User user)
        {
            Person person = PersonBuilder.ToPerson(user);
            return await _personRepository.Add(person);
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            Account account = await _accountRepository.Get(loginDTO.Username);

            if (account != null && loginDTO.Password.Equals(account.Password))
            {
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Username", account.Username),
                        new Claim("Role", account.Role)
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("92041820582301542915")), SecurityAlgorithms.HmacSha256Signature)
                };
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
                string token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            else return "Incorrect username or password";
        }
    }
}
