using MediatR;
using FlightPath.Application.Interfaces;
using FlightPath.Application.Notifications.Models;
using System.Threading;
using System.Threading.Tasks;

namespace FlightPath.Application.Aircrafts.Commands
{
    public class AircraftCreated : INotification
    {
        public int AircraftId { get; set; }

        public class AircraftCreatedHandler : INotificationHandler<AircraftCreated>
        {
            private readonly INotificationService _notification;

            public AircraftCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(AircraftCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
