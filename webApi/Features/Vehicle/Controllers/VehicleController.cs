using Microsoft.AspNetCore.Mvc;
using webApi.Features.Vehicle.Dtos;
using webApi.Features.Vehicle.Services;

namespace webApi.Features.Vehicle.Controller
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllVehicle()
        {
            var vehicles = await _vehicleService.GetAllVehicleAsync();
            return Ok(vehicles);
        }

        [HttpGet("findBy/{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            return Ok(vehicle);
        }

        [HttpGet("find/plate/{plate}")]
        public async Task<IActionResult> GetVehicleByPlate(string plate)
        {
            var vehicle = await _vehicleService.GetVehicleByPlateAsync(plate);
            return Ok(vehicle);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDto body)
        {
            var vehicle = await _vehicleService.CreateVehicleAsync(body);
            return Ok(vehicle);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] UpdateVehicleDto body)
        {
            await _vehicleService.UpdateVehicleAsync(id, body);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return NoContent();
        }
    }
}
