namespace DuAn.GUI.frmfornhvhc
{
    partial class frmbqs
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbqs));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pntitle = new System.Windows.Forms.Panel();
            this.lblbqs = new System.Windows.Forms.Label();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.pnlchilfilter = new System.Windows.Forms.Panel();
            this.lbltim = new System.Windows.Forms.Label();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.lblngay = new System.Windows.Forms.Label();
            this.cbodonvi = new System.Windows.Forms.ComboBox();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.dtpngay = new System.Windows.Forms.DateTimePicker();
            this.cbobuoi = new System.Windows.Forms.ComboBox();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.pnbang = new System.Windows.Forms.Panel();
            this.pnlpaging = new System.Windows.Forms.Panel();
            this.pnltrang = new System.Windows.Forms.Panel();
            this.btnsau = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.lbltrang = new System.Windows.Forms.Label();
            this.dgvbqs = new System.Windows.Forms.DataGridView();
            this.colmaqn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlptrangthai = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblCheDo2 = new System.Windows.Forms.Label();
            this.pnlbqs = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblTongQuanSo = new System.Windows.Forms.Label();
            this.pnllsbqs = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblCheDo1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pntitle.SuspendLayout();
            this.pnlfilter.SuspendLayout();
            this.pnlchilfilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnbang.SuspendLayout();
            this.pnlpaging.SuspendLayout();
            this.pnltrang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbqs)).BeginInit();
            this.tlptrangthai.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.pnlbqs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.pnllsbqs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // pntitle
            // 
            this.pntitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pntitle.Controls.Add(this.lblbqs);
            this.pntitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pntitle.Location = new System.Drawing.Point(0, 0);
            this.pntitle.Name = "pntitle";
            this.pntitle.Size = new System.Drawing.Size(1200, 79);
            this.pntitle.TabIndex = 0;
            this.pntitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblbqs
            // 
            this.lblbqs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblbqs.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbqs.ForeColor = System.Drawing.Color.White;
            this.lblbqs.Location = new System.Drawing.Point(491, 18);
            this.lblbqs.Name = "lblbqs";
            this.lblbqs.Size = new System.Drawing.Size(255, 45);
            this.lblbqs.TabIndex = 0;
            this.lblbqs.Text = "BÁO QUÂN SỐ";
            // 
            // pnlfilter
            // 
            this.pnlfilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlfilter.Controls.Add(this.pnlchilfilter);
            this.pnlfilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlfilter.Location = new System.Drawing.Point(0, 79);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(1200, 155);
            this.pnlfilter.TabIndex = 1;
            this.pnlfilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlfilter_Paint);
            // 
            // pnlchilfilter
            // 
            this.pnlchilfilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlchilfilter.AutoSize = true;
            this.pnlchilfilter.BackColor = System.Drawing.Color.White;
            this.pnlchilfilter.Controls.Add(this.lbltim);
            this.pnlchilfilter.Controls.Add(this.txttimkiem);
            this.pnlchilfilter.Controls.Add(this.pictureBox1);
            this.pnlchilfilter.Controls.Add(this.btnluu);
            this.pnlchilfilter.Controls.Add(this.btnhienthi);
            this.pnlchilfilter.Controls.Add(this.lblngay);
            this.pnlchilfilter.Controls.Add(this.cbodonvi);
            this.pnlchilfilter.Controls.Add(this.lbldonvi);
            this.pnlchilfilter.Controls.Add(this.dtpngay);
            this.pnlchilfilter.Controls.Add(this.cbobuoi);
            this.pnlchilfilter.Controls.Add(this.lblbuoi);
            this.pnlchilfilter.Location = new System.Drawing.Point(130, 18);
            this.pnlchilfilter.Name = "pnlchilfilter";
            this.pnlchilfilter.Size = new System.Drawing.Size(956, 100);
            this.pnlchilfilter.TabIndex = 0;
            // 
            // lbltim
            // 
            this.lbltim.AutoSize = true;
            this.lbltim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltim.ForeColor = System.Drawing.Color.Black;
            this.lbltim.Location = new System.Drawing.Point(260, 66);
            this.lbltim.Name = "lbltim";
            this.lbltim.Size = new System.Drawing.Size(71, 20);
            this.lbltim.TabIndex = 10;
            this.lbltim.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(349, 63);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(269, 26);
            this.txttimkiem.TabIndex = 9;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(820, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(133)))));
            this.btnluu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnluu.ForeColor = System.Drawing.Color.White;
            this.btnluu.Location = new System.Drawing.Point(809, 22);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(99, 53);
            this.btnluu.TabIndex = 7;
            this.btnluu.Text = "    Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click_1);
            // 
            // btnhienthi
            // 
            this.btnhienthi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(125)))), ((int)(((byte)(219)))));
            this.btnhienthi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhienthi.ForeColor = System.Drawing.Color.White;
            this.btnhienthi.Location = new System.Drawing.Point(663, 22);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(99, 53);
            this.btnhienthi.TabIndex = 6;
            this.btnhienthi.Text = "Hiển thị";
            this.btnhienthi.UseVisualStyleBackColor = false;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // lblngay
            // 
            this.lblngay.AutoSize = true;
            this.lblngay.Location = new System.Drawing.Point(271, 26);
            this.lblngay.Name = "lblngay";
            this.lblngay.Size = new System.Drawing.Size(45, 20);
            this.lblngay.TabIndex = 5;
            this.lblngay.Text = "Ngày";
            // 
            // cbodonvi
            // 
            this.cbodonvi.FormattingEnabled = true;
            this.cbodonvi.Location = new System.Drawing.Point(99, 66);
            this.cbodonvi.Name = "cbodonvi";
            this.cbodonvi.Size = new System.Drawing.Size(146, 28);
            this.cbodonvi.TabIndex = 4;
            this.cbodonvi.SelectedIndexChanged += new System.EventHandler(this.cbodonvi_SelectedIndexChanged);
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(31, 69);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(53, 20);
            this.lbldonvi.TabIndex = 3;
            this.lbldonvi.Text = "Đơn vị";
            // 
            // dtpngay
            // 
            this.dtpngay.Location = new System.Drawing.Point(346, 23);
            this.dtpngay.Name = "dtpngay";
            this.dtpngay.Size = new System.Drawing.Size(272, 26);
            this.dtpngay.TabIndex = 2;
            this.dtpngay.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // cbobuoi
            // 
            this.cbobuoi.FormattingEnabled = true;
            this.cbobuoi.Location = new System.Drawing.Point(99, 22);
            this.cbobuoi.Name = "cbobuoi";
            this.cbobuoi.Size = new System.Drawing.Size(146, 28);
            this.cbobuoi.TabIndex = 1;
            this.cbobuoi.SelectedIndexChanged += new System.EventHandler(this.cbobuoi_SelectedIndexChanged);
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(31, 26);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(41, 20);
            this.lblbuoi.TabIndex = 0;
            this.lblbuoi.Text = "Buổi";
            // 
            // pnbang
            // 
            this.pnbang.Controls.Add(this.pnlpaging);
            this.pnbang.Controls.Add(this.dgvbqs);
            this.pnbang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnbang.Location = new System.Drawing.Point(0, 234);
            this.pnbang.Name = "pnbang";
            this.pnbang.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnbang.Size = new System.Drawing.Size(1200, 471);
            this.pnbang.TabIndex = 2;
            this.pnbang.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pnlpaging
            // 
            this.pnlpaging.BackColor = System.Drawing.Color.White;
            this.pnlpaging.Controls.Add(this.pnltrang);
            this.pnlpaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlpaging.Location = new System.Drawing.Point(10, 435);
            this.pnlpaging.Name = "pnlpaging";
            this.pnlpaging.Size = new System.Drawing.Size(1190, 36);
            this.pnlpaging.TabIndex = 4;
            // 
            // pnltrang
            // 
            this.pnltrang.Controls.Add(this.btnsau);
            this.pnltrang.Controls.Add(this.btnnext);
            this.pnltrang.Controls.Add(this.lbltrang);
            this.pnltrang.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnltrang.Location = new System.Drawing.Point(951, 0);
            this.pnltrang.Name = "pnltrang";
            this.pnltrang.Size = new System.Drawing.Size(239, 36);
            this.pnltrang.TabIndex = 3;
            // 
            // btnsau
            // 
            this.btnsau.Location = new System.Drawing.Point(3, 3);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(48, 31);
            this.btnsau.TabIndex = 0;
            this.btnsau.Text = "<<";
            this.btnsau.UseVisualStyleBackColor = true;
            this.btnsau.Click += new System.EventHandler(this.btnsau_Click);
            // 
            // btnnext
            // 
            this.btnnext.Location = new System.Drawing.Point(191, 3);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(45, 31);
            this.btnnext.TabIndex = 1;
            this.btnnext.Text = ">>";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // lbltrang
            // 
            this.lbltrang.AutoSize = true;
            this.lbltrang.Location = new System.Drawing.Point(79, 5);
            this.lbltrang.Name = "lbltrang";
            this.lbltrang.Size = new System.Drawing.Size(46, 20);
            this.lbltrang.TabIndex = 2;
            this.lbltrang.Text = "trang";
            this.lbltrang.Click += new System.EventHandler(this.lbltrang_Click);
            // 
            // dgvbqs
            // 
            this.dgvbqs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbqs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbqs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbqs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbqs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colmaqn,
            this.colten,
            this.colchedo,
            this.colchedoid,
            this.colKan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbqs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvbqs.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvbqs.EnableHeadersVisualStyles = false;
            this.dgvbqs.Location = new System.Drawing.Point(10, 0);
            this.dgvbqs.Name = "dgvbqs";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbqs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvbqs.RowHeadersWidth = 62;
            this.dgvbqs.RowTemplate.Height = 30;
            this.dgvbqs.Size = new System.Drawing.Size(1190, 435);
            this.dgvbqs.TabIndex = 0;
            this.dgvbqs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbqs_CellClick);
            this.dgvbqs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvbqs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbqs_CellValueChanged);
            // 
            // colmaqn
            // 
            this.colmaqn.DataPropertyName = "quannhan_id";
            this.colmaqn.HeaderText = "Mã Quân nhân ";
            this.colmaqn.MinimumWidth = 8;
            this.colmaqn.Name = "colmaqn";
            this.colmaqn.ReadOnly = true;
            // 
            // colten
            // 
            this.colten.DataPropertyName = "quannhan_hoten";
            this.colten.HeaderText = "Tên quân nhân";
            this.colten.MinimumWidth = 8;
            this.colten.Name = "colten";
            this.colten.ReadOnly = true;
            // 
            // colchedo
            // 
            this.colchedo.DataPropertyName = "chedo_ten";
            this.colchedo.HeaderText = "Chế độ";
            this.colchedo.MinimumWidth = 8;
            this.colchedo.Name = "colchedo";
            this.colchedo.ReadOnly = true;
            // 
            // colchedoid
            // 
            this.colchedoid.DataPropertyName = "chedo_id";
            this.colchedoid.HeaderText = "Chế độ ID";
            this.colchedoid.MinimumWidth = 8;
            this.colchedoid.Name = "colchedoid";
            this.colchedoid.ReadOnly = true;
            this.colchedoid.Visible = false;
            // 
            // colKan
            // 
            this.colKan.HeaderText = "Không ăn";
            this.colKan.MinimumWidth = 8;
            this.colKan.Name = "colKan";
            // 
            // tlptrangthai
            // 
            this.tlptrangthai.ColumnCount = 3;
            this.tlptrangthai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlptrangthai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlptrangthai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlptrangthai.Controls.Add(this.panel2, 2, 0);
            this.tlptrangthai.Controls.Add(this.pnlbqs, 0, 0);
            this.tlptrangthai.Controls.Add(this.pnllsbqs, 1, 0);
            this.tlptrangthai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlptrangthai.Location = new System.Drawing.Point(0, 705);
            this.tlptrangthai.Name = "tlptrangthai";
            this.tlptrangthai.Padding = new System.Windows.Forms.Padding(20);
            this.tlptrangthai.RowCount = 1;
            this.tlptrangthai.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlptrangthai.Size = new System.Drawing.Size(1200, 191);
            this.tlptrangthai.TabIndex = 4;
            this.tlptrangthai.Paint += new System.Windows.Forms.PaintEventHandler(this.tlptrangthai_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Controls.Add(this.lblCheDo2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.panel2.Location = new System.Drawing.Point(784, 30);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(386, 131);
            this.panel2.TabIndex = 4;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(155, 8);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(67, 66);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 4;
            this.pictureBox8.TabStop = false;
            // 
            // lblCheDo2
            // 
            this.lblCheDo2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheDo2.AutoSize = true;
            this.lblCheDo2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheDo2.ForeColor = System.Drawing.Color.Black;
            this.lblCheDo2.Location = new System.Drawing.Point(122, 72);
            this.lblCheDo2.Name = "lblCheDo2";
            this.lblCheDo2.Size = new System.Drawing.Size(150, 32);
            this.lblCheDo2.TabIndex = 3;
            this.lblCheDo2.Text = "Quân số ăn ";
            this.lblCheDo2.Click += new System.EventHandler(this.lblCheDo2_Click);
            // 
            // pnlbqs
            // 
            this.pnlbqs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnlbqs.Controls.Add(this.pictureBox6);
            this.pnlbqs.Controls.Add(this.lblTongQuanSo);
            this.pnlbqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlbqs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnlbqs.Location = new System.Drawing.Point(30, 30);
            this.pnlbqs.Margin = new System.Windows.Forms.Padding(10);
            this.pnlbqs.Name = "pnlbqs";
            this.pnlbqs.Padding = new System.Windows.Forms.Padding(5);
            this.pnlbqs.Size = new System.Drawing.Size(328, 131);
            this.pnlbqs.TabIndex = 0;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(135, 15);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(60, 54);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // lblTongQuanSo
            // 
            this.lblTongQuanSo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongQuanSo.AutoSize = true;
            this.lblTongQuanSo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongQuanSo.ForeColor = System.Drawing.Color.Black;
            this.lblTongQuanSo.Location = new System.Drawing.Point(58, 72);
            this.lblTongQuanSo.Name = "lblTongQuanSo";
            this.lblTongQuanSo.Size = new System.Drawing.Size(171, 32);
            this.lblTongQuanSo.TabIndex = 1;
            this.lblTongQuanSo.Text = "Tổng quân số";
            // 
            // pnllsbqs
            // 
            this.pnllsbqs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.pnllsbqs.Controls.Add(this.pictureBox7);
            this.pnllsbqs.Controls.Add(this.lblCheDo1);
            this.pnllsbqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnllsbqs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnllsbqs.Location = new System.Drawing.Point(378, 30);
            this.pnllsbqs.Margin = new System.Windows.Forms.Padding(10);
            this.pnllsbqs.Name = "pnllsbqs";
            this.pnllsbqs.Padding = new System.Windows.Forms.Padding(5);
            this.pnllsbqs.Size = new System.Drawing.Size(386, 131);
            this.pnllsbqs.TabIndex = 4;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(164, 8);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(64, 61);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 3;
            this.pictureBox7.TabStop = false;
            // 
            // lblCheDo1
            // 
            this.lblCheDo1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheDo1.AutoSize = true;
            this.lblCheDo1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheDo1.ForeColor = System.Drawing.Color.Black;
            this.lblCheDo1.Location = new System.Drawing.Point(92, 72);
            this.lblCheDo1.Name = "lblCheDo1";
            this.lblCheDo1.Size = new System.Drawing.Size(150, 32);
            this.lblCheDo1.TabIndex = 2;
            this.lblCheDo1.Text = "Quân số ăn ";
            this.lblCheDo1.Click += new System.EventHandler(this.lblCheDo1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmbqs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 896);
            this.Controls.Add(this.tlptrangthai);
            this.Controls.Add(this.pnbang);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.pntitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "frmbqs";
            this.Text = "Báo quân số";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmbqs_Load);
            this.pntitle.ResumeLayout(false);
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.pnlchilfilter.ResumeLayout(false);
            this.pnlchilfilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnbang.ResumeLayout(false);
            this.pnlpaging.ResumeLayout(false);
            this.pnltrang.ResumeLayout(false);
            this.pnltrang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbqs)).EndInit();
            this.tlptrangthai.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.pnlbqs.ResumeLayout(false);
            this.pnlbqs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.pnllsbqs.ResumeLayout(false);
            this.pnllsbqs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pntitle;
        private System.Windows.Forms.Label lblbqs;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.Panel pnlchilfilter;
        private System.Windows.Forms.DateTimePicker dtpngay;
        private System.Windows.Forms.ComboBox cbobuoi;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.ComboBox cbodonvi;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnhienthi;
        private System.Windows.Forms.Label lblngay;
        private System.Windows.Forms.Panel pnbang;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlpaging;
        private System.Windows.Forms.Panel pnltrang;
        private System.Windows.Forms.Button btnsau;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Label lbltrang;
        private System.Windows.Forms.TableLayoutPanel tlptrangthai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblCheDo2;
        private System.Windows.Forms.Panel pnlbqs;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblTongQuanSo;
        private System.Windows.Forms.Panel pnllsbqs;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblCheDo1;
        private System.Windows.Forms.DataGridView dgvbqs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmaqn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colten;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedoid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colKan;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbltim;
    }
}