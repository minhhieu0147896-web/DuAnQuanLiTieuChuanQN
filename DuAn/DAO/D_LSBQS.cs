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

        public static DataTable TraCuu(LSBQS ls)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand("sp_BaoCaoQuanSo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tungay", ls.tungay.Date);
                cmd.Parameters.AddWithValue("@denngay", ls.denngay.Date);
                cmd.Parameters.AddWithValue("@donvi_id", ls.donvi_id);
                cmd.Parameters.AddWithValue("@buoian_id", ls.buoian_id);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        public static DataTable TraCuuThucPham(DateTime tuNgay, DateTime denNgay, int donViId, int buoiAnId, int cheDoId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand("sp_BaoCaoThucPham", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tungay", tuNgay.Date);
                cmd.Parameters.AddWithValue("@denngay", denNgay.Date);
                cmd.Parameters.AddWithValue("@donvi_id", donViId);
                cmd.Parameters.AddWithValue("@buoian_id", buoiAnId);
                cmd.Parameters.AddWithValue("@chedo_id", cheDoId);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
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
