using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Airports.Commands
{
    public class CreateAirportCommand : IRequest
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

        public class Handler : IRequestHandler<CreateAirportCommand, Unit>
        {
            private readonly IFlightPathDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFlightPathDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
            {
                var entity = new Airport
                {
                  AirportName = request.AirportName,
                  Icao = request.Icao,
                  Designator = request.Designator,
                  Category = request.Category,
                  City = request.City,
                  Province = request.Province,
                  Country = request.Country,
                  Latitude = request.Latitude,
                  Longitude = request.Longitude,
                  Elevation = request.Elevation
                };

                _context.Airport.Add(entity);

                //await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new AirportCreated { Designator = entity.Designator }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
