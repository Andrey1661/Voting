using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.ViewModels
{
    public class QuestionViewModel
    {
        public string Text { get; set; }
        public int Number { get; set; }
        public int CorrectOptionNumber { get; set; }
        public List<OptionViewModel> Options { get; set; } 
    }
}
