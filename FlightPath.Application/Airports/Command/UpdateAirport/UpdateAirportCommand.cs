using MediatR;
using Microsoft.EntityFrameworkCore;
using FlightPath.Application.Exceptions;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace FlightPath.Application.Airports.Commands
{
    public class UpdateAirportCommand : IRequest
    { 
        public string AirportName { get; set; }
        public bool Icao { get; set; }
        public string Designator { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Elevation { get; set; }
        public class Handler : IRequestHandler<UpdateAirportCommand, Unit>
        {
            private readonly IFlightPathDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFlightPathDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Airport
                    .SingleOrDefaultAsync(c => c.Designator == request.Designator, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Aircraft), request.Designator);
                }

                entity.AirportName = request.AirportName;
                entity.Icao = request.Icao;
                entity.Designator = request.Designator;
                entity.Category = request.Category;
                entity.City = request.City;
                entity.Province = request.Province;
                entity.Country = request.Country;
                entity.Latitude = request .Latitude;
                entity.Longitude = request.Longitude;
                entity.Elevation = request.Elevation;
               
                //await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
