using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FlightPath.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace FlightPath.Application.Aircrafts.Queries
{
    public class GetAircraftsListQueryHandler : IRequestHandler<GetAircraftsListQuery, AircraftsListViewModel>
    {
        private readonly IFlightPathDbContext _context;
        private readonly IMapper _mapper;

        public GetAircraftsListQueryHandler(IFlightPathDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AircraftsListViewModel> Handle(GetAircraftsListQuery request, CancellationToken cancellationToken)
        {
            return new AircraftsListViewModel
            {
                Aircrafts = await _context.Aircraft
                .ProjectTo<AircraftLookupModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
