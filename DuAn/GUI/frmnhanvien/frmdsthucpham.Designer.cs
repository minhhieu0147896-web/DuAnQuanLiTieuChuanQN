namespace frmnhanvien
{
    partial class frmdsthucpham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdsthucpham));
            this.lbllscc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pntieude = new System.Windows.Forms.Panel();
            this.btnthoat = new System.Windows.Forms.Button();
            this.lbltieude = new System.Windows.Forms.Label();
            this.pnlluachon = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtkcal = new System.Windows.Forms.TextBox();
            this.txtdonvi = new System.Windows.Forms.TextBox();
            this.txtgia = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.lblkcal = new System.Windows.Forms.Label();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.lblgia = new System.Windows.Forms.Label();
            this.lblten = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btntracuu = new System.Windows.Forms.Button();
            this.pndata = new System.Windows.Forms.Panel();
            this.dgvdstp = new System.Windows.Forms.DataGridView();
            this.coltpid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colthucpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldonvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colkcal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pntieude.SuspendLayout();
            this.pnlluachon.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pndata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdstp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // lbllscc
            // 
            this.lbllscc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbllscc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllscc.ForeColor = System.Drawing.Color.White;
            this.lbllscc.Location = new System.Drawing.Point(0, 0);
            this.lbllscc.Name = "lbllscc";
            this.lbllscc.Size = new System.Drawing.Size(1078, 716);
            this.lbllscc.TabIndex = 1;
            this.lbllscc.Text = "LỊCH SỬ CẮT CƠM";
            this.lbllscc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1078, 716);
            this.label1.TabIndex = 2;
            this.label1.Text = "LỊCH SỬ CẮT CƠM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pntieude
            // 
            this.pntieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pntieude.Controls.Add(this.btnthoat);
            this.pntieude.Controls.Add(this.lbltieude);
            this.pntieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pntieude.Location = new System.Drawing.Point(0, 0);
            this.pntieude.Name = "pntieude";
            this.pntieude.Size = new System.Drawing.Size(1078, 80);
            this.pntieude.TabIndex = 3;
            // 
            // btnthoat
            // 
            this.btnthoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnthoat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.Location = new System.Drawing.Point(1022, 0);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(56, 41);
            this.btnthoat.TabIndex = 4;
            this.btnthoat.Text = " X";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // lbltieude
            // 
            this.lbltieude.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltieude.AutoSize = true;
            this.lbltieude.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.Color.White;
            this.lbltieude.Location = new System.Drawing.Point(440, 19);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(217, 45);
            this.lbltieude.TabIndex = 0;
            this.lbltieude.Text = "THỰC PHẨM";
            // 
            // pnlluachon
            // 
            this.pnlluachon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlluachon.Controls.Add(this.panel2);
            this.pnlluachon.Controls.Add(this.panel1);
            this.pnlluachon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlluachon.Location = new System.Drawing.Point(0, 80);
            this.pnlluachon.Name = "pnlluachon";
            this.pnlluachon.Size = new System.Drawing.Size(1078, 183);
            this.pnlluachon.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtkcal);
            this.panel2.Controls.Add(this.txtdonvi);
            this.panel2.Controls.Add(this.txtgia);
            this.panel2.Controls.Add(this.txtten);
            this.panel2.Controls.Add(this.lblkcal);
            this.panel2.Controls.Add(this.lbldonvi);
            this.panel2.Controls.Add(this.lblgia);
            this.panel2.Controls.Add(this.lblten);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 183);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtkcal
            // 
            this.txtkcal.Location = new System.Drawing.Point(98, 138);
            this.txtkcal.Name = "txtkcal";
            this.txtkcal.Size = new System.Drawing.Size(482, 26);
            this.txtkcal.TabIndex = 8;
            // 
            // txtdonvi
            // 
            this.txtdonvi.Location = new System.Drawing.Point(98, 99);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.Size = new System.Drawing.Size(482, 26);
            this.txtdonvi.TabIndex = 7;
            // 
            // txtgia
            // 
            this.txtgia.Location = new System.Drawing.Point(98, 60);
            this.txtgia.Name = "txtgia";
            this.txtgia.Size = new System.Drawing.Size(482, 26);
            this.txtgia.TabIndex = 6;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(98, 21);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(482, 26);
            this.txtten.TabIndex = 5;
            // 
            // lblkcal
            // 
            this.lblkcal.AutoSize = true;
            this.lblkcal.Location = new System.Drawing.Point(33, 138);
            this.lblkcal.Name = "lblkcal";
            this.lblkcal.Size = new System.Drawing.Size(39, 20);
            this.lblkcal.TabIndex = 4;
            this.lblkcal.Text = "Kcal";
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(33, 100);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(53, 20);
            this.lbldonvi.TabIndex = 3;
            this.lbldonvi.Text = "Đơn vị";
            // 
            // lblgia
            // 
            this.lblgia.AutoSize = true;
            this.lblgia.Location = new System.Drawing.Point(33, 62);
            this.lblgia.Name = "lblgia";
            this.lblgia.Size = new System.Drawing.Size(34, 20);
            this.lblgia.TabIndex = 2;
            this.lblgia.Text = "Giá";
            // 
            // lblten
            // 
            this.lblten.AutoSize = true;
            this.lblten.Location = new System.Drawing.Point(33, 24);
            this.lblten.Name = "lblten";
            this.lblten.Size = new System.Drawing.Size(36, 20);
            this.lblten.TabIndex = 0;
            this.lblten.Text = "Tên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.btnxoa);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnthem);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btntracuu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(735, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 183);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.Wheat;
            this.btnupdate.Location = new System.Drawing.Point(185, 99);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(129, 58);
            this.btnupdate.TabIndex = 12;
            this.btnupdate.Text = "     Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnxoa.Location = new System.Drawing.Point(25, 100);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(129, 58);
            this.btnxoa.TabIndex = 11;
            this.btnxoa.Text = "  Xóa";
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.LightGreen;
            this.btnthem.Location = new System.Drawing.Point(25, 21);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(129, 58);
            this.btnthem.TabIndex = 10;
            this.btnthem.Text = "   Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(196, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // btntracuu
            // 
            this.btntracuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btntracuu.Location = new System.Drawing.Point(185, 21);
            this.btntracuu.Name = "btntracuu";
            this.btntracuu.Size = new System.Drawing.Size(129, 58);
            this.btntracuu.TabIndex = 9;
            this.btntracuu.Text = "    Tra cứu";
            this.btntracuu.UseVisualStyleBackColor = false;
            this.btntracuu.Click += new System.EventHandler(this.btntracuu_Click);
            // 
            // pndata
            // 
            this.pndata.Controls.Add(this.dgvdstp);
            this.pndata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pndata.Location = new System.Drawing.Point(0, 263);
            this.pndata.Name = "pndata";
            this.pndata.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pndata.Size = new System.Drawing.Size(1078, 453);
            this.pndata.TabIndex = 5;
            // 
            // dgvdstp
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdstp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvdstp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdstp.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdstp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvdstp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdstp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coltpid,
            this.colthucpham,
            this.colgia,
            this.coldonvi,
            this.colkcal});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdstp.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvdstp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdstp.EnableHeadersVisualStyles = false;
            this.dgvdstp.Location = new System.Drawing.Point(10, 0);
            this.dgvdstp.Name = "dgvdstp";
            this.dgvdstp.RowHeadersWidth = 62;
            this.dgvdstp.RowTemplate.Height = 28;
            this.dgvdstp.Size = new System.Drawing.Size(1068, 453);
            this.dgvdstp.TabIndex = 1;
            this.dgvdstp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdstp_CellClick);
            this.dgvdstp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlscc_CellContentClick);
            // 
            // coltpid
            // 
            this.coltpid.DataPropertyName = "thucpham_id";
            this.coltpid.HeaderText = "Thực phẩm id";
            this.coltpid.MinimumWidth = 8;
            this.coltpid.Name = "coltpid";
            // 
            // colthucpham
            // 
            this.colthucpham.DataPropertyName = "thucpham_ten";
            this.colthucpham.HeaderText = "Tên thực phẩm";
            this.colthucpham.MinimumWidth = 8;
            this.colthucpham.Name = "colthucpham";
            // 
            // colgia
            // 
            this.colgia.DataPropertyName = "thucpham_giatien";
            this.colgia.HeaderText = "Giá";
            this.colgia.MinimumWidth = 8;
            this.colgia.Name = "colgia";
            // 
            // coldonvi
            // 
            this.coldonvi.DataPropertyName = "thucpham_donvitinh";
            this.coldonvi.HeaderText = "Đơn vị";
            this.coldonvi.MinimumWidth = 8;
            this.coldonvi.Name = "coldonvi";
            // 
            // colkcal
            // 
            this.colkcal.DataPropertyName = "thucpham_kcal";
            this.colkcal.HeaderText = "Kcal";
            this.colkcal.MinimumWidth = 8;
            this.colkcal.Name = "colkcal";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.LightCoral;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(35, 114);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Wheat;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(196, 114);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 21;
            this.pictureBox5.TabStop = false;
            // 
            // frmdsthucpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1078, 716);
            this.Controls.Add(this.pndata);
            this.Controls.Add(this.pnlluachon);
            this.Controls.Add(this.pntieude);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbllscc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmdsthucpham";
            this.Text = "Danh sách thực phẩm";
            this.Load += new System.EventHandler(this.frmdsthucpham_Load);
            this.pntieude.ResumeLayout(false);
            this.pntieude.PerformLayout();
            this.pnlluachon.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pndata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdstp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbllscc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pntieude;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.Panel pnlluachon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btntracuu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblkcal;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.Label lblgia;
        private System.Windows.Forms.Label lblten;
        private System.Windows.Forms.TextBox txtkcal;
        private System.Windows.Forms.TextBox txtdonvi;
        private System.Windows.Forms.TextBox txtgia;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.Panel pndata;
        private System.Windows.Forms.DataGridView dgvdstp;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltpid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colthucpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgia;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldonvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colkcal;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}