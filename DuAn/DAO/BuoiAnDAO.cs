using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DTO;

namespace DuAn.DAO
{
    public class BuoiAnDAO
    {
        private static BuoiAnDAO instance;
        public static BuoiAnDAO Instance
        {
            get { instance = new BuoiAnDAO(); return instance; }
            private set => instance = value;
        }
        private BuoiAnDAO() { }

        /// <summary>
        /// Lấy danh sách tất cả bữa ăn từ DB
        /// </summary>
        public List<BuoiAnModel> GetAll()
        {
            List<BuoiAnModel> list = new List<BuoiAnModel>();

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_BuoiAn_DanhSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new BuoiAnModel
                    {
                        BuoiAnId = Convert.ToInt32(row["buoian_id"]),
                        TenBuoi = row["buoian_ten"].ToString(),
                        TyLeTienAn = Convert.ToDecimal(row["buoian_tletienan"])
                    });
                }
            }

            return list;
        }
    }
}
