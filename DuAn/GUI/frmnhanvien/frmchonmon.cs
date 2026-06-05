using DuAn.BUL;
using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public class frmchonmon : Form
    {
        private readonly string _loaiMon;
        private readonly string _ghiChu;
        private readonly Dictionary<string, MonAnModel> _currentWeekMeals;
        private readonly DateTime _targetDate;
        private readonly int _targetBuoiId;
        private readonly string _targetSlotKey;
        private readonly bool _hasDuplicateContext;

        private DataGridView dgvMonAn;
        private DataGridViewTextBoxColumn colKhuyenNghi;
        private Label lblTitle;
        private Label lblEmpty;
        private Button btnChon;
        private Button btnHuy;

        private readonly Dictionary<int, DuplicateStatus> _statusByMonId = new Dictionary<int, DuplicateStatus>();

        public MonAnModel MonDaChon { get; private set; }

        public frmchonmon(string loaiMon)
            : this(loaiMon, null)
        {
        }

        public frmchonmon(string loaiMon, string ghiChu)
            : this(loaiMon, ghiChu, null, DateTime.MinValue, 0, null)
        {
        }

        public frmchonmon(
            string loaiMon,
            string ghiChu,
            Dictionary<string, MonAnModel> currentWeekMeals,
            DateTime targetDate,
            int targetBuoiId)
            : this(loaiMon, ghiChu, currentWeekMeals, targetDate, targetBuoiId, null)
        {
        }

        public frmchonmon(
            string loaiMon,
            string ghiChu,
            Dictionary<string, MonAnModel> currentWeekMeals,
            DateTime targetDate,
            int targetBuoiId,
            string targetSlotKey)
        {
            _loaiMon = loaiMon;
            _ghiChu = ghiChu;
            _currentWeekMeals = currentWeekMeals;
            _targetDate = targetDate.Date;
            _targetBuoiId = targetBuoiId;
            _targetSlotKey = targetSlotKey;
            _hasDuplicateContext = currentWeekMeals != null;

            BuildLayout();
            Load += frmchonmon_Load;
        }

        private void BuildLayout()
        {
            Text = "Chọn món";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(720, 520);
            MinimumSize = new Size(620, 440);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                BackColor = Color.FromArgb(33, 48, 64),
                Padding = new Padding(18, 0, 18, 0)
            };

            lblTitle = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            header.Controls.Add(lblTitle);

            dgvMonAn = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MonAnId",
                HeaderText = "Mã",
                Width = 70
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenMon",
                HeaderText = "Tên món",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiMon",
                HeaderText = "Loại món",
                Width = 120
            });
            colKhuyenNghi = new DataGridViewTextBoxColumn
            {
                Name = "ColKhuyenNghi",
                HeaderText = "Khuyến nghị",
                Width = 220,
                ReadOnly = true
            };
            dgvMonAn.Columns.Add(colKhuyenNghi);

            dgvMonAn.CellFormatting += dgvMonAn_CellFormatting;
            dgvMonAn.CellDoubleClick += (s, e) => ChooseSelected();

            lblEmpty = new Label
            {
                Dock = DockStyle.Top,
                Height = 36,
                ForeColor = Color.FromArgb(180, 60, 60),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(18, 0, 18, 0),
                Visible = false
            };

            Panel footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 62,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(18, 10, 18, 10)
            };

            btnChon = CreateButton("Chọn món", Color.FromArgb(38, 132, 255), Color.White);
            btnChon.Dock = DockStyle.Right;
            btnChon.Click += (s, e) => ChooseSelected();

            btnHuy = CreateButton("Hủy", Color.FromArgb(236, 241, 247), Color.FromArgb(33, 48, 64));
            btnHuy.Dock = DockStyle.Right;
            btnHuy.Margin = new Padding(0, 0, 10, 0);
            btnHuy.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            footer.Controls.Add(btnChon);
            footer.Controls.Add(btnHuy);

            Controls.Add(dgvMonAn);
            Controls.Add(lblEmpty);
            Controls.Add(footer);
            Controls.Add(header);
        }

        private void frmchonmon_Load(object sender, EventArgs e)
        {
            lblTitle.Text = string.IsNullOrWhiteSpace(_ghiChu)
                ? "Chọn món " + _loaiMon
                : "Chọn món " + _loaiMon + " - " + _ghiChu;

            List<MonAnModel> dishes = MonAnDAO.Instance.GetByNhomLoaiMon(_loaiMon, _ghiChu);
            BuildDuplicateStatusMap(dishes);

            dgvMonAn.DataSource = dishes;

            bool hasData = dishes.Count > 0;
            lblEmpty.Visible = !hasData;
            lblEmpty.Text = string.IsNullOrWhiteSpace(_ghiChu)
                ? "Không tìm thấy món có loại món phù hợp: " + _loaiMon
                : "Không tìm thấy món có loại món phù hợp: " + _loaiMon + ", ghi chú: " + _ghiChu;
            btnChon.Enabled = hasData;

            if (hasData)
                dgvMonAn.Rows[0].Selected = true;
        }

        private void BuildDuplicateStatusMap(List<MonAnModel> dishes)
        {
            _statusByMonId.Clear();

            if (!_hasDuplicateContext)
            {
                foreach (MonAnModel dish in dishes)
                    _statusByMonId[dish.MonAnId] = DuplicateStatus.None;
                return;
            }

            foreach (MonAnModel dish in dishes)
            {
                _statusByMonId[dish.MonAnId] = DuplicateChecker.GetStatus(
                    dish.MonAnId,
                    dish.LoaiMon,
                    _targetDate,
                    _targetBuoiId,
                    _currentWeekMeals,
                    _targetSlotKey);
            }
        }

        private DuplicateStatus GetStatusForMon(MonAnModel mon)
        {
            if (mon == null)
                return DuplicateStatus.None;

            DuplicateStatus status;
            if (_statusByMonId.TryGetValue(mon.MonAnId, out status))
                return status;

            return DuplicateStatus.None;
        }

        private string GetKhuyenNghiText(MonAnModel mon)
        {
            DuplicateStatus status = GetStatusForMon(mon);
            return DuplicateChecker.GetStatusMessage(status, mon?.LoaiMon);
        }

        private void dgvMonAn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvMonAn.Rows.Count)
                return;

            MonAnModel mon = dgvMonAn.Rows[e.RowIndex].DataBoundItem as MonAnModel;
            if (mon == null)
                return;

            if (dgvMonAn.Columns[e.ColumnIndex] == colKhuyenNghi)
                e.Value = GetKhuyenNghiText(mon);

            DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];
            DuplicateStatus status = GetStatusForMon(mon);

            switch (status)
            {
                case DuplicateStatus.BlockedSameMeal:
                case DuplicateStatus.BlockedSameDay:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(110, 110, 110);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 200);
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(80, 80, 80);
                    break;

                case DuplicateStatus.WarningDaySpan:
                case DuplicateStatus.WarningFreq:
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 95, 20);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 235, 170);
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(150, 75, 10);
                    break;

                default:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
                    row.DefaultCellStyle.SelectionForeColor = Color.Black;
                    break;
            }
        }

        private void ChooseSelected()
        {
            if (dgvMonAn.CurrentRow == null || dgvMonAn.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn một món.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MonAnModel selected = dgvMonAn.CurrentRow.DataBoundItem as MonAnModel;
            if (selected == null)
                return;

            DuplicateStatus status = GetStatusForMon(selected);
            if (DuplicateChecker.IsBlocked(status))
            {
                string reason = status == DuplicateStatus.BlockedSameMeal
                    ? "đã có trong buổi ăn này"
                    : "đã được dùng ở bữa khác trong cùng ngày";
                MessageBox.Show(
                    "Món \"" + selected.TenMon + "\" " + reason + ".\nVui lòng chọn món khác.",
                    "Không thể chọn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MonDaChon = selected;
            DialogResult = DialogResult.OK;
            Close();
        }

        private static Button CreateButton(string text, Color backColor, Color foreColor)
        {
            Button button = new Button
            {
                Text = text,
                Width = 112,
                Height = 40,
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 218, 226);
            return button;
        }
    }
}
