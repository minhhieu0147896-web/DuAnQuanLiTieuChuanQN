using DuAn.BUL;
using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmLapthucdon2 : Form
    {
        // ============================================================
        // HẰNG SỐ & BIẾN TOÀN CỤC
        // ============================================================

        private const int CurrentUserId = 1;

        // Bộ đệm thực đơn theo tuần (key: yyyyMMdd của thứ 2 đầu tuần)
        private readonly Dictionary<int, Dictionary<string, MonAnModel>> _weeklyBuffers
            = new Dictionary<int, Dictionary<string, MonAnModel>>();

        // Bộ đệm trạng thái của từng tuần
        private readonly Dictionary<int, string> _weeklyStatuses = new Dictionary<int, string>();

        // === THAY ĐỔI LỚN: _slots giờ là Dictionary<string, Button> ===
        // Trước đây dùng SlotButton (class tự định nghĩa), giờ dùng Button có sẵn
        // Metadata (ngày, buổi, loại món...) được lưu trong Button.Tag
        private readonly Dictionary<string, Button> _slots = new Dictionary<string, Button>();
        private readonly Dictionary<string, MonAnModel> _selectedMeals = new Dictionary<string, MonAnModel>();

        private List<BuoiAnModel> _buoiAns = new List<BuoiAnModel>();
        private NutritionTargetModel _weeklyNutritionTarget = new NutritionTargetModel();

        // Ô đang được chọn (active slot) — giờ là Button thay vì SlotButton
        private Button _activeSlot;
        private bool _isLoadingReferenceData;
        private bool _isInitialized;
        private string _currentWeekStatus = "NhapLieu";

        // === MẢNG THAM CHIẾU NHANH ĐẾN CÁC CONTROL TRONG LƯỚI ===
        // Giúp truy xuất nhanh không cần if/switch dài dòng
        private Label[] _dayHeaders;          // 7 label tiêu đề ngày (T2..CN)
        private UserControl[,] _mealCells;    // [3 dòng buổi, 7 ngày]
        private ToolTip _toolTip;              // Hiện gợi ý khi rê chuột vào tiêu đề ngày

        // Win32 API để đổi màu ProgressBar
        private const int PBM_SETSTATE = 0x0410;
        private const int PBST_NORMAL = 1;
        private const int PBST_ERROR = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        // ============================================================
        // CONSTRUCTOR & LOAD
        // ============================================================

        public frmLapthucdon2()
        {
            InitializeComponent();

            _toolTip = new ToolTip();
            _toolTip.SetToolTip(lblHeaderT2, "Click để xem chi tiết ngày");

            // === CHỐNG FLICKER: DoubleBuffered cho form + container nặng ===
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint, true);

            // Khởi tạo mảng tham chiếu nhanh đến các control trong lưới
            InitGridReferenceArrays();

            Load += frmLapthucdon2_Load;
            FormClosing += frmLapthucdon2_FormClosing;
        }

        /// <summary>
        /// Bật DoubleBuffered cho control qua reflection
        /// (dùng cho TableLayoutPanel, Panel, SplitContainer... không có sẵn property này)
        /// </summary>
        private static void SetDoubleBuffered(Control control)
        {
            PropertyInfo prop = typeof(Control).GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            prop?.SetValue(control, true, null);
        }

        /// <summary>
        /// Gán các control trong weekGrid vào mảng để truy xuất nhanh.
        /// Mảng 2 chiều: _mealCells[dòng, cột] với dòng 0=Sáng, 1=Trưa, 2=Tối
        /// </summary>
        private void InitGridReferenceArrays()
        {
            _dayHeaders = new Label[]
            {
                lblHeaderT2, lblHeaderT3, lblHeaderT4, lblHeaderT5,
                lblHeaderT6, lblHeaderT7, lblHeaderCN
            };

            // Gắn sự kiện click, hover, và tooltip cho 7 label tiêu đề ngày
            foreach (Label lbl in _dayHeaders)
            {
                lbl.Cursor = Cursors.Hand;
                lbl.Click += DayHeader_Click;
                lbl.MouseEnter += DayHeader_MouseEnter;
                lbl.MouseLeave += DayHeader_MouseLeave;
            }

            // Cập nhật tooltip sau khi _dayHeaders đã có (cho tất cả 7 label)
            foreach (Label lbl in _dayHeaders)
            {
                _toolTip.SetToolTip(lbl, "Click để xem chi tiết thống kê ngày");
            }

            _mealCells = new UserControl[3, 7]
            {
                // Dòng 0: Sáng
                { ucT2Sang, ucT3Sang, ucT4Sang, ucT5Sang, ucT6Sang, ucT7Sang, ucCNSang },
                // Dòng 1: Trưa
                { ucT2Trua, ucT3Trua, ucT4Trua, ucT5Trua, ucT6Trua, ucT7Trua, ucCNTrua },
                // Dòng 2: Tối
                { ucT2Toi, ucT3Toi, ucT4Toi, ucT5Toi, ucT6Toi, ucT7Toi, ucCNToi }
            };
        }

        /// <summary>
        /// Sự kiện Load — chạy MỘT LẦN khi form được mở lần đầu.
        /// Trình tự: chống flicker → gán sự kiện → chỉnh giao diện → load DB → hiển thị.
        /// </summary>
        private void frmLapthucdon2_Load(object sender, EventArgs e)
        {
            if (_isInitialized) return;
            _isInitialized = true;

            // === CHỐNG FLICKER: tạm dừng vẽ, làm xong mới vẽ 1 lần ===
            this.SuspendLayout();

            // Bật DoubleBuffered cho các container nặng
            SetDoubleBuffered(weekGrid);
            SetDoubleBuffered(splBody);
            SetDoubleBuffered(pnlChooser);
            SetDoubleBuffered(flpToolbar);

            WireEvents();
            SetupFormAppearance();
            LoadReferenceData();
            LoadWeek();

            this.ResumeLayout(true);
        }

        /// <summary>
        /// Gán tất cả sự kiện Click / ValueChanged cho các nút và control.
        /// Tách riêng ra để code Load không bị rối.
        /// </summary>
        private void WireEvents()
        {
            dtpWeek.ValueChanged += (s, ev) => LoadWeek();
            cboCheDo.SelectedIndexChanged += (s, ev) =>
            {
                if (!_isLoadingReferenceData) LoadWeek();
            };

            btnLuu.Click += btnluu_Click;
            btnDienTuMau.Click += btnDienTuMau_Click;
            btnXoaMon.Click += btnBo_Click;
            btnReload.Click += btnhienthi_Click;
            btnHelp.Click += btnHD_Click;
            btnBack.Click += btnExit_Click;
        }

        /// <summary>
        /// Thiết lập giao diện form: font, màu nền, style các nút.
        /// </summary>
        private void SetupFormAppearance()
        {
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 247, 250);

            // Label tiêu đề
            lblTitle.AutoSize = false;
            lblTitle.Width = 420;
            lblTitle.Height = pnlHeader.Height;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Padding = new Padding(24, 0, 0, 0);

            // Control trên toolbar
            dtpWeek.Width = 170;
            cboCheDo.Width = 190;
            lblWeekRange.Width = 300;
            lblWeekRange.Height = 48;
            lblWeekRange.TextAlign = ContentAlignment.MiddleLeft;

            // Nút Lưu
            btnLuu.Width = 170;
            btnLuu.Height = 42;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;

            // Nút Quay lại
            btnBack.Text = "Quay lại";
            btnLuu.Text = "Lưu thực đơn tuần";
            btnDienTuMau.Text = "Điền từ mẫu";
            btnXoaMon.Text = "Xóa món khỏi ô";
            btnReload.Text = "Tải lại từ cơ sở dữ liệu";
            btnHelp.Text = "Hướng dẫn";

            // Label chọn món
            lblChooserTitle.Text = "CHỌN MÓN";
            lblActiveSlot.Text = "Bấm vào một ô món trong bảng để mở form chọn món từ cơ sở dữ liệu.";
            lblActiveSlot.AutoSize = false;
            lblActiveSlot.Height = 72;

            lblStatus.AutoSize = false;
            lblStatus.Dock = DockStyle.Fill;

            // Cấu hình ProgressBar
            ConfigureProgressBar(prgDam);
            ConfigureProgressBar(prgChatXo);
            ConfigureProgressBar(prgChatBeo);
        }

        // ============================================================
        // LOAD DỮ LIỆU THAM CHIẾU (CHẾ ĐỘ, BUỔI ĂN)
        // Chạy 1 lần khi form load. Dữ liệu này không thay đổi trong phiên làm việc.
        // ============================================================

        /// <summary>
        /// Load danh sách buổi ăn (Sáng/Trưa/Tối) và danh sách chế độ (Học viên/Sĩ quan/...)
        /// từ database. Đổ vào _buoiAns và cboCheDo.
        /// Cờ _isLoadingReferenceData ngăn LoadWeek chạy khi đang đổ dữ liệu vào ComboBox.
        /// </summary>
        private void LoadReferenceData()
        {
            _isLoadingReferenceData = true;
            try
            {
                _buoiAns = BuoiAnDAO.Instance.GetAll();
                if (_buoiAns.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu buổi ăn.", "Thiếu dữ liệu",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable cheDo = B_QN.GetAllCheDo();
                cboCheDo.DisplayMember = "chedo_ten";
                cboCheDo.ValueMember = "chedo_id";
                cboCheDo.DataSource = cheDo;
            }
            finally
            {
                _isLoadingReferenceData = false;
            }
        }

        // ============================================================
        // LOAD TUẦN — TRÁI TIM CỦA FORM
        // Hàm này được gọi mỗi khi người dùng đổi tuần hoặc đổi chế độ.
        // Luồng: kiểm tra bộ đệm → nếu có thì dùng, không thì query DB →
        //        gán metadata cho Button → tự động điền sữa → vẽ lại → cập nhật trạng thái.
        // ============================================================

        /// <summary>
        /// Load toàn bộ dữ liệu của 1 tuần (7 ngày × 3 buổi).
        /// Ưu tiên lấy từ bộ đệm _weeklyBuffers để tránh query lại DB.
        /// </summary>
        private void LoadWeek()
        {
            if (!_isInitialized || cboCheDo.SelectedValue == null || _buoiAns.Count == 0)
                return;

            DateTime start = GetWeekStart(dtpWeek.Value);
            int weekKey = GetWeekKey(start);

            // 1. Lấy dữ liệu từ bộ đệm hoặc database
            if (_weeklyBuffers.ContainsKey(weekKey))
            {
                _selectedMeals.Clear();
                foreach (var kvp in _weeklyBuffers[weekKey])
                    _selectedMeals[kvp.Key] = kvp.Value;

                _currentWeekStatus = _weeklyStatuses.ContainsKey(weekKey)
                    ? _weeklyStatuses[weekKey] : "NhapLieu";
            }
            else
            {
                _selectedMeals.Clear();
                LoadExistingMealsFromDatabase(start, out string status);
                _currentWeekStatus = status;

                _weeklyBuffers[weekKey] = new Dictionary<string, MonAnModel>(_selectedMeals);
                _weeklyStatuses[weekKey] = _currentWeekStatus;
            }

            // 2. Cập nhật giao diện
            DateTime end = start.AddDays(6);
            lblWeekRange.Text = string.Format("Tuần {0:dd/MM/yyyy} - {1:dd/MM/yyyy}", start, end);
            _weeklyNutritionTarget = MonAnDAO.Instance.GetWeeklyNutritionTarget(GetSelectedCheDoId());

            // 3. Gán metadata cho các Button trong lưới (thay vì tạo mới như trước)
            PopulateWeekGrid(start);

            // 4. Tự động điền sữa nếu là chế độ học viên
            ApplyAutomaticMilkSlots();

            // 5. Cập nhật hiển thị
            RefreshSlots();
            UpdateStatus();
            ApplyEditPermissions();
        }

        // ============================================================
        // POPULATE WEEK GRID — Gán metadata cho Button CÓ SẴN
        // (KHÔNG tạo mới control như BuildWeekGrid cũ)
        // ============================================================

        /// <summary>
        /// Duyệt qua tất cả UserControl trong lưới, lấy Button từng slot,
        /// gán SlotMetadata vào Tag, gán sự kiện Click, và đăng ký vào _slots.
        /// </summary>
        private void PopulateWeekGrid(DateTime weekStart)
        {
            _slots.Clear();

            // Cập nhật tiêu đề ngày (thêm ngày tháng)
            for (int day = 0; day < 7; day++)
            {
                DateTime date = weekStart.AddDays(day);
                _dayHeaders[day].Text = GetDayTitle(date);
            }

            bool isHocVien = IsHocVienSelected();

            // Duyệt 3 buổi × 7 ngày
            for (int row = 0; row < 3; row++)
            {
                MealKind meal = (MealKind)row;
                BuoiAnModel buoi = FindBuoiAn(meal);

                for (int day = 0; day < 7; day++)
                {
                    DateTime date = weekStart.AddDays(day);
                    UserControl uc = _mealCells[row, day];

                    foreach (DishCategory category in GetRequiredCategories(meal))
                    {
                        int count = GetCategoryCount(meal, category);

                        for (int idx = 0; idx < count; idx++)
                        {
                            Button btn = GetSlotButtonFromUC(uc, category, idx);
                            if (btn == null) continue;

                            string key = BuildKey(date, buoi.BuoiAnId, category, idx);

                            // Lưu metadata vào Tag để dùng sau này
                            btn.Tag = new SlotMetadata
                            {
                                Key = key,
                                Date = date,
                                BuoiAn = buoi,
                                Meal = meal,
                                Category = category,
                                CategoryIndex = idx
                            };

                            // Gỡ handler cũ (nếu có), gán handler mới
                            btn.Click -= Slot_Click;
                            btn.Click += Slot_Click;

                            // Đăng ký vào từ điển
                            _slots[key] = btn;
                        }
                    }

                    // Ẩn/hiện nút Sữa trong ô Sáng tùy theo chế độ
                    if (uc is UcMealCellSang sangCell)
                    {
                        sangCell.SetSlotVisible(DishCategory.SuaHop, isHocVien);
                    }
                }
            }
        }

        /// <summary>
        /// Lấy Button từ UserControl theo loại món và chỉ số.
        /// UcMealCellSang và UcMealCellTruaToi đều có method GetSlotButton.
        /// </summary>
        private static Button GetSlotButtonFromUC(UserControl uc, DishCategory category, int index)
        {
            if (uc is UcMealCellSang sang)
                return sang.GetSlotButton(category, index);
            if (uc is UcMealCellTruaToi truaToi)
                return truaToi.GetSlotButton(category, index);
            return null;
        }

        // ============================================================
        // CÁC HÀM TIỆN ÍCH VỀ LOẠI MÓN & BUỔI
        // ============================================================

        /// <summary>
        /// Trả về danh sách loại món cần có cho mỗi buổi.
        /// Sáng: Mặn + Canh (+ Sữa nếu học viên)
        /// Trưa/Tối: 4 Mặn + Canh + Rau + Tráng miệng
        /// </summary>
        private IEnumerable<DishCategory> GetRequiredCategories(MealKind meal)
        {
            if (meal == MealKind.Sang)
            {
                yield return DishCategory.Man;
                yield return DishCategory.Canh;
                if (IsHocVienSelected())
                    yield return DishCategory.SuaHop;
                yield break;
            }

            yield return DishCategory.Man;      // 4 món mặn (xử lý qua count)
            yield return DishCategory.Canh;
            yield return DishCategory.Rau;
            yield return DishCategory.TrangMieng;
        }

        /// <summary>
        /// Số lượng slot cho mỗi loại món trong một buổi.
        /// </summary>
        private static int GetCategoryCount(MealKind meal, DishCategory category)
        {
            if (meal == MealKind.Sang)
                return 1; // Mỗi loại 1 slot

            // Trưa / Tối
            if (category == DishCategory.Man) return 4;
            return 1; // Canh, Rau, Tráng miệng: mỗi loại 1 slot
        }

        /// <summary>
        /// Tìm đối tượng BuoiAnModel tương ứng với MealKind (Sáng/Trưa/Tối).
        /// Dò theo từ khóa trong tên buổi, nếu không thấy thì lấy theo index.
        /// </summary>
        private BuoiAnModel FindBuoiAn(MealKind meal)
        {
            string keyword = GetMealKeyword(meal);
            BuoiAnModel found = _buoiAns.FirstOrDefault(x => NormalizeText(x.TenBuoi).Contains(keyword));
            if (found != null) return found;

            int index = meal == MealKind.Sang ? 0 : meal == MealKind.Trua ? 1 : 2;
            return _buoiAns[Math.Min(index, _buoiAns.Count - 1)];
        }

        /// <summary>
        /// Lấy ID của chế độ đang chọn trong ComboBox. Mặc định = 1 (học viên).
        /// </summary>
        private int GetSelectedCheDoId()
        {
            if (cboCheDo.SelectedValue is int value) return value;
            if (cboCheDo.SelectedValue == null) return 1;
            return Convert.ToInt32(cboCheDo.SelectedValue);
        }

        /// <summary>
        /// Kiểm tra chế độ hiện tại có phải "Học viên" không.
        /// Học viên có thêm slot Sữa hộp vào buổi sáng.
        /// Kiểm tra theo ID = 1 hoặc theo tên chứa "hoc vien".
        /// </summary>
        private bool IsHocVienSelected()
        {
            if (GetSelectedCheDoId() == 1) return true;

            DataRowView row = cboCheDo.SelectedItem as DataRowView;
            if (row != null && row.Row.Table.Columns.Contains("chedo_ten"))
                return NormalizeText(row["chedo_ten"].ToString()).Contains("hoc vien");

            return NormalizeText(cboCheDo.Text).Contains("hoc vien");
        }

        // ============================================================
        // LOAD DỮ LIỆU MÓN ĂN TỪ DATABASE
        // Duyệt 7 ngày × từng buổi × từng loại món, query DB và đổ vào _selectedMeals.
        // ============================================================

        /// <summary>
        /// Query database lấy tất cả món ăn đã lưu cho 1 tuần.
        /// Tham số out status: trả về trạng thái của tuần (NhapLieu/ChoDuyet/DaDuyet).
        /// Kết quả lưu vào _selectedMeals (Dictionary key → MonAnModel).
        /// </summary>
        private void LoadExistingMealsFromDatabase(DateTime weekStart, out string status)
        {
            status = "NhapLieu";
            int cheDoId = GetSelectedCheDoId();
            _selectedMeals.Clear();

            for (int day = 0; day < 7; day++)
            {
                DateTime date = weekStart.AddDays(day);
                ThucDonModel thucDon = ThucDonDAO.Instance.GetOrCreate(CurrentUserId, cheDoId, date);

                if (day == 0 && !string.IsNullOrEmpty(thucDon.TrangThai))
                    status = thucDon.TrangThai;

                List<ChiTietThucDonModel> details = ChiTietThucDonDAO.Instance.GetByThucDonNgay(thucDon.ThucDonId, date);

                foreach (IGrouping<int, ChiTietThucDonModel> mealGroup in details.GroupBy(x => x.BuoiAnId))
                {
                    foreach (IGrouping<DishCategory, ChiTietThucDonModel> categoryGroup
                        in mealGroup.GroupBy(x => ClassifyDishType(x.LoaiMon)))
                    {
                        int index = 0;
                        foreach (ChiTietThucDonModel item in categoryGroup)
                        {
                            string key = BuildKey(date, mealGroup.Key, categoryGroup.Key, index);
                            if (_slots.ContainsKey(key))
                            {
                                _selectedMeals[key] = new MonAnModel
                                {
                                    MonAnId = item.MonAnId,
                                    TenMon = item.TenMon,
                                    LoaiMon = item.LoaiMon,
                                    Dam = item.Dam,
                                    ChatXo = item.ChatXo,
                                    ChatBeo = item.ChatBeo
                                };
                            }
                            index++;
                        }
                    }
                }
            }
        }

        // ============================================================
        // SỰ KIỆN CLICK VÀO SLOT — MỞ FORM CHỌN MÓN
        // ============================================================

        /// <summary>
        /// Khi rê chuột vào tiêu đề ngày → đổi màu nền đậm hơn
        /// </summary>
        private void DayHeader_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
                lbl.BackColor = Color.FromArgb(208, 216, 228);
        }

        /// <summary>
        /// Khi rê chuột rời khỏi tiêu đề ngày → trả lại màu nền cũ
        /// </summary>
        private void DayHeader_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl != null)
                lbl.BackColor = Color.FromArgb(236, 241, 247);
        }

        /// <summary>
        /// Khi click vào tiêu đề ngày (T2..CN) → mở form chi tiết ngày đó
        /// </summary>
        private void DayHeader_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;

            // Tìm chỉ số ngày trong tuần (0 = T2, 6 = CN)
            int dayIndex = Array.IndexOf(_dayHeaders, lbl);
            if (dayIndex < 0) return;

            // Tính ngày tương ứng
            DateTime ngayDuocChon = GetWeekStart(dtpWeek.Value).AddDays(dayIndex);

            // Gom tất cả món đã chọn trong ngày từ _selectedMeals
            var dsMon = new List<MonAnTheoBuoi>();
            string ngayKey = ngayDuocChon.ToString("yyyyMMdd");

            foreach (var kvp in _selectedMeals)
            {
                // Key có dạng "yyyyMMdd-buoiAnId-category-index"
                if (!kvp.Key.StartsWith(ngayKey)) continue;

                MonAnModel mon = kvp.Value;
                if (mon == null) continue;

                // Tách buoiAnId từ key
                string[] parts = kvp.Key.Split('-');
                int buoiAnId = parts.Length >= 2 ? int.Parse(parts[1]) : 0;

                // Lấy tên buổi
                string tenBuoi = LayTenBuoi(buoiAnId);

                dsMon.Add(new MonAnTheoBuoi
                {
                    MonAnId = mon.MonAnId,
                    TenMon = mon.TenMon,
                    LoaiMon = mon.LoaiMon,
                    TenBuoi = tenBuoi,
                    Dam = mon.Dam,
                    ChatBeo = mon.ChatBeo,
                    ChatXo = mon.ChatXo
                });
            }

            // Lấy chế độ ăn hiện tại
            int cheDoId = 1;
            string tenCheDo = "";
            if (cboCheDo.SelectedValue != null)
            {
                cheDoId = Convert.ToInt32(cboCheDo.SelectedValue);
                tenCheDo = cboCheDo.Text;
            }

            // Mở form chi tiết
            using (var frm = new frmChiTietNgay(ngayDuocChon, cheDoId, tenCheDo, dsMon))
            {
                frm.ShowDialog(this);
            }
        }

        /// <summary>
        /// Trả về tên buổi từ buoiAnId (1=Sáng, 2=Trưa, 3=Chiều)
        /// </summary>
        private string LayTenBuoi(int buoiAnId)
        {
            switch (buoiAnId)
            {
                case 1: return "Sáng";
                case 2: return "Trưa";
                case 3: return "Chiều";
                default: return "Buổi " + buoiAnId;
            }
        }

        /// <summary>
        /// Khi người dùng click vào 1 ô món (Button slot) trong lưới.
        /// Lấy metadata từ Tag → kiểm tra quyền sửa → tô viền slot được chọn →
        /// mở form frmchonmon để chọn món.
        /// </summary>
        private void Slot_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            if (clickedBtn == null) return;

            SlotMetadata meta = clickedBtn.Tag as SlotMetadata;
            if (meta == null) return;

            // Nếu thực đơn đã duyệt → chỉ xem, không sửa
            if (!WeeklyMenuStateManager.IsEditable(_currentWeekStatus))
            {
                MessageBox.Show("Thực đơn tuần này đã được duyệt, không thể chỉnh sửa.\nChỉ có thể xem.",
                    "Thực đơn đã duyệt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _activeSlot = clickedBtn;

            // Bỏ viền tất cả slot, tô viền slot đang chọn
            foreach (Button slot in _slots.Values)
                slot.FlatAppearance.BorderSize = 1;
            clickedBtn.FlatAppearance.BorderSize = 3;

            lblActiveSlot.Text = string.Format("{0:dd/MM} - {1}\n{2} {3}",
                meta.Date, meta.BuoiAn.TenBuoi,
                GetCategoryTitle(meta.Category), meta.CategoryIndex + 1);

            if (meta.Category == DishCategory.SuaHop && IsHocVienSelected())
                return;

            OpenChooseDishForm(meta);
        }

        /// <summary>
        /// Mở form frmchonmon để người dùng chọn món cho 1 slot.
        /// Truyền loại món + ghi chú (SANG nếu là món mặn buổi sáng) để form lọc.
        /// Nếu chọn OK: kiểm tra đúng loại → lưu vào _selectedMeals + bộ đệm → vẽ lại.
        /// </summary>
        private void OpenChooseDishForm(SlotMetadata meta)
        {
            string loaiMon = GetCategoryTitle(meta.Category);
            string ghiChu = meta.Meal == MealKind.Sang && meta.Category == DishCategory.Man ? "SANG" : null;

            using (frmchonmon frm = new frmchonmon(
                loaiMon, ghiChu, _selectedMeals, meta.Date, meta.BuoiAn.BuoiAnId, meta.Key))
            {
                DialogResult result = frm.ShowDialog(this);
                if (result != DialogResult.OK || frm.MonDaChon == null) return;

                DishCategory selectedCategory = ClassifyDishType(frm.MonDaChon.LoaiMon);
                if (selectedCategory != meta.Category)
                {
                    MessageBox.Show("Món vừa chọn không đúng loại của ô hiện tại.", "Sai loại món",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RevertToNhapLieuIfNeeded();

                _selectedMeals[meta.Key] = frm.MonDaChon;

                DateTime weekStart = GetWeekStart(meta.Date);
                int weekKey = GetWeekKey(weekStart);
                if (!_weeklyBuffers.ContainsKey(weekKey))
                    _weeklyBuffers[weekKey] = new Dictionary<string, MonAnModel>();
                _weeklyBuffers[weekKey][meta.Key] = frm.MonDaChon;

                RefreshSlots();
                UpdateStatus();
            }
        }

        /// <summary>
        /// Nếu tuần đang ở trạng thái "Chờ duyệt" hoặc "Đã duyệt",
        /// tự động chuyển về "Nhập liệu" khi người dùng bắt đầu sửa.
        /// Đảm bảo dữ liệu đã duyệt không bị sửa âm thầm.
        /// </summary>
        private void RevertToNhapLieuIfNeeded()
        {
            if (WeeklyMenuStateManager.ShouldAutoRevert(_currentWeekStatus))
            {
                _currentWeekStatus = WeeklyMenuStateManager.GetRevertedStatus(_currentWeekStatus);

                DateTime weekStart = GetWeekStart(dtpWeek.Value);
                int weekKey = GetWeekKey(weekStart);
                _weeklyStatuses[weekKey] = _currentWeekStatus;

                ApplyEditPermissions();
            }
        }

        // ============================================================
        // KHÓA / MỞ KHÓA CHỈNH SỬA THEO TRẠNG THÁI
        // ============================================================

        /// <summary>
        /// Dựa vào _currentWeekStatus để khóa hoặc mở khóa toàn bộ control.
        /// "Đã duyệt" → khóa hết (chỉ xem). Còn lại → mở khóa (cho sửa).
        /// Gọi WeeklyMenuStateManager để xử lý tập trung.
        /// </summary>
        private void ApplyEditPermissions()
        {
            if (WeeklyMenuStateManager.IsEditable(_currentWeekStatus))
            {
                WeeklyMenuStateManager.UnlockEditing(
                    _slots.Values, btnXoaMon, btnDienTuMau, btnLuu, cboCheDo, dtpWeek);
            }
            else
            {
                WeeklyMenuStateManager.LockEditing(
                    _slots.Values, btnXoaMon, btnDienTuMau, btnLuu, cboCheDo, dtpWeek);
            }
        }

        // ============================================================
        // NÚT: XÓA MÓN KHỎI Ô ĐANG CHỌN
        // ============================================================

        /// <summary>
        /// Xóa món khỏi _activeSlot (slot đang được chọn).
        /// Nếu đang "Chờ duyệt" → tự động revert về "Nhập liệu" trước khi xóa.
        /// </summary>
        private void btnBo_Click(object sender, EventArgs e)
        {
            if (_activeSlot == null) return;
            if (!WeeklyMenuStateManager.IsEditable(_currentWeekStatus)) return;

            SlotMetadata meta = _activeSlot.Tag as SlotMetadata;
            if (meta == null) return;

            RevertToNhapLieuIfNeeded();
            _selectedMeals.Remove(meta.Key);

            DateTime weekStart = GetWeekStart(meta.Date);
            int weekKey = GetWeekKey(weekStart);
            if (_weeklyBuffers.ContainsKey(weekKey))
                _weeklyBuffers[weekKey].Remove(meta.Key);

            RefreshSlots();
            UpdateStatus();
        }

        // ============================================================
        // NÚT: TẢI LẠI TỪ DATABASE (Reload)
        // ============================================================

        /// <summary>
        /// Xóa bộ đệm của tuần hiện tại, load lại từ database.
        /// Dùng khi người dùng muốn hủy thay đổi chưa lưu.
        /// </summary>
        private void btnhienthi_Click(object sender, EventArgs e)
        {
            DateTime start = GetWeekStart(dtpWeek.Value);
            int weekKey = GetWeekKey(start);
            if (_weeklyBuffers.ContainsKey(weekKey)) _weeklyBuffers.Remove(weekKey);
            if (_weeklyStatuses.ContainsKey(weekKey)) _weeklyStatuses.Remove(weekKey);

            LoadWeek();
        }

        // ============================================================
        // NÚT: ĐIỀN TỪ MẪU — áp dụng thực đơn mẫu có sẵn vào tuần hiện tại
        // ============================================================

        /// <summary>
        /// Mở form chọn thực đơn mẫu → nếu chọn OK thì thay thế toàn bộ _selectedMeals
        /// bằng dữ liệu từ mẫu. Có xác nhận ghi đè nếu tuần đã có món.
        /// </summary>
        private void btnDienTuMau_Click(object sender, EventArgs e)
        {
            if (_slots.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tuần và chế độ trước khi điền từ mẫu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (frmChonThucDonMau frm = new frmChonThucDonMau())
            {
                if (frm.ShowDialog(this) != DialogResult.OK || frm.MauDaChon == null) return;

                if (_selectedMeals.Count > 0)
                {
                    DialogResult overwrite = MessageBox.Show(
                        "Tuần hiện tại đã có món được chọn.\nÁp dụng mẫu sẽ thay thế toàn bộ thực đơn trên lưới.\nBạn có muốn tiếp tục?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (overwrite != DialogResult.Yes) return;
                }

                DateTime weekStart = GetWeekStart(dtpWeek.Value);
                TemplateFillResult fillResult = WeeklyMenuFromTemplateFiller.FillFromTemplate(
                    frm.MauDaChon.MauId, weekStart, _slots.Keys);

                _selectedMeals.Clear();
                foreach (KeyValuePair<string, MonAnModel> entry in fillResult.Meals)
                    _selectedMeals[entry.Key] = entry.Value;

                int weekKey = GetWeekKey(weekStart);
                _weeklyBuffers[weekKey] = new Dictionary<string, MonAnModel>(_selectedMeals);

                _currentWeekStatus = WeeklyMenuStateManager.NhapLieu;
                _weeklyStatuses[weekKey] = _currentWeekStatus;

                ApplyAutomaticMilkSlots();
                RefreshSlots();
                UpdateStatus();
                ApplyEditPermissions();

                string tenMau = string.IsNullOrWhiteSpace(fillResult.MauTen)
                    ? frm.MauDaChon.MauTen : fillResult.MauTen;

                MessageBox.Show(
                    string.Format(
                        "Đã áp dụng mẫu «{0}».\nĐiền: {1} ô.\nBỏ qua (không khớp ô lưới): {2}.\nVị trí mẫu không hợp lệ: {3}.\nThứ trong tuần không hợp lệ: {4}.\n\nBạn có thể chỉnh sửa từng ô trước khi lưu.",
                        tenMau, fillResult.FilledCount, fillResult.SkippedNoSlot,
                        fillResult.SkippedInvalidViTri, fillResult.SkippedInvalidThu),
                    "Điền từ thực đơn mẫu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ============================================================
        // NÚT: LƯU THỰC ĐƠN TUẦN — ghi toàn bộ xuống database
        // ============================================================

        /// <summary>
        /// Kiểm tra thiếu món → xác nhận → xóa dữ liệu cũ của tuần trong DB →
        /// INSERT từng món đã chọn → cập nhật trạng thái "ChoDuyet" →
        /// xóa bộ đệm → load lại.
        /// </summary>
        private void btnluu_Click(object sender, EventArgs e)
        {
            string validationError = ValidateWeek();
            if (!string.IsNullOrEmpty(validationError))
            {
                MessageBox.Show(validationError, "Thực đơn chưa đủ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Lưu toàn bộ thực đơn trong tuần này vào cơ sở dữ liệu?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            int cheDoId = GetSelectedCheDoId();
            DateTime start = GetWeekStart(dtpWeek.Value);
            int weekKey = GetWeekKey(start);

            for (int day = 0; day < 7; day++)
            {
                DateTime date = start.AddDays(day);
                ThucDonModel thucDon = ThucDonDAO.Instance.GetOrCreate(CurrentUserId, cheDoId, date);

                foreach (BuoiAnModel buoi in _buoiAns)
                    ChiTietThucDonDAO.Instance.DeleteByThucDonNgayBuoi(thucDon.ThucDonId, date, buoi.BuoiAnId);

                foreach (Button slot in _slots.Values)
                {
                    SlotMetadata meta = slot.Tag as SlotMetadata;
                    if (meta == null) continue;
                    if (meta.Date.Date != date.Date) continue;

                    if (_selectedMeals.TryGetValue(meta.Key, out MonAnModel dish))
                        ChiTietThucDonDAO.Instance.Insert(thucDon.ThucDonId, date, meta.BuoiAn.BuoiAnId, dish.MonAnId);
                }

                ThucDonDAO.Instance.UpdateTrangThai(thucDon.ThucDonId, "ChoDuyet");
            }

            if (_weeklyBuffers.ContainsKey(weekKey)) _weeklyBuffers.Remove(weekKey);
            if (_weeklyStatuses.ContainsKey(weekKey)) _weeklyStatuses.Remove(weekKey);

            MessageBox.Show("Đã lưu thực đơn tuần. Trạng thái: Chờ duyệt.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadWeek();
        }

        // ============================================================
        // CẬP NHẬT HIỂN THỊ SLOT
        // ============================================================

        /// <summary>
        /// Làm mới text và màu nền của từng Button slot dựa trên _selectedMeals.
        /// </summary>
        private void RefreshSlots()
        {
            foreach (Button slot in _slots.Values)
            {
                SlotMetadata meta = slot.Tag as SlotMetadata;
                if (meta == null) continue;

                if (_selectedMeals.TryGetValue(meta.Key, out MonAnModel dish))
                {
                    slot.Text = dish.TenMon;
                    slot.BackColor = Color.White;
                }
                else
                {
                    slot.Text = GetSlotPlaceholder(meta.Category, meta.CategoryIndex);
                    slot.BackColor = GetCategoryColor(meta.Category);
                }
            }
        }

        /// <summary>
        /// Cập nhật thanh tiến độ dinh dưỡng và dòng trạng thái.
        /// </summary>
        private void UpdateStatus()
        {
            int total = _slots.Count;
            int selected = _selectedMeals.Count;
            NutritionTargetModel current = SumSelectedNutrition();
            double damPercent = GetPercent(current.Dam, _weeklyNutritionTarget.Dam);
            double chatXoPercent = GetPercent(current.ChatXo, _weeklyNutritionTarget.ChatXo);
            double chatBeoPercent = GetPercent(current.ChatBeo, _weeklyNutritionTarget.ChatBeo);

            UpdateNutritionProgress(prgDam, lblDam, "ĐẠM", current.Dam, _weeklyNutritionTarget.Dam, damPercent);
            UpdateNutritionProgress(prgChatXo, lblChatXo, "CHẤT XƠ", current.ChatXo, _weeklyNutritionTarget.ChatXo, chatXoPercent);
            UpdateNutritionProgress(prgChatBeo, lblChatBeo, "CHẤT BÉO", current.ChatBeo, _weeklyNutritionTarget.ChatBeo, chatBeoPercent);

            string breakfastRule = IsHocVienSelected()
                ? "Sáng: 1 món mặn, 1 canh, tự động có Sữa."
                : "Sáng: 1 món mặn, 1 canh.";
            string nutritionWarning = BuildNutritionWarning(damPercent, chatXoPercent, chatBeoPercent);
            string statusText = WeeklyMenuStateManager.GetDisplayName(_currentWeekStatus);

            lblStatus.Text = string.Format(
                "Đã chọn {0}/{1} ô.\nTrạng thái: {2}\n\nRàng buộc:\n{3}\nTrưa/tối: 4 món mặn, 1 canh, 1 rau, 1 tráng miệng.\n\n{4}",
                selected, total, statusText, breakfastRule, nutritionWarning);
        }

        /// <summary>
        /// Kiểm tra tất cả slot trong _slots: nếu slot nào chưa có món trong _selectedMeals
        /// thì báo lỗi "Còn thiếu món: [ngày] - [buổi] - [loại] [số]".
        /// Trả về null nếu đầy đủ.
        /// </summary>
        private string ValidateWeek()
        {
            foreach (Button slot in _slots.Values.OrderBy(s =>
            {
                SlotMetadata m = s.Tag as SlotMetadata;
                return m != null ? m.Date : DateTime.MinValue;
            }).ThenBy(s =>
            {
                SlotMetadata m = s.Tag as SlotMetadata;
                return m != null ? m.BuoiAn.BuoiAnId : 0;
            }))
            {
                SlotMetadata meta = slot.Tag as SlotMetadata;
                if (meta == null) continue;

                if (!_selectedMeals.ContainsKey(meta.Key))
                {
                    return string.Format("Còn thiếu món: {0:dd/MM/yyyy} - {1} - {2} {3}.",
                        meta.Date, meta.BuoiAn.TenBuoi,
                        GetCategoryTitle(meta.Category), meta.CategoryIndex + 1);
                }
            }
            return null;
        }

        // ============================================================
        // TỰ ĐỘNG ĐIỀN SỮA HỘP CHO CHẾ ĐỘ HỌC VIÊN
        // ============================================================

        /// <summary>
        /// Nếu chế độ là Học viên, tự động gán món "Sữa hộp" vào tất cả slot Sữa.
        /// Sữa là món mặc định, không cần người dùng chọn.
        /// </summary>
        private void ApplyAutomaticMilkSlots()
        {
            if (!IsHocVienSelected()) return;

            MonAnModel milk = MonAnDAO.Instance.GetOrCreateSua();
            foreach (Button slot in _slots.Values)
            {
                SlotMetadata meta = slot.Tag as SlotMetadata;
                if (meta != null && meta.Category == DishCategory.SuaHop)
                    _selectedMeals[meta.Key] = milk;
            }
        }

        // ============================================================
        // TÍNH TOÁN DINH DƯỠNG & PROGRESS BAR
        // ============================================================

        /// <summary>
        /// Tính tổng Đạm, Chất xơ, Chất béo từ tất cả món đã chọn trong _selectedMeals.
        /// </summary>
        private NutritionTargetModel SumSelectedNutrition()
        {
            return new NutritionTargetModel
            {
                Dam = _selectedMeals.Values.Sum(x => x.Dam),
                ChatXo = _selectedMeals.Values.Sum(x => x.ChatXo),
                ChatBeo = _selectedMeals.Values.Sum(x => x.ChatBeo)
            };
        }

        /// <summary>
        /// Tính phần trăm current/target. Trả về 0 nếu target <= 0 (tránh chia 0).
        /// </summary>
        private static double GetPercent(double current, double target)
        {
            if (target <= 0) return 0;
            return current * 100.0 / target;
        }

        /// <summary>
        /// Đặt ProgressBar về chế độ Continuous, min=0, max=100, value=0.
        /// </summary>
        private static void ConfigureProgressBar(ProgressBar pb)
        {
            pb.Minimum = 0;
            pb.Maximum = 100;
            pb.Value = 0;
            pb.Style = ProgressBarStyle.Continuous;
        }

        /// <summary>
        /// Cập nhật 1 thanh ProgressBar + Label: set giá trị %, đổi màu đỏ nếu vượt 100%.
        /// Dùng Win32 API PBM_SETSTATE để chuyển màu thanh (xanh → đỏ).
        /// </summary>
        private static void UpdateNutritionProgress(ProgressBar pb, Label lbl, string title,
            double current, double target, double percent)
        {
            int value = Math.Max(0, Math.Min(100, (int)Math.Round(percent)));
            pb.Value = value;

            bool overLimit = percent > 100.0;
            lbl.Text = string.Format(CultureInfo.CurrentCulture,
                "{0}: {1:0.#}% ({2:0.#}/{3:0.#}g)", title, percent, current, target);
            lbl.ForeColor = overLimit ? Color.FromArgb(190, 45, 45) : Color.FromArgb(40, 48, 56);

            if (pb.IsHandleCreated)
                SendMessage(pb.Handle, PBM_SETSTATE,
                    new IntPtr(overLimit ? PBST_ERROR : PBST_NORMAL), IntPtr.Zero);
        }

        /// <summary>
        /// Tạo chuỗi cảnh báo nếu chất nào vượt 100% tiêu chuẩn tuần.
        /// VD: "Cảnh báo: thừa đạm, thừa chất béo."
        /// Nếu không vượt → "Dinh dưỡng: chưa vượt chuẩn tuần."
        /// </summary>
        private static string BuildNutritionWarning(double dam, double xo, double beo)
        {
            List<string> warnings = new List<string>();
            if (dam > 100.0) warnings.Add("thừa đạm");
            if (xo > 100.0) warnings.Add("thừa chất xơ");
            if (beo > 100.0) warnings.Add("thừa chất béo");

            if (warnings.Count == 0) return "Dinh dưỡng: chưa vượt chuẩn tuần.";
            return "Cảnh báo: " + string.Join(", ", warnings) + ".";
        }

        // ============================================================
        // HÀM TIỆN ÍCH: NGÀY THÁNG, KEY, HIỂN THỊ
        // Tất cả đều là static vì không dùng biến instance.
        // ============================================================

        /// <summary>
        /// Tính ngày thứ 2 của tuần chứa 'value'.
        /// VD: 04/06/2026 (thứ 5) → 01/06/2026 (thứ 2).
        /// </summary>
        private static DateTime GetWeekStart(DateTime value)
        {
            int diff = ((int)value.DayOfWeek + 6) % 7;
            return value.Date.AddDays(-diff);
        }

        /// <summary>
        /// Sinh mã số duy nhất cho 1 tuần: yyyyMMdd từ ngày thứ 2.
        /// VD: 01/06/2026 → 20260601.
        /// </summary>
        private static int GetWeekKey(DateTime weekStart)
        {
            return weekStart.Year * 10000 + weekStart.Month * 100 + weekStart.Day;
        }

        /// <summary>
        /// Tạo key cho 1 slot: "yyyyMMdd-buoiAnId-category-index".
        /// Key này là khóa chính trong Dictionary _slots và _selectedMeals.
        /// </summary>
        private static string BuildKey(DateTime date, int buoiAnId, DishCategory category, int index)
        {
            return string.Format("{0:yyyyMMdd}-{1}-{2}-{3}", date, buoiAnId, category, index);
        }

        /// <summary>
        /// Tạo text cho tiêu đề cột ngày: "Thứ 2\n02/06".
        /// Dòng 1: tên thứ, dòng 2: ngày/tháng.
        /// </summary>
        private static string GetDayTitle(DateTime date)
        {
            string[] names = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "CN" };
            int index = ((int)date.DayOfWeek + 6) % 7;
            return string.Format("{0}\n{1:dd/MM}", names[index], date);
        }

        /// <summary>
        /// Từ khóa tìm buổi trong DB: Sáng→"sang", Trưa→"trua", Tối→"chieu".
        /// Dùng để dò tên buổi trong FindBuoiAn.
        /// </summary>
        private static string GetMealKeyword(MealKind meal)
        {
            if (meal == MealKind.Sang) return "sang";
            if (meal == MealKind.Trua) return "trua";
            return "chieu";
        }

        /// <summary>
        /// Tên hiển thị tiếng Việt của loại món.
        /// </summary>
        private static string GetCategoryTitle(DishCategory category)
        {
            if (category == DishCategory.Canh) return "Canh";
            if (category == DishCategory.Rau) return "Rau";
            if (category == DishCategory.TrangMieng) return "Tráng miệng";
            if (category == DishCategory.SuaHop) return "Sữa";
            return "Mặn";
        }

        /// <summary>
        /// Text placeholder khi slot chưa có món: "+ Mặn 1", "+ Canh 1"...
        /// </summary>
        private static string GetSlotPlaceholder(DishCategory category, int index)
        {
            return string.Format("+ {0} {1}", GetCategoryTitle(category), index + 1);
        }

        /// <summary>
        /// Màu nền mặc định cho từng loại món (khi slot chưa có món được chọn).
        /// Mặn=vàng nhạt, Canh=xanh nhạt, Rau=xanh lá, Tráng miệng=hồng, Sữa=trắng.
        /// </summary>
        private static Color GetCategoryColor(DishCategory category)
        {
            if (category == DishCategory.Canh) return Color.FromArgb(220, 239, 255);
            if (category == DishCategory.Rau) return Color.FromArgb(224, 245, 229);
            if (category == DishCategory.TrangMieng) return Color.FromArgb(255, 231, 238);
            if (category == DishCategory.SuaHop) return Color.White;
            return Color.FromArgb(255, 239, 214);
        }

        // ============================================================
        // HÀM TIỆN ÍCH: PHÂN LOẠI MÓN, CHUẨN HÓA VĂN BẢN
        // ============================================================

        /// <summary>
        /// Phân loại món dựa vào tên loại (text từ DB).
        /// Dò từ khóa: "sữa"/"milk"→SuaHop, "tráng miệng"/"trái cây"→TrangMieng,
        /// "canh"/"súp"→Canh, "rau"/"xào"/"luộc"→Rau, còn lại→Mặn.
        /// </summary>
        private static DishCategory ClassifyDishType(string value)
        {
            string normalized = NormalizeText(value);
            string compact = normalized.Replace(" ", string.Empty);

            if (compact.Contains("suahop") || normalized.Contains("sua") || normalized.Contains("milk"))
                return DishCategory.SuaHop;
            if (compact.Contains("trangmieng") || normalized.Contains("trang mieng")
                || compact.Contains("traicay") || normalized.Contains("trai cay")
                || compact.Contains("hoaqua") || normalized.Contains("hoa qua")
                || normalized.Contains("dua hau") || normalized.Contains("chuoi") || normalized.Contains("cam"))
                return DishCategory.TrangMieng;
            if (normalized.Contains("canh") || normalized.Contains("sup") || normalized.Contains("soup"))
                return DishCategory.Canh;
            if (normalized.Contains("rau") || normalized.Contains("xao") || normalized.Contains("luoc"))
                return DishCategory.Rau;
            return DishCategory.Man;
        }

        /// <summary>
        /// Chuẩn hóa văn bản tiếng Việt: bỏ dấu, lowercase, bỏ khoảng trắng thừa.
        /// Dùng NormalizationForm.FormD để tách dấu khỏi ký tự gốc, rồi lọc bỏ dấu.
        /// VD: "Canh Chua" → "canh chua"
        /// </summary>
        private static string NormalizeText(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return string.Empty;

            string formD = value.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();
            foreach (char c in formD)
            {
                UnicodeCategory cat = CharUnicodeInfo.GetUnicodeCategory(c);
                if (cat != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }
            return builder.ToString()
                .Replace("đ", "d")
                .Normalize(NormalizationForm.FormC);
        }

        // ============================================================
        // NÚT ĐIỀU HƯỚNG
        // ============================================================

        /// <summary>
        /// Nút Quay lại: ẩn form này, hiển thị menu chính frm_manhinh_nhanvien.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
            Form existingForm = Application.OpenForms["frm_manhinh_nhanvien"];
            if (existingForm != null)
            {
                existingForm.Show();
                existingForm.BringToFront();
            }
            else
            {
                frm_manhinh_nhanvien frm = new frm_manhinh_nhanvien();
                frm.Show();
                frm.FormClosed += (s, args) => Close();
            }
        }

        /// <summary>
        /// Nút Hướng dẫn: mở form hướng dẫn lập thực đơn (frmHuongDanLapThucDon).
        /// </summary>
        private void btnHD_Click(object sender, EventArgs e)
        {
            frmHuongDanLapThucDon frm = new frmHuongDanLapThucDon();
            frm.ShowDialog();
        }

        /// <summary>
        /// Sự kiện đóng form: hỏi xác nhận "Bạn có chắc chắn muốn thoát không?"
        /// trước khi cho phép đóng form.
        /// </summary>
        private void frmLapthucdon2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                    "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        // ============================================================
        // EVENT HANDLER RỖNG (do Designer tự sinh, cần giữ lại)
        // ============================================================

        private void lblStatus_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void prgChatBeo_Click(object sender, EventArgs e) { }
    }
}
