using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Station
    {
        [Key]
        public int StationId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Location { get; set; }

        [ForeignKey("Train")]
        public int TrainId { get; set; }

        public Train Train { get; set; }

        public DateTime? ArriveTime { get; set; }

        public DateTime? DepartureTime { get; set; }

        public int DistanceTraversed { get; set; }

        public int OrderNumber { get; set; }
    }
}
