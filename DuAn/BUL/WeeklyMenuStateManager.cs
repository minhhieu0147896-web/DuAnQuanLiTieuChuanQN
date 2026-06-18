using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DuAn.BUL
{
    /// <summary>
    /// Quản lý trạng thái thực đơn tuần: quy tắc chuyển trạng thái và khóa/mở khóa UI.
    /// Tách khỏi form để dễ đọc và dễ kiểm thử.
    /// </summary>
    public static class WeeklyMenuStateManager
    {
        // ── Hằng trạng thái ──────────────────────────────────────
        public const string NhapLieu   = "NhapLieu";
        public const string ChoDuyet   = "ChoDuyet";
        public const string DaDuyet    = "DaDuyet";
        public const string TuChoi     = "TuChoi";

        // ── Quy tắc nghiệp vụ ────────────────────────────────────

        /// <summary>
        /// Trạng thái có được phép chỉnh sửa thực đơn không?
        /// Đã duyệt → chỉ xem; còn lại → được sửa.
        /// </summary>
        public static bool IsEditable(string status)
        {
            return status != DaDuyet;
        }

        /// <summary>
        /// Khi người dùng bắt đầu sửa một tuần đang ChoDuyet,
        /// có cần tự động quay về NhapLieu không?
        /// </summary>
        public static bool ShouldAutoRevert(string status)
        {
            return status == ChoDuyet || status == DaDuyet;
        }

        /// <summary>
        /// Trả về trạng thái sau khi tự động revert.
        /// </summary>
        public static string GetRevertedStatus(string currentStatus)
        {
            if (currentStatus == ChoDuyet || currentStatus == DaDuyet)
                return NhapLieu;
            return currentStatus;
        }

        /// <summary>
        /// Tên hiển thị tiếng Việt của trạng thái.
        /// </summary>
        public static string GetDisplayName(string status)
        {
            switch (status)
            {
                case NhapLieu:   return "Nhập liệu";
                case ChoDuyet:   return "Chờ duyệt";
                case DaDuyet:    return "Đã duyệt";
                case TuChoi:     return "Từ chối";
                default:         return status;
            }
        }

        // ── Khóa / mở khóa UI ────────────────────────────────────

        /// <summary>
        /// Khóa toàn bộ control chỉnh sửa thực đơn (chế độ chỉ xem).
        /// </summary>
        public static void LockEditing(
            IEnumerable<Control> slotControls,
            Button btnXoaMon,
            Button btnDienTuMau,
            Button btnLuu,
            ComboBox cboCheDo)
        {
            foreach (Control slot in slotControls)
            {
                slot.Enabled = false;
                slot.BackColor = Color.FromArgb(240, 240, 240);
            }

            SetControlEnabled(btnXoaMon, false);
            SetControlEnabled(btnDienTuMau, false);
            SetControlEnabled(btnLuu, false);
            SetControlEnabled(cboCheDo, false);
            MessageBox.Show("Tuần này đã được duyệt. Không sửa !");
          
        }

        /// <summary>
        /// Mở khóa toàn bộ control chỉnh sửa thực đơn.
        /// </summary>
        public static void UnlockEditing(
            IEnumerable<Control> slotControls,
            Button btnXoaMon,
            Button btnDienTuMau,
            Button btnLuu,
            ComboBox cboCheDo,
            DateTimePicker dtpWeek)
        {
            foreach (Control slot in slotControls)
            {
                slot.Enabled = true;
            }

            SetControlEnabled(btnXoaMon, true);
            SetControlEnabled(btnDienTuMau, true);
            SetControlEnabled(btnLuu, true);
            SetControlEnabled(cboCheDo, true);
            SetControlEnabled(dtpWeek, true);
        }

        // ── Helpers ──────────────────────────────────────────────

        private static void SetControlEnabled(Control control, bool enabled)
        {
            if (control != null)
                control.Enabled = enabled;
        }
    }
}
