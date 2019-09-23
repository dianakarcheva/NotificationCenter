using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationCenter.Interfaces.Enums;

namespace NotificationCenter.Interfaces.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }

        public LoggedInUser User { get; set; }
    }

    public class LoggedInUser
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public ClientType ClientType { get; set; }
    }
}
