using CoffeeManagement.Bl;
using CoffeeManagement.TL;
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
    public partial class frmStorehouseAdd : SampleAdd
    {
        private readonly MaterialBL materialBL;

        public frmStorehouseAdd()
        {
            InitializeComponent();
            materialBL = new MaterialBL();
            materialBL = new MaterialBL(); LoadSuppliers();
        }
        public int MaterialID { get; set; }

        public void SetMaterial(MaterialTL material)
        {
            MaterialID = material.ID;
            txtName.Text = material.Tên_nguyên_liệu;
            txtQuantity.Text = material.Số_lượng.ToString();
            txtUnit.Text = material.Đơn_vị;
            txtExDate.Text = material.Hạn_sử_dụng.ToString("dd/MM/yyyy");
            cbSupplier.Text = material.Tên_nhà_cung_cấp;
            txtSupplierPhone.Text = material.SDT_nhà_cung_cấp;
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            { // Kiểm tra hoặc thêm SupplierID
                int supplierID = materialBL.GetOrCreateSupplierID(cbSupplier.Text, txtSupplierPhone.Text);
                var material = new MaterialTL
                {
                    ID = this.MaterialID,
                    Tên_nguyên_liệu = txtName.Text,
                    Số_lượng = int.Parse(txtQuantity.Text),
                    Đơn_vị = txtUnit.Text,
                    Hạn_sử_dụng = DateTime.ParseExact(txtExDate.Text, "dd/MM/yyyy", null),
                    Tên_nhà_cung_cấp = cbSupplier.Text,
                    SDT_nhà_cung_cấp = txtSupplierPhone.Text,
                    SupplierID = supplierID
                };
                if (material.ID > 0)
                {
                    materialBL.UpdMaterial(material);
                }// Cập nhật nếu có ID }
                else
                {
                    materialBL.AddMaterial(material); // Thêm mới nếu không có ID 
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving material: " + ex.Message);

            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void LoadSuppliers()
        {
            var suppliers = materialBL.GetSuppliers();
            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = "Tên_nhà_cung_cấp";
            cbSupplier.ValueMember = "ID";
        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedItem is SupplierTL selectedSupplier)
            {
                txtSupplierPhone.Text = selectedSupplier.SDT_nhà_cung_cấp;
            }
        }
    }
}
