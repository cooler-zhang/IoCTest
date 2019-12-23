using Autofac;
using Autofac.Integration.Mvc;
using IoCTest.AppService;
using IoCTest.Contract;
using IoCTest.Repository;
using System.Web.Mvc;

namespace IoCTest.Autofac.Host
{
    public class Bootstrapper
    {
        public static ContainerBuilder Initialise()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            builder.RegisterType<TestDbContext>().SingleInstance();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<ProductAppService>().As<IProductAppService>();
            builder.RegisterType<RemoteAppService>().As<IRemoteAppService>();

            //// OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            ContainerManager.Container = container;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return builder;
        }
    }
}