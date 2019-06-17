using MediatR;

namespace FlightPath.Application.Aircrafts.Queries
{
    public class GetAircraftDetailQuery: IRequest<AircraftDetailModel>
    {
        public int Id { get; set; }
    }
}
