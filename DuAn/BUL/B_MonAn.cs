using System.Data;
using DuAn.DAO;

namespace DuAn.BUL
{
    internal class B_MonAn
    {
        public static int LayMaMoi()
        {
            return D_MonAn.LayMaMoi();
        }

        public static void ThemMonAn(int monanId, string tenMon, string loaiMon,
            string ghiChu, double? dam, double? chatBeo, double? chatXo)
        {
            D_MonAn.ThemMonAn(monanId, tenMon, loaiMon, ghiChu, dam, chatBeo, chatXo);
        }

        public static void ThemChiTietMonAn(int monanId, int thucPhamId, int cheDoId, decimal? tyLe)
        {
            D_MonAn.ThemChiTietMonAn(monanId, thucPhamId, cheDoId, tyLe);
        }

        public static DataTable LayDanhSachThucPham()
        {
            return D_MonAn.LayDanhSachThucPham();
        }

        public static DataTable LayDanhSachCheDo()
        {
            return D_MonAn.LayDanhSachCheDo();
        }
    }
}
