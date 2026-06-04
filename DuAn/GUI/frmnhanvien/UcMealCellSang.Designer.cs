namespace DuAn.GUI.frmnhanvien
{
    partial class UcMealCellSang
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

        private void InitializeComponent()
        {
            this.flpContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMan1 = new System.Windows.Forms.Button();
            this.btnCanh1 = new System.Windows.Forms.Button();
            this.btnSua1 = new System.Windows.Forms.Button();
            this.flpContainer.SuspendLayout();
            this.SuspendLayout();
            //
            // flpContainer
            //
            this.flpContainer.AutoScroll = true;
            this.flpContainer.BackColor = System.Drawing.Color.White;
            this.flpContainer.Controls.Add(this.btnMan1);
            this.flpContainer.Controls.Add(this.btnCanh1);
            this.flpContainer.Controls.Add(this.btnSua1);
            this.flpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContainer.Location = new System.Drawing.Point(0, 0);
            this.flpContainer.Name = "flpContainer";
            this.flpContainer.Padding = new System.Windows.Forms.Padding(6);
            this.flpContainer.Size = new System.Drawing.Size(130, 152);
            this.flpContainer.TabIndex = 0;
            this.flpContainer.WrapContents = true;
            //
            // btnMan1
            //
            this.btnMan1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(214)))));
            this.btnMan1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnMan1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMan1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnMan1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.btnMan1.Location = new System.Drawing.Point(10, 10);
            this.btnMan1.Margin = new System.Windows.Forms.Padding(4);
            this.btnMan1.Name = "btnMan1";
            this.btnMan1.Size = new System.Drawing.Size(106, 36);
            this.btnMan1.TabIndex = 0;
            this.btnMan1.Text = "+ Mặn 1";
            this.btnMan1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMan1.UseVisualStyleBackColor = false;
            //
            // btnCanh1
            //
            this.btnCanh1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.btnCanh1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnCanh1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanh1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnCanh1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.btnCanh1.Location = new System.Drawing.Point(10, 54);
            this.btnCanh1.Margin = new System.Windows.Forms.Padding(4);
            this.btnCanh1.Name = "btnCanh1";
            this.btnCanh1.Size = new System.Drawing.Size(106, 36);
            this.btnCanh1.TabIndex = 1;
            this.btnCanh1.Text = "+ Canh 1";
            this.btnCanh1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCanh1.UseVisualStyleBackColor = false;
            //
            // btnSua1
            //
            this.btnSua1.BackColor = System.Drawing.Color.White;
            this.btnSua1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(155)))), ((int)(((byte)(166)))));
            this.btnSua1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSua1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.btnSua1.Location = new System.Drawing.Point(10, 98);
            this.btnSua1.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua1.Name = "btnSua1";
            this.btnSua1.Size = new System.Drawing.Size(106, 36);
            this.btnSua1.TabIndex = 2;
            this.btnSua1.Text = "+ Sữa 1";
            this.btnSua1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSua1.UseVisualStyleBackColor = false;
            //
            // UcMealCellSang
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpContainer);
            this.Name = "UcMealCellSang";
            this.Size = new System.Drawing.Size(130, 152);
            this.flpContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.FlowLayoutPanel flpContainer;
        private System.Windows.Forms.Button btnMan1;
        private System.Windows.Forms.Button btnCanh1;
        private System.Windows.Forms.Button btnSua1;
    }
}
