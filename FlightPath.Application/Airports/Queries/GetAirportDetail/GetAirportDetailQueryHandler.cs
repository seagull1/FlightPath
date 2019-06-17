using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FlightPath.Application.Exceptions;
using FlightPath.Application.Interfaces;
using FlightPath.Domain.Entities;

namespace FlightPath.Application.Airports.Queries
{
    public class GetAirportDetailQueryHandler : IRequestHandler<GetAirportDetailQuery, AirportDetailModel>
    {
        private readonly IFlightPathDbContext _context;

        public GetAirportDetailQueryHandler(IFlightPathDbContext context)
        {
            _context = context;
        }

        public async Task<AirportDetailModel> Handle(GetAirportDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Airport
                .FindAsync(request.Designator);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Airport), request.Designator);
            }

            return AirportDetailModel.Create(entity);
        }
    }
}
