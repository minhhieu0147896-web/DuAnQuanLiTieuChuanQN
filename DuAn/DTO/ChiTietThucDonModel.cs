using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    public class ChiTietThucDonModel
    {
        public int ThucDonId { get; set; }
        public DateTime Ngay { get; set; }
        public int BuoiAnId { get; set; }
        public int MonAnId { get; set; }

        // Thông tin mở rộng để hiển thị (join từ bảng khác)
        public string TenMon { get; set; }
        public string TenBuoi { get; set; }
        public string LoaiMon { get; set; }
    }
}
