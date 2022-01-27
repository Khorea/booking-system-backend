using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class TrainLayout
    {
        public int FirstClass { get; set; }
        public int SecondClass { get; set; }
        public int FirstClassSleeper { get; set; }
        public int Couchette { get; set; }
    }
}
