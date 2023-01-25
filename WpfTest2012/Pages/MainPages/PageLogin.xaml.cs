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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void BtnLoginIn_Click(object sender, RoutedEventArgs e)
        {
            User user = UseUserController.FindUser(TxbLogin.Text, PsbxPassword.Password);
            if(user != null)
                FrameNav.frameNavigation.Navigate(new PageMainAdmin());
            else
                MessageBox.Show("Неправильный логин или пароль");
        }

        private void BtnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.frameNavigation.Navigate(new PageCreateUser());
        }
    }
}
