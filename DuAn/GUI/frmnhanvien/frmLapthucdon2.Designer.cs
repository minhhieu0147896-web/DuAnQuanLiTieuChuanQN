namespace DuAn.GUI.frmnhanvien
{
    partial class frmLapthucdon2
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpWeek = new System.Windows.Forms.DateTimePicker();
            this.cboCheDo = new System.Windows.Forms.ComboBox();
            this.lblWeekRange = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.splBody = new System.Windows.Forms.SplitContainer();
            this.weekGrid = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChooser = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.lblActiveSlot = new System.Windows.Forms.Label();
            this.lblChooserTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.flpToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splBody)).BeginInit();
            this.splBody.Panel1.SuspendLayout();
            this.splBody.Panel2.SuspendLayout();
            this.splBody.SuspendLayout();
            this.pnlChooser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 41);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "LẬP THỰC ĐƠN TUẦN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(980, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 68);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Quay lai";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.flpToolbar);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 68);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(24, 14, 24, 14);
            this.pnlToolbar.Size = new System.Drawing.Size(1100, 96);
            this.pnlToolbar.TabIndex = 1;
            // 
            // flpToolbar
            // 
            this.flpToolbar.AutoScroll = true;
            this.flpToolbar.Controls.Add(this.dtpWeek);
            this.flpToolbar.Controls.Add(this.cboCheDo);
            this.flpToolbar.Controls.Add(this.lblWeekRange);
            this.flpToolbar.Controls.Add(this.btnLuu);
            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToolbar.Location = new System.Drawing.Point(24, 14);
            this.flpToolbar.Name = "flpToolbar";
            this.flpToolbar.Size = new System.Drawing.Size(1052, 68);
            this.flpToolbar.TabIndex = 0;
            this.flpToolbar.WrapContents = false;
            // 
            // dtpWeek
            // 
            this.dtpWeek.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWeek.Location = new System.Drawing.Point(3, 3);
            this.dtpWeek.Name = "dtpWeek";
            this.dtpWeek.Size = new System.Drawing.Size(170, 22);
            this.dtpWeek.TabIndex = 0;
            // 
            // cboCheDo
            // 
            this.cboCheDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheDo.FormattingEnabled = true;
            this.cboCheDo.Location = new System.Drawing.Point(179, 3);
            this.cboCheDo.Name = "cboCheDo";
            this.cboCheDo.Size = new System.Drawing.Size(190, 24);
            this.cboCheDo.TabIndex = 1;
            // 
            // lblWeekRange
            // 
            this.lblWeekRange.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeekRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblWeekRange.Location = new System.Drawing.Point(375, 0);
            this.lblWeekRange.Name = "lblWeekRange";
            this.lblWeekRange.Size = new System.Drawing.Size(300, 48);
            this.lblWeekRange.TabIndex = 2;
            this.lblWeekRange.Text = "Tuần ...";
            this.lblWeekRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(681, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(170, 42);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu thực đơn tuần";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // splBody
            // 
            this.splBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.splBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splBody.Location = new System.Drawing.Point(0, 164);
            this.splBody.Name = "splBody";
            // 
            // splBody.Panel1
            // 
            this.splBody.Panel1.Controls.Add(this.weekGrid);
            this.splBody.Panel1.Padding = new System.Windows.Forms.Padding(16);
            // 
            // splBody.Panel2
            // 
            this.splBody.Panel2.Controls.Add(this.pnlChooser);
            this.splBody.Panel2.Padding = new System.Windows.Forms.Padding(16);
            this.splBody.Size = new System.Drawing.Size(1100, 486);
            this.splBody.SplitterDistance = 880;
            this.splBody.TabIndex = 2;
            // 
            // weekGrid
            // 
            this.weekGrid.BackColor = System.Drawing.Color.White;
            this.weekGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.weekGrid.ColumnCount = 8;
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.weekGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weekGrid.Location = new System.Drawing.Point(16, 16);
            this.weekGrid.Name = "weekGrid";
            this.weekGrid.Padding = new System.Windows.Forms.Padding(10);
            this.weekGrid.RowCount = 4;
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekGrid.Size = new System.Drawing.Size(848, 454);
            this.weekGrid.TabIndex = 0;
            // 
            // pnlChooser
            // 
            this.pnlChooser.BackColor = System.Drawing.Color.White;
            this.pnlChooser.Controls.Add(this.lblStatus);
            this.pnlChooser.Controls.Add(this.btnHelp);
            this.pnlChooser.Controls.Add(this.btnReload);
            this.pnlChooser.Controls.Add(this.btnXoaMon);
            this.pnlChooser.Controls.Add(this.lblActiveSlot);
            this.pnlChooser.Controls.Add(this.lblChooserTitle);
            this.pnlChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChooser.Location = new System.Drawing.Point(16, 16);
            this.pnlChooser.Name = "pnlChooser";
            this.pnlChooser.Padding = new System.Windows.Forms.Padding(18);
            this.pnlChooser.Size = new System.Drawing.Size(184, 454);
            this.pnlChooser.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(96)))), ((int)(((byte)(105)))));
            this.lblStatus.Location = new System.Drawing.Point(18, 238);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 16);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Da chon 0/98 o...";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHelp.Location = new System.Drawing.Point(18, 200);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(148, 38);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Hướng dẫn";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReload.Location = new System.Drawing.Point(18, 162);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(148, 38);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Tải lại từ database";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXoaMon.Location = new System.Drawing.Point(18, 124);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(148, 38);
            this.btnXoaMon.TabIndex = 2;
            this.btnXoaMon.Text = "Xóa món khỏi ô";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            // 
            // lblActiveSlot
            // 
            this.lblActiveSlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActiveSlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(96)))), ((int)(((byte)(105)))));
            this.lblActiveSlot.Location = new System.Drawing.Point(18, 52);
            this.lblActiveSlot.Name = "lblActiveSlot";
            this.lblActiveSlot.Size = new System.Drawing.Size(148, 72);
            this.lblActiveSlot.TabIndex = 1;
            this.lblActiveSlot.Text = "Bấm vào một ô món trong bảng để mở form chọn món ";
            // 
            // lblChooserTitle
            // 
            this.lblChooserTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChooserTitle.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooserTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblChooserTitle.Location = new System.Drawing.Point(18, 18);
            this.lblChooserTitle.Name = "lblChooserTitle";
            this.lblChooserTitle.Size = new System.Drawing.Size(148, 34);
            this.lblChooserTitle.TabIndex = 0;
            this.lblChooserTitle.Text = "CHỌN MÓN";
            // 
            // frmLapthucdon2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.splBody);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "frmLapthucdon2";
            this.Text = "frmLapthucdon2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.flpToolbar.ResumeLayout(false);
            this.splBody.Panel1.ResumeLayout(false);
            this.splBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splBody)).EndInit();
            this.splBody.ResumeLayout(false);
            this.pnlChooser.ResumeLayout(false);
            this.pnlChooser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        protected internal System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.DateTimePicker dtpWeek;
        private System.Windows.Forms.ComboBox cboCheDo;
        private System.Windows.Forms.Label lblWeekRange;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.SplitContainer splBody;
        private System.Windows.Forms.TableLayoutPanel weekGrid;
        private System.Windows.Forms.Panel pnlChooser;
        private System.Windows.Forms.Label lblChooserTitle;
        private System.Windows.Forms.Label lblActiveSlot;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnHelp;
    }
}