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
        //public static void InsertCatCom(catcom cc)
        //{
        //    SqlConnection conn = DataProvider.Instance.GetConnection();

        //    SqlCommand cmd = new SqlCommand("sp_insertcc", conn);

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@ngaythangnam", cc.ngay_thang_nam);
        //    cmd.Parameters.AddWithValue("@buoian_id", cc.buoian_id);
        //    cmd.Parameters.AddWithValue("@donvi_id", cc.donvi_id);
        //    cmd.Parameters.AddWithValue("@quannhan_id", cc.quannhan_id);

        //    conn.Open();
        //    cmd.ExecuteNonQuery();
        //    conn.Close();
        //}
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
        public static bool KiemTraDaBao(DateTime ngay, int mabuoi, int madv)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd = new SqlCommand("sp_KiemTraDaBao", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@buoian", mabuoi);
            cmd.Parameters.AddWithValue("@donvi", madv);

            SqlParameter p = new SqlParameter("@ketqua", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return Convert.ToInt32(p.Value) == 1;
        }

        //==================================================
        // KIEM TRA DA KHOA SO
        //==================================================
        public static bool KiemTraDaKhoaSo(DateTime ngay, int madv)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd = new SqlCommand("sp_KiemTraKhoaSo", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@donvi", madv);

            SqlParameter p = new SqlParameter("@ketqua", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            return Convert.ToInt32(p.Value) == 1;
        }

        public static int CountBQS(int donvi)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_count_qs_donvi", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@donvi_id", donvi);

            conn.Open();
            int total = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return total;
        }
        public static DataTable loadbqs(int donvi, int page, int pagesize)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_getbqs", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@donvi_id", donvi);
            cmd.Parameters.AddWithValue("@Page", page);
            cmd.Parameters.AddWithValue("@PageSize", pagesize);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                conn.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static DataTable loadbqs(int donvi, string tukhoa, int page, int pagesize)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_getbqs", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@donvi_id", donvi);
            cmd.Parameters.AddWithValue("@tukhoa", tukhoa);
            cmd.Parameters.AddWithValue("@page", page);
            cmd.Parameters.AddWithValue("@pagesize", pagesize);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                conn.Open();
                da.Fill(dt);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        public static int CountBQS(int donvi, string tukhoa)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_count_bqs", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@donvi_id", donvi);
            cmd.Parameters.AddWithValue("@tukhoa", tukhoa);

            conn.Open();
            int total = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return total;
        }

       
       
        //==================================================
        // LAY DS CAT COM HIEN TAI
        //==================================================
        public static List<int> LayDSCatComHienTai(
            DateTime ngay,
            int mabuoi,
            int madv)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd =
                new SqlCommand("sp_LayDSCatComHienTai", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@buoian", mabuoi);
            cmd.Parameters.AddWithValue("@donvi", madv);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            List<int> ds = new List<int>();

            foreach (DataRow row in dt.Rows)
            {
                ds.Add(Convert.ToInt32(row["quannhan_id"]));
            }

            return ds;
        }

        //==================================================
        // VO HIEU HOA PHIEN CU
        //==================================================
        public static void VoHieuHoaCatCom(
            DateTime ngay,
            int mabuoi,
            int madv)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd =
                new SqlCommand("sp_VoHieuHoaCatCom", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@buoian", mabuoi);
            cmd.Parameters.AddWithValue("@donvi", madv);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //==================================================
        // INSERT CAT COM
        //==================================================
        public static void InsertCatCom(catcom cc)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd =
                new SqlCommand("sp_InsertCatCom", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay",
                cc.ngay_thang_nam);

            cmd.Parameters.AddWithValue("@buoian",
                cc.buoian_id);

            cmd.Parameters.AddWithValue("@donvi",
                cc.donvi_id);

            cmd.Parameters.AddWithValue("@quannhan",
                cc.quannhan_id);

            cmd.Parameters.AddWithValue("@lydo",
                (object)cc.catcom_ly_do ?? DBNull.Value);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //==================================================
        // UPSERT QUAN SO AN
        //==================================================
        public static void UpsertQuanSoAn(quansoan qs)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd =
                new SqlCommand("sp_UpsertQuanSoAn", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ngay",
                qs.ngay_thang_nam);

            cmd.Parameters.AddWithValue("@buoian",
                qs.buoian_id);

            cmd.Parameters.AddWithValue("@donvi",
                qs.donvi_id);

            cmd.Parameters.AddWithValue("@chedo",
                qs.chedo_id);

            cmd.Parameters.AddWithValue("@soluong",
                qs.soluong);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        

        //==================================================
        // GHI KHOA SO
        //==================================================
        public static void KhoaSo(
            DateTime ngay,
            int madv,
            int nguoiKhoa,
            string lyDo)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            conn.Open();

            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                SqlCommand cmd1 =
                    new SqlCommand("sp_KhoaSoCatCom",
                        conn, tran);

                cmd1.CommandType =
                    CommandType.StoredProcedure;

                cmd1.Parameters.AddWithValue("@ngay", ngay);
                cmd1.Parameters.AddWithValue("@donvi", madv);

                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 =
                    new SqlCommand("sp_GhiKhoaSo",
                        conn, tran);

                cmd2.CommandType =
                    CommandType.StoredProcedure;

                cmd2.Parameters.AddWithValue("@ngay", ngay);
                cmd2.Parameters.AddWithValue("@donvi", madv);
                cmd2.Parameters.AddWithValue("@nguoi_khoa",
                    nguoiKhoa);
                cmd2.Parameters.AddWithValue("@ly_do",
                    lyDo);

                cmd2.ExecuteNonQuery();

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
  