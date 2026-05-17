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
    internal class B_thongkeqn
    {
        public static thongkecatcom thongke_thang(int quannhan_id, int thang, int nam)
        {
            return D_thongkeqn.thongke_thang(quannhan_id, thang, nam);
        }
        public static DataTable thongke_nam(int quannhan_id, int nam)
        {
            return D_thongkeqn.thongke_nam(quannhan_id, nam);
        }
    }
}
