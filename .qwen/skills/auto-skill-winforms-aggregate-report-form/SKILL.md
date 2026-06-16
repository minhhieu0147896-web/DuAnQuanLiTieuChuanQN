---
name: winforms-aggregate-report-form
description: Create a WinForms calculation/report form that delegates all heavy aggregation to a single stored procedure and displays results in a dynamic DataGridView — used for food-usage, cost-summary, and similar multi-table rollup forms
source: auto-skill
extracted_at: '2026-06-16T03:25:16.281Z'
---

# WinForms Aggregate Report Form

Use this skill when the user asks for a form that calculates or reports aggregated data across multiple tables (e.g., "tính thực phẩm cần sử dụng", "báo cáo chi phí theo ngày", "tổng hợp định lượng"). The core principle: **one stored procedure does all the SQL work; the C# side is thin**.

## Architecture (3-tier: GUI → BUL → DAO → SP)

```
frmXxx.cs  →  B_Xxx.TinhToan(...)  →  D_Xxx.TinhToan(...)  →  EXEC sp_Xxx_TinhToan
```

- **DAO** calls the SP via `CommandType.StoredProcedure`, returns `DataTable`.
- **BUL** is a pass-through (same signature). Keeps the door open for future caching/validation.
- **Form** calls BUL, binds `DataTable` to DataGridView with dynamically created columns.

## Stored Procedure Pattern

Push ALL joins, filtering, aggregation, and business logic into one SP. The SP returns a flat result set ready for display — no post-processing in C#.

### Template

```sql
CREATE PROCEDURE [dbo].[sp_Xxx_TinhToan]
    @ngay      DATE,
    @filter_id INT = NULL,   -- NULL = "tất cả"
    @donvi_id  INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Step 1: intermediate results in table variables
    DECLARE @Intermediates TABLE (key_col INT, value_col DECIMAL(10,4), ...);

    INSERT INTO @Intermediates ...
    SELECT ... FROM SourceTable WHERE ... AND (@filter_id IS NULL OR col = @filter_id);

    -- Step 2: adjust/transform (e.g., subtract excluded records)
    UPDATE @Intermediates SET value_col = value_col - ISNULL(sub.value, 0)
    FROM @Intermediates i LEFT JOIN (...) sub ON ...;

    -- Step 3: final aggregation with joins
    SELECT
        dim.ten         AS TenHienThi,
        dim.don_vi      AS DonVi,
        SUM(ratio * base_qty * headcount)        AS TongSoLuong,
        SUM(ratio * base_qty * headcount * price) AS TongTien
    FROM DetailTable d
    JOIN DimensionTable dim ON d.fk = dim.pk
    JOIN @Intermediates i ON ...
    WHERE d.ngay = @ngay AND (@filter_id IS NULL OR d.filter_col = @filter_id)
      AND i.value_col > 0
    GROUP BY dim.pk, dim.ten, dim.don_vi
    ORDER BY dim.ten;
END
GO
```

### Key patterns in the SP
- **`@filter_id IS NULL OR col = @filter_id`** — the "all" option handled entirely in SQL.
- **Table variables** (`DECLARE @t TABLE`) for intermediate calculations like headcount.
- **Multiply ratios before summing**: `SUM(ty_le * dinhluong * so_nguoi)` — ratios are per-row, not post-aggregation.

## C# Code

### DAO (stored procedure call)

```csharp
internal class D_Xxx
{
    public static DataTable TinhToan(DateTime ngay, int? filterId, int donviId)
    {
        using (SqlConnection conn = DataProvider.Instance.GetConnection())
        {
            SqlCommand cmd = new SqlCommand("sp_Xxx_TinhToan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngay", ngay.Date);
            cmd.Parameters.AddWithValue("@filter_id", (object)filterId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@donvi_id", donviId);

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(dt);
            return dt;
        }
    }
}
```

### BUL (pass-through)

```csharp
internal class B_Xxx
{
    public static DataTable TinhToan(DateTime ngay, int? filterId, int donviId)
        => D_Xxx.TinhToan(ngay, filterId, donviId);
}
```

