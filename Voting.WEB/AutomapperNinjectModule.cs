using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Voting.DataAccess.Implementation;

namespace Voting.WEB
{
    public class AutomapperNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(CreateInstance).InSingletonScope();
        }

        private IMapper CreateInstance(IContext context)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(type => context.Kernel.Get(type));
                cfg.AddProfile<AutomapperModuleDa>();
                cfg.AddProfile<AutomapperModuleWeb>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}