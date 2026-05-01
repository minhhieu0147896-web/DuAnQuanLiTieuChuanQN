using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DAO;

namespace DuAn.BUL
{
    internal class B_BQS
    {
        public static DataTable loadbuoi()
        {
            return DAO.D_BQS.LoadBuoi();
        }
        public static DataTable loadbqs(int madv)
        {
            return DAO.D_BQS.LoadBaoQuanSo(madv);
        }
        public static void insertcatcom(DTO.catcom cc)
        {
            DAO.D_BQS.InsertCatCom(cc);
        }
        public static void insertqsa(DTO.quansoan qsa)
        {
            DAO.D_BQS.InsertQuanSoAn(qsa);
        }
        public static int KiemTraDaBao(DateTime ngay, int mabuoi, int madv)
        {
            return DAO.D_BQS.KiemTraDaBao(ngay, mabuoi, madv);
        }

    }
}
