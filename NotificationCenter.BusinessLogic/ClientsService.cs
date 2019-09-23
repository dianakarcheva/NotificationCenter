using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using NotificationCenter.Interfaces;
using NotificationCenter.Interfaces.Enums;
using NotificationCenter.Interfaces.Models;

namespace NotificationCenter.BusinessLogic
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService()
        {
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["NotificationCenterContext"].ConnectionString);

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NotificationCenterContext"].ConnectionString);

            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM [dbo].[Notifications]",
                Notification = null
            };
            command.Connection.Open();

            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += (sender, args) => { NewNotification?.Invoke(); };
            command.ExecuteReader();
        }

        public event Action NewNotification;

        public void DeleteNotification(long notificationId)
        {
            var notification = _db.Notifications.SingleOrDefault(n => n.Id == notificationId);
            if(notification != null)
            {
                notification.Deleted = true;
                _db.SaveChanges();
            }
        }

        public async Task<ICollection<Notification>> GetClientNotificationsAsync(long clientId, DateTime? fromDate = null, DateTime? toDate = null, NotificationStatus[] status = null)
        {
            await Task.Yield();
            return _db.Notifications.Where(n => !n.Deleted).Select(n => new Notification() {
                ClientId = clientId,
                CreatedOn = n.CreatedOn,
                Id = n.Id,
                Status = n.Seen ? NotificationStatus.Seen : NotificationStatus.NotSeen,
                Text = n.Message
            }).ToList();
        }

        public void MarkNotificationAsSeen(long notificationId)
        {
            var notification = _db.Notifications.SingleOrDefault(n => n.Id == notificationId);
            if (notification != null)
            {
                notification.Seen = true;
                _db.SaveChanges();
            }
        }
    }
}
