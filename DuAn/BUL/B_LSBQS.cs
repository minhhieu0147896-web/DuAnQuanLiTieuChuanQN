using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DAO;
using DuAn.DTO;
using System.Data;

namespace DuAn.BUL
{
    internal class B_LSBQS
    {
        public static DataTable TraCuu(LSBQS ls, int page, int pagesize)
        {
            return D_LSBQS.TraCuu(ls, page, pagesize);
        }
        public static int CountLSBQS(LSBQS ls)
        {
            return D_LSBQS.CountLSBQS(ls);
        }
    }
}
