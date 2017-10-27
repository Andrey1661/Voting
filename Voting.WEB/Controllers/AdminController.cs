using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Voting.DataAccess;
using Voting.ViewModels;

namespace Voting.WEB.Controllers
{
    public class AdminController : Controller
    {
        [Inject]
        public IGetUserListQuery GetUserListQuery { get; set; }

        public async Task<ActionResult> Users(ListOptions options)
        {
            ListResponce<UserResponceViewModel> model = await GetUserListQuery.RunAsync(options);

            return View(model);
        }
    }
}