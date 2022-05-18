using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
	public class EFCoreSubBookingRepository : EFCoreRepository<SubBooking, BookingSystemContext>, ISubBookingRepository
	{
		BookingSystemContext _context;

		public EFCoreSubBookingRepository(BookingSystemContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<SubBooking>> GetByTrainIdAndDate(int trainId, DateTime date)
		{
			return await _context.SubBookings.Where(x => x.TrainId == trainId && x.BookingDate.Date == date).ToListAsync();
		}
	}
}
