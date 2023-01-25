using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest2012.Models;

namespace WpfTest2012.HelperClasses
{
    internal class GetDBInformationHelper
    {
        public static List<string> GetRoles()
        {
            var roles = DataBaseConnectContext.ConnectContext.Role.ToList();
            var rolesNames = new List<string>();
            foreach (var role in roles)
                rolesNames.Add(role.Name);

            return rolesNames;
        }
        public static Dictionary<string, string> GetQuestion()
        {
            var questions = DataBaseConnectContext.ConnectContext.FAQ.ToList();
            var questionsNames = new Dictionary<string, string>();
            foreach (var question in questions)
                questionsNames.Add(question.QuestionName, question.QuestionAnswer);

            return questionsNames;
        }
    }
}
