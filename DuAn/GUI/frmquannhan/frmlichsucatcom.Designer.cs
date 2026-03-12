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
            this.lbltungay = new System.Windows.Forms.Label();
            this.lbldenngay = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btntracuu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collydo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbltongtiencat = new System.Windows.Forms.Label();
            this.lblhienthitiencat = new System.Windows.Forms.Label();
            this.lbltieude = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltungay
            // 
            this.lbltungay.AutoSize = true;
            this.lbltungay.Location = new System.Drawing.Point(210, 84);
            this.lbltungay.Name = "lbltungay";
            this.lbltungay.Size = new System.Drawing.Size(65, 18);
            this.lbltungay.TabIndex = 0;
            this.lbltungay.Text = "Từ ngày";
            // 
            // lbldenngay
            // 
            this.lbldenngay.AutoSize = true;
            this.lbldenngay.Location = new System.Drawing.Point(210, 122);
            this.lbldenngay.Name = "lbldenngay";
            this.lbldenngay.Size = new System.Drawing.Size(74, 18);
            this.lbldenngay.TabIndex = 1;
            this.lbldenngay.Text = "Đến ngày";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(354, 76);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(354, 122);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // btntracuu
            // 
            this.btntracuu.Location = new System.Drawing.Point(646, 76);
            this.btntracuu.Name = "btntracuu";
            this.btntracuu.Size = new System.Drawing.Size(98, 40);
            this.btntracuu.TabIndex = 4;
            this.btntracuu.Text = "Tra cứu";
            this.btntracuu.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colNgay,
            this.colBuoi,
            this.collydo,
            this.coltien});
            this.dataGridView1.Location = new System.Drawing.Point(35, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(812, 215);
            this.dataGridView1.TabIndex = 5;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 150;
            // 
            // colNgay
            // 
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.MinimumWidth = 8;
            this.colNgay.Name = "colNgay";
            this.colNgay.Width = 150;
            // 
            // colBuoi
            // 
            this.colBuoi.HeaderText = "Buổi";
            this.colBuoi.MinimumWidth = 8;
            this.colBuoi.Name = "colBuoi";
            this.colBuoi.Width = 150;
            // 
            // collydo
            // 
            this.collydo.HeaderText = "Lý do";
            this.collydo.MinimumWidth = 8;
            this.collydo.Name = "collydo";
            this.collydo.Width = 150;
            // 
            // coltien
            // 
            this.coltien.HeaderText = "Tiền cắt cơm";
            this.coltien.MinimumWidth = 8;
            this.coltien.Name = "coltien";
            this.coltien.Width = 150;
            // 
            // lbltongtiencat
            // 
            this.lbltongtiencat.AutoSize = true;
            this.lbltongtiencat.Location = new System.Drawing.Point(322, 436);
            this.lbltongtiencat.Name = "lbltongtiencat";
            this.lbltongtiencat.Size = new System.Drawing.Size(133, 18);
            this.lbltongtiencat.TabIndex = 6;
            this.lbltongtiencat.Text = "Tổng tiền cắt cơm";
            // 
            // lblhienthitiencat
            // 
            this.lblhienthitiencat.AutoSize = true;
            this.lblhienthitiencat.Location = new System.Drawing.Point(504, 436);
            this.lblhienthitiencat.Name = "lblhienthitiencat";
            this.lblhienthitiencat.Size = new System.Drawing.Size(50, 18);
            this.lblhienthitiencat.TabIndex = 7;
            this.lblhienthitiencat.Text = "label1";
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbltieude.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.Location = new System.Drawing.Point(319, 22);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(235, 33);
            this.lbltieude.TabIndex = 8;
            this.lbltieude.Text = "Lịch sử cắt cơm";
            // 
            // frmlichsucatcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(916, 493);
            this.Controls.Add(this.lbltieude);
            this.Controls.Add(this.lblhienthitiencat);
            this.Controls.Add(this.lbltongtiencat);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btntracuu);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lbldenngay);
            this.Controls.Add(this.lbltungay);
            this.Name = "frmlichsucatcom";
            this.Text = "Lịch sử cắt cơm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltungay;
        private System.Windows.Forms.Label lbldenngay;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btntracuu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn collydo;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltien;
        private System.Windows.Forms.Label lbltongtiencat;
        private System.Windows.Forms.Label lblhienthitiencat;
        private System.Windows.Forms.Label lbltieude;
    }
}