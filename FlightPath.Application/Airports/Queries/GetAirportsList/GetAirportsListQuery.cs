using MediatR;

namespace FlightPath.Application.Airports.Queries
{
    public class GetAirportsListQuery : IRequest<AirportsListViewModel>
    {
    }
}
