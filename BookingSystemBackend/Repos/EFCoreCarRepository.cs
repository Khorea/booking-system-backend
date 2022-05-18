using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookingSystemBackend.Utils.Enums;

namespace BookingSystemBackend.Repos
{
    public class EFCoreCarRepository : EFCoreRepository<Car, BookingSystemContext>, ICarRepository
    {
        BookingSystemContext _context;

        public EFCoreCarRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<Car> Delete(int id)
        {
            var car = await _context.Cars.Include(x => x.Seats).FirstOrDefaultAsync(x => x.CarId == id);
            if (car == null)
            {
                return null;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> RemoveCar(int trainId, CarType carType)
        {
            var car = await _context.Cars.Include(x => x.Seats).Where(x => x.TrainId == trainId && x.CarType.Equals(carType)).FirstOrDefaultAsync();
            if (car == null)
            {
                return null;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
