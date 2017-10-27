using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Voting.ViewModels;

namespace Voting.DataAccess.Implementation
{
    public static class QuestionnaireManager
    {
        public static QuestionnaireViewModel QuestionnaireInstance { get; private set; }

        internal static void LoadQuestionnaireFromXml(string filePath)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(QuestionnaireViewModel));

                document.Load(filePath);
                string xml = document.OuterXml;
                var stringReader = new StringReader(xml);

                QuestionnaireInstance = (QuestionnaireViewModel)serializer.Deserialize(new XmlTextReader(stringReader));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        internal static int CalculateResults(QuestionnaireViewModel model)
        {
            model.Answers = model.Answers.OrderBy(t => t.QuestionNumber).ToList();

            int points = 0;

            for (int i = 0; i < QuestionnaireInstance.Questions.Count; i++)
            {
                if (model.Answers[i].OptionNumber == QuestionnaireInstance.Questions[i].CorrectOptionNumber)
                    points++;
            }

            return points;
        }
    }
}
