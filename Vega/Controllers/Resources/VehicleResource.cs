using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;
using Vega.Models.JoinEntities;

namespace Vega.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<int> Features { get; set; } = new List<int>();

        public ContactResource Contact { get; set; }
    }
}
