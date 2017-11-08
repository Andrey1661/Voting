using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Voting.WEB.Authentication
{
    public class ApplicationPrincipal : IPrincipal
    {
        public IIdentity Identity { get; }

        public UserData UserData { get; set; }

        public ApplicationPrincipal(IIdentity identity, UserData data) : this(identity)
        {
            UserData = data;
        }

        public ApplicationPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            if (UserData?.Roles == null) return false;

            return UserData.Roles != null && UserData.Roles.Contains(role);
        }
    }
}