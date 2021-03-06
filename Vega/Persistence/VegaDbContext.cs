using Microsoft.EntityFrameworkCore;
using Vega.Core.Models;
using Vega.Core.Models.JoinEntities;

namespace Vega.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(vf => new { vf.VehicleId, vf.FeatureId });

            modelBuilder.Entity<Vehicle>().OwnsOne(v => v.Contact);
        }
    }
}