using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCoreStationRepository : EFCoreRepository<Station, BookingSystemContext>, IStationRepository
    {
        BookingSystemContext _context;

        public EFCoreStationRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
