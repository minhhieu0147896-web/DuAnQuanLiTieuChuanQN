# Tài liệu giải thích form frmLapthucdon2

> Dành cho sinh viên năm 2, chỉ biết C++ môn Kỹ thuật lập trình.
> Mục tiêu: hiểu bản chất từng dòng code, trình bày được logic với thầy.

---

## I. TỔNG QUAN — Form này làm gì?

`frmLapthucdon2` là form **lập thực đơn theo tuần** cho quân nhân. Nó hiển thị 1 bảng lịch 7 ngày × 3 buổi. Mỗi ô trong bảng chứa các món ăn (Mặn, Canh, Rau, Tráng miệng, Cơm, Sữa). Người dùng bấm vào ô trống → chọn món → lưu toàn bộ tuần xuống database.

```
┌────────┬────────┬────────┬────────┬────────┬────────┬────────┐
│  T2/15 │  T3/16 │  T4/17 │  T5/18 │  T6/19 │  T7/20 │  CN/21 │
├────────┼────────┼────────┼────────┼────────┼────────┼────────┤
│ Sáng   │ Sáng   │ Sáng   │ Sáng   │ Sáng   │ Sáng   │ Sáng   │
│[Thịt]  │[Cá]    │[Trứng] │[Thịt]  │[Cá]    │[Trứng] │[Thịt]  │
│[Canh]  │[Canh]  │[Canh]  │[Canh]  │[Canh]  │[Canh]  │[Canh]  │
│[Sữa]   │[Sữa]   │[Sữa]   │[Sữa]   │[Sữa]   │[Sữa]   │[Sữa]   │
│[Cơm]   │[Cơm]   │[Cơm]   │[Cơm]   │[Cơm]   │[Cơm]   │[Cơm]   │
├────────┼────────┼────────┼────────┼────────┼────────┼────────┤
│ Trưa   │ Trưa   │ Trưa   │ Trưa   │ Trưa   │ Trưa   │ Trưa   │
│  ...   │  ...   │  ...   │  ...   │  ...   │  ...   │  ...   │
├────────┼────────┼────────┼────────┼────────┼────────┼────────┤
│ Tối    │ Tối    │ Tối    │ Tối    │ Tối    │ Tối    │ Tối    │
│  ...   │  ...   │  ...   │  ...   │  ...   │  ...   │  ...   │
└────────┴────────┴────────┴────────┴────────┴────────┴────────┘
```

---

## II. KIẾN TRÚC — 3 tầng dữ liệu

Form dùng 3 cấu trúc dữ liệu chính, tất cả đều xoay quanh 1 thứ: **KEY**.

### 2.1 KEY là gì?

Key là chuỗi định danh duy nhất cho mỗi vị trí món ăn:

```
"20260615-1-Man-0"
   │      │  │   │
   │      │  │   └── Index (món Mặn thứ 0, thứ 1...)
   │      │  └────── Loại món (Man/Canh/Rau/Sua/Com)
   │      └───────── Mã buổi (1=Sáng, 2=Trưa, 3=Tối)
   └──────────────── Ngày (yyyyMMdd)
```

**C++ tương đương cách tạo key:**
```cpp
char key[100];
sprintf(key, "%04d%02d%02d-%d-%s-%d", 
    date.year, date.month, date.day, 
    buoiAnId, loaiMon, index);
// → "20260615-1-Man-0"
```

### 2.2 Ba từ điển (Dictionary = std::map trong C++)

```
┌─────────────────────────────────────────────────────────┐
│                                                         │
│   _slots                _selectedMeals       _weeklyBuffers
│   KEY → Button          KEY → MonAnModel     weekKey → {KEY → MonAnModel}
│                                                         │
│   "định vị nút"         "dữ liệu món"        "bộ nhớ cache"
│   trên màn hình         trong RAM            tránh query DB
│                                                         │
│   Cả 3 dùng chung KEY                                  │
└─────────────────────────────────────────────────────────┘
```

