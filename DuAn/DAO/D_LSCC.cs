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
    internal class D_LSCC
    {
        public static DataTable TraCuu(DuAn.DTO.LSCC ls)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_lichsucatcom", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@quannhan_id", ls.quannhan_id);
            cmd.Parameters.AddWithValue("@tungay", ls.tungay);
            cmd.Parameters.AddWithValue("@denngay", ls.denngay);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;

        }
    }
}
