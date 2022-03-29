using System;

namespace BookingSystemBackend.Models.DTOs
{
	public class ConnectionDTO
	{
		public int StartStationId { get; set; }
		public int EndStationId { get; set; }
		public TimeSpan? ArriveTime { get; set; }
		public TimeSpan? DepartureTime { get; set; }
		public int Distance { get; set; }
		public int Line { get; set; }
		public int OrderNumber { get; set; };
	}
}
