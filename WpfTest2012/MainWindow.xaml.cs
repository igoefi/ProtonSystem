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
using WpfTest2012.Pages;

namespace WpfTest2012
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameNav.frameNavigation = FrmMain;
            FrmMain.Navigate(new PageLogin());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameNav.frameNavigation.CanGoBack)
                FrameNav.frameNavigation.GoBack();
        }
        
    }
}
