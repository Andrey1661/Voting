using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Voting.ViewModels;

namespace Voting.DataAccess
{
    public interface IGetUserListQuery
    {
        Task<ListResponce<UserResponceViewModel>> RunAsync(ListOptions listOptions);
    }
}
