using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.ViewModels
{
    public class ListOptions
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int ItemsCount { get; set; }

        public int ItemsTotal { get; set; }

        public int PageCount
        {
            get
            {
                if (PageSize == 0) return 0;

                int count = ItemsTotal / PageSize;

                if (ItemsTotal % PageSize != 0) count++;

                return count;
            }
        }

        public int Offset => Page * PageSize;
    }
}
