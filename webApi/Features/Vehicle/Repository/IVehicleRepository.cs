using VehicleEntity = webApi.Features.Vehicle.Models.Vehicle;

namespace webApi.Features.Vehicle.Repository
{
    public interface IVehicleRepository
    {
        Task<List<VehicleEntity>> GetAllVehicleAsync();
        Task<VehicleEntity?> GetVehicleByIdAsync(int id);

        Task<VehicleEntity?> GetVehicleByPlateAsync(string vehicle);

        Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle);

        Task<VehicleEntity> UpdateVehicleAsync(VehicleEntity vehicle);

        Task DeleteVehicleAsync(VehicleEntity vehicle);
    }
}
