using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vega.Core.Models.JoinEntities;

namespace Vega.Core.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public Model Model { get; set; }

        [Required] public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<VehicleFeature> Features { get; set; } = new List<VehicleFeature>();

        [Required]
        public Contact Contact { get; set; }

        public DateTime LastUpdate { get; set; }
    }

    public class Contact
    {
        [Required] [StringLength(255)] public string Name { get; set; }

        [Required] [StringLength(32)] public string Phone { get; set; }

        [StringLength(255)] public string Email { get; set; }
    }
}