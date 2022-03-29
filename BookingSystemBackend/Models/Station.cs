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
        public string Name { get; set; }
    }
}
