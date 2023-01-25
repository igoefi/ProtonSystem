using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTest2012.Pages.ScriptPages
{
    internal class DataPrint
    {
        public static void Print(DataGrid grid)
        {
            var printdlg = new PrintDialog();
            if (printdlg.ShowDialog().GetValueOrDefault())
                printdlg.PrintVisual(grid, "Печатаем грид");
        }
    }
}
