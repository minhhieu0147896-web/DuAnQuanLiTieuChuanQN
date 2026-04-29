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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdsqn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnltitle = new System.Windows.Forms.Panel();
            this.btnthoat = new System.Windows.Forms.Button();
            this.lblbqs = new System.Windows.Forms.Label();
            this.pnlfilter = new System.Windows.Forms.Panel();
            this.pnlcrud = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.pnldien = new System.Windows.Forms.Panel();
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
            this.pnltitle.SuspendLayout();
            this.pnlfilter.SuspendLayout();
            this.pnlcrud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnldien.SuspendLayout();
            this.pnldgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsqn)).BeginInit();
            this.SuspendLayout();
            // 
            // pnltitle
            // 
            this.pnltitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnltitle.Controls.Add(this.btnthoat);
            this.pnltitle.Controls.Add(this.lblbqs);
            this.pnltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltitle.Location = new System.Drawing.Point(0, 0);
            this.pnltitle.Name = "pnltitle";
            this.pnltitle.Size = new System.Drawing.Size(1049, 79);
            this.pnltitle.TabIndex = 1;
            // 
            // btnthoat
            // 
            this.btnthoat.AutoSize = true;
            this.btnthoat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnthoat.Location = new System.Drawing.Point(1022, 0);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(30, 30);
            this.btnthoat.TabIndex = 1;
            this.btnthoat.Text = "X";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.button3_Click);
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
            this.pnlcrud.Controls.Add(this.button2);
            this.pnlcrud.Controls.Add(this.button1);
            this.pnlcrud.Controls.Add(this.pictureBox2);
            this.pnlcrud.Controls.Add(this.btnupdate);
            this.pnlcrud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlcrud.Location = new System.Drawing.Point(625, 0);
            this.pnlcrud.Name = "pnlcrud";
            this.pnlcrud.Size = new System.Drawing.Size(424, 187);
            this.pnlcrud.TabIndex = 9;
            this.pnlcrud.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlcrud_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightCoral;
            this.button2.Location = new System.Drawing.Point(126, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 58);
            this.button2.TabIndex = 11;
            this.button2.Text = "  Xóa";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Location = new System.Drawing.Point(16, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 58);
            this.button1.TabIndex = 10;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(261, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnupdate.Location = new System.Drawing.Point(250, 21);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(129, 58);
            this.btnupdate.TabIndex = 9;
            this.btnupdate.Text = "  Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // pnldien
            // 
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
            // cbodonvi
            // 
            this.cbodonvi.FormattingEnabled = true;
            this.cbodonvi.Location = new System.Drawing.Point(99, 97);
            this.cbodonvi.Name = "cbodonvi";
            this.cbodonvi.Size = new System.Drawing.Size(280, 28);
            this.cbodonvi.TabIndex = 7;
            // 
            // cbochedo
            // 
            this.cbochedo.FormattingEnabled = true;
            this.cbochedo.Location = new System.Drawing.Point(99, 59);
            this.cbochedo.Name = "cbochedo";
            this.cbochedo.Size = new System.Drawing.Size(280, 28);
            this.cbochedo.TabIndex = 6;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(98, 21);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(482, 26);
            this.txtten.TabIndex = 5;
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
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(33, 62);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(60, 20);
            this.lblchedo.TabIndex = 2;
            this.lblchedo.Text = "Chế độ";
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
            this.dgvdsqn.RowHeadersWidth = 62;
            this.dgvdsqn.RowTemplate.Height = 28;
            this.dgvdsqn.Size = new System.Drawing.Size(1039, 361);
            this.dgvdsqn.TabIndex = 2;
            this.dgvdsqn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdsqn_CellClick);
            this.dgvdsqn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdsqn_CellContentClick);
            // 
            // colid
            // 
            this.colid.DataPropertyName = "Quannhan_id";
            this.colid.HeaderText = "Mã Quân Nhân";
            this.colid.MinimumWidth = 8;
            this.colid.Name = "colid";
            // 
            // colten
            // 
            this.colten.DataPropertyName = "Quannhan_ten";
            this.colten.HeaderText = "Tên Quân Nhân";
            this.colten.MinimumWidth = 8;
            this.colten.Name = "colten";
            // 
            // coldonvi
            // 
            this.coldonvi.DataPropertyName = "Donvi_ten";
            this.coldonvi.HeaderText = "Đơn vị";
            this.coldonvi.MinimumWidth = 8;
            this.coldonvi.Name = "coldonvi";
            // 
            // colchedo
            // 
            this.colchedo.DataPropertyName = "Chedo_ten";
            this.colchedo.HeaderText = "Chế độ";
            this.colchedo.MinimumWidth = 8;
            this.colchedo.Name = "colchedo";
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
            this.pnltitle.PerformLayout();
            this.pnlfilter.ResumeLayout(false);
            this.pnlcrud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnldien.ResumeLayout(false);
            this.pnldien.PerformLayout();
            this.pnldgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdsqn)).EndInit();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Panel pnldgv;
        private System.Windows.Forms.DataGridView dgvdsqn;
        private System.Windows.Forms.ComboBox cbodonvi;
        private System.Windows.Forms.ComboBox cbochedo;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colten;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldonvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
    }
}

