namespace DuAn.GUI.frmnhanvien
{
    partial class frmHuongDanLapThucDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.SplitContainer();
            this.rtbHuongDan = new System.Windows.Forms.RichTextBox();
            this.picGuide = new System.Windows.Forms.PictureBox();
            this.footer = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.body)).BeginInit();
            this.body.Panel1.SuspendLayout();
            this.body.Panel2.SuspendLayout();
            this.body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGuide)).BeginInit();
            this.footer.SuspendLayout();
            this.SuspendLayout();
            //
            // header
            //
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.header.Controls.Add(this.lblTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Height = 64;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.header.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(880, 64);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HƯỚNG DẪN LẬP THỰC ĐƠN TUẦN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // body
            //
            this.body.BackColor = System.Drawing.Color.White;
            this.body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.body.Location = new System.Drawing.Point(0, 64);
            this.body.Name = "body";
            //
            // body.Panel1
            //
            this.body.Panel1.Controls.Add(this.rtbHuongDan);
            this.body.Panel1.Padding = new System.Windows.Forms.Padding(18);
            //
            // body.Panel2
            //
            this.body.Panel2.AutoScroll = true;
            this.body.Panel2.Controls.Add(this.picGuide);
            this.body.Panel2.Padding = new System.Windows.Forms.Padding(18);
            this.body.Size = new System.Drawing.Size(920, 520);
            this.body.SplitterDistance = 560;
            this.body.TabIndex = 1;
            //
            // rtbHuongDan
            //
            this.rtbHuongDan.BackColor = System.Drawing.Color.White;
            this.rtbHuongDan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHuongDan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHuongDan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.rtbHuongDan.Location = new System.Drawing.Point(18, 18);
            this.rtbHuongDan.Name = "rtbHuongDan";
            this.rtbHuongDan.ReadOnly = true;
            this.rtbHuongDan.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbHuongDan.Size = new System.Drawing.Size(524, 484);
            this.rtbHuongDan.TabIndex = 0;
            this.rtbHuongDan.Text = "";
            //
            // picGuide
            //
            this.picGuide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.picGuide.Location = new System.Drawing.Point(18, 18);
            this.picGuide.Name = "picGuide";
            this.picGuide.Size = new System.Drawing.Size(290, 600);
            this.picGuide.TabIndex = 0;
            this.picGuide.TabStop = false;
            //
            // footer
            //
            this.footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.footer.Controls.Add(this.btnClose);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Height = 56;
            this.footer.Location = new System.Drawing.Point(0, 584);
            this.footer.Name = "footer";
            this.footer.Padding = new System.Windows.Forms.Padding(18, 8, 18, 8);
            this.footer.TabIndex = 2;
            //
            // btnClose
            //
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(792, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // frmHuongDanLapThucDon
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(920, 700);
            this.Controls.Add(this.body);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(840, 580);
            this.Name = "frmHuongDanLapThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hướng dẫn lập thực đơn tuần";
            this.header.ResumeLayout(false);
            this.body.Panel1.ResumeLayout(false);
            this.body.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.body)).EndInit();
            this.body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGuide)).EndInit();
            this.footer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer body;
        private System.Windows.Forms.RichTextBox rtbHuongDan;
        private System.Windows.Forms.PictureBox picGuide;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Button btnClose;
    }
}
