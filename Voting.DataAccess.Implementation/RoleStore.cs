using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Voting.Db;
using Voting.Entities;
using Voting.ViewModels;

namespace Voting.DataAccess.Implementation
{
    public class RoleStore : IRoleStore<RoleModel, Guid>
    {
        private ApplicationContext Context { get; }

        public RoleStore(ApplicationContext context)
        {
            Context = context;
        }

        public async Task CreateAsync(RoleModel role)
        {
            Context.Roles.Add(new Role
            {
                Id = Guid.NewGuid(),
                Name = role.Name
            });

            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RoleModel role)
        {
            var storedRole = await Context.Roles.FindAsync(role.Id);

            if (storedRole != null) Context.Roles.Remove(storedRole);

            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task<RoleModel> FindByIdAsync(Guid roleId)
        {
            var role = await Context.Roles.FindAsync(roleId);

            return role == null ? null : new RoleModel(role.Id, role.Name);
        }

        public async Task<RoleModel> FindByNameAsync(string roleName)
        {
            var role = await Context.Roles.FirstOrDefaultAsync(t => t.Name == roleName);

            return role == null ? null : new RoleModel(role.Id, role.Name);
        }

        public async Task UpdateAsync(RoleModel role)
        {
            var storedRole = await Context.Roles.FindAsync(role.Id);

            if (storedRole != null) Context.Entry(storedRole).State = EntityState.Modified;

            await Context.SaveChangesAsync();
        }
    }
}
