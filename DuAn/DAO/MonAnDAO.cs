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

        public MonAnModel GetOrCreateSua()
        {
            const string findQuery = @"SELECT TOP 1 monan_id, monan_loaimon, monan_ten
                                       FROM Mon_an
                                       WHERE monan_loaimon = N'Sua'
                                          OR monan_ten = N'Sữa'
                                          OR monan_ten = N'Sua'
                                       ORDER BY monan_id";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(findQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MonAnModel
                        {
                            MonAnId = reader.GetInt32(0),
                            LoaiMon = reader.GetString(1),
                            TenMon = reader.GetString(2)
                        };
                    }
                }
            }

            int newId = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT ISNULL(MAX(monan_id), 0) + 1 FROM Mon_an"));
            const string insertQuery = @"INSERT INTO Mon_an (monan_id, monan_ten, monan_loaimon, ghi_chu)
                                         VALUES (@id, N'Sữa', N'Sua', N'Tự động cho chế độ Học viên')";

            DataProvider.Instance.ExecuteNonQuery(insertQuery, new SqlParameter("@id", newId));

            return new MonAnModel
            {
                MonAnId = newId,
                LoaiMon = "Sua",
                TenMon = "Sữa"
            };
        }

        private static bool IsSameDishGroup(string dbLoaiMon, string nhomLoaiMon)
        {
            string db = NormalizeText(dbLoaiMon);
            string requested = NormalizeText(nhomLoaiMon);
            string dbCompact = db.Replace(" ", string.Empty);
            string requestedCompact = requested.Replace(" ", string.Empty);

            if (db == requested || dbCompact == requestedCompact || db.Contains(requested) || requested.Contains(db))
                return true;

            if (requested == "man")
                return db.Contains("man") || db.Contains("chinh") || db.Contains("thit") || db.Contains("ca");

            if (requested == "canh")
                return db.Contains("canh") || db.Contains("sup") || db.Contains("soup");

            if (requested == "rau")
                return db.Contains("rau") || db.Contains("xao") || db.Contains("luoc");

            if (requestedCompact == "trangmieng")
                return dbCompact.Contains("trangmieng")
                    || db.Contains("trang mieng")
                    || dbCompact.Contains("traicay")
                    || db.Contains("trai cay")
                    || dbCompact.Contains("hoaqua")
                    || db.Contains("hoa qua")
                    || db.Contains("dua hau")
                    || db.Contains("chuoi")
                    || db.Contains("cam");

            if (requestedCompact == "suahop")
                return dbCompact.Contains("suahop") || db.Contains("sua") || db.Contains("milk");

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
