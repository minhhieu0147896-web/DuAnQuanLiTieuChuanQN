namespace DuAn.GUI.frmquannhan
{
    partial class frmtrangchu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtrangchu));
            this.pnltieude = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblhd = new System.Windows.Forms.Label();
            this.lbltieude = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnllsbqs = new System.Windows.Forms.Panel();
            this.btnclsbqs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbllsbqs = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbldonvi = new System.Windows.Forms.Label();
            this.lblchedo = new System.Windows.Forms.Label();
            this.pnltieude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnllsbqs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnltieude
            // 
            this.pnltieude.Controls.Add(this.lblchedo);
            this.pnltieude.Controls.Add(this.lbldonvi);
            this.pnltieude.Controls.Add(this.pictureBox3);
            this.pnltieude.Controls.Add(this.lblhd);
            this.pnltieude.Controls.Add(this.lbltieude);
            this.pnltieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltieude.Location = new System.Drawing.Point(0, 0);
            this.pnltieude.Name = "pnltieude";
            this.pnltieude.Size = new System.Drawing.Size(1039, 173);
            this.pnltieude.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(868, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(171, 170);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // lblhd
            // 
            this.lblhd.AutoSize = true;
            this.lblhd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhd.ForeColor = System.Drawing.Color.Gray;
            this.lblhd.Location = new System.Drawing.Point(30, 133);
            this.lblhd.Name = "lblhd";
            this.lblhd.Size = new System.Drawing.Size(402, 28);
            this.lblhd.TabIndex = 1;
            this.lblhd.Text = "Chọn chức năng từ menu bên trái để bắt đầu";
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lbltieude.Location = new System.Drawing.Point(27, 33);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(380, 45);
            this.lbltieude.TabIndex = 0;
            this.lbltieude.Text = "Chào mừng, quân nhân!";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.83735F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.16265F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.pnllsbqs, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 245);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 307);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pnllsbqs
            // 
            this.pnllsbqs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.pnllsbqs.Controls.Add(this.btnclsbqs);
            this.pnllsbqs.Controls.Add(this.label1);
            this.pnllsbqs.Controls.Add(this.lbllsbqs);
            this.pnllsbqs.Controls.Add(this.pictureBox2);
            this.pnllsbqs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnllsbqs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnllsbqs.Location = new System.Drawing.Point(321, 10);
            this.pnllsbqs.Margin = new System.Windows.Forms.Padding(10);
            this.pnllsbqs.Name = "pnllsbqs";
            this.pnllsbqs.Padding = new System.Windows.Forms.Padding(5);
            this.pnllsbqs.Size = new System.Drawing.Size(333, 287);
            this.pnllsbqs.TabIndex = 4;
            this.pnllsbqs.Paint += new System.Windows.Forms.PaintEventHandler(this.pnllsbqs_Paint);
            // 
            // btnclsbqs
            // 
            this.btnclsbqs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnclsbqs.BackColor = System.Drawing.Color.White;
            this.btnclsbqs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclsbqs.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclsbqs.ForeColor = System.Drawing.Color.Navy;
            this.btnclsbqs.Location = new System.Drawing.Point(109, 202);
            this.btnclsbqs.Name = "btnclsbqs";
            this.btnclsbqs.Size = new System.Drawing.Size(136, 64);
            this.btnclsbqs.TabIndex = 3;
            this.btnclsbqs.Text = "Mở chức năng ";
            this.btnclsbqs.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(8, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tra cứu chi tiết lịch sử cắt cơm, chế độ \r\n           tiêu chuẩn của quân nhân";
            // 
            // lbllsbqs
            // 
            this.lbllsbqs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbllsbqs.AutoSize = true;
            this.lbllsbqs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllsbqs.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbllsbqs.Location = new System.Drawing.Point(132, 102);
            this.lbllsbqs.Name = "lbllsbqs";
            this.lbllsbqs.Size = new System.Drawing.Size(82, 28);
            this.lbllsbqs.TabIndex = 1;
            this.lbllsbqs.Text = "Tra cứu";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(148, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // lbldonvi
            // 
            this.lbldonvi.AutoSize = true;
            this.lbldonvi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldonvi.ForeColor = System.Drawing.Color.Black;
            this.lbldonvi.Location = new System.Drawing.Point(30, 94);
            this.lbldonvi.Name = "lbldonvi";
            this.lbldonvi.Size = new System.Drawing.Size(78, 28);
            this.lbldonvi.TabIndex = 3;
            this.lbldonvi.Text = "Đơn vị: ";
            this.lbldonvi.Click += new System.EventHandler(this.lbldonvi_Click);
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchedo.ForeColor = System.Drawing.Color.Black;
            this.lblchedo.Location = new System.Drawing.Point(251, 94);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(78, 28);
            this.lblchedo.TabIndex = 4;
            this.lblchedo.Text = "Chế độ:";
            // 
            // frmtrangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 615);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnltieude);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmtrangchu";
            this.Text = "frmtrangchu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmtrangchu_Load);
            this.pnltieude.ResumeLayout(false);
            this.pnltieude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnllsbqs.ResumeLayout(false);
            this.pnllsbqs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnltieude;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblhd;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnllsbqs;
        private System.Windows.Forms.Button btnclsbqs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbllsbqs;
        private System.Windows.Forms.Label lbldonvi;
        private System.Windows.Forms.Label lblchedo;
    }
}