---
name: convert-inline-sql-to-stored-procedure
description: Systematically find and convert all inline SQL queries in C# code to stored procedures — used to enforce the project's SP-only rule across DAO, BUL, and GUI layers
source: auto-skill
extracted_at: '2026-06-18T00:31:27.635Z'
---

# Convert Inline SQL to Stored Procedure

Use this skill when the user asks to find and fix inline SQL violations, enforce the SP-only rule, or convert specific DAO methods from raw SQL to stored procedures.

**Core principle:** Replace inline SQL with SP calls that have **identical logic first**, then optimize the SP later if needed. Never change behavior during the conversion — it's a mechanical refactor.

## Phase 1: Discovery — find all violations

### Step 1: Search patterns

Use the Explore agent to search across all `.cs` files for these patterns:

| Pattern | What it catches |
|---------|----------------|
| `new SqlCommand(` with a string literal, not SP name | Direct inline SQL |
| `CommandType` NOT set (defaults to `Text`) | Implicit inline SQL |
| Raw query strings containing `SELECT`, `INSERT`, `UPDATE`, `DELETE`, `FROM`, `JOIN` | Inline queries in string variables |
| String variables passed to `DataProvider.Instance.ExecuteQuery()` or `ExecuteNonQuery()` or `ExecuteScalar()` | Inline SQL through DataProvider |
| `"SELECT...` or `@"SELECT...` inside GUI `.cs` files | SQL in forms (worst violation) |
| String interpolation in SQL strings like `$"SELECT ... FROM {table}"` | **SQL injection risk** — flag these as critical |

Also check `DataProvider.cs` itself — if its methods create `SqlCommand` with default `CommandType.Text`, they are the **root enabler** for many violations.

### Step 2: Categorize findings

Create a summary table grouped by file, showing method names and query types:

| File | # queries | Methods | Notes |
|------|-----------|---------|-------|
| DAO/MonAnDAO.cs | 10 | GetAllLoaiMon, GetByLoaiMon, GetOrCreateSua, ... | Most heavily affected |
| GUI/frmthongke_cb.cs | 1 | XuatExcelThang | SQL in form code — worst |

### Step 3: Distinguish "already using SP" from "violation"

Files that use `CommandType.StoredProcedure` are clean. Files that use `new SqlCommand("sp_...")` without setting `CommandType` are still violations — the command type defaults to `Text`.

### Step 4: Check which SPs already exist BEFORE creating new ones

Read existing SP files in `DB cua Hieu/script/` to see what's already available. This avoids creating duplicate SPs. For example:

- `sp_MonAn_Them` (already exists) → reuse for INSERT operations
- `sp_MonAn_LayMaMoi` (already exists) → reuse for MAX(id)+1
- `sp_MonAn_DanhSach` (already exists) → reuse for listing

Reusing existing SPs keeps the SP count low and avoids fragmentation.

## Phase 2: Create replacement stored procedures

### Mass conversion: use a SINGLE script file

When converting many inline SQL queries across multiple files (e.g., 20+ SPs for 6 DAO files), write ONE script file at `DB cua Hieu/script/sp_chuyen_doi_inline_sang_sp.sql` containing ALL new SPs. This is what the user wants — one file to run in SSMS, not 20 tiny files.

Use `IF OBJECT_ID(...) IS NOT NULL DROP PROC ...` before each `CREATE PROC` so the script is re-runnable. End each SP with `GO`.

### Before creating any SP: check what already exists

Read the existing SP scripts in `DB cua Hieu/script/` to avoid creating duplicates. If an SP already does what you need, reuse it instead of creating a new one.

Examples of reusable existing SPs:
- `sp_MonAn_Them(@monan_id, @monan_ten, @monan_loaimon, @ghi_chu, @dam, @chat_beo, @chat_xo)` — generic INSERT
- `sp_MonAn_LayMaMoi` — returns `ISNULL(MAX(monan_id),0)+1`

### For each inline SQL found:

1. Extract the exact SQL query from the C# code
2. Identify all `@paramName` parameters used
3. **Keep the logic identical** — copy the SQL verbatim into the SP body
4. Follow naming convention: `sp_<ĐốiTượng>_<HànhĐộng>`

### SP templates

**Basic SELECT / reader-based SP:**

```sql
IF OBJECT_ID('dbo.sp_TenProcedure') IS NOT NULL
    DROP PROC dbo.sp_TenProcedure
GO
CREATE PROC dbo.sp_TenProcedure
    @param1 DATE,
    @param2 INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ... FROM ... WHERE col = @param1 AND col2 = @param2 ORDER BY ...;
END
GO
```

