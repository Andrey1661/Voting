using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.ViewModels
{
    public class AnswerViewModel
    {
        public int QuestionNumber { get; set; }
        public int OptionNumber { get; set; } = -1;
    }
}
