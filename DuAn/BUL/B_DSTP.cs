using DuAn.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.BUL
{
    internal class B_DSTP
    {
        public static DataTable getalltp()
        {
            return D_DSTP.getalltp();
        }
        public static void inserttp(DuAn.DTO.thucpham tp)
        {
            D_DSTP.inserttp(tp);
        }
        public static void Updatetp(DuAn.DTO.thucpham tp)
        {
            D_DSTP.Updatetp(tp);
        }
        public static void Deletetp(int id)
        {
            D_DSTP.Deletetp(id);
        }
    }
}
