using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCenter.Data.Enums
{
    [Flags]
    public enum NotificationChannel
    {
        None = 0,

        Web = 1,

        Email = 2,

        Mobile = 4,

        Sms = 8
    }
}
