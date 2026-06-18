namespace DuAn.GUI.ADMIN
{
    partial class frmAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnTaiThucDon = new System.Windows.Forms.Button();
            this.dtpTuan = new System.Windows.Forms.DateTimePicker();
            this.lblTuan = new System.Windows.Forms.Label();
            this.cboCheDo = new System.Windows.Forms.ComboBox();
            this.lblCheDo = new System.Windows.Forms.Label();
            this.dgvThucDon = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(83)))), ((int)(((byte)(142)))));
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1180, 72);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BackColor = System.Drawing.Color.LightCoral;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.Location = new System.Drawing.Point(1026, 16);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(130, 40);
            this.btnDangXuat.TabIndex = 1;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(357, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ADMIN DUYỆT THỰC ĐƠN";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFilter.Controls.Add(this.lblTrangThai);
            this.pnlFilter.Controls.Add(this.btnDuyet);
            this.pnlFilter.Controls.Add(this.btnTaiThucDon);
            this.pnlFilter.Controls.Add(this.dtpTuan);
            this.pnlFilter.Controls.Add(this.lblTuan);
            this.pnlFilter.Controls.Add(this.cboCheDo);
            this.pnlFilter.Controls.Add(this.lblCheDo);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 72);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1180, 110);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.Location = new System.Drawing.Point(31, 69);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(192, 28);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Chưa tải thực đơn";
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnDuyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Location = new System.Drawing.Point(681, 21);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(142, 38);
            this.btnDuyet.TabIndex = 5;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.UseVisualStyleBackColor = false;
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnTaiThucDon
            // 
            this.btnTaiThucDon.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTaiThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiThucDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaiThucDon.Location = new System.Drawing.Point(511, 21);
            this.btnTaiThucDon.Name = "btnTaiThucDon";
            this.btnTaiThucDon.Size = new System.Drawing.Size(142, 38);
            this.btnTaiThucDon.TabIndex = 4;
            this.btnTaiThucDon.Text = "Tải thực đơn";
            this.btnTaiThucDon.UseVisualStyleBackColor = false;
            this.btnTaiThucDon.Click += new System.EventHandler(this.btnTaiThucDon_Click);
            // 
            // dtpTuan
            // 
            this.dtpTuan.CustomFormat = "dd/MM/yyyy";
            this.dtpTuan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuan.Location = new System.Drawing.Point(346, 27);
            this.dtpTuan.Name = "dtpTuan";
            this.dtpTuan.Size = new System.Drawing.Size(137, 26);
            this.dtpTuan.TabIndex = 3;
            // 
            // lblTuan
            // 
            this.lblTuan.AutoSize = true;
            this.lblTuan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTuan.Location = new System.Drawing.Point(282, 25);
            this.lblTuan.Name = "lblTuan";
            this.lblTuan.Size = new System.Drawing.Size(58, 28);
            this.lblTuan.TabIndex = 2;
            this.lblTuan.Text = "Tuần";
            // 
            // cboCheDo
            // 
            this.cboCheDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheDo.FormattingEnabled = true;
            this.cboCheDo.Location = new System.Drawing.Point(112, 25);
            this.cboCheDo.Name = "cboCheDo";
            this.cboCheDo.Size = new System.Drawing.Size(148, 28);
            this.cboCheDo.TabIndex = 1;
            // 
            // lblCheDo
            // 
            this.lblCheDo.AutoSize = true;
            this.lblCheDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheDo.Location = new System.Drawing.Point(31, 25);
            this.lblCheDo.Name = "lblCheDo";
            this.lblCheDo.Size = new System.Drawing.Size(75, 28);
            this.lblCheDo.TabIndex = 0;
            this.lblCheDo.Text = "Chế độ";
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.AllowUserToAddRows = false;
            this.dgvThucDon.AllowUserToDeleteRows = false;
            this.dgvThucDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThucDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucDon.Location = new System.Drawing.Point(0, 182);
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.ReadOnly = true;
            this.dgvThucDon.RowHeadersWidth = 62;
            this.dgvThucDon.RowTemplate.Height = 28;
            this.dgvThucDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThucDon.Size = new System.Drawing.Size(1180, 538);
            this.dgvThucDon.TabIndex = 2;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.dgvThucDon);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin duyệt thực đơn";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTaiThucDon;
        private System.Windows.Forms.DateTimePicker dtpTuan;
        private System.Windows.Forms.Label lblTuan;
        private System.Windows.Forms.ComboBox cboCheDo;
        private System.Windows.Forms.Label lblCheDo;
        private System.Windows.Forms.DataGridView dgvThucDon;
    }
}
