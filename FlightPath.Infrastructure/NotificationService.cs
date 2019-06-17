using FlightPath.Application.Interfaces;
using FlightPath.Application.Notifications.Models;
using System.Threading.Tasks;

namespace FlightPath.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            //email, external service, queue etc.
            return Task.CompletedTask;
        }
    }
}
