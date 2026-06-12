---
name: winforms-mealgrid-add-category
description: Add a new auto-filled or user-selectable dish category (like Cơm trắng) to the weekly meal planning grid — touching enum, UCs, DAO, and form in coordinated steps. Buttons MUST be added in Designer.cs files, NOT programmatically.
source: auto-skill
extracted_at: '2026-06-11T00:43:44.574Z'
---

# WinForms: Add a New Dish Category to the Weekly Meal Grid

## When to apply
When you need to add a new type of dish slot to the `frmLapthucdon2` weekly meal grid — especially auto-filled dishes like "Cơm trắng" that appear automatically in every meal without user selection.

This skill covers the **full checklist** of files and methods that must be updated, so nothing is missed.

## Pattern: coordinated changes across 5 files

### Step 1: Add enum value — `MealEnums.cs`
Add the new category to `DishCategory`:
```csharp
public enum DishCategory
{
    Man,
    Canh,
    Rau,
    TrangMieng,
    SuaHop,
    Com             // ← new
}
```

### Step 2: Add button to both UserControls (in Designer.cs, NOT programmatically)

**Why Designer:** The user prefers drag-and-drop / Designer-editable forms. Buttons added in `.Designer.cs` appear in Visual Studio Designer, have correct positioning, and follow the project convention. Programmatic buttons (added in code-behind) are invisible in Designer and harder to maintain.

#### Calculate button position
Each existing button is **106×36 px**, with **Margin 4px** (Top+Bottom = 8px gap), starting at **Y=10** (6px padding + 4px margin).

Formula: `Y_new = Y_last_button + 36 + 8` (button height + margin top + margin bottom)

Example for UcMealCellSang (3 existing buttons at Y=10, 54, 98):
- New button Y = 98 + 44 = **142**
- New control height = old height + 44 (152 → **196**)

#### In `UcMealCellSang.Designer.cs`:

**a) Add to InitializeComponent** — in the `new` declarations:
```csharp
this.btnCom1 = new System.Windows.Forms.Button();  // after btnSua1
```

**b) Add to flpContainer.Controls:**
```csharp
this.flpContainer.Controls.Add(this.btnCom1);  // after btnSua1
```

**c) Update flpContainer size and UcMealCellSang size:**
```csharp
this.flpContainer.Size = new System.Drawing.Size(130, 196);  // was 152
// ...
this.Size = new System.Drawing.Size(130, 196);                // was 152
```

**d) Add button property block** (match exact pattern of existing buttons — same Font, FlatStyle, BorderColor, etc.):
```csharp
// btnCom1
this.btnCom1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(240)))));
this.btnCom1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
this.btnCom1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
this.btnCom1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
this.btnCom1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
this.btnCom1.Location = new System.Drawing.Point(10, 142);   // calculated Y
this.btnCom1.Margin = new System.Windows.Forms.Padding(4);
this.btnCom1.Name = "btnCom1";
this.btnCom1.Size = new System.Drawing.Size(106, 36);
this.btnCom1.TabIndex = 3;                                   // last index + 1
this.btnCom1.Text = "+ Cơm 1";
this.btnCom1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.btnCom1.UseVisualStyleBackColor = false;
```

**e) Declare field at bottom:**
```csharp
private System.Windows.Forms.Button btnCom1;
```

#### In `UcMealCellTruaToi.Designer.cs`:
Same pattern. For 7 existing buttons (last btnTrangMieng1 at Y=274):
- New button Y = 274 + 44 = **318**
- New control height = 312 + 44 = **356**
- TabIndex = **7**

#### In `UcMealCellSang.cs` and `UcMealCellTruaToi.cs` — code-behind:
**Remove** any programmatic button creation code (`KhoiTaoBtnCom()`, manual `new Button()`, `flpContainer.Controls.Add()`).
**Keep only** the logic methods that reference `btnCom1`:
```csharp
// Clean code-behind — no programmatic UI creation
public UcMealCellSang()
{
    InitializeComponent();  // only this line
}

public IEnumerable<Button> GetAllSlots()
{
    yield return btnMan1;
    yield return btnCanh1;
    yield return btnSua1;
    yield return btnCom1;   // Designer-created button
}
// ... GetSlotButton(), SetSlotVisible() similarly
```

