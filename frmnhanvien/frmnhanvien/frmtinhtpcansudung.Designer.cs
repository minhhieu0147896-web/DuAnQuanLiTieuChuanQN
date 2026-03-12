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
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTinhtp = new System.Windows.Forms.Button();
            this.btnbaocao = new System.Windows.Forms.Button();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colthucpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongsoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonggiatien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnluu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(69, 25);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(44, 18);
            this.lblNgay.TabIndex = 0;
            this.lblNgay.Text = "Ngày";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(190, 25);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(268, 26);
            this.dtpNgay.TabIndex = 1;
            // 
            // btnTinhtp
            // 
            this.btnTinhtp.Location = new System.Drawing.Point(523, 30);
            this.btnTinhtp.Name = "btnTinhtp";
            this.btnTinhtp.Size = new System.Drawing.Size(133, 65);
            this.btnTinhtp.TabIndex = 2;
            this.btnTinhtp.Text = "Tính thực phẩm";
            this.btnTinhtp.UseVisualStyleBackColor = true;
            // 
            // btnbaocao
            // 
            this.btnbaocao.Location = new System.Drawing.Point(399, 450);
            this.btnbaocao.Name = "btnbaocao";
            this.btnbaocao.Size = new System.Drawing.Size(148, 26);
            this.btnbaocao.TabIndex = 3;
            this.btnbaocao.Text = "Xuất báo cáo";
            this.btnbaocao.UseVisualStyleBackColor = true;
            this.btnbaocao.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(69, 72);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 4;
            this.lblbuoi.Text = "Buổi";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sáng ",
            "Trưa",
            "Chiều"});
            this.comboBox1.Location = new System.Drawing.Point(190, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colthucpham,
            this.colDonvi,
            this.colTongsoluong,
            this.colTonggiatien});
            this.dataGridView1.Location = new System.Drawing.Point(36, 162);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(687, 254);
            this.dataGridView1.TabIndex = 6;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 70;
            // 
            // colthucpham
            // 
            this.colthucpham.HeaderText = "Thực phẩm";
            this.colthucpham.MinimumWidth = 8;
            this.colthucpham.Name = "colthucpham";
            this.colthucpham.Width = 150;
            // 
            // colDonvi
            // 
            this.colDonvi.HeaderText = "Đơn vị";
            this.colDonvi.MinimumWidth = 8;
            this.colDonvi.Name = "colDonvi";
            this.colDonvi.Width = 150;
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
            this.colTonggiatien.Width = 150;
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(190, 450);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(148, 26);
            this.btnluu.TabIndex = 7;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            // 
            // frmtinhtpcansudung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(785, 501);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblbuoi);
            this.Controls.Add(this.btnbaocao);
            this.Controls.Add(this.btnTinhtp);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.lblNgay);
            this.Name = "frmtinhtpcansudung";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtinhtpcansudung";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnTinhtp;
        private System.Windows.Forms.Button btnbaocao;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colthucpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongsoluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonggiatien;
        private System.Windows.Forms.Button btnluu;
    }
}