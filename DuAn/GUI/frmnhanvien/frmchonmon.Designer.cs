namespace DuAn.GUI.frmnhanvien
{
    partial class frmchonmon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvMonAn = new System.Windows.Forms.DataGridView();
            this.colMonAnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhuyenNghi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpNguyenLieu = new System.Windows.Forms.GroupBox();
            this.dgvNguyenLieu = new System.Windows.Forms.DataGridView();
            this.colTenThucPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDinhLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.header.SuspendLayout();
            this.footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
            this.grpNguyenLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).BeginInit();
            this.SuspendLayout();
            //
            // header
            //
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Height = 64;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.header.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 64);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Text = "Chọn món";
            //
            // lblEmpty
            //
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblEmpty.Height = 36;
            this.lblEmpty.Location = new System.Drawing.Point(0, 64);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Padding = new System.Windows.Forms.Padding(18, 0, 18, 0);
            this.lblEmpty.Size = new System.Drawing.Size(1034, 36);
            this.lblEmpty.TabIndex = 2;
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmpty.Visible = false;
            //
            // footer
            //
            this.footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.footer.Controls.Add(this.btnChon);
            this.footer.Controls.Add(this.btnHuy);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Height = 62;
            this.footer.Location = new System.Drawing.Point(0, 458);
            this.footer.Name = "footer";
            this.footer.Padding = new System.Windows.Forms.Padding(18, 10, 18, 10);
            this.footer.TabIndex = 3;
            //
            // btnChon
            //
            this.btnChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnChon.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChon.ForeColor = System.Drawing.Color.White;
            this.btnChon.Height = 40;
            this.btnChon.Location = new System.Drawing.Point(904, 10);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(112, 40);
            this.btnChon.TabIndex = 0;
            this.btnChon.Text = "Chọn món";
            this.btnChon.UseVisualStyleBackColor = false;
            //
            // btnHuy
            //
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.btnHuy.Height = 40;
            this.btnHuy.Location = new System.Drawing.Point(800, 10);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            //
            // splitContainer
            //
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 100);
            this.splitContainer.Name = "splitContainer";
            //
            // splitContainer.Panel1
            //
            this.splitContainer.Panel1.Controls.Add(this.dgvMonAn);
            this.splitContainer.Panel1.Controls.Add(this.txtTimKiem);
            //
            // splitContainer.Panel2
            //
            this.splitContainer.Panel2.Controls.Add(this.grpNguyenLieu);
            this.splitContainer.Size = new System.Drawing.Size(1034, 358);
            this.splitContainer.SplitterDistance = 700;
            this.splitContainer.TabIndex = 4;
            //
            // dgvMonAn
            //
            this.dgvMonAn.AllowUserToAddRows = false;
            this.dgvMonAn.AllowUserToDeleteRows = false;
            this.dgvMonAn.AllowUserToResizeRows = false;
            this.dgvMonAn.AutoGenerateColumns = false;
            this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonAn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonAn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMonAnId,
            this.colTenMon,
            this.colLoaiMon,
            this.colKhuyenNghi});
            this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonAn.Location = new System.Drawing.Point(0, 0);
            this.dgvMonAn.MultiSelect = false;
            this.dgvMonAn.Name = "dgvMonAn";
            this.dgvMonAn.ReadOnly = true;
            this.dgvMonAn.RowHeadersVisible = false;
            this.dgvMonAn.RowHeadersWidth = 51;
            this.dgvMonAn.RowTemplate.Height = 24;
            this.dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonAn.Size = new System.Drawing.Size(700, 358);
            this.dgvMonAn.TabIndex = 0;
            //
            // colMonAnId
            //
            this.colMonAnId.DataPropertyName = "MonAnId";
            this.colMonAnId.HeaderText = "Mã";
            this.colMonAnId.MinimumWidth = 6;
            this.colMonAnId.Name = "colMonAnId";
            this.colMonAnId.ReadOnly = true;
            this.colMonAnId.Width = 70;
            //
            // colTenMon
            //
            this.colTenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenMon.DataPropertyName = "TenMon";
            this.colTenMon.HeaderText = "Tên món";
            this.colTenMon.MinimumWidth = 6;
            this.colTenMon.Name = "colTenMon";
            this.colTenMon.ReadOnly = true;
            //
            // colLoaiMon
            //
            this.colLoaiMon.DataPropertyName = "LoaiMon";
            this.colLoaiMon.HeaderText = "Loại món";
            this.colLoaiMon.MinimumWidth = 6;
            this.colLoaiMon.Name = "colLoaiMon";
            this.colLoaiMon.ReadOnly = true;
            this.colLoaiMon.Width = 120;
            //
            // colKhuyenNghi
            //
            this.colKhuyenNghi.HeaderText = "Khuyến nghị";
            this.colKhuyenNghi.MinimumWidth = 6;
            this.colKhuyenNghi.Name = "ColKhuyenNghi";
            this.colKhuyenNghi.ReadOnly = true;
            this.colKhuyenNghi.Width = 220;
            //
            // grpNguyenLieu
            //
            this.grpNguyenLieu.Controls.Add(this.dgvNguyenLieu);
            this.grpNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpNguyenLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.grpNguyenLieu.Location = new System.Drawing.Point(0, 0);
            this.grpNguyenLieu.Name = "grpNguyenLieu";
            this.grpNguyenLieu.Padding = new System.Windows.Forms.Padding(8, 22, 8, 8);
            this.grpNguyenLieu.Size = new System.Drawing.Size(330, 358);
            this.grpNguyenLieu.TabIndex = 0;
            this.grpNguyenLieu.TabStop = false;
            this.grpNguyenLieu.Text = "Nguyên liệu chế biến";
            //
            // dgvNguyenLieu
            //
            this.dgvNguyenLieu.AllowUserToAddRows = false;
            this.dgvNguyenLieu.AllowUserToDeleteRows = false;
            this.dgvNguyenLieu.AllowUserToResizeRows = false;
            this.dgvNguyenLieu.AutoGenerateColumns = false;
            this.dgvNguyenLieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvNguyenLieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguyenLieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguyenLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenThucPham,
            this.colDinhLuong,
            this.colDonViTinh});
            this.dgvNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNguyenLieu.Location = new System.Drawing.Point(8, 22);
            this.dgvNguyenLieu.MultiSelect = false;
            this.dgvNguyenLieu.Name = "dgvNguyenLieu";
            this.dgvNguyenLieu.ReadOnly = true;
            this.dgvNguyenLieu.RowHeadersVisible = false;
            this.dgvNguyenLieu.RowHeadersWidth = 51;
            this.dgvNguyenLieu.RowTemplate.Height = 24;
            this.dgvNguyenLieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguyenLieu.Size = new System.Drawing.Size(314, 328);
            this.dgvNguyenLieu.TabIndex = 0;
            //
            // colTenThucPham
            //
            this.colTenThucPham.DataPropertyName = "TenThucPham";
            this.colTenThucPham.HeaderText = "Tên thực phẩm";
            this.colTenThucPham.MinimumWidth = 6;
            this.colTenThucPham.Name = "colTenThucPham";
            this.colTenThucPham.ReadOnly = true;
            this.colTenThucPham.Width = 150;
            //
            // colDinhLuong
            //
            this.colDinhLuong.DataPropertyName = "DinhLuong";
            this.colDinhLuong.HeaderText = "Số gam";
            this.colDinhLuong.MinimumWidth = 6;
            this.colDinhLuong.Name = "colDinhLuong";
            this.colDinhLuong.ReadOnly = true;
            this.colDinhLuong.Width = 80;
            //
            // colDonViTinh
            //
            this.colDonViTinh.DataPropertyName = "DonViTinh";
            this.colDonViTinh.HeaderText = "ĐVT";
            this.colDonViTinh.MinimumWidth = 6;
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            this.colDonViTinh.Width = 60;
            //
            // txtTimKiem
            //
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(0, 0);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(700, 23);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.Text = "🔍 Tìm món...";
            //
            // frmchonmon
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 520);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(800, 440);
            this.Name = "frmchonmon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn món";
            this.Load += new System.EventHandler(this.frmchonmon_Load);
            this.header.ResumeLayout(false);
            this.footer.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
            this.grpNguyenLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonAnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhuyenNghi;
        private System.Windows.Forms.GroupBox grpNguyenLieu;
        private System.Windows.Forms.DataGridView dgvNguyenLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThucPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDinhLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}
