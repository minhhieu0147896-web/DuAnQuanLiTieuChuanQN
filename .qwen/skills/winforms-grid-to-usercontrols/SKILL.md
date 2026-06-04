---
name: winforms-grid-to-usercontrols
description: Convert code-generated TableLayoutPanel content (headers, cells, buttons) into design-time UserControls visible in WinForms Designer
source: auto-skill
extracted_at: '2026-06-04T18:30:00.000Z'
---

# WinForms: Convert Code-Generated Grid Content to Design-Time UserControls

## When to apply
When a WinForms form uses a `TableLayoutPanel` whose content (header labels, meal labels, slot buttons, etc.) is entirely created at runtime via `new Label()` / `new Button()` / `new FlowLayoutPanel()` inside methods like `BuildWeekGrid()` or `NormalizeDesignedControls()`, and the user wants to **see the content in the Designer** instead of an empty grid.

## Pattern

### Step 1: Identify repeatable cell types
Look at the code that populates the grid. Group cells by their internal structure. In our case:
- **Sáng cells**: 3 slots (Mặn, Canh, Sữa) → `UcMealCellSang`
- **Trưa/Tối cells**: 7 slots (4×Mặn, Canh, Rau, Tráng miệng) → `UcMealCellTruaToi`

### Step 2: Extract shared enums/types to separate files
Move private enums (`DishCategory`, `MealKind`) out of the form into a standalone file (e.g., `MealEnums.cs`) so both the form and UserControls can reference them.

### Step 3: Create UserControls with design-time buttons
For each cell type, create a WinForms `UserControl` containing:
- A `FlowLayoutPanel` docked `Fill` (matches original `CreateMealCell()` behavior)
- Buttons for each slot, with design-time visible properties (text, color, size)
- A `GetAllSlots()` method returning `IEnumerable<Button>` 
- A `GetSlotButton(DishCategory, int index)` method for lookups
- A `SetSlotVisible(DishCategory, bool)` for show/hide logic

**Why:** Buttons exist at design time in the UserControl's own Designer. The parent form no longer needs to `new Button()`.

### Step 4: Create a metadata class for Button.Tag
Replace custom button subclasses (e.g., `SlotButton : Button`) with a plain `Button` + metadata stored in `Button.Tag`:
```csharp
public class SlotMetadata {
    public string Key { get; set; }
    public DateTime Date { get; set; }
    public BuoiAnModel BuoiAn { get; set; }
    public MealKind Meal { get; set; }
    public DishCategory Category { get; set; }
    public int CategoryIndex { get; set; }
}
```

### Step 5: Place UserControls in the TableLayoutPanel via Designer.cs
- Add field declarations for each UserControl instance (e.g., `ucT2Sang`, `ucT2Trua`, ...)
- Add header/meal labels as regular `Label` controls with `Dock = Fill`
- Call `weekGrid.Controls.Add(control, column, row)` for each control in `InitializeComponent()`
- Use systematic naming: `uc{Day}{Meal}` — makes it easy to build reference arrays

### Step 6: Create reference arrays in the form
```csharp
private Label[] _dayHeaders;        // for updating header text at runtime
private UserControl[,] _mealCells;  // [3 meals, 7 days] for quick lookup
```
Initialize in constructor with the design-time control references.

### Step 7: Replace BuildWeekGrid with PopulateWeekGrid
Instead of clearing and recreating controls:
- Update existing header labels' `.Text` with dates
- Iterate UserControls, get buttons via `GetSlotButton()`, assign `Tag` with metadata
- Wire `Click` events
- Show/hide dynamic slots (e.g., Sữa only visible for học viên chế độ)
- Build `_slots` dictionary mapping keys → `Button`

### Step 8: Update all SlotButton references
Change `Dictionary<string, SlotButton>` → `Dictionary<string, Button>`, and replace `slot.Key` with `((SlotMetadata)slot.Tag).Key`, etc. throughout the form.

### Step 9: Remove dead code
Delete: the old `SlotButton` class, `NormalizeDesignedControls()`, `BuildWeekGrid()`, `CreateGridHeader()`, `CreateMealHeader()`, `CreateMealCell()`, `CreateSlot()`.

### Step 10: Add new files to .csproj
Every new `.cs`, `.Designer.cs`, and `.resx` file must be added as `<Compile>` / `<EmbeddedResource>` entries in `DuAn.csproj`. UserControls get `<SubType>UserControl</SubType>`.

## Verification
After build: open the form in Visual Studio Designer. The grid should show all header labels, meal labels, and UserControls with visible buttons in their correct positions and colors.
