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
        [Key, Column(TypeName = "nvarchar(30)")]
        public string TrainId { get; set; }

        public ICollection<Route> Routes { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
