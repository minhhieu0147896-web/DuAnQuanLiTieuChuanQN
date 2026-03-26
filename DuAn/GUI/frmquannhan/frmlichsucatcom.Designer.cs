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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collydo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltieude = new System.Windows.Forms.Label();
            this.btntracuu = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lbldenngay = new System.Windows.Forms.Label();
            this.lbltungay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblhienthitiencat = new System.Windows.Forms.Label();
            this.lbltongtiencat = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 296F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(916, 493);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colNgay,
            this.colBuoi,
            this.collydo,
            this.coltien});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(910, 290);
            this.dataGridView1.TabIndex = 6;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            // 
            // colNgay
            // 
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.MinimumWidth = 8;
            this.colNgay.Name = "colNgay";
            // 
            // colBuoi
            // 
            this.colBuoi.HeaderText = "Buổi";
            this.colBuoi.MinimumWidth = 8;
            this.colBuoi.Name = "colBuoi";
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.lbltieude);
            this.panel1.Controls.Add(this.btntracuu);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lbldenngay);
            this.panel1.Controls.Add(this.lbltungay);
            this.panel1.Location = new System.Drawing.Point(156, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 147);
            this.panel1.TabIndex = 11;
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbltieude.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.Location = new System.Drawing.Point(144, 9);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(235, 33);
            this.lbltieude.TabIndex = 8;
            this.lbltieude.Text = "Lịch sử cắt cơm";
            // 
            // btntracuu
            // 
            this.btntracuu.Location = new System.Drawing.Point(471, 63);
            this.btntracuu.Name = "btntracuu";
            this.btntracuu.Size = new System.Drawing.Size(98, 40);
            this.btntracuu.TabIndex = 4;
            this.btntracuu.Text = "Tra cứu";
            this.btntracuu.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(179, 109);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(179, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // lbldenngay
            // 
            this.lbldenngay.AutoSize = true;
            this.lbldenngay.Location = new System.Drawing.Point(35, 109);
            this.lbldenngay.Name = "lbldenngay";
            this.lbldenngay.Size = new System.Drawing.Size(74, 18);
            this.lbldenngay.TabIndex = 1;
            this.lbldenngay.Text = "Đến ngày";
            // 
            // lbltungay
            // 
            this.lbltungay.AutoSize = true;
            this.lbltungay.Location = new System.Drawing.Point(35, 71);
            this.lbltungay.Name = "lbltungay";
            this.lbltungay.Size = new System.Drawing.Size(65, 18);
            this.lbltungay.TabIndex = 0;
            this.lbltungay.Text = "Từ ngày";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.lblhienthitiencat);
            this.panel2.Controls.Add(this.lbltongtiencat);
            this.panel2.Location = new System.Drawing.Point(295, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(325, 38);
            this.panel2.TabIndex = 12;
            // 
            // lblhienthitiencat
            // 
            this.lblhienthitiencat.AutoSize = true;
            this.lblhienthitiencat.Location = new System.Drawing.Point(193, 18);
            this.lblhienthitiencat.Name = "lblhienthitiencat";
            this.lblhienthitiencat.Size = new System.Drawing.Size(50, 18);
            this.lblhienthitiencat.TabIndex = 7;
            this.lblhienthitiencat.Text = "label1";
            // 
            // lbltongtiencat
            // 
            this.lbltongtiencat.AutoSize = true;
            this.lbltongtiencat.Location = new System.Drawing.Point(11, 18);
            this.lbltongtiencat.Name = "lbltongtiencat";
            this.lbltongtiencat.Size = new System.Drawing.Size(133, 18);
            this.lbltongtiencat.TabIndex = 6;
            this.lbltongtiencat.Text = "Tổng tiền cắt cơm";
            // 
            // frmlichsucatcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(916, 493);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmlichsucatcom";
            this.Text = "Lịch sử cắt cơm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblhienthitiencat;
        private System.Windows.Forms.Label lbltongtiencat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.Button btntracuu;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lbldenngay;
        private System.Windows.Forms.Label lbltungay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn collydo;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltien;
    }
}