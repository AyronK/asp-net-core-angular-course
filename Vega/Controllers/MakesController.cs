using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext dbContext;
        private readonly IMapper mapper;

        public MakesController(VegaDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await dbContext.Makes.Include(m=>m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

    }
}