using System.Windows;
using System.Windows.Controls;
using WpfTest2012.HelperClasses;
using WpfTest2012.Interface;
using WpfTest2012.Models;

namespace WpfTest2012.Pages
{
    /// <summary>
    /// Логика взаимодействия для FindUserPage.xaml
    /// </summary>
    public partial class FindUserPage : Page
    {
        private ISetUser _nextScript;
        public FindUserPage(ISetUser nextPage)
        {
            InitializeComponent();
            _nextScript = nextPage;
        }

        private void BtnFindUser_Click(object sender, RoutedEventArgs e)
        {
            User user = UseUserController.FindUser(TxbLogin.Text);
            if (user == null)
            {
                MessageBox.Show("Пользователя с таким логином не существует");
                return;
            }

            if (_nextScript != null)
            {
                _nextScript.SetUser(user);
                try
                {
                    Page page = (Page)_nextScript;
                    FrameNav.frameNavigation.Navigate(page);
                }
                catch { }

            }

        }
    }
}
