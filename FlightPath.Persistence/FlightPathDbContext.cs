using Microsoft.EntityFrameworkCore;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;


namespace FlightPath.Persistence
{
    public class FlightPathDbContext : DbContext, IFlightPathDbContext
    {
        public FlightPathDbContext(DbContextOptions<FlightPathDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<AirportFee> AirportFee { get; set; }
        public DbSet<AirportFuel> AirportFuel { get; set; }
        public DbSet<Radio> Radio { get; set; }
        public DbSet<Runway> Runway { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlightPathDbContext).Assembly);
        }
    }
}
