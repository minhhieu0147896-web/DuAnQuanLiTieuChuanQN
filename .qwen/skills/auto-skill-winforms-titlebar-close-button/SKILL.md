---
name: winforms-titlebar-close-button
description: Fix a misaligned or unstyled close button in a WinForms form title bar — set Anchor, vertical centering, red FlatStyle button with ✕ text
source: auto-skill
extracted_at: '2026-06-17T09:21:21.583Z'
---

# WinForms Title Bar Close Button

Use this skill when a close (X) button in a WinForms form's title bar panel is misaligned, doesn't resize properly, or uses default button styling instead of looking like a proper close button.

## The Problem

Common issues with close buttons in custom title bars:
- **Hardcoded `Location`** (e.g., `(1036, 0)`) with no `Anchor` — the button drifts when the form or MDI container resizes
- **Not vertically centered** — sits at `y=0` instead of centered in the title bar panel
- **Default button look** — gray 3D bevel, inconsistent with modern flat UI
- **Ambiguous text** — uses `" X"` with a leading space instead of the Unicode ✕ character

## The Fix Pattern

All changes go in the **Designer.cs** file, inside the `InitializeComponent()` method for the button.

### 1. Add Anchor to Top-Right

```csharp
this.btnthoat.Anchor = ((System.Windows.Forms.AnchorStyles)(
    System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
```

This makes the button stick to the top-right corner regardless of parent panel resizing.

### 2. Center Vertically

```csharp
// Formula: y = (panelHeight - buttonHeight) / 2
// Example: panel 64px, button 32px → y=16
this.btnthoat.Location = new System.Drawing.Point(1031, 16);
```

Right-edge position: `x = panelWidth - buttonWidth - margin` (e.g., `1086 - 45 - 10 = 1031`).

### 3. Flat Style + Red Background

```csharp
this.btnthoat.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);  // #C0392B
this.btnthoat.FlatAppearance.BorderSize = 0;
this.btnthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
this.btnthoat.ForeColor = System.Drawing.Color.White;
this.btnthoat.UseVisualStyleBackColor = false;
```

### 4. Clean Icon Text

```csharp
this.btnthoat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
this.btnthoat.Size = new System.Drawing.Size(45, 32);
this.btnthoat.Text = "✕";  // Unicode MULTIPLICATION X (U+2715), not the letter X
```

## Full Before/After Example

**Before** (broken):
```csharp
this.btnthoat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, FontStyle.Bold);
this.btnthoat.Location = new System.Drawing.Point(1036, 0);
this.btnthoat.Size = new System.Drawing.Size(50, 33);
this.btnthoat.Text = " X";
this.btnthoat.UseVisualStyleBackColor = true;
```

**After** (fixed):
```csharp
this.btnthoat.Anchor = ((System.Windows.Forms.AnchorStyles)(AnchorStyles.Top | AnchorStyles.Right));
this.btnthoat.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
this.btnthoat.FlatAppearance.BorderSize = 0;
this.btnthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
this.btnthoat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, FontStyle.Bold);
this.btnthoat.ForeColor = System.Drawing.Color.White;
this.btnthoat.Location = new System.Drawing.Point(1031, 16);
this.btnthoat.Size = new System.Drawing.Size(45, 32);
this.btnthoat.Text = "✕";
this.btnthoat.UseVisualStyleBackColor = false;
```

## Verification

After making changes:
1. Build the project
2. Run the app and navigate to the form
3. Zoom in on the title bar to confirm the button is centered and uses the red ✕ style
4. Resize the form to confirm the button stays at the top-right via Anchor

## When NOT to apply

- If the button is inside a standard `FormBorderStyle` title bar (use the built-in close button)
- If the title bar panel uses `AutoSize` or a `FlowLayoutPanel` — use layout properties instead of absolute positioning
- If the button is not a close button but a general action button in the title bar (use different colors)
