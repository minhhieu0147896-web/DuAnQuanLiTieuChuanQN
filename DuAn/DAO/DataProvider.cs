using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class DataProvider
    {
        private string connectionString = "Data Source=localhost\\ SQLEXPRESS;Initial Catalog=Quan_li_tieu_chuan_QN;Integrated Security=True;Encrypt=False";
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);


                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
    }
}
