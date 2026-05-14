using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    public static class Session
    {
        public static int UserID { get; set; }

        public static string TenDangNhap { get; set; }

        public static int VaiTro { get; set; }

        public static int? DonViID { get; set; } // nullable
    }
}
