using MediatR;

namespace FlightPath.Application.Aircrafts.Queries
{
    public class GetAircraftsListQuery : IRequest<AircraftsListViewModel>
    {
    }
}
