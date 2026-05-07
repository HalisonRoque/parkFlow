using webApi.Features.Vehicle.Dtos;
using webApi.Features.Vehicle.Repository;
using VehicleEntity = webApi.Features.Vehicle.Models.Vehicle;

namespace webApi.Features.Vehicle.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<ResponseVehicleDto>> GetAllVehicleAsync()
        {
            var vehicles = await _vehicleRepository.GetAllVehicleAsync();

            return vehicles
                .Select(v => new ResponseVehicleDto
                {
                    Id = v.Id,
                    Plate = v.Plate,
                    Model = v.Model,
                    ClientId = v.ClientId,
                })
                .ToList();
        }

        public async Task<ResponseVehicleDto?> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);

            if (vehicle == null)
            {
                throw new Exception("Veículo não localizado");
            }

            return new ResponseVehicleDto
            {
                Id = vehicle.Id,
                Plate = vehicle.Plate,
                Model = vehicle.Model,
                ClientId = vehicle.ClientId,
            };
        }

        public async Task<ResponseVehicleDto?> GetVehicleByPlateAsync(string plate)
        {
            var findVehicle = await _vehicleRepository.GetVehicleByPlateAsync(plate);

            if (findVehicle == null)
            {
                throw new Exception("Veículo não encontrado");
            }

            return new ResponseVehicleDto
            {
                Id = findVehicle.Id,
                Plate = findVehicle.Plate,
                Model = findVehicle.Model,
                ClientId = findVehicle.ClientId,
            };
        }

        public async Task<ResponseVehicleDto> CreateVehicleAsync(CreateVehicleDto body)
        {
            var vehicle = new VehicleEntity
            {
                Plate = body.Plate.Trim(),
                Model = body.Model.Trim(),
                ClientId = body.ClientId,
            };

            var newVehicle = await _vehicleRepository.CreateVehicleAsync(vehicle);

            return new ResponseVehicleDto
            {
                Id = newVehicle.Id,
                Plate = newVehicle.Plate,
                Model = newVehicle.Model,
                ClientId = newVehicle.ClientId,
            };
        }

        public async Task<ResponseVehicleDto> UpdateVehicleAsync(int id, UpdateVehicleDto body)
        {
            var findVehicle = await _vehicleRepository.GetVehicleByIdAsync(id);

            if (findVehicle == null)
            {
                throw new Exception("Veículo não encontrado!");
            }

            findVehicle.Plate = body.Plate;
            findVehicle.Model = body.Model;

            var updateVehicle = await _vehicleRepository.UpdateVehicleAsync(findVehicle);

            return new ResponseVehicleDto
            {
                Id = updateVehicle.Id,
                Plate = updateVehicle.Plate,
                Model = updateVehicle.Model,
                ClientId = updateVehicle.ClientId,
            };
        }

        public async Task DeleteVehicleAsync(int id)
        {
            var findVehicle = await _vehicleRepository.GetVehicleByIdAsync(id);

            if (findVehicle == null)
            {
                throw new Exception("Veículo não encontrado");
            }

            await _vehicleRepository.DeleteVehicleAsync(findVehicle);
        }
    }
}
