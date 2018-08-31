using System.Collections.Generic;

namespace Vega.Controllers.Resources.Vehicle
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<int> Features { get; set; } = new List<int>();

        public ContactResource Contact { get; set; }
    }
}
