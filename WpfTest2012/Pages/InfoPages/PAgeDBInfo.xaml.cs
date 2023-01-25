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
using WpfTest2012.Models;
using WpfTest2012.Pages.ScriptPages;

namespace WpfTest2012.Pages
{
    /// <summary>
    /// Логика взаимодействия для PAgeDBInfo.xaml
    /// </summary>
    public partial class PAgeDBInfo : Page
    {
        public PAgeDBInfo()
        {
            InitializeComponent();
            GridUserList.ItemsSource = DataBaseConnectContext.ConnectContext.User.ToList();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e) =>
            DataPrint.Print(GridUserList);

        private void BtnToExcel_Click(object sender, RoutedEventArgs e)=>
            ExcelExporter.ToExcelButton_OnClick(GridUserList);
            
    }
}
