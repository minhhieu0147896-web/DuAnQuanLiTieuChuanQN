namespace frmfornhvhc
{
    partial class frmddtc
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
            this.lblchedo = new System.Windows.Forms.Label();
            this.cbochedo = new System.Windows.Forms.ComboBox();
            this.btntracuu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colstt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltencd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcapbac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblchedo
            // 
            this.lblchedo.AutoSize = true;
            this.lblchedo.Location = new System.Drawing.Point(46, 34);
            this.lblchedo.Name = "lblchedo";
            this.lblchedo.Size = new System.Drawing.Size(59, 18);
            this.lblchedo.TabIndex = 0;
            this.lblchedo.Text = "Chế độ";
            // 
            // cbochedo
            // 
            this.cbochedo.FormattingEnabled = true;
            this.cbochedo.Location = new System.Drawing.Point(123, 31);
            this.cbochedo.Name = "cbochedo";
            this.cbochedo.Size = new System.Drawing.Size(121, 26);
            this.cbochedo.TabIndex = 1;
            // 
            // btntracuu
            // 
            this.btntracuu.Location = new System.Drawing.Point(278, 29);
            this.btntracuu.Name = "btntracuu";
            this.btntracuu.Size = new System.Drawing.Size(59, 28);
            this.btntracuu.TabIndex = 2;
            this.btntracuu.Text = "Tra cứu";
            this.btntracuu.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colstt,
            this.coltencd,
            this.Column1,
            this.colcapbac,
            this.colBC,
            this.colTienan});
            this.dataGridView1.Location = new System.Drawing.Point(32, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(880, 193);
            this.dataGridView1.TabIndex = 3;
            // 
            // colstt
            // 
            this.colstt.HeaderText = "STT";
            this.colstt.MinimumWidth = 8;
            this.colstt.Name = "colstt";
            this.colstt.Width = 70;
            // 
            // coltencd
            // 
            this.coltencd.HeaderText = "Chế độ";
            this.coltencd.MinimumWidth = 8;
            this.coltencd.Name = "coltencd";
            this.coltencd.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // colcapbac
            // 
            this.colcapbac.HeaderText = "Cấp bậc";
            this.colcapbac.MinimumWidth = 8;
            this.colcapbac.Name = "colcapbac";
            this.colcapbac.Width = 150;
            // 
            // colBC
            // 
            this.colBC.HeaderText = "Binh chủng";
            this.colBC.MinimumWidth = 8;
            this.colBC.Name = "colBC";
            this.colBC.Width = 150;
            // 
            // colTienan
            // 
            this.colTienan.HeaderText = "Tiền ăn";
            this.colTienan.MinimumWidth = 8;
            this.colTienan.Name = "colTienan";
            this.colTienan.Width = 150;
            // 
            // frmddtc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 357);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btntracuu);
            this.Controls.Add(this.cbochedo);
            this.Controls.Add(this.lblchedo);
            this.Name = "frmddtc";
            this.Text = "Tra cứu tiêu chuẩn dinh dưỡng";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblchedo;
        private System.Windows.Forms.ComboBox cbochedo;
        private System.Windows.Forms.Button btntracuu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstt;
        private System.Windows.Forms.DataGridViewTextBoxColumn coltencd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcapbac;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienan;
    }
}