using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.ViewModels;

namespace Voting.DataAccess.Implementation
{
    internal static class EmailMessageHelper
    {
        internal static string CreateMailMessage(UserResult user)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"<span><b>Домен: </b>{user.Domain}</span>");
            sb.AppendLine($"<span><b>ФИО: </b>{user.LastName} {user.FirstName} {user.Patronymic}</span>");
            sb.AppendLine($"<span><b>Результат: {user.Result}</b>{user.Domain}</span>");

            return sb.ToString();
        }
    }
}
