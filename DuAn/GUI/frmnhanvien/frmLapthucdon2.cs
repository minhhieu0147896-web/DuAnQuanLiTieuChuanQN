using DuAn.BUL;
using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmLapthucdon2 : Form
    {
        private const int CurrentUserId = 1;

        private readonly Dictionary<string, SlotButton> _slots = new Dictionary<string, SlotButton>();
        private readonly Dictionary<string, MonAnModel> _selectedMeals = new Dictionary<string, MonAnModel>();

        private List<BuoiAnModel> _buoiAns = new List<BuoiAnModel>();
        private NutritionTargetModel _weeklyNutritionTarget = new NutritionTargetModel();
        private SlotButton _activeSlot;
        private bool _isLoadingReferenceData;
        private bool _isInitialized;

        private const int PBM_SETSTATE = 0x0410;
        private const int PBST_NORMAL = 1;
        private const int PBST_ERROR = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public frmLapthucdon2()
        {
            InitializeComponent();
            Load += frmLapthucdon2_Load;
            FormClosing += frmLapthucdon2_FormClosing;
        }

        private void frmLapthucdon2_Load(object sender, EventArgs e)
        {
            if (_isInitialized)
                return;

            _isInitialized = true;
            WireEvents();
            NormalizeDesignedControls();
            LoadReferenceData();
            LoadWeek();
        }

        private void WireEvents()
        {
            dtpWeek.ValueChanged += (s, e) => LoadWeek();
            cboCheDo.SelectedIndexChanged += (s, e) =>
            {
                if (!_isLoadingReferenceData)
                    LoadWeek();
            };

            btnLuu.Click += btnluu_Click;
            btnXoaMon.Click += btnBo_Click;
            btnReload.Click += btnhienthi_Click;
            btnHelp.Click += btnHD_Click;
            btnBack.Click += btnExit_Click;
        }

        private void NormalizeDesignedControls()
        {
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 247, 250);

            lblTitle.AutoSize = false;
            lblTitle.Width = 420;
            lblTitle.Height = pnlHeader.Height;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Padding = new Padding(24, 0, 0, 0);

            dtpWeek.Width = 170;
            cboCheDo.Width = 190;
            lblWeekRange.Width = 300;
            lblWeekRange.Height = 48;
            lblWeekRange.TextAlign = ContentAlignment.MiddleLeft;

            btnLuu.Width = 170;
            btnLuu.Height = 42;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;

            weekGrid.Controls.Clear();
            weekGrid.ColumnStyles.Clear();
            weekGrid.RowStyles.Clear();
            weekGrid.ColumnCount = 8;
            weekGrid.RowCount = 4;
            weekGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            weekGrid.Padding = new Padding(10);

            weekGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92));
            for (int i = 0; i < 7; i++)
                weekGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.285F));

            weekGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            weekGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333F));
            weekGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333F));
            weekGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333F));

            btnBack.Text = "Quay lại";
            btnLuu.Text = "Lưu thực đơn tuần";
            btnXoaMon.Text = "Xóa món khỏi ô";
            btnReload.Text = "Tải lại từ cơ sở dữ liệu";
            btnHelp.Text = "Hướng dẫn";
            lblChooserTitle.Text = "CHỌN MÓN";
            lblActiveSlot.Text = "Bấm vào một ô món trong bảng để mở form chọn món từ cơ sở dữ liệu.";
            lblActiveSlot.AutoSize = false;
            lblActiveSlot.Height = 72;

            lblStatus.AutoSize = false;
            lblStatus.Dock = DockStyle.Fill;

            ConfigureProgressBar(prgDam);
            ConfigureProgressBar(prgChatXo);
            ConfigureProgressBar(prgChatBeo);
        }

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

        private void LoadWeek()
        {
            if (!_isInitialized || cboCheDo.SelectedValue == null || _buoiAns.Count == 0)
                return;

            _selectedMeals.Clear();
            DateTime start = GetWeekStart(dtpWeek.Value);
            DateTime end = start.AddDays(6);
            lblWeekRange.Text = string.Format("Tuần {0:dd/MM/yyyy} - {1:dd/MM/yyyy}", start, end);
            _weeklyNutritionTarget = MonAnDAO.Instance.GetWeeklyNutritionTarget(GetSelectedCheDoId());

            BuildWeekGrid(start);
            LoadExistingMeals(start);
            ApplyAutomaticMilkSlots();
            RefreshSlots();
            UpdateStatus();
        }

        private void BuildWeekGrid(DateTime weekStart)
        {
            weekGrid.SuspendLayout();
            weekGrid.Controls.Clear();
            _slots.Clear();

            weekGrid.Controls.Add(CreateGridHeader("Buổi"), 0, 0);

            for (int day = 0; day < 7; day++)
            {
                DateTime date = weekStart.AddDays(day);
                weekGrid.Controls.Add(CreateGridHeader(GetDayTitle(date)), day + 1, 0);
            }

            for (int row = 0; row < 3; row++)
            {
                MealKind meal = (MealKind)row;
                BuoiAnModel buoi = FindBuoiAn(meal);
                weekGrid.Controls.Add(CreateMealHeader(GetMealTitle(meal)), 0, row + 1);

                for (int day = 0; day < 7; day++)
                {
                    DateTime date = weekStart.AddDays(day);
                    FlowLayoutPanel cell = CreateMealCell();

                    foreach (DishCategory category in GetRequiredCategories(meal))
                    {
                        SlotButton slot = CreateSlot(date, buoi, meal, category, CountCategoryBefore(cell, category));
                        cell.Controls.Add(slot);
                        _slots[slot.Key] = slot;
                    }

                    weekGrid.Controls.Add(cell, day + 1, row + 1);
                }
            }

            weekGrid.ResumeLayout();
        }

        private void LoadExistingMeals(DateTime weekStart)
        {
            int cheDoId = GetSelectedCheDoId();

            for (int day = 0; day < 7; day++)
            {
                DateTime date = weekStart.AddDays(day);
                ThucDonModel thucDon = ThucDonDAO.Instance.GetOrCreate(CurrentUserId, cheDoId, date);
                List<ChiTietThucDonModel> details = ChiTietThucDonDAO.Instance.GetByThucDonNgay(thucDon.ThucDonId, date);

                foreach (IGrouping<int, ChiTietThucDonModel> mealGroup in details.GroupBy(x => x.BuoiAnId))
                {
                    foreach (IGrouping<DishCategory, ChiTietThucDonModel> categoryGroup in mealGroup.GroupBy(x => ClassifyDishType(x.LoaiMon)))
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

        private SlotButton CreateSlot(DateTime date, BuoiAnModel buoi, MealKind meal, DishCategory category, int index)
        {
            SlotButton button = new SlotButton
            {
                Date = date,
                BuoiAn = buoi,
                Meal = meal,
                Category = category,
                CategoryIndex = index,
                Key = BuildKey(date, buoi.BuoiAnId, category, index),
                Width = 116,
                Height = 36,
                Margin = new Padding(4),
                FlatStyle = FlatStyle.Flat,
                BackColor = GetCategoryColor(category),
                ForeColor = Color.FromArgb(30, 35, 40),
                Font = new Font("Segoe UI", 8.5F),
                TextAlign = ContentAlignment.MiddleCenter
            };

            button.FlatAppearance.BorderColor = category == DishCategory.SuaHop
                ? Color.FromArgb(145, 155, 166)
                : Color.FromArgb(212, 218, 226);
            button.Click += Slot_Click;
            return button;
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            _activeSlot = sender as SlotButton;
            if (_activeSlot == null)
                return;

            foreach (SlotButton slot in _slots.Values)
                slot.FlatAppearance.BorderSize = 1;

            _activeSlot.FlatAppearance.BorderSize = 3;
            lblActiveSlot.Text = string.Format("{0:dd/MM} - {1}\n{2} {3}",
                _activeSlot.Date,
                _activeSlot.BuoiAn.TenBuoi,
                GetCategoryTitle(_activeSlot.Category),
                _activeSlot.CategoryIndex + 1);

            if (_activeSlot.Category == DishCategory.SuaHop && IsHocVienSelected())
                return;

            OpenChooseDishForm(_activeSlot);
        }

        private void OpenChooseDishForm(SlotButton slot)
        {
            string loaiMon = GetCategoryTitle(slot.Category);
            string ghiChu = slot.Meal == MealKind.Sang && slot.Category == DishCategory.Man ? "SANG" : null;
            using (frmchonmon frm = new frmchonmon(
                loaiMon,
                ghiChu,
                _selectedMeals,
                slot.Date,
                slot.BuoiAn.BuoiAnId,
                slot.Key))
            {
                DialogResult result = frm.ShowDialog(this);
                if (result != DialogResult.OK || frm.MonDaChon == null)
                    return;

                DishCategory selectedCategory = ClassifyDishType(frm.MonDaChon.LoaiMon);
                if (selectedCategory != slot.Category)
                {
                    MessageBox.Show("Món vừa chọn không đúng loại của ô hiện tại.", "Sai loại món",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _selectedMeals[slot.Key] = frm.MonDaChon;
                RefreshSlots();
                UpdateStatus();
            }
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            if (_activeSlot == null)
                return;

            _selectedMeals.Remove(_activeSlot.Key);
            RefreshSlots();
            UpdateStatus();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            LoadWeek();
        }

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
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            int cheDoId = GetSelectedCheDoId();
            DateTime start = GetWeekStart(dtpWeek.Value);

            for (int day = 0; day < 7; day++)
            {
                DateTime date = start.AddDays(day);
                ThucDonModel thucDon = ThucDonDAO.Instance.GetOrCreate(CurrentUserId, cheDoId, date);

                foreach (BuoiAnModel buoi in _buoiAns)
                    ChiTietThucDonDAO.Instance.DeleteByThucDonNgayBuoi(thucDon.ThucDonId, date, buoi.BuoiAnId);

                foreach (SlotButton slot in _slots.Values.Where(s => s.Date.Date == date.Date))
                {
                    if (_selectedMeals.TryGetValue(slot.Key, out MonAnModel dish))
                        ChiTietThucDonDAO.Instance.Insert(thucDon.ThucDonId, date, slot.BuoiAn.BuoiAnId, dish.MonAnId);
                }

                ThucDonDAO.Instance.UpdateTrangThai(thucDon.ThucDonId, "ChoDuyet");
            }

            MessageBox.Show("Đã lưu thực đơn tuần. Trạng thái: Chờ duyệt.", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadWeek();
        }

        private void RefreshSlots()
        {
            foreach (SlotButton slot in _slots.Values)
            {
                if (_selectedMeals.TryGetValue(slot.Key, out MonAnModel dish))
                {
                    slot.Text = dish.TenMon;
                    slot.BackColor = Color.White;
                }
                else
                {
                    slot.Text = GetSlotPlaceholder(slot.Category, slot.CategoryIndex);
                    slot.BackColor = GetCategoryColor(slot.Category);
                }
            }
        }

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

            lblStatus.Text = string.Format(
                "Đã chọn {0}/{1} ô.\n\nRàng buộc:\n{2}\nTrưa/tối: 4 món mặn, 1 canh, 1 rau, 1 tráng miệng.\n\n{3}",
                selected, total, breakfastRule, nutritionWarning);
        }

        private NutritionTargetModel SumSelectedNutrition()
        {
            return new NutritionTargetModel
            {
                Dam = _selectedMeals.Values.Sum(x => x.Dam),
                ChatXo = _selectedMeals.Values.Sum(x => x.ChatXo),
                ChatBeo = _selectedMeals.Values.Sum(x => x.ChatBeo)
            };
        }

        private static double GetPercent(double current, double target)
        {
            if (target <= 0)
                return 0;

            return current * 100.0 / target;
        }

        private static void ConfigureProgressBar(ProgressBar progressBar)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Continuous;
        }

        private static void UpdateNutritionProgress(ProgressBar progressBar, Label label, string title, double current, double target, double percent)
        {
            int value = Math.Max(0, Math.Min(100, (int)Math.Round(percent)));
            progressBar.Value = value;

            bool overLimit = percent > 100.0;
            label.Text = string.Format(CultureInfo.CurrentCulture, "{0}: {1:0.#}% ({2:0.#}/{3:0.#}g)", title, percent, current, target);
            label.ForeColor = overLimit ? Color.FromArgb(190, 45, 45) : Color.FromArgb(40, 48, 56);

            if (progressBar.IsHandleCreated)
                SendMessage(progressBar.Handle, PBM_SETSTATE, new IntPtr(overLimit ? PBST_ERROR : PBST_NORMAL), IntPtr.Zero);
        }

        private static string BuildNutritionWarning(double damPercent, double chatXoPercent, double chatBeoPercent)
        {
            List<string> warnings = new List<string>();

            if (damPercent > 100.0)
                warnings.Add("thừa đạm");
            if (chatXoPercent > 100.0)
                warnings.Add("thừa chất xơ");
            if (chatBeoPercent > 100.0)
                warnings.Add("thừa chất béo");

            if (warnings.Count == 0)
                return "Dinh dưỡng: chưa vượt chuẩn tuần.";

            return "Cảnh báo: " + string.Join(", ", warnings) + ".";
        }

        private string ValidateWeek()
        {
            foreach (SlotButton slot in _slots.Values.OrderBy(s => s.Date).ThenBy(s => s.BuoiAn.BuoiAnId))
            {
                if (!_selectedMeals.ContainsKey(slot.Key))
                {
                    return string.Format("Còn thiếu món: {0:dd/MM/yyyy} - {1} - {2} {3}.",
                        slot.Date,
                        slot.BuoiAn.TenBuoi,
                        GetCategoryTitle(slot.Category),
                        slot.CategoryIndex + 1);
                }
            }

            return null;
        }

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

            for (int i = 0; i < 4; i++)
                yield return DishCategory.Man;

            yield return DishCategory.Canh;
            yield return DishCategory.Rau;
            yield return DishCategory.TrangMieng;
        }

        private int CountCategoryBefore(FlowLayoutPanel cell, DishCategory category)
        {
            int count = 0;
            foreach (Control control in cell.Controls)
            {
                SlotButton slot = control as SlotButton;
                if (slot != null && slot.Category == category)
                    count++;
            }
            return count;
        }

        private BuoiAnModel FindBuoiAn(MealKind meal)
        {
            string keyword = GetMealKeyword(meal);
            BuoiAnModel found = _buoiAns.FirstOrDefault(x => NormalizeText(x.TenBuoi).Contains(keyword));
            if (found != null)
                return found;

            int index = meal == MealKind.Sang ? 0 : meal == MealKind.Trua ? 1 : 2;
            return _buoiAns[Math.Min(index, _buoiAns.Count - 1)];
        }

        private int GetSelectedCheDoId()
        {
            if (cboCheDo.SelectedValue is int value)
                return value;

            if (cboCheDo.SelectedValue == null)
                return 1;

            return Convert.ToInt32(cboCheDo.SelectedValue);
        }

        private bool IsHocVienSelected()
        {
            if (GetSelectedCheDoId() == 1)
                return true;

            DataRowView row = cboCheDo.SelectedItem as DataRowView;
            if (row != null && row.Row.Table.Columns.Contains("chedo_ten"))
                return NormalizeText(row["chedo_ten"].ToString()).Contains("hoc vien");

            return NormalizeText(cboCheDo.Text).Contains("hoc vien");
        }

        private void ApplyAutomaticMilkSlots()
        {
            if (!IsHocVienSelected())
                return;

            MonAnModel milk = MonAnDAO.Instance.GetOrCreateSua();
            foreach (SlotButton slot in _slots.Values.Where(s => s.Category == DishCategory.SuaHop))
                _selectedMeals[slot.Key] = milk;
        }

        private static DateTime GetWeekStart(DateTime value)
        {
            int diff = ((int)value.DayOfWeek + 6) % 7;
            return value.Date.AddDays(-diff);
        }

        private static string BuildKey(DateTime date, int buoiAnId, DishCategory category, int index)
        {
            return string.Format("{0:yyyyMMdd}-{1}-{2}-{3}", date, buoiAnId, category, index);
        }

        private static string GetDayTitle(DateTime date)
        {
            string[] names = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "CN" };
            int index = ((int)date.DayOfWeek + 6) % 7;
            return string.Format("{0}\n{1:dd/MM}", names[index], date);
        }

        private static string GetMealTitle(MealKind meal)
        {
            if (meal == MealKind.Sang)
                return "Sáng";
            if (meal == MealKind.Trua)
                return "Trưa";
            return "Tối";
        }

        private static string GetMealKeyword(MealKind meal)
        {
            if (meal == MealKind.Sang)
                return "sang";
            if (meal == MealKind.Trua)
                return "trua";
            return "chieu";
        }

        private static string GetCategoryTitle(DishCategory category)
        {
            if (category == DishCategory.Canh)
                return "Canh";
            if (category == DishCategory.Rau)
                return "Rau";
            if (category == DishCategory.TrangMieng)
                return "Tráng miệng";
            if (category == DishCategory.SuaHop)
                return "Sữa";
            return "Mặn";
        }

        private static string GetSlotPlaceholder(DishCategory category, int index)
        {
            return string.Format("+ {0} {1}", GetCategoryTitle(category), index + 1);
        }

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

        private static string NormalizeText(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            string formD = value.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();
            foreach (char c in formD)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }

            return builder.ToString()
                .Replace("đ", "d")
                .Normalize(NormalizationForm.FormC);
        }

        private static Color GetCategoryColor(DishCategory category)
        {
            if (category == DishCategory.Canh)
                return Color.FromArgb(220, 239, 255);
            if (category == DishCategory.Rau)
                return Color.FromArgb(224, 245, 229);
            if (category == DishCategory.TrangMieng)
                return Color.FromArgb(255, 231, 238);
            if (category == DishCategory.SuaHop)
                return Color.White;
            return Color.FromArgb(255, 239, 214);
        }

        private static Label CreateGridHeader(string text)
        {
            return new Label
            {
                Dock = DockStyle.Fill,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 48, 64),
                BackColor = Color.FromArgb(236, 241, 247)
            };
        }

        private static Label CreateMealHeader(string text)
        {
            return new Label
            {
                Dock = DockStyle.Fill,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(52, 73, 94)
            };
        }

        private static FlowLayoutPanel CreateMealCell()
        {
            return new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(6),
                AutoScroll = true,
                WrapContents = true
            };
        }

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

        private void btnHD_Click(object sender, EventArgs e)
        {
            frmHuongDanLapThucDon frm = new frmHuongDanLapThucDon();
            frm.ShowDialog();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
        }

        private void frmLapthucdon2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private enum DishCategory
        {
            Man,
            Canh,
            Rau,
            TrangMieng,
            SuaHop
        }

        private enum MealKind
        {
            Sang = 0,
            Trua = 1,
            Toi = 2
        }

        private class SlotButton : Button
        {
            public string Key { get; set; }
            public DateTime Date { get; set; }
            public BuoiAnModel BuoiAn { get; set; }
            public MealKind Meal { get; set; }
            public DishCategory Category { get; set; }
            public int CategoryIndex { get; set; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void prgChatBeo_Click(object sender, EventArgs e)
        {

        }
    }
}
