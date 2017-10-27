using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.ViewModels
{
    public class ListResponce<T> : List<T>
    {
        public int Page { get; set; }

        public int ItemsTotal { get; set; }

        public int PagesTotal { get; set; }

        public ListResponce() { }

        public ListResponce(IEnumerable<T> collection) : base(collection) { }
    }
}
