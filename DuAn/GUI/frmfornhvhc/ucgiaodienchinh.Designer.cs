namespace DuAn.GUI.frmfornhvhc
{
    partial class ucgiaodienchinh
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnltitle = new System.Windows.Forms.Panel();
            this.lbltieude = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlbang = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnltitle.SuspendLayout();
            this.pnlbang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnltitle
            // 
            this.pnltitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnltitle.Controls.Add(this.lbltieude);
            this.pnltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnltitle.Location = new System.Drawing.Point(0, 0);
            this.pnltitle.Name = "pnltitle";
            this.pnltitle.Size = new System.Drawing.Size(932, 60);
            this.pnltitle.TabIndex = 0;
            // 
            // lbltieude
            // 
            this.lbltieude.AutoSize = true;
            this.lbltieude.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltieude.ForeColor = System.Drawing.Color.White;
            this.lbltieude.Location = new System.Drawing.Point(397, 12);
            this.lbltieude.Name = "lbltieude";
            this.lbltieude.Size = new System.Drawing.Size(132, 45);
            this.lbltieude.TabIndex = 0;
            this.lbltieude.Text = "Lịch sử ";
            this.lbltieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 150);
            this.panel1.TabIndex = 1;
            // 
            // pnlbang
            // 
            this.pnlbang.Controls.Add(this.dataGridView1);
            this.pnlbang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlbang.Location = new System.Drawing.Point(0, 210);
            this.pnlbang.Name = "pnlbang";
            this.pnlbang.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlbang.Size = new System.Drawing.Size(932, 451);
            this.pnlbang.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(922, 451);
            this.dataGridView1.TabIndex = 0;
            // 
            // ucgiaodienchinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlbang);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnltitle);
            this.Name = "ucgiaodienchinh";
            this.Size = new System.Drawing.Size(932, 661);
            this.pnltitle.ResumeLayout(false);
            this.pnltitle.PerformLayout();
            this.pnlbang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnltitle;
        private System.Windows.Forms.Label lbltieude;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlbang;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
