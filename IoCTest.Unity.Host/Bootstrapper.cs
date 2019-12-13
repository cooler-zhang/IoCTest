using IoCTest.AppService;
using IoCTest.Contract;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace IoCTest.Unity.Host
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            //container.RegisterType<TestDbContext>();
            //container.RegisterType<IProductRepository, ProductRepository>();
            //container.RegisterType<IProductAppService, ProductAppService>();

            container.RegisterType<IRemoteAppService, RemoteAppService>(new PerResolveLifetimeManager());

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
        }
    }
}