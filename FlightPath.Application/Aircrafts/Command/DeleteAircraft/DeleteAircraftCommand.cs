using System;
using MediatR;

namespace FlightPath.Application.Aircrafts.Commands
{
    public class DeleteAircraftCommand : IRequest
    {
        public int Id { get; set; }
    }
}
