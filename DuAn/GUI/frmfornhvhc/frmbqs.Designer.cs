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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchucvu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colkhongan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.collydo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnluu = new System.Windows.Forms.Button();
            this.lblhienthi = new System.Windows.Forms.Label();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblNgay = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblbuoi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1142, 450);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            // 
            // colten
            // 
            this.colten.HeaderText = "Tên quân nhân";
            this.colten.MinimumWidth = 8;
            this.colten.Name = "colten";
            // 
            // colchucvu
            // 
            this.colchucvu.HeaderText = "Chức vụ";
            this.colchucvu.MinimumWidth = 8;
            this.colchucvu.Name = "colchucvu";
            // 
            // colchedo
            // 
            this.colchedo.HeaderText = "Chế độ";
            this.colchedo.MinimumWidth = 8;
            this.colchedo.Name = "colchedo";
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
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.28042F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.71957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnluu);
            this.panel1.Controls.Add(this.lblhienthi);
            this.panel1.Controls.Add(this.lbldonvi);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lblNgay);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lblbuoi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 284);
            this.panel1.TabIndex = 8;
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnluu.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluu.Location = new System.Drawing.Point(99, 207);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(75, 37);
            this.btnluu.TabIndex = 9;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = false;
            // 
            // lblhienthi
            // 
            this.lblhienthi.AutoSize = true;
            this.lblhienthi.Location = new System.Drawing.Point(96, 162);
            this.lblhienthi.Name = "lblhienthi";
            this.lblhienthi.Size = new System.Drawing.Size(53, 18);
            this.lblhienthi.TabIndex = 8;
            this.lblhienthi.Text = "hienthi";
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Location = new System.Drawing.Point(36, 162);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(54, 18);
            this.lbldonvi.TabIndex = 7;
            this.lbldonvi.Text = "Đơn vị";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(99, 101);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 26);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(39, 101);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(44, 18);
            this.lblNgay.TabIndex = 5;
            this.lblNgay.Text = "Ngày";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sáng ",
            "Trưa",
            "Chiều"});
            this.comboBox1.Location = new System.Drawing.Point(99, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 4;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(39, 51);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 1;
            this.lblbuoi.Text = "Buổi";
            // 
            // frmbqs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1142, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmbqs";
            this.Text = "Báo quân số";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colten;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchucvu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colkhongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn collydo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Label lblhienthi;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblbuoi;
    }
}