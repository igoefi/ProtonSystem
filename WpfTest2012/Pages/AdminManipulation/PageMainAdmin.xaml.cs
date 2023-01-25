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
using WpfTest2012.Pages.AdminManipulation;
using WpfTest2012.Pages.InfoPages;

namespace WpfTest2012.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMainAdmin.xaml
    /// </summary>
    public partial class PageMainAdmin : Page
    {
        public PageMainAdmin()
        {
            InitializeComponent();
        }

        private void BtnDBInfo(object sender, RoutedEventArgs e) =>
            FrameNav.frameNavigation.Navigate(new PAgeDBInfo());

        private void BtnUpdateUserInfo(object sender, RoutedEventArgs e) =>
            FrameNav.frameNavigation.Navigate(new FindUserPage(new UpdateUserInformationPage()));

        private void BtnCreateUser_Click(object sender, RoutedEventArgs e) =>
            FrameNav.frameNavigation.Navigate(new PageCreateUser());

        private void BtnFAQ_Click(object sender, RoutedEventArgs e) =>
            FrameNav.frameNavigation.Navigate(new PageFAQ());
    }
}
