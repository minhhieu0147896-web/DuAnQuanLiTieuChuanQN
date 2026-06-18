using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Lấy danh sách Loại món (chuỗi) duy nhất từ DB
        /// </summary>
        public List<string> GetAllLoaiMon()
        {
            List<string> list = new List<string>();
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_MonAn_LayLoaiMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(reader.GetString(0));
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy danh sách món ăn theo Loại món
        /// </summary>
        public List<MonAnModel> GetByLoaiMon(string loaiMon)
        {
            List<MonAnModel> list = new List<MonAnModel>();
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_MonAn_LayTheoLoaiMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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

        /// <summary>
        /// Lấy danh sách món ăn theo nhóm loại món.
        /// Bước 1: Lọc theo ghi_chú trong DB.
        /// Bước 2: Lọc tiếp trong C# bằng IsSameDishGroup() để khớp tên nhóm.
        /// </summary>
        public List<MonAnModel> GetByNhomLoaiMon(string nhomLoaiMon, string ghiChu = null)
        {
            List<MonAnModel> list = new List<MonAnModel>();

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_MonAn_LayTheoGhiChu", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GhiChu",
                        string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string loaiMon = reader["monan_loaimon"].ToString();
                            // Lọc lần 2 trong C# để so khớp nhóm (chuẩn hóa tiếng Việt)
                            if (!IsSameDishGroup(loaiMon, nhomLoaiMon))
                                continue;

                            list.Add(MapMonAn(reader));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Tìm hoặc tự tạo món Sữa trong DB nếu chưa có.
        /// Dùng cho chế độ Học viên (cần sữa trong thực đơn).
        /// </summary>
        public MonAnModel GetOrCreateSua()
        {
            // Bước 1: Tìm món Sữa đã có trong DB chưa
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_MonAn_TimSua", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapMonAn(reader);
                        }
                    }
                }
            }

            // Bước 2: Chưa có thì tạo mới
            // Lấy mã món tiếp theo (dùng SP có sẵn)
            int newId;
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_MonAn_LayMaMoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                newId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // Thêm món Sữa vào DB (dùng SP có sẵn)
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_MonAn_Them", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@monan_id", newId);
                cmd.Parameters.AddWithValue("@monan_ten", "Sữa");
                cmd.Parameters.AddWithValue("@monan_loaimon", "Sua");
                cmd.Parameters.AddWithValue("@ghi_chu", "Tự động cho chế độ Học viên");
                cmd.Parameters.AddWithValue("@dam", 6);
                cmd.Parameters.AddWithValue("@chat_beo", 6);
                cmd.Parameters.AddWithValue("@chat_xo", 0);
                cmd.ExecuteNonQuery();
            }

            // Trả về model tương ứng
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

        /// <summary>
        /// Tìm hoặc tự tạo món Cơm trắng trong DB nếu chưa có.
        /// Cơm trắng được tự động thêm vào tất cả các buổi (Sáng/Trưa/Tối).
        /// Dinh dưỡng 1 suất cơm (~200g cơm chín):
        ///   Đạm ~4g, Chất béo ~0.5g, Chất xơ ~0.5g
        /// </summary>
        public MonAnModel GetOrCreateCom()
        {
            // Bước 1: Tìm món Cơm trắng đã có trong DB chưa
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_MonAn_TimCom", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapMonAn(reader);
                        }
                    }
                }
            }

            // Bước 2: Chưa có thì tạo mới
            // Lấy mã món tiếp theo (dùng SP có sẵn)
            int newId;
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_MonAn_LayMaMoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                newId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // Thêm món Cơm trắng vào DB (dùng SP có sẵn)
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_MonAn_Them", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@monan_id", newId);
                cmd.Parameters.AddWithValue("@monan_ten", "Cơm trắng");
                cmd.Parameters.AddWithValue("@monan_loaimon", "Com");
                cmd.Parameters.AddWithValue("@ghi_chu", "Tự động thêm vào mọi buổi");
                cmd.Parameters.AddWithValue("@dam", 4);
                cmd.Parameters.AddWithValue("@chat_beo", 0.5);
                cmd.Parameters.AddWithValue("@chat_xo", 0.5);
                cmd.ExecuteNonQuery();
            }

            // Trả về model tương ứng
            return new MonAnModel
            {
                MonAnId = newId,
                LoaiMon = "Com",
                TenMon = "Cơm trắng",
                Dam = 4,
                ChatBeo = 0.5,
                ChatXo = 0.5
            };
        }

        /// <summary>
        /// Tính tổng dinh dưỡng mục tiêu trong 1 tuần của một chế độ ăn
        /// (dựa trên Dinh_luong_che_do_chuan)
        /// </summary>
        public NutritionTargetModel GetWeeklyNutritionTarget(int cheDoId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_MonAn_TinhDinhDuongTuan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CheDoId", cheDoId);
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

        /// <summary>
        /// Ánh xạ từ SqlDataReader sang MonAnModel
        /// </summary>
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

        /// <summary>
        /// Chuyển đổi giá trị object sang double an toàn (trả về 0 nếu NULL)
        /// </summary>
        private static double ToDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// So sánh tên nhóm loại món (VD: "Mặn chính", "Canh", "Rau"...)
        /// sau khi chuẩn hóa tiếng Việt (bỏ dấu, lowercase).
        /// Trả về true nếu cùng nhóm.
        /// </summary>
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

            if (requested == "com" || requestedCompact == "comtrang")
                return dbCompact.Contains("comtrang") || db.Contains("com trang") || db.Contains("cơm");

            return false;
        }

        /// <summary>
        /// Chuẩn hóa chuỗi tiếng Việt: bỏ dấu, lowercase, trim
        /// </summary>
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
