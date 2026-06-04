namespace DuAn.GUI.frmnhanvien
{
    partial class frmLapthucdon2
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.flpToolbar = new System.Windows.Forms.FlowLayoutPanel();
            this.dtpWeek = new System.Windows.Forms.DateTimePicker();
            this.cboCheDo = new System.Windows.Forms.ComboBox();
            this.lblWeekRange = new System.Windows.Forms.Label();
            this.btnDienTuMau = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.splBody = new System.Windows.Forms.SplitContainer();
            this.weekGrid = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderBuoi = new System.Windows.Forms.Label();
            this.lblHeaderT2 = new System.Windows.Forms.Label();
            this.lblHeaderT3 = new System.Windows.Forms.Label();
            this.lblHeaderT4 = new System.Windows.Forms.Label();
            this.lblHeaderT5 = new System.Windows.Forms.Label();
            this.lblHeaderT6 = new System.Windows.Forms.Label();
            this.lblHeaderT7 = new System.Windows.Forms.Label();
            this.lblHeaderCN = new System.Windows.Forms.Label();
            this.lblMealSang = new System.Windows.Forms.Label();
            this.lblMealTrua = new System.Windows.Forms.Label();
            this.lblMealToi = new System.Windows.Forms.Label();
            this.ucT2Sang = new DuAn.GUI.frmnhanvien.UcMealCellSang();
            this.ucT3Sang = new DuAn.GUI.frmnhanvien.UcMealCellSang();
            this.ucT4Sang = new DuAn.GUI.frmnhanvien.UcMealCellSang();
            this.ucT5Sang = new DuAn.GUI.frmnhanvien.UcMealCellSang();
            this.ucT6Sang = new DuAn.GUI.frmnhanvien.UcMealCellSang();
            this.ucT7Sang = new DuAn.GUI.frmnhanvien.UcMealCellSang();
            this.ucCNSang = new DuAn.GUI.frmnhanvien.UcMealCellSang();
            this.ucT2Trua = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT3Trua = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT4Trua = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT5Trua = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT6Trua = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT7Trua = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucCNTrua = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT2Toi = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT3Toi = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT4Toi = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT5Toi = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT6Toi = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucT7Toi = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.ucCNToi = new DuAn.GUI.frmnhanvien.UcMealCellTruaToi();
            this.pnlChooser = new System.Windows.Forms.Panel();
            this.pnlTienDo = new System.Windows.Forms.Panel();
            this.lblChatBeo = new System.Windows.Forms.Label();
            this.prgChatBeo = new System.Windows.Forms.ProgressBar();
            this.lblChatXo = new System.Windows.Forms.Label();
            this.prgChatXo = new System.Windows.Forms.ProgressBar();
            this.lblDam = new System.Windows.Forms.Label();
            this.prgDam = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
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
            this.weekGrid.SuspendLayout();
            this.pnlChooser.SuspendLayout();
            this.pnlTienDo.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(1144, 68);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
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
            this.btnBack.Location = new System.Drawing.Point(1024, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 68);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Quay lại";
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
            this.pnlToolbar.Size = new System.Drawing.Size(1144, 96);
            this.pnlToolbar.TabIndex = 1;
            // 
            // flpToolbar
            // 
            this.flpToolbar.AutoScroll = true;
            this.flpToolbar.Controls.Add(this.dtpWeek);
            this.flpToolbar.Controls.Add(this.cboCheDo);
            this.flpToolbar.Controls.Add(this.lblWeekRange);
            this.flpToolbar.Controls.Add(this.btnDienTuMau);
            this.flpToolbar.Controls.Add(this.btnLuu);
            this.flpToolbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToolbar.Location = new System.Drawing.Point(24, 14);
            this.flpToolbar.Name = "flpToolbar";
            this.flpToolbar.Size = new System.Drawing.Size(1096, 68);
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
            this.lblWeekRange.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblWeekRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblWeekRange.Location = new System.Drawing.Point(375, 0);
            this.lblWeekRange.Name = "lblWeekRange";
            this.lblWeekRange.Size = new System.Drawing.Size(300, 48);
            this.lblWeekRange.TabIndex = 2;
            this.lblWeekRange.Text = "Tuần ...";
            this.lblWeekRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDienTuMau
            // 
            this.btnDienTuMau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(90)))));
            this.btnDienTuMau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDienTuMau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDienTuMau.ForeColor = System.Drawing.Color.White;
            this.btnDienTuMau.Location = new System.Drawing.Point(681, 3);
            this.btnDienTuMau.Name = "btnDienTuMau";
            this.btnDienTuMau.Size = new System.Drawing.Size(170, 42);
            this.btnDienTuMau.TabIndex = 4;
            this.btnDienTuMau.Text = "Điền từ mẫu";
            this.btnDienTuMau.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(857, 3);
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
            this.splBody.Size = new System.Drawing.Size(1144, 580);
            this.splBody.SplitterDistance = 924;
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
            this.weekGrid.Controls.Add(this.lblHeaderBuoi, 0, 0);
            this.weekGrid.Controls.Add(this.lblHeaderT2, 1, 0);
            this.weekGrid.Controls.Add(this.lblHeaderT3, 2, 0);
            this.weekGrid.Controls.Add(this.lblHeaderT4, 3, 0);
            this.weekGrid.Controls.Add(this.lblHeaderT5, 4, 0);
            this.weekGrid.Controls.Add(this.lblHeaderT6, 5, 0);
            this.weekGrid.Controls.Add(this.lblHeaderT7, 6, 0);
            this.weekGrid.Controls.Add(this.lblHeaderCN, 7, 0);
            this.weekGrid.Controls.Add(this.lblMealSang, 0, 1);
            this.weekGrid.Controls.Add(this.lblMealTrua, 0, 2);
            this.weekGrid.Controls.Add(this.lblMealToi, 0, 3);
            this.weekGrid.Controls.Add(this.ucT2Sang, 1, 1);
            this.weekGrid.Controls.Add(this.ucT3Sang, 2, 1);
            this.weekGrid.Controls.Add(this.ucT4Sang, 3, 1);
            this.weekGrid.Controls.Add(this.ucT5Sang, 4, 1);
            this.weekGrid.Controls.Add(this.ucT6Sang, 5, 1);
            this.weekGrid.Controls.Add(this.ucT7Sang, 6, 1);
            this.weekGrid.Controls.Add(this.ucCNSang, 7, 1);
            this.weekGrid.Controls.Add(this.ucT2Trua, 1, 2);
            this.weekGrid.Controls.Add(this.ucT3Trua, 2, 2);
            this.weekGrid.Controls.Add(this.ucT4Trua, 3, 2);
            this.weekGrid.Controls.Add(this.ucT5Trua, 4, 2);
            this.weekGrid.Controls.Add(this.ucT6Trua, 5, 2);
            this.weekGrid.Controls.Add(this.ucT7Trua, 6, 2);
            this.weekGrid.Controls.Add(this.ucCNTrua, 7, 2);
            this.weekGrid.Controls.Add(this.ucT2Toi, 1, 3);
            this.weekGrid.Controls.Add(this.ucT3Toi, 2, 3);
            this.weekGrid.Controls.Add(this.ucT4Toi, 3, 3);
            this.weekGrid.Controls.Add(this.ucT5Toi, 4, 3);
            this.weekGrid.Controls.Add(this.ucT6Toi, 5, 3);
            this.weekGrid.Controls.Add(this.ucT7Toi, 6, 3);
            this.weekGrid.Controls.Add(this.ucCNToi, 7, 3);
            this.weekGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weekGrid.Location = new System.Drawing.Point(16, 16);
            this.weekGrid.Name = "weekGrid";
            this.weekGrid.Padding = new System.Windows.Forms.Padding(10);
            this.weekGrid.RowCount = 4;
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.weekGrid.Size = new System.Drawing.Size(892, 548);
            this.weekGrid.TabIndex = 0;
            // 
            // lblHeaderBuoi
            // 
            this.lblHeaderBuoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderBuoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderBuoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderBuoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderBuoi.Location = new System.Drawing.Point(14, 11);
            this.lblHeaderBuoi.Name = "lblHeaderBuoi";
            this.lblHeaderBuoi.Size = new System.Drawing.Size(86, 48);
            this.lblHeaderBuoi.TabIndex = 0;
            this.lblHeaderBuoi.Text = "Buổi";
            this.lblHeaderBuoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderT2
            // 
            this.lblHeaderT2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderT2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderT2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderT2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderT2.Location = new System.Drawing.Point(107, 11);
            this.lblHeaderT2.Name = "lblHeaderT2";
            this.lblHeaderT2.Size = new System.Drawing.Size(104, 48);
            this.lblHeaderT2.TabIndex = 1;
            this.lblHeaderT2.Text = "Thứ 2";
            this.lblHeaderT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderT3
            // 
            this.lblHeaderT3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderT3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderT3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderT3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderT3.Location = new System.Drawing.Point(218, 11);
            this.lblHeaderT3.Name = "lblHeaderT3";
            this.lblHeaderT3.Size = new System.Drawing.Size(104, 48);
            this.lblHeaderT3.TabIndex = 2;
            this.lblHeaderT3.Text = "Thứ 3";
            this.lblHeaderT3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderT4
            // 
            this.lblHeaderT4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderT4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderT4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderT4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderT4.Location = new System.Drawing.Point(329, 11);
            this.lblHeaderT4.Name = "lblHeaderT4";
            this.lblHeaderT4.Size = new System.Drawing.Size(104, 48);
            this.lblHeaderT4.TabIndex = 3;
            this.lblHeaderT4.Text = "Thứ 4";
            this.lblHeaderT4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderT5
            // 
            this.lblHeaderT5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderT5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderT5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderT5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderT5.Location = new System.Drawing.Point(440, 11);
            this.lblHeaderT5.Name = "lblHeaderT5";
            this.lblHeaderT5.Size = new System.Drawing.Size(104, 48);
            this.lblHeaderT5.TabIndex = 4;
            this.lblHeaderT5.Text = "Thứ 5";
            this.lblHeaderT5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderT6
            // 
            this.lblHeaderT6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderT6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderT6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderT6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderT6.Location = new System.Drawing.Point(551, 11);
            this.lblHeaderT6.Name = "lblHeaderT6";
            this.lblHeaderT6.Size = new System.Drawing.Size(104, 48);
            this.lblHeaderT6.TabIndex = 5;
            this.lblHeaderT6.Text = "Thứ 6";
            this.lblHeaderT6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderT7
            // 
            this.lblHeaderT7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderT7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderT7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderT7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderT7.Location = new System.Drawing.Point(662, 11);
            this.lblHeaderT7.Name = "lblHeaderT7";
            this.lblHeaderT7.Size = new System.Drawing.Size(104, 48);
            this.lblHeaderT7.TabIndex = 6;
            this.lblHeaderT7.Text = "Thứ 7";
            this.lblHeaderT7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderCN
            // 
            this.lblHeaderCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.lblHeaderCN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderCN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHeaderCN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.lblHeaderCN.Location = new System.Drawing.Point(773, 11);
            this.lblHeaderCN.Name = "lblHeaderCN";
            this.lblHeaderCN.Size = new System.Drawing.Size(105, 48);
            this.lblHeaderCN.TabIndex = 7;
            this.lblHeaderCN.Text = "CN";
            this.lblHeaderCN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMealSang
            // 
            this.lblMealSang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMealSang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMealSang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMealSang.ForeColor = System.Drawing.Color.White;
            this.lblMealSang.Location = new System.Drawing.Point(14, 60);
            this.lblMealSang.Name = "lblMealSang";
            this.lblMealSang.Size = new System.Drawing.Size(86, 158);
            this.lblMealSang.TabIndex = 8;
            this.lblMealSang.Text = "Sáng";
            this.lblMealSang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMealTrua
            // 
            this.lblMealTrua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMealTrua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMealTrua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMealTrua.ForeColor = System.Drawing.Color.White;
            this.lblMealTrua.Location = new System.Drawing.Point(14, 219);
            this.lblMealTrua.Name = "lblMealTrua";
            this.lblMealTrua.Size = new System.Drawing.Size(86, 158);
            this.lblMealTrua.TabIndex = 9;
            this.lblMealTrua.Text = "Trưa";
            this.lblMealTrua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMealToi
            // 
            this.lblMealToi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMealToi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMealToi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMealToi.ForeColor = System.Drawing.Color.White;
            this.lblMealToi.Location = new System.Drawing.Point(14, 378);
            this.lblMealToi.Name = "lblMealToi";
            this.lblMealToi.Size = new System.Drawing.Size(86, 159);
            this.lblMealToi.TabIndex = 10;
            this.lblMealToi.Text = "Tối";
            this.lblMealToi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucT2Sang
            // 
            this.ucT2Sang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT2Sang.Location = new System.Drawing.Point(107, 63);
            this.ucT2Sang.Name = "ucT2Sang";
            this.ucT2Sang.Size = new System.Drawing.Size(104, 152);
            this.ucT2Sang.TabIndex = 11;
            // 
            // ucT3Sang
            // 
            this.ucT3Sang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT3Sang.Location = new System.Drawing.Point(218, 63);
            this.ucT3Sang.Name = "ucT3Sang";
            this.ucT3Sang.Size = new System.Drawing.Size(104, 152);
            this.ucT3Sang.TabIndex = 12;
            // 
            // ucT4Sang
            // 
            this.ucT4Sang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT4Sang.Location = new System.Drawing.Point(329, 63);
            this.ucT4Sang.Name = "ucT4Sang";
            this.ucT4Sang.Size = new System.Drawing.Size(104, 152);
            this.ucT4Sang.TabIndex = 13;
            // 
            // ucT5Sang
            // 
            this.ucT5Sang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT5Sang.Location = new System.Drawing.Point(440, 63);
            this.ucT5Sang.Name = "ucT5Sang";
            this.ucT5Sang.Size = new System.Drawing.Size(104, 152);
            this.ucT5Sang.TabIndex = 14;
            // 
            // ucT6Sang
            // 
            this.ucT6Sang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT6Sang.Location = new System.Drawing.Point(551, 63);
            this.ucT6Sang.Name = "ucT6Sang";
            this.ucT6Sang.Size = new System.Drawing.Size(104, 152);
            this.ucT6Sang.TabIndex = 15;
            // 
            // ucT7Sang
            // 
            this.ucT7Sang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT7Sang.Location = new System.Drawing.Point(662, 63);
            this.ucT7Sang.Name = "ucT7Sang";
            this.ucT7Sang.Size = new System.Drawing.Size(104, 152);
            this.ucT7Sang.TabIndex = 16;
            // 
            // ucCNSang
            // 
            this.ucCNSang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCNSang.Location = new System.Drawing.Point(773, 63);
            this.ucCNSang.Name = "ucCNSang";
            this.ucCNSang.Size = new System.Drawing.Size(105, 152);
            this.ucCNSang.TabIndex = 17;
            // 
            // ucT2Trua
            // 
            this.ucT2Trua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT2Trua.Location = new System.Drawing.Point(107, 222);
            this.ucT2Trua.Name = "ucT2Trua";
            this.ucT2Trua.Size = new System.Drawing.Size(104, 152);
            this.ucT2Trua.TabIndex = 18;
            // 
            // ucT3Trua
            // 
            this.ucT3Trua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT3Trua.Location = new System.Drawing.Point(218, 222);
            this.ucT3Trua.Name = "ucT3Trua";
            this.ucT3Trua.Size = new System.Drawing.Size(104, 152);
            this.ucT3Trua.TabIndex = 19;
            // 
            // ucT4Trua
            // 
            this.ucT4Trua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT4Trua.Location = new System.Drawing.Point(329, 222);
            this.ucT4Trua.Name = "ucT4Trua";
            this.ucT4Trua.Size = new System.Drawing.Size(104, 152);
            this.ucT4Trua.TabIndex = 20;
            // 
            // ucT5Trua
            // 
            this.ucT5Trua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT5Trua.Location = new System.Drawing.Point(440, 222);
            this.ucT5Trua.Name = "ucT5Trua";
            this.ucT5Trua.Size = new System.Drawing.Size(104, 152);
            this.ucT5Trua.TabIndex = 21;
            // 
            // ucT6Trua
            // 
            this.ucT6Trua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT6Trua.Location = new System.Drawing.Point(551, 222);
            this.ucT6Trua.Name = "ucT6Trua";
            this.ucT6Trua.Size = new System.Drawing.Size(104, 152);
            this.ucT6Trua.TabIndex = 22;
            // 
            // ucT7Trua
            // 
            this.ucT7Trua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT7Trua.Location = new System.Drawing.Point(662, 222);
            this.ucT7Trua.Name = "ucT7Trua";
            this.ucT7Trua.Size = new System.Drawing.Size(104, 152);
            this.ucT7Trua.TabIndex = 23;
            // 
            // ucCNTrua
            // 
            this.ucCNTrua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCNTrua.Location = new System.Drawing.Point(773, 222);
            this.ucCNTrua.Name = "ucCNTrua";
            this.ucCNTrua.Size = new System.Drawing.Size(105, 152);
            this.ucCNTrua.TabIndex = 24;
            // 
            // ucT2Toi
            // 
            this.ucT2Toi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT2Toi.Location = new System.Drawing.Point(107, 381);
            this.ucT2Toi.Name = "ucT2Toi";
            this.ucT2Toi.Size = new System.Drawing.Size(104, 153);
            this.ucT2Toi.TabIndex = 25;
            // 
            // ucT3Toi
            // 
            this.ucT3Toi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT3Toi.Location = new System.Drawing.Point(218, 381);
            this.ucT3Toi.Name = "ucT3Toi";
            this.ucT3Toi.Size = new System.Drawing.Size(104, 153);
            this.ucT3Toi.TabIndex = 26;
            // 
            // ucT4Toi
            // 
            this.ucT4Toi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT4Toi.Location = new System.Drawing.Point(329, 381);
            this.ucT4Toi.Name = "ucT4Toi";
            this.ucT4Toi.Size = new System.Drawing.Size(104, 153);
            this.ucT4Toi.TabIndex = 27;
            // 
            // ucT5Toi
            // 
            this.ucT5Toi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT5Toi.Location = new System.Drawing.Point(440, 381);
            this.ucT5Toi.Name = "ucT5Toi";
            this.ucT5Toi.Size = new System.Drawing.Size(104, 153);
            this.ucT5Toi.TabIndex = 28;
            // 
            // ucT6Toi
            // 
            this.ucT6Toi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT6Toi.Location = new System.Drawing.Point(551, 381);
            this.ucT6Toi.Name = "ucT6Toi";
            this.ucT6Toi.Size = new System.Drawing.Size(104, 153);
            this.ucT6Toi.TabIndex = 29;
            // 
            // ucT7Toi
            // 
            this.ucT7Toi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucT7Toi.Location = new System.Drawing.Point(662, 381);
            this.ucT7Toi.Name = "ucT7Toi";
            this.ucT7Toi.Size = new System.Drawing.Size(104, 153);
            this.ucT7Toi.TabIndex = 30;
            // 
            // ucCNToi
            // 
            this.ucCNToi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCNToi.Location = new System.Drawing.Point(773, 381);
            this.ucCNToi.Name = "ucCNToi";
            this.ucCNToi.Size = new System.Drawing.Size(105, 153);
            this.ucCNToi.TabIndex = 31;
            // 
            // pnlChooser
            // 
            this.pnlChooser.BackColor = System.Drawing.Color.White;
            this.pnlChooser.Controls.Add(this.pnlTienDo);
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
            this.pnlChooser.Size = new System.Drawing.Size(184, 548);
            this.pnlChooser.TabIndex = 0;
            // 
            // pnlTienDo
            // 
            this.pnlTienDo.Controls.Add(this.lblChatBeo);
            this.pnlTienDo.Controls.Add(this.prgChatBeo);
            this.pnlTienDo.Controls.Add(this.lblChatXo);
            this.pnlTienDo.Controls.Add(this.prgChatXo);
            this.pnlTienDo.Controls.Add(this.lblDam);
            this.pnlTienDo.Controls.Add(this.prgDam);
            this.pnlTienDo.Controls.Add(this.label1);
            this.pnlTienDo.Location = new System.Drawing.Point(18, 257);
            this.pnlTienDo.Name = "pnlTienDo";
            this.pnlTienDo.Size = new System.Drawing.Size(158, 252);
            this.pnlTienDo.TabIndex = 6;
            // 
            // lblChatBeo
            // 
            this.lblChatBeo.AutoSize = true;
            this.lblChatBeo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic);
            this.lblChatBeo.Location = new System.Drawing.Point(0, 176);
            this.lblChatBeo.Name = "lblChatBeo";
            this.lblChatBeo.Size = new System.Drawing.Size(92, 17);
            this.lblChatBeo.TabIndex = 6;
            this.lblChatBeo.Text = "CHẤT BÉO: 0%";
            // 
            // prgChatBeo
            // 
            this.prgChatBeo.Location = new System.Drawing.Point(0, 196);
            this.prgChatBeo.Name = "prgChatBeo";
            this.prgChatBeo.Size = new System.Drawing.Size(158, 19);
            this.prgChatBeo.TabIndex = 5;
            // 
            // lblChatXo
            // 
            this.lblChatXo.AutoSize = true;
            this.lblChatXo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic);
            this.lblChatXo.Location = new System.Drawing.Point(0, 107);
            this.lblChatXo.Name = "lblChatXo";
            this.lblChatXo.Size = new System.Drawing.Size(87, 17);
            this.lblChatXo.TabIndex = 4;
            this.lblChatXo.Text = "CHẤT XƠ: 0%";
            // 
            // prgChatXo
            // 
            this.prgChatXo.Location = new System.Drawing.Point(0, 127);
            this.prgChatXo.Name = "prgChatXo";
            this.prgChatXo.Size = new System.Drawing.Size(158, 17);
            this.prgChatXo.TabIndex = 3;
            // 
            // lblDam
            // 
            this.lblDam.AutoSize = true;
            this.lblDam.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic);
            this.lblDam.Location = new System.Drawing.Point(0, 52);
            this.lblDam.Name = "lblDam";
            this.lblDam.Size = new System.Drawing.Size(61, 17);
            this.lblDam.TabIndex = 2;
            this.lblDam.Text = "ĐẠM: 0%";
            // 
            // prgDam
            // 
            this.prgDam.Location = new System.Drawing.Point(0, 72);
            this.prgDam.Name = "prgDam";
            this.prgDam.Size = new System.Drawing.Size(155, 14);
            this.prgDam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "TIÊU CHUẨN TUẦN";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(96)))), ((int)(((byte)(105)))));
            this.lblStatus.Location = new System.Drawing.Point(18, 238);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(104, 16);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Đã chọn 0/98 ô...";
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
            this.lblChooserTitle.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold);
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
            this.ClientSize = new System.Drawing.Size(1144, 744);
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
            this.weekGrid.ResumeLayout(false);
            this.pnlChooser.ResumeLayout(false);
            this.pnlChooser.PerformLayout();
            this.pnlTienDo.ResumeLayout(false);
            this.pnlTienDo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // ============================================================
        // KHAI BÁO BIẾN (fields) cho tất cả control trên form
        // ============================================================

        // Panel & layout chính
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        protected internal System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.FlowLayoutPanel flpToolbar;
        private System.Windows.Forms.DateTimePicker dtpWeek;
        private System.Windows.Forms.ComboBox cboCheDo;
        private System.Windows.Forms.Label lblWeekRange;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDienTuMau;
        private System.Windows.Forms.SplitContainer splBody;

        // Lưới thực đơn
        private System.Windows.Forms.TableLayoutPanel weekGrid;

        // Header labels (dòng 0)
        private System.Windows.Forms.Label lblHeaderBuoi;
        private System.Windows.Forms.Label lblHeaderT2;
        private System.Windows.Forms.Label lblHeaderT3;
        private System.Windows.Forms.Label lblHeaderT4;
        private System.Windows.Forms.Label lblHeaderT5;
        private System.Windows.Forms.Label lblHeaderT6;
        private System.Windows.Forms.Label lblHeaderT7;
        private System.Windows.Forms.Label lblHeaderCN;

        // Meal labels (cột 0)
        private System.Windows.Forms.Label lblMealSang;
        private System.Windows.Forms.Label lblMealTrua;
        private System.Windows.Forms.Label lblMealToi;

        // UserControl dòng Sáng (mỗi ô có 3 slot: Mặn, Canh, Sữa)
        private UcMealCellSang ucT2Sang;
        private UcMealCellSang ucT3Sang;
        private UcMealCellSang ucT4Sang;
        private UcMealCellSang ucT5Sang;
        private UcMealCellSang ucT6Sang;
        private UcMealCellSang ucT7Sang;
        private UcMealCellSang ucCNSang;

        // UserControl dòng Trưa (mỗi ô có 7 slot: 4 Mặn, Canh, Rau, Tráng miệng)
        private UcMealCellTruaToi ucT2Trua;
        private UcMealCellTruaToi ucT3Trua;
        private UcMealCellTruaToi ucT4Trua;
        private UcMealCellTruaToi ucT5Trua;
        private UcMealCellTruaToi ucT6Trua;
        private UcMealCellTruaToi ucT7Trua;
        private UcMealCellTruaToi ucCNTrua;

        // UserControl dòng Tối (giống Trưa)
        private UcMealCellTruaToi ucT2Toi;
        private UcMealCellTruaToi ucT3Toi;
        private UcMealCellTruaToi ucT4Toi;
        private UcMealCellTruaToi ucT5Toi;
        private UcMealCellTruaToi ucT6Toi;
        private UcMealCellTruaToi ucT7Toi;
        private UcMealCellTruaToi ucCNToi;

        // Panel chọn món bên phải
        private System.Windows.Forms.Panel pnlChooser;
        private System.Windows.Forms.Label lblChooserTitle;
        private System.Windows.Forms.Label lblActiveSlot;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel pnlTienDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prgDam;
        private System.Windows.Forms.Label lblDam;
        private System.Windows.Forms.Label lblChatXo;
        private System.Windows.Forms.ProgressBar prgChatXo;
        private System.Windows.Forms.ProgressBar prgChatBeo;
        private System.Windows.Forms.Label lblChatBeo;
    }
}
