using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationCenter.Interfaces.Models;
using NotificationCenter.Interfaces.Enums;

namespace NotificationCenter.Interfaces.Mockups
{
    public class AuthenticationMockupService : IAuthenticationService
    {
        public LoginResult Login(string username, string password)
        {
            return new LoginResult()
            {
                Success = true,
                User = new LoggedInUser()
                {
                    Username = "MockedUser",
                    ClientType = ClientType.Person
                }
            };
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            await Task.Yield();

            return new LoginResult()
            {
                Success = true,
                User = new LoggedInUser()
                {
                    Username = "MockedUser",
                    ClientType = ClientType.Person
                }
            };
        }
    }
}
