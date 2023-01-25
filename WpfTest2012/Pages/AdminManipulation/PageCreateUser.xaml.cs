using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfTest2012.HelperClasses;
using WpfTest2012.Models;

namespace WpfTest2012.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCreateUser.xaml
    /// </summary>
    public partial class PageCreateUser : Page
    {
        public PageCreateUser()
        {
            InitializeComponent();

            RoleCombBox.ItemsSource = GetDBInformationHelper.GetRoles();
        }

        private void BtnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User newUser = UseUserController.CreateUser(TxbLogin.Text, PsbPassUser.Password,
                    $"{TxbSurnameUser.Text} {TxbNameUser.Text} {TxbPatronymicUser.Text}", RoleCombBox.SelectedIndex + 1);
                if (newUser == null) return;

                DataBaseConnectContext.ConnectContext.User.Add(newUser);
                DataBaseConnectContext.ConnectContext.SaveChanges();
                FrameNav.frameNavigation.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
