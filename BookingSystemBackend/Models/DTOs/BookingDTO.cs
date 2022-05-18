using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
	public class BookingDTO
	{
        public ICollection<SubBookingDTO> SubBookings { get; set; }

        public string Username { get; set; }
    }
}
