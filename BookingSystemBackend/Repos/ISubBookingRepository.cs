using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
	public interface ISubBookingRepository : IRepository<SubBooking>
	{
		public Task<List<SubBooking>> GetByTrainIdAndDate(int trainId, DateTime date);
	}
}
