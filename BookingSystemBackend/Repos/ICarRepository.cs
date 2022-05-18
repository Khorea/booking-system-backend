using BookingSystemBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookingSystemBackend.Utils.Enums;

namespace BookingSystemBackend.Repos
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> RemoveCar(int trainId, CarType carType);
    }
}
