using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DuAn.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private AccountDAO() { }
        // Đổi return type từ bool → AccountModel để lấy được VaiTro
        public AccountModel Login(string username, string password)
        {
            string query = @"SELECT user_id, user_taikhoan, user_vai_tro, user_mat_khau
                             FROM   [dbo].[User]
                             WHERE  user_taikhoan = @username
                               AND  mat_khau     = @password";
                             

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new AccountModel
                            {
                                MaTK = (int)reader["tai_khoan_id"],
                                TenDangNhap = reader["ten_dang_nhap"].ToString(),
                                VaiTro = (int)reader["vai_tro"],
                                HoTen = reader["ho_ten"].ToString(),
                                // Đọc thêm daidoi_id (Kiểm tra DBNull nếu cột này Allow Nulls, nếu không thì ép kiểu trực tiếp)
                                DaiDoiId = reader["daidoi_id"] != DBNull.Value ? (int)reader["daidoi_id"] : 0
                            };
                        }
                    }
                }
            }
            return null;

        }

    }
}




