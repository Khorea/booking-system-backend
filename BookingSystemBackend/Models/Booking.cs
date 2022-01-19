using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Booking
    {
        [Column(TypeName = "Date")]
        public DateTime BookingDate { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        [ForeignKey("Train")]
        public int TrainId { get; set; }

        public Train Train { get; set; }

        [ForeignKey("Seat")]
        public int SeatId { get; set; }
    }
}
