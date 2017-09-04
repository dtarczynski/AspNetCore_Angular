using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_spa.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        public VehiclesController(IMapper mapper)
        {
            this.mapper = mapper;

        }
        [HttpPost]
        public IActionResult CreateVehicle([FromBody]VehicleResource vehicleResource)
        {
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            return Ok(vehicle);
        }
    }
}