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

        /// <summary>
        /// Lấy danh sách tất cả món ăn
        /// </summary>
        public static DataTable LayDanhSachMonAn()
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_DanhSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Tìm món ăn theo từ khóa (tên hoặc loại món)
        /// </summary>
        public static DataTable TimKiemMonAn(string tuKhoa)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_TimKiem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tukhoa", tuKhoa);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Lấy thông tin 1 món ăn + danh sách nguyên liệu theo ID.
        /// Trả về DataSet: Tables[0] = thông tin món, Tables[1] = nguyên liệu.
        /// </summary>
        public static DataSet LayMonAnTheoId(int monanId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_LayTheoId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@monan_id", monanId);

                DataSet ds = new DataSet();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(ds);
                return ds;
            }
        }

        /// <summary>
        /// Cập nhật thông tin món ăn (xóa nguyên liệu cũ để thêm lại sau)
        /// </summary>
        public static void CapNhatMonAn(int monanId, string tenMon, string loaiMon,
            string ghiChu, double? dam, double? chatBeo, double? chatXo)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_CapNhat", conn);
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
            }
        }

        /// <summary>
        /// Xóa món ăn và tất cả nguyên liệu liên quan.
        /// Trả về true nếu xóa thành công.
        /// </summary>
        public static bool XoaMonAn(int monanId)
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_MonAn_Xoa", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@monan_id", monanId);

                conn.Open();
                int ketQua = Convert.ToInt32(cmd.ExecuteScalar());
                return ketQua == 1;
            }
        }
    }
}
