using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    public class KhoaSo
    {
        public int khoaso_id { get; set; }
        public DateTime ngay_thang_nam { get; set; }
        public int donvi_id { get; set; }
        public int? nguoi_khoa { get; set; } // null = tự động
        public DateTime thoi_gian_khoa { get; set; }
        public string ly_do { get; set; }
    }
}
