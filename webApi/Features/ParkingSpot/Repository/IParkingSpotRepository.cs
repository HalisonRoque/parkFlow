using ParkingSpotEntity = webApi.Features.ParkingSpot.Models.ParkingSpot;

namespace webApi.Features.ParkingSpot.Repository
{
    public interface IParkingSpotRepository
    {
        Task<List<ParkingSpotEntity>> GetAllParkingSpotAsync();
        Task<ParkingSpotEntity?> GetParkingSpotByIdAsync(int id);

        Task<ParkingSpotEntity> CreateParkingSpotAsync(ParkingSpotEntity parkingSpot);

        Task<ParkingSpotEntity> UpdateParkingSpotAsync(ParkingSpotEntity parkingSpot);

        Task DeleteParkingSpotAsync(ParkingSpotEntity parkingSpot);
    }
}
