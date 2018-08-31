using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vega.Core.Models.JoinEntities;

namespace Vega.Core.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }

        public ICollection<VehicleFeature> Vehicles { get; set; }
    }
}