using DuAn.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DTO;

namespace DuAn.BUL
{
    internal class B_thongke_cb
    {
        public static DataTable ds_catcom_theongay(int donvi_id, DateTime ngay)
        {
            return D_thongkecb.ds_catcom_theongay(donvi_id, ngay);
        }

        // Thống kê biểu đồ
        public static thongke_tongquan thongke_tongquan(int donvi_id, DateTime ngay)
        {
            return D_thongkecb.thongke_tongquan(donvi_id, ngay);
        }
    }
}

