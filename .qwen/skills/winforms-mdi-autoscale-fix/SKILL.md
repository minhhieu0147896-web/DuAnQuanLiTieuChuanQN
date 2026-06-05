---
name: winforms-mdi-autoscale-fix
description: Diagnose and fix MDI child form layout issues caused by AutoScaleDimensions mismatch and conflicting WindowState/Dock settings
source: auto-skill
extracted_at: '2026-06-04T16:49:54.636Z'
---

# WinForms: Fix MDI Child Form Layout (Scale Mismatch + WindowState Conflict)

## When to apply
When an MDI child form appears "broken" — controls squeezed into a corner, font sizes wrong, layout distorted, or form flickers while loading — especially when:
- The form is opened as `child.MdiParent = parent; child.Dock = DockStyle.Fill;`
- The form was designed on a different machine or at a different DPI setting than the parent

## Root causes (check all three)

### 1. AutoScaleDimensions mismatch
If the MDI parent and child have different `AutoScaleDimensions`, WinForms will auto-scale the child when it's embedded. This distorts all control positions and font sizes.

**Check:** Compare `this.AutoScaleDimensions` in both forms' `.Designer.cs`:
```csharp
// Parent (frm_manhinh_nhanvien)
this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);  // 125% DPI

// Child (frmLapthucdon2) — BEFORE fix
this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);  // 100% DPI ❌
```

**Fix:** Make the child match the parent:
```csharp
this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);  // matches parent ✅
```

The values correspond to DPI scaling: `8F/16F` = 100%, `9F/20F` = 125%, `12F/24F` = 150%.

### 2. WindowState = Maximized on MDI child with Dock = Fill
When a form is `Dock = DockStyle.Fill` inside an MDI parent, setting `WindowState = Maximized` is redundant and causes an extra resize during load — adding flicker and potential layout glitches.

**Fix:** Remove `this.WindowState = System.Windows.Forms.FormWindowState.Maximized;` from the child's Designer.cs. The `Dock = Fill` already makes it fill the MDI client area.

### 3. Heavy synchronous loading on UI thread
If the form's `Load` event does database queries and control population synchronously, Windows can't paint the form until everything finishes — causing a "frozen white rectangle" effect.

**Fix pattern (anti-flicker):**
```csharp
// In constructor
this.DoubleBuffered = true;
this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint, true);

// Helper for containers without DoubleBuffered property
private static void SetDoubleBuffered(Control control)
{
    var prop = typeof(Control).GetProperty("DoubleBuffered",
        BindingFlags.Instance | BindingFlags.NonPublic);
    prop?.SetValue(control, true, null);
}

// In _Load event
private void Form_Load(object sender, EventArgs e)
{
    this.SuspendLayout();
    SetDoubleBuffered(weekGrid);     // heavy TableLayoutPanel
    SetDoubleBuffered(splBody);      // SplitContainer
    // ... load data, populate controls ...
    this.ResumeLayout(true);         // paint ONCE at the end
}
```

## Verification checklist
- [ ] Both forms have identical `AutoScaleDimensions` in Designer.cs
- [ ] Child form does NOT have `WindowState = Maximized` (Dock handles sizing)
- [ ] Child form loads and displays without flickering or white flash
- [ ] All controls appear at correct sizes and positions
