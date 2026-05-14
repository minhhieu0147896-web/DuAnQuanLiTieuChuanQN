using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
            get
            {
                if (instance == null)
                    instance = new MonAnDAO();
                return instance;
            }
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

        public List<MonAnModel> GetByNhomLoaiMon(string nhomLoaiMon)
        {
            List<MonAnModel> list = new List<MonAnModel>();
            string query = "SELECT monan_id, monan_loaimon, monan_ten FROM Mon_an WHERE monan_loaimon IS NOT NULL ORDER BY monan_loaimon, monan_ten";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string loaiMon = reader["monan_loaimon"].ToString();
                        if (!IsSameDishGroup(loaiMon, nhomLoaiMon))
                            continue;

                        list.Add(new MonAnModel
                        {
                            MonAnId = Convert.ToInt32(reader["monan_id"]),
                            LoaiMon = loaiMon,
                            TenMon = reader["monan_ten"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        private static bool IsSameDishGroup(string dbLoaiMon, string nhomLoaiMon)
        {
            string db = NormalizeText(dbLoaiMon);
            string requested = NormalizeText(nhomLoaiMon);

            if (db == requested || db.Contains(requested) || requested.Contains(db))
                return true;

            if (requested == "man")
                return db.Contains("man") || db.Contains("chinh") || db.Contains("thit") || db.Contains("ca");

            if (requested == "canh")
                return db.Contains("canh") || db.Contains("sup") || db.Contains("soup");

            if (requested == "rau")
                return db.Contains("rau") || db.Contains("xao") || db.Contains("luoc");

            return false;
        }

        private static string NormalizeText(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            string formD = value.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            foreach (char c in formD)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }

            return builder.ToString()
                .Replace("đ", "d")
                .Normalize(NormalizationForm.FormC);
        }
    }
}
