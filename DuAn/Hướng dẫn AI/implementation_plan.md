# Kế Hoạch Triển Khai: Luồng Xử Lý Tránh Trùng Lặp Món Ăn Thông Minh

Kế hoạch này mô tả các giai đoạn và công việc cụ thể để tích hợp tính năng kiểm soát, cảnh báo và chặn trùng lặp món ăn trực quan trên giao diện lập thực đơn tuần (`frmLapthucdon2` và `frmchonmon`).

---

## Giai Đoạn & Công Việc Cụ Thể (Phases & Tasks)

Chi tiết lộ trình triển khai gồm **3 giai đoạn** chính với các công việc cụ thể như sau:

### Giai Đoạn 1: Xây Dựng Lớp Logic Đánh Giá Trùng Lặp
*   **Công việc 1.1:** Tạo mới lớp Helper `DuplicateChecker.cs` trong thư mục `BUL` hoặc `DTO` để đóng gói toàn bộ quy tắc đánh giá trùng lặp.
*   **Công việc 1.2:** Định nghĩa enum `DuplicateStatus` bao gồm các trạng thái:
    *   `None`: Hợp lệ, khuyến nghị sử dụng.
    *   `WarningDaySpan`: Cảnh báo món ăn đã được dùng trong ngày hôm qua hoặc ngày mai (Soft Limit).
    *   `WarningFreq`: Cảnh báo món ăn đã đạt ngưỡng tần suất tối đa trong tuần (Soft Limit - Mặn chính: 2 lần/tuần, các loại khác: 3 lần/tuần).
    *   `BlockedSameDay`: Chặn cứng do món ăn đã xuất hiện ở bữa ăn khác trong cùng một ngày (Hard Limit).
*   **Công việc 1.3:** Viết hàm static `GetStatus(...)` tính toán trạng thái trùng lặp của một món ăn cụ thể tại ô đang chọn so với danh sách món ăn đã chọn trong tuần.

### Giai Đoạn 2: Nâng Cấp Form Chọn Món (`frmchonmon.cs`)
*   **Công việc 2.1:** Cải tiến các Constructor trong `frmchonmon.cs` để nhận thêm tham số ngữ cảnh lập thực đơn:
    *   `Dictionary<string, MonAnModel> currentWeekMeals`: Danh sách các món ăn đã được chọn trong tuần hiện tại.
    *   `DateTime targetDate`: Ngày của ô đang chọn.
    *   `int targetBuoiId`: ID buổi ăn của ô đang chọn (Sáng, Trưa, Chiều).
*   **Công việc 2.2:** Cải tiến lưới hiển thị `dgvMonAn` trong `frmchonmon`:
    *   Thêm cột **"Khuyến nghị" (Status/Warning)** hiển thị chi tiết lý do trùng lặp (ví dụ: *"Đã dùng hôm nay"*, *"Vừa ăn hôm qua"*, *"Đã dùng 2 lần/tuần"*).
*   **Công việc 2.3:** Bổ sung sự kiện `CellFormatting` của `DataGridView`:
    *   Tô màu đỏ nhạt/xám dòng đối với các món bị **Chặn cứng** (`BlockedSameDay`).
    *   Tô màu vàng nhạt/chữ cam đối với các món có **Cảnh báo** (`WarningDaySpan`, `WarningFreq`).
*   **Công việc 2.4:** Cập nhật hàm chọn món `ChooseSelected()` và sự kiện double-click:
    *   Nếu người dùng chọn món bị trùng cùng ngày (`BlockedSameDay`), hiển thị thông báo lỗi và **không cho phép chọn**.

### Giai Đoạn 3: Tích Hợp Vào Giao Diện Lập Thực Đơn Tuần (`frmLapthucdon2.cs`)
*   **Công việc 3.1:** Cập nhật hàm gọi form chọn món `OpenChooseDishForm(...)` trong `frmLapthucdon2.cs`:
    *   Truyền đầy đủ danh sách món đang chọn trên lưới (`_selectedMeals`), ngày của ô slot (`slot.Date`), và ID buổi ăn (`slot.BuoiAn.BuoiAnId`) vào constructor mới của `frmchonmon`.
*   **Công việc 3.2:** Đảm bảo luồng hoạt động mượt mà và không phát sinh lỗi bất tương thích dữ liệu khi tải dữ liệu tuần mới.

---

## Các File Sẽ Thay Đổi (Proposed Changes)

### [NEW] [DuplicateChecker.cs](file:///e:/lung%20tung/DuAnQuanLiTieuChuanQN/DuAn/BUL/DuplicateChecker.cs)
*   Tạo mới lớp để kiểm soát nghiệp vụ trùng lặp món ăn.

### [MODIFY] [frmchonmon.cs](file:///e:/lung%20tung/DuAnQuanLiTieuChuanQN/DuAn/GUI/frmnhanvien/frmchonmon.cs)
*   Thêm constructor mới.
*   Cải tiến lưới DataGridView hiển thị trạng thái khuyến nghị/cảnh báo/chặn cứng.
*   Tô màu trực quan và ràng buộc chặn chọn món trùng ngày.

### [MODIFY] [frmLapthucdon2.cs](file:///e:/lung%20tung/DuAnQuanLiTieuChuanQN/DuAn/GUI/frmnhanvien/frmLapthucdon2.cs)
*   Cập nhật luồng truyền dữ liệu ngữ cảnh sang `frmchonmon`.

---

## Kế Hoạch Xác Minh (Verification Plan)

### Kiểm thử Thủ công (Manual Verification)
1.  **Kiểm tra tính năng Chặn cùng ngày (Hard Limit):**
    *   Chọn món "Gà chiên" cho bữa *Trưa Thứ Hai*.
    *   Bấm vào ô bữa *Tối Thứ Hai*, mở Form chọn món, kiểm tra xem món "Gà chiên" có bị xám màu, hiển thị chữ *"Chặn: Đã dùng hôm nay"* và không cho phép chọn hay không.
2.  **Kiểm tra tính năng Cảnh báo ngày liên tiếp (Soft Limit):**
    *   Chọn món "Cá rán" cho bữa *Trưa Thứ Hai*.
    *   Bấm vào ô bữa *Trưa Thứ Ba*, mở Form chọn món, kiểm tra xem món "Cá rán" có hiển thị cảnh báo *"Cảnh báo: Vừa ăn hôm qua/ngày mai"* với màu chữ cam/nền vàng nhạt hay không (nhưng vẫn cho phép chọn).
3.  **Kiểm tra tính năng Tần suất tuần (Soft Limit):**
    *   Chọn món mặn "Thịt luộc" vào bữa *Trưa Thứ Hai* và bữa *Trưa Thứ Tư* (đã đạt giới hạn 2 lần/tuần).
    *   Bấm vào ô bữa *Trưa Thứ Sáu*, mở Form chọn món, kiểm tra xem món "Thịt luộc" có hiển thị cảnh báo *"Lưu ý: Đã dùng 2 lần trong tuần"* hay không.
