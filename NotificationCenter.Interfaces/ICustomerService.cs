using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationCenter.Interfaces.Models;
using NotificationCenter.Interfaces.Enums;

namespace NotificationCenter.Interfaces
{
    public interface ICustomerService
    {
        Task<ICollection<Notification>> GetClientNotificationsAsync(long clientId, DateTime? fromDate = null, DateTime? toDate = null, NotificationStatus[] status = null);

        void MarkNotificationAsSeen(long notificationId);

        void DeleteNotification(long notificationId);

        event Action NewNotification;
    }
}
