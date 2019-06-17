using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FlightPath.Application.Exceptions;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Airports.Commands
{
    public class DeleteAirportCommandHandler: IRequestHandler<DeleteAirportCommand>
    {
        private readonly IFlightPathDbContext _context;

        public DeleteAirportCommandHandler(IFlightPathDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAirportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Airport.FindAsync(request.Designator);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Airport), request.Designator);
            }

            _context.Airport.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
