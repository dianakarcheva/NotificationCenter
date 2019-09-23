using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using NotificationCenter.Interfaces;
using NotificationCenter.Interfaces.Models;
using NotificationCenter.Web.Helpers;
using RazorEngine;
using RazorEngine.Templating;

namespace NotificationCenter.Web.Hubs
{
    [HubName("notificationsChannel")]
    public class NotificationHub :  Hub
    {
        private static ICustomerService _customerService;

        private static IHubContext _hub;

        private static IHubContext Hub
        {
            get
            {
                if (_hub == null)
                    _hub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

                return _hub;
            }
        }

        public NotificationHub(ICustomerService customerService)
        {
            if(_customerService == null)
            {
                _customerService = customerService;
                _customerService.NewNotification += OnNewNotifications;
            }
        }

        private static void OnNewNotifications()
        {
            ///ToDo: Get new notifications -> Push to client
        }

        public override Task OnConnected()
        {
            if (SessionHelper.CurrentUser != null)
            {                
                Groups.Add(Context.ConnectionId, SessionHelper.CurrentUser.Id.ToString());
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            if (SessionHelper.CurrentUser != null)
            {
                Groups.Remove(Context.ConnectionId, SessionHelper.CurrentUser.Id.ToString());
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}