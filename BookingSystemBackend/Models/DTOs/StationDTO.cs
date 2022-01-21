using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class StationDTO
    {
        public string Location { get; set; }
        public DateTime ArriveTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int DistanceTraversed { get; set; }
        public int OrderNumber { get; set; }
    }
}
