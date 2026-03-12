namespace frmfornhvhc
{
    partial class frmmain
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
            this.quânSốToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoQuânSốToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quânNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchQuânNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quânSốToolStripMenuItem,
            this.quânNhânToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất ";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // quânSốToolStripMenuItem
            // 
            this.quânSốToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoQuânSốToolStripMenuItem,
            this.lịchSửToolStripMenuItem});
            this.quânSốToolStripMenuItem.Name = "quânSốToolStripMenuItem";
            this.quânSốToolStripMenuItem.Size = new System.Drawing.Size(95, 29);
            this.quânSốToolStripMenuItem.Text = "Quân số";
            // 
            // báoQuânSốToolStripMenuItem
            // 
            this.báoQuânSốToolStripMenuItem.Name = "báoQuânSốToolStripMenuItem";
            this.báoQuânSốToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.báoQuânSốToolStripMenuItem.Text = "Báo quân số";
            this.báoQuânSốToolStripMenuItem.Click += new System.EventHandler(this.báoQuânSốToolStripMenuItem_Click);
            // 
            // lịchSửToolStripMenuItem
            // 
            this.lịchSửToolStripMenuItem.Name = "lịchSửToolStripMenuItem";
            this.lịchSửToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.lịchSửToolStripMenuItem.Text = "Lịch sử ";
            this.lịchSửToolStripMenuItem.Click += new System.EventHandler(this.lịchSửToolStripMenuItem_Click);
            // 
            // quânNhânToolStripMenuItem
            // 
            this.quânNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchQuânNhânToolStripMenuItem});
            this.quânNhânToolStripMenuItem.Name = "quânNhânToolStripMenuItem";
            this.quânNhânToolStripMenuItem.Size = new System.Drawing.Size(115, 29);
            this.quânNhânToolStripMenuItem.Text = "Quân nhân";
            // 
            // danhSáchQuânNhânToolStripMenuItem
            // 
            this.danhSáchQuânNhânToolStripMenuItem.Name = "danhSáchQuânNhânToolStripMenuItem";
            this.danhSáchQuânNhânToolStripMenuItem.Size = new System.Drawing.Size(287, 34);
            this.danhSáchQuânNhânToolStripMenuItem.Text = "Tiêu chuẩn quân nhân";
            this.danhSáchQuânNhânToolStripMenuItem.Click += new System.EventHandler(this.danhSáchQuânNhânToolStripMenuItem_Click);
            // 
            // frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmmain";
            this.Text = "Cán bộ đơn vị";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.ToolStripMenuItem quânSốToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoQuânSốToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quânNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchQuânNhânToolStripMenuItem;
    }
}

