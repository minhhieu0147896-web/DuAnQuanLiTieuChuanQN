using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    public class MonAnDAO
    {
        private static MonAnDAO instance;
        public static MonAnDAO Instance
        {
            get { instance = new MonAnDAO(); return instance; }
            private set => instance = value;
        }
        private MonAnDAO() { }

        // Lấy danh sách Loại món (chuỗi) duy nhất
        public List<string> GetAllLoaiMon()
        {
            List<string> list = new List<string>();
            string query = "SELECT DISTINCT monan_loaimon FROM Mon_an WHERE monan_loaimon IS NOT NULL ORDER BY monan_loaimon";
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(reader.GetString(0));
                }
            }
            return list;
        }

        // Lấy món ăn theo Loại món (chuỗi)
        public List<MonAnModel> GetByLoaiMon(string loaiMon)
        {
            List<MonAnModel> list = new List<MonAnModel>();
            string query = "SELECT monan_id, monan_loaimon, monan_ten FROM Mon_an WHERE monan_loaimon = @LoaiMon ORDER BY monan_ten";
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoaiMon", loaiMon);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MonAnModel
                        {
                            MonAnId = reader.GetInt32(0),
                            LoaiMon = reader.GetString(1),
                            TenMon = reader.GetString(2)  // Nếu cột thứ 3 là monan_ten
                        });
                    }
                }
            }
            return list;
        }
    }
}
