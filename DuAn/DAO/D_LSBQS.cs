using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class D_LSBQS
    {
        public static DataTable TraCuu(LSBQS ls)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_lichsubaoqs", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tungay", ls.tungay);
            cmd.Parameters.AddWithValue("@denngay", ls.denngay);
            cmd.Parameters.AddWithValue("@donvi_id", ls.donvi_id);
            cmd.Parameters.AddWithValue("@buoian_id", ls.buoian_id);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;
        }

    }
}
