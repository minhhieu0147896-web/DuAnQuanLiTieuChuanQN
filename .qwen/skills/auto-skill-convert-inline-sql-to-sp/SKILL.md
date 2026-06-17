---
name: convert-inline-sql-to-stored-procedure
description: Systematically find and convert all inline SQL queries in C# code to stored procedures — used to enforce the project's SP-only rule across DAO, BUL, and GUI layers
source: auto-skill
extracted_at: '2026-06-17T09:02:51.392Z'
---

# Convert Inline SQL to Stored Procedure

Use this skill when the user asks to find and fix inline SQL violations, enforce the SP-only rule, or convert specific DAO methods from raw SQL to stored procedures.

**Core principle:** Replace inline SQL with SP calls that have **identical logic first**, then optimize the SP later if needed. Never change behavior during the conversion — it's a mechanical refactor.

## Phase 1: Discovery — find all violations

### Step 1: Search patterns

Search all `.cs` files for these patterns:

| Pattern | What it catches |
|---------|----------------|
| `new SqlCommand(` with a string literal, not SP name | Direct inline SQL |
| `CommandType` NOT set (defaults to `Text`) | Implicit inline SQL |
| Raw query strings containing `SELECT`, `INSERT`, `UPDATE`, `DELETE`, `FROM`, `JOIN` | Inline queries in string variables |
| String variables passed to `DataProvider.Instance.ExecuteQuery()` or `ExecuteNonQuery()` or `ExecuteScalar()` | Inline SQL through DataProvider |
| `"SELECT...` or `@"SELECT...` inside GUI `.cs` files | SQL in forms (worst violation) |

Also check `DataProvider.cs` itself — if its methods create `SqlCommand` with default `CommandType.Text`, they are the **root enabler** for many violations.

### Step 2: Categorize findings

Create a table:

| File | Layer | # queries | Notes |
|------|-------|-----------|-------|
| DAO/DataProvider.cs | DAO | 3 methods | Root cause — all pass-through |
| DAO/D_LSBQS.cs | DAO | 2 | 30-50 line queries |
| GUI/frmthongke_cb.cs | **GUI** | 1 | Worst — SQL in form code |

### Step 3: Distinguish "already using SP" from "violation"

Files that use `CommandType.StoredProcedure` are clean. Files that use `new SqlCommand("sp_...")` without setting `CommandType` are still violations — the command type defaults to `Text`.

## Phase 2: Create replacement stored procedures

### For each inline SQL found:

1. Extract the exact SQL query from the C# code
2. Identify all `@paramName` parameters used
3. Create a new `.sql` file in `DB cua Hieu/script/` with the SP definition
4. **Keep the logic identical** — copy the SQL verbatim into the SP body
5. Follow naming convention: `sp_<ĐốiTượng>_<HànhĐộng>`

### SP template

```sql
CREATE PROC [dbo].[sp_TenProcedure]
    @param1  DATE,
    @param2  INT,
    @param3  INT = 0    -- 0 = "tất cả" / no filter
AS
BEGIN
    SET NOCOUNT ON;

    -- Copy the exact inline SQL here, replacing C# @params with SP @params
    SELECT ...
    FROM ...
    WHERE col BETWEEN @param1 AND @param2
      AND (@param3 = 0 OR other_col = @param3)
    ORDER BY ...;
END
GO
```

### Naming convention

- `sp_BaoCaoQuanSo` — for report/read operations
- `sp_TraCuuThucPham` — for lookup queries
- `sp_TinhToan...` — for calculation/aggregation
- Match existing SP names in the project: `sp_lichsubaoqs`, `sp_QuanSoAn_Count`, etc.

## Phase 3: Update DAO code

### Before (inline SQL)

```csharp
public static DataTable TraCuu(LSBQS ls)
{
    const string query = @"
SELECT ... FROM Quan_so_an qs
INNER JOIN Buoi_an ba ON ...
WHERE qs.ngay_thang_nam BETWEEN @tungay AND @denngay
  AND qs.donvi_id = @donvi_id ...";

    using (SqlConnection conn = DataProvider.Instance.GetConnection())
    using (SqlCommand cmd = new SqlCommand(query, conn))  // ← inline SQL
    {
        cmd.Parameters.AddWithValue("@tungay", ls.tungay.Date);
        ...
    }
}
```

### After (SP call)

```csharp
public static DataTable TraCuu(LSBQS ls)
{
    using (SqlConnection conn = DataProvider.Instance.GetConnection())
    using (SqlCommand cmd = new SqlCommand("sp_BaoCaoQuanSo", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;     // ← MUST set this
        cmd.Parameters.AddWithValue("@tungay", ls.tungay.Date);
        cmd.Parameters.AddWithValue("@denngay", ls.denngay.Date);
        cmd.Parameters.AddWithValue("@donvi_id", ls.donvi_id);
        cmd.Parameters.AddWithValue("@buoian_id", ls.buoian_id);

        DataTable dt = new DataTable();
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            da.Fill(dt);
        return dt;
    }
}
```

### Key points when updating DAO

- Always set `cmd.CommandType = CommandType.StoredProcedure`
- Match parameter names exactly between C# and the SP
- Use `.Date` for `DateTime` parameters to strip time component
- Use `using` blocks for `SqlConnection`, `SqlCommand`, `SqlDataAdapter`
- If the SP uses `SET NOCOUNT ON`, you can use `ExecuteReader()` / `Fill()` safely

## Phase 4: Build and verify

```bash
# Build with MSBuild (the project is .NET Framework 4.7.2, not .NET Core)
cmd /c ""C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "path\to\DuAn.csproj" /t:Build /p:Configuration=Debug /p:Platform=AnyCPU"
```

Check: 0 errors. Ignore pre-existing CS0105 warnings (duplicate `using` directives).

## Phase 5: Deliver SP scripts to user

After code changes are verified, remind the user to run the SP scripts:

> Bạn cần chạy các script SQL trong `DB cua Hieu/script/` vào DB trước khi chạy chương trình. Nếu không sẽ báo lỗi "Could not find stored procedure".

## What NOT to change during conversion

- Do NOT change the SQL logic (optimizations come later, in a separate step)
- Do NOT change the method signatures in BUL or GUI layers
- Do NOT add or remove columns from the result set
- Do NOT change parameter types or order
- Forms calling through BUL → DAO do NOT need modification

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
