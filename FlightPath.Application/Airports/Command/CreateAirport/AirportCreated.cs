using MediatR;
using FlightPath.Application.Interfaces;
using FlightPath.Application.Notifications.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FlightPath.Application.Airports.Commands
{
    public class AirportCreated : INotification
    {
        public string Designator { get; set; }

        public class AirportCreatedHandler : INotificationHandler<AirportCreated>
        {
            private readonly INotificationService _notification;

            public AirportCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(AirportCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
