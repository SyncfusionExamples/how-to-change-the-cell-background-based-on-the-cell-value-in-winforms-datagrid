using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        DataTable employeeCollection;
        public Form1()
        {
            InitializeComponent();

            this.sfDataGrid1.AutoGenerateColumns = true;
            var table = this.GetDataTable();        
            sfDataGrid1.DataSource = table;          
            sfDataGrid1.QueryCellStyle += SfDataGrid1_QueryCellStyle;           
        }       

        private void SfDataGrid1_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            if (e.Column.MappingName == "Color")
            {
                var userColourString = e.DisplayText;
                int userColourNumeric = 0;
                int.TryParse(userColourString, out userColourNumeric);
                var colourToUse = userColourNumeric;
                e.Style.BackColor = ColorTranslator.FromWin32(colourToUse);
                if (e.DisplayText == "0")
                    e.Style.TextColor = Color.White;
            }            
        }     

        public DataTable GetDataTable()
        {
            employeeCollection = new DataTable();

            employeeCollection.Columns.Add("Color", typeof(int));
            employeeCollection.Columns.Add("CustomerID", typeof(string));
            employeeCollection.Columns.Add("CustomerName", typeof(string));            
            employeeCollection.Columns.Add("Country", typeof(string));            
            employeeCollection.Columns.Add("ShipCity", typeof(string));

            employeeCollection.Rows.Add(0, "ALFKI", "Maria Anders", "Germany", "Berlin");
            employeeCollection.Rows.Add(255, "ANATR", "Ana Trujilo", "Mexico", "Lula");
            employeeCollection.Rows.Add(32768, "ANTON", "Antonio Moreno", "Mexico", "Berlin");
            employeeCollection.Rows.Add(33023, "AROUT", "Thomas Hardy", "UK", "Lula");
            employeeCollection.Rows.Add(65535, "BERGS", "Christina Berglund", "Sweden", "Mannheim");
            employeeCollection.Rows.Add(12615935, "BLAUS", "Hanna Moos", "Germany", "Madrid");
            employeeCollection.Rows.Add(16777215, "BLONP", "Frederique Citeaux", "France", "Berlin");
            employeeCollection.Rows.Add(16770790, "BOLID", "Martin Sommer", "Spain", "Mannheim");
            employeeCollection.Rows.Add(13027014, "BONAP", "Laurence Lebihan", "France", "Madrid");
            employeeCollection.Rows.Add(16751001, "BOTTM", "Elizabeth Lincoln", "Canada", "Mannheim");

            return employeeCollection;
        }      
    }
}
