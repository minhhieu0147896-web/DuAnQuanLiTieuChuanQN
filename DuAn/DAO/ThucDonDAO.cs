using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DTO;
using System.Data.SqlClient;
using System.Globalization;

namespace DuAn.DAO
{
    public class ThucDonDAO
    {
        private static ThucDonDAO instance;
        public static ThucDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThucDonDAO();
                return instance;
            }
            private set => instance = value;
        }
        private ThucDonDAO() { }

        // Lấy hoặc tạo mới thực đơn cho tuần/năm/chế độ
        public ThucDonModel GetOrCreate(int userId, int chedoId, DateTime ngay)
        {
            // Lấy tuần ISO và năm
            GregorianCalendar cal = new GregorianCalendar();
            int tuan = cal.GetWeekOfYear(ngay, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int nam = ngay.Year;

            // Kiểm tra xem đã có thực đơn chưa
            string query = @"SELECT thucdon_id, user_id, chedo_id, trang_thai, thucdon_tuan, thucdon_nam, ngay_thang_nam
                             FROM Thuc_don
                             WHERE thucdon_tuan = @tuan AND thucdon_nam = @nam AND chedo_id = @chedoId";
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuan", tuan);
                cmd.Parameters.AddWithValue("@nam", nam);
                cmd.Parameters.AddWithValue("@chedoId", chedoId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ThucDonModel
                        {
                            ThucDonId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            CheDoId = reader.GetInt32(2),
                            TrangThai = reader.GetString(3),
                            Tuan = reader.GetByte(4),
                            Nam = reader.GetInt16(5),
                            NgayLap = reader.GetDateTime(6)
                        };
                    }
                }
            }

            // Chưa có thì tạo mới
            int newId = GenerateNewId("Thuc_don", "thucdon_id");
            string insert = @"INSERT INTO Thuc_don (thucdon_id, user_id, chedo_id, trang_thai, thucdon_tuan, thucdon_nam, ngay_thang_nam)
                              VALUES (@id, @userId, @chedoId, N'NhapLieu', @tuan, @nam, @ngayLap)";
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@id", newId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@chedoId", chedoId);
                cmd.Parameters.AddWithValue("@tuan", tuan);
                cmd.Parameters.AddWithValue("@nam", nam);
                cmd.Parameters.AddWithValue("@ngayLap", ngay.Date);
                cmd.ExecuteNonQuery();
            }

            return new ThucDonModel
            {
                ThucDonId = newId,
                UserId = userId,
                CheDoId = chedoId,
                TrangThai = "NhapLieu",
                Tuan = tuan,
                Nam = nam,
                NgayLap = ngay.Date
            };
        }

        private int GenerateNewId(string table, string column)
        {
            string query = $"SELECT ISNULL(MAX({column}), 0) + 1 FROM {table}";
            return Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
        }

        // Trong ThucDonDAO.cs
        public bool UpdateTrangThai(int thucdonId, string trangThaiMoi)
        {
            string query = "UPDATE Thuc_don SET trang_thai = @trangThai WHERE thucdon_id = @id";
            int rows = DataProvider.Instance.ExecuteNonQuery(query,
                new SqlParameter("@trangThai", trangThaiMoi),
                new SqlParameter("@id", thucdonId));
            return rows > 0;
        }
    }
}