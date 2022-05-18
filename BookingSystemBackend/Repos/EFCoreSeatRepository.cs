using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task RemoveByCarIds(ICollection<int> carIds)
		{
            ICollection<Seat> seats = await _context.Seats.Where(x => carIds.Contains(x.CarId)).ToListAsync();
            await DeleteRange(seats);
		}

        public async Task<List<Seat>> GetByCarIds(List<int> carIds)
		{
            return await _context.Seats.Where(x => carIds.Contains(x.CarId)).ToListAsync();
		}
    }
}
