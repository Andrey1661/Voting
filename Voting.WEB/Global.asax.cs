using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;
using Voting.WEB.Authentication;

namespace Voting.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //AuthenticateRequest += OnAuthenticateRequest;
        }

        protected void OnAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);

                if (ticket == null) return;

                var serializer = new JavaScriptSerializer();
                var userData = serializer.Deserialize<UserData>(ticket.UserData);

                var identity = new GenericIdentity(ticket.Name);
                var principal = new ApplicationPrincipal(identity, userData);

                HttpContext.Current.User = principal;
            }
        }
    }
}
