using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
	public class EFCoreConnectionRepository : EFCoreRepository<Connection, BookingSystemContext>, IConnectionRepository
	{
        private readonly BookingSystemContext _context;

        public EFCoreConnectionRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Connection>> GetAllIncludeEverythingAsync()
		{
            return await _context.Connections
                .Include(c => c.StartStation)
                .Include(c => c.EndStation)
                .Include(c => c.Train)
                .ToListAsync();
        }
    }
}
