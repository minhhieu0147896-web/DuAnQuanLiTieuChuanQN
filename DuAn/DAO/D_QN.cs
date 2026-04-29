
using DuAn.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DuAn.DAO
{
    public class D_QN
    {
        public static DataTable getQN()
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_getallqn",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt= new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void insertqn(DuAn.DTO.quannhan qn)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            SqlCommand cmd = new SqlCommand("sp_insertqn", conn);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.Add("quannhan_hoten", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("donvi_id", SqlDbType.Int);
            cmd.Parameters.Add("chedo_id", SqlDbType.Int);
            cmd.Parameters["quannhan_hoten"].Value = qn.Quannhan_ten1;
            cmd.Parameters["donvi_id"].Value = qn.Donvi_id1;
            cmd.Parameters["chedo_id"].Value = qn.Chedo_id1;
            conn.Open();                 // MỞ KẾT NỐI
            cmd.ExecuteNonQuery();       // CHẠY INSERT
            conn.Close();                // ĐÓNG
        }
        public DataTable GetAllCheDo()
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlDataAdapter da =
                new SqlDataAdapter("sp_getallchedo", conn);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable GetAllDonVi()
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlDataAdapter da =
                new SqlDataAdapter("sp_getalldonvi", conn);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public static void UpdateQN(DuAn.DTO.quannhan qn)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_updateqn", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@quannhan_id", qn.Quannhan_id1);
            cmd.Parameters.AddWithValue("@quannhan_hoten", qn.Quannhan_ten1);
            cmd.Parameters.AddWithValue("@donvi_id", qn.Donvi_id1);
            cmd.Parameters.AddWithValue("@chedo_id", qn.Chedo_id1);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void DeleteQN(int id)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_deleteqn", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@quannhan_id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}
