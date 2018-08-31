using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Controllers.Resources
{
    public class ContactResource
    {
        [Required] [StringLength(255)] public string Name { get; set; }

        [Required] [StringLength(32)] public string Phone { get; set; }

        [StringLength(255)] public string Email { get; set; }
    }
}
