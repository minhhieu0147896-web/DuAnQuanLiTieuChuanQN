using DuAn.BUL;
using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmlapthucdon : Form
    {
        private const int CurrentUserId = 1;

        private readonly Dictionary<string, SlotButton> _slots = new Dictionary<string, SlotButton>();
        private readonly Dictionary<string, MonAnModel> _selectedMeals = new Dictionary<string, MonAnModel>();
        private List<BuoiAnModel> _buoiAns = new List<BuoiAnModel>();
        private SlotButton _activeSlot;
        private bool _isLoadingReferenceData;

        private DateTimePicker dtpWeek;
        private ComboBox cboCheDo;
        private Label lblWeekRange;
        private Label lblActiveSlot;
        private Label lblStatus;
        private TableLayoutPanel weekGrid;
        private Button btnXoaMon;
        private Button btnLuu;

        public frmlapthucdon()
        {
            InitializeComponent();
            BuildLayout();
            LoadReferenceData();
            LoadWeek();
        }

        private void BuildLayout()
        {
            Font = new Font("Segoe UI", 9F);
            BackColor = Color.FromArgb(245, 247, 250);
            Padding = new Padding(0);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 68,
                BackColor = Color.FromArgb(33, 48, 64),
                Padding = new Padding(24, 0, 24, 0)
            };

            Label title = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Left,
                Width = 420,
                Text = "LAP THUC DON TUAN",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Button btnBack = CreateHeaderButton("Quay lai");
            btnBack.Dock = DockStyle.Right;
            btnBack.Click += btnExit_Click;

            header.Controls.Add(btnBack);
            header.Controls.Add(title);

            Panel toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 96,
                BackColor = Color.White,
                Padding = new Padding(24, 14, 24, 14)
            };

            FlowLayoutPanel filters = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };

            dtpWeek = new DateTimePicker
            {
                Width = 170,
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today,
                Margin = new Padding(0, 24, 16, 0)
            };
            dtpWeek.ValueChanged += (s, e) => LoadWeek();

            cboCheDo = new ComboBox
            {
                Width = 190,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Margin = new Padding(0, 24, 16, 0)
            };
            cboCheDo.SelectedIndexChanged += (s, e) =>
            {
                if (!_isLoadingReferenceData)
                    LoadWeek();
            };

            lblWeekRange = new Label
            {
                Width = 300,
                Height = 48,
                Margin = new Padding(0, 18, 16, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 48, 64)
            };

            btnLuu = CreatePrimaryButton("Luu thuc don tuan");
            btnLuu.Margin = new Padding(0, 20, 0, 0);
            btnLuu.Click += btnluu_Click;

            filters.Controls.Add(CreateField("Ngay trong tuan", dtpWeek));
            filters.Controls.Add(CreateField("Che do", cboCheDo));
            filters.Controls.Add(lblWeekRange);
            filters.Controls.Add(btnLuu);
            toolbar.Controls.Add(filters);

            SplitContainer body = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 880,
                FixedPanel = FixedPanel.Panel2,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(16)
            };

            weekGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ColumnCount = 8,
                RowCount = 4,
                Padding = new Padding(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };
            weekGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 92));
            for (int i = 0; i < 7; i++)
                weekGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.285F));

            weekGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
            weekGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333F));
            weekGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333F));
            weekGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333F));

            Panel chooser = BuildChooserPanel();
            body.Panel1.Controls.Add(weekGrid);
            body.Panel2.Controls.Add(chooser);

            Controls.Add(body);
            Controls.Add(toolbar);
            Controls.Add(header);
        }

        private Panel BuildChooserPanel()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(18)
            };

            Label title = new Label
            {
                Dock = DockStyle.Top,
                Height = 34,
                Text = "CHON MON",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 48, 64)
            };

            lblActiveSlot = new Label
            {
                Dock = DockStyle.Top,
                Height = 72,
                Text = "Bam vao mot o mon trong bang de mo form chon mon tu database.",
                ForeColor = Color.FromArgb(88, 96, 105),
                Font = new Font("Segoe UI", 9.5F),
                Padding = new Padding(0, 10, 0, 0)
            };

            btnXoaMon = CreateSecondaryButton("Xoa mon khoi o");
            btnXoaMon.Dock = DockStyle.Top;
            btnXoaMon.Margin = new Padding(0, 10, 0, 0);
            btnXoaMon.Click += btnBo_Click;

            Button btnReload = CreateSecondaryButton("Tai lai tu database");
            btnReload.Dock = DockStyle.Top;
            btnReload.Margin = new Padding(0, 10, 0, 0);
            btnReload.Click += btnhienthi_Click;

            Button btnHelp = CreateSecondaryButton("Huong dan");
            btnHelp.Dock = DockStyle.Top;
            btnHelp.Margin = new Padding(0, 10, 0, 0);
            btnHelp.Click += btnHD_Click;

            lblStatus = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(88, 96, 105),
                Padding = new Padding(0, 18, 0, 0)
            };

            panel.Controls.Add(lblStatus);
            panel.Controls.Add(btnHelp);
            panel.Controls.Add(btnReload);
            panel.Controls.Add(btnXoaMon);
            panel.Controls.Add(lblActiveSlot);
            panel.Controls.Add(title);

            return panel;
        }

        private void LoadReferenceData()
        {
            _isLoadingReferenceData = true;
            try
            {
                _buoiAns = BuoiAnDAO.Instance.GetAll();
                if (_buoiAns.Count == 0)
                {
                    MessageBox.Show("Chua co du lieu buoi an.", "Thieu du lieu",
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
            if (cboCheDo == null || cboCheDo.SelectedValue == null || _buoiAns.Count == 0)
                return;

            _selectedMeals.Clear();
            DateTime start = GetWeekStart(dtpWeek.Value);
            DateTime end = start.AddDays(6);
            lblWeekRange.Text = string.Format("Tuan {0:dd/MM/yyyy} - {1:dd/MM/yyyy}", start, end);

            BuildWeekGrid(start);
            LoadExistingMeals(start);
            RefreshSlots();
            UpdateStatus();
        }

        private void BuildWeekGrid(DateTime weekStart)
        {
            weekGrid.SuspendLayout();
            weekGrid.Controls.Clear();
            _slots.Clear();

            weekGrid.Controls.Add(CreateGridHeader("Buoi"), 0, 0);
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
                                    LoaiMon = item.LoaiMon
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
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 218, 226);
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

            OpenChooseDishForm(_activeSlot);
        }

        private void OpenChooseDishForm(SlotButton slot)
        {
            string loaiMon = GetCategoryTitle(slot.Category);
            using (frmchonmon frm = new frmchonmon(loaiMon))
            {
                DialogResult result = frm.ShowDialog(this);
                if (result != DialogResult.OK || frm.MonDaChon == null)
                    return;

                DishCategory selectedCategory = ClassifyDishType(frm.MonDaChon.LoaiMon);
                if (selectedCategory != slot.Category)
                {
                    MessageBox.Show("Mon vua chon khong dung loai cua o hien tai.", "Sai loai mon",
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
                MessageBox.Show(validationError, "Thuc don chua du",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Luu toan bo thuc don trong tuan nay vao database?",
                "Xac nhan",
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
                {
                    ChiTietThucDonDAO.Instance.DeleteByThucDonNgayBuoi(thucDon.ThucDonId, date, buoi.BuoiAnId);
                }

                foreach (SlotButton slot in _slots.Values.Where(s => s.Date.Date == date.Date))
                {
                    if (_selectedMeals.TryGetValue(slot.Key, out MonAnModel dish))
                    {
                        ChiTietThucDonDAO.Instance.Insert(thucDon.ThucDonId, date, slot.BuoiAn.BuoiAnId, dish.MonAnId);
                    }
                }

                ThucDonDAO.Instance.UpdateTrangThai(thucDon.ThucDonId, "ChoDuyet");
            }

            MessageBox.Show("Da luu thuc don tuan. Trang thai: ChoDuyet.", "Thanh cong",
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
            lblStatus.Text = string.Format(
                "Da chon {0}/{1} o.\n\nRang buoc:\nSang: 1 mon man, 1 canh.\nTrua/toi: 4 mon man, 1 canh, 1 rau.",
                selected, total);
        }

        private string ValidateWeek()
        {
            foreach (SlotButton slot in _slots.Values.OrderBy(s => s.Date).ThenBy(s => s.BuoiAn.BuoiAnId))
            {
                if (!_selectedMeals.ContainsKey(slot.Key))
                {
                    return string.Format("Con thieu mon: {0:dd/MM/yyyy} - {1} - {2} {3}.",
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
                yield break;
            }

            for (int i = 0; i < 4; i++)
                yield return DishCategory.Man;
            yield return DishCategory.Canh;
            yield return DishCategory.Rau;
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
            string[] names = { "Thu 2", "Thu 3", "Thu 4", "Thu 5", "Thu 6", "Thu 7", "CN" };
            int index = ((int)date.DayOfWeek + 6) % 7;
            return string.Format("{0}\n{1:dd/MM}", names[index], date);
        }

        private static string GetMealTitle(MealKind meal)
        {
            if (meal == MealKind.Sang)
                return "Sang";
            if (meal == MealKind.Trua)
                return "Trua";
            return "Toi";
        }

        private static string GetMealKeyword(MealKind meal)
        {
            if (meal == MealKind.Sang)
                return "sang";
            if (meal == MealKind.Trua)
                return "trua";
            return "toi";
        }

        private static string GetCategoryTitle(DishCategory category)
        {
            if (category == DishCategory.Canh)
                return "Canh";
            if (category == DishCategory.Rau)
                return "Rau";
            return "Man";
        }

        private static string GetSlotPlaceholder(DishCategory category, int index)
        {
            return string.Format("+ {0} {1}", GetCategoryTitle(category), index + 1);
        }

        private static DishCategory ClassifyDishType(string value)
        {
            string normalized = NormalizeText(value);
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
            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        private static Color GetCategoryColor(DishCategory category)
        {
            if (category == DishCategory.Canh)
                return Color.FromArgb(220, 239, 255);
            if (category == DishCategory.Rau)
                return Color.FromArgb(224, 245, 229);
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

        private static Label CreateSmallLabel(string text)
        {
            return new Label
            {
                Dock = DockStyle.Top,
                Height = 24,
                Text = text,
                ForeColor = Color.FromArgb(88, 96, 105),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Padding = new Padding(0, 8, 0, 0)
            };
        }

        private static Control CreateField(string label, Control input)
        {
            Panel panel = new Panel
            {
                Width = input.Width,
                Height = 68,
                Margin = new Padding(0, 0, 16, 0)
            };

            Label lbl = new Label
            {
                Dock = DockStyle.Top,
                Height = 22,
                Text = label,
                ForeColor = Color.FromArgb(88, 96, 105),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
            };

            input.Dock = DockStyle.Bottom;
            input.Margin = new Padding(0);
            panel.Controls.Add(input);
            panel.Controls.Add(lbl);
            return panel;
        }

        private static Button CreatePrimaryButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                Width = 170,
                Height = 42,
                BackColor = Color.FromArgb(38, 132, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private static Button CreateSecondaryButton(string text)
        {
            Button button = new Button
            {
                Text = text,
                Height = 38,
                BackColor = Color.FromArgb(236, 241, 247),
                ForeColor = Color.FromArgb(33, 48, 64),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(212, 218, 226);
            return button;
        }

        private static Button CreateHeaderButton(string text)
        {
            Button button = CreateSecondaryButton(text);
            button.Width = 120;
            button.Height = 38;
            button.Margin = new Padding(0, 15, 0, 15);
            return button;
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

        private void frmlapthucdon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Ban co chac chan muon thoat khong?",
                    "Xac nhan thoat",
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
            Rau
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
    }
}
