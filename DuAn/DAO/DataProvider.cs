//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DuAn.DAO
//{
//    internal class DataProvider
//    {
//        // Bước 1: Biến lưu instance duy nhất
//        private static DataProvider _instance;

//        // Bước 2: Property để truy cập instance từ bên ngoài
//        public static DataProvider Instance
//        {
//            get
//            {
//                if (_instance == null)
//                    _instance = new DataProvider();
//                return _instance;
//            }
//        }

//        // Bước 3: Constructor private - khóa không cho tạo bằng "new" từ bên ngoài
//        private DataProvider() { }

//        private string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=QuanLyTieuChuanQuanNhan;Integrated Security=True;Encrypt=False";
//        public DataTable ExecuteQuery(string query)
//        {
//            DataTable data = new DataTable();
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand(query, connection);


//                SqlDataAdapter adapter = new SqlDataAdapter(command);
//                adapter.Fill(data);
//                connection.Close();
//            }
//            return data;
//        }

//        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
//        {
//            int rowsAffected = 0;

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    conn.Open();

//                    SqlCommand cmd = new SqlCommand(query, conn);

//                    if (parameters != null && parameters.Length > 0)
//                        cmd.Parameters.AddRange(parameters);

//                    rowsAffected = cmd.ExecuteNonQuery();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi",
//                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }

//            return rowsAffected;
//        }

//        public object ExecuteScalar(string query, params SqlParameter[] parameters)
//        {
//            object result = null;

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    conn.Open();

//                    SqlCommand cmd = new SqlCommand(query, conn);

//                    if (parameters != null && parameters.Length > 0)
//                        cmd.Parameters.AddRange(parameters);

//                    result = cmd.ExecuteScalar();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi",
//                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }

//            return result;
//        }

//        public SqlConnection GetConnection()
//        {
//            return new SqlConnection(connectionString);
//        }
//    }
//}
using System;
using System.Data;
using System.Data.SqlClient;
namespace DuAn.DAO
{
    internal class DataProvider
    {
        // Pattern Singleton
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }
        }
        private DataProvider() { }

        // ★ Sửa chuỗi kết nối theo SQL Server của bạn
        private string connectionString =
          "Data Source=.\\SQLEXPRESS;" +
          "Initial Catalog=QuanLiTieuChuanQN;" +
          "Integrated Security=True;";

        private SqlConnection GetConnection()
          => new SqlConnection(connectionString);

        // Dùng cho SELECT
        public DataTable ExecuteQuery(string query,
                                       SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        // Dùng cho INSERT / UPDATE / DELETE
        public int ExecuteNonQuery(string query,
                                    SqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // Dùng cho COUNT / SUM / giá trị đơn
        public object ExecuteScalar(string query,
                                     SqlParameter[] parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
    }
}
