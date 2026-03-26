namespace frmnhanvien
{
    partial class frmtinhtpcansudung
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colthucpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongsoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonggiatien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnbaocao = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.btnTinhtp = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.13044F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.86957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(785, 501);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colthucpham,
            this.colDonvi,
            this.colTongsoluong,
            this.colTonggiatien});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(779, 278);
            this.dataGridView1.TabIndex = 7;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            // 
            // colthucpham
            // 
            this.colthucpham.HeaderText = "Thực phẩm";
            this.colthucpham.MinimumWidth = 8;
            this.colthucpham.Name = "colthucpham";
            // 
            // colDonvi
            // 
            this.colDonvi.HeaderText = "Đơn vị";
            this.colDonvi.MinimumWidth = 8;
            this.colDonvi.Name = "colDonvi";
            // 
            // colTongsoluong
            // 
            this.colTongsoluong.HeaderText = "Tổng số lượng";
            this.colTongsoluong.MinimumWidth = 8;
            this.colTongsoluong.Name = "colTongsoluong";
            // 
            // colTonggiatien
            // 
            this.colTonggiatien.HeaderText = "Tổng tiền";
            this.colTonggiatien.MinimumWidth = 8;
            this.colTonggiatien.Name = "colTonggiatien";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btnluu);
            this.panel1.Controls.Add(this.btnbaocao);
            this.panel1.Location = new System.Drawing.Point(192, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 64);
            this.panel1.TabIndex = 10;
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(31, 21);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(148, 26);
            this.btnluu.TabIndex = 7;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            // 
            // btnbaocao
            // 
            this.btnbaocao.Location = new System.Drawing.Point(233, 21);
            this.btnbaocao.Name = "btnbaocao";
            this.btnbaocao.Size = new System.Drawing.Size(148, 26);
            this.btnbaocao.TabIndex = 3;
            this.btnbaocao.Text = "Xuất báo cáo";
            this.btnbaocao.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.lblNgay);
            this.panel2.Controls.Add(this.dtpNgay);
            this.panel2.Controls.Add(this.lblbuoi);
            this.panel2.Controls.Add(this.btnTinhtp);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(84, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 107);
            this.panel2.TabIndex = 12;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(15, 23);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(44, 18);
            this.lblNgay.TabIndex = 0;
            this.lblNgay.Text = "Ngày";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(65, 17);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(268, 26);
            this.dtpNgay.TabIndex = 1;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(19, 67);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 4;
            this.lblbuoi.Text = "Buổi";
            // 
            // btnTinhtp
            // 
            this.btnTinhtp.Location = new System.Drawing.Point(439, 23);
            this.btnTinhtp.Name = "btnTinhtp";
            this.btnTinhtp.Size = new System.Drawing.Size(133, 65);
            this.btnTinhtp.TabIndex = 2;
            this.btnTinhtp.Text = "Tính thực phẩm";
            this.btnTinhtp.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sáng ",
            "Trưa",
            "Chiều"});
            this.comboBox1.Location = new System.Drawing.Point(65, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // frmtinhtpcansudung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(785, 501);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmtinhtpcansudung";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtinhtpcansudung";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnbaocao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.Button btnTinhtp;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colthucpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongsoluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonggiatien;
    }
}