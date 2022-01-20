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
        BookingSystemContext _context;

        public EFCorePersonRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Person> GetByUsername(string username)
        {
            return await _context.People
                .Where(p => p.Username.Equals(username))
                .Include(a => a.Account)
                .FirstOrDefaultAsync();
        }
    }
}
