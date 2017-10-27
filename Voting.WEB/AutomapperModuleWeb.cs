using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Voting.ViewModels;

namespace Voting.WEB
{
    public class AutomapperModuleWeb : Profile
    {
        public AutomapperModuleWeb()
        {
            CreateMap<UserResponceViewModel, UserResult>();
        }
    }
}