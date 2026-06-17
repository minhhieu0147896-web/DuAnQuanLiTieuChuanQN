---
name: winforms-sidebar-menu-item
description: Add a new menu button to the collapsible left sidebar (FlowLayoutPanel) of an MDI container form like frm_manhinh_nhanvien — following the existing icon + panel + button pattern so it looks identical to sibling items and participates in the collapse animation
source: auto-skill
extracted_at: '2026-06-17T16:12:00.000Z'
---

# WinForms — Add a sidebar menu button to an MDI container form

Use this when adding a new navigation button to the dark collapsible sidebar (`slidebar`
FlowLayoutPanel) of an MDI parent form (e.g. `frm_manhinh_nhanvien`,
`frm_manhinh_canbodonvi`).

## Sidebar structure (recurring pattern)

```
slidebar (FlowLayoutPanel, Dock=Left)
├── FlowLayoutPanel container (e.g. pndanhsachthucpham)        ← wrapper
│   └── Panel (e.g. panel12)                                   ← row
│       ├── PictureBox (icon)                                  ← 34×48, StretchImage
│       └── Button (big clickable area, overlaps the panel)    ← -16,-18, 342×99
├── FlowLayoutPanel container …  (next item)
```

**Every top-level sidebar item is a FlowLayoutPanel container** that holds exactly one
Panel row. The row contains a PictureBox (left icon) and a Button (text + click handler).

## Step-by-step: add a new sidebar button

### 1. Read the existing Designer.cs to copy the pattern

Pick a **simple non-expandable** item (e.g. `pndanhsachthucpham` or `flowLayoutPanel1`)
as the template. Expandable containers (like `thucdoncontainer`) have extra sub-panels —
don't copy those unless you also need expand/collapse.

### 2. Design the control names

Choose a short Vietnamese prefix and name the four controls consistently:

| Control | Name convention | Example |
|---------|----------------|---------|
| FlowLayoutPanel (wrapper) | `pn<name>container` | `pnmonancontainer` |
| Panel (row) | `panel_<name>` | `panel_monan` |
| PictureBox (icon) | `pictureBox_<name>` | `pictureBox_monan` |
| Button | `btn<name>` | `btnmonan` |

### 3. Edit the Designer.cs — 4 insertion points

#### A) ⚠️ NEW statements (CRITICAL — near line ~35, at the very start of InitializeComponent)

All controls are instantiated with `new` at the beginning of `InitializeComponent()`.
Insert the new `new` lines **in the same order they appear in the sidebar**,
right after the item they follow:

```csharp
this.btndstp = new System.Windows.Forms.Button();
this.pn<name>container = new System.Windows.Forms.FlowLayoutPanel();
this.panel_<name> = new System.Windows.Forms.Panel();
this.pictureBox_<name> = new System.Windows.Forms.PictureBox();
this.btn<name> = new System.Windows.Forms.Button();
this.thucdoncontainer = new System.Windows.Forms.FlowLayoutPanel();  // ← next item
```

> **Without these `new` statements the C# compiler will throw CS0117 errors and the
> Designer will show a yellow error screen.** The fields ARE declared (Section 6), but
> if they're never instantiated via `new` in InitializeComponent, the SuspendLayout
> calls and property assignments below will fail to compile.

#### B) SuspendLayout block (near line ~110)

Insert BEFORE the template item's SuspendLayout that you're copying from:

```csharp
this.pn<name>container.SuspendLayout();
this.panel_<name>.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.pictureBox_<name>)).BeginInit();
```

#### C) Property initialisation block (near line ~250)

Copy the whole block of the template item and replace names + text:

