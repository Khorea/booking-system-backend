using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCoreCarRepository : EFCoreRepository<Car, BookingSystemContext>, ICarRepository
    {
        BookingSystemContext _context;

        public EFCoreCarRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
