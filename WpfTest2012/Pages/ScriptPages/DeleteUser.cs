using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest2012.HelperClasses;
using WpfTest2012.Interface;
using WpfTest2012.Models;

namespace WpfTest2012.Pages.ScriptPages
{
    internal class DeleteUser : ISetUser
    {
        public void SetUser(User user)
        {
            DataBaseConnectContext.ConnectContext.User.Remove(user);
            DataBaseConnectContext.ConnectContext.SaveChanges();

            FrameNav.frameNavigation.GoBack();
        }
    }
}
