using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<Account> Get(string id);
    }
}
