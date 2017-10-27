using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Voting.Entities;
using Voting.ViewModels;

namespace Voting.DataAccess.Implementation
{
    public class AutomapperModuleDa : Profile
    {
        public AutomapperModuleDa()
        {
            CreateMap<QuestionnaireViewModel, User>();
            CreateMap<User, UserResponceViewModel>();
            CreateMap<User, UserResponceViewModel>();
        }
    }
}
