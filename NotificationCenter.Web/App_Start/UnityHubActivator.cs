using System;
using Microsoft.AspNet.SignalR.Hubs;
using Unity;
using Unity.Lifetime;
using NotificationCenter.Web.Hubs;

namespace NotificationCenter.Web.App_Start
{
    public class UnityHubActivator : IHubActivator
    {
        private readonly IUnityContainer _container;

        public UnityHubActivator(IUnityContainer container)
        {
            _container = container;
        }

        public IHub Create(HubDescriptor descriptor)
        {
            if (descriptor == null)
            {
                throw new ArgumentNullException("descriptor");
            }

            if (descriptor.HubType == null)
            {
                return null;
            }

            object hub = _container.Resolve(descriptor.HubType) ?? Activator.CreateInstance(descriptor.HubType);
            return hub as IHub;
        }
    }

    public class UnityConfiguration
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<NotificationHub, NotificationHub>(new ContainerControlledLifetimeManager());
            container.RegisterType<IHubActivator, UnityHubActivator>(new ContainerControlledLifetimeManager());

        }
    }
}