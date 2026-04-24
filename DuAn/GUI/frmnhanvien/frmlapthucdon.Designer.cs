namespace frmnhanvien
{
    partial class frmlapthucdon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlapthucdon));
            this.pntitle = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbltieude = new System.Windows.Forms.Label();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.pnlchilfilter = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.lblngay = new System.Windows.Forms.Label();
            this.cbocd = new System.Windows.Forms.ComboBox();
            this.lblchedo = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.cboBuoi = new System.Windows.Forms.ComboBox();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvThucDon = new System.Windows.Forms.DataGridView();
            this.pnthemmon = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnThemVaoThucDon = new System.Windows.Forms.Button();
            this.cboDanhSachMon = new System.Windows.Forms.ComboBox();
            this.lbldanhsachan = new System.Windows.Forms.Label();
            this.cboLoaiMon = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblloaimon = new System.Windows.Forms.Label();
            this.btnBo = new System.Windows.Forms.Button();
            this.pntitle.SuspendLayout();
            this.pnlfilter.SuspendLayout();
            this.pnlchilfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            this.pnthemmon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pntitle
            // 
            this.pntitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pntitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pntitle.Controls.Add(this.btnExit);
            this.pntitle.Controls.Add(this.lbltieude);
            this.pntitle.Location = new System.Drawing.Point(0, 0);
            this.pntitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pntitle.Name = "pntitle";
            this.pntitle.Size = new System.Drawing.Size(1067, 64);
            this.pntitle.TabIndex = 0;
            this.pntitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pntitle_Paint);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(987, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 64);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbltieude
            // 
            this.lbltieude.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltieude.AutoSize = true;
            this.lbltieude.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.Color.White;
            this.lbltieude.Location = new System.Drawing.Point(437, 14);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(218, 37);
            this.lbltieude.TabIndex = 1;
            this.lbltieude.Text = "LẬP THỰC ĐƠN";
            this.lbltieude.Click += new System.EventHandler(this.lbltieude_Click);
            // 
            // pnlfilter
            // 
            this.pnlfilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlfilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlfilter.Controls.Add(this.btnBo);
            this.pnlfilter.Controls.Add(this.pnlchilfilter);
            this.pnlfilter.Location = new System.Drawing.Point(0, 64);
            this.pnlfilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(1067, 111);
            this.pnlfilter.TabIndex = 2;
            this.pnlfilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlfilter_Paint);
            // 
            // pnlchilfilter
            // 
            this.pnlchilfilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlchilfilter.AutoSize = true;
            this.pnlchilfilter.BackColor = System.Drawing.Color.White;
            this.pnlchilfilter.Controls.Add(this.pictureBox1);
            this.pnlchilfilter.Controls.Add(this.btnluu);
            this.pnlchilfilter.Controls.Add(this.btnhienthi);
            this.pnlchilfilter.Controls.Add(this.lblngay);
            this.pnlchilfilter.Controls.Add(this.cbocd);
            this.pnlchilfilter.Controls.Add(this.lblchedo);
            this.pnlchilfilter.Controls.Add(this.dtpNgay);
            this.pnlchilfilter.Controls.Add(this.cboBuoi);
            this.pnlchilfilter.Controls.Add(this.lblbuoi);
            this.pnlchilfilter.Location = new System.Drawing.Point(114, 14);
            this.pnlchilfilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlchilfilter.Name = "pnlchilfilter";
            this.pnlchilfilter.Size = new System.Drawing.Size(828, 80);
            this.pnlchilfilter.TabIndex = 0;
            this.pnlchilfilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlchilfilter_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(718, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnluu
            // 
            this.btnluu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnluu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.btnluu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnluu.ForeColor = System.Drawing.Color.White;
            this.btnluu.Location = new System.Drawing.Point(708, 18);
            this.btnluu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(88, 42);
            this.btnluu.TabIndex = 7;
            this.btnluu.Text = "    Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnhienthi
            // 
            this.btnhienthi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnhienthi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(219)))));
            this.btnhienthi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhienthi.ForeColor = System.Drawing.Color.White;
            this.btnhienthi.Location = new System.Drawing.Point(594, 18);
            this.btnhienthi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(88, 42);
            this.btnhienthi.TabIndex = 6;
            this.btnhienthi.Text = "Hiển thị";
            this.btnhienthi.UseVisualStyleBackColor = false;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // lblngay
            // 
            this.lblngay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblngay.AutoSize = true;
            this.lblngay.Location = new System.Drawing.Point(230, 21);
            this.lblngay.Name = "lblngay";
            this.lblngay.Size = new System.Drawing.Size(40, 16);
            this.lblngay.TabIndex = 5;
            this.lblngay.Text = "Ngày";
            this.lblngay.Click += new System.EventHandler(this.lblngay_Click);
            // 
            // cbocd
            // 
            this.cbocd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbocd.FormattingEnabled = true;
            this.cbocd.Location = new System.Drawing.Point(77, 53);
            this.cbocd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbocd.Name = "cbocd";
            this.cbocd.Size = new System.Drawing.Size(116, 24);
            this.cbocd.TabIndex = 4;
            this.cbocd.SelectedIndexChanged += new System.EventHandler(this.cbocd_SelectedIndexChanged);
            // 
            // lblchedo
            // 
            this.lblchedo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(17, 55);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(50, 16);
            this.lblchedo.TabIndex = 3;
            this.lblchedo.Text = "Chế độ";
            this.lblchedo.Click += new System.EventHandler(this.lblchedo_Click);
            // 
            // dtpNgay
            // 
            this.dtpNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpNgay.CalendarMonthBackground = System.Drawing.SystemColors.HighlightText;
            this.dtpNgay.Location = new System.Drawing.Point(297, 18);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(242, 22);
            this.dtpNgay.TabIndex = 2;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // cboBuoi
            // 
            this.cboBuoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboBuoi.FormattingEnabled = true;
            this.cboBuoi.Location = new System.Drawing.Point(77, 18);
            this.cboBuoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboBuoi.Name = "cboBuoi";
            this.cboBuoi.Size = new System.Drawing.Size(116, 24);
            this.cboBuoi.TabIndex = 1;
            this.cboBuoi.SelectedIndexChanged += new System.EventHandler(this.cboBuoi_SelectedIndexChanged);
            // 
            // lblbuoi
            // 
            this.lblbuoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(17, 21);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(34, 16);
            this.lblbuoi.TabIndex = 0;
            this.lblbuoi.Text = "Buổi";
            this.lblbuoi.Click += new System.EventHandler(this.lblbuoi_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(0, 516);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 44);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(753, 0);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 44);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.LightGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(791, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(276, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "  Lưu thực đơn tuần";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.Controls.Add(this.dgvThucDon);
            this.panel3.Controls.Add(this.pnthemmon);
            this.panel3.Location = new System.Drawing.Point(0, 175);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1067, 341);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDon.Location = new System.Drawing.Point(336, 0);
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.RowHeadersWidth = 51;
            this.dgvThucDon.RowTemplate.Height = 24;
            this.dgvThucDon.Size = new System.Drawing.Size(731, 341);
            this.dgvThucDon.TabIndex = 3;
            this.dgvThucDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThucDon_CellContentClick);
            // 
            // pnthemmon
            // 
            this.pnthemmon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnthemmon.Controls.Add(this.pictureBox3);
            this.pnthemmon.Controls.Add(this.btnThemVaoThucDon);
            this.pnthemmon.Controls.Add(this.cboDanhSachMon);
            this.pnthemmon.Controls.Add(this.lbldanhsachan);
            this.pnthemmon.Controls.Add(this.cboLoaiMon);
            this.pnthemmon.Controls.Add(this.panel1);
            this.pnthemmon.Controls.Add(this.lblloaimon);
            this.pnthemmon.Location = new System.Drawing.Point(0, 0);
            this.pnthemmon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnthemmon.Name = "pnthemmon";
            this.pnthemmon.Size = new System.Drawing.Size(336, 341);
            this.pnthemmon.TabIndex = 2;
            this.pnthemmon.Paint += new System.Windows.Forms.PaintEventHandler(this.pnthemmon_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BackColor = System.Drawing.Color.LightPink;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(30, 282);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnThemVaoThucDon
            // 
            this.btnThemVaoThucDon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemVaoThucDon.BackColor = System.Drawing.Color.DeepPink;
            this.btnThemVaoThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoThucDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVaoThucDon.ForeColor = System.Drawing.Color.White;
            this.btnThemVaoThucDon.Location = new System.Drawing.Point(17, 272);
            this.btnThemVaoThucDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemVaoThucDon.Name = "btnThemVaoThucDon";
            this.btnThemVaoThucDon.Size = new System.Drawing.Size(269, 46);
            this.btnThemVaoThucDon.TabIndex = 9;
            this.btnThemVaoThucDon.Text = "    Thêm vào thực đơn";
            this.btnThemVaoThucDon.UseVisualStyleBackColor = false;
            this.btnThemVaoThucDon.Click += new System.EventHandler(this.btnThemVaoThucDon_Click);
            // 
            // cboDanhSachMon
            // 
            this.cboDanhSachMon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboDanhSachMon.FormattingEnabled = true;
            this.cboDanhSachMon.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cboDanhSachMon.Location = new System.Drawing.Point(17, 206);
            this.cboDanhSachMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDanhSachMon.Name = "cboDanhSachMon";
            this.cboDanhSachMon.Size = new System.Drawing.Size(300, 24);
            this.cboDanhSachMon.TabIndex = 5;
            this.cboDanhSachMon.SelectedIndexChanged += new System.EventHandler(this.cboDanhSachMon_SelectedIndexChanged);
            // 
            // lbldanhsachan
            // 
            this.lbldanhsachan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldanhsachan.AutoSize = true;
            this.lbldanhsachan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldanhsachan.Location = new System.Drawing.Point(12, 173);
            this.lbldanhsachan.Name = "lbldanhsachan";
            this.lbldanhsachan.Size = new System.Drawing.Size(156, 23);
            this.lbldanhsachan.TabIndex = 4;
            this.lbldanhsachan.Text = "Danh sách món ăn";
            this.lbldanhsachan.Click += new System.EventHandler(this.lbldanhsachan_Click);
            // 
            // cboLoaiMon
            // 
            this.cboLoaiMon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboLoaiMon.FormattingEnabled = true;
            this.cboLoaiMon.Location = new System.Drawing.Point(17, 106);
            this.cboLoaiMon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLoaiMon.Name = "cboLoaiMon";
            this.cboLoaiMon.Size = new System.Drawing.Size(300, 24);
            this.cboLoaiMon.TabIndex = 3;
            this.cboLoaiMon.SelectedIndexChanged += new System.EventHandler(this.cboLoaiMon_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 44);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 8);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn món ăn";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblloaimon
            // 
            this.lblloaimon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblloaimon.AutoSize = true;
            this.lblloaimon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloaimon.Location = new System.Drawing.Point(12, 71);
            this.lblloaimon.Name = "lblloaimon";
            this.lblloaimon.Size = new System.Drawing.Size(84, 23);
            this.lblloaimon.TabIndex = 1;
            this.lblloaimon.Text = "Loại món";
            this.lblloaimon.Click += new System.EventHandler(this.lblloaimon_Click);
            // 
            // btnBo
            // 
            this.btnBo.BackColor = System.Drawing.Color.Yellow;
            this.btnBo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBo.Location = new System.Drawing.Point(940, 14);
            this.btnBo.Name = "btnBo";
            this.btnBo.Size = new System.Drawing.Size(104, 80);
            this.btnBo.TabIndex = 1;
            this.btnBo.Text = "Xóa món";
            this.btnBo.UseVisualStyleBackColor = false;
            this.btnBo.Click += new System.EventHandler(this.btnBo_Click);
            // 
            // frmlapthucdon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 560);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.pntitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1067, 560);
            this.Name = "frmlapthucdon";
            this.Text = "frmlapthucdon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmlapthucdon_FormClosing);
            this.pntitle.ResumeLayout(false);
            this.pntitle.PerformLayout();
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.pnlchilfilter.ResumeLayout(false);
            this.pnlchilfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
            this.pnthemmon.ResumeLayout(false);
            this.pnthemmon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pntitle;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.Panel pnlchilfilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnhienthi;
        private System.Windows.Forms.Label lblngay;
        private System.Windows.Forms.ComboBox cbocd;
        private System.Windows.Forms.Label lblchedo;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.ComboBox cboBuoi;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnthemmon;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnThemVaoThucDon;
        private System.Windows.Forms.ComboBox cboDanhSachMon;
        private System.Windows.Forms.Label lbldanhsachan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblloaimon;
        private System.Windows.Forms.ComboBox cboLoaiMon;
        private System.Windows.Forms.DataGridView dgvThucDon;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBo;
    }
}