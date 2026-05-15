using System;
using System.Drawing;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public class frmHuongDanLapThucDon : Form
    {
        private PictureBox picGuide;

        public frmHuongDanLapThucDon()
        {
            BuildLayout();
        }

        private void BuildLayout()
        {
            Text = "Hướng dẫn lập thực đơn tuần";
            Size = new Size(920, 640);
            MinimumSize = new Size(840, 580);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                BackColor = Color.FromArgb(33, 48, 64),
                Padding = new Padding(20, 0, 20, 0)
            };

            Label title = new Label
            {
                Dock = DockStyle.Fill,
                Text = "HƯỚNG DẪN LẬP THỰC ĐƠN TUẦN",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };
            header.Controls.Add(title);

            SplitContainer body = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 560,
                FixedPanel = FixedPanel.Panel2,
                BackColor = Color.White
            };

            RichTextBox rtb = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10.5F),
                Text = GetHuongDanText(),
                Padding = new Padding(18)
            };

            picGuide = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 247, 250)
            };
            picGuide.Paint += picGuide_Paint;

            Panel footer = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 56,
                BackColor = Color.FromArgb(245, 247, 250),
                Padding = new Padding(18, 8, 18, 8)
            };

            Button btnClose = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Right,
                Width = 110,
                BackColor = Color.FromArgb(38, 132, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => Close();
            footer.Controls.Add(btnClose);

            body.Panel1.Padding = new Padding(18);
            body.Panel2.Padding = new Padding(18);
            body.Panel1.Controls.Add(rtb);
            body.Panel2.Controls.Add(picGuide);

            Controls.Add(body);
            Controls.Add(footer);
            Controls.Add(header);
        }

        private string GetHuongDanText()
        {
            return
@"1. Chọn tuần và chế độ ăn
   - Chọn một ngày bất kỳ trong ô Ngày trong tuần.
   - Hệ thống tự xác định tuần từ Thứ 2 đến Chủ nhật.
   - Chọn Chế độ ăn trong combobox.
   - Bảng thực đơn sẽ tải lại theo tuần và chế độ đã chọn.

2. Hiểu cấu trúc bảng thực đơn
   - Cột đầu tiên là Buổi: Sáng, Trưa, Tối.
   - Các cột còn lại là Thứ 2 đến Chủ nhật.
   - Mỗi ô trong bảng là một bữa ăn của một ngày.

3. Quy tắc số lượng món
   - Buổi sáng: 1 món mặn, 1 món canh, 1 sữa hộp.
   - Buổi trưa: 4 món mặn, 1 món canh, 1 món rau, 1 món tráng miệng.
   - Buổi tối: 4 món mặn, 1 món canh, 1 món rau, 1 món tráng miệng.
   - Tất cả các ô + Mặn, + Canh, + Rau, + Tráng miệng, + Sữa hộp đều phải được chọn trước khi lưu.

4. Chọn món cho một ô
   - Bấm vào ô món cần chọn trong bảng.
   - Form Chọn món sẽ mở ra và chỉ hiển thị các món đúng loại với ô đang chọn.
   - Double click vào món hoặc chọn món rồi bấm Chọn món.
   - Form chọn món đóng lại và tên món sẽ hiện ngay trên ô vừa chọn.

5. Xóa hoặc tải lại dữ liệu
   - Bấm một ô đã chọn món, sau đó bấm Xóa món khỏi ô để bỏ món đó.
   - Bấm Tải lại từ cơ sở dữ liệu để lấy lại thực đơn đã lưu trong tuần hiện tại.

6. Lưu thực đơn tuần
   - Chỉ bấm Lưu thực đơn tuần khi tất cả ô bắt buộc đã có món.
   - Hệ thống sẽ xóa chi tiết cũ của từng ngày/buổi trong tuần và lưu lại danh sách món mới.
   - Sau khi lưu thành công, trạng thái thực đơn chuyển thành Chờ duyệt.

Lưu ý
   - Món ăn được lấy từ bảng Mon_an trong cơ sở dữ liệu.
   - Loại món được phân nhóm theo Mặn, Canh, Rau, Tráng miệng, Sữa hộp.
   - Nếu form Chọn món không có dữ liệu, hãy kiểm tra cột monan_loaimon trong bảng Mon_an.";
        }

        private void picGuide_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(245, 247, 250));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Font titleFont = new Font("Segoe UI", 12F, FontStyle.Bold))
            using (Font textFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (Pen borderPen = new Pen(Color.FromArgb(180, 190, 200)))
            using (SolidBrush darkBrush = new SolidBrush(Color.FromArgb(52, 73, 94)))
            using (SolidBrush headerBrush = new SolidBrush(Color.FromArgb(236, 241, 247)))
            using (SolidBrush manBrush = new SolidBrush(Color.FromArgb(255, 239, 214)))
            using (SolidBrush canhBrush = new SolidBrush(Color.FromArgb(220, 239, 255)))
            using (SolidBrush rauBrush = new SolidBrush(Color.FromArgb(224, 245, 229)))
            using (SolidBrush trangMiengBrush = new SolidBrush(Color.FromArgb(255, 231, 238)))
            using (SolidBrush suaHopBrush = new SolidBrush(Color.White))
            using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(33, 48, 64)))
            using (SolidBrush whiteBrush = new SolidBrush(Color.White))
            {
                g.DrawString("Minh họa thao tác", titleFont, textBrush, 12, 12);

                Rectangle table = new Rectangle(12, 52, picGuide.Width - 24, 360);
                g.FillRectangle(whiteBrush, table);
                g.DrawRectangle(borderPen, table);

                int leftWidth = 70;
                int headerHeight = 40;
                int colWidth = (table.Width - leftWidth) / 2;
                int rowHeight = 160;

                g.FillRectangle(headerBrush, table.X, table.Y, table.Width, headerHeight);
                g.DrawRectangle(borderPen, table.X, table.Y, leftWidth, headerHeight);
                g.DrawString("Buổi", textFont, textBrush, table.X + 16, table.Y + 11);

                DrawCentered(g, "Thứ 2\n11/05", textFont, textBrush,
                    new Rectangle(table.X + leftWidth, table.Y, colWidth, headerHeight));
                DrawCentered(g, "Thứ 3\n12/05", textFont, textBrush,
                    new Rectangle(table.X + leftWidth + colWidth, table.Y, colWidth, headerHeight));

                DrawMealRow(g, table.X, table.Y + headerHeight, leftWidth, colWidth, rowHeight,
                    "Sáng", new[] { "+ Mặn 1", "+ Canh 1", "+ Sữa hộp 1" },
                    manBrush, canhBrush, rauBrush, trangMiengBrush, suaHopBrush, darkBrush, textBrush, borderPen, textFont);

                DrawMealRow(g, table.X, table.Y + headerHeight + rowHeight, leftWidth, colWidth, rowHeight,
                    "Trưa/Tối", new[] { "+ Mặn 1", "+ Mặn 2", "+ Mặn 3", "+ Mặn 4", "+ Canh 1", "+ Rau 1", "+ Tráng miệng 1" },
                    manBrush, canhBrush, rauBrush, trangMiengBrush, suaHopBrush, darkBrush, textBrush, borderPen, textFont);

                Rectangle choose = new Rectangle(26, 430, picGuide.Width - 52, 120);
                g.FillRectangle(whiteBrush, choose);
                g.DrawRectangle(borderPen, choose);
                g.DrawString("Khi bấm vào một ô:", textFont, textBrush, choose.X + 12, choose.Y + 12);
                g.DrawString("1. Form Chọn món mở ra", textFont, textBrush, choose.X + 24, choose.Y + 40);
                g.DrawString("2. Chỉ hiển thị món đúng loại", textFont, textBrush, choose.X + 24, choose.Y + 66);
                g.DrawString("3. Chọn món để đưa tên món về ô", textFont, textBrush, choose.X + 24, choose.Y + 92);
            }
        }

        private static void DrawMealRow(
            Graphics g,
            int x,
            int y,
            int leftWidth,
            int colWidth,
            int rowHeight,
            string mealName,
            string[] slots,
            Brush manBrush,
            Brush canhBrush,
            Brush rauBrush,
            Brush trangMiengBrush,
            Brush suaHopBrush,
            Brush darkBrush,
            Brush textBrush,
            Pen borderPen,
            Font textFont)
        {
            g.FillRectangle(darkBrush, x, y, leftWidth, rowHeight);
            DrawCentered(g, mealName, textFont, Brushes.White, new Rectangle(x, y, leftWidth, rowHeight));

            for (int col = 0; col < 2; col++)
            {
                Rectangle cell = new Rectangle(x + leftWidth + col * colWidth, y, colWidth, rowHeight);
                g.DrawRectangle(borderPen, cell);

                for (int i = 0; i < slots.Length; i++)
                {
                    Brush brush = GetSlotBrush(slots[i], manBrush, canhBrush, rauBrush, trangMiengBrush, suaHopBrush);
                    Rectangle slot = new Rectangle(cell.X + 14, cell.Y + 10 + i * 21, Math.Min(128, cell.Width - 28), 18);
                    g.FillRectangle(brush, slot);
                    g.DrawRectangle(borderPen, slot);
                    DrawCentered(g, slots[i], textFont, textBrush, slot);
                }
            }
        }

        private static Brush GetSlotBrush(string text, Brush manBrush, Brush canhBrush, Brush rauBrush, Brush trangMiengBrush, Brush suaHopBrush)
        {
            if (text.Contains("Canh"))
                return canhBrush;
            if (text.Contains("Rau"))
                return rauBrush;
            if (text.Contains("Tráng"))
                return trangMiengBrush;
            if (text.Contains("Sữa"))
                return suaHopBrush;
            return manBrush;
        }

        private static void DrawCentered(Graphics g, string text, Font font, Brush brush, Rectangle bounds)
        {
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(text, font, brush, bounds, format);
            }
        }
    }
}
