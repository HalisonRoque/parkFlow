using Microsoft.EntityFrameworkCore;
using webApi.Data;
using ParkingSpotEntity = webApi.Features.ParkingSpot.Models.ParkingSpot;

namespace webApi.Features.ParkingSpot.Repository
{
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        private readonly AppDbContext _context;

        public ParkingSpotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParkingSpotEntity>> GetAllParkingSpotAsync()
        {
            return await _context.Parking_Spot.ToListAsync();
        }

        public async Task<ParkingSpotEntity?> GetParkingSpotByIdAsync(int id)
        {
            return await _context.Parking_Spot.FirstOrDefaultAsync(ps => ps.Id == id);
        }

        public async Task<ParkingSpotEntity> CreateParkingSpotAsync(ParkingSpotEntity parkingSpot)
        {
            _context.Parking_Spot.Add(parkingSpot);
            await _context.SaveChangesAsync();
            return parkingSpot;
        }

        public async Task<ParkingSpotEntity> UpdateParkingSpotAsync(ParkingSpotEntity parkingSpot)
        {
            _context.Parking_Spot.Update(parkingSpot);
            await _context.SaveChangesAsync();
            return parkingSpot;
        }

        public async Task DeleteParkingSpotAsync(ParkingSpotEntity parkingSpot)
        {
            _context.Parking_Spot.Remove(parkingSpot);
            await _context.SaveChangesAsync();
        }
    }
}
