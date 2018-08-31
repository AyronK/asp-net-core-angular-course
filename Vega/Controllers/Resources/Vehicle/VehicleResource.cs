using System;
using System.Collections.Generic;

namespace Vega.Controllers.Resources.Vehicle
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public KeyValuePairResourse Model { get; set; }
        
        public KeyValuePairResourse Make { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<KeyValuePairResourse> Features { get; set; } = new List<KeyValuePairResourse>();

        public ContactResource Contact { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
