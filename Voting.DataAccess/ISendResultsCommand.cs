using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.ViewModels;

namespace Voting.DataAccess
{
    public interface ISendResultsCommand
    {
        Task ExecuteAsync(UserResult result, IEnumerable<string> recievers);
    }
}
