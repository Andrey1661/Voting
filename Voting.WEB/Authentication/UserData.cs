using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voting.WEB.Authentication
{
    public class UserData
    {
        public IEnumerable<string> Roles { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}