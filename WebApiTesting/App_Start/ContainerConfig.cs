using Autofac;
using Autofac.Integration.WebApi;
using WebApiTesting.Infrastructure;

namespace WebApiTesting.App_Start
{
    public static class ContainerConfig
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(ContainerConfig).Assembly);

            builder.Register(c => new DateTimeProvider())
                .AsImplementedInterfaces().SingleInstance();
            builder.Register(c => new PingRepository())
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}