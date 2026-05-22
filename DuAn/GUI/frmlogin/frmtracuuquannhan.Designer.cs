namespace DuAn.GUI.frmlogin
{
    partial class frmtracuuquannhan
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
            this.lblma = new System.Windows.Forms.Label();
            this.txtma = new System.Windows.Forms.TextBox();
            this.btnxacnhan = new System.Windows.Forms.Button();
            this.btnthoat = new System.Windows.Forms.Button();
            this.lblyeucau = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblma
            // 
            this.lblma.AutoSize = true;
            this.lblma.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblma.Location = new System.Drawing.Point(23, 162);
            this.lblma.Name = "lblma";
            this.lblma.Size = new System.Drawing.Size(140, 28);
            this.lblma.TabIndex = 0;
            this.lblma.Text = "Mã Quân nhân";
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(182, 166);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(204, 26);
            this.txtma.TabIndex = 1;
            // 
            // btnxacnhan
            // 
            this.btnxacnhan.BackColor = System.Drawing.Color.SkyBlue;
            this.btnxacnhan.Location = new System.Drawing.Point(68, 273);
            this.btnxacnhan.Name = "btnxacnhan";
            this.btnxacnhan.Size = new System.Drawing.Size(95, 39);
            this.btnxacnhan.TabIndex = 2;
            this.btnxacnhan.Text = "Xác nhận";
            this.btnxacnhan.UseVisualStyleBackColor = false;
            this.btnxacnhan.Click += new System.EventHandler(this.btnxacnhan_Click);
            // 
            // btnthoat
            // 
            this.btnthoat.BackColor = System.Drawing.Color.LightCoral;
            this.btnthoat.Location = new System.Drawing.Point(246, 273);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(105, 38);
            this.btnthoat.TabIndex = 3;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = false;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // lblyeucau
            // 
            this.lblyeucau.AutoSize = true;
            this.lblyeucau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblyeucau.Location = new System.Drawing.Point(22, 38);
            this.lblyeucau.Name = "lblyeucau";
            this.lblyeucau.Size = new System.Drawing.Size(390, 64);
            this.lblyeucau.TabIndex = 4;
            this.lblyeucau.Text = "VUI LÒNG NHẬP MÃ QUÂN NHÂN \r\n                DƯỚI ĐÂY!";
            // 
            // frmtracuuquannhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 426);
            this.Controls.Add(this.lblyeucau);
            this.Controls.Add(this.btnthoat);
            this.Controls.Add(this.btnxacnhan);
            this.Controls.Add(this.txtma);
            this.Controls.Add(this.lblma);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmtracuuquannhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtracuuquannhan";
            this.Load += new System.EventHandler(this.frmtracuuquannhan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblma;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Button btnxacnhan;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Label lblyeucau;
    }
}