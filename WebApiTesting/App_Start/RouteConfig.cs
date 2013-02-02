using System.Web.Http;

namespace WebApiTesting.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterApiRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
