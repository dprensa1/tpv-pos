using System.Web.Mvc;
using System.Web.Routing;

namespace TPV
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}",
                //url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Inicio", action = "Login", id = UrlParameter.Optional }
                defaults: new { controller = "Login", action = "Index"}
            );
        }
    }
}