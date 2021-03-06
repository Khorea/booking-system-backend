using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task RemoveByCarIds(ICollection<int> carIds);

        Task<List<Seat>> GetByCarIds(List<int> carIds);
    }
}
