using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class D_TCTD
    {
        public static DataTable TraCuuThucDon(int chedoID, int nam, int tuan)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_TraCuuThucDonTuan", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@chedo_id", chedoID);

            cmd.Parameters.AddWithValue("@nam", nam);

            cmd.Parameters.AddWithValue("@tuan", tuan);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }
        public static DataTable TraCuuDinhLuong(int chedoID)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_tracuudinhluongchuan", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@chedo_id", chedoID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            conn.Close();

            return dt;
        }

    }
}
