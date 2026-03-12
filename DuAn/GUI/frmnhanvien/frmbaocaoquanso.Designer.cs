namespace frmnhanvien
{
    partial class frmbaocaoquanso
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblend = new System.Windows.Forms.Label();
            this.lbldenngay = new System.Windows.Forms.Label();
            this.dtptungay = new System.Windows.Forms.DateTimePicker();
            this.dtpdenngay = new System.Windows.Forms.DateTimePicker();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.cbobuoi = new System.Windows.Forms.ComboBox();
            this.lblchedo = new System.Windows.Forms.Label();
            this.cbochedo = new System.Windows.Forms.ComboBox();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.cbodonvi = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colstt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltungay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldenngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colquanso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongan = new System.Windows.Forms.Label();
            this.lbltongkhongan = new System.Windows.Forms.Label();
            this.lbltongqsan = new System.Windows.Forms.Label();
            this.lbltongquansokhongan = new System.Windows.Forms.Label();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxuatbc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnxuatbc);
            this.splitContainer1.Panel1.Controls.Add(this.btnluu);
            this.splitContainer1.Panel1.Controls.Add(this.cbodonvi);
            this.splitContainer1.Panel1.Controls.Add(this.lbldonvi);
            this.splitContainer1.Panel1.Controls.Add(this.cbochedo);
            this.splitContainer1.Panel1.Controls.Add(this.lblchedo);
            this.splitContainer1.Panel1.Controls.Add(this.cbobuoi);
            this.splitContainer1.Panel1.Controls.Add(this.lblbuoi);
            this.splitContainer1.Panel1.Controls.Add(this.dtpdenngay);
            this.splitContainer1.Panel1.Controls.Add(this.dtptungay);
            this.splitContainer1.Panel1.Controls.Add(this.lbldenngay);
            this.splitContainer1.Panel1.Controls.Add(this.lblend);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbltongquansokhongan);
            this.splitContainer1.Panel2.Controls.Add(this.lbltongqsan);
            this.splitContainer1.Panel2.Controls.Add(this.lbltongkhongan);
            this.splitContainer1.Panel2.Controls.Add(this.lblTongan);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 475);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblend
            // 
            this.lblend.AutoSize = true;
            this.lblend.Location = new System.Drawing.Point(20, 46);
            this.lblend.Name = "lblend";
            this.lblend.Size = new System.Drawing.Size(65, 18);
            this.lblend.TabIndex = 0;
            this.lblend.Text = "Từ ngày";
            // 
            // lbldenngay
            // 
            this.lbldenngay.AutoSize = true;
            this.lbldenngay.Location = new System.Drawing.Point(20, 101);
            this.lbldenngay.Name = "lbldenngay";
            this.lbldenngay.Size = new System.Drawing.Size(74, 18);
            this.lbldenngay.TabIndex = 1;
            this.lbldenngay.Text = "Đến ngày";
            // 
            // dtptungay
            // 
            this.dtptungay.Location = new System.Drawing.Point(113, 60);
            this.dtptungay.Name = "dtptungay";
            this.dtptungay.Size = new System.Drawing.Size(200, 26);
            this.dtptungay.TabIndex = 2;
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.Location = new System.Drawing.Point(113, 101);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(200, 26);
            this.dtpdenngay.TabIndex = 3;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(29, 156);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 4;
            this.lblbuoi.Text = "Buổi";
            // 
            // cbobuoi
            // 
            this.cbobuoi.FormattingEnabled = true;
            this.cbobuoi.Location = new System.Drawing.Point(113, 153);
            this.cbobuoi.Name = "cbobuoi";
            this.cbobuoi.Size = new System.Drawing.Size(121, 26);
            this.cbobuoi.TabIndex = 5;
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(29, 206);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(59, 18);
            this.lblchedo.TabIndex = 6;
            this.lblchedo.Text = "Chế độ";
            // 
            // cbochedo
            // 
            this.cbochedo.FormattingEnabled = true;
            this.cbochedo.Location = new System.Drawing.Point(113, 206);
            this.cbochedo.Name = "cbochedo";
            this.cbochedo.Size = new System.Drawing.Size(121, 26);
            this.cbochedo.TabIndex = 7;
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(29, 255);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(54, 18);
            this.lbldonvi.TabIndex = 8;
            this.lbldonvi.Text = "Đơn vị";
            // 
            // cbodonvi
            // 
            this.cbodonvi.FormattingEnabled = true;
            this.cbodonvi.Location = new System.Drawing.Point(113, 255);
            this.cbodonvi.Name = "cbodonvi";
            this.cbodonvi.Size = new System.Drawing.Size(121, 26);
            this.cbodonvi.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colstt,
            this.coltungay,
            this.coldenngay,
            this.colbuoi,
            this.colchedo,
            this.colquanso,
            this.colQSan});
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(870, 383);
            this.dataGridView1.TabIndex = 0;
            // 
            // colstt
            // 
            this.colstt.HeaderText = "STT";
            this.colstt.MinimumWidth = 8;
            this.colstt.Name = "colstt";
            this.colstt.Width = 70;
            // 
            // coltungay
            // 
            this.coltungay.HeaderText = "Từ ngày";
            this.coltungay.MinimumWidth = 8;
            this.coltungay.Name = "coltungay";
            this.coltungay.Width = 150;
            // 
            // coldenngay
            // 
            this.coldenngay.HeaderText = "Đến ngày";
            this.coldenngay.MinimumWidth = 8;
            this.coldenngay.Name = "coldenngay";
            this.coldenngay.Width = 150;
            // 
            // colbuoi
            // 
            this.colbuoi.HeaderText = "Buổi";
            this.colbuoi.MinimumWidth = 8;
            this.colbuoi.Name = "colbuoi";
            // 
            // colchedo
            // 
            this.colchedo.HeaderText = "Chế độ";
            this.colchedo.MinimumWidth = 8;
            this.colchedo.Name = "colchedo";
            this.colchedo.Width = 150;
            // 
            // colquanso
            // 
            this.colquanso.HeaderText = "Quân số";
            this.colquanso.MinimumWidth = 8;
            this.colquanso.Name = "colquanso";
            // 
            // colQSan
            // 
            this.colQSan.HeaderText = "Quân số ăn";
            this.colQSan.MinimumWidth = 8;
            this.colQSan.Name = "colQSan";
            // 
            // lblTongan
            // 
            this.lblTongan.AutoSize = true;
            this.lblTongan.Location = new System.Drawing.Point(75, 401);
            this.lblTongan.Name = "lblTongan";
            this.lblTongan.Size = new System.Drawing.Size(123, 18);
            this.lblTongan.TabIndex = 1;
            this.lblTongan.Text = "Tổng quân số ăn";
            // 
            // lbltongkhongan
            // 
            this.lbltongkhongan.AutoSize = true;
            this.lbltongkhongan.Location = new System.Drawing.Point(75, 448);
            this.lbltongkhongan.Name = "lbltongkhongan";
            this.lbltongkhongan.Size = new System.Drawing.Size(169, 18);
            this.lbltongkhongan.TabIndex = 2;
            this.lbltongkhongan.Text = "Tổng quân số không ăn";
            // 
            // lbltongqsan
            // 
            this.lbltongqsan.AutoSize = true;
            this.lbltongqsan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbltongqsan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltongqsan.Location = new System.Drawing.Point(286, 399);
            this.lbltongqsan.Name = "lbltongqsan";
            this.lbltongqsan.Size = new System.Drawing.Size(27, 20);
            this.lbltongqsan.TabIndex = 3;
            this.lbltongqsan.Text = "an";
            // 
            // lbltongquansokhongan
            // 
            this.lbltongquansokhongan.AutoSize = true;
            this.lbltongquansokhongan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbltongquansokhongan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltongquansokhongan.Location = new System.Drawing.Point(286, 446);
            this.lbltongquansokhongan.Name = "lbltongquansokhongan";
            this.lbltongquansokhongan.Size = new System.Drawing.Size(69, 20);
            this.lbltongquansokhongan.TabIndex = 4;
            this.lbltongquansokhongan.Text = "khongan";
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(129, 306);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(105, 40);
            this.btnluu.TabIndex = 10;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            // 
            // btnxuatbc
            // 
            this.btnxuatbc.Location = new System.Drawing.Point(113, 381);
            this.btnxuatbc.Name = "btnxuatbc";
            this.btnxuatbc.Size = new System.Drawing.Size(141, 38);
            this.btnxuatbc.TabIndex = 11;
            this.btnxuatbc.Text = "Xuất báo cáo";
            this.btnxuatbc.UseVisualStyleBackColor = true;
            // 
            // frmbaocaoquanso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1222, 475);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmbaocaoquanso";
            this.Text = "frmbaocaoquanso";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbodonvi;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.ComboBox cbochedo;
        private System.Windows.Forms.Label lblchedo;
        private System.Windows.Forms.ComboBox cbobuoi;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.DateTimePicker dtpdenngay;
        private System.Windows.Forms.DateTimePicker dtptungay;
        private System.Windows.Forms.Label lbldenngay;
        private System.Windows.Forms.Label lblend;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstt;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltungay;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldenngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colquanso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQSan;
        private System.Windows.Forms.Button btnxuatbc;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Label lbltongquansokhongan;
        private System.Windows.Forms.Label lbltongqsan;
        private System.Windows.Forms.Label lbltongkhongan;
        private System.Windows.Forms.Label lblTongan;
    }
}