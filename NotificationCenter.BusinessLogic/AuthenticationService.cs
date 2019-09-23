using System;
using System.Linq;
using System.Threading.Tasks;
using NotificationCenter.Interfaces;
using NotificationCenter.Interfaces.Models;
using NotificationCenter.BusinessLogic.Helpers;

namespace NotificationCenter.BusinessLogic
{
    public class AuthenticationService : ServiceBase, IAuthenticationService
    {      

        public LoginResult Login(string username, string password)
        {
            var user = _db.Clients.SingleOrDefault(c => c.Login == username);
            if (user == null) return new LoginResult { Success = false };

            if (CryptoHelper.ComparePassword(password, user.Password))
            {
                return new LoginResult()
                {
                    Success = true,
                    User = new LoggedInUser()
                    {
                        Id = user.Id,
                        Username = username,
                        ClientType = user.ClientType == Data.Enums.ClientType.Person
                            ? Interfaces.Enums.ClientType.Person
                            : Interfaces.Enums.ClientType.Company
                    }
                };
            }
            else
            {
                return new LoginResult()
                {
                    Success = false
                };
            }
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            await Task.Yield();

            return this.Login(username, password);
        }
    }
}
