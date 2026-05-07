namespace webApi.Features.Vehicle.Dtos
{
    public class ResponseVehicleDto
    {
        public int Id { get; set; }
        public string Plate { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int ClientId { get; set; }
    }
}
