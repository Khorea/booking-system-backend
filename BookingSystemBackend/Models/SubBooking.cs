using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
	public class SubBooking
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubBookingId { get; set; }

        [ForeignKey("Booking")]
        public int BookingId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BookingDate { get; set; }

        [ForeignKey("Train")]
        public int TrainId { get; set; }

        public Train Train { get; set; }

        [ForeignKey("Seat")]
        public int SeatId { get; set; }

        public Seat Seat { get; set; }

        [ForeignKey("Station")]
        public int FirstStationId { get; set; }

        public Station FirstStation { get; set; }

        [ForeignKey("Station")]
        public int SecondStationId { get; set; }

        public Station SecondStation { get; set; }

        public int Price { get; set; }
    }
}
