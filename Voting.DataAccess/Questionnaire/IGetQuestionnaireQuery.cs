using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.ViewModels;

namespace Voting.DataAccess.Questionnaire
{
    public interface IGetQuestionnaireQuery
    {
        Task<QuestionnaireViewModel> RunAsync();
    }
}
