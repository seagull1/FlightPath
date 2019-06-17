using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FlightPath.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace FlightPath.Application.Airports.Queries
{
    public class GetAirportsListQueryHandler : IRequestHandler<GetAirportsListQuery, AirportsListViewModel>
    {
        private readonly IFlightPathDbContext _context;
        private readonly IMapper _mapper;

        public GetAirportsListQueryHandler(IFlightPathDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AirportsListViewModel> Handle(GetAirportsListQuery request, CancellationToken cancellationToken)
        {
            return new AirportsListViewModel
            {
                Airports = await _context.Airport.ProjectTo<AirportLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