**Remove unused `using System.Drawing;`** if it was only needed for programmatic button creation.

### Step 3: Add auto-create method in DAO — `MonAnDAO.cs`

Follow the existing `GetOrCreateSua()` pattern:
```csharp
public MonAnModel GetOrCreateCom()
{
    // 1. Try to find existing dish in DB
    // 2. If not found, INSERT with hardcoded nutrition values
    // 3. Return MonAnModel with matching values
}
```

**Nutrition values:** Hardcode reasonable per-serving values (e.g., Đạm 4g, Chất béo 0.5g, Chất xơ 0.5g for white rice). The INSERT must match the returned model values exactly.

Also update `IsSameDishGroup()` to recognize the new category by keyword (e.g., `"com"`, `"comtrang"`, `"cơm"`).

### Step 4: Update the form — `frmLapthucdon2.cs`

This is the biggest change. Update these methods **in order**:

| # | Method | What to add |
|---|--------|-------------|
| 1 | `GetRequiredCategories()` | `yield return DishCategory.Com;` in both Sáng and Trưa/Tối branches |
| 2 | `GetCategoryCount()` | Usually not needed — falls through to default 1 (unless new type needs >1 slot) |
| 3 | `GetCategoryTitle()` | `if (category == DishCategory.Com) return "Cơm";` |
| 4 | `GetCategoryColor()` | `if (category == DishCategory.Com) return Color.FromArgb(255, 252, 240);` |
| 5 | `ClassifyDishType()` | Add keyword detection BEFORE the default `Man` return |
| 6 | `Slot_Click()` | Add early return to block user interaction if auto-filled: `if (meta.Category == DishCategory.Com) return;` |
| 7 | `ApplyAutomaticRiceSlots()` | New method — iterate `_slots.Values`, find slots with matching category, assign dish via `_selectedMeals[meta.Key] = dish;` |
| 8 | `LoadWeek()` | Call the new auto-fill method after `ApplyAutomaticMilkSlots()` |
| 9 | `btnDienTuMau_Click()` | Same — call auto-fill after milk auto-fill |
| 10 | `UpdateStatus()` | Update the `breakfastRule` and status text to mention the new auto-filled category |

### Step 5: Auto-fill method template

```csharp
/// <summary>
/// Tự động gán món "X" vào tất cả slot loại X trong mọi buổi.
/// </summary>
private void ApplyAutomaticXSlots()
{
    MonAnModel dish = MonAnDAO.Instance.GetOrCreateX();
    foreach (Button slot in _slots.Values)
    {
        SlotMetadata meta = slot.Tag as SlotMetadata;
        if (meta != null && meta.Category == DishCategory.X)
            _selectedMeals[meta.Key] = dish;
    }
}
```

## Decision: auto-filled vs user-selectable

- **Auto-filled** (like Cơm, Sữa): User cannot click the slot to change it. Block in `Slot_Click()` with early return. Call auto-fill method in `LoadWeek()` and `btnDienTuMau_Click()`.
- **User-selectable** (like Mặn, Canh, Rau): User clicks the slot → `frmchonmon` opens → selects dish. The slot participates in `ValidateWeek()` (must be filled to save).

## Files NOT to touch
- `ViTriSlotMapper.cs` — template filling uses its own vi_tri mapping; auto-filled dishes don't go through templates
- `.resx` files — only change if Designer is involved and new resources are needed; for simple button additions, no `.resx` changes needed
- `WeeklyMenuFromTemplateFiller.cs` — auto-filled dishes are applied after template, not during

## Verification checklist
- [ ] Build succeeds (use Visual Studio MSBuild, not `dotnet build` for .NET Framework projects)
- [ ] New slot appears in every meal cell with correct placeholder text and color
- [ ] Auto-fill populates the slot on form load
- [ ] Clicking the auto-filled slot does nothing (no chooser form opens)
- [ ] Nutrition totals include the new dish values
- [ ] Save/Load round-trips correctly (dish persists in DB)
- [ ] Template fill still works (auto-fill runs after template)
