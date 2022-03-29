using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystemBackend.Models
{
	public class Connection
	{
		[ForeignKey("Station")]
		public int StartStationId { get; set; }

		public Station StartStation { get; set; }

		[ForeignKey("Station")]
		public int EndStationId { get; set; }

		public Station EndStation { get; set; }

		[ForeignKey("Train")]
		public int TrainId { get; set; }

		public Train Train { get; set; }

		[Column(TypeName = "time(7)")]
		public TimeSpan? ArriveTime { get; set; }

		[Column(TypeName = "time(7)")]
		public TimeSpan? DepartureTime { get; set; }

		public int Distance { get; set; }

		public int Line { get; set; }

		public int OrderNumber { get; set; }
	}
}
