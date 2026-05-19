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
            string query = @"SELECT monan_id, monan_loaimon, monan_ten,
                                    ISNULL(dam, 0) AS dam,
                                    ISNULL(chat_xo, 0) AS chat_xo,
                                    ISNULL(chat_beo, 0) AS chat_beo
                             FROM Mon_an
                             WHERE monan_loaimon = @LoaiMon
                             ORDER BY monan_ten";
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@LoaiMon", loaiMon);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapMonAn(reader));
                    }
                }
            }
            return list;
        }

        public List<MonAnModel> GetByNhomLoaiMon(string nhomLoaiMon, string ghiChu = null)
        {
            List<MonAnModel> list = new List<MonAnModel>();
            string query = @"SELECT monan_id, monan_loaimon, monan_ten,
                                    ISNULL(dam, 0) AS dam,
                                    ISNULL(chat_xo, 0) AS chat_xo,
                                    ISNULL(chat_beo, 0) AS chat_beo
                             FROM Mon_an
                             WHERE monan_loaimon IS NOT NULL
                               AND (@GhiChu IS NULL OR UPPER(LTRIM(RTRIM(ISNULL(ghi_chu, '')))) = UPPER(@GhiChu))
                             ORDER BY monan_loaimon, monan_ten";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string loaiMon = reader["monan_loaimon"].ToString();
                            if (!IsSameDishGroup(loaiMon, nhomLoaiMon))
                                continue;

                            list.Add(MapMonAn(reader));
                        }
                    }
                }
            }

            return list;
        }

        public MonAnModel GetOrCreateSua()
        {
            const string findQuery = @"SELECT TOP 1 monan_id, monan_loaimon, monan_ten,
                                              ISNULL(dam, 0) AS dam,
                                              ISNULL(chat_xo, 0) AS chat_xo,
                                              ISNULL(chat_beo, 0) AS chat_beo
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
                        return MapMonAn(reader);
                    }
                }
            }

            int newId = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT ISNULL(MAX(monan_id), 0) + 1 FROM Mon_an"));
            const string insertQuery = @"INSERT INTO Mon_an (monan_id, monan_ten, monan_loaimon, ghi_chu, dam, chat_beo, chat_xo)
                                         VALUES (@id, N'Sữa', N'Sua', N'Tự động cho chế độ Học viên', 6, 6, 0)";

            DataProvider.Instance.ExecuteNonQuery(insertQuery, new SqlParameter("@id", newId));

            return new MonAnModel
            {
                MonAnId = newId,
                LoaiMon = "Sua",
                TenMon = "Sữa",
                Dam = 6,
                ChatBeo = 6,
                ChatXo = 0
            };
        }

        public NutritionTargetModel GetWeeklyNutritionTarget(int cheDoId)
        {
            const string query = @"
SELECT
    ISNULL(SUM(so_luong * 8.0 *
        CASE UPPER(LTRIM(RTRIM(nhom_thucpham)))
            WHEN 'TINH BOT' THEN 7.0
            WHEN 'THIT' THEN 20.0
            WHEN 'CA' THEN 19.0
            WHEN 'TRUNG' THEN 13.0
            WHEN 'DAU' THEN 8.0
            WHEN 'RAU' THEN 2.0
            WHEN 'TRAI CAY' THEN 0.8
            WHEN 'SUA' THEN 3.2
            ELSE 0.0
        END / 100.0), 0) AS dam,
    ISNULL(SUM(so_luong * 8.0 *
        CASE UPPER(LTRIM(RTRIM(nhom_thucpham)))
            WHEN 'TINH BOT' THEN 1.3
            WHEN 'DAU' THEN 1.0
            WHEN 'RAU' THEN 2.5
            WHEN 'TRAI CAY' THEN 1.8
            ELSE 0.0
        END / 100.0), 0) AS chat_xo,
    ISNULL(SUM(so_luong * 8.0 *
        CASE UPPER(LTRIM(RTRIM(nhom_thucpham)))
            WHEN 'TINH BOT' THEN 0.6
            WHEN 'THIT' THEN 12.0
            WHEN 'CA' THEN 5.0
            WHEN 'TRUNG' THEN 11.0
            WHEN 'DAU' THEN 4.0
            WHEN 'RAU' THEN 0.2
            WHEN 'TRAI CAY' THEN 0.2
            WHEN 'SUA' THEN 3.5
            ELSE 0.0
        END / 100.0), 0) AS chat_beo
FROM Dinh_luong_che_do_chuan
WHERE chedo_id = @cheDoId";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cheDoId", cheDoId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new NutritionTargetModel
                            {
                                Dam = ToDouble(reader["dam"]),
                                ChatXo = ToDouble(reader["chat_xo"]),
                                ChatBeo = ToDouble(reader["chat_beo"])
                            };
                        }
                    }
                }
            }

            return new NutritionTargetModel();
        }

        private static MonAnModel MapMonAn(SqlDataReader reader)
        {
            return new MonAnModel
            {
                MonAnId = Convert.ToInt32(reader["monan_id"]),
                LoaiMon = reader["monan_loaimon"].ToString(),
                TenMon = reader["monan_ten"].ToString(),
                Dam = ToDouble(reader["dam"]),
                ChatXo = ToDouble(reader["chat_xo"]),
                ChatBeo = ToDouble(reader["chat_beo"])
            };
        }

        private static double ToDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        private static bool IsSameDishGroup(string dbLoaiMon, string nhomLoaiMon)
        {
            string db = NormalizeText(dbLoaiMon);
            string requested = NormalizeText(nhomLoaiMon);
            string dbCompact = db.Replace(" ", string.Empty);
            string requestedCompact = requested.Replace(" ", string.Empty);

            if (requested == "man" || requestedCompact == "manchinh")
                return dbCompact == "manchinh" || db == "man" || db.Contains("man chinh");

            if (db == requested || dbCompact == requestedCompact || db.Contains(requested) || requested.Contains(db))
                return true;

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
