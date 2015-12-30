using System.Web.Http;
using System.Web.Http.Cors;

namespace MECWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors(new EnableCorsAttribute("http://localhost:10071, http://localhost:10072, http://localhost:10070, http://localhost:21575, http://localhost:37045", "accept, authorization", "GET", "WWW-Authenticate"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}