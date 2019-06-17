using MediatR;

namespace FlightPath.Application.Airports.Commands
{
    public class DeleteAirportCommand : IRequest
    {
        public string Designator { get; set; }
    }
}
