using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class TrainDTO
    {
        public string TrainType { get; set; }
        public List<StationDTO> Stations { get; set; }
        public int FirstClass { get; set; }
        public int SecondClass { get; set; }
        public int FirstClassSlepper { get; set; }
        public int Couchette { get; set; }

    }
}
