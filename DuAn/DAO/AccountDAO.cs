using System;
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

        public AccountModel Login(string username, string password)
        {

            string query = @"SELECT user_id, user_taikhoan, user_vai_tro, user_mat_khau, donvi_id

                             FROM   [dbo].[User]
                             WHERE  user_taikhoan = @username
                               AND  user_mat_khau = @password";

   

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new AccountModel
                        {
                            MaTK = Convert.ToInt32(reader["user_id"]),
                            TenDangNhap = reader["user_taikhoan"].ToString(),
                            VaiTro = Convert.ToInt32(reader["user_vai_tro"]),
                            DonViId = reader["donvi_id"] == DBNull.Value
                                ? (int?)null
                                : Convert.ToInt32(reader["donvi_id"])
                        };
                    }
                }
            }
        }
    }
}
