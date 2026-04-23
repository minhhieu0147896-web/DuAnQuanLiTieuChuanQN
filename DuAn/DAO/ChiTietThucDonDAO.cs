using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DTO;
using System.Data.SqlClient;

namespace DuAn.DAO
{
    public class ChiTietThucDonDAO
    {
        private static ChiTietThucDonDAO instance;
        public static ChiTietThucDonDAO Instance
        {
            get { instance = new ChiTietThucDonDAO(); return instance; }
            private set => instance = value;
        }
        private ChiTietThucDonDAO() { }

        // Lấy danh sách chi tiết theo thực đơn, ngày, buổi
        public List<ChiTietThucDonModel> GetByThucDonNgayBuoi(int thucdonId, DateTime ngay, int buoianId)
        {
            List<ChiTietThucDonModel> list = new List<ChiTietThucDonModel>();
            string query = @"SELECT ctd.thucdon_id, ctd.ngay_thang_nam, ctd.buoian_id, ctd.monan_id,
                            m.monan_ten, m.monan_loaimon, b.buoian_ten
                     FROM Chi_tiet_thuc_don ctd
                     INNER JOIN Mon_an m ON ctd.monan_id = m.monan_id
                     INNER JOIN Buoi_an b ON ctd.buoian_id = b.buoian_id
                     WHERE ctd.thucdon_id = @thucdonId 
                       AND ctd.ngay_thang_nam = @ngay 
                       AND ctd.buoian_id = @buoianId
                     ORDER BY m.monan_loaimon, m.monan_ten";  // Có thể sắp xếp theo loại món
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@thucdonId", thucdonId);
                cmd.Parameters.AddWithValue("@ngay", ngay.Date);
                cmd.Parameters.AddWithValue("@buoianId", buoianId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChiTietThucDonModel
                        {
                            ThucDonId = reader.GetInt32(0),
                            Ngay = reader.GetDateTime(1),
                            BuoiAnId = reader.GetInt32(2),
                            MonAnId = reader.GetInt32(3),
                            TenMon = reader.GetString(4),
                            LoaiMon = reader.GetString(5),
                            TenBuoi = reader.GetString(6)
                        });
                    }
                }
            }
            return list;
        }

        // Thêm mới một chi tiết
        public bool Insert(int thucdonId, DateTime ngay, int buoianId, int monanId)
        {
            // Kiểm tra trùng lặp
            string check = @"SELECT COUNT(*) FROM Chi_tiet_thuc_don 
                     WHERE thucdon_id = @thucdonId 
                       AND ngay_thang_nam = @ngay 
                       AND buoian_id = @buoianId 
                       AND monan_id = @monanId";
            object result = DataProvider.Instance.ExecuteScalar(check,
                new SqlParameter("@thucdonId", thucdonId),
                new SqlParameter("@ngay", ngay.Date),
                new SqlParameter("@buoianId", buoianId),
                new SqlParameter("@monanId", monanId));
            if (Convert.ToInt32(result) > 0)
                return false; // Đã tồn tại

            // Thêm mới
            string insert = @"INSERT INTO Chi_tiet_thuc_don (thucdon_id, ngay_thang_nam, buoian_id, monan_id)
                      VALUES (@thucdonId, @ngay, @buoianId, @monanId)";
            int rows = DataProvider.Instance.ExecuteNonQuery(insert,
                new SqlParameter("@thucdonId", thucdonId),
                new SqlParameter("@ngay", ngay.Date),
                new SqlParameter("@buoianId", buoianId),
                new SqlParameter("@monanId", monanId));
            return rows > 0;
        }

        public bool Delete(int thucdonId, DateTime ngay, int buoianId, int monanId)
        {
            string delete = @"DELETE FROM Chi_tiet_thuc_don 
                      WHERE thucdon_id = @thucdonId 
                        AND ngay_thang_nam = @ngay 
                        AND buoian_id = @buoianId 
                        AND monan_id = @monanId";
            int rows = DataProvider.Instance.ExecuteNonQuery(delete,
                new SqlParameter("@thucdonId", thucdonId),
                new SqlParameter("@ngay", ngay.Date),
                new SqlParameter("@buoianId", buoianId),
                new SqlParameter("@monanId", monanId));
            return rows > 0;
        }
    }
}