```csharp
// pn<name>container
this.pn<name>container.BackColor = System.Drawing.Color.FromArgb(…);
this.pn<name>container.Controls.Add(this.panel_<name>);
this.pn<name>container.Location = new System.Drawing.Point(3, <Y>);
this.pn<name>container.Name = "pn<name>container";
this.pn<name>container.Size = new System.Drawing.Size(247, 73);
this.pn<name>container.TabIndex = <unique_tab_index>;

// panel_<name>
this.panel_<name>.BackColor = System.Drawing.Color.FromArgb(23, 24, 29);
this.panel_<name>.Controls.Add(this.pictureBox_<name>);
this.panel_<name>.Controls.Add(this.btn<name>);
this.panel_<name>.Location = new System.Drawing.Point(3, 3);
this.panel_<name>.Name = "panel_<name>";
this.panel_<name>.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
this.panel_<name>.Size = new System.Drawing.Size(344, 67);
this.panel_<name>.TabIndex = 4;

// pictureBox_<name> — reuse an existing icon resource
this.pictureBox_<name>.Image = ((System.Drawing.Image)(resources.GetObject("<any_existing_icon>")));
this.pictureBox_<name>.Location = new System.Drawing.Point(13, 6);
this.pictureBox_<name>.Name = "pictureBox_<name>";
this.pictureBox_<name>.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
this.pictureBox_<name>.Size = new System.Drawing.Size(34, 48);
this.pictureBox_<name>.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
this.pictureBox_<name>.TabIndex = 1;
this.pictureBox_<name>.TabStop = false;

// btn<name>
this.btn<name>.BackColor = System.Drawing.Color.FromArgb(24, 25, 29);
this.btn<name>.ForeColor = System.Drawing.SystemColors.ButtonFace;
this.btn<name>.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.btn<name>.Location = new System.Drawing.Point(-16, -18);
this.btn<name>.Name = "btn<name>";
this.btn<name>.Size = new System.Drawing.Size(342, 99);
this.btn<name>.TabIndex = 0;
this.btn<name>.Text = "<Display Text>";
this.btn<name>.UseVisualStyleBackColor = false;
this.btn<name>.Click += new System.EventHandler(this.btn<name>_Click);
```

⚠️ **tabIndex must be unique** across all sibling containers. Scan the file for existing
values (common: 9, 10, 11, 12) and pick an unused one.

⚠️ The `Location` is overridden by the FlowLayoutPanel — use values from the template
item; the Y coordinate doesn't matter, but keep it reasonable (e.g. 3, 82, 163 etc.).

#### D) slidebar.Controls.Add — insert in correct order

Find `this.slidebar.Controls.Add(this.<item_above>);` and insert the new container
**right after** the item it should follow:

```csharp
this.slidebar.Controls.Add(this.pndanhsachthucpham);
this.slidebar.Controls.Add(this.pnmonancontainer);    // NEW — after dstp, before thucdon
this.slidebar.Controls.Add(this.thucdoncontainer);
```

### 4. ResumeLayout block (near end of InitializeComponent)

Add matching EndInit/ResumeLayout calls **before** the template item's resume:

```csharp
this.pn<name>container.ResumeLayout(false);
this.panel_<name>.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.pictureBox_<name>)).EndInit();
```

### 5. Field declarations (end of file, inside `#region`)

```csharp
private System.Windows.Forms.FlowLayoutPanel pn<name>container;
private System.Windows.Forms.Panel panel_<name>;
private System.Windows.Forms.PictureBox pictureBox_<name>;
private System.Windows.Forms.Button btn<name>;
```

### 6. Code-behind (.cs file) — 3 changes

#### A) Form-level field for the child form

```csharp
frm<ChildForm> ftma;  // near other frm… fields
```

#### B) Click handler (near other _Click handlers)

```csharp
private void btn<name>_Click(object sender, EventArgs e)
{
    CloseAllChildForms();
    ftma = new frm<ChildForm>();
    ftma.MdiParent = this;
    ftma.WindowState = FormWindowState.Maximized;
    ftma.FormClosed += (s, args) => ftma = null;
    ftma.Show();
}
```

Pattern: close all children, create new form, set MDI parent, **maximize** it so it fills
the MDI container correctly.

> **Use `WindowState = FormWindowState.Maximized` — NOT `Dock = DockStyle.Fill`.**
> MDI children don't always respect Dock=Fill; they may leave white gaps at the edges
> or fail to fill the container. `Maximized` is the standard, reliable approach for MDI
> child forms.

#### C) Collapse animation — add Width update in `slidebartransition_Tick`

The timer handler explicitly sets Width on every container when the sidebar
collapses/expands. Add the new container in **both branches** (if/else):

```csharp
pn<name>container.Width = slidebar.Width;
```

Also add `flowLayoutPanel1.Width = slidebar.Width;` if it's missing (it's often
forgotten).

## Build + Designer

- The user must **build from inside Visual Studio** (Ctrl+Shift+B) — MSBuild from
  command line is blocked on Hiếu's machine.
- After a successful build, the Designer will recognise the new fields. If it still shows
  errors, close and re-open the Designer tab (right-click → View Designer).
