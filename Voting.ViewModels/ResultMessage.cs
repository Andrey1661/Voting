using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.ViewModels
{
    public class ResultMessage
    {
        public IEnumerable<string> Recievers { get; set; }

        public IEnumerable<UserResponceViewModel> Users { get; set; }
    }
}