**C++ tương đương:**
```cpp
map<string, Button*>      slots;           // _slots
map<string, MonAnModel*>  selectedMeals;    // _selectedMeals
map<int, map<string, MonAnModel*>> weeklyBuffers; // _weeklyBuffers
map<int, string>          weeklyStatuses;   // _weeklyStatuses
```

### 2.3 Mảng tham chiếu nhanh — `_mealCells[3,7]`

21 UserControl được gom vào mảng 2 chiều:

```cpp
UserControl* mealCells[3][7] = {
    { &ucT2Sang, &ucT3Sang, &ucT4Sang, &ucT5Sang, &ucT6Sang, &ucT7Sang, &ucCNSang },
    { &ucT2Trua, &ucT3Trua, &ucT4Trua, &ucT5Trua, &ucT6Trua, &ucT7Trua, &ucCNTrua },
    { &ucT2Toi,  &ucT3Toi,  &ucT4Toi,  &ucT5Toi,  &ucT6Toi,  &ucT7Toi,  &ucCNToi  }
};
// mealCells[buoi][ngay] → đúng UserControl cần tìm, O(1)
```

---

## III. LUỒNG CHÍNH — Từ mở form đến lưu dữ liệu

### 3.1 Constructor (hàm khởi tạo)

```csharp
public frmLapthucdon2()
{
    InitializeComponent();        // Máy tự sinh: tạo tất cả nút/label/panel
    _toolTip = new ToolTip();     // Tooltip = bóng nói khi rê chuột
    this.DoubleBuffered = true;   // Chống giật màn hình
    InitGridReferenceArrays();    // Gom 21 UserControl vào mảng [3,7]
    Load += frmLapthucdon2_Load;  // Đăng ký: khi form mở → chạy Load
}
```

**C++:**
```cpp
frmLapthucdon2() {
    KhoiTaoGiaoDien();     // InitializeComponent
    toolTip = new ToolTip();
    doubleBuffered = true;
    TaoMangThamChieu();    // InitGridReferenceArrays
    // Load += ... : gán function pointer nhưng C++ không có sẵn event
}
```

### 3.2 Load — Chạy 1 lần khi mở form

```csharp
private void frmLapthucdon2_Load(object sender, EventArgs e)
{
    if (_isInitialized) return;  // KHÓA: chống chạy 2 lần
    _isInitialized = true;

    this.SuspendLayout();  // Tắt vẽ (tránh giật)

    WireEvents();           // 1. Gán sự kiện cho nút
    SetupFormAppearance();  // 2. Chỉnh font, màu
    LoadReferenceData();    // 3. Load danh sách buổi, chế độ
    LoadWeek();             // 4. Load dữ liệu tuần

    this.ResumeLayout(true); // Bật vẽ lại (vẽ 1 lần duy nhất)
}
```

**Giải thích từng bước:**

| Bước | Hàm | Làm gì |
|------|-----|--------|
| 1 | WireEvents | Nối dây: khi bấm nút Lưu → gọi btnluu_Click |
| 2 | SetupFormAppearance | Trang điểm: đổi font Segoe UI, màu nền form |
| 3 | LoadReferenceData | Load dữ liệu tĩnh: danh sách buổi (Sáng/Trưa/Tối), danh sách chế độ (Sĩ quan/Học viên...) |
| 4 | LoadWeek | Load dữ liệu thực đơn 7 ngày từ DB/cache |

### 3.3 LoadWeek — Trái tim của form (pipeline 9 bước)

