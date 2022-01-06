using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCorePersonRepository : EFCoreRepository<Person, BookingSystemContext>, IPersonRepository
    {
        public EFCorePersonRepository(BookingSystemContext context) : base(context)
        {
        }

        public Task<List<Person>> GetSorted()
        {
            throw new NotImplementedException();
        }
    }
}
