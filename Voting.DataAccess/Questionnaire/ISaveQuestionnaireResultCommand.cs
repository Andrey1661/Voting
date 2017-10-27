using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.ViewModels;

namespace Voting.DataAccess.Questionnaire
{
    public interface ISaveQuestionnaireResultCommand
    {
        Task<UserResponceViewModel> ExecuteAsync(QuestionnaireViewModel model);
    }
}
