using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookingSystemBackend.Utils.Enums;

namespace BookingSystemBackend.Models.DTOs
{
    public class CarDTOClient
    {
        public CarDTOClient(int carId, CarType carType, List<SeatDTOClient> seats)
        {
            CarId = carId;
            CarType = carType;
            Seats = seats;
        }

        public int CarId { get; set; }
        public CarType CarType { get; set; }
        public List<SeatDTOClient> Seats { get; set; }
    }
}
