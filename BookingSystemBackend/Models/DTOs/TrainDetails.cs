using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class TrainDetails
    {
        public int TrainId { get; set; }
        public string TrainType { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string TotalDuration { get; set; }
        public int StationCount { get; set; }
    }
}
