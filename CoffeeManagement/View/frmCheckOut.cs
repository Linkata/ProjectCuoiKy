using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement.Model
{
    public partial class frmCheckOut : SampleAdd
    {
        public frmCheckOut()
        {
            InitializeComponent();
        }
        public double amt;
        public int MainID = 0;
        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;
            double.TryParse(txtBillAmount.Text, out amt);   
            double.TryParse(txtReceived.Text, out receipt);
            change =Math.Abs( amt - receipt);
            txtChange.Text = change.ToString();
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            string qry = @"Update tblMain set total = @total, received= @rec, change = @change,status = 'Đã thanh toán' where MainID=@id";
            Hashtable ht = new Hashtable();
            ht.Add("@total",txtBillAmount.Text);
            ht.Add("@rec", txtReceived.Text);
            ht.Add("@change", txtChange.Text);
            ht.Add("@id", MainID);

            if (MainClass.SQL(qry, ht) > 0)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Lưu thành công");
                this.Close();
            }
        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text = amt.ToString();
        }
    }
}
