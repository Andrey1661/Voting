using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Voting.DataAccess.Questionnaire;
using Voting.Db;
using Voting.Entities;
using Voting.ViewModels;

namespace Voting.DataAccess.Implementation.Commands
{
    public class SaveQuestionnaireResultCommand : ISaveQuestionnaireResultCommand
    {
        private ApplicationContext Context { get; }
        private IMapper Mapper { get; }

        public SaveQuestionnaireResultCommand(ApplicationContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public async Task<UserResponceViewModel> ExecuteAsync(QuestionnaireViewModel model)
        {
            var user =
                await Context.Users.FirstOrDefaultAsync(
                    t =>
                        model.LastName == t.LastName && 
                        model.FirstName == t.FirstName &&
                        model.Patronymic == t.Patronymic) ?? 
                        Mapper.Map<QuestionnaireViewModel, User>(model);

            user.Points = QuestionnaireManager.CalculateResults(model);
            user.PassDate = DateTime.Now;

            if (user.UserId == Guid.Empty)
            {
                Context.Users.Add(user);
            }
            else
            {
                Context.Entry(user).State = EntityState.Modified;
            }

            await Context.SaveChangesAsync();

            return Mapper.Map<User, UserResponceViewModel>(user);
        }
    }
}
