using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
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

        public new async Task<Train> Get(int trainId)
        {
            return await _context.Trains
                .Include(x => x.Connections)
                .Include(x => x.Cars)
                .ThenInclude(x => x.Seats)
                .FirstOrDefaultAsync(x => x.TrainId == trainId);
        }

        public async new Task<List<Train>> GetAll()
        {
            return await _context.Trains
                .Include(x => x.Connections)
                .Include(x => x.Cars)
                .ThenInclude(x => x.Seats)
                .ToListAsync();
        }
    }
}