**SP combining multiple operations (check + insert, returns 1 or 0):**

Use this pattern when the original C# does a COUNT check then INSERT. Combine them into one SP.

```sql
IF OBJECT_ID('dbo.sp_ChiTietThucDon_Them') IS NOT NULL
    DROP PROC dbo.sp_ChiTietThucDon_Them
GO
CREATE PROC dbo.sp_ChiTietThucDon_Them
    @ThucDonId INT, @Ngay DATE, @BuoiAnId INT, @MonAnId INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Kiểm tra trùng lặp
    IF EXISTS (SELECT 1 FROM Chi_tiet_thuc_don WHERE ...)
    BEGIN
        SELECT 0 AS KetQua;   -- Đã tồn tại, không thêm
        RETURN;
    END
    -- Thêm mới
    INSERT INTO Chi_tiet_thuc_don (...) VALUES (...);
    SELECT 1 AS KetQua;       -- Thành công
END
GO
```

Then in C#, call `ExecuteScalar()` and check `Convert.ToInt32(result) == 1` for success.

**SP returning @@ROWCOUNT for DELETE/UPDATE:**

```sql
CREATE PROC dbo.sp_ThucDon_CapNhatTrangThai
    @Id INT, @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Thuc_don SET trang_thai = @TrangThai WHERE thucdon_id = @Id;
    SELECT @@ROWCOUNT AS SoDongDaCapNhat;
END
GO
```

In C#: `int rows = Convert.ToInt32(cmd.ExecuteScalar()); return rows > 0;`

### Naming convention

Follow `sp_<ĐốiTượng>_<HànhĐộng>`:
- `sp_MonAn_LayLoaiMon` — get distinct loai_mon
- `sp_MonAn_TimSua` — find specific dish
- `sp_MonAn_TinhDinhDuongTuan` — calculation/aggregation
- `sp_ChiTietThucDon_LayTheoNgayBuoi` — query by foreign keys
- `sp_ChiTietThucDon_Them` — insert (may include dedup check)
- `sp_ChiTietThucDon_Xoa` — delete by key
- `sp_ThucDon_LayMaMoi` — get next ID (MAX+1)

## Phase 3: Update DAO code

### Key rule: use `GetConnection()` + `SqlCommand` directly, NOT `DataProvider.Instance.ExecuteQuery()`

The `DataProvider` helper methods (`ExecuteQuery`, `ExecuteNonQuery`, `ExecuteScalar`) create `SqlCommand` with default `CommandType.Text` — they are the enablers of inline SQL. Do NOT pass SP names through them. Instead, use the pattern already established in `D_MonAn.cs`:

### Pattern: GetConnection() → create SqlCommand → set CommandType.StoredProcedure

```csharp
using (SqlConnection conn = DataProvider.Instance.GetConnection())
{
    conn.Open();
    SqlCommand cmd = new SqlCommand("sp_MonAn_DanhSach", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    // ... execute
}
```

### Before (inline SQL — wrong)

```csharp
string query = @"SELECT ... FROM ... WHERE col = @param";
using (SqlConnection conn = DataProvider.Instance.GetConnection())
{
    conn.Open();
    SqlCommand cmd = new SqlCommand(query, conn);  // ← CommandType defaults to Text
    cmd.Parameters.AddWithValue("@param", value);
    using (SqlDataReader reader = cmd.ExecuteReader()) { ... }
}
```

### After (SP call — correct)

```csharp
using (SqlConnection conn = DataProvider.Instance.GetConnection())
{
    conn.Open();
    SqlCommand cmd = new SqlCommand("sp_TenProcedure", conn);
    cmd.CommandType = CommandType.StoredProcedure;     // ← MUST set this
    cmd.Parameters.AddWithValue("@Param", value);
    using (SqlDataReader reader = cmd.ExecuteReader()) { ... }
}
```

### When the original code used DataProvider helper methods

If the original code used `DataProvider.Instance.ExecuteQuery(stringQuery)`, restructure to use the `GetConnection()` pattern above. For methods that return `DataTable`, use `SqlDataAdapter`:

```csharp
// Before: DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT ...");
// After:
using (SqlConnection conn = DataProvider.Instance.GetConnection())
{
    conn.Open();
    SqlCommand cmd = new SqlCommand("sp_BuoiAn_DanhSach", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    DataTable dt = new DataTable();
    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        da.Fill(dt);
    // use dt...
}
```

### Reusing existing SPs in GetOrCreate patterns

When a method has "find first, create if not found" logic, check if existing SPs can be reused:

```csharp
// GetOrCreateSua() uses TWO existing SPs + one new SP:
// 1. sp_MonAn_TimSua (new) — SELECT TOP 1 to find existing
// 2. sp_MonAn_LayMaMoi (EXISTING) — get MAX(id)+1
// 3. sp_MonAn_Them (EXISTING) — INSERT the new row
```

This avoids creating SPs that duplicate existing functionality.

### SP returning a value via SELECT: use ExecuteScalar()

For SPs that return a single value via `SELECT`:

```csharp
SqlCommand cmd = new SqlCommand("sp_ChiTietThucDon_Them", conn);
cmd.CommandType = CommandType.StoredProcedure;
// ... add params ...
object result = cmd.ExecuteScalar();
bool success = Convert.ToInt32(result) == 1;
```

This works for SPs that do `SELECT 0 AS KetQua` or `SELECT @@ROWCOUNT`.

### Key points when updating DAO

- Always set `cmd.CommandType = CommandType.StoredProcedure`
- Match parameter names exactly between C# and the SP (case-insensitive in SQL Server, but be consistent)
- Use `.Date` for `DateTime` parameters to strip time component
- Use `using` blocks for `SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `SqlDataReader`
- If the SP uses `SET NOCOUNT ON`, you can use `ExecuteReader()` / `Fill()` safely
- Add Vietnamese comments for each method explaining what it does (for 2nd-year students)

## Phase 4: Build and verify

```bash
cmd /c ""C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "E:\lung tung\DuAnQuanLiTieuChuanQN\DuAn\DuAn.sln" /t:Build /p:Configuration=Debug /verbosity:minimal"
```

The `cmd /c` wrapper is required because paths contain spaces — direct invocation fails with "'C:\Program' is not recognized".

Check: 0 errors. Ignore pre-existing CS0105 warnings (duplicate `using` directives) and CS0168 (unused variables).

## Phase 5: Deliver SP scripts to user

After code changes are verified:

1. Tell the user the script file path (e.g., `DB cua Hieu/script/sp_chuyen_doi_inline_sang_sp.sql`)
2. Remind them to run it in SSMS on the correct database (`QuanLyTieuChuanQuanNhan1`)
3. Warn: "Nếu không chạy script SP trước, chương trình sẽ báo lỗi 'Could not find stored procedure'"

## Dangerous patterns to catch during conversion

### String interpolation in SQL (CRITICAL)

```csharp
// NGUY HIỂM — SQL injection risk
string query = $"SELECT ISNULL(MAX({column}), 0) + 1 FROM {table}";
```

Replace with a dedicated SP that hardcodes the table/column name:

```csharp
// AN TOÀN — gọi SP riêng cho từng bảng
SqlCommand cmd = new SqlCommand("sp_ThucDon_LayMaMoi", conn);
cmd.CommandType = CommandType.StoredProcedure;
```

Even if `column` and `table` are currently hardcoded, this pattern is dangerous because future changes could pass user input. Always replace with specific SPs.

### Post-retrieval client-side filtering

Some methods do a broad SELECT in SQL, then filter in C# (e.g., `IsSameDishGroup()` text normalization). Keep the C# filtering if it involves complex Vietnamese text normalization that's impractical in T-SQL. The SP handles basic filtering; C# handles domain-specific matching.

## What NOT to change during conversion

- Do NOT change the SQL logic (optimizations come later, in a separate step)
- Do NOT change the method signatures in BUL or GUI layers
- Do NOT add or remove columns from the result set
- Do NOT change parameter types or order
- Forms calling through BUL → DAO do NOT need modification
- The `AccountDAO.cs` file is intentionally excluded — user explicitly asked to skip it

## Identifying the full data flow (optional but helpful)

When converting a query, trace its callers to understand the full flow:

```
GUI form → BUL method → DAO method → SP
```

Use this to verify:
1. Which forms depend on this query
2. Whether the form does client-side post-filtering (and if so, whether that can move into the SP)
3. Whether parameters like `chedo_id` are passed to SQL or filtered in C# after retrieval

Finding client-side filtering (e.g., `dt.DefaultView.RowFilter = ...`) is a signal that the SP could be improved later to accept that parameter directly.
