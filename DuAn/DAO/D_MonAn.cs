using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DuAn.DAO
{
    internal class D_MonAn
    {
        /// <summary>
        /// Lấy mã món ăn tiếp theo (MAX + 1)
        /// </summary>
        public static int LayMaMoi()
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_LayMaMoi", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 1;
            }
        }

        /// <summary>
        /// Thêm món ăn mới vào bảng Mon_an. 
        /// Ném exception nếu thất bại, không thì coi như thành công.
        /// </summary>
        public static void ThemMonAn(int monanId, string tenMon, string loaiMon,
            string ghiChu, double? dam, double? chatBeo, double? chatXo)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_Them", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@monan_id", monanId);
                cmd.Parameters.AddWithValue("@monan_ten", tenMon);
                cmd.Parameters.AddWithValue("@monan_loaimon", loaiMon);
                cmd.Parameters.AddWithValue("@ghi_chu", (object)ghiChu ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@dam", (object)dam ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@chat_beo", (object)chatBeo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@chat_xo", (object)chatXo ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                // Không check giá trị trả về — nếu có lỗi sẽ throw exception
            }
        }

        /// <summary>
        /// Thêm một dòng chi tiết nguyên liệu vào Chi_tiet_mon_an.
        /// Ném exception nếu thất bại.
        /// </summary>
        public static void ThemChiTietMonAn(int monanId, int thucPhamId, int cheDoId, decimal? tyLe)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ChiTietMonAn_Them", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@monan_id", monanId);
                cmd.Parameters.AddWithValue("@thucpham_id", thucPhamId);
                cmd.Parameters.AddWithValue("@chedo_id", cheDoId);
                cmd.Parameters.AddWithValue("@ty_le", (object)tyLe ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                // Không check giá trị trả về — nếu có lỗi sẽ throw exception
            }
        }

        /// <summary>
        /// Lấy danh sách nguyên liệu của một món ăn theo chế độ ăn
        /// </summary>
        public static DataTable LayNguyenLieu(int monAnId, int cheDoId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_LayNguyenLieu", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@monan_id", monAnId);
                cmd.Parameters.AddWithValue("@chedo_id", cheDoId);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lấy danh sách thực phẩm cho ComboBox
        /// </summary>
        public static DataTable LayDanhSachThucPham()
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ThucPham_DanhSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lấy danh sách chế độ cho ComboBox
        /// </summary>
        public static DataTable LayDanhSachCheDo()
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_CheDo_DanhSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }
    }
}
