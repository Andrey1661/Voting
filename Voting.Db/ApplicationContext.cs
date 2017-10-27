using System.Data.Entity;
using Voting.Entities;

namespace Voting.Db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(string connectionString) : base(connectionString)
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}
