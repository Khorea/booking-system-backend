using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
