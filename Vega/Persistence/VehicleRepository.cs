using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Vega.Models;

namespace Vega.Persistence
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext dbContext;

        public VehicleRepository(VegaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Vehicle> FindAsync(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await dbContext.Vehicles.SingleOrDefaultAsync(v => v.Id == id);

            return await QueryVehiclesWithRelated().SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vehicle>> GetAsync()
        {
            return await QueryVehiclesWithRelated().ToListAsync();
        }

        public void Add(Vehicle vehicle)
        {
            dbContext.Vehicles.Add(vehicle);
        }

        public void Remove(Vehicle vehicle)
        {
            dbContext.Vehicles.Remove(vehicle);
        }

        private IIncludableQueryable<Vehicle, Make> QueryVehiclesWithRelated()
        {
            return dbContext.Vehicles
                .Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                .ThenInclude(vm => vm.Make);
        }

        //public Task<IEnumerable<Vehicle>> GetAsync()
        //{
        //    return await dbContext.Vehicles
        //        .Include(v => v.Features)
        //        .ThenInclude(vf => vf.Feature)
        //        .Include(v => v.Model)
        //        .ThenInclude(vm => vm.Make).ToAsyncEnumerable();
        //}
    }
}