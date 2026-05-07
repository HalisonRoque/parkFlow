using webApi.Features.Vehicle.Dtos;

namespace webApi.Features.Vehicle.Services
{
    public interface IVehicleService
    {
        Task<List<ResponseVehicleDto>> GetAllVehicleAsync();

        Task<ResponseVehicleDto?> GetVehicleByIdAsync(int id);

        Task<ResponseVehicleDto?> GetVehicleByPlateAsync(string plate);

        Task<ResponseVehicleDto> CreateVehicleAsync(CreateVehicleDto vehicle);

        Task<ResponseVehicleDto> UpdateVehicleAsync(int id, UpdateVehicleDto vehicle);

        Task DeleteVehicleAsync(int id);
    }
}
