using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotificationCenter.Interfaces.Models;

namespace NotificationCenter.Web.Models
{
    public class HomeModel
    {
        public string User { get; set; }

        public ICollection<Notification> Notifications { get; set; }

    }
}