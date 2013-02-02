using System.Web.Http;
using Autofac.Integration.WebApi;
using WebApiTesting.App_Start;

namespace WebApiTesting
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterApiRoutes(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(ContainerConfig.BuildContainer());
        }
    }
}