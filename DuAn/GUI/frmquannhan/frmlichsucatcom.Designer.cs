namespace frmquannhan
{
    partial class frmlichsucatcom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlichsucatcom));
            this.pnltieude = new System.Windows.Forms.Panel();
            this.lbllscc = new System.Windows.Forms.Label();
            this.pnlluachon = new System.Windows.Forms.Panel();
            this.pnllscc = new System.Windows.Forms.Panel();
            this.dgvlscc = new System.Windows.Forms.DataGridView();
            this.colstt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collydo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbltong = new System.Windows.Forms.Label();
            this.lblsum = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnltogtien = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btntracuu = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbldenngay = new System.Windows.Forms.Label();
            this.lbltungay = new System.Windows.Forms.Label();
            this.pnltieude.SuspendLayout();
            this.pnlluachon.SuspendLayout();
            this.pnllscc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlscc)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnltogtien.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnltieude
            // 
            this.pnltieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnltieude.Controls.Add(this.lbllscc);
            this.pnltieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltieude.Location = new System.Drawing.Point(0, 0);
            this.pnltieude.Name = "pnltieude";
            this.pnltieude.Size = new System.Drawing.Size(916, 60);
            this.pnltieude.TabIndex = 0;
            // 
            // lbllscc
            // 
            this.lbllscc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbllscc.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllscc.ForeColor = System.Drawing.Color.White;
            this.lbllscc.Location = new System.Drawing.Point(0, 0);
            this.lbllscc.Name = "lbllscc";
            this.lbllscc.Size = new System.Drawing.Size(916, 60);
            this.lbllscc.TabIndex = 0;
            this.lbllscc.Text = "LỊCH SỬ CẮT CƠM";
            this.lbllscc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlluachon
            // 
            this.pnlluachon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlluachon.Controls.Add(this.panel1);
            this.pnlluachon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlluachon.Location = new System.Drawing.Point(0, 60);
            this.pnlluachon.Name = "pnlluachon";
            this.pnlluachon.Size = new System.Drawing.Size(916, 80);
            this.pnlluachon.TabIndex = 1;
            this.pnlluachon.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pnllscc
            // 
            this.pnllscc.Controls.Add(this.panel4);
            this.pnllscc.Controls.Add(this.dgvlscc);
            this.pnllscc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnllscc.Location = new System.Drawing.Point(0, 140);
            this.pnllscc.Name = "pnllscc";
            this.pnllscc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnllscc.Size = new System.Drawing.Size(916, 408);
            this.pnllscc.TabIndex = 2;
            // 
            // dgvlscc
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvlscc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvlscc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvlscc.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlscc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvlscc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlscc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colstt,
            this.colngay,
            this.colbuoi,
            this.collydo,
            this.coltien});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvlscc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvlscc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvlscc.Location = new System.Drawing.Point(10, 0);
            this.dgvlscc.Name = "dgvlscc";
            this.dgvlscc.RowHeadersWidth = 62;
            this.dgvlscc.RowTemplate.Height = 28;
            this.dgvlscc.Size = new System.Drawing.Size(906, 408);
            this.dgvlscc.TabIndex = 0;
            // 
            // colstt
            // 
            this.colstt.HeaderText = "STT";
            this.colstt.MinimumWidth = 8;
            this.colstt.Name = "colstt";
            // 
            // colngay
            // 
            this.colngay.HeaderText = "Ngày";
            this.colngay.MinimumWidth = 8;
            this.colngay.Name = "colngay";
            // 
            // colbuoi
            // 
            this.colbuoi.HeaderText = "Buổi";
            this.colbuoi.MinimumWidth = 8;
            this.colbuoi.Name = "colbuoi";
            // 
            // collydo
            // 
            this.collydo.HeaderText = "Lý do";
            this.collydo.MinimumWidth = 8;
            this.collydo.Name = "collydo";
            // 
            // coltien
            // 
            this.coltien.HeaderText = "Tiền cắt cơm";
            this.coltien.MinimumWidth = 8;
            this.coltien.Name = "coltien";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnltogtien);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 358);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(906, 50);
            this.panel4.TabIndex = 1;
            // 
            // lbltong
            // 
            this.lbltong.AutoSize = true;
            this.lbltong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.lbltong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lbltong.Location = new System.Drawing.Point(38, 12);
            this.lbltong.Name = "lbltong";
            this.lbltong.Size = new System.Drawing.Size(221, 29);
            this.lbltong.TabIndex = 0;
            this.lbltong.Text = "Tổng tiền cắt cơm";
            // 
            // lblsum
            // 
            this.lblsum.AutoSize = true;
            this.lblsum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.lblsum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblsum.Location = new System.Drawing.Point(265, 11);
            this.lblsum.Name = "lblsum";
            this.lblsum.Size = new System.Drawing.Size(87, 29);
            this.lblsum.TabIndex = 1;
            this.lblsum.Text = "0 VND";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(631, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pnltogtien
            // 
            this.pnltogtien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnltogtien.Controls.Add(this.lbltong);
            this.pnltogtien.Controls.Add(this.pictureBox1);
            this.pnltogtien.Controls.Add(this.lblsum);
            this.pnltogtien.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnltogtien.Location = new System.Drawing.Point(543, 0);
            this.pnltogtien.Name = "pnltogtien";
            this.pnltogtien.Size = new System.Drawing.Size(363, 50);
            this.pnltogtien.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.btntracuu);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lbldenngay);
            this.panel1.Controls.Add(this.lbltungay);
            this.panel1.Location = new System.Drawing.Point(110, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 74);
            this.panel1.TabIndex = 6;
            // 
            // btntracuu
            // 
            this.btntracuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btntracuu.Location = new System.Drawing.Point(620, 10);
            this.btntracuu.Name = "btntracuu";
            this.btntracuu.Size = new System.Drawing.Size(129, 58);
            this.btntracuu.TabIndex = 9;
            this.btntracuu.Text = "  Tra cứu";
            this.btntracuu.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(399, 28);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(202, 26);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(85, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(202, 26);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // lbldenngay
            // 
            this.lbldenngay.AutoSize = true;
            this.lbldenngay.BackColor = System.Drawing.Color.White;
            this.lbldenngay.ForeColor = System.Drawing.Color.Black;
            this.lbldenngay.Location = new System.Drawing.Point(304, 34);
            this.lbldenngay.Name = "lbldenngay";
            this.lbldenngay.Size = new System.Drawing.Size(77, 20);
            this.lbldenngay.TabIndex = 6;
            this.lbldenngay.Text = "Đến ngày";
            // 
            // lbltungay
            // 
            this.lbltungay.AutoSize = true;
            this.lbltungay.ForeColor = System.Drawing.Color.Black;
            this.lbltungay.Location = new System.Drawing.Point(14, 34);
            this.lbltungay.Name = "lbltungay";
            this.lbltungay.Size = new System.Drawing.Size(65, 20);
            this.lbltungay.TabIndex = 5;
            this.lbltungay.Text = "Từ ngày";
            // 
            // frmlichsucatcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(916, 548);
            this.Controls.Add(this.pnllscc);
            this.Controls.Add(this.pnlluachon);
            this.Controls.Add(this.pnltieude);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmlichsucatcom";
            this.Text = "Lịch sử cắt cơm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnltieude.ResumeLayout(false);
            this.pnlluachon.ResumeLayout(false);
            this.pnllscc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlscc)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnltogtien.ResumeLayout(false);
            this.pnltogtien.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnltieude;
        private System.Windows.Forms.Label lbllscc;
        private System.Windows.Forms.Panel pnlluachon;
        private System.Windows.Forms.Panel pnllscc;
        private System.Windows.Forms.DataGridView dgvlscc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn collydo;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltien;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblsum;
        private System.Windows.Forms.Label lbltong;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnltogtien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btntracuu;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbldenngay;
        private System.Windows.Forms.Label lbltungay;
    }
}