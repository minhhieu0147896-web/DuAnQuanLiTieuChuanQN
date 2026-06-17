namespace DuAn.GUI.frmnhanvien
{
    partial class frmThemMonAn
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.btnTabThem = new System.Windows.Forms.Button();
            this.btnTabSua = new System.Windows.Forms.Button();
            this.btnTabXoa = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.txtChatXo = new System.Windows.Forms.TextBox();
            this.txtChatBeo = new System.Windows.Forms.TextBox();
            this.txtDam = new System.Windows.Forms.TextBox();
            this.lblChatXo = new System.Windows.Forms.Label();
            this.lblChatBeo = new System.Windows.Forms.Label();
            this.lblDam = new System.Windows.Forms.Label();
            this.lblDinhDuong = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cboLoaiMon = new System.Windows.Forms.ComboBox();
            this.lblLoaiMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.pnlNguyenLieu = new System.Windows.Forms.Panel();
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colStt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThucPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTyLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThemNL = new System.Windows.Forms.Button();
            this.pnlInputNL = new System.Windows.Forms.Panel();
            this.txtTyLe = new System.Windows.Forms.TextBox();
            this.lblTyLe = new System.Windows.Forms.Label();
            this.cboCheDo = new System.Windows.Forms.ComboBox();
            this.lblCheDoNL = new System.Windows.Forms.Label();
            this.cboThucPham = new System.Windows.Forms.ComboBox();
            this.lblThucPham = new System.Windows.Forms.Label();
            this.lblNguyenLieu = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.pnlThongTin.SuspendLayout();
            this.pnlNguyenLieu.SuspendLayout();
            this.pnlAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlInputNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlTitle.Size = new System.Drawing.Size(933, 54);
            this.pnlTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(10, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(923, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÊM MÓN ĂN MỚI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTab
            // 
            this.pnlTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlTab.Controls.Add(this.btnTabThem);
            this.pnlTab.Controls.Add(this.btnTabSua);
            this.pnlTab.Controls.Add(this.btnTabXoa);
            this.pnlTab.Controls.Add(this.txtTimKiem);
            this.pnlTab.Controls.Add(this.btnXoaMon);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTab.Location = new System.Drawing.Point(0, 54);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.pnlTab.Size = new System.Drawing.Size(933, 42);
            this.pnlTab.TabIndex = 3;
            // 
            // btnTabThem
            // 
            this.btnTabThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.btnTabThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabThem.FlatAppearance.BorderSize = 0;
            this.btnTabThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabThem.ForeColor = System.Drawing.Color.White;
            this.btnTabThem.Location = new System.Drawing.Point(10, 5);
            this.btnTabThem.Name = "btnTabThem";
            this.btnTabThem.Size = new System.Drawing.Size(100, 32);
            this.btnTabThem.TabIndex = 0;
            this.btnTabThem.Text = "Thêm";
            this.btnTabThem.UseVisualStyleBackColor = false;
            this.btnTabThem.Click += new System.EventHandler(this.btnTabThem_Click);
            // 
            // btnTabSua
            // 
            this.btnTabSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnTabSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabSua.FlatAppearance.BorderSize = 0;
            this.btnTabSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabSua.ForeColor = System.Drawing.Color.White;
            this.btnTabSua.Location = new System.Drawing.Point(115, 5);
            this.btnTabSua.Name = "btnTabSua";
            this.btnTabSua.Size = new System.Drawing.Size(100, 32);
            this.btnTabSua.TabIndex = 1;
            this.btnTabSua.Text = "Sửa";
            this.btnTabSua.UseVisualStyleBackColor = false;
            this.btnTabSua.Click += new System.EventHandler(this.btnTabSua_Click);
            // 
            // btnTabXoa
            // 
            this.btnTabXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnTabXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabXoa.FlatAppearance.BorderSize = 0;
            this.btnTabXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabXoa.ForeColor = System.Drawing.Color.White;
            this.btnTabXoa.Location = new System.Drawing.Point(220, 5);
            this.btnTabXoa.Name = "btnTabXoa";
            this.btnTabXoa.Size = new System.Drawing.Size(100, 32);
            this.btnTabXoa.TabIndex = 2;
            this.btnTabXoa.Text = "Xóa";
            this.btnTabXoa.UseVisualStyleBackColor = false;
            this.btnTabXoa.Click += new System.EventHandler(this.btnTabXoa_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(533, 8);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 27);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.Text = "🔍 Tìm món ăn...";
            this.txtTimKiem.Visible = false;
            this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
            this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnXoaMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnXoaMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaMon.FlatAppearance.BorderSize = 0;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMon.ForeColor = System.Drawing.Color.White;
            this.btnXoaMon.Location = new System.Drawing.Point(366, 366);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(200, 45);
            this.btnXoaMon.TabIndex = 5;
            this.btnXoaMon.Text = "XÓA MÓN ĂN";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            this.btnXoaMon.Visible = false;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlThongTin.Controls.Add(this.txtChatXo);
            this.pnlThongTin.Controls.Add(this.txtChatBeo);
            this.pnlThongTin.Controls.Add(this.txtDam);
            this.pnlThongTin.Controls.Add(this.lblChatXo);
            this.pnlThongTin.Controls.Add(this.lblChatBeo);
            this.pnlThongTin.Controls.Add(this.lblDam);
            this.pnlThongTin.Controls.Add(this.lblDinhDuong);
            this.pnlThongTin.Controls.Add(this.txtGhiChu);
            this.pnlThongTin.Controls.Add(this.lblGhiChu);
            this.pnlThongTin.Controls.Add(this.cboLoaiMon);
            this.pnlThongTin.Controls.Add(this.lblLoaiMon);
            this.pnlThongTin.Controls.Add(this.txtTenMon);
            this.pnlThongTin.Controls.Add(this.lblTenMon);
            this.pnlThongTin.Controls.Add(this.txtMaMon);
            this.pnlThongTin.Controls.Add(this.lblMaMon);
            this.pnlThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTin.Location = new System.Drawing.Point(0, 54);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlThongTin.Size = new System.Drawing.Size(933, 175);
            this.pnlThongTin.TabIndex = 1;
            // 
            // txtChatXo
            // 
            this.txtChatXo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChatXo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatXo.Location = new System.Drawing.Point(435, 117);
            this.txtChatXo.Name = "txtChatXo";
            this.txtChatXo.Size = new System.Drawing.Size(80, 27);
            this.txtChatXo.TabIndex = 14;
            this.txtChatXo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtChatBeo
            // 
            this.txtChatBeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChatBeo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatBeo.Location = new System.Drawing.Point(265, 117);
            this.txtChatBeo.Name = "txtChatBeo";
            this.txtChatBeo.Size = new System.Drawing.Size(80, 27);
            this.txtChatBeo.TabIndex = 13;
            this.txtChatBeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDam
            // 
            this.txtDam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDam.Location = new System.Drawing.Point(85, 117);
            this.txtDam.Name = "txtDam";
            this.txtDam.Size = new System.Drawing.Size(80, 27);
            this.txtDam.TabIndex = 12;
            this.txtDam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChatXo
            // 
            this.lblChatXo.AutoSize = true;
            this.lblChatXo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatXo.Location = new System.Drawing.Point(355, 120);
            this.lblChatXo.Name = "lblChatXo";
            this.lblChatXo.Size = new System.Drawing.Size(85, 20);
            this.lblChatXo.TabIndex = 11;
            this.lblChatXo.Text = "Chất xơ (g):";
            // 
            // lblChatBeo
            // 
            this.lblChatBeo.AutoSize = true;
            this.lblChatBeo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatBeo.Location = new System.Drawing.Point(175, 120);
            this.lblChatBeo.Name = "lblChatBeo";
            this.lblChatBeo.Size = new System.Drawing.Size(95, 20);
            this.lblChatBeo.TabIndex = 10;
            this.lblChatBeo.Text = "Chất béo (g):";
            // 
            // lblDam
            // 
            this.lblDam.AutoSize = true;
            this.lblDam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDam.Location = new System.Drawing.Point(15, 114);
            this.lblDam.Name = "lblDam";
            this.lblDam.Size = new System.Drawing.Size(67, 20);
            this.lblDam.TabIndex = 9;
            this.lblDam.Text = "Đạm (g):";
            // 
            // lblDinhDuong
            // 
            this.lblDinhDuong.AutoSize = true;
            this.lblDinhDuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinhDuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDinhDuong.Location = new System.Drawing.Point(15, 90);
            this.lblDinhDuong.Name = "lblDinhDuong";
            this.lblDinhDuong.Size = new System.Drawing.Size(248, 20);
            this.lblDinhDuong.TabIndex = 8;
            this.lblDinhDuong.Text = "Thông số dinh dưỡng (trên 100g):";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(340, 47);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(233, 27);
            this.txtGhiChu.TabIndex = 7;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(250, 50);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(61, 20);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // cboLoaiMon
            // 
            this.cboLoaiMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiMon.FormattingEnabled = true;
            this.cboLoaiMon.Items.AddRange(new object[] {
            "Mặn Chính",
            "Canh",
            "Rau",
            "Tráng Miệng",
            "Sữa"});
            this.cboLoaiMon.Location = new System.Drawing.Point(100, 47);
            this.cboLoaiMon.Name = "cboLoaiMon";
            this.cboLoaiMon.Size = new System.Drawing.Size(140, 28);
            this.cboLoaiMon.TabIndex = 5;
            // 
            // lblLoaiMon
            // 
            this.lblLoaiMon.AutoSize = true;
            this.lblLoaiMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiMon.Location = new System.Drawing.Point(15, 50);
            this.lblLoaiMon.Name = "lblLoaiMon";
            this.lblLoaiMon.Size = new System.Drawing.Size(94, 20);
            this.lblLoaiMon.TabIndex = 4;
            this.lblLoaiMon.Text = "Loại món (*):";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMon.Location = new System.Drawing.Point(340, 12);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(233, 27);
            this.txtTenMon.TabIndex = 3;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMon.Location = new System.Drawing.Point(250, 15);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(89, 20);
            this.lblTenMon.TabIndex = 2;
            this.lblTenMon.Text = "Tên món (*):";
            // 
            // txtMaMon
            // 
            this.txtMaMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMaMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMon.Location = new System.Drawing.Point(100, 12);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.ReadOnly = true;
            this.txtMaMon.Size = new System.Drawing.Size(120, 27);
            this.txtMaMon.TabIndex = 1;
            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaMon.Location = new System.Drawing.Point(15, 15);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(67, 20);
            this.lblMaMon.TabIndex = 0;
            this.lblMaMon.Text = "Mã món:";
            // 
            // pnlNguyenLieu
            // 
            this.pnlNguyenLieu.BackColor = System.Drawing.Color.White;
            this.pnlNguyenLieu.Controls.Add(this.pnlAction);
            this.pnlNguyenLieu.Controls.Add(this.btnXoaDong);
            this.pnlNguyenLieu.Controls.Add(this.dgvChiTiet);
            this.pnlNguyenLieu.Controls.Add(this.btnXoaMon);
            this.pnlNguyenLieu.Controls.Add(this.btnThemNL);
            this.pnlNguyenLieu.Controls.Add(this.pnlInputNL);
            this.pnlNguyenLieu.Controls.Add(this.lblNguyenLieu);
            this.pnlNguyenLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNguyenLieu.Location = new System.Drawing.Point(0, 229);
            this.pnlNguyenLieu.Name = "pnlNguyenLieu";
            this.pnlNguyenLieu.Padding = new System.Windows.Forms.Padding(10);
            this.pnlNguyenLieu.Size = new System.Drawing.Size(933, 361);
            this.pnlNguyenLieu.TabIndex = 2;
            // 
            // pnlAction
            // 
            this.pnlAction.Controls.Add(this.btnHuy);
            this.pnlAction.Controls.Add(this.btnLuu);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAction.Location = new System.Drawing.Point(10, 296);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(913, 55);
            this.pnlAction.TabIndex = 5;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnHuy.BackColor = System.Drawing.Color.LightCoral;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(202, 6);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(479, 6);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 40);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "LƯU";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaDong.BackColor = System.Drawing.Color.LightCoral;
            this.btnXoaDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDong.FlatAppearance.BorderSize = 0;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDong.ForeColor = System.Drawing.Color.Black;
            this.btnXoaDong.Location = new System.Drawing.Point(738, 266);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(187, 30);
            this.btnXoaDong.TabIndex = 4;
            this.btnXoaDong.Text = "🗑 Xóa dòng đã chọn";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTiet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStt,
            this.colThucPham,
            this.colCheDo,
            this.colTyLe});
            this.dgvChiTiet.EnableHeadersVisualStyles = false;
            this.dgvChiTiet.Location = new System.Drawing.Point(10, 95);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.RowTemplate.Height = 28;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(713, 200);
            this.dgvChiTiet.TabIndex = 3;
            // 
            // colStt
            // 
            this.colStt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStt.HeaderText = "Stt";
            this.colStt.MinimumWidth = 6;
            this.colStt.Name = "colStt";
            this.colStt.ReadOnly = true;
            this.colStt.Width = 40;
            // 
            // colThucPham
            // 
            this.colThucPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colThucPham.HeaderText = "Thực phẩm";
            this.colThucPham.MinimumWidth = 6;
            this.colThucPham.Name = "colThucPham";
            this.colThucPham.ReadOnly = true;
            this.colThucPham.Width = 250;
            // 
            // colCheDo
            // 
            this.colCheDo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCheDo.HeaderText = "Chế độ";
            this.colCheDo.MinimumWidth = 6;
            this.colCheDo.Name = "colCheDo";
            this.colCheDo.ReadOnly = true;
            this.colCheDo.Width = 120;
            // 
            // colTyLe
            // 
            this.colTyLe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTyLe.HeaderText = "Tỷ lệ";
            this.colTyLe.MinimumWidth = 6;
            this.colTyLe.Name = "colTyLe";
            this.colTyLe.ReadOnly = true;
            this.colTyLe.Width = 125;
            // 
            // btnThemNL
            // 
            this.btnThemNL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.btnThemNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNL.FlatAppearance.BorderSize = 0;
            this.btnThemNL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNL.ForeColor = System.Drawing.Color.White;
            this.btnThemNL.Location = new System.Drawing.Point(628, 8);
            this.btnThemNL.Name = "btnThemNL";
            this.btnThemNL.Size = new System.Drawing.Size(75, 28);
            this.btnThemNL.TabIndex = 2;
            this.btnThemNL.Text = "+ Thêm";
            this.btnThemNL.UseVisualStyleBackColor = false;
            this.btnThemNL.Click += new System.EventHandler(this.btnThemNL_Click);
            // 
            // pnlInputNL
            // 
            this.pnlInputNL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInputNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlInputNL.Controls.Add(this.txtTyLe);
            this.pnlInputNL.Controls.Add(this.lblTyLe);
            this.pnlInputNL.Controls.Add(this.cboCheDo);
            this.pnlInputNL.Controls.Add(this.lblCheDoNL);
            this.pnlInputNL.Controls.Add(this.cboThucPham);
            this.pnlInputNL.Controls.Add(this.lblThucPham);
            this.pnlInputNL.Location = new System.Drawing.Point(10, 40);
            this.pnlInputNL.Name = "pnlInputNL";
            this.pnlInputNL.Size = new System.Drawing.Size(874, 45);
            this.pnlInputNL.TabIndex = 1;
            // 
            // txtTyLe
            // 
            this.txtTyLe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTyLe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTyLe.Location = new System.Drawing.Point(623, 13);
            this.txtTyLe.Name = "txtTyLe";
            this.txtTyLe.Size = new System.Drawing.Size(70, 27);
            this.txtTyLe.TabIndex = 5;
            this.txtTyLe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTyLe
            // 
            this.lblTyLe.AutoSize = true;
            this.lblTyLe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTyLe.Location = new System.Drawing.Point(574, 16);
            this.lblTyLe.Name = "lblTyLe";
            this.lblTyLe.Size = new System.Drawing.Size(43, 20);
            this.lblTyLe.TabIndex = 4;
            this.lblTyLe.Text = "Tỷ lệ:";
            // 
            // cboCheDo
            // 
            this.cboCheDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCheDo.FormattingEnabled = true;
            this.cboCheDo.Location = new System.Drawing.Point(410, 13);
            this.cboCheDo.Name = "cboCheDo";
            this.cboCheDo.Size = new System.Drawing.Size(140, 28);
            this.cboCheDo.TabIndex = 3;
            // 
            // lblCheDoNL
            // 
            this.lblCheDoNL.AutoSize = true;
            this.lblCheDoNL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheDoNL.Location = new System.Drawing.Point(345, 13);
            this.lblCheDoNL.Name = "lblCheDoNL";
            this.lblCheDoNL.Size = new System.Drawing.Size(59, 20);
            this.lblCheDoNL.TabIndex = 2;
            this.lblCheDoNL.Text = "Chế độ:";
            // 
            // cboThucPham
            // 
            this.cboThucPham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboThucPham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboThucPham.DropDownWidth = 350;
            this.cboThucPham.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThucPham.FormattingEnabled = true;
            this.cboThucPham.Location = new System.Drawing.Point(102, 10);
            this.cboThucPham.MaxDropDownItems = 12;
            this.cboThucPham.Name = "cboThucPham";
            this.cboThucPham.Size = new System.Drawing.Size(220, 28);
            this.cboThucPham.TabIndex = 1;
            // 
            // lblThucPham
            // 
            this.lblThucPham.AutoSize = true;
            this.lblThucPham.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThucPham.Location = new System.Drawing.Point(10, 13);
            this.lblThucPham.Name = "lblThucPham";
            this.lblThucPham.Size = new System.Drawing.Size(86, 20);
            this.lblThucPham.TabIndex = 0;
            this.lblThucPham.Text = "Thực phẩm:";
            // 
            // lblNguyenLieu
            // 
            this.lblNguyenLieu.AutoSize = true;
            this.lblNguyenLieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguyenLieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNguyenLieu.Location = new System.Drawing.Point(10, 8);
            this.lblNguyenLieu.Name = "lblNguyenLieu";
            this.lblNguyenLieu.Size = new System.Drawing.Size(234, 28);
            this.lblNguyenLieu.TabIndex = 0;
            this.lblNguyenLieu.Text = "NGUYÊN LIỆU MÓN ĂN";
            // 
            // frmThemMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(933, 590);
            this.Controls.Add(this.pnlNguyenLieu);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThemMonAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmThemMonAn_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.pnlTab.PerformLayout();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.pnlNguyenLieu.ResumeLayout(false);
            this.pnlNguyenLieu.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlInputNL.ResumeLayout(false);
            this.pnlInputNL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblLoaiMon;
        private System.Windows.Forms.ComboBox cboLoaiMon;
        private System.Windows.Forms.Label lblDinhDuong;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtChatXo;
        private System.Windows.Forms.TextBox txtChatBeo;
        private System.Windows.Forms.TextBox txtDam;
        private System.Windows.Forms.Label lblChatXo;
        private System.Windows.Forms.Label lblChatBeo;
        private System.Windows.Forms.Label lblDam;
        private System.Windows.Forms.Panel pnlNguyenLieu;
        private System.Windows.Forms.Panel pnlInputNL;
        private System.Windows.Forms.Label lblNguyenLieu;
        private System.Windows.Forms.ComboBox cboThucPham;
        private System.Windows.Forms.Label lblThucPham;
        private System.Windows.Forms.ComboBox cboCheDo;
        private System.Windows.Forms.Label lblCheDoNL;
        private System.Windows.Forms.TextBox txtTyLe;
        private System.Windows.Forms.Label lblTyLe;
        private System.Windows.Forms.Button btnThemNL;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThucPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTyLe;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Button btnTabThem;
        private System.Windows.Forms.Button btnTabSua;
        private System.Windows.Forms.Button btnTabXoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnXoaMon;
    }
}