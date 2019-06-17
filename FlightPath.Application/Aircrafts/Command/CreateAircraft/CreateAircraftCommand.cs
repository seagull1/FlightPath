using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Aircrafts.Commands
{
    public class CreateAircraftCommand : IRequest
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int FuelCapacity { get; set; }
        public int SpeedCruise { get; set; }
        public int Range { get; set; }
        public int Ceiling { get; set; }

        public class Handler : IRequestHandler<CreateAircraftCommand, Unit>
        {
            private readonly IFlightPathDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFlightPathDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
            {
                var entity = new Aircraft
                {
                   Id = request.Id,
                   Make = request.Make,
                   Model = request.Model,
                   FuelCapacity = request.FuelCapacity,
                   SpeedCruise = request.SpeedCruise,
                   Range = request.Range,
                   Ceiling = request.Ceiling
                };

                _context.Aircraft.Add(entity);

                //await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new AircraftCreated { AircraftId = entity.Id }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
