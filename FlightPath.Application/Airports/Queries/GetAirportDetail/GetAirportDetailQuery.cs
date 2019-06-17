using MediatR;

namespace FlightPath.Application.Airports.Queries
{
    public class GetAirportDetailQuery: IRequest<AirportDetailModel>
    {
        public string Designator { get; set; }
    }
}
