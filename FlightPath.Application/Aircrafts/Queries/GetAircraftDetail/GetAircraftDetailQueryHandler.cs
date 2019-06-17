using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FlightPath.Application.Exceptions;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Aircrafts.Queries
{
    public class GetAircraftDetailQueryHandler : IRequestHandler<GetAircraftDetailQuery, AircraftDetailModel>
    {
        private readonly IFlightPathDbContext _context;

        public GetAircraftDetailQueryHandler(IFlightPathDbContext context)
        {
            _context = context;
        }

        public async Task<AircraftDetailModel> Handle(GetAircraftDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Aircraft
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Aircraft), request.Id);
            }

            return AircraftDetailModel.Create(entity);
        }
    }
}
