namespace EH.WebApi
{
    using EH.Core;
    using EH.Core.Interfaces;
    using EH.Core.Repositories;
    using System.Web.Http;
    using Unity;
    using Unity.Lifetime;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IContactService, ContactService>();
            container.RegisterType<IContactRepository, ContactRepository>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}