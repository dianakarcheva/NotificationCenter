using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationCenter.Interfaces.Models;
using NotificationCenter.Interfaces.Enums;

namespace NotificationCenter.Interfaces
{
    public interface IAuthenticationService
    {
        LoginResult Login(string username, string password);

        Task<LoginResult> LoginAsync(string username, string password);
    }   
}
