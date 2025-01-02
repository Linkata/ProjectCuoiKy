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
    public partial class frmStaffAdd : SampleAdd
    {
        public frmStaffAdd()
        {
            InitializeComponent();
        }
        public int id = 0;

        private void frmStaffAdd_Load(object sender, EventArgs e)
        {

        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";
            Hashtable ht = new Hashtable();

            // Kiểm tra nếu bảng category không có dữ liệu
            string checkQry = "Select Count(*) From staff";
            int count = 0;

            using (SqlConnection con = new SqlConnection(MainClass.con_string))
            {
                SqlCommand cmd = new SqlCommand(checkQry, con);
                con.Open();
                count = (int)cmd.ExecuteScalar();
            }

            if (id == 0) // Insert
            {
                if (count == 0)
                {
                    // Nếu bảng trống, bật IDENTITY_INSERT và đặt catId = 1
                    qry = "SET IDENTITY_INSERT staff ON; " +
                          "Insert into staff (staffID, sName,sPhone,sRole) Values (1, @Name,@phone,@role); " +
                          "SET IDENTITY_INSERT staff OFF;";
                }
                else
                {
                    qry = "Insert into staff (sName,sPhone,sRole) Values (@Name,@phone,@role)";
                }
            }
            else // Update
            {
                qry = "Update staff Set sName = @Name,sPhone=@phone,sRole=@role where staffID = @id";
            }

            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@role", cbRole.Text);

            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Saved successfully..");
                id = 0;
                txtName.Text = "";
                txtPhone.Text = "";
                cbRole.SelectedIndex = -1;
                txtName.Focus();
            }
        }
    }
}