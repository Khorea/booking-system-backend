using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
	public class SubBookingDTO
	{
        public DateTime BookingDate { get; set; }

        public int TrainId { get; set; }

        public string CarType { get; set; }

        public int FirstStationId { get; set; }

        public int SecondStationId { get; set; }
    }
}
