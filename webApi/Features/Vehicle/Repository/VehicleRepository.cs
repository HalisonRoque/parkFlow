using Microsoft.EntityFrameworkCore;
using webApi.Data;
using VehicleEntity = webApi.Features.Vehicle.Models.Vehicle;

namespace webApi.Features.Vehicle.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleEntity>> GetAllVehicleAsync()
        {
            return await _context.Vehicle.ToListAsync();
        }

        public async Task<VehicleEntity?> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicle.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<VehicleEntity?> GetVehicleByPlateAsync(string vehicle)
        {
            return await _context.Vehicle.FirstOrDefaultAsync(v => v.Plate == vehicle);
        }

        public async Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle)
        {
            _context.Vehicle.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<VehicleEntity> UpdateVehicleAsync(VehicleEntity vehicle)
        {
            _context.Vehicle.Update(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task DeleteVehicleAsync(VehicleEntity vehicle)
        {
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}
