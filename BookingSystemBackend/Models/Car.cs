using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static BookingSystemBackend.Utils.Enums;

namespace BookingSystemBackend.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public CarType CarType { get; set; }

        [ForeignKey("Train")]
        public int TrainId { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public Car() { }
        public Car(CarType carType, int trainId)
        {
            CarType = carType;
            TrainId = trainId;
            Seats = new List<Seat>();
        }

    }
}