```csharp
private void LoadWeek()
{
    // BƯỚC 0: Bảo vệ — form sẵn sàng chưa?
    if (!_isInitialized || cboCheDo.SelectedValue == null || _buoiAns.Count == 0)
        return;

    // BƯỚC 1: Tính Thứ 2 của tuần được chọn + mã tuần
    DateTime start = GetWeekStart(dtpWeek.Value);   // 15/06/2026
    int weekKey = GetWeekKey(start);                // 20260615

    // BƯỚC 2: Cache — đã load tuần này chưa?
    if (_weeklyBuffers.ContainsKey(weekKey))
    {
        // CÓ trong cache → lấy từ RAM, 0 query DB
        _selectedMeals.Clear();
        foreach (var kvp in _weeklyBuffers[weekKey])
            _selectedMeals[kvp.Key] = kvp.Value;
        _currentWeekStatus = _weeklyStatuses[weekKey];
    }
    else
    {
        // KHÔNG có → query DB
        _selectedMeals.Clear();
        LoadExistingMealsFromDatabase(start, out string status);
        _currentWeekStatus = status;
        // Lưu vào cache cho lần sau
        _weeklyBuffers[weekKey] = new Dictionary<string, MonAnModel>(_selectedMeals);
        _weeklyStatuses[weekKey] = _currentWeekStatus;
    }

    // BƯỚC 3: Hiển thị nhãn tuần
    lblWeekRange.Text = $"Tuần {start:dd/MM/yyyy} - {start.AddDays(6):dd/MM/yyyy}";

    // BƯỚC 4: Tính mục tiêu dinh dưỡng tuần
    _weeklyNutritionTarget = MonAnDAO.Instance.GetWeeklyNutritionTarget(GetSelectedCheDoId());

    // BƯỚC 5: Gán metadata + sự kiện click cho 21 ô
    PopulateWeekGrid(start);

    // BƯỚC 6: Tự động thêm Sữa (nếu chế độ Học viên)
    ApplyAutomaticMilkSlots();

    // BƯỚC 7: Tự động thêm Cơm trắng (tất cả buổi)
    ApplyAutomaticRiceSlots();

    // BƯỚC 8: Vẽ lại giao diện (text + màu từng nút)
    RefreshSlots();

    // BƯỚC 9: Cập nhật trạng thái + phân quyền (khóa nếu đã duyệt)
    UpdateStatus();
    ApplyEditPermissions();
}
```

**C++ tương đương (pseudo-code):**
```cpp
void LoadWeek() {
    // B0: Guard
    if (!daKhoiTao || !cboCheDo->HasSelection() || buoiAns.empty()) return;

    // B1: Tính ngày đầu tuần
    DateTime start = TinhThu2(dtpWeek->GetValue());
    int weekKey = start.nam * 10000 + start.thang * 100 + start.ngay;

    // B2: Cache
    if (weeklyBuffers.count(weekKey)) {
        selectedMeals = weeklyBuffers[weekKey];           // O(1) từ RAM
        currentWeekStatus = weeklyStatuses[weekKey];
    } else {
        LoadExistingMealsFromDB(start, currentWeekStatus); // O(n) từ DB
        weeklyBuffers[weekKey] = selectedMeals;            // Lưu cache
        weeklyStatuses[weekKey] = currentWeekStatus;
    }

    // B3-B9: Cập nhật giao diện
    HienThiNhanTuan(start);
    TinhMucTieuDinhDuong();
    GanMetadataCho21O(start);      // PopulateWeekGrid
    TuDongThemSua();               // ApplyAutomaticMilkSlots
    TuDongThemCom();               // ApplyAutomaticRiceSlots
    VeLaiGiaoDien();               // RefreshSlots
    CapNhatTrangThai();            // UpdateStatus
    PhanQuyenChinhSua();           // ApplyEditPermissions
}
```

---

## IV. CƠ CHẾ CỐT LÕI — Cách key kết nối giao diện và dữ liệu

### 4.1 Luồng: từ lúc bấm nút đến lúc hiển thị món mới

