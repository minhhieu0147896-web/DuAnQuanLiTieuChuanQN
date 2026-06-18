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
    public class ChiTietThucDonDAO
    {
        private static ChiTietThucDonDAO instance;
        public static ChiTietThucDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietThucDonDAO();
                return instance;
            }
            private set => instance = value;
        }
        private ChiTietThucDonDAO() { }

        /// <summary>
        /// Lấy danh sách chi tiết thực đơn theo thực đơn + ngày + buổi
        /// </summary>
        public List<ChiTietThucDonModel> GetByThucDonNgayBuoi(int thucdonId, DateTime ngay, int buoianId)
        {
            List<ChiTietThucDonModel> list = new List<ChiTietThucDonModel>();
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ChiTietThucDon_LayTheoNgayBuoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThucDonId", thucdonId);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);
                cmd.Parameters.AddWithValue("@BuoiAnId", buoianId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapChiTiet(reader));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy danh sách chi tiết thực đơn theo thực đơn + ngày (tất cả buổi)
        /// </summary>
        public List<ChiTietThucDonModel> GetByThucDonNgay(int thucdonId, DateTime ngay)
        {
            List<ChiTietThucDonModel> list = new List<ChiTietThucDonModel>();
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ChiTietThucDon_LayTheoNgay", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ThucDonId", thucdonId);
                    cmd.Parameters.AddWithValue("@Ngay", ngay.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(MapChiTiet(reader));
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Thêm một món vào chi tiết thực đơn.
        /// Trả về true nếu thêm thành công, false nếu đã tồn tại (trùng).
        /// </summary>
        public bool Insert(int thucdonId, DateTime ngay, int buoianId, int monanId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ChiTietThucDon_Them", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThucDonId", thucdonId);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);
                cmd.Parameters.AddWithValue("@BuoiAnId", buoianId);
                cmd.Parameters.AddWithValue("@MonAnId", monanId);

                // SP trả về SELECT 1 (thành công) hoặc SELECT 0 (trùng)
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) == 1;
            }
        }

        /// <summary>
        /// Xóa một món khỏi chi tiết thực đơn.
        /// Trả về true nếu xóa ít nhất 1 dòng.
        /// </summary>
        public bool Delete(int thucdonId, DateTime ngay, int buoianId, int monanId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ChiTietThucDon_Xoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThucDonId", thucdonId);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);
                cmd.Parameters.AddWithValue("@BuoiAnId", buoianId);
                cmd.Parameters.AddWithValue("@MonAnId", monanId);

                // SP trả về @@ROWCOUNT
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result) > 0;
            }
        }

        /// <summary>
        /// Xóa tất cả chi tiết theo thực đơn + ngày + buổi.
        /// Trả về số dòng đã xóa.
        /// </summary>
        public int DeleteByThucDonNgayBuoi(int thucdonId, DateTime ngay, int buoianId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ChiTietThucDon_XoaTheoNgayBuoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThucDonId", thucdonId);
                cmd.Parameters.AddWithValue("@Ngay", ngay.Date);
                cmd.Parameters.AddWithValue("@BuoiAnId", buoianId);

                // SP trả về @@ROWCOUNT
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        /// <summary>
        /// Ánh xạ từ SqlDataReader sang ChiTietThucDonModel
        /// </summary>
        private ChiTietThucDonModel MapChiTiet(SqlDataReader reader)
        {
            return new ChiTietThucDonModel
            {
                ThucDonId = Convert.ToInt32(reader["thucdon_id"]),
                Ngay = Convert.ToDateTime(reader["ngay_thang_nam"]),
                BuoiAnId = Convert.ToInt32(reader["buoian_id"]),
                MonAnId = Convert.ToInt32(reader["monan_id"]),
                TenMon = reader["monan_ten"].ToString(),
                LoaiMon = reader["monan_loaimon"].ToString(),
                TenBuoi = reader["buoian_ten"].ToString(),
                Dam = Convert.ToDouble(reader["dam"]),
                ChatXo = Convert.ToDouble(reader["chat_xo"]),
                ChatBeo = Convert.ToDouble(reader["chat_beo"])
            };
        }
    }
}
