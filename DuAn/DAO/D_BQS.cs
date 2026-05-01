using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class D_BQS
    {
        public static DataTable LoadBuoi()
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd = new SqlCommand("sp_getallbuoi", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public static DataTable LoadBaoQuanSo(int madv)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd = new SqlCommand("sp_getbqs", conn);
           
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@donvi_id", madv);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;

           
        }
        public static void InsertCatCom(catcom cc)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd = new SqlCommand("sp_insertcc", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngaythangnam", cc.ngay_thang_nam);
            cmd.Parameters.AddWithValue("@buoian_id", cc.buoian_id);
            cmd.Parameters.AddWithValue("@donvi_id", cc.donvi_id);
            cmd.Parameters.AddWithValue("@quannhan_id", cc.quannhan_id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void InsertQuanSoAn(quansoan qs)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd = new SqlCommand("sp_insertqsa", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay", qs.ngay_thang_nam);
            cmd.Parameters.AddWithValue("@buoian_id", qs.buoian_id);
            cmd.Parameters.AddWithValue("@donvi_id", qs.donvi_id);
            cmd.Parameters.AddWithValue("@chedo_id", qs.chedo_id);
            cmd.Parameters.AddWithValue("@soluong", qs.soluong);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static int KiemTraDaBao(DateTime ngay, int mabuoi, int madv)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd = new SqlCommand("sp_KiemTraDaBao", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@buoian_id", mabuoi);
            cmd.Parameters.AddWithValue("@donvi_id", madv);

            conn.Open();

            int kq = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            return kq;
        }



    }
}
