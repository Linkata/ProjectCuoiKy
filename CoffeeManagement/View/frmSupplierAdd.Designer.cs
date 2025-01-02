namespace CoffeeManagement.View
{
    partial class frmSupplierAdd
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
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblSupplierPhone = new System.Windows.Forms.Label();
            this.txtbSupplierName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtbSupplierPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(102, 32);
            this.label1.Text = "Supplier";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::CoffeeManagement.Properties.Resources.Supplier;
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
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(22, 163);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(145, 23);
            this.lblSupplierName.TabIndex = 2;
            this.lblSupplierName.Text = "Tên nhà cung cấp";
            // 
            // lblSupplierPhone
            // 
            this.lblSupplierPhone.AutoSize = true;
            this.lblSupplierPhone.Location = new System.Drawing.Point(22, 280);
            this.lblSupplierPhone.Name = "lblSupplierPhone";
            this.lblSupplierPhone.Size = new System.Drawing.Size(149, 23);
            this.lblSupplierPhone.TabIndex = 3;
            this.lblSupplierPhone.Text = "SĐT nhà cung cấp";
            // 
            // txtbSupplierName
            // 
            this.txtbSupplierName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbSupplierName.DefaultText = "";
            this.txtbSupplierName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbSupplierName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbSupplierName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbSupplierName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbSupplierName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbSupplierName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbSupplierName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbSupplierName.Location = new System.Drawing.Point(186, 163);
            this.txtbSupplierName.Name = "txtbSupplierName";
            this.txtbSupplierName.PasswordChar = '\0';
            this.txtbSupplierName.PlaceholderText = "";
            this.txtbSupplierName.SelectedText = "";
            this.txtbSupplierName.Size = new System.Drawing.Size(582, 36);
            this.txtbSupplierName.TabIndex = 4;
            // 
            // txtbSupplierPhone
            // 
            this.txtbSupplierPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbSupplierPhone.DefaultText = "";
            this.txtbSupplierPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbSupplierPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbSupplierPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbSupplierPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbSupplierPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbSupplierPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbSupplierPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbSupplierPhone.Location = new System.Drawing.Point(186, 280);
            this.txtbSupplierPhone.Name = "txtbSupplierPhone";
            this.txtbSupplierPhone.PasswordChar = '\0';
            this.txtbSupplierPhone.PlaceholderText = "";
            this.txtbSupplierPhone.SelectedText = "";
            this.txtbSupplierPhone.Size = new System.Drawing.Size(582, 36);
            this.txtbSupplierPhone.TabIndex = 5;
            // 
            // frmSupplierAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtbSupplierPhone);
            this.Controls.Add(this.txtbSupplierName);
            this.Controls.Add(this.lblSupplierPhone);
            this.Controls.Add(this.lblSupplierName);
            this.Name = "frmSupplierAdd";
            this.Text = "frmSupplierAdd";
            this.Controls.SetChildIndex(this.guna2Panel1, 0);
            this.Controls.SetChildIndex(this.guna2Panel2, 0);
            this.Controls.SetChildIndex(this.lblSupplierName, 0);
            this.Controls.SetChildIndex(this.lblSupplierPhone, 0);
            this.Controls.SetChildIndex(this.txtbSupplierName, 0);
            this.Controls.SetChildIndex(this.txtbSupplierPhone, 0);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblSupplierPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtbSupplierName;
        private Guna.UI2.WinForms.Guna2TextBox txtbSupplierPhone;
    }
}