namespace BookingSystemBackend.Models.DTOs
{
    public class SeatDTOClient
    {
        public SeatDTOClient(int seatId)
        {
            SeatId = seatId;
        }

        public int SeatId { get; set; }
    }
}
