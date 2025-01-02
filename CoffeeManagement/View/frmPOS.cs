using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace CoffeeManagement.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }
        public int MainID = 0;
        public string OrderType="";
        public int driverID = 0;
        public string customerName = "";
        public string customerPhone = "";
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();
            ProductPanel.Controls.Clear();
            LoadProducts();
        }
        private void AddCategory()
        {
            string qry = "Select * from category";
            SqlCommand  cmd = new SqlCommand(qry,MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CategoryPanel.Controls.Clear();
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor= Color.FromArgb(50,55,89);
                    b.Size = new Size(121, 51);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();
                    b.Click += new EventHandler(_Click);
                    CategoryPanel.Controls.Add(b);
                }
                
            }
        }
        private void _Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            if(b.Text =="All Categories")
            {
                txtSearch.Text = "1";
                txtSearch.Text = "";
                return;
            }
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }
        private void AddItems(string id,String proID, string name,string cat, string price, Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name,
                PPrice = price,
                PCategory = cat,
                PImage = pimage,
                id = Convert.ToInt32(proID)

            };
            ProductPanel.Controls.Add(w);
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    // check product already there then a one to quantity and update price
                    if (Convert.ToInt32(item.Cells["dgvproID"].Value) == wdg.id)
                    {
                        int currentQty = int.Parse(item.Cells["dgvQty"].Value.ToString());
                        double pricePerUnit = double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        currentQty += 1;
                        item.Cells["dgvQty"].Value = currentQty;
                        item.Cells["dgvAmount"].Value = currentQty * pricePerUnit;
                        GetTotal();
                        return;
                    }
                }
                //add new product
                guna2DataGridView1.Rows.Add(new object[] { 0,0, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                GetTotal();
            };
        }
        //Getting product from db
        private void LoadProducts()
        {
            string qry = "Select * from products inner join category on catID = CategoryID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows) {
                Byte[] imagearray = (byte[])item["pImage"];
                byte[] imagebytearray = imagearray;
                AddItems("0 ",item["pID"].ToString(), item["pName"].ToString(), item["catName"].ToString(), item["pPrice"].ToString(),Image.FromStream(new MemoryStream(imagearray)));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
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
        private void GetTotal()
        {
            double tot = 0;
            lblTotal.Text = "";
            foreach(DataGridViewRow item in guna2DataGridView1.Rows)
            {
                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());

            }
            lblTotal.Text = tot.ToString("N2");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            guna2DataGridView1.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "00";
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Giao hàng";
            frmAddCustomer frm = new frmAddCustomer();
            frm.mainID = MainID;
            frm.orderType = OrderType;
            MainClass.BlurBackground(frm);
            if (frm.txtName.Text != "")
            {
                driverID = frm.driverID;
                lblDriverName.Text = " Tên khách hàng: " + frm.txtName.Text + " SDT : " + frm.txtPhone.Text + " Driver: " + frm.cbDriver.Text;
                lblDriverName.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Mang đi";
            frmAddCustomer frm = new frmAddCustomer();
            frm.mainID= MainID;
            frm.orderType= OrderType;
            MainClass.BlurBackground(frm);
            if (frm.txtName.Text != "")
            {
                driverID = frm.driverID;
                lblDriverName.Text=" Tên khách hàng: " + frm.txtName.Text + " SDT : " + frm.txtPhone.Text ;
                lblDriverName.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }
        }

        private void BtnDinIn_Click(object sender, EventArgs e)
        {
            OrderType = "Dùng tại cửa hàng";
            lblDriverName.Visible = false;
            frmTableSelect frm = new frmTableSelect();
            MainClass.BlurBackground(frm);
            if(frm.TableName != "")
            {
                lblTable.Text=frm.TableName;
                lblTable.Visible=true;
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible=false;
            }
            frmWaiterSelect frm2 = new frmWaiterSelect();
            MainClass.BlurBackground(frm2);
            if (frm2.WaiterName != "")
            {
                lblWaiter.Text=frm2.WaiterName;
                lblWaiter.Visible=true;
            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible=false;
            }
        }

        private void btnKOT_Click(object sender, EventArgs e)
        {
            //save datain db
            string qry1 = "";//Main table
            string qry2 = "";//Detail table
            int detailID = 0;

            if (MainID == 0)
            {
                qry1 = @"Insert into tblMain (aDate, aTime, TableName, WaiterName, status, orderType, total, received, change,driverID,CusName,Cusphone)
                 Values (@aDate, @aTime, @TableName, @WaiterName, @status, @orderType, @total, @received, @change,@driverID,@CusName,@CusPhone);
                Select SCOPE_IDENTITY()";
                //get recent add id value
            }
            else
            {
                qry1 = @"Update tblMain Set status=@status,total=@total,received=@received,change=@change where MainID=@ID";
            }
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID",MainID);
            cmd.Parameters.AddWithValue("@aDate",Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime",DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName",lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName",lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status","Đang chờ xử lý");
            cmd.Parameters.AddWithValue("@orderType",OrderType);
            cmd.Parameters.AddWithValue("@total",Convert.ToDouble(lblTotal.Text)); // we only saving data for kitchen value will update when payment received
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@driverID", driverID);
            cmd.Parameters.AddWithValue("@CusName", customerName);
            cmd.Parameters.AddWithValue("@CusPhone", customerPhone);

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if(MainID==0) {MainID=Convert.ToInt32( cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
            if(MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            foreach(DataGridViewRow row in guna2DataGridView1.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);
                if (detailID == 0)
                {
                    qry2 = @"Insert into tblDetails (MainID, proID, qty, price, amount,note) 
                     Values (@MainID, @proID, @qty, @price, @amount,@note)";
                }
                else
                {
                    qry2 = @"Update tblDetails Set proID=@proID,qty=@qty,price=@price,amount=@amount,note=@note
where DetailID=@ID";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@MainID", MainID);
                cmd2.Parameters.AddWithValue("@proID",Convert.ToInt32( row.Cells["dgvproID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvqty"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvPrice"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));
                cmd2.Parameters.AddWithValue("@note", row.Cells["dgvNote"].Value.ToString());
                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery(); 
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

                
            }
                guna2MessageDialog1.Show("Saved Succesful");
                MainID = 0;
                detailID = 0;
                guna2DataGridView1.Rows.Clear();
                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                
                lblTotal.Text = "00";
                lblDriverName.Text = "";
        }
        public int id = 0;

        private void btnBillList_Click(object sender, EventArgs e)
        {
            frmBillList frm = new frmBillList();
            MainClass.BlurBackground(frm);
            if (frm.MainID > 0)
            {
                id = frm.MainID;
                MainID = frm.MainID;
                LoadEntries();
            }
        }
        private void LoadEntries()
        {
            string qry = @"Select * from tblMain m inner join tblDetails d on m.MainID = d.MainID inner join products p on p.pID=d.proID where m.MainID = " +id+"";
            SqlCommand cmd2 = new SqlCommand(qry, MainClass.con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);
            if (dt2.Rows[0]["orderType"].ToString() =="Giao hàng"){
                btnDelivery.Checked = true;
                lblWaiter.Visible = false;
                lblTable.Visible = false;
            }

            else if (dt2.Rows[0]["orderType"].ToString()== "Mang đi"){
                btnTakeAway.Checked = true;
                lblWaiter.Visible =false;
                lblTable.Visible = false;
            }

            else
            {
                btnDin.Checked = true;
                lblWaiter.Visible = true;
                lblTable.Visible =true;

            }
                
            guna2DataGridView1.Rows.Clear();
            foreach(DataRow item in dt2.Rows)
            {

                lblTable.Text= item["TableName"].ToString();
                lblWaiter.Text = item["WaiterName"].ToString();
                string detailid= item["DetailID"].ToString();
                string proName = item["pName"].ToString();
                string proid = item["proID"].ToString();
                string qty = item["qty"].ToString();
                string price = item["price"].ToString();
                string amount = item["amount"].ToString();
                object[] obj = {0,detailid,proid,proName,qty,price,amount };
                guna2DataGridView1.Rows.Add(obj);
            }
            GetTotal();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            frmCheckOut frm = new frmCheckOut();
            frm.MainID = id;
            frm.amt = Convert.ToDouble(lblTotal.Text);
            MainClass.BlurBackground(frm);
            MainID = 0;
            guna2DataGridView1.Rows.Clear();
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;

            lblTotal.Text = "00";
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            string qry1 = "";//Main table
            string qry2 = "";//Detail table
            int detailID = 0;
            if(OrderType == "")
            {
                guna2MessageDialog1.Show("Vui lòng chọn loại đơn hàng");
                return;
            }
            if (MainID == 0)
            {
                qry1 = qry1 = @"Insert into tblMain (aDate, aTime, TableName, WaiterName, status, orderType, total, received, change,driverID,CusName,Cusphone)
                 Values (@aDate, @aTime, @TableName, @WaiterName, @status, @orderType, @total, @received, @change,@driverID,@CusName,@CusPhone);
                Select SCOPE_IDENTITY()";
                //get recent add id value
            }
            else
            {
                qry1 = @"Update tblMain Set status=@status,total=@total,received=@received,change=@change where MainID=@ID";
            }
            Hashtable ht = new Hashtable();
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Giữ");
            cmd.Parameters.AddWithValue("@orderType", OrderType);
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text)); // we only saving data for kitchen value will update when payment received
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@driverID", driverID);
            cmd.Parameters.AddWithValue("@CusName", customerName);
            cmd.Parameters.AddWithValue("@CusPhone", customerPhone);

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); } else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvid"].Value);
                if (detailID == 0)
                {
                    qry2 = @"Insert into tblDetails (MainID, proID, qty, price, amount) 
                     Values (@MainID, @proID, @qty, @price, @amount)";
                }
                else
                {
                    qry2 = @"Update tblDetails Set proID=@proID,qty=@qty,price=@price,amount=@amount
where DetailID=@ID";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@MainID", MainID);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvqty"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvPrice"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));

                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }


            }
            guna2MessageDialog1.Show("Saved Succesful");
            MainID = 0;
            detailID = 0;
            guna2DataGridView1.Rows.Clear();
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;

            lblTotal.Text = "00";
            lblDriverName.Text = "";
        }
    }
}
