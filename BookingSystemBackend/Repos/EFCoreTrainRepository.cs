using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCoreTrainRepository : EFCoreRepository<Train, BookingSystemContext>, ITrainRepository
    {
        BookingSystemContext _context;

        public EFCoreTrainRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
