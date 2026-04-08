namespace frmlogin
{
    partial class frmmhlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmhlogin));
            this.pnlogin = new System.Windows.Forms.Panel();
            this.lbldangnhap = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlogin
            // 
            this.pnlogin.BackColor = System.Drawing.Color.Gray;
            this.pnlogin.Controls.Add(this.lbldangnhap);
            this.pnlogin.Controls.Add(this.button2);
            this.pnlogin.Controls.Add(this.button1);
            this.pnlogin.Controls.Add(this.textBox3);
            this.pnlogin.Controls.Add(this.label3);
            this.pnlogin.Controls.Add(this.label2);
            this.pnlogin.Controls.Add(this.textBox1);
            this.pnlogin.Location = new System.Drawing.Point(219, 95);
            this.pnlogin.Name = "pnlogin";
            this.pnlogin.Size = new System.Drawing.Size(502, 400);
            this.pnlogin.TabIndex = 6;
            this.pnlogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // lbldangnhap
            // 
            this.lbldangnhap.AutoSize = true;
            this.lbldangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldangnhap.ForeColor = System.Drawing.Color.Transparent;
            this.lbldangnhap.Location = new System.Drawing.Point(193, 64);
            this.lbldangnhap.Name = "lbldangnhap";
            this.lbldangnhap.Size = new System.Drawing.Size(162, 32);
            this.lbldangnhap.TabIndex = 10;
            this.lbldangnhap.Text = "Đăng nhập";
            this.lbldangnhap.Click += new System.EventHandler(this.lbldangnhap_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.IndianRed;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.button2.Location = new System.Drawing.Point(305, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(133, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Đăng nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(168, 191);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(304, 19);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label3.Location = new System.Drawing.Point(16, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label2.Location = new System.Drawing.Point(3, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên đăng nhập";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(168, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 19);
            this.textBox1.TabIndex = 1;
            // 
            // frmmhlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1022, 631);
            this.Controls.Add(this.pnlogin);
            this.DoubleBuffered = true;
            this.Name = "frmmhlogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmlogin_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlogin.ResumeLayout(false);
            this.pnlogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlogin;
        private System.Windows.Forms.Label lbldangnhap;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

