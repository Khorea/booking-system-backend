using BookingSystemBackend.Models;
using BookingSystemBackend.Models.DTOs;
using BookingSystemBackend.Repos;
using BookingSystemBackend.Services;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace BookingSystemTests
{
    public class LoginTest
    {
        [Fact]
        public async void Test_Login_Succesful()
        {
            var loginDTO = new LoginDTO
            {
                Username = "horea",
                Password = "pass123",
            };
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(repo => repo.Get(loginDTO.Username))
                .ReturnsAsync(new Account
                {
                    Username = "horea",
                    Password = "pass123",
                    Role = "admin"
                });
            var userService = new UserService(
                new Mock<IPersonRepository>().Object,
                accountRepositoryMock.Object
            );
            string token = await userService.Login(loginDTO);
            Assert.False(token.Equals("Incorrect username or password"));

            SecurityToken validatedToken;
            TokenValidationParameters parameters = new TokenValidationParameters();
            parameters.ValidateAudience = false;
            parameters.ValidateIssuer = false;
            parameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("92041820582301542915"));
            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, parameters, out validatedToken);

            Assert.True(principal != null && principal.FindFirst("Role").Value.Equals("admin"));
        }

        [Fact]
        public async void Test_Login_InvalidPassword()
        {
            var loginDTO = new LoginDTO
            {
                Username = "horea",
                Password = "wrongPassword"
            };
            var accountRepositoryMock = new Mock<IAccountRepository>();
            accountRepositoryMock.Setup(repo => repo.Get(loginDTO.Username))
                .ReturnsAsync(new Account
                {
                    Username = "horea",
                    Password = "pass123",
                    Role = "admin"
                });
            var userService = new UserService(
                new Mock<IPersonRepository>().Object,
                accountRepositoryMock.Object
            );
            string token = await userService.Login(loginDTO);
            Assert.True(token.Equals("Incorrect username or password"));
        }
    }
}