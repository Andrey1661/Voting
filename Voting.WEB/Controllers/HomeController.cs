using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using Voting.DataAccess;
using Voting.DataAccess.Implementation;
using Voting.DataAccess.Questionnaire;
using Voting.ViewModels;

namespace Voting.WEB.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public ISaveQuestionnaireResultCommand SaveQuestionnaireResultCommand { get; set; }

        [Inject]
        public ISendResultsCommand SendResultCommand { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [HttpGet]
        public ActionResult Questionnaire()
        {
            QuestionnaireViewModel model = QuestionnaireManager.QuestionnaireInstance;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Questionnaire(QuestionnaireViewModel model)
        {
            UserResponceViewModel responce;

            try
            {
                responce = await SaveQuestionnaireResultCommand.ExecuteAsync(model);
            }
            catch (Exception e)
            {
                return View("Error");
            }

            UserResult result = Mapper.Map<UserResponceViewModel, UserResult>(responce);

            var userList = new List<string> {"shedogubov.andrey96@gmail.com"};

            try
            {
                await SendResultCommand.ExecuteAsync(result, userList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return View("Result", responce);
        }
    }
}