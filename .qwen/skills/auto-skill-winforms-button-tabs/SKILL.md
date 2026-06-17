---
name: winforms-button-tabs
description: Add simple button-style tabs (like Chrome tabs) to a WinForms form — using Buttons in a Dock=Top Panel with color highlighting to switch between Thêm/Sửa/Xóa views sharing the same form layout
source: auto-skill
extracted_at: '2026-06-17T16:00:00.000Z'
---

# WinForms — Add Button Tabs to a Form

Use this when a single-purpose form (e.g., `frmThemMonAn`) needs to support multiple
related operations (Thêm / Sửa / Xóa) without duplicating the entire form layout.

## Design Principle: Share layout, change behavior

Instead of creating separate forms or 3 full duplicate panels, keep one set of form
controls and change their behavior based on the active tab. This avoids code duplication
and keeps the form maintainable.

```
┌─────────────────────────────────────────────┐
│  pnlTitle: Tên form (thay đổi theo tab)      │
├─────────────────────────────────────────────┤
│  [Thêm]  [Sửa]  [Xóa]    ← nút tab          │
│  ┌─[Tìm kiếm...]──────────┐ (ẩn/hiện)       │
├─────────────────────────────────────────────┤
│  Nội dung form (dùng chung)                  │
│  ...                                         │
├─────────────────────────────────────────────┤
│  [LƯU]   [HỦY]   [XÓA]  ← nút thay đổi      │
└─────────────────────────────────────────────┘
```

## Step-by-step

### 1. Add tab controls in Designer.cs

Add a `pnlTab` (Panel, Dock=Top) between the title bar and the form content. Inside
it, place Button-based tabs:

```csharp
// pnlTab — docked below pnlTitle
this.pnlTab.BackColor = Color.FromArgb(240, 242, 245);
this.pnlTab.Controls.Add(this.btnTabThem);
this.pnlTab.Controls.Add(this.btnTabSua);
this.pnlTab.Controls.Add(this.btnTabXoa);
this.pnlTab.Controls.Add(this.txtTimKiem);   // search box, visible only in Sửa/Xóa
this.pnlTab.Dock = DockStyle.Top;
this.pnlTab.Size = new Size(933, 42);

// btnTabThem — tab button (active = green, inactive = gray)
this.btnTabThem.FlatStyle = FlatStyle.Flat;
this.btnTabThem.BackColor = Color.FromArgb(46, 204, 133);  // green = active
this.btnTabThem.ForeColor = Color.White;
this.btnTabThem.Size = new Size(100, 32);

// btnTabSua, btnTabXoa — same pattern, default gray (100,100,100)
```

### 2. Add search TextBox for Sửa/Xóa tabs

```csharp
this.txtTimKiem.Visible = false;  // hidden by default, shown on Sửa/Xóa
this.txtTimKiem.Text = "🔍 Tìm món ăn...";
this.txtTimKiem.ForeColor = Color.Gray;  // placeholder style
```

Use `Enter`/`Leave` events to clear/restore placeholder text.

### 3. Add form-level fields

```csharp
private int tabHienTai = 0;     // 0 = Thêm, 1 = Sửa, 2 = Xóa
private int monanIdDangChon;    // ID of selected item (for Sửa/Xóa)
```

### 4. Implement ChuyenTab(int tab) — the core method

```csharp
private void ChuyenTab(int tab)
{
    tabHienTai = tab;

    // Highlight active tab
    Color active = Color.FromArgb(46, 204, 133);   // green
    Color inactive = Color.FromArgb(100, 100, 100); // gray
    btnTabThem.BackColor = tab == 0 ? active : inactive;
    btnTabSua.BackColor  = tab == 1 ? active : inactive;
    btnTabXoa.BackColor  = tab == 2 ? active : inactive;

    // Show/hide controls per tab
    txtTimKiem.Visible = (tab == 1 || tab == 2);
    btnXoaMon.Visible = (tab == 2);
    btnLuu.Visible = (tab != 2);

    // Change title text
    string[] titles = { "THÊM MỚI", "SỬA", "XÓA" };
    lblTitle.Text = titles[tab];

    // Reset form state for tab
    if (tab == 0)
    {
        // Reset all fields for new entry
        txtMaMon.ReadOnly = false;
        LoadNewId();
        ClearFields();
    }
    else
    {
        // Lock ID field for edit/delete
        txtMaMon.ReadOnly = true;
    }
}
```

### 5. Make LƯU button handle both INSERT and UPDATE

```csharp
private void btnLuu_Click(object sender, EventArgs e)
{
    if (!ValidateInput()) return;

    if (tabHienTai == 0)  // Thêm
        DAO.Insert(...);
    else                   // Sửa
        DAO.Update(...);

    // Insert detail rows (common for both)
    foreach (var row in detailRows)
        DAO.InsertDetail(...);
}
```

### 6. Implement search for Sửa/Xóa tabs

On `txtTimKiem.TextChanged`:
- Call `sp_TimKiem` with the input text
- If 1 result → auto-load it onto the form
- If multiple results → show in DataGridView for user to double-click

```csharp
private void txtTimKiem_TextChanged(object sender, EventArgs e)
{
    string keyword = txtTimKiem.Text.Trim();
    if (string.IsNullOrWhiteSpace(keyword)) return;

    DataTable results = BUL.Search(keyword);
    if (results.Rows.Count == 1)
        LoadItem(Convert.ToInt32(results.Rows[0]["id"]));
    else
        ShowSearchResults(results);  // temporary DataGridView
}
```

### 7. Important: Controls.Add order for Dock=Top panels

In WinForms, for `Dock=Top` controls, the control with the **highest index**
(added LAST) in `this.Controls` gets the topmost position.

Correct order for `pnlTitle` (top) → `pnlTab` (below) → `pnlThongTin` (below):
```csharp
this.Controls.Add(this.pnlNguyenLieu);   // Dock=Fill
this.Controls.Add(this.pnlThongTin);     // Dock=Top, bottommost Top
this.Controls.Add(this.pnlTab);          // Dock=Top, middle
this.Controls.Add(this.pnlTitle);        // Dock=Top, topmost ✓
```

## Common pitfalls

- **Forgot `new` statements**: Every new control needs a `new` in InitializeComponent(),
  not just field declarations. Designer will show "undeclared" errors otherwise.
- **Anchor=Bottom with Y near top**: If a control anchors to Bottom but its Y is near
  the top (e.g., y=6 in a 421px container), the large bottom margin (~385px) pushes it
  off-screen when the container shrinks. Place it close to where it should anchor.
- **Dock vs WindowState.Maximized**: MDI children fill the container with
  `Dock = DockStyle.Fill`, NOT `WindowState = FormWindowState.Maximized`. The latter
  merges the child's title bar into the MDI parent, hiding custom title bars.
