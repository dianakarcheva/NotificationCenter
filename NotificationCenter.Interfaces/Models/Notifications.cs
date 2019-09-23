using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationCenter.Interfaces.Enums;

namespace NotificationCenter.Interfaces.Models
{
    public class Notification
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public long ClientId { get; set; }

        public DateTime CreatedOn { get; set; }

        public NotificationStatus Status { get; set; }
    }
}
