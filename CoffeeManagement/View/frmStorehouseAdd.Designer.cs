namespace CoffeeManagement.Model
{
    partial class frmStorehouseAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblexDate = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtExDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSupplierPhone = new System.Windows.Forms.TextBox();
            this.cbSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(209, 32);
            this.label1.Text = "Thêm nguyên liệu";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::CoffeeManagement.Properties.Resources.warehouse;
            this.guna2PictureBox1.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnClose
            // 
            this.btnClose.CustomizableEdges.TopRight = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.CustomizableEdges.TopRight = false;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(35, 136);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Tên nguyên liệu";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(294, 136);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(78, 23);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "Số lượng";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(35, 235);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(59, 23);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Đơn vị";
            // 
            // lblexDate
            // 
            this.lblexDate.AutoSize = true;
            this.lblexDate.Location = new System.Drawing.Point(294, 235);
            this.lblexDate.Name = "lblexDate";
            this.lblexDate.Size = new System.Drawing.Size(233, 23);
            this.lblexDate.TabIndex = 5;
            this.lblexDate.Text = "Hạn sử dụng ( dd/mm/YYYY )";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(39, 176);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 30);
            this.txtName.TabIndex = 6;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(298, 176);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(218, 30);
            this.txtQuantity.TabIndex = 7;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(39, 300);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(221, 30);
            this.txtUnit.TabIndex = 8;
            // 
            // txtExDate
            // 
            this.txtExDate.Location = new System.Drawing.Point(298, 300);
            this.txtExDate.Name = "txtExDate";
            this.txtExDate.Size = new System.Drawing.Size(218, 30);
            this.txtExDate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(591, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tên nhà cung cấp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(591, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "SDT nhà cung cấp";
            // 
            // txtSupplierPhone
            // 
            this.txtSupplierPhone.Location = new System.Drawing.Point(570, 300);
            this.txtSupplierPhone.Name = "txtSupplierPhone";
            this.txtSupplierPhone.Size = new System.Drawing.Size(218, 30);
            this.txtSupplierPhone.TabIndex = 13;
            // 
            // cbSupplier
            // 
            this.cbSupplier.BackColor = System.Drawing.Color.Transparent;
            this.cbSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSupplier.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSupplier.ItemHeight = 30;
            this.cbSupplier.Location = new System.Drawing.Point(570, 170);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(218, 36);
            this.cbSupplier.TabIndex = 14;
            this.cbSupplier.SelectedIndexChanged += new System.EventHandler(this.cbSupplier_SelectedIndexChanged);
            // 
            // frmStorehouseAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbSupplier);
            this.Controls.Add(this.txtSupplierPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExDate);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblexDate);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblName);
            this.Name = "frmStorehouseAdd";
            this.Text = "frmStorehouseAdd";
            this.Controls.SetChildIndex(this.guna2Panel1, 0);
            this.Controls.SetChildIndex(this.guna2Panel2, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.lblQuantity, 0);
            this.Controls.SetChildIndex(this.lblUnit, 0);
            this.Controls.SetChildIndex(this.lblexDate, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.txtQuantity, 0);
            this.Controls.SetChildIndex(this.txtUnit, 0);
            this.Controls.SetChildIndex(this.txtExDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtSupplierPhone, 0);
            this.Controls.SetChildIndex(this.cbSupplier, 0);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblexDate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtExDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSupplierPhone;
        private Guna.UI2.WinForms.Guna2ComboBox cbSupplier;
    }
}