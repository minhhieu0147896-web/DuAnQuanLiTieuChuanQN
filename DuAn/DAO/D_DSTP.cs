using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class D_DSTP
    {
        public static DataTable getalltp()
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_getalltp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void inserttp(DuAn.DTO.thucpham tp)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_inserttp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("thucpham_ten", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("thucpham_giatien", SqlDbType.Decimal);
            cmd.Parameters.Add("thucpham_kcal", SqlDbType.Decimal);
            cmd.Parameters.Add("thucpham_donvitinh", SqlDbType.NVarChar, 50);
            cmd.Parameters["thucpham_ten"].Value = tp.thucpham_ten;
            cmd.Parameters["thucpham_giatien"].Value = tp.thucpham_giatien;
            cmd.Parameters["thucpham_kcal"].Value = tp.thucpham_kcal;
            cmd.Parameters["thucpham_donvitinh"].Value = tp.thucpham_donvitinh;
            conn.Open();                 // MỞ KẾT NỐI
            cmd.ExecuteNonQuery();       // CHẠY INSERT
            conn.Close();                // ĐÓNG
        }
        public static void Updatetp(DuAn.DTO.thucpham tp)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();


            SqlCommand cmd = new SqlCommand("sp_updatetp", conn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@thucpham_id", tp.thucpham_id);
            cmd.Parameters.AddWithValue("@thucpham_ten", tp.thucpham_ten);
            cmd.Parameters.AddWithValue("@thucpham_giatien", tp.thucpham_giatien);
            cmd.Parameters.AddWithValue("@thucpham_donvitinh", tp.thucpham_donvitinh);
            cmd.Parameters.AddWithValue("@thucpham_kcal", tp.thucpham_kcal);
            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void Deletetp(int id)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_deletetp", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@thucpham_id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
