using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
	public class EFCoreBookingRepository : EFCoreRepository<Booking, BookingSystemContext>, IBookingRepository
	{
		BookingSystemContext _context;

		public EFCoreBookingRepository(BookingSystemContext context) : base(context)
		{
			_context = context;
		}
	}
}
