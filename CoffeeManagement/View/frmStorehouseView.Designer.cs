namespace CoffeeManagement.View
{
    partial class frmStorehouseView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.materialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnWarehouseHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheckExpired = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.HoverState.ImageSize = new System.Drawing.Size(57, 57);
            this.btnAdd.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
            this.btnAdd.PressedState.ImageSize = new System.Drawing.Size(55, 55);
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(184, 23);
            this.label2.Text = "Danh sách nguyên liệu";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Size = new System.Drawing.Size(1139, 10);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(743, 39);
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView1.ColumnHeadersHeight = 25;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materialID,
            this.materialName,
            this.materialQuantity,
            this.materialUnit,
            this.exDate});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(27, 162);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(1019, 291);
            this.guna2DataGridView1.TabIndex = 5;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 25;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // materialID
            // 
            this.materialID.HeaderText = "ID";
            this.materialID.MinimumWidth = 6;
            this.materialID.Name = "materialID";
            this.materialID.ReadOnly = true;
            // 
            // materialName
            // 
            this.materialName.HeaderText = "Tên nguyên liệu";
            this.materialName.MinimumWidth = 6;
            this.materialName.Name = "materialName";
            this.materialName.ReadOnly = true;
            // 
            // materialQuantity
            // 
            this.materialQuantity.HeaderText = "Số lượng";
            this.materialQuantity.MinimumWidth = 6;
            this.materialQuantity.Name = "materialQuantity";
            this.materialQuantity.ReadOnly = true;
            // 
            // materialUnit
            // 
            this.materialUnit.HeaderText = "Đơn vị";
            this.materialUnit.MinimumWidth = 6;
            this.materialUnit.Name = "materialUnit";
            this.materialUnit.ReadOnly = true;
            // 
            // exDate
            // 
            this.exDate.HeaderText = "Hạn sử dụng";
            this.exDate.MinimumWidth = 6;
            this.exDate.Name = "exDate";
            this.exDate.ReadOnly = true;
            // 
            // btnWarehouseHistory
            // 
            this.btnWarehouseHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnWarehouseHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnWarehouseHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnWarehouseHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnWarehouseHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnWarehouseHistory.ForeColor = System.Drawing.Color.White;
            this.btnWarehouseHistory.Location = new System.Drawing.Point(27, 474);
            this.btnWarehouseHistory.Name = "btnWarehouseHistory";
            this.btnWarehouseHistory.Size = new System.Drawing.Size(180, 45);
            this.btnWarehouseHistory.TabIndex = 6;
            this.btnWarehouseHistory.Text = "Lịch sử nhập kho";
            this.btnWarehouseHistory.Click += new System.EventHandler(this.btnWarehouseHistory_Click);
            // 
            // btnCheckExpired
            // 
            this.btnCheckExpired.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckExpired.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckExpired.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheckExpired.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheckExpired.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCheckExpired.ForeColor = System.Drawing.Color.White;
            this.btnCheckExpired.Location = new System.Drawing.Point(895, 474);
            this.btnCheckExpired.Name = "btnCheckExpired";
            this.btnCheckExpired.Size = new System.Drawing.Size(180, 45);
            this.btnCheckExpired.TabIndex = 7;
            this.btnCheckExpired.Text = "Sản phẩm hết hạn";
            this.btnCheckExpired.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmStorehouseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 540);
            this.Controls.Add(this.btnCheckExpired);
            this.Controls.Add(this.btnWarehouseHistory);
            this.Controls.Add(this.guna2DataGridView1);
            this.Name = "frmStorehouseView";
            this.Text = "frmStorehouseView";
            this.Load += new System.EventHandler(this.frmStorehouseView_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.guna2Separator1, 0);
            this.Controls.SetChildIndex(this.guna2DataGridView1, 0);
            this.Controls.SetChildIndex(this.btnWarehouseHistory, 0);
            this.Controls.SetChildIndex(this.btnCheckExpired, 0);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn exDate;
        private Guna.UI2.WinForms.Guna2Button btnWarehouseHistory;
        private Guna.UI2.WinForms.Guna2Button btnCheckExpired;
    }
}