using System;
using System.Drawing;
using System.Windows.Forms;

namespace frmnhanvien
{
    public class frmHuongDanLapThucDon : Form
    {
        public frmHuongDanLapThucDon()
        {
            this.Text = "Hướng dẫn sử dụng Lập thực đơn";
            this.Size = new Size(620, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            rtb.ReadOnly = true;
            rtb.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            rtb.BackColor = Color.White;
            rtb.Text = GetHuongDanText();
            this.Controls.Add(rtb);
        }

        private string GetHuongDanText()
        {
            return @"HƯỚNG DẪN SỬ DỤNG FORM LẬP THỰC ĐƠN

1. CHỌN NGÀY VÀ BUỔI
   - Chọn ngày từ ô chọn ngày (DateTimePicker).
   - Chọn buổi ăn (Sáng / Trưa / Chiều) từ combobox Buổi.
   - Sau khi chọn, bảng bên phải sẽ hiển thị danh sách món ăn đã có trong thực đơn của buổi đó.
   - Nếu chưa có thực đơn cho tuần, hệ thống sẽ tự động tạo thực đơn trạng thái ""Nhập liệu"".

2. XEM / LÀM MỚI DANH SÁCH
   - Nhấn nút ""Hiển thị"" để nạp lại dữ liệu từ cơ sở dữ liệu (nếu nghi ngờ dữ liệu chưa được cập nhật).

3. THÊM MÓN ĂN
   a) Chọn loại món từ combobox ""Loại món"" (ví dụ: Mặn chính, Canh, Tráng miệng...).
   b) Combobox ""Danh sách món ăn"" sẽ hiện ra các món thuộc loại vừa chọn.
   c) Chọn một món cụ thể trong combobox đó.
   d) Nhấn nút ""Thêm vào thực đơn"".
   - Món sẽ được lưu ngay vào cơ sở dữ liệu và hiện lên bảng danh sách.
   - Mỗi món chỉ được thêm một lần trong cùng buổi/ngày.

4. XÓA MÓN ĂN
   a) Trong bảng danh sách món (DataGridView), click chọn dòng chứa món cần xóa.
   b) Nhấn nút ""Bỏ"" (hoặc ""Xóa món"").
   c) Xác nhận xóa → Món sẽ được xóa khỏi cơ sở dữ liệu và bảng danh sách được cập nhật lại.

5. LƯU THỰC ĐƠN TUẦN
   - Sau khi đã lập xong các bữa trong tuần, nhấn nút ""Lưu"" (Lưu thực đơn tuần).
   - Hệ thống sẽ hỏi xác nhận chuyển trạng thái thực đơn từ ""Nhập liệu"" sang ""Chờ duyệt"".
   - Lưu ý: Nút này không lưu lại các món riêng lẻ (vì chúng đã được lưu khi thêm/bỏ). Nó chỉ đánh dấu thực đơn đã hoàn thành.

GHI CHÚ
- Mỗi tuần (theo số tuần ISO) chỉ có một bản thực đơn cho mỗi chế độ ăn.
- Chế độ ăn hiện tại mặc định là chế độ 1 (có thể thay đổi sau này).
- Để lập thực đơn cho cả tuần, bạn cần chọn lần lượt từng ngày và buổi để thêm món.
- Các thao tác thêm/xóa đều có kiểm tra trùng lặp và báo lỗi nếu có vấn đề.
";
        }
    }
}