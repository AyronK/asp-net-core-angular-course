using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Controllers.Resources.Vehicle;
using Vega.Core;
using Vega.Core.Models;

namespace Vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var vehicles = await repository.GetAsync();

            var result = vehicles.Select(mapper.Map<Vehicle, VehicleResource>);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await repository.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveVehicleResource saveVehicleResource)
        {
            ValidateCustom(saveVehicleResource);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(saveVehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();

            vehicle = await repository.FindAsync(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return CreatedAtAction(nameof(Get), new { id = saveVehicleResource.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveVehicleResource saveVehicleResource)
        {
            var vehicle = await repository.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            ValidateCustom(saveVehicleResource);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            mapper.Map(saveVehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            vehicle = await repository.FindAsync(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        private void ValidateCustom(SaveVehicleResource saveVehicleResource)
        {
            if (!saveVehicleResource.Features.Any())
                ModelState.AddModelError(nameof(saveVehicleResource.Features), "At least one feature is required");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await repository.FindAsync(id, false);

            if (vehicle == null)
                return NotFound();

            repository.Remove(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}