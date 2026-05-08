namespace DuAn.GUI.frmfornhvhc
{
    partial class frmdsqn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdsqn));
            this.pnltitle = new System.Windows.Forms.Panel();
            this.lblbqs = new System.Windows.Forms.Label();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.pnlcrud = new System.Windows.Forms.Panel();
            this.btnreset = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.pnldien = new System.Windows.Forms.Panel();
            this.txtmaqn = new System.Windows.Forms.TextBox();
            this.lblma = new System.Windows.Forms.Label();
            this.cbodonvi = new System.Windows.Forms.ComboBox();
            this.cbochedo = new System.Windows.Forms.ComboBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.lblchedo = new System.Windows.Forms.Label();
            this.lblten = new System.Windows.Forms.Label();
            this.pnldgv = new System.Windows.Forms.Panel();
            this.dgvdsqn = new System.Windows.Forms.DataGridView();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldonvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pnltitle.SuspendLayout();
            this.pnlfilter.SuspendLayout();
            this.pnlcrud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnldien.SuspendLayout();
            this.pnldgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsqn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pnltitle
            // 
            this.pnltitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnltitle.Controls.Add(this.lblbqs);
            this.pnltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltitle.Location = new System.Drawing.Point(0, 0);
            this.pnltitle.Name = "pnltitle";
            this.pnltitle.Size = new System.Drawing.Size(1049, 79);
            this.pnltitle.TabIndex = 1;
            // 
            // lblbqs
            // 
            this.lblbqs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblbqs.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbqs.ForeColor = System.Drawing.Color.White;
            this.lblbqs.Location = new System.Drawing.Point(328, 20);
            this.lblbqs.Name = "lblbqs";
            this.lblbqs.Size = new System.Drawing.Size(451, 45);
            this.lblbqs.TabIndex = 0;
            this.lblbqs.Text = "DANH SÁCH QUÂN NHÂN";
            // 
            // pnlfilter
            // 
            this.pnlfilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlfilter.Controls.Add(this.pnlcrud);
            this.pnlfilter.Controls.Add(this.pnldien);
            this.pnlfilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlfilter.Location = new System.Drawing.Point(0, 79);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(1049, 187);
            this.pnlfilter.TabIndex = 2;
            // 
            // pnlcrud
            // 
            this.pnlcrud.Controls.Add(this.pictureBox5);
            this.pnlcrud.Controls.Add(this.pictureBox4);
            this.pnlcrud.Controls.Add(this.pictureBox3);
            this.pnlcrud.Controls.Add(this.pictureBox1);
            this.pnlcrud.Controls.Add(this.btnreset);
            this.pnlcrud.Controls.Add(this.btntimkiem);
            this.pnlcrud.Controls.Add(this.btnxoa);
            this.pnlcrud.Controls.Add(this.btnthem);
            this.pnlcrud.Controls.Add(this.pictureBox2);
            this.pnlcrud.Controls.Add(this.btnupdate);
            this.pnlcrud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlcrud.Location = new System.Drawing.Point(625, 0);
            this.pnlcrud.Name = "pnlcrud";
            this.pnlcrud.Size = new System.Drawing.Size(424, 187);
            this.pnlcrud.TabIndex = 9;
            this.pnlcrud.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlcrud_Paint);
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnreset.Location = new System.Drawing.Point(151, 56);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(114, 61);
            this.btnreset.TabIndex = 13;
            this.btnreset.Text = "    Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click_1);
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackColor = System.Drawing.Color.SandyBrown;
            this.btntimkiem.Location = new System.Drawing.Point(271, 97);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(129, 58);
            this.btntimkiem.TabIndex = 12;
            this.btntimkiem.Text = "       Tìm kiếm ";
            this.btntimkiem.UseVisualStyleBackColor = false;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.Color.LightCoral;
            this.btnxoa.Location = new System.Drawing.Point(16, 100);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(129, 58);
            this.btnxoa.TabIndex = 11;
            this.btnxoa.Text = "  Xóa";
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.LightGreen;
            this.btnthem.Location = new System.Drawing.Point(16, 21);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(129, 58);
            this.btnthem.TabIndex = 10;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(280, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnupdate.Location = new System.Drawing.Point(271, 18);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(129, 58);
            this.btnupdate.TabIndex = 9;
            this.btnupdate.Text = "  Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // pnldien
            // 
            this.pnldien.Controls.Add(this.txtmaqn);
            this.pnldien.Controls.Add(this.lblma);
            this.pnldien.Controls.Add(this.cbodonvi);
            this.pnldien.Controls.Add(this.cbochedo);
            this.pnldien.Controls.Add(this.txtten);
            this.pnldien.Controls.Add(this.lbldonvi);
            this.pnldien.Controls.Add(this.lblchedo);
            this.pnldien.Controls.Add(this.lblten);
            this.pnldien.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnldien.Location = new System.Drawing.Point(0, 0);
            this.pnldien.Name = "pnldien";
            this.pnldien.Size = new System.Drawing.Size(625, 187);
            this.pnldien.TabIndex = 8;
            this.pnldien.Paint += new System.Windows.Forms.PaintEventHandler(this.pnldien_Paint);
            // 
            // txtmaqn
            // 
            this.txtmaqn.Location = new System.Drawing.Point(166, 18);
            this.txtmaqn.Name = "txtmaqn";
            this.txtmaqn.Size = new System.Drawing.Size(156, 26);
            this.txtmaqn.TabIndex = 9;
            this.txtmaqn.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblma
            // 
            this.lblma.AutoSize = true;
            this.lblma.Location = new System.Drawing.Point(28, 24);
            this.lblma.Name = "lblma";
            this.lblma.Size = new System.Drawing.Size(116, 20);
            this.lblma.TabIndex = 8;
            this.lblma.Text = "Mã Quân Nhân";
            this.lblma.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbodonvi
            // 
            this.cbodonvi.FormattingEnabled = true;
            this.cbodonvi.Location = new System.Drawing.Point(166, 147);
            this.cbodonvi.Name = "cbodonvi";
            this.cbodonvi.Size = new System.Drawing.Size(280, 28);
            this.cbodonvi.TabIndex = 7;
            this.cbodonvi.SelectedIndexChanged += new System.EventHandler(this.cbodonvi_SelectedIndexChanged);
            // 
            // cbochedo
            // 
            this.cbochedo.FormattingEnabled = true;
            this.cbochedo.Location = new System.Drawing.Point(166, 100);
            this.cbochedo.Name = "cbochedo";
            this.cbochedo.Size = new System.Drawing.Size(280, 28);
            this.cbochedo.TabIndex = 6;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(166, 56);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(363, 26);
            this.txtten.TabIndex = 5;
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(50, 150);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(53, 20);
            this.lbldonvi.TabIndex = 3;
            this.lbldonvi.Text = "Đơn vị";
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(50, 97);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(60, 20);
            this.lblchedo.TabIndex = 2;
            this.lblchedo.Text = "Chế độ";
            // 
            // lblten
            // 
            this.lblten.AutoSize = true;
            this.lblten.Location = new System.Drawing.Point(50, 56);
            this.lblten.Name = "lblten";
            this.lblten.Size = new System.Drawing.Size(36, 20);
            this.lblten.TabIndex = 0;
            this.lblten.Text = "Tên";
            // 
            // pnldgv
            // 
            this.pnldgv.Controls.Add(this.dgvdsqn);
            this.pnldgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnldgv.Location = new System.Drawing.Point(0, 266);
            this.pnldgv.Name = "pnldgv";
            this.pnldgv.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnldgv.Size = new System.Drawing.Size(1049, 361);
            this.pnldgv.TabIndex = 3;
            // 
            // dgvdsqn
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvdsqn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdsqn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvdsqn.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdsqn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdsqn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdsqn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colid,
            this.colten,
            this.coldonvi,
            this.colchedo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvdsqn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdsqn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdsqn.EnableHeadersVisualStyles = false;
            this.dgvdsqn.Location = new System.Drawing.Point(10, 0);
            this.dgvdsqn.Name = "dgvdsqn";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdsqn.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvdsqn.RowHeadersWidth = 62;
            this.dgvdsqn.RowTemplate.Height = 28;
            this.dgvdsqn.Size = new System.Drawing.Size(1039, 361);
            this.dgvdsqn.TabIndex = 2;
            this.dgvdsqn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdsqn_CellClick);
            this.dgvdsqn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdsqn_CellContentClick);
            // 
            // colid
            // 
            this.colid.DataPropertyName = "quannhan_id";
            this.colid.HeaderText = "Mã Quân Nhân";
            this.colid.MinimumWidth = 8;
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.DataPropertyName = "quannhan_hoten";
            this.colten.HeaderText = "Tên Quân Nhân";
            this.colten.MinimumWidth = 8;
            this.colten.Name = "colten";
            // 
            // coldonvi
            // 
            this.coldonvi.DataPropertyName = "donvi_ten";
            this.coldonvi.HeaderText = "Đơn vị";
            this.coldonvi.MinimumWidth = 8;
            this.coldonvi.Name = "coldonvi";
            // 
            // colchedo
            // 
            this.colchedo.DataPropertyName = "chedo_ten";
            this.colchedo.HeaderText = "Chế độ";
            this.colchedo.MinimumWidth = 8;
            this.colchedo.Name = "colchedo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.LightCoral;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(25, 114);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.LemonChiffon;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(161, 70);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.SandyBrown;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(280, 114);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // frmdsqn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 627);
            this.Controls.Add(this.pnldgv);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.pnltitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmdsqn";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmquannhan_Load);
            this.pnltitle.ResumeLayout(false);
            this.pnlfilter.ResumeLayout(false);
            this.pnlcrud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnldien.ResumeLayout(false);
            this.pnldien.PerformLayout();
            this.pnldgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsqn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnltitle;
        private System.Windows.Forms.Label lblbqs;
        private System.Windows.Forms.Panel pnlfilter;
        private System.Windows.Forms.Panel pnldien;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.Label lblchedo;
        private System.Windows.Forms.Label lblten;
        private System.Windows.Forms.Panel pnlcrud;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Panel pnldgv;
        private System.Windows.Forms.DataGridView dgvdsqn;
        private System.Windows.Forms.ComboBox cbodonvi;
        private System.Windows.Forms.ComboBox cbochedo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colten;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldonvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txtmaqn;
        private System.Windows.Forms.Label lblma;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

