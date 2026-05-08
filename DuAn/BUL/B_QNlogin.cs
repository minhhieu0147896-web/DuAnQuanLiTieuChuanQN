using DuAn.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DTO;
using DuAn.DAO;

namespace DuAn.BUL
{
    internal class B_QNlogin
    {
        public static qnlogin GetQuanNhanByMa(int maqn)
        {
            return D_qnlogin.GetQuanNhanByMa(maqn);
        }
    }
}
