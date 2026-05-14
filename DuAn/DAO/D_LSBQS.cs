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
        public static DataTable TraCuu(LSBQS ls,int page, int pagesize)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_lichsubaoqs", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tungay", ls.tungay);
            cmd.Parameters.AddWithValue("@denngay", ls.denngay);
            cmd.Parameters.AddWithValue("@donvi_id", ls.donvi_id);
            cmd.Parameters.AddWithValue("@buoian_id", ls.buoian_id);
            cmd.Parameters.AddWithValue("@page",page );
            cmd.Parameters.AddWithValue("@pagesize", pagesize);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;
        }
        public static int CountLSBQS(LSBQS ls)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd =
                new SqlCommand("sp_QuanSoAn_Count", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tungay", ls.tungay);

            cmd.Parameters.AddWithValue("@denngay", ls.denngay);

            cmd.Parameters.AddWithValue("@donvi", ls.donvi_id);

            cmd.Parameters.AddWithValue("@buoi", ls.buoian_id);

            conn.Open();

            int total =
                Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            return total;
        }

    }
}
