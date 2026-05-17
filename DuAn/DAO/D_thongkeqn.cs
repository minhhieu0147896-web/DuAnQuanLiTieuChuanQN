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
    internal class D_thongkeqn
    {
        public static thongkecatcom thongke_thang(int quannhan_id, int thang, int nam)
        {
            thongkecatcom tk = new thongkecatcom();

            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_thongkecatcom_thang", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@quannhan_id", quannhan_id);
            cmd.Parameters.AddWithValue("@thang", thang);
            cmd.Parameters.AddWithValue("@nam", nam);

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                tk.tongbuoi = Convert.ToInt32(rd["tongbuoi"]);
                tk.sobuoian = Convert.ToInt32(rd["sobuoian"]);
                tk.sobuoikhongan = Convert.ToInt32(rd["sobuoikhongan"]);
                tk.tongtiencat = Convert.ToDouble(rd["tongtiencat"]);
            }

            rd.Close();
            conn.Close();

            return tk;
        }
        public static DataTable thongke_nam(int quannhan_id, int nam)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_thongke_nam", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@quannhan_id", quannhan_id);
            da.SelectCommand.Parameters.AddWithValue("@nam", nam);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
