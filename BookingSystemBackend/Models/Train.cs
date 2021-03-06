using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string TrainType { get; set; }

        public ICollection<Car> Cars { get; set; }

        public ICollection<Connection> Connections { get; set; }

        public Train() { }

        public Train(string trainType, ICollection<Car> cars, ICollection<Connection> connections)
        {
            TrainType = trainType;
            Cars = cars;
            Connections = connections;
        }
    }
}
