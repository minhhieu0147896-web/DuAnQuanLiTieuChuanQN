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
    internal class D_qnlogin
    {
        public static qnlogin GetQuanNhanByMa(int maqn)
        {
            qnlogin qn = null;

            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_getQuannhanByMa", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@quannhan_id", maqn);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                qn = new qnlogin();
                qn.quannhan_id = Convert.ToInt32(reader["quannhan_id"]);
                qn.quannhan_hoten = reader["quannhan_hoten"].ToString();
                qn.donvi_id = Convert.ToInt32(reader["donvi_id"]);
                qn.chedo_id = Convert.ToInt32(reader["chedo_id"]);
                qn.donvi_ten = reader["donvi_ten"].ToString();
                qn.chedo_ten = reader["chedo_ten"].ToString();
                qn.chedo_tienan = Convert.ToInt32(reader["chedo_tienan"]);
            }

            conn.Close();
            return qn;
        }
    }
}
