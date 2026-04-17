using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class AccountModel
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public int VaiTro { get; set; } // 1 = QuanNhan, 2 = NhanVien
        public string HoTen { get; set; }

        // Bổ sung thêm ID Đại đội để phục vụ phân quyền dữ liệu
        public int DaiDoiId { get; set; }
    }
}
