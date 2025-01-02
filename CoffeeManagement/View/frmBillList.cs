using CoffeeManagement.Reports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement.Model
{
    public partial class frmBillList : SampleAdd
    {
        public frmBillList()
        {
            InitializeComponent();
        }

        public int MainID = 0;

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string qry = "select MainID, TableName, WaiterName,orderType,status,total from tblMain where status <> 'Đang chờ xử lý'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvtable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);
            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {

                MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                this.Close();



            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                //print bill
                MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                string qry = @"Select * from tblMain m inner join tblDetails d on d.MainID = m.MainID
inner join products p on p.pID = d.proID where m.MainID = " + MainID + " ";

                SqlCommand cmd = new SqlCommand(qry, MainClass.con);

                MainClass.con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                MainClass.con.Close();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine("MainID: " + row["MainID"]);
                        Console.WriteLine("proID: " + row["proID"]);
                        Console.WriteLine("pName: " + row["pName"]);
                    }
                }
                else
                {
                    Console.WriteLine("DataTable is empty");
                }

                frmPrint frm = new frmPrint();
                rptBill cr = new rptBill();
                cr.SetDataSource(dt);
                cr.SetDatabaseLogon("sa", "sa");

                frm.crystalReportViewer2.ReportSource = cr;
                frm.crystalReportViewer2.Refresh();
                frm.Show();
            }
        }
    }
}