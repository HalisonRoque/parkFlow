namespace webApi.Features.Ticket.Dtos
{
    public class ResponseTicketDto
    {
        public int Id { get; set; }

        public DateTime EntryTime { get; set; }

        public DateTime? ExitTime { get; set; }

        public decimal? TotalPrice { get; set; }

        public int VehicleId { get; set; }

        public int ParkingSpotId { get; set; }
    }
}
