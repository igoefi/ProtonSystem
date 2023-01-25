using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfTest2012.Models;

namespace WpfTest2012.HelperClasses
{
    internal class UseUserController
    {
        public static User CreateUser(string login, string password, string fullName, int roleIdIndex)
        {
            var user = DataBaseConnectContext.ConnectContext.User.FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                MessageBox.Show("Логин занят");
                return null;
            }
            return new User()
            {
                Login = login,
                Password = password,
                FullName = fullName,
                LastUpdateInfoTime = DateTime.Now,
                RoleId = roleIdIndex
            };
        }

        public static void UpdateUserInformation(User oldUser, string login, string password, string fullName, int roleIdIndex)
        {

            IEnumerable<User> users = DataBaseConnectContext.ConnectContext.User.Where(c => c.Id == oldUser.Id).
                AsEnumerable().Select(
                c =>
                {
                    c.Login = login;
                    c.Password = password;
                    c.RoleId = roleIdIndex;
                    c.FullName = fullName;
                    c.LastUpdateInfoTime = DateTime.Now;
                    return c;
                });

            foreach (var user in users)
                DataBaseConnectContext.ConnectContext.Entry(user).State = EntityState.Modified;

            DataBaseConnectContext.ConnectContext.SaveChanges();
        }

        #region find
        public static User FindUser(string login)
        {
            try
            {
                User user = DataBaseConnectContext.ConnectContext.User.FirstOrDefault(x => x.Login == login);

                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        public static User FindUser(string login, string password)
        {
            try
            {
                User user = DataBaseConnectContext.ConnectContext.User.FirstOrDefault(
                        x => x.Login == login && x.Password == password
                    );

                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        #endregion
    }
}
