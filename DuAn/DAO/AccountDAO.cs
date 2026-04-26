using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string query = @"SELECT user_id, user_taikhoan, user_vai_tro
                     FROM   [dbo].[User]
                     WHERE  user_taikhoan = @username
                       AND  user_mat_khau = @password";

            SqlParameter[] parameters =
            {
        new SqlParameter("@username", username),
        new SqlParameter("@password", password)
    };

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                return new AccountModel
                {
                    MaTK = Convert.ToInt32(row["user_id"]),
                    TenDangNhap = row["user_taikhoan"].ToString(),
                    VaiTro = Convert.ToInt32(row["user_vai_tro"])
                };
            }

            return null;
        }


    }
}




