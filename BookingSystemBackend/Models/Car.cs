using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string CarType { get; set; }

        [ForeignKey("Train")]
        public int TrainId { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}
