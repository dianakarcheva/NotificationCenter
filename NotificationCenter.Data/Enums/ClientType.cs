using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationCenter.Data.Enums
{
    [Flags]
    public enum ClientType
    {
        None = 0,

        Companies = 1,

        Person = 2
    }
}
