using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCoreAccountRepository : EFCoreRepository<Account, BookingSystemContext>, IAccountRepository
    {
        private readonly BookingSystemContext _context;

        public EFCoreAccountRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account> Get(string id)
        {
            return await _context.Set<Account>().FindAsync(id);
        }
    }
}
