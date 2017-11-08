using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Entities
{
    public class UserRoles
    {
        [Key, Column(Order = 0), ForeignKey("User")]
        public Guid UserId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Role")]
        public Guid RoleId { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }
    }
}