```
NGƯỜI DÙNG BẤM VÀO Ô "+ Mặn"
        │
        ▼
Slot_Click(sender, e)
  ├── sender = Button vừa bấm
  ├── meta = (SlotMetadata)button.Tag     ← ĐỌC KEY TỪ TAG
  ├── Kiểm tra: tuần đã duyệt chưa?
  ├── Kiểm tra: có phải Sữa/Cơm tự động?
  └── OpenChooseDishForm(meta)
        │
        ▼
OpenChooseDishForm(meta)
  ├── Mở popup frmchonmon (cho user chọn món)
  ├── User chọn "Thịt kho" → bấm OK
  ├── Kiểm tra: loại món có đúng không?
  ├── _selectedMeals[meta.Key] = monThitKho    ← GHI DỮ LIỆU
  ├── _weeklyBuffers[weekKey][meta.Key] = monThitKho  ← CẬP NHẬT CACHE
  └── RefreshSlots()                           ← VẼ LẠI
        │
        ▼
RefreshSlots()
  ├── foreach (Button slot in _slots.Values)
  │   ├── meta = slot.Tag
  │   ├── if (_selectedMeals[meta.Key] có món)
  │   │     slot.Text = món.TenMon;     // "Thịt kho"
  │   │     slot.BackColor = White;     // Nền trắng
  │   └── else
  │         slot.Text = "+ " + loai;    // "+ Mặn"
  │         slot.BackColor = Gray;      // Nền xám
  └── DONE: nút chuyển từ xám "+ Mặn" → trắng "Thịt kho"
```

### 4.2 Tại sao dùng 2 từ điển thay vì 1?

```
NẾU CHỈ CÓ _slots (Button → món):
  - Muốn lưu xuống DB → phải duyệt từng Button, đọc Tag, đọc Text
  - Rủi ro: Text có thể bị user sửa, Font thay đổi → sai dữ liệu

NẾU CHỈ CÓ _selectedMeals (Key → món):
  - Muốn tô màu nút → phải tìm nút từ Key → phải có _slots để tra

GIẢI PHÁP: 2 từ điển tách biệt
  - _slots: lo giao diện (vẽ, màu, sự kiện)
  - _selectedMeals: lo dữ liệu (lưu DB, tính dinh dưỡng)
  - Cả 2 dùng chung KEY → luôn đồng bộ
```

---

## V. CHI TIẾT CÁC HÀM QUAN TRỌNG

### 5.1 BuildKey — Nơi sinh ra key (dòng 1152)

```csharp
private static string BuildKey(DateTime date, int buoiAnId, DishCategory category, int index)
{
    return string.Format("{0:yyyyMMdd}-{1}-{2}-{3}", date, buoiAnId, category, index);
}
```

**C++:**
```cpp
string BuildKey(DateTime date, int buoiAnId, string category, int index) {
    char buf[100];
    sprintf(buf, "%04d%02d%02d-%d-%s-%d", 
        date.year, date.month, date.day, buoiAnId, category.c_str(), index);
    return buf;
}
```

### 5.2 PopulateWeekGrid — Gán Tag cho nút (dòng ~330-395)

```csharp
private void PopulateWeekGrid(DateTime weekStart)
{
    _slots.Clear();

    // Duyệt 3 buổi × 7 ngày = 21 UserControl
    for (int row = 0; row < 3; row++)
    {
        BuoiAnModel buoi = FindBuoiAn(row);
        for (int day = 0; day < 7; day++)
        {
            DateTime date = weekStart.AddDays(day);
            UserControl uc = _mealCells[row, day];  // ← Lấy đúng ô từ mảng

            // Mỗi ô có vài nút con (Mặn, Canh, Cơm, Sữa...)
            foreach (DishCategory category in GetRequiredCategories(buoi))
            {
                for (int idx = 0; idx < count; idx++)
                {
                    Button btn = GetSlotButtonFromUC(uc, category, idx);

                    // ← GẮN THẺ CĂN CƯỚC
                    string key = BuildKey(date, buoi.BuoiAnId, category, idx);
                    btn.Tag = new SlotMetadata {
                        Key = key, Date = date, BuoiAn = buoi, Category = category
                    };

                    btn.Click += Slot_Click;     // Gán sự kiện
                    _slots[key] = btn;           // Đăng ký vào từ điển
                }
            }
        }
    }
}
```

### 5.3 Slot_Click — Xử lý khi bấm vào ô món (dòng ~649)

