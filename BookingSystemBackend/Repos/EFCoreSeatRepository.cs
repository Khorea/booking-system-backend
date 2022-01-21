using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCoreSeatRepository : EFCoreRepository<Seat, BookingSystemContext>, ISeatRepository
    {
        BookingSystemContext _context;

        public EFCoreSeatRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
