using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vega.Models.JoinEntities;

namespace Vega.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public Model Model { get; set; }

        [Required] public int ModelId { get; set; }

        public ICollection<VehicleFeature> VehicleFeatures { get; set; }

        [Required] [StringLength(255)] public string ContactName { get; set; }

        [Required] [StringLength(32)] public string ContactPhone { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}