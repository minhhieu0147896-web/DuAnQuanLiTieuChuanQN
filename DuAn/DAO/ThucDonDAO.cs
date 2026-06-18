using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DTO;

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

        /// <summary>
        /// Lấy thực đơn đã có hoặc tạo mới nếu chưa tồn tại.
        /// Dựa trên tuần ISO + năm + chế độ ăn.
        /// </summary>
        public ThucDonModel GetOrCreate(int userId, int chedoId, DateTime ngay)
        {
            // Lấy tuần ISO và năm từ ngày
            GregorianCalendar cal = new GregorianCalendar();
            int tuan = cal.GetWeekOfYear(ngay, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            int nam = ngay.Year;

            // Bước 1: Kiểm tra xem đã có thực đơn cho tuần này chưa
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThucDon_TimTheoTuanNam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tuan", tuan);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@CheDoId", chedoId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Đã có thực đơn → trả về luôn
                        return new ThucDonModel
                        {
                            ThucDonId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            CheDoId = reader.GetInt32(2),
                            TrangThai = reader.GetString(3),
                            Tuan = Convert.ToInt32(reader["thucdon_tuan"]),
                            Nam = Convert.ToInt32(reader["thucdon_nam"]),
                            NgayLap = reader.GetDateTime(6)
                        };
                    }
                }
            }

            // Bước 2: Chưa có thì tạo thực đơn mới
            int newId = LayMaThucDonMoi();

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThucDon_Them", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", newId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@CheDoId", chedoId);
                cmd.Parameters.AddWithValue("@Tuan", tuan);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@NgayLap", ngay.Date);
                cmd.ExecuteNonQuery();
            }

            // Trả về thực đơn vừa tạo
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

        /// <summary>
        /// Lấy mã thực đơn tiếp theo (MAX(thucdon_id) + 1)
        /// </summary>
        private int LayMaThucDonMoi()
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThucDon_LayMaMoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái của thực đơn (VD: "NhapLieu" → "HoanThanh")
        /// Trả về true nếu cập nhật thành công ít nhất 1 dòng.
        /// </summary>
        public bool UpdateTrangThai(int thucdonId, string trangThaiMoi)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThucDon_CapNhatTrangThai", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", thucdonId);
                cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) > 0;
            }
        }

        /// <summary>
        /// Tìm thực đơn theo tuần, năm và chế độ ăn.
        /// Hàm này chỉ tìm, không tự tạo thực đơn mới.
        /// </summary>
        public ThucDonModel GetByTuanNamCheDo(int tuan, int nam, int chedoId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ThucDon_TimTheoTuanNam", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tuan", tuan);
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@CheDoId", chedoId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new ThucDonModel
                    {
                        ThucDonId = Convert.ToInt32(reader["thucdon_id"]),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        CheDoId = Convert.ToInt32(reader["chedo_id"]),
                        TrangThai = reader["trang_thai"].ToString(),
                        Tuan = Convert.ToInt32(reader["thucdon_tuan"]),
                        Nam = Convert.ToInt32(reader["thucdon_nam"]),
                        NgayLap = Convert.ToDateTime(reader["ngay_thang_nam"])
                    };
                }
            }
        }

        /// <summary>
        /// Duyệt thực đơn: đổi trạng thái sang DaDuyet.
        /// </summary>
        public bool DuyetThucDon(int thucdonId)
        {
            return UpdateTrangThai(thucdonId, "DaDuyet");
        }
    }
}
