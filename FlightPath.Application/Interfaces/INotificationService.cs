using System;
using System.Threading.Tasks;
using FlightPath.Application.Notifications.Models;

namespace FlightPath.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
