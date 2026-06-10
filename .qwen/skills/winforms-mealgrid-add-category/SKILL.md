---
name: winforms-mealgrid-add-category
description: Add a new auto-filled or user-selectable dish category (like Cơm trắng) to the weekly meal planning grid — touching enum, UCs, DAO, and form in coordinated steps
source: auto-skill
extracted_at: '2026-06-10T08:23:17.076Z'
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

### Step 2: Add button to both UserControls (programmatically, NOT in Designer)

**Why programmatic:** Modifying `.Designer.cs` files is fragile and can break the Visual Studio Designer. Adding the button in code-behind keeps the Designer safe while the button works at runtime.

#### In `UcMealCellSang.cs`:
```csharp
// Add using System.Drawing; at top

private Button btnCom1;  // field

// In constructor, after InitializeComponent():
KhoiTaoBtnCom();

private void KhoiTaoBtnCom()
{
    btnCom1 = new Button
    {
        Name = "btnCom1",
        Text = "+ Cơm 1",
        Size = new Size(106, 36),
        BackColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        TextAlign = ContentAlignment.MiddleCenter,
        Font = new Font("Segoe UI", 9F),
        Margin = new Padding(4)
    };
    btnCom1.FlatAppearance.BorderSize = 1;
    flpContainer.Controls.Add(btnCom1);
}
```

Update `GetAllSlots()`, `GetSlotButton()`, `SetSlotVisible()`:
```csharp
public IEnumerable<Button> GetAllSlots()
{
    yield return btnMan1;
    yield return btnCanh1;
    yield return btnSua1;
    yield return btnCom1;   // ← new
}

public Button GetSlotButton(DishCategory category, int index)
{
    // ... existing cases ...
    if (category == DishCategory.Com) return btnCom1;   // ← new
    return null;
}
```

#### In `UcMealCellTruaToi.cs`:
Same pattern — copy the `KhoiTaoBtnCom()` method, add `btnCom1` field, update `GetAllSlots()`, `GetSlotButton()`, `SetSlotVisible()`.

**Important:** Match button dimensions and style exactly to existing buttons (106×36, FlatStyle.Flat, BorderSize=1, Segoe UI 9pt, Margin 4px).

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
- `.Designer.cs` files of UserControls — adding buttons programmatically avoids Designer breakage
- `.resx` files — no changes needed when adding programmatic controls
- `WeeklyMenuFromTemplateFiller.cs` — auto-filled dishes are applied after template, not during

## Verification checklist
- [ ] Build succeeds (use Visual Studio MSBuild, not `dotnet build` for .NET Framework projects)
- [ ] New slot appears in every meal cell with correct placeholder text and color
- [ ] Auto-fill populates the slot on form load
- [ ] Clicking the auto-filled slot does nothing (no chooser form opens)
- [ ] Nutrition totals include the new dish values
- [ ] Save/Load round-trips correctly (dish persists in DB)
- [ ] Template fill still works (auto-fill runs after template)