```csharp
private void Slot_Click(object sender, EventArgs e)
{
    Button clickedBtn = sender as Button;           // sender = nút vừa bấm
    SlotMetadata meta = clickedBtn.Tag as SlotMetadata; // Đọc thẻ

    // KIỂM TRA: tuần đã duyệt → cấm sửa
    if (!WeeklyMenuStateManager.IsEditable(_currentWeekStatus))
    {
        MessageBox.Show("Thực đơn đã duyệt, không thể sửa.");
        return;
    }

    // KIỂM TRA: Sữa hộp tự động (Học viên) → cấm chọn món khác
    if (meta.Category == DishCategory.SuaHop && IsHocVienSelected())
        return;

    // KIỂM TRA: Cơm trắng tự động → cấm chọn món khác
    if (meta.Category == DishCategory.Com)
        return;

    // MỞ POPUP CHỌN MÓN
    OpenChooseDishForm(meta);
}
```

### 5.4 OpenChooseDishForm — Popup chọn món (dòng ~690)

```csharp
private void OpenChooseDishForm(SlotMetadata meta)
{
    // Tạo form con frmchonmon với bộ lọc loại món
    using (frmchonmon frm = new frmchonmon(loaiMon, ghiChu, ...))
    {
        if (frm.ShowDialog() == DialogResult.OK)   // User bấm OK
        {
            // Kiểm tra loại món đúng không
            if (ClassifyDishType(frm.MonDaChon.LoaiMon) != meta.Category)
            {
                MessageBox.Show("Sai loại món!");
                return;
            }

            // LƯU vào _selectedMeals
            _selectedMeals[meta.Key] = frm.MonDaChon;

            // Cập nhật cache
            _weeklyBuffers[weekKey][meta.Key] = frm.MonDaChon;

            // Vẽ lại nút
            RefreshSlots();
        }
    }
}
```

### 5.5 RefreshSlots — Vẽ lại toàn bộ nút (dòng ~990)

```csharp
private void RefreshSlots()
{
    foreach (Button slot in _slots.Values)  // Duyệt từng nút
    {
        SlotMetadata meta = slot.Tag as SlotMetadata;

        if (_selectedMeals.TryGetValue(meta.Key, out MonAnModel dish))
        {
            slot.Text = dish.TenMon;        // Có món → tên món
            slot.BackColor = Color.White;   // Nền trắng
        }
        else
        {
            slot.Text = "+ " + GetCategoryTitle(meta.Category); // "+ Mặn"
            slot.BackColor = Color.LightGray;                    // Nền xám
        }
    }
}
```

### 5.6 btnluu_Click — Lưu xuống database (dòng ~900-960)

```csharp
private void btnluu_Click(object sender, EventArgs e)
{
    // 1. Validate: kiểm tra còn ô trống không?
    string validationError = ValidateWeek();
    if (!string.IsNullOrEmpty(validationError))
    {
        MessageBox.Show(validationError);
        return;
    }

    // 2. Xác nhận
    if (MessageBox.Show("Lưu thực đơn?", "Xác nhận", YesNo) != Yes)
        return;

    // 3. Duyệt 7 ngày, ghi xuống DB
    for (int day = 0; day < 7; day++)
    {
        DateTime date = weekStart.AddDays(day);

        // 3a. Tìm hoặc tạo thực đơn
        ThucDonModel thucDon = ThucDonDAO.Instance.GetOrCreate(userId, cheDoId, date);

        // 3b. Xóa món cũ của ngày này
        ChiTietThucDonDAO.Instance.DeleteByThucDonNgayBuoi(...);

        // 3c. INSERT từng món từ _selectedMeals
        foreach (Button slot in _slots.Values)
        {
            SlotMetadata meta = slot.Tag as SlotMetadata;
            if (meta.Date == date && _selectedMeals.ContainsKey(meta.Key))
            {
                MonAnModel mon = _selectedMeals[meta.Key];
                ChiTietThucDonDAO.Instance.Insert(thucDon.ThucDonId, date,
                    meta.BuoiAn.BuoiAnId, mon.MonAnId);
            }
        }

        // 3d. Đổi trạng thái "ChoDuyet"
        ThucDonDAO.Instance.UpdateTrangThai(thucDon.ThucDonId, "ChoDuyet");
    }

    // 4. Xóa cache → load lại từ DB
    _weeklyBuffers.Remove(weekKey);
    LoadWeek();
}
```