### Form — "All" option in ComboBox

Use a small internal class so `null` maps naturally to the "all" choice:

```csharp
internal class FilterComboItem
{
    public string HienThi { get; set; }   // DisplayMember
    public int? GiaTri { get; set; }       // ValueMember — nullable
}
```

Populate in constructor/load:

```csharp
cboFilter.Items.Clear();
cboFilter.Items.Add(new FilterComboItem { HienThi = "Tất cả", GiaTri = null });
cboFilter.Items.Add(new FilterComboItem { HienThi = "Sáng",  GiaTri = 1 });
cboFilter.Items.Add(new FilterComboItem { HienThi = "Trưa",  GiaTri = 2 });
cboFilter.Items.Add(new FilterComboItem { HienThi = "Chiều", GiaTri = 3 });
cboFilter.DisplayMember = "HienThi";
cboFilter.ValueMember = "GiaTri";
cboFilter.SelectedIndex = 0;
```

Read value in click handler:

```csharp
var item = cboFilter.SelectedItem as FilterComboItem;
int? filterId = item?.GiaTri; // null = Tất cả
```

### Form — Dynamic DataGridView

**Remove pre-defined columns from Designer.cs** (both instantiations and property setters), then build them in code-behind:

```csharp
private void HienThiKetQua(DataTable dt)
{
    dgvData.DataSource = null;
    dgvData.Columns.Clear();

    if (dt == null || dt.Rows.Count == 0)
    {
        // Show "no data" message, zero out summary labels
        return;
    }

    // STT column (manual numbering)
    var colSTT = new DataGridViewTextBoxColumn { HeaderText = "STT", Width = 50 };

    // Data-bound columns
    var colTen = new DataGridViewTextBoxColumn { HeaderText = "Tên", DataPropertyName = "TenHienThi" };
    var colSL  = new DataGridViewTextBoxColumn { HeaderText = "Số lượng", DataPropertyName = "TongSoLuong",
                                                 DefaultCellStyle = { Format = "N2" } };
    var colTien = new DataGridViewTextBoxColumn { HeaderText = "Tiền", DataPropertyName = "TongTien",
                                                  DefaultCellStyle = { Format = "N0", Alignment = MiddleRight } };

    dgvData.Columns.AddRange(new DataGridViewColumn[] { colSTT, colTen, colSL, colTien });
    dgvData.AutoGenerateColumns = false;
    dgvData.DataSource = dt;

    // Number rows
    for (int i = 0; i < dgvData.Rows.Count; i++)
        dgvData.Rows[i].Cells[0].Value = i + 1;

    // Update summary labels
    double tongTien = 0;
    foreach (DataRow row in dt.Rows)
        tongTien += Convert.ToDouble(row["TongTien"]);
    lblSoLoai.Text = dt.Rows.Count.ToString();
    lblTongChiPhi.Text = tongTien.ToString("N0") + " đ";
}
```

### Form — Clipboard export to Excel

```csharp
private void btnLuu_Click(object sender, EventArgs e)
{
    dgvData.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
    dgvData.SelectAll();
    DataObject data = dgvData.GetClipboardContent();
    if (data != null) Clipboard.SetDataObject(data);
    MessageBox.Show("Đã sao chép vào clipboard. Dán (Ctrl+V) vào Excel.");
}
```

## DataProvider note

Use `DataProvider.Instance.GetConnection()` for manual `SqlCommand` usage (the project's singleton connection provider). Pass `DBNull.Value` for nullable parameters — never `null`.

## Project conventions for this codebase

- SP names: `sp_<ĐốiTượng>_<HànhĐộng>` (e.g., `sp_TinhThucPham_CanSuDung`)
- DAO classes prefixed `D_`, BUL classes prefixed `B_`
- All classes `internal` unless shared across assemblies
- Always add new `.cs` files to `DuAn.csproj` `<Compile Include="...">` entries
- Forms use `Segoe UI` font, dark header `#2C3E50`, white background, `FormBorderStyle.None`
