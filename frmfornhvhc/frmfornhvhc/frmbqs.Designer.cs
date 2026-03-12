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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenQN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchucvu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colchedo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colkhongan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.collydo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quanlitieuchuanQNDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quan_li_tieu_chuan_QNDataSet = new frmfornhvhc.Quan_li_tieu_chuan_QNDataSet();
            this.btnsave = new System.Windows.Forms.Button();
            this.cbobuoi = new System.Windows.Forms.ComboBox();
            this.lblbuoi = new System.Windows.Forms.Label();
            this.cbodonvi = new System.Windows.Forms.ComboBox();
            this.lbldv = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.quannhanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quan_nhanTableAdapter = new frmfornhvhc.Quan_li_tieu_chuan_QNDataSetTableAdapters.Quan_nhanTableAdapter();
            this.quanlitieuchuanQNDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlitieuchuanQNDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quan_li_tieu_chuan_QNDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quannhanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlitieuchuanQNDataSetBindingSource1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.btnsave);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.cbobuoi);
            this.splitContainer1.Panel2.Controls.Add(this.lblbuoi);
            this.splitContainer1.Panel2.Controls.Add(this.cbodonvi);
            this.splitContainer1.Panel2.Controls.Add(this.lbldv);
            this.splitContainer1.Panel2.Controls.Add(this.lbldate);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Size = new System.Drawing.Size(1321, 527);
            this.splitContainer1.SplitterDistance = 790;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenQN,
            this.colchucvu,
            this.colchedo,
            this.colAn,
            this.colkhongan,
            this.collydo});
            this.dataGridView1.DataSource = this.quanlitieuchuanQNDataSetBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(733, 356);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_2);
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 50;
            // 
            // colTenQN
            // 
            this.colTenQN.DataPropertyName = "quannhan_hoten";
            this.colTenQN.HeaderText = "Tên Quân Nhân";
            this.colTenQN.MinimumWidth = 8;
            this.colTenQN.Name = "colTenQN";
            this.colTenQN.Width = 200;
            // 
            // colchucvu
            // 
            this.colchucvu.DataPropertyName = "quannhan_chucvu";
            this.colchucvu.HeaderText = "Chức vụ";
            this.colchucvu.MinimumWidth = 8;
            this.colchucvu.Name = "colchucvu";
            this.colchucvu.Width = 150;
            // 
            // colchedo
            // 
            this.colchedo.DataPropertyName = "chedo_ten";
            this.colchedo.HeaderText = "Chế độ";
            this.colchedo.MinimumWidth = 8;
            this.colchedo.Name = "colchedo";
            this.colchedo.Width = 150;
            // 
            // colAn
            // 
            this.colAn.HeaderText = "Ăn";
            this.colAn.MinimumWidth = 8;
            this.colAn.Name = "colAn";
            this.colAn.Width = 50;
            // 
            // colkhongan
            // 
            this.colkhongan.HeaderText = "Không ăn";
            this.colkhongan.MinimumWidth = 8;
            this.colkhongan.Name = "colkhongan";
            this.colkhongan.Width = 70;
            // 
            // collydo
            // 
            this.collydo.HeaderText = "Lý do";
            this.collydo.MinimumWidth = 8;
            this.collydo.Name = "collydo";
            this.collydo.Width = 150;
            // 
            // quanlitieuchuanQNDataSetBindingSource
            // 
            this.quanlitieuchuanQNDataSetBindingSource.DataSource = this.quan_li_tieu_chuan_QNDataSet;
            this.quanlitieuchuanQNDataSetBindingSource.Position = 0;
            // 
            // quan_li_tieu_chuan_QNDataSet
            // 
            this.quan_li_tieu_chuan_QNDataSet.DataSetName = "Quan_li_tieu_chuan_QNDataSet";
            this.quan_li_tieu_chuan_QNDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnsave.Location = new System.Drawing.Point(348, 436);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(134, 30);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Lưu quân số";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbobuoi
            // 
            this.cbobuoi.FormattingEnabled = true;
            this.cbobuoi.Items.AddRange(new object[] {
            "Sáng",
            "Trưa",
            "Chiều"});
            this.cbobuoi.Location = new System.Drawing.Point(109, 88);
            this.cbobuoi.Name = "cbobuoi";
            this.cbobuoi.Size = new System.Drawing.Size(121, 26);
            this.cbobuoi.TabIndex = 5;
            // 
            // lblbuoi
            // 
            this.lblbuoi.AutoSize = true;
            this.lblbuoi.Location = new System.Drawing.Point(21, 88);
            this.lblbuoi.Name = "lblbuoi";
            this.lblbuoi.Size = new System.Drawing.Size(40, 18);
            this.lblbuoi.TabIndex = 4;
            this.lblbuoi.Text = "Buổi";
            this.lblbuoi.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbodonvi
            // 
            this.cbodonvi.FormattingEnabled = true;
            this.cbodonvi.Items.AddRange(new object[] {
            "c1",
            "c2",
            "c3"});
            this.cbodonvi.Location = new System.Drawing.Point(109, 170);
            this.cbodonvi.Name = "cbodonvi";
            this.cbodonvi.Size = new System.Drawing.Size(121, 26);
            this.cbodonvi.TabIndex = 3;
            this.cbodonvi.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbldv
            // 
            this.lbldv.AutoSize = true;
            this.lbldv.Location = new System.Drawing.Point(21, 178);
            this.lbldv.Name = "lbldv";
            this.lbldv.Size = new System.Drawing.Size(62, 18);
            this.lbldv.TabIndex = 2;
            this.lbldv.Text = "Đơn vị: ";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(21, 134);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(82, 18);
            this.lbldate.TabIndex = 1;
            this.lbldate.Text = "Ngày nhập";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(109, 128);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 26);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // quannhanBindingSource
            // 
            this.quannhanBindingSource.DataMember = "Quan_nhan";
            this.quannhanBindingSource.DataSource = this.quan_li_tieu_chuan_QNDataSet;
            // 
            // quan_nhanTableAdapter
            // 
            this.quan_nhanTableAdapter.ClearBeforeFill = true;
            // 
            // quanlitieuchuanQNDataSetBindingSource1
            // 
            this.quanlitieuchuanQNDataSetBindingSource1.DataSource = this.quan_li_tieu_chuan_QNDataSet;
            this.quanlitieuchuanQNDataSetBindingSource1.Position = 0;
            // 
            // frmbqs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1321, 527);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmbqs";
            this.Text = "frmbqs";
            this.Load += new System.EventHandler(this.frmbqs_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlitieuchuanQNDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quan_li_tieu_chuan_QNDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quannhanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanlitieuchuanQNDataSetBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbodonvi;
        private System.Windows.Forms.Label lbldv;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Quan_li_tieu_chuan_QNDataSet quan_li_tieu_chuan_QNDataSet;
        private System.Windows.Forms.BindingSource quannhanBindingSource;
        private Quan_li_tieu_chuan_QNDataSetTableAdapters.Quan_nhanTableAdapter quan_nhanTableAdapter;
        private System.Windows.Forms.BindingSource quanlitieuchuanQNDataSetBindingSource;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblbuoi;
        private System.Windows.Forms.ComboBox cbobuoi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource quanlitieuchuanQNDataSetBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenQN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchucvu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colchedo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colkhongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn collydo;
    }
}