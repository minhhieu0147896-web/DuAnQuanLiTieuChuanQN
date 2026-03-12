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
            this.cbochedo = new System.Windows.Forms.ComboBox();
            this.lblchedo = new System.Windows.Forms.Label();
            this.btnluu = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.lbltennguoilap = new System.Windows.Forms.Label();
            this.lblnguoilap = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblngay = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnthem = new System.Windows.Forms.Button();
            this.cbomonan = new System.Windows.Forms.ComboBox();
            this.cboloai = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lbldsmonan = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenmon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaimon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuuthucdon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(831, 465);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbochedo
            // 
            this.cbochedo.FormattingEnabled = true;
            this.cbochedo.Location = new System.Drawing.Point(74, 125);
            this.cbochedo.Name = "cbochedo";
            this.cbochedo.Size = new System.Drawing.Size(119, 26);
            this.cbochedo.TabIndex = 8;
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(4, 125);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(59, 18);
            this.lblchedo.TabIndex = 7;
            this.lblchedo.Text = "Chế độ";
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnluu.Location = new System.Drawing.Point(74, 229);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(105, 38);
            this.btnluu.TabIndex = 6;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sáng ",
            "Trưa ",
            "Chiều"});
            this.comboBox1.Location = new System.Drawing.Point(74, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 5;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(4, 77);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 4;
            this.lblbuoi.Text = "Buổi";
            // 
            // lbltennguoilap
            // 
            this.lbltennguoilap.AutoSize = true;
            this.lbltennguoilap.Location = new System.Drawing.Point(134, 172);
            this.lbltennguoilap.Name = "lbltennguoilap";
            this.lbltennguoilap.Size = new System.Drawing.Size(50, 18);
            this.lbltennguoilap.TabIndex = 3;
            this.lbltennguoilap.Text = "label3";
            this.lbltennguoilap.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblnguoilap
            // 
            this.lblnguoilap.AutoSize = true;
            this.lblnguoilap.Location = new System.Drawing.Point(4, 172);
            this.lblnguoilap.Name = "lblnguoilap";
            this.lblnguoilap.Size = new System.Drawing.Size(83, 18);
            this.lblnguoilap.TabIndex = 2;
            this.lblnguoilap.Text = "Người lập:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(74, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // lblngay
            // 
            this.lblngay.AutoSize = true;
            this.lblngay.Location = new System.Drawing.Point(4, 22);
            this.lblngay.Name = "lblngay";
            this.lblngay.Size = new System.Drawing.Size(44, 18);
            this.lblngay.TabIndex = 0;
            this.lblngay.Text = "Ngày";
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
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(495, 465);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnthem
            // 
            this.btnthem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnthem.Location = new System.Drawing.Point(368, 32);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(89, 46);
            this.btnthem.TabIndex = 4;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            // 
            // cbomonan
            // 
            this.cbomonan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbomonan.FormattingEnabled = true;
            this.cbomonan.Location = new System.Drawing.Point(174, 66);
            this.cbomonan.Name = "cbomonan";
            this.cbomonan.Size = new System.Drawing.Size(145, 26);
            this.cbomonan.TabIndex = 3;
            this.cbomonan.SelectedIndexChanged += new System.EventHandler(this.cbomonan_SelectedIndexChanged);
            // 
            // cboloai
            // 
            this.cboloai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboloai.FormattingEnabled = true;
            this.cboloai.Location = new System.Drawing.Point(174, 12);
            this.cboloai.Name = "cboloai";
            this.cboloai.Size = new System.Drawing.Size(145, 26);
            this.cboloai.TabIndex = 2;
            // 
            // lblLoai
            // 
            this.lblLoai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(21, 32);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(39, 18);
            this.lblLoai.TabIndex = 1;
            this.lblLoai.Text = "Loại";
            // 
            // lbldsmonan
            // 
            this.lbldsmonan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldsmonan.AutoSize = true;
            this.lbldsmonan.Location = new System.Drawing.Point(4, 69);
            this.lbldsmonan.Name = "lbldsmonan";
            this.lbldsmonan.Size = new System.Drawing.Size(137, 18);
            this.lbldsmonan.TabIndex = 0;
            this.lbldsmonan.Text = "Danh sách món ăn";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnLuuthucdon, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(495, 351);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenmon,
            this.colLoaimon});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(489, 259);
            this.dataGridView1.TabIndex = 1;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            // 
            // colTenmon
            // 
            this.colTenmon.HeaderText = "Tên món";
            this.colTenmon.MinimumWidth = 8;
            this.colTenmon.Name = "colTenmon";
            // 
            // colLoaimon
            // 
            this.colLoaimon.HeaderText = "Loại món";
            this.colLoaimon.MinimumWidth = 8;
            this.colLoaimon.Name = "colLoaimon";
            // 
            // btnLuuthucdon
            // 
            this.btnLuuthucdon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLuuthucdon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLuuthucdon.Location = new System.Drawing.Point(188, 292);
            this.btnLuuthucdon.Name = "btnLuuthucdon";
            this.btnLuuthucdon.Size = new System.Drawing.Size(119, 32);
            this.btnLuuthucdon.TabIndex = 2;
            this.btnLuuthucdon.Text = "Lưu thực đơn";
            this.btnLuuthucdon.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.cbochedo);
            this.panel1.Controls.Add(this.lblchedo);
            this.panel1.Controls.Add(this.btnluu);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lblbuoi);
            this.panel1.Controls.Add(this.lbltennguoilap);
            this.panel1.Controls.Add(this.lblnguoilap);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lblngay);
            this.panel1.Location = new System.Drawing.Point(23, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 297);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnthem);
            this.panel2.Controls.Add(this.cbomonan);
            this.panel2.Controls.Add(this.cboloai);
            this.panel2.Controls.Add(this.lblLoai);
            this.panel2.Controls.Add(this.lbldsmonan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 110);
            this.panel2.TabIndex = 5;
            // 
            // frmlapthucdon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(831, 465);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmlapthucdon";
            this.Text = "frmlapthucdon";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnLuuthucdon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenmon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaimon;
    }
}