using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfTest2012.Interface;
using WpfTest2012.Models;

namespace WpfTest2012.Pages.AdminManipulation
{
    /// <summary>
    /// Логика взаимодействия для UpdateUserInformationPage.xaml
    /// </summary>
    public partial class UpdateUserInformationPage : Page, ISetUser
    {
        User _lastUser = null;
        public UpdateUserInformationPage()
        {
            InitializeComponent();
            RoleCombBox.ItemsSource = GetDBInformationHelper.GetRoles();
        }

        public void SetUser(User user)
        {
            TxbLogin.Text = user.Login;
            PsbPassUser.Password = user.Password;
            string[] names = user.FullName.Split(' ');
            Console.WriteLine(names);
            TxbNameUser.Text = names[1];
            TxbSurnameUser.Text = names[0];
            TxbPatronymicUser.Text = names[2];
            RoleCombBox.SelectedIndex = user.RoleId - 1;

            _lastUser = user;
        }

        private void BtnUpdateUserInfo_Click(object sender, RoutedEventArgs e)
        {
            UseUserController.UpdateUserInformation(_lastUser, TxbLogin.Text, PsbPassUser.Password,
                $"{TxbSurnameUser.Text} {TxbNameUser.Text} {TxbPatronymicUser.Text}", RoleCombBox.SelectedIndex+1);

            FrameNav.frameNavigation.GoBack();
            FrameNav.frameNavigation.GoBack();
        }
    }
}
