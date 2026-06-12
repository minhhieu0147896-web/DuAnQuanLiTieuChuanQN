namespace DuAn.GUI.frmnhanvien
{
    partial class frmChiTietNgay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblCheDo = new System.Windows.Forms.Label();
            this.tabChiTiet = new System.Windows.Forms.TabControl();
            this.tabMonAn = new System.Windows.Forms.TabPage();
            this.dgvMonTrongNgay = new System.Windows.Forms.DataGridView();
            this.colMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabNguyenLieu = new System.Windows.Forms.TabPage();
            this.dgvNguyenLieuNgay = new System.Windows.Forms.DataGridView();
            this.colTenTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDinhLuongTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.tabChiTiet.SuspendLayout();
            this.tabMonAn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonTrongNgay)).BeginInit();
            this.tabNguyenLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieuNgay)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.lblCheDo);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(18, 10, 18, 0);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTieuDe
            //
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(18, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(664, 36);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Chi tiết ngày";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblCheDo
            //
            this.lblCheDo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheDo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCheDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.lblCheDo.Location = new System.Drawing.Point(18, 46);
            this.lblCheDo.Name = "lblCheDo";
            this.lblCheDo.Size = new System.Drawing.Size(664, 24);
            this.lblCheDo.TabIndex = 1;
            this.lblCheDo.Text = "Chế độ: ...";
            this.lblCheDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // tabChiTiet
            //
            this.tabChiTiet.Controls.Add(this.tabMonAn);
            this.tabChiTiet.Controls.Add(this.tabNguyenLieu);
            this.tabChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabChiTiet.Location = new System.Drawing.Point(0, 80);
            this.tabChiTiet.Name = "tabChiTiet";
            this.tabChiTiet.Padding = new System.Drawing.Point(8, 4);
            this.tabChiTiet.SelectedIndex = 0;
            this.tabChiTiet.Size = new System.Drawing.Size(700, 340);
            this.tabChiTiet.TabIndex = 1;
            //
            // tabMonAn
            //
            this.tabMonAn.BackColor = System.Drawing.Color.White;
            this.tabMonAn.Controls.Add(this.dgvMonTrongNgay);
            this.tabMonAn.Location = new System.Drawing.Point(4, 24);
            this.tabMonAn.Name = "tabMonAn";
            this.tabMonAn.Padding = new System.Windows.Forms.Padding(3);
            this.tabMonAn.Size = new System.Drawing.Size(692, 312);
            this.tabMonAn.TabIndex = 0;
            this.tabMonAn.Text = "Món ăn trong ngày";
            //
            // dgvMonTrongNgay
            //
            this.dgvMonTrongNgay.AllowUserToAddRows = false;
            this.dgvMonTrongNgay.AllowUserToDeleteRows = false;
            this.dgvMonTrongNgay.AllowUserToResizeRows = false;
            this.dgvMonTrongNgay.AutoGenerateColumns = false;
            this.dgvMonTrongNgay.BackgroundColor = System.Drawing.Color.White;
            this.dgvMonTrongNgay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonTrongNgay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonTrongNgay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonTrongNgay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMon,
            this.colTenMon,
            this.colBuoi,
            this.colLoaiMon});
            this.dgvMonTrongNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonTrongNgay.Location = new System.Drawing.Point(3, 3);
            this.dgvMonTrongNgay.MultiSelect = false;
            this.dgvMonTrongNgay.Name = "dgvMonTrongNgay";
            this.dgvMonTrongNgay.ReadOnly = true;
            this.dgvMonTrongNgay.RowHeadersVisible = false;
            this.dgvMonTrongNgay.RowHeadersWidth = 51;
            this.dgvMonTrongNgay.RowTemplate.Height = 24;
            this.dgvMonTrongNgay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonTrongNgay.Size = new System.Drawing.Size(686, 306);
            this.dgvMonTrongNgay.TabIndex = 0;
            //
            // colMaMon
            //
            this.colMaMon.DataPropertyName = "MaMon";
            this.colMaMon.HeaderText = "Mã";
            this.colMaMon.MinimumWidth = 6;
            this.colMaMon.Name = "colMaMon";
            this.colMaMon.ReadOnly = true;
            this.colMaMon.Width = 50;
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
            // colBuoi
            //
            this.colBuoi.DataPropertyName = "TenBuoi";
            this.colBuoi.HeaderText = "Buổi";
            this.colBuoi.MinimumWidth = 6;
            this.colBuoi.Name = "colBuoi";
            this.colBuoi.ReadOnly = true;
            this.colBuoi.Width = 80;
            //
            // colLoaiMon
            //
            this.colLoaiMon.DataPropertyName = "LoaiMon";
            this.colLoaiMon.HeaderText = "Loại món";
            this.colLoaiMon.MinimumWidth = 6;
            this.colLoaiMon.Name = "colLoaiMon";
            this.colLoaiMon.ReadOnly = true;
            this.colLoaiMon.Width = 100;
            //
            // tabNguyenLieu
            //
            this.tabNguyenLieu.BackColor = System.Drawing.Color.White;
            this.tabNguyenLieu.Controls.Add(this.dgvNguyenLieuNgay);
            this.tabNguyenLieu.Location = new System.Drawing.Point(4, 24);
            this.tabNguyenLieu.Name = "tabNguyenLieu";
            this.tabNguyenLieu.Padding = new System.Windows.Forms.Padding(3);
            this.tabNguyenLieu.Size = new System.Drawing.Size(692, 312);
            this.tabNguyenLieu.TabIndex = 1;
            this.tabNguyenLieu.Text = "Nguyên liệu tổng";
            //
            // dgvNguyenLieuNgay
            //
            this.dgvNguyenLieuNgay.AllowUserToAddRows = false;
            this.dgvNguyenLieuNgay.AllowUserToDeleteRows = false;
            this.dgvNguyenLieuNgay.AllowUserToResizeRows = false;
            this.dgvNguyenLieuNgay.AutoGenerateColumns = false;
            this.dgvNguyenLieuNgay.BackgroundColor = System.Drawing.Color.White;
            this.dgvNguyenLieuNgay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguyenLieuNgay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNguyenLieuNgay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguyenLieuNgay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenTP,
            this.colDinhLuongTP,
            this.colDonViTP});
            this.dgvNguyenLieuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNguyenLieuNgay.Location = new System.Drawing.Point(3, 3);
            this.dgvNguyenLieuNgay.MultiSelect = false;
            this.dgvNguyenLieuNgay.Name = "dgvNguyenLieuNgay";
            this.dgvNguyenLieuNgay.ReadOnly = true;
            this.dgvNguyenLieuNgay.RowHeadersVisible = false;
            this.dgvNguyenLieuNgay.RowHeadersWidth = 51;
            this.dgvNguyenLieuNgay.RowTemplate.Height = 24;
            this.dgvNguyenLieuNgay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguyenLieuNgay.Size = new System.Drawing.Size(686, 306);
            this.dgvNguyenLieuNgay.TabIndex = 0;
            //
            // colTenTP
            //
            this.colTenTP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenTP.DataPropertyName = "TenThucPham";
            this.colTenTP.HeaderText = "Tên thực phẩm";
            this.colTenTP.MinimumWidth = 6;
            this.colTenTP.Name = "colTenTP";
            this.colTenTP.ReadOnly = true;
            //
            // colDinhLuongTP
            //
            this.colDinhLuongTP.DataPropertyName = "DinhLuong";
            this.colDinhLuongTP.HeaderText = "Số gam";
            this.colDinhLuongTP.MinimumWidth = 6;
            this.colDinhLuongTP.Name = "colDinhLuongTP";
            this.colDinhLuongTP.ReadOnly = true;
            this.colDinhLuongTP.Width = 120;
            //
            // colDonViTP
            //
            this.colDonViTP.DataPropertyName = "DonViTinh";
            this.colDonViTP.HeaderText = "ĐVT";
            this.colDonViTP.MinimumWidth = 6;
            this.colDonViTP.Name = "colDonViTP";
            this.colDonViTP.ReadOnly = true;
            this.colDonViTP.Width = 60;
            //
            // pnlFooter
            //
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlFooter.Controls.Add(this.btnDong);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 56;
            this.pnlFooter.Location = new System.Drawing.Point(0, 420);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(18, 10, 18, 10);
            this.pnlFooter.TabIndex = 2;
            //
            // btnDong
            //
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.btnDong.Location = new System.Drawing.Point(570, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(112, 36);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            //
            // frmChiTietNgay
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 476);
            this.Controls.Add(this.tabChiTiet);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmChiTietNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết ngày";
            this.pnlHeader.ResumeLayout(false);
            this.tabChiTiet.ResumeLayout(false);
            this.tabMonAn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonTrongNgay)).EndInit();
            this.tabNguyenLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguyenLieuNgay)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblCheDo;
        private System.Windows.Forms.TabControl tabChiTiet;
        private System.Windows.Forms.TabPage tabMonAn;
        private System.Windows.Forms.TabPage tabNguyenLieu;
        private System.Windows.Forms.DataGridView dgvMonTrongNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiMon;
        private System.Windows.Forms.DataGridView dgvNguyenLieuNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDinhLuongTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTP;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnDong;
    }
}
