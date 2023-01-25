using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using WpfTest2012.Models;
using static System.Net.WebRequestMethods;

namespace WpfTest2012.Pages.ScriptPages
{
    internal class ExcelExporter
    {
        public Microsoft.Office.Interop.Excel.Application APP = null;
        public Microsoft.Office.Interop.Excel.Workbook WB = null;
        public Microsoft.Office.Interop.Excel.Worksheet WS = null;
        public Microsoft.Office.Interop.Excel.Range Range = null;

        public MyExcel()
        {
            this.APP = new Microsoft.Office.Interop.Excel.Application();
            this.Open("C:\\MyExcel.xlsx", "Sheet1");
            this.CreateHeader();
            this.InsertData();
            this.Close();
        }

        private void Open(string Location, int workSheet)
        {
            this.WB = this.APP.Workbooks.Open(Location);
            this.WS = (Microsoft.Office.Interop.Excel.Worksheet)WB.Sheets[workSheet];
            return this.WS;
        }
        private void CreateHeader()
        {
            int ind = 1;
            foreach (object ob in this.dgvFields.Columns.Select(cs => cs.Header).ToList())
            {
                this.WS.Cells[1, ind] = ob.ToStrihng();
                ind++;
            }
        }
        private void InsertData()
        {
            ind = 2;
            foreach (Field field in dgvFields.ItemsSource)
            {
                DataRow DR = DRV.Row;
                for (int ind1 = 1; ind1 <= dgvFields.Columns.Count; ind1++)
                {
                    WS.Cells[ind][ind1] = DR[ind1 - 1];
                }
                ind++;
            }
        }
        private void Close()
        {
            if (this.APP.ActiveWorkbook != null)
                this.APP.ActiveWorkbook.Save();
            if (this.APP != null)
            {
                if (this.WB != null)
                {
                    if (this.WS != null)
                        Marshal.ReleaseComObject(this.WS);
                    this.WB.Close(false, Type.Missing, Type.Missing);
                    Marshal.ReleaseComObject(this.WB);
                }
                this.APP.Quit();
                Marshal.ReleaseComObject(this.APP);
            }
        }

        public static void ToExcelButton_OnClick(DataGrid UsersDataGrid)
        {
            IEnumerable<User> d = UsersDataGrid.ItemsSource.Cast<User>();
            DataTable data = ToDataTable(d.ToList());
            ToExcelFile(data, "test.xlsx");
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in properties)
            {
                //Defining type of data column gives proper data table 
                Type type = (prop.PropertyType.IsGenericType &&
                    prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                    ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }

            foreach (T item in items)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    //inserting property values to data table rows
                    values[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check data table
            return dataTable;
        }

        public static void ToExcelFile(DataTable dataTable, string filePath, bool overwriteFile = true)
        {
            if (File.Exists(filePath) && overwriteFile)
                File.Delete(filePath);

            using (OleDbConnection connection = new OleDbConnection())
            {
                connection.ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};" +
                                              "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                connection.Open();

                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = connection;
                    List<string> columnNames = (from DataColumn dataColumn in dataTable.Columns select dataColumn.ColumnName).ToList();
                    string tableName = !string.IsNullOrWhiteSpace(dataTable.TableName) ? dataTable.TableName : Guid.NewGuid().ToString();
                    command.CommandText = $"CREATE TABLE [{tableName}] ({string.Join(",", columnNames.Select(c => $"[{c}] VARCHAR").ToArray())});";
                    command.ExecuteNonQuery();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        List<string> rowValues = (from DataColumn column in dataTable.Columns select (row[column] != null && row[column] != DBNull.Value) ? row[column].ToString() : string.Empty).ToList();
                        command.CommandText = $"INSERT INTO [{tableName}]({string.Join(",", columnNames.Select(c => $"[{c}]"))}) VALUES ({string.Join(",", rowValues.Select(r => $"'{r}'").ToArray())});";
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
                MessageBox.Show("Успешно сохранено по пути :" + filePath);
            }
        }
    }
}
