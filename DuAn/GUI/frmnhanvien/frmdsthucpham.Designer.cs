namespace frmnhanvien
{
    partial class frmdsthucpham
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
            this.lbltentp = new System.Windows.Forms.Label();
            this.lbldvt = new System.Windows.Forms.Label();
            this.lbldstp = new System.Windows.Forms.Label();
            this.lblgiatien = new System.Windows.Forms.Label();
            this.lblnangluong = new System.Windows.Forms.Label();
            this.lblprotein = new System.Windows.Forms.Label();
            this.btnthem = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txttenthucpham = new System.Windows.Forms.TextBox();
            this.txtdonvi = new System.Windows.Forms.TextBox();
            this.txtgia = new System.Windows.Forms.TextBox();
            this.txtnangluong = new System.Windows.Forms.TextBox();
            this.txtprotein = new System.Windows.Forms.TextBox();
            this.lbllipid = new System.Windows.Forms.Label();
            this.txtlipid = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonvitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgiatien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colkcal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colprotein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collipit = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtlipid);
            this.splitContainer1.Panel1.Controls.Add(this.lbllipid);
            this.splitContainer1.Panel1.Controls.Add(this.txtprotein);
            this.splitContainer1.Panel1.Controls.Add(this.txtnangluong);
            this.splitContainer1.Panel1.Controls.Add(this.txtgia);
            this.splitContainer1.Panel1.Controls.Add(this.txtdonvi);
            this.splitContainer1.Panel1.Controls.Add(this.txttenthucpham);
            this.splitContainer1.Panel1.Controls.Add(this.btntimkiem);
            this.splitContainer1.Panel1.Controls.Add(this.btnxoa);
            this.splitContainer1.Panel1.Controls.Add(this.btnsua);
            this.splitContainer1.Panel1.Controls.Add(this.btnthem);
            this.splitContainer1.Panel1.Controls.Add(this.lblprotein);
            this.splitContainer1.Panel1.Controls.Add(this.lblnangluong);
            this.splitContainer1.Panel1.Controls.Add(this.lblgiatien);
            this.splitContainer1.Panel1.Controls.Add(this.lbldvt);
            this.splitContainer1.Panel1.Controls.Add(this.lbltentp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.lbldstp);
            this.splitContainer1.Size = new System.Drawing.Size(1078, 644);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbltentp
            // 
            this.lbltentp.AutoSize = true;
            this.lbltentp.Location = new System.Drawing.Point(5, 50);
            this.lbltentp.Name = "lbltentp";
            this.lbltentp.Size = new System.Drawing.Size(112, 18);
            this.lbltentp.TabIndex = 0;
            this.lbltentp.Text = "Tên thực phẩm";
            // 
            // lbldvt
            // 
            this.lbldvt.AutoSize = true;
            this.lbldvt.Location = new System.Drawing.Point(5, 84);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(81, 18);
            this.lbldvt.TabIndex = 1;
            this.lbldvt.Text = "Đơn vị tính";
            // 
            // lbldstp
            // 
            this.lbldstp.AutoSize = true;
            this.lbldstp.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldstp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbldstp.Location = new System.Drawing.Point(105, 39);
            this.lbldstp.Name = "lbldstp";
            this.lbldstp.Size = new System.Drawing.Size(311, 33);
            this.lbldstp.TabIndex = 0;
            this.lbldstp.Text = "Danh sách thực phẩm";
            // 
            // lblgiatien
            // 
            this.lblgiatien.AutoSize = true;
            this.lblgiatien.Location = new System.Drawing.Point(5, 135);
            this.lblgiatien.Name = "lblgiatien";
            this.lblgiatien.Size = new System.Drawing.Size(62, 18);
            this.lblgiatien.TabIndex = 2;
            this.lblgiatien.Text = "Giá tiền";
            // 
            // lblnangluong
            // 
            this.lblnangluong.AutoSize = true;
            this.lblnangluong.Location = new System.Drawing.Point(5, 182);
            this.lblnangluong.Name = "lblnangluong";
            this.lblnangluong.Size = new System.Drawing.Size(91, 18);
            this.lblnangluong.TabIndex = 3;
            this.lblnangluong.Text = "Năng lượng";
            // 
            // lblprotein
            // 
            this.lblprotein.AutoSize = true;
            this.lblprotein.Location = new System.Drawing.Point(9, 228);
            this.lblprotein.Name = "lblprotein";
            this.lblprotein.Size = new System.Drawing.Size(58, 18);
            this.lblprotein.TabIndex = 4;
            this.lblprotein.Text = "Protein";
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(33, 373);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(94, 23);
            this.btnthem.TabIndex = 11;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(153, 373);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(94, 23);
            this.btnsua.TabIndex = 12;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(33, 431);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(94, 23);
            this.btnxoa.TabIndex = 13;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(153, 431);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(94, 23);
            this.btntimkiem.TabIndex = 14;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            // 
            // txttenthucpham
            // 
            this.txttenthucpham.Location = new System.Drawing.Point(123, 42);
            this.txttenthucpham.Name = "txttenthucpham";
            this.txttenthucpham.Size = new System.Drawing.Size(148, 26);
            this.txttenthucpham.TabIndex = 15;
            // 
            // txtdonvi
            // 
            this.txtdonvi.Location = new System.Drawing.Point(122, 84);
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.Size = new System.Drawing.Size(148, 26);
            this.txtdonvi.TabIndex = 16;
            // 
            // txtgia
            // 
            this.txtgia.Location = new System.Drawing.Point(123, 127);
            this.txtgia.Name = "txtgia";
            this.txtgia.Size = new System.Drawing.Size(148, 26);
            this.txtgia.TabIndex = 17;
            // 
            // txtnangluong
            // 
            this.txtnangluong.Location = new System.Drawing.Point(123, 179);
            this.txtnangluong.Name = "txtnangluong";
            this.txtnangluong.Size = new System.Drawing.Size(148, 26);
            this.txtnangluong.TabIndex = 18;
            // 
            // txtprotein
            // 
            this.txtprotein.Location = new System.Drawing.Point(123, 228);
            this.txtprotein.Name = "txtprotein";
            this.txtprotein.Size = new System.Drawing.Size(148, 26);
            this.txtprotein.TabIndex = 19;
            // 
            // lbllipid
            // 
            this.lbllipid.AutoSize = true;
            this.lbllipid.Location = new System.Drawing.Point(12, 282);
            this.lbllipid.Name = "lbllipid";
            this.lbllipid.Size = new System.Drawing.Size(43, 18);
            this.lbllipid.TabIndex = 20;
            this.lbllipid.Text = "Lipid";
            // 
            // txtlipid
            // 
            this.txtlipid.Location = new System.Drawing.Point(122, 282);
            this.txtlipid.Name = "txtlipid";
            this.txtlipid.Size = new System.Drawing.Size(149, 26);
            this.txtlipid.TabIndex = 21;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colTenTP,
            this.colDonvitinh,
            this.colgiatien,
            this.colkcal,
            this.colprotein,
            this.collipit});
            this.dataGridView1.Location = new System.Drawing.Point(22, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(712, 322);
            this.dataGridView1.TabIndex = 1;
            // 
            // colSTT
            // 
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 8;
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 70;
            // 
            // colTenTP
            // 
            this.colTenTP.HeaderText = "Tên Thực Phẩm";
            this.colTenTP.MinimumWidth = 8;
            this.colTenTP.Name = "colTenTP";
            this.colTenTP.Width = 170;
            // 
            // colDonvitinh
            // 
            this.colDonvitinh.HeaderText = "Đơn vị tính";
            this.colDonvitinh.MinimumWidth = 8;
            this.colDonvitinh.Name = "colDonvitinh";
            this.colDonvitinh.Width = 70;
            // 
            // colgiatien
            // 
            this.colgiatien.HeaderText = "Giá tiền";
            this.colgiatien.MinimumWidth = 8;
            this.colgiatien.Name = "colgiatien";
            // 
            // colkcal
            // 
            this.colkcal.HeaderText = "kcal";
            this.colkcal.MinimumWidth = 8;
            this.colkcal.Name = "colkcal";
            this.colkcal.Width = 80;
            // 
            // colprotein
            // 
            this.colprotein.HeaderText = "Protein";
            this.colprotein.MinimumWidth = 8;
            this.colprotein.Name = "colprotein";
            this.colprotein.Width = 80;
            // 
            // collipit
            // 
            this.collipit.HeaderText = "Lipit";
            this.collipit.MinimumWidth = 8;
            this.collipit.Name = "collipit";
            this.collipit.Width = 80;
            // 
            // frmdsthucpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1078, 644);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmdsthucpham";
            this.Text = "Danh sách thực phẩm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label lblprotein;
        private System.Windows.Forms.Label lblnangluong;
        private System.Windows.Forms.Label lblgiatien;
        private System.Windows.Forms.Label lbldvt;
        private System.Windows.Forms.Label lbltentp;
        private System.Windows.Forms.Label lbldstp;
        private System.Windows.Forms.TextBox txtprotein;
        private System.Windows.Forms.TextBox txtnangluong;
        private System.Windows.Forms.TextBox txtgia;
        private System.Windows.Forms.TextBox txtdonvi;
        private System.Windows.Forms.TextBox txttenthucpham;
        private System.Windows.Forms.Label lbllipid;
        private System.Windows.Forms.TextBox txtlipid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonvitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgiatien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colkcal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colprotein;
        private System.Windows.Forms.DataGridViewTextBoxColumn collipit;
    }
}