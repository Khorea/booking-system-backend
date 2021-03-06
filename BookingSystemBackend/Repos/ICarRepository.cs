using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> RemoveCar(int trainId, string carType);
    }
}
