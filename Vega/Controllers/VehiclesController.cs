using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly VegaDbContext dbContext;
        private readonly IMapper mapper;

        public VehiclesController(VegaDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vehicles = await dbContext.Vehicles
                .Include(v => v.Features).ToListAsync();

            var result = vehicles.Select(mapper.Map<Vehicle, VehicleResource>);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await dbContext.Vehicles
                .Include(v => v.Features)
                .SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleResource vehicleResource)
        {
            ValidateCustom(vehicleResource);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            dbContext.Vehicles.Add(vehicle);
            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicleResource.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleResource vehicleResource)
        {
            var vehicle = await dbContext.Vehicles
                .Include(v=>v.Features)
                .SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            ValidateCustom(vehicleResource);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            mapper.Map(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await dbContext.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        private void ValidateCustom(VehicleResource vehicleResource)
        {
            if (!vehicleResource.Features.Any())
                ModelState.AddModelError(nameof(vehicleResource.Features), "At least one feature is required");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            dbContext.Vehicles.Remove(vehicle);
            await dbContext.SaveChangesAsync();

            return Ok(id);
        }
    }
}