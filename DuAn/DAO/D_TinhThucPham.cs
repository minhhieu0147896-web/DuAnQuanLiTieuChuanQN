using System;
using System.Data;
using System.Data.SqlClient;

namespace DuAn.DAO
{
    /// <summary>
    /// DAO tính toán thực phẩm cần sử dụng theo ngày / buổi / đơn vị
    /// </summary>
    internal class D_TinhThucPham
    {
        /// <summary>
        /// Gọi stored procedure sp_TinhThucPham_CanSuDung
        /// Trả về DataTable gồm: TenThucPham, DonViTinh, TongSoLuong, TongTien
        /// </summary>
        public static DataTable TinhThucPham(DateTime ngay, int? buoianId, int donviId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_TinhThucPham_CanSuDung", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ngay", ngay.Date);
                cmd.Parameters.AddWithValue("@buoian_id", (object)buoianId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@donvi_id", donviId);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }
    }
}
