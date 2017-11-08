using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Voting.WEB.Authentication
{
    public static class AuthenticationManager
    {
        public static void SignIn(string name, bool isPersistent, UserData data = null)
        {
            var serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(data);

            var ticket = new FormsAuthenticationTicket(
                1, 
                name, 
                DateTime.Now,
                DateTime.Now.AddDays(1), 
                isPersistent, 
                userData);

            var encrypted = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}