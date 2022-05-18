using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class CarDTOClient
    {
        public CarDTOClient(int carId, string carType, List<SeatDTOClient> seats)
        {
            CarId = carId;
            CarType = carType;
            Seats = seats;
        }

        public int CarId { get; set; }
        public string CarType { get; set; }
        public List<SeatDTOClient> Seats { get; set; }
    }
}
