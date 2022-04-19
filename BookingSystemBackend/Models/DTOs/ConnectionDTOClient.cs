using System;

namespace BookingSystemBackend.Models.DTOs
{
	public class ConnectionDTOClient
	{
		public int StartStationId { get; set; }
		public int EndStationId { get; set; }
		public string ArriveTime { get; set; }
		public string DepartureTime { get; set; }
		public int Distance { get; set; }
		public int Line { get; set; }
		public int OrderNumber { get; set; }
	}
}
