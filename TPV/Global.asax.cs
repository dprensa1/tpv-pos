using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TPV
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /*protected void Application_PostAuthenticateRequest()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer js = new JavaScriptSerializer();

                Usuario usuario = js.Deserialize<Usuario>(ticket.UserData);

                Identity Identity = new Identity(usuario);

                Principal Principal = new Principal(Identity);

                HttpContext.Current.User = Principal;
            }
        }*/
    }
}