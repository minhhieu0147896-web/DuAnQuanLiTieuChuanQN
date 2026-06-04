using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using OfficeOpenXml.ConditionalFormatting.Contracts;


namespace DuAn.DAO
{
    internal class D_QuanSoAn
    {
        public static thongke_quansoan ThongKeQuanSoAn(int donvi_id, DateTime ngay)
        {
            thongke_quansoan tk = new thongke_quansoan();
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_thongke_quansoan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@donvi_id", donvi_id);
            cmd.Parameters.AddWithValue("@ngay", ngay);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                tk.TongQuanSo = Convert.ToInt32(rd["tong_qs"]);
                tk.DangKyAn = Convert.ToInt32(rd["dka"]);
                tk.DangKyKhongAn = Convert.ToInt32(rd["dkka"]);
                tk.TongDonVi = Convert.ToInt32(rd["tong_dv"]);
            }
            rd.Close();
            conn.Close();
            return tk;
        }
        public static DataTable QuanSoAnTheoDonVi(int donvi_id, DateTime ngay)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_quansoan_thedonvi", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@donvi_id", donvi_id);
            da.SelectCommand.Parameters.AddWithValue("@ngay", ngay);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
        public static DataTable ChiTietCatCom(int donvi_id, DateTime ngay)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_chitiet_catcom", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@donvi_id", donvi_id);
            da.SelectCommand.Parameters.AddWithValue("@ngay", ngay);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static int ChotSo(DateTime ngay, int donvi_id, int nguoi_khoa)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_chotso", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@donvi_id", donvi_id);
            cmd.Parameters.AddWithValue("@nguoi_khoa", nguoi_khoa);
            SqlDataReader rd = cmd.ExecuteReader();
            int kq = -1;
            if (rd.Read())
            {
                kq = Convert.ToInt32(rd["ket_qua"]);
            }
            rd.Close();
            conn.Close();
            return kq;

        }
        public static bool IsKhoaSo(DateTime ngay, int donvi_id)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_kiemtra_khoaso", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ngay", ngay.Date);
            cmd.Parameters.AddWithValue("@donvi_id", donvi_id);
            SqlDataReader rd = cmd.ExecuteReader();
            bool daKhoa = false;
            if (rd.Read()) daKhoa = Convert.ToInt32(rd["da_khoa"]) > 0;
            rd.Close();
            conn.Close();
            return daKhoa;
        }
    } 
}
