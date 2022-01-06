using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        public ICollection<Station> Stations { get; set; }

        [ForeignKey("Train"), Column(TypeName = "nvarchar(30)")]
        public string TrainId { get; set; }

        public Train Train { get; set; }
    }
}
