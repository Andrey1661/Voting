using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Voting.DataAccess.Implementation.Commands;
using Voting.DataAccess.Implementation.Queries;
using Voting.DataAccess.Questionnaire;
using Voting.Db;

namespace Voting.DataAccess.Implementation
{
    public class NinjectModuleDa : NinjectModule
    {
        private readonly string _connectionString;
        private readonly string _smtpLogin;
        private readonly string _smtpPassword;

        public NinjectModuleDa(string pathToXml, string connectionString, string smtpLogin, string smtpPassword)
        {
            _connectionString = connectionString;
            _smtpLogin = smtpLogin;
            _smtpPassword = smtpPassword;

            QuestionnaireManager.LoadQuestionnaireFromXml(pathToXml);
        }

        public override void Load()
        {
            if (Kernel == null) return;

            Kernel.Bind<ApplicationContext>().ToSelf().WithConstructorArgument(_connectionString);
            Kernel.Bind<ISaveQuestionnaireResultCommand>().To<SaveQuestionnaireResultCommand>();
            Kernel.Bind<IGetUserListQuery>().To<GetUserListQuery>();
            Kernel.Bind<ISendResultsCommand>()
                .To<SendResultsCommand>()
                .WithConstructorArgument("smtpLogin", _smtpLogin)
                .WithConstructorArgument("smtpPassword", _smtpPassword);
        }
    }
}