---

## VI. CÁCH TRÌNH BÀY VỚI THẦY

### Mở đầu (30 giây)
"Form Lập thực đơn cho phép người dùng soạn thực đơn 7 ngày × 3 buổi cho quân nhân theo chế độ ăn. Mỗi buổi có các loại món: Mặn, Canh, Rau, Tráng miệng, Cơm, Sữa."

### Kiến trúc (1 phút)
"Form dùng 3 cấu trúc dữ liệu chính:
- **Mảng 2 chiều `_mealCells[3,7]`**: tham chiếu nhanh đến 21 UserControl, mỗi UserControl chứa các nút món ăn.
- **Dictionary `_slots`**: ánh xạ Key → Button, dùng để định vị và vẽ lại giao diện.
- **Dictionary `_selectedMeals`**: ánh xạ Key → Món ăn, dùng để lưu dữ liệu và ghi xuống database.
- **Dictionary `_weeklyBuffers`**: cache dữ liệu tuần trong RAM để tránh query DB nhiều lần."

### Cơ chế Key (1 phút)
"Mỗi vị trí món ăn có 1 Key duy nhất dạng `ngày-buổi-loạiMón-index`, ví dụ `20260615-1-Man-0`. Key này là cầu nối giữa giao diện (`_slots`) và dữ liệu (`_selectedMeals`). Khi user chọn món, ta gán `_selectedMeals[key] = món`. Khi vẽ lại, ta đọc `_selectedMeals[key]` để hiển thị tên món lên `_slots[key]`."

### Luồng chính (1 phút)
"Luồng hoạt động gồm 3 giai đoạn:
1. **Load**: form mở → LoadReferenceData (buổi, chế độ) → LoadWeek (pipeline 9 bước: cache check → query DB → gán metadata → tự động thêm Cơm/Sữa → vẽ giao diện).
2. **Tương tác**: user bấm ô → Slot_Click đọc Key từ Tag → mở popup chọn món → gán vào `_selectedMeals[key]` → RefreshSlots vẽ lại.
3. **Lưu**: user bấm Lưu → ValidateWeek kiểm tra → xóa món cũ → INSERT món mới từ `_selectedMeals` → đổi trạng thái."

### Điểm sáng tạo (30 giây)
"- Dùng Cache (`_weeklyBuffers`) để tránh query DB khi user xem đi xem lại cùng 1 tuần.
- Tự động thêm Cơm trắng (mọi buổi) và Sữa (chế độ Học viên) bằng code, user không cần chọn thủ công.
- Mảng 2 chiều `[3,7]` thay thế 21 dòng if-else, code ngắn gọn và không lặp."

---

## VII. TỪ VỰNG C# → C++

| C# | C++ | Giải thích |
|----|-----|-----------|
| `Dictionary<K,V>` | `map<K,V>` | Từ điển tra cứu key→value |
| `List<T>` | `vector<T>` | Mảng động |
| `foreach (var x in list)` | `for (auto& x : vec)` | Duyệt từng phần tử |
| `Button.Tag` | `void* userData` | Gắn dữ liệu tùy ý vào control |
| `event Click` | Function pointer | Gán hàm xử lý sự kiện |
| `MessageBox.Show()` | `cout <<` / `MessageBox()` | Hiển thị thông báo |
| `this.` | `this->` | Truy xuất thành viên class |
| `new Class()` | `new Class()` | Cấp phát đối tượng |
| `var x = value` | `auto x = value` | Tự động suy kiểu |
| `string.Format()` | `sprintf()` | Định dạng chuỗi |
