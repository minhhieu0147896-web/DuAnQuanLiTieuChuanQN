using DuAn.DTO;
using System;
using System.Collections.Generic;
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

        public List<ThucDonMauModel> GetAll()
        {
            List<ThucDonMauModel> list = new List<ThucDonMauModel>();
            const string query = @"SELECT mau_id, mau_ten, mau_mo_ta, ngay_tao, nguoi_tao, la_mac_dinh
                                   FROM Thuc_don_mau
                                   ORDER BY la_mac_dinh DESC, mau_ten";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(MapHeader(reader));
                }
            }

            return list;
        }

        public ThucDonMauModel GetMacDinh()
        {
            const string query = @"SELECT TOP 1 mau_id, mau_ten, mau_mo_ta, ngay_tao, nguoi_tao, la_mac_dinh
                                   FROM Thuc_don_mau
                                   WHERE la_mac_dinh = 1
                                   ORDER BY mau_id";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return MapHeader(reader);
                }
            }

            return null;
        }

        public List<ChiTietTdMauModel> GetChiTietByMauId(int mauId)
        {
            List<ChiTietTdMauModel> list = new List<ChiTietTdMauModel>();
            const string query = @"SELECT c.mau_id, c.thu_trong_tuan, c.buoian_id, c.monan_id, c.vi_tri, c.ghi_chu_mau,
                                          m.monan_ten, m.monan_loaimon,
                                          ISNULL(m.dam, 0) AS dam,
                                          ISNULL(m.chat_xo, 0) AS chat_xo,
                                          ISNULL(m.chat_beo, 0) AS chat_beo
                                   FROM Chi_tiet_tdmau c
                                   INNER JOIN Mon_an m ON c.monan_id = m.monan_id
                                   WHERE c.mau_id = @mauId
                                   ORDER BY c.thu_trong_tuan, c.buoian_id, c.vi_tri";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@mauId", mauId);
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

        private static double ToDouble(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }
    }
}
