namespace frmfornhvhc
{
    partial class frmbqs
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
            this.lblbuoi = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblhienthi = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchucvu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colkhongan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.collydo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnluu = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnluu);
            this.splitContainer1.Panel1.Controls.Add(this.lblhienthi);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lbldonvi);
            this.splitContainer1.Panel1.Controls.Add(this.lblNgay);
            this.splitContainer1.Panel1.Controls.Add(this.lblbuoi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1142, 450);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(28, 61);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 0;
            this.lblbuoi.Text = "Buổi";
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(28, 104);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(44, 18);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Ngày";
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(28, 149);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(54, 18);
            this.lbldonvi.TabIndex = 2;
            this.lbldonvi.Text = "Đơn vị";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sáng ",
            "Trưa",
            "Chiều"});
            this.comboBox1.Location = new System.Drawing.Point(84, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(84, 104);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // lblhienthi
            // 
            this.lblhienthi.AutoSize = true;
            this.lblhienthi.Location = new System.Drawing.Point(81, 149);
            this.lblhienthi.Name = "lblhienthi";
            this.lblhienthi.Size = new System.Drawing.Size(53, 18);
            this.lblhienthi.TabIndex = 5;
            this.lblhienthi.Text = "hienthi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colten,
            this.colchucvu,
            this.colchedo,
            this.colan,
            this.colkhongan,
            this.collydo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(848, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 70;
            // 
            // colten
            // 
            this.colten.HeaderText = "Tên quân nhân";
            this.colten.MinimumWidth = 8;
            this.colten.Name = "colten";
            this.colten.Width = 150;
            // 
            // colchucvu
            // 
            this.colchucvu.HeaderText = "Chức vụ";
            this.colchucvu.MinimumWidth = 8;
            this.colchucvu.Name = "colchucvu";
            this.colchucvu.Width = 150;
            // 
            // colchedo
            // 
            this.colchedo.HeaderText = "Chế độ";
            this.colchedo.MinimumWidth = 8;
            this.colchedo.Name = "colchedo";
            this.colchedo.Width = 150;
            // 
            // colan
            // 
            this.colan.HeaderText = "Ăn";
            this.colan.MinimumWidth = 8;
            this.colan.Name = "colan";
            // 
            // colkhongan
            // 
            this.colkhongan.HeaderText = "Không ăn";
            this.colkhongan.MinimumWidth = 8;
            this.colkhongan.Name = "colkhongan";
            // 
            // collydo
            // 
            this.collydo.HeaderText = "Lý do";
            this.collydo.MinimumWidth = 8;
            this.collydo.Name = "collydo";
            this.collydo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.collydo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.collydo.Width = 150;
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnluu.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluu.Location = new System.Drawing.Point(99, 236);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 37);
            this.btnluu.TabIndex = 6;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            // 
            // frmbqs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1142, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmbqs";
            this.Text = "Báo quân số";
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
        private System.Windows.Forms.Label lblhienthi;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colten;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchucvu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colkhongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn collydo;
        private System.Windows.Forms.Button btnluu;
    }
}