using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Voting.ViewModels
{
    public class RoleModel : IRole<Guid>
    {
        public RoleModel()
        {          
        }

        public RoleModel(Guid id)
        {
            Id = id;
        }

        public RoleModel(Guid id, string name) : this(id)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
