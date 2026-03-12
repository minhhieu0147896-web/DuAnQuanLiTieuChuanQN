namespace frmquannhan
{
    partial class frm_manhinh_quannhan
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiêuChuẩnĂnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửCắtCơmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.traCứuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            this.hệThốngToolStripMenuItem.Click += new System.EventHandler(this.hệThốngToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(195, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(195, 34);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // traCứuToolStripMenuItem
            // 
            this.traCứuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiêuChuẩnĂnToolStripMenuItem,
            this.lịchSửCắtCơmToolStripMenuItem});
            this.traCứuToolStripMenuItem.Name = "traCứuToolStripMenuItem";
            this.traCứuToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.traCứuToolStripMenuItem.Text = "Tra cứu";
            // 
            // tiêuChuẩnĂnToolStripMenuItem
            // 
            this.tiêuChuẩnĂnToolStripMenuItem.Name = "tiêuChuẩnĂnToolStripMenuItem";
            this.tiêuChuẩnĂnToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.tiêuChuẩnĂnToolStripMenuItem.Text = "Tiêu chuẩn ăn";
            this.tiêuChuẩnĂnToolStripMenuItem.Click += new System.EventHandler(this.tiêuChuẩnĂnToolStripMenuItem_Click);
            // 
            // lịchSửCắtCơmToolStripMenuItem
            // 
            this.lịchSửCắtCơmToolStripMenuItem.Name = "lịchSửCắtCơmToolStripMenuItem";
            this.lịchSửCắtCơmToolStripMenuItem.Size = new System.Drawing.Size(236, 34);
            this.lịchSửCắtCơmToolStripMenuItem.Text = "Lịch sử cắt cơm";
            this.lịchSửCắtCơmToolStripMenuItem.Click += new System.EventHandler(this.lịchSửCắtCơmToolStripMenuItem_Click);
            // 
            // frm_manhinh_quannhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_manhinh_quannhan";
            this.Text = "Quân Nhân";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traCứuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiêuChuẩnĂnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửCắtCơmToolStripMenuItem;
    }
}

