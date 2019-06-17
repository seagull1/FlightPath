using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FlightPath.Application.Exceptions;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Aircrafts.Commands
{
    public class DeleteAircraftCommandHandler: IRequestHandler<DeleteAircraftCommand>
    {
        private readonly IFlightPathDbContext _context;

        public DeleteAircraftCommandHandler(IFlightPathDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAircraftCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Aircraft.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Aircraft), request.Id);
            }

            _context.Aircraft.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
