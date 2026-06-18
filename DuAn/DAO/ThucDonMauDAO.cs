using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DuAn.DAO
{
    public class ThucDonMauDAO
    {
        private static ThucDonMauDAO instance;

        public static ThucDonMauDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThucDonMauDAO();
                return instance;
            }
            private set => instance = value;
        }

        private ThucDonMauDAO() { }

        /// <summary>
        /// Lấy danh sách tất cả thực đơn mẫu (mặc định xếp trước)
        /// </summary>
        public List<ThucDonMauModel> GetAll()
        {
            List<ThucDonMauModel> list = new List<ThucDonMauModel>();

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ThucDonMau_DanhSach", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            list.Add(MapHeader(reader));
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Lấy thực đơn mẫu mặc định (la_mac_dinh = 1)
        /// </summary>
        public ThucDonMauModel GetMacDinh()
        {
            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ThucDonMau_LayMacDinh", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return MapHeader(reader);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Lấy chi tiết các món trong một thực đơn mẫu (JOIN với Mon_an)
        /// </summary>
        public List<ChiTietTdMauModel> GetChiTietByMauId(int mauId)
        {
            List<ChiTietTdMauModel> list = new List<ChiTietTdMauModel>();

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ChiTietTdMau_LayTheoMau", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MauId", mauId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ChiTietTdMauModel
                            {
                                MauId = Convert.ToInt32(reader["mau_id"]),
                                ThuTrongTuan = Convert.ToByte(reader["thu_trong_tuan"]),
                                BuoiAnId = Convert.ToInt32(reader["buoian_id"]),
                                MonAnId = Convert.ToInt32(reader["monan_id"]),
                                ViTri = Convert.ToByte(reader["vi_tri"]),
                                GhiChuMau = reader["ghi_chu_mau"] == DBNull.Value
                                    ? null
                                    : reader["ghi_chu_mau"].ToString(),
                                TenMon = reader["monan_ten"].ToString(),
                                LoaiMon = reader["monan_loaimon"].ToString(),
                                Dam = ToDouble(reader["dam"]),
                                ChatXo = ToDouble(reader["chat_xo"]),
                                ChatBeo = ToDouble(reader["chat_beo"])
                            });
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Ánh xạ từ SqlDataReader sang ThucDonMauModel (phần header)
        /// </summary>
        private static ThucDonMauModel MapHeader(SqlDataReader reader)
        {
            return new ThucDonMauModel
            {
                MauId = Convert.ToInt32(reader["mau_id"]),
                MauTen = reader["mau_ten"].ToString(),
                MauMoTa = reader["mau_mo_ta"] == DBNull.Value ? null : reader["mau_mo_ta"].ToString(),
                NgayTao = Convert.ToDateTime(reader["ngay_tao"]),
                NguoiTao = reader["nguoi_tao"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["nguoi_tao"]),
                LaMacDinh = Convert.ToBoolean(reader["la_mac_dinh"])
            };
        }

        /// <summary>
        /// Chuyển đổi giá trị object sang double an toàn (trả về 0 nếu NULL)
        /// </summary>
        private static double ToDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }
    }
}
