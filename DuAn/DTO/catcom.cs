using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    internal class catcom
    {
        public int catcom_id { get; set; }
        public DateTime ngay_thang_nam { get; set; }
        public int buoian_id { get; set; }
        public int donvi_id { get; set; }
        public int quannhan_id { get; set; }
        public string catcom_ly_do { get; set; }
        public int trang_thai { get; set; } // 0=bị đè, 1=hiệu lực, 2=đã khóa
        public DateTime thoi_gian { get; set; }

    }
}
