using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Voting.Db;
using Voting.Entities;
using Voting.ViewModels;

namespace Voting.DataAccess.Implementation.Queries
{
    public class GetUserListQuery : IGetUserListQuery
    {
        private ApplicationContext Context { get; }
        private IMapper Mapper { get; }

        public GetUserListQuery(ApplicationContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }

        public async Task<ListResponce<UserResponceViewModel>> RunAsync(ListOptions listOptions)
        {
            var query = Context.Users.AsQueryable();
            int totalCount = await Context.Users.CountAsync();

            var result = new ListResponce<UserResponceViewModel>();

            if (listOptions != null)
            {
                query = query.OrderBy(t => t.LastName);
                if (listOptions.Offset > 0) query = query.Skip(listOptions.Offset);
                if (listOptions.PageSize > 0) query = query.Take(listOptions.PageSize);

                result.Page = listOptions.Page;
                result.ItemsTotal = totalCount;
                result.PagesTotal = listOptions.PageCount;
            }

            var users = await query.ToListAsync();

            result.AddRange(Mapper.Map<IEnumerable<User>, IEnumerable<UserResponceViewModel>>(users));

            return result;
        }
    }
}
