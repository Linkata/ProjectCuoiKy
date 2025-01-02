using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CoffeeManagement
{
    class MainClass
    {
        // Method để lấy chuỗi kết nối từ appsettings.json
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            return config.GetConnectionString("DefaultConnection");
        }

        // Thiết lập connection string từ appsettings.json
        public static readonly string con_string = GetConnectionString();
        public static SqlConnection con = new SqlConnection(con_string);

        // Method để kiểm tra tài khoản người dùng
        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;
            string qry = @"SELECT * FROM users WHERE username = @user AND upass = @pass";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["uName"].ToString();
            }
            return isValid;
        }

        // Property cho tên người dùng
        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        // Method thực hiện câu lệnh SQL với tham số
        public static int SQL(string qry, Hashtable ht)
        {
            int res = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }

                res = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open) { con.Close(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
            return res;
        }

        // Method để tải dữ liệu từ database lên DataGridView
        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < lb.Items.Count; i++)
                        {
                            string colName = ((DataGridViewColumn)lb.Items[i]).Name;
                            if (i < dt.Columns.Count)
                            {
                                gv.Columns[colName].DataPropertyName = dt.Columns[i].ColumnName;
                            }
                        }
                        gv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Kiểm tra nếu bảng category rỗng
        public static bool IsCategoryTableEmpty()
        {
            bool isEmpty = true;
            string qry = "SELECT COUNT(*) FROM category";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    isEmpty = false;
                }
            }
            return isEmpty;
        }

        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;
            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        // Làm mờ nền Form
        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = formMain.Instance.Size;
                Background.Location = formMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }

        // Điền ComboBox với dữ liệu từ database
        public static void CBFill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }
    }
}
