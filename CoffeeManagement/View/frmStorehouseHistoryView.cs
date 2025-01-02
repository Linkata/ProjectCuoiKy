using CoffeeManagement.Bl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement.View
{
    public partial class frmStorehouseHistoryView : Form
    {
        private readonly StorehouseBL storehouseBL;
        public frmStorehouseHistoryView()
        {
            InitializeComponent();
            storehouseBL = new StorehouseBL();
        }

        private void frmStorehouseHistoryView_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }
        private void LoadHistory()
        {
            var history = storehouseBL.GetEntryHistory();
            guna2DataGridView1.DataSource = null;
            guna2DataGridView1.DataSource = history;
            guna2DataGridView1.AutoResizeRows();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ToExcel(guna2DataGridView1, saveFileDialog1.FileName);
            }
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                workbook = excel.Workbooks.Add(Type.Missing);

                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet.Name = "LICH SU NHAP KHO";

                // export header
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }

                // export content
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save workbook
                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất file thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

    }
}
