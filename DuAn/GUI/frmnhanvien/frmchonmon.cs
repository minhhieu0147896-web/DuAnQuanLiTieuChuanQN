using DuAn.BUL;
using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmchonmon : Form
    {
        private readonly string _loaiMon;
        private readonly string _ghiChu;
        private readonly Dictionary<string, MonAnModel> _currentWeekMeals;
        private readonly DateTime _targetDate;
        private readonly int _targetBuoiId;
        private readonly string _targetSlotKey;
        private readonly bool _hasDuplicateContext;

        // Hằng số: tên ComboBox chế độ ăn trên form cha (frmLapthucdon2)
        private const string PARENT_CBO_NAME = "cboCheDo";

        private int _cheDoId;
        private int _lastMonAnId = -1;
        private List<MonAnModel> _dsMonGoc;  // Lưu danh sách gốc để lọc tìm kiếm

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

            InitializeComponent();
            dgvMonAn.CellFormatting += dgvMonAn_CellFormatting;
            dgvMonAn.CellDoubleClick += (s, ev) => ChooseSelected();
            btnChon.Click += (s, ev) => ChooseSelected();
            btnHuy.Click += (s, ev) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            // Sự kiện cho ô tìm kiếm
            txtTimKiem.Enter += (s, ev) =>
            {
                if (txtTimKiem.Text == "🔍 Tìm món...")
                {
                    txtTimKiem.Text = "";
                    txtTimKiem.ForeColor = Color.Black;
                }
            };
            txtTimKiem.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    txtTimKiem.Text = "🔍 Tìm món...";
                    txtTimKiem.ForeColor = Color.Gray;
                }
            };
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void frmchonmon_Load(object sender, EventArgs e)
        {
            _cheDoId = LayCheDoId();

            lblTitle.Text = string.IsNullOrWhiteSpace(_ghiChu)
                ? "Chọn món " + _loaiMon
                : "Chọn món " + _loaiMon + " - " + _ghiChu;

            List<MonAnModel> dishes = MonAnDAO.Instance.GetByNhomLoaiMon(_loaiMon, _ghiChu);
            _dsMonGoc = dishes;  // Lưu lại danh sách gốc để lọc
            BuildDuplicateStatusMap(dishes);

            dgvMonAn.DataSource = dishes;

            bool hasData = dishes.Count > 0;
            lblEmpty.Visible = !hasData;
            lblEmpty.Text = string.IsNullOrWhiteSpace(_ghiChu)
                ? "Không tìm thấy món có loại món phù hợp: " + _loaiMon
                : "Không tìm thấy món có loại món phù hợp: " + _loaiMon + ", ghi chú: " + _ghiChu;
            btnChon.Enabled = hasData;

            if (hasData)
            {
                dgvMonAn.Rows[0].Selected = true;
                HienThiNguyenLieu(dishes[0].MonAnId);
            }

            // Đăng ký sự kiện sau khi đã có dữ liệu, tránh chạy khi grid còn trống
            dgvMonAn.SelectionChanged += dgvMonAn_SelectionChanged;
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

        private void dgvMonAn_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMonAn.CurrentRow == null)
                return;

            int monAnId = Convert.ToInt32(dgvMonAn.CurrentRow.Cells["colMonAnId"].Value);

            if (monAnId == _lastMonAnId)
                return;
            _lastMonAnId = monAnId;

            HienThiNguyenLieu(monAnId);
        }

        /// <summary>
        /// Mỗi khi người dùng gõ vào ô tìm kiếm → lọc danh sách món ăn
        /// </summary>
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (_dsMonGoc == null) return;

            string tuKhoa = txtTimKiem.Text.Trim();

            // Nếu đang hiển thị placeholder thì không lọc
            if (tuKhoa == "🔍 Tìm món..." || string.IsNullOrEmpty(tuKhoa))
            {
                dgvMonAn.DataSource = _dsMonGoc;
                return;
            }

            // Lọc danh sách: tên món chứa từ khóa (không phân biệt hoa thường)
            List<MonAnModel> dsLoc = new List<MonAnModel>();
            foreach (MonAnModel mon in _dsMonGoc)
            {
                if (mon.TenMon.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    dsLoc.Add(mon);
                }
            }

            dgvMonAn.DataSource = dsLoc;
        }

        /// <summary>
        /// Tải nguyên liệu của món ăn từ DB và hiển thị lên bảng bên phải
        /// </summary>
        private void HienThiNguyenLieu(int monAnId)
        {
            try
            {
                // Gọi BUL lấy dữ liệu từ procedure sp_MonAn_LayNguyenLieu
                DataTable dt = B_MonAn.LayDanhSachNguyenLieu(monAnId, _cheDoId);

                // Gán vào lưới bên phải
                dgvNguyenLieu.DataSource = null;
                dgvNguyenLieu.DataSource = dt;

                // Nếu không có nguyên liệu, hiển thị thông báo nhẹ nhàng
                if (dt.Rows.Count == 0)
                {
                    dgvNguyenLieu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi để sinh viên dễ debug
                MessageBox.Show(
                    "Lỗi khi tải nguyên liệu:\n" + ex.Message +
                    "\n\nmonAnId=" + monAnId + ", cheDoId=" + _cheDoId,
                    "Lỗi truy vấn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dgvNguyenLieu.DataSource = null;
            }
        }

        private int LayCheDoId()
        {
            try
            {
                if (this.Owner != null)
                {
                    Control[] controls = this.Owner.Controls.Find(PARENT_CBO_NAME, true);
                    if (controls.Length > 0 && controls[0] is ComboBox cbo)
                    {
                        if (cbo.SelectedValue != null)
                        {
                            return Convert.ToInt32(cbo.SelectedValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Không lấy được chế độ ăn từ form cha: " + ex.Message);
            }

            return LayCheDoMacDinhTuDB();
        }

        private int LayCheDoMacDinhTuDB()
        {
            try
            {
                DataTable dt = B_MonAn.LayDanhSachCheDo();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["chedo_id"]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Không lấy được chế độ mặc định từ DB: " + ex.Message);
            }
            return 1;
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

    }
}
