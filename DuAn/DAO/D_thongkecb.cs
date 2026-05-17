using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class D_thongkecb
    {
        public static thongke_tongquan thongke_tongquan(int donvi_id, DateTime ngay)
        {
            thongke_tongquan tk = new thongke_tongquan();
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_thongke_tongquan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@donvi_id", donvi_id);
            cmd.Parameters.AddWithValue("@ngay", ngay);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                tk.TongQuanSo = Convert.ToInt32(rd["tong_quanso"]);
                tk.AnSang = Convert.ToInt32(rd["an_sang"]);
                tk.KhongAnSang = Convert.ToInt32(rd["khong_an_sang"]);
                tk.AnTrua = Convert.ToInt32(rd["an_trua"]);
                tk.KhongAnTrua = Convert.ToInt32(rd["khong_an_trua"]);
                tk.AnChieu = Convert.ToInt32(rd["an_chieu"]);
                tk.KhongAnChieu = Convert.ToInt32(rd["khong_an_chieu"]);
            }

            rd.Close();
            conn.Close();
            return tk;
        }
        public static DataTable ds_catcom_theongay(int donvi_id, DateTime ngay)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_ds_catcom_theongay", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@donvi_id", donvi_id);
            da.SelectCommand.Parameters.AddWithValue("@ngay", ngay);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
