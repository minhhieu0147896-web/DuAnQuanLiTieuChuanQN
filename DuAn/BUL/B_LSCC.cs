using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DAO;
using DuAn.DTO;

namespace DuAn.BUL
{
    internal class B_LSCC
    {
        public static DataTable TraCuu(LSCC ls)
        {
            return D_LSCC.TraCuu(ls);
        }
    }
}
