using CoffeeManagement.Model;
using CoffeeManagement.TL;
using CoffeeManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class formMain : Form
    {
        private readonly UserTransaction _userTransaction = new UserTransaction();

        public static formMain Instance { get; private set; }


        public formMain()
        {
            InitializeComponent();
        }
        private void formMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = _userTransaction.GetUserName();
            Instance = this; // Đặt tham chiếu formMain hiện tại vào Instance
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView());
        }

        public void AddControls(Form f)
        {
            guna2Panel3.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            guna2Panel3.Controls.Add(f);
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            AddControls(new frmKitchenView());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddControls(new frmPOS());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            AddControls(new frmStaffView());
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            AddControls(new frmTableView());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategoryView());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnStorehouse_Click(object sender, EventArgs e)
        {
            AddControls(new frmStorehouseView());
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
            AddControls(new frmHome());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            AddControls(new frmSupplierView());
        }
    }
}
