using System;
using System.Threading.Tasks;
using aspnetcore_spa.Controllers.Resources;
using aspnetcore_spa.Models;
using aspnetcore_spa.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var vr = mapper.Map<Vehicle, VehicleResource>(vehicle);
            
            return Ok(vr);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v=>v.Id == id);
            if (vehicle == null)
                return NotFound();
            
            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            
            await context.SaveChangesAsync();

            var vr = mapper.Map<Vehicle, VehicleResource>(vehicle);
            
            return Ok(vr);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var vehicle = await context.Vehicles.FindAsync(id);
            if (vehicle == null)
                return NotFound();
            
            context.Remove(vehicle);
            await context.SaveChangesAsync();
       
            
            return Ok(id);
        }


        
    }
}