using MediatR;

namespace FlightPath.Application.Route.Queries
{
    public class GetAirportDtosListQuery : IRequest<AirportDtosListViewModel>
    {
        public int AircraftId { get; set; }
        public string StartAirport { set; get; }
        public string EndAirport { set; get; }
    }
}
