using Microsoft.EntityFrameworkCore;
using FlightPath.Persistence.Infrastructure;

namespace FlightPath.Persistence
{
    public class FlightPathDbContestFactory : DesignTimeDbContextFactoryBase<FlightPathDbContext>
    {
        protected override FlightPathDbContext CreateNewInstance(DbContextOptions<FlightPathDbContext> options)
        {
            return new FlightPathDbContext(options);
        }
    }
}
