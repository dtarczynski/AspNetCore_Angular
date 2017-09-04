using System.Threading.Tasks;
using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using aspnetcore_spa.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_spa.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var vr = mapper.Map<Vehicle, VehicleResource>(vehicle);
            
            return Ok(vr);
        }
    }
}