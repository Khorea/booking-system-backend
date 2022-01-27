using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Repos
{
    public class EFCoreTrainRepository : EFCoreRepository<Train, BookingSystemContext>, ITrainRepository
    {
        BookingSystemContext _context;

        public EFCoreTrainRepository(BookingSystemContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<Train> Get(int trainId)
        {
            return await _context.Trains
                .Include(x => x.Stations)
                .Include(x => x.Cars)
                .FirstOrDefaultAsync(x => x.TrainId == trainId);
        }

        public async new Task<List<Train>> GetAll()
        {
            return await _context.Trains.Include(x => x.Stations).ToListAsync();
        }

        public new async Task<Train> Delete(int id)
        {
            Train train = await _context.Trains.Include(x => x.Stations)
                .Include(x => x.Cars)
                .Include(x => x.Cars).SingleAsync(x => x.TrainId == id);
            if (train == null)
            {
                return train;
            }
            foreach (Car car in train.Cars)
            {
                Car c = await _context.Cars.Include(x => x.Seats).SingleAsync(x => x.CarId == car.CarId);
                _context.Remove(c);
            }

            _context.Remove(train);

            await _context.SaveChangesAsync();

            return train;
        }
    }
}
