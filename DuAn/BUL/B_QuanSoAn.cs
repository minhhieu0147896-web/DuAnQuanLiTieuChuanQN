using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.BUL
{
    internal class B_QuanSoAn
    {
        public static thongke_quansoan ThongKeQuanSoAn(int donvi_id, DateTime ngay)
        {
            return D_QuanSoAn.ThongKeQuanSoAn(donvi_id, ngay);
        }

        public static DataTable QuanSoAnTheoDonVi(int donvi_id, DateTime ngay)
        {
            return D_QuanSoAn.QuanSoAnTheoDonVi(donvi_id, ngay);
        }

        public static DataTable ChiTietCatCom(int donvi_id, DateTime ngay)
        {
            return D_QuanSoAn.ChiTietCatCom(donvi_id, ngay);
        }

               public static int ChotSo(DateTime ngay, int donvi_id, int nguoi_khoa)
        {
            return D_QuanSoAn.ChotSo(ngay, donvi_id, nguoi_khoa);
        }

        public static bool CoTheChinhSua(DateTime ngay, int donvi_id)
        {
            if (ngay.Date < DateTime.Today) return false;
            if (ngay.Date == DateTime.Today && DateTime.Now.Hour >= 19) return false;
            return !D_QuanSoAn.IsKhoaSo(ngay, donvi_id);
        }

        public static bool IsKhoaSo(DateTime ngay, int donvi_id)
        {
            return D_QuanSoAn.IsKhoaSo(ngay, donvi_id);
        }
    }
}
