namespace frmnhanvien
{
    partial class frmlapthucdon
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
            this.lblngay = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblnguoilap = new System.Windows.Forms.Label();
            this.lbltennguoilap = new System.Windows.Forms.Label();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnluu = new System.Windows.Forms.Button();
            this.lblchedo = new System.Windows.Forms.Label();
            this.cbochedo = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbldsmonan = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboloai = new System.Windows.Forms.ComboBox();
            this.cbomonan = new System.Windows.Forms.ComboBox();
            this.btnthem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenmon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaimon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuuthucdon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.cbochedo);
            this.splitContainer1.Panel1.Controls.Add(this.lblchedo);
            this.splitContainer1.Panel1.Controls.Add(this.btnluu);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblbuoi);
            this.splitContainer1.Panel1.Controls.Add(this.lbltennguoilap);
            this.splitContainer1.Panel1.Controls.Add(this.lblnguoilap);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.lblngay);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(831, 465);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblngay
            // 
            this.lblngay.AutoSize = true;
            this.lblngay.Location = new System.Drawing.Point(12, 100);
            this.lblngay.Name = "lblngay";
            this.lblngay.Size = new System.Drawing.Size(44, 18);
            this.lblngay.TabIndex = 0;
            this.lblngay.Text = "Ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // lblnguoilap
            // 
            this.lblnguoilap.AutoSize = true;
            this.lblnguoilap.Location = new System.Drawing.Point(12, 250);
            this.lblnguoilap.Name = "lblnguoilap";
            this.lblnguoilap.Size = new System.Drawing.Size(83, 18);
            this.lblnguoilap.TabIndex = 2;
            this.lblnguoilap.Text = "Người lập:";
            // 
            // lbltennguoilap
            // 
            this.lbltennguoilap.AutoSize = true;
            this.lbltennguoilap.Location = new System.Drawing.Point(142, 250);
            this.lbltennguoilap.Name = "lbltennguoilap";
            this.lbltennguoilap.Size = new System.Drawing.Size(50, 18);
            this.lbltennguoilap.TabIndex = 3;
            this.lbltennguoilap.Text = "label3";
            this.lbltennguoilap.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(12, 155);
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
            "Trưa ",
            "Chiều"});
            this.comboBox1.Location = new System.Drawing.Point(82, 155);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnluu.Location = new System.Drawing.Point(82, 307);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(105, 38);
            this.btnluu.TabIndex = 6;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(12, 203);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(59, 18);
            this.lblchedo.TabIndex = 7;
            this.lblchedo.Text = "Chế độ";
            // 
            // cbochedo
            // 
            this.cbochedo.FormattingEnabled = true;
            this.cbochedo.Location = new System.Drawing.Point(82, 203);
            this.cbochedo.Name = "cbochedo";
            this.cbochedo.Size = new System.Drawing.Size(119, 26);
            this.cbochedo.TabIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnthem);
            this.splitContainer2.Panel1.Controls.Add(this.cbomonan);
            this.splitContainer2.Panel1.Controls.Add(this.cboloai);
            this.splitContainer2.Panel1.Controls.Add(this.lblLoai);
            this.splitContainer2.Panel1.Controls.Add(this.lbldsmonan);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnLuuthucdon);
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(495, 465);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbldsmonan
            // 
            this.lbldsmonan.AutoSize = true;
            this.lbldsmonan.Location = new System.Drawing.Point(20, 63);
            this.lbldsmonan.Name = "lbldsmonan";
            this.lbldsmonan.Size = new System.Drawing.Size(137, 18);
            this.lbldsmonan.TabIndex = 0;
            this.lbldsmonan.Text = "Danh sách món ăn";
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(20, 27);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(39, 18);
            this.lblLoai.TabIndex = 1;
            this.lblLoai.Text = "Loại";
            // 
            // cboloai
            // 
            this.cboloai.FormattingEnabled = true;
            this.cboloai.Location = new System.Drawing.Point(163, 24);
            this.cboloai.Name = "cboloai";
            this.cboloai.Size = new System.Drawing.Size(145, 26);
            this.cboloai.TabIndex = 2;
            // 
            // cbomonan
            // 
            this.cbomonan.FormattingEnabled = true;
            this.cbomonan.Location = new System.Drawing.Point(163, 63);
            this.cbomonan.Name = "cbomonan";
            this.cbomonan.Size = new System.Drawing.Size(145, 26);
            this.cbomonan.TabIndex = 3;
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(346, 34);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(89, 46);
            this.btnthem.TabIndex = 4;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenmon,
            this.colLoaimon});
            this.dataGridView1.Location = new System.Drawing.Point(23, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(434, 255);
            this.dataGridView1.TabIndex = 0;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 70;
            // 
            // colTenmon
            // 
            this.colTenmon.HeaderText = "Tên món";
            this.colTenmon.MinimumWidth = 8;
            this.colTenmon.Name = "colTenmon";
            this.colTenmon.Width = 150;
            // 
            // colLoaimon
            // 
            this.colLoaimon.HeaderText = "Loại món";
            this.colLoaimon.MinimumWidth = 8;
            this.colLoaimon.Name = "colLoaimon";
            this.colLoaimon.Width = 150;
            // 
            // btnLuuthucdon
            // 
            this.btnLuuthucdon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLuuthucdon.Location = new System.Drawing.Point(176, 298);
            this.btnLuuthucdon.Name = "btnLuuthucdon";
            this.btnLuuthucdon.Size = new System.Drawing.Size(119, 32);
            this.btnLuuthucdon.TabIndex = 1;
            this.btnLuuthucdon.Text = "Lưu thực đơn";
            this.btnLuuthucdon.UseVisualStyleBackColor = false;
            // 
            // frmlapthucdon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(831, 465);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmlapthucdon";
            this.Text = "frmlapthucdon";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.Label lbltennguoilap;
        private System.Windows.Forms.Label lblnguoilap;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblngay;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.ComboBox cbochedo;
        private System.Windows.Forms.Label lblchedo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.ComboBox cbomonan;
        private System.Windows.Forms.ComboBox cboloai;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Label lbldsmonan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenmon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaimon;
        private System.Windows.Forms.Button btnLuuthucdon;
    }
}