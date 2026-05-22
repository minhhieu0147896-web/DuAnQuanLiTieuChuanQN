using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DAO;

namespace DuAn.BUL
{
    internal class B_TCTD
    {
        public static DataTable TraCuuThucDon(int chedoID, int nam, int tuan)
        {
            return D_TCTD.TraCuuThucDon(chedoID, nam, tuan);
        }
        public static DataTable TraCuuDinhLuong(int chedoID)
        {
            return D_TCTD.TraCuuDinhLuong(chedoID);
        }
    }
}
