namespace frmnhanvien
{
    partial class frmbaocaothucpham
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
            this.lblstart = new System.Windows.Forms.Label();
            this.lblend = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.lblchedo = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnxuatbaocao = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltentp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colloai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colsoluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnxuatbaocao);
            this.splitContainer1.Panel1.Controls.Add(this.btnluu);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblchedo);
            this.splitContainer1.Panel1.Controls.Add(this.lblbuoi);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.lblend);
            this.splitContainer1.Panel1.Controls.Add(this.lblstart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(850, 450);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblstart
            // 
            this.lblstart.AutoSize = true;
            this.lblstart.Location = new System.Drawing.Point(12, 56);
            this.lblstart.Name = "lblstart";
            this.lblstart.Size = new System.Drawing.Size(65, 18);
            this.lblstart.TabIndex = 0;
            this.lblstart.Text = "Từ ngày";
            // 
            // lblend
            // 
            this.lblend.AutoSize = true;
            this.lblend.Location = new System.Drawing.Point(12, 134);
            this.lblend.Name = "lblend";
            this.lblend.Size = new System.Drawing.Size(74, 18);
            this.lblend.TabIndex = 1;
            this.lblend.Text = "Đến ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(92, 56);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(92, 128);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(12, 199);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 4;
            this.lblbuoi.Text = "Buổi";
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(12, 258);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(59, 18);
            this.lblchedo.TabIndex = 5;
            this.lblchedo.Text = "Chế độ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(92, 196);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 6;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(92, 255);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 26);
            this.comboBox2.TabIndex = 7;
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(53, 317);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(84, 34);
            this.btnluu.TabIndex = 8;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            // 
            // btnxuatbaocao
            // 
            this.btnxuatbaocao.Location = new System.Drawing.Point(176, 316);
            this.btnxuatbaocao.Name = "btnxuatbaocao";
            this.btnxuatbaocao.Size = new System.Drawing.Size(84, 34);
            this.btnxuatbaocao.TabIndex = 9;
            this.btnxuatbaocao.Text = "Xuất";
            this.btnxuatbaocao.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colstart,
            this.colend,
            this.colbuoi,
            this.colchedo,
            this.coltentp,
            this.colloai,
            this.colsoluong,
            this.coltongtien});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(516, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 70;
            // 
            // colstart
            // 
            this.colstart.HeaderText = "Từ ngày ";
            this.colstart.MinimumWidth = 8;
            this.colstart.Name = "colstart";
            this.colstart.Width = 150;
            // 
            // colend
            // 
            this.colend.HeaderText = "Đến ngày";
            this.colend.MinimumWidth = 8;
            this.colend.Name = "colend";
            this.colend.Width = 150;
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
            // coltentp
            // 
            this.coltentp.HeaderText = "Thực phẩm";
            this.coltentp.MinimumWidth = 8;
            this.coltentp.Name = "coltentp";
            this.coltentp.Width = 150;
            // 
            // colloai
            // 
            this.colloai.HeaderText = "Loại";
            this.colloai.MinimumWidth = 8;
            this.colloai.Name = "colloai";
            // 
            // colsoluong
            // 
            this.colsoluong.HeaderText = "Số lượng";
            this.colsoluong.MinimumWidth = 8;
            this.colsoluong.Name = "colsoluong";
            // 
            // coltongtien
            // 
            this.coltongtien.HeaderText = "Tổng tiền";
            this.coltongtien.MinimumWidth = 8;
            this.coltongtien.Name = "coltongtien";
            // 
            // frmbaocaothucpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmbaocaothucpham";
            this.Text = "frmbaocaothucpham";
            this.Load += new System.EventHandler(this.frmbaocaothucpham_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnxuatbaocao;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblchedo;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblend;
        private System.Windows.Forms.Label lblstart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colend;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltentp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colloai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsoluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltongtien;
    }
}