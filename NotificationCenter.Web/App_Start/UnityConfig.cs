using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using NotificationCenter.Interfaces;
using NotificationCenter.Interfaces.Mockups;

namespace NotificationCenter.Web.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IAuthenticationService, AuthenticationMockupService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}