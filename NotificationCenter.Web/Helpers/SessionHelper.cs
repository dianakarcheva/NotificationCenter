using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotificationCenter.Interfaces.Models;

namespace NotificationCenter.Web.Helpers
{
    public static class SessionHelper
    {
        private const string CURRENT_USER = "CurrentUser";

        private const string CURRENT_USER_NOTIFICATIONS = "Notifications";

        public static bool IsAuthenticated => CurrentUser != null;

        public static LoggedInUser CurrentUser
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null) return null;
                return HttpContext.Current.Session[CURRENT_USER] as LoggedInUser;
            }

            set
            {
                if (HttpContext.Current != null || HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session[CURRENT_USER] = value;
                }
            }

        }

        public static List<Notification> ClientNotifications
        {
            get
            {
                if (CurrentUser == null) return null;
                return HttpContext.Current.Session[CURRENT_USER_NOTIFICATIONS] as List<Notification>;
            }

            set
            {
                if(CurrentUser != null)
                {
                    HttpContext.Current.Session[CURRENT_USER_NOTIFICATIONS] = value;
                }
            }
        }

        public static void CloseSession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }
}