---
name: winforms-datagridview-search-filter
description: Add a real-time search TextBox above a DataGridView that filters rows as the user types, with placeholder text and visual cues
source: auto-skill
extracted_at: '2026-06-08T08:47:30.951Z'
---

# WinForms: Real-time Search/Filter TextBox for DataGridView

## When to apply
When a DataGridView contains a list of items (e.g., dishes, products) and the user needs to filter the list quickly by typing a keyword — matching against one text column (e.g., name). The filter must apply **as the user types** without requiring Enter or a button click.

## Pattern

### Step 1: Add TextBox in Designer.cs
Add a `TextBox` that docks Top inside the same parent panel as the DataGridView:

```csharp
// Declaration
private System.Windows.Forms.TextBox txtTimKiem;

// In InitializeComponent() — BEFORE the DataGridView is added to the panel
this.txtTimKiem = new System.Windows.Forms.TextBox();
this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.txtTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
this.txtTimKiem.Name = "txtTimKiem";
this.txtTimKiem.Size = new System.Drawing.Size(700, 23);
this.txtTimKiem.Text = "🔍 Tìm món...";   // Placeholder text

// Add to panel BEFORE DataGridView (Dock.Top takes priority)
this.splitContainer.Panel1.Controls.Add(this.dgvMonAn);   // Dock.Fill
this.splitContainer.Panel1.Controls.Add(this.txtTimKiem);  // Dock.Top — added AFTER Fill

// Field declaration
private System.Windows.Forms.TextBox txtTimKiem;
```

**Dock order rule:** `DockStyle.Fill` control must be added first, then `DockStyle.Top` controls. The TextBox will occupy the top ~23px, and the DataGridView fills the remaining space.

### Step 2: Store original list and wire events in .cs constructor

```csharp
// Field to hold the unfiltered list
private List<MonAnModel> _dsMonGoc;

// In constructor, after InitializeComponent():
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
```

### Step 3: Save original list after loading data

```csharp
// In Form_Load, after fetching data:
List<MonAnModel> dishes = DAO.GetData();
_dsMonGoc = dishes;  // Save unfiltered copy
dgvMonAn.DataSource = dishes;
```

### Step 4: Filter handler — foreach loop (no LINQ, easier for students)

```csharp
/// <summary>
/// Mỗi khi người dùng gõ vào ô tìm kiếm → lọc danh sách món ăn
/// </summary>
private void txtTimKiem_TextChanged(object sender, EventArgs e)
{
    if (_dsMonGoc == null) return;

    string tuKhoa = txtTimKiem.Text.Trim();

    // Nếu đang hiển thị placeholder hoặc rỗng → hiện toàn bộ
    if (tuKhoa == "🔍 Tìm món..." || string.IsNullOrEmpty(tuKhoa))
    {
        dgvMonAn.DataSource = _dsMonGoc;
        return;
    }

    // Lọc danh sách: tên chứa từ khóa (không phân biệt hoa thường)
    List<MonAnModel> dsLoc = new List<MonAnModel>();
    foreach (MonAnModel item in _dsMonGoc)
    {
        if (item.TenMon.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            dsLoc.Add(item);
        }
    }

    dgvMonAn.DataSource = dsLoc;
}
```

### Step 5: Optional — switch focus to grid after Enter key

```csharp
txtTimKiem.KeyDown += (s, ev) =>
{
    if (ev.KeyCode == Keys.Enter && dgvMonAn.Rows.Count > 0)
    {
        dgvMonAn.Focus();
        dgvMonAn.Rows[0].Selected = true;
        ev.SuppressKeyPress = true;
    }
};
```

## Key design decisions
- **Plain `foreach` instead of LINQ** — easier for 2nd-year students to understand
- **`StringComparison.OrdinalIgnoreCase`** — handles Vietnamese search correctly (no diacritic normalization needed for basic usage)
- **Placeholder via Enter/Leave events** — simpler than subclassing or using `SendMessage(EM_SETCUEBANNER)`, works reliably on all Windows versions
- **No Timer/debounce** — simple list filtering is fast enough even for 100+ items
- **Filter applied on every keystroke** — provides instant feedback; no need to press Enter

## Verification
- Type in the search box → list filters instantly
- Clear the text → full list restores
- Click away → placeholder reappears if empty
- Click back → placeholder clears, ready to type
