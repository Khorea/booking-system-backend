using BookingSystemBackend.Models;
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
    }
}
