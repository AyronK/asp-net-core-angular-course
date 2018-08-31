using System.Collections.Generic;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Persistence
{
    public interface IVehicleRepository
    {
        Task<Vehicle> FindAsync(int id, bool includeRelated = true);
        Task<IEnumerable<Vehicle>> GetAsync();

        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}