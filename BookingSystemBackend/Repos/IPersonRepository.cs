using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Task<Person> GetByUsername(string username);

        public void UpdatePersonDetails(int personId, string name, string address, string email, string username, string password, string role, string oldUsername);

        public Task<List<Person>> GetAllWithAccounts();
    }
}
