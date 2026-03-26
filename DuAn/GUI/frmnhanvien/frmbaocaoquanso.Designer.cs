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
            this.btnxuatbc = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.cbodonvi = new System.Windows.Forms.ComboBox();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.cbochedo = new System.Windows.Forms.ComboBox();
            this.lblchedo = new System.Windows.Forms.Label();
            this.cbobuoi = new System.Windows.Forms.ComboBox();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.dtpdenngay = new System.Windows.Forms.DateTimePicker();
            this.dtptungay = new System.Windows.Forms.DateTimePicker();
            this.lbldenngay = new System.Windows.Forms.Label();
            this.lblend = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colstt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltungay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldenngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colquanso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongan = new System.Windows.Forms.Label();
            this.lbltongkhongan = new System.Windows.Forms.Label();
            this.lbltongquansokhongan = new System.Windows.Forms.Label();
            this.lbltongqsan = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1222, 475);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnxuatbc
            // 
            this.btnxuatbc.Location = new System.Drawing.Point(110, 281);
            this.btnxuatbc.Name = "btnxuatbc";
            this.btnxuatbc.Size = new System.Drawing.Size(141, 38);
            this.btnxuatbc.TabIndex = 11;
            this.btnxuatbc.Text = "Xuất báo cáo";
            this.btnxuatbc.UseVisualStyleBackColor = true;
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(110, 227);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(105, 40);
            this.btnluu.TabIndex = 10;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            // 
            // cbodonvi
            // 
            this.cbodonvi.FormattingEnabled = true;
            this.cbodonvi.Location = new System.Drawing.Point(110, 174);
            this.cbodonvi.Name = "cbodonvi";
            this.cbodonvi.Size = new System.Drawing.Size(121, 31);
            this.cbodonvi.TabIndex = 9;
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(21, 180);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(66, 23);
            this.lbldonvi.TabIndex = 8;
            this.lbldonvi.Text = "Đơn vị";
            // 
            // cbochedo
            // 
            this.cbochedo.FormattingEnabled = true;
            this.cbochedo.Location = new System.Drawing.Point(110, 137);
            this.cbochedo.Name = "cbochedo";
            this.cbochedo.Size = new System.Drawing.Size(121, 31);
            this.cbochedo.TabIndex = 7;
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(14, 137);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(73, 23);
            this.lblchedo.TabIndex = 6;
            this.lblchedo.Text = "Chế độ";
            // 
            // cbobuoi
            // 
            this.cbobuoi.FormattingEnabled = true;
            this.cbobuoi.Location = new System.Drawing.Point(110, 92);
            this.cbobuoi.Name = "cbobuoi";
            this.cbobuoi.Size = new System.Drawing.Size(121, 31);
            this.cbobuoi.TabIndex = 5;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(21, 100);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(48, 23);
            this.lblbuoi.TabIndex = 4;
            this.lblbuoi.Text = "Buổi";
            // 
            // dtpdenngay
            // 
            this.dtpdenngay.Location = new System.Drawing.Point(110, 56);
            this.dtpdenngay.Name = "dtpdenngay";
            this.dtpdenngay.Size = new System.Drawing.Size(200, 30);
            this.dtpdenngay.TabIndex = 3;
            // 
            // dtptungay
            // 
            this.dtptungay.Location = new System.Drawing.Point(110, 13);
            this.dtptungay.Name = "dtptungay";
            this.dtptungay.Size = new System.Drawing.Size(200, 30);
            this.dtptungay.TabIndex = 2;
            // 
            // lbldenngay
            // 
            this.lbldenngay.AutoSize = true;
            this.lbldenngay.Location = new System.Drawing.Point(11, 60);
            this.lbldenngay.Name = "lbldenngay";
            this.lbldenngay.Size = new System.Drawing.Size(93, 23);
            this.lbldenngay.TabIndex = 1;
            this.lbldenngay.Text = "Đến ngày";
            // 
            // lblend
            // 
            this.lblend.AutoSize = true;
            this.lblend.Location = new System.Drawing.Point(3, 20);
            this.lblend.Name = "lblend";
            this.lblend.Size = new System.Drawing.Size(83, 23);
            this.lblend.TabIndex = 0;
            this.lblend.Text = "Từ ngày";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.78947F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.21053F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 475);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colstt,
            this.coltungay,
            this.coldenngay,
            this.colbuoi,
            this.colchedo,
            this.colquanso,
            this.colQSan});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(858, 335);
            this.dataGridView1.TabIndex = 1;
            // 
            // colstt
            // 
            this.colstt.HeaderText = "STT";
            this.colstt.MinimumWidth = 8;
            this.colstt.Name = "colstt";
            // 
            // coltungay
            // 
            this.coltungay.HeaderText = "Từ ngày";
            this.coltungay.MinimumWidth = 8;
            this.coltungay.Name = "coltungay";
            // 
            // coldenngay
            // 
            this.coldenngay.HeaderText = "Đến ngày";
            this.coldenngay.MinimumWidth = 8;
            this.coldenngay.Name = "coldenngay";
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.lblTongan);
            this.panel1.Controls.Add(this.lbltongkhongan);
            this.panel1.Controls.Add(this.lbltongquansokhongan);
            this.panel1.Controls.Add(this.lbltongqsan);
            this.panel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(185, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 128);
            this.panel1.TabIndex = 7;
            // 
            // lblTongan
            // 
            this.lblTongan.AutoSize = true;
            this.lblTongan.Location = new System.Drawing.Point(3, 23);
            this.lblTongan.Name = "lblTongan";
            this.lblTongan.Size = new System.Drawing.Size(156, 23);
            this.lblTongan.TabIndex = 1;
            this.lblTongan.Text = "Tổng quân số ăn";
            // 
            // lbltongkhongan
            // 
            this.lbltongkhongan.AutoSize = true;
            this.lbltongkhongan.Location = new System.Drawing.Point(3, 78);
            this.lbltongkhongan.Name = "lbltongkhongan";
            this.lbltongkhongan.Size = new System.Drawing.Size(214, 23);
            this.lbltongkhongan.TabIndex = 2;
            this.lbltongkhongan.Text = "Tổng quân số không ăn";
            // 
            // lbltongquansokhongan
            // 
            this.lbltongquansokhongan.AutoSize = true;
            this.lbltongquansokhongan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbltongquansokhongan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltongquansokhongan.Location = new System.Drawing.Point(234, 78);
            this.lbltongquansokhongan.Name = "lbltongquansokhongan";
            this.lbltongquansokhongan.Size = new System.Drawing.Size(85, 25);
            this.lbltongquansokhongan.TabIndex = 4;
            this.lbltongquansokhongan.Text = "khongan";
            // 
            // lbltongqsan
            // 
            this.lbltongqsan.AutoSize = true;
            this.lbltongqsan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbltongqsan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltongqsan.Location = new System.Drawing.Point(245, 23);
            this.lbltongqsan.Name = "lbltongqsan";
            this.lbltongqsan.Size = new System.Drawing.Size(33, 25);
            this.lbltongqsan.TabIndex = 3;
            this.lbltongqsan.Text = "an";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.btnxuatbc);
            this.panel2.Controls.Add(this.dtptungay);
            this.panel2.Controls.Add(this.dtpdenngay);
            this.panel2.Controls.Add(this.lblend);
            this.panel2.Controls.Add(this.lblbuoi);
            this.panel2.Controls.Add(this.cbobuoi);
            this.panel2.Controls.Add(this.lbldenngay);
            this.panel2.Controls.Add(this.lblchedo);
            this.panel2.Controls.Add(this.cbochedo);
            this.panel2.Controls.Add(this.lbldonvi);
            this.panel2.Controls.Add(this.cbodonvi);
            this.panel2.Controls.Add(this.btnluu);
            this.panel2.Location = new System.Drawing.Point(12, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 339);
            this.panel2.TabIndex = 12;
            // 
            // frmbaocaoquanso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1222, 475);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmbaocaoquanso";
            this.Text = "frmbaocaoquanso";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button btnxuatbc;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstt;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltungay;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldenngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colquanso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQSan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTongan;
        private System.Windows.Forms.Label lbltongkhongan;
        private System.Windows.Forms.Label lbltongquansokhongan;
        private System.Windows.Forms.Label lbltongqsan;
        private System.Windows.Forms.Panel panel2;
    }
}