using Microsoft.EntityFrameworkCore;
using FlightPath.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FlightPath.Application.Interfaces
{
    public interface IFlightPathDbContext
    {
        DbSet<Aircraft> Aircraft { get; set; }
        DbSet<Airport> Airport { get; set; }
        DbSet<AirportFee> AirportFee { get; set; }
        DbSet<AirportFuel> AirportFuel { get; set; }
        DbSet<Radio> Radio { get; set; }
        DbSet<Runway> Runway { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
