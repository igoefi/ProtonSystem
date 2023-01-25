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

namespace WpfTest2012.Pages.InfoPages
{
    /// <summary>
    /// Логика взаимодействия для PageFAQ.xaml
    /// </summary>
    public partial class PageFAQ : Page
    {
        private Dictionary<string, string> _questions = new Dictionary<string, string>();
        public PageFAQ()
        {
            InitializeComponent();
            _questions = GetDBInformationHelper.GetQuestion();
            CombBoxQuestion.ItemsSource = _questions.Keys;
        }

        private void CombBoxQuestionsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string question = CombBoxQuestion.SelectedValue.ToString();
            RnNameQuestion.Text = question;
            RnAnswer.Text = _questions[question];
        }
    }
}
