using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class StationDTO
    {
        public int StationId { get; set; }
        public string Location { get; set; }
        public string ArriveTime { get; set; }
        public string DepartureTime { get; set; }
        public int Distance { get; set; }
        public int Line { get; set; }
        public int OrderNumber { get; set; }
    }
}
