using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DAO
{
    internal class D_LSBQS
    {
        public static DataTable TraCuu(LSBQS ls,int page, int pagesize)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_lichsubaoqs", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tungay", ls.tungay);
            cmd.Parameters.AddWithValue("@denngay", ls.denngay);
            cmd.Parameters.AddWithValue("@donvi_id", ls.donvi_id);
            cmd.Parameters.AddWithValue("@buoian_id", ls.buoian_id);
            cmd.Parameters.AddWithValue("@page",page );
            cmd.Parameters.AddWithValue("@pagesize", pagesize);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;
        }

        public static DataTable TraCuu(LSBQS ls)
        {
            const string query = @"
SELECT
    qs.ngay_thang_nam,
    ba.buoian_ten,
    ba.buoian_id,
    cd.chedo_ten,
    cd.chedo_id,
    dv.donvi_ten,
    qs.quansoan_soluong AS An,
    (
        SELECT COUNT(*)
        FROM Quan_nhan qn
        WHERE qn.donvi_id = qs.donvi_id
          AND qn.chedo_id = qs.chedo_id
    ) - qs.quansoan_soluong AS CatCom
FROM Quan_so_an qs
INNER JOIN Buoi_an ba ON qs.buoian_id = ba.buoian_id
INNER JOIN Che_do cd ON qs.chedo_id = cd.chedo_id
INNER JOIN Don_vi dv ON qs.donvi_id = dv.donvi_id
WHERE qs.ngay_thang_nam BETWEEN @tungay AND @denngay
  AND qs.donvi_id = @donvi_id
  AND (@buoian_id = 0 OR qs.buoian_id = @buoian_id)
ORDER BY qs.ngay_thang_nam, qs.buoian_id, cd.chedo_id;";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tungay", ls.tungay.Date);
                cmd.Parameters.AddWithValue("@denngay", ls.denngay.Date);
                cmd.Parameters.AddWithValue("@donvi_id", ls.donvi_id);
                cmd.Parameters.AddWithValue("@buoian_id", ls.buoian_id);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }

        public static DataTable TraCuuThucPham(DateTime tuNgay, DateTime denNgay, int donViId, int buoiAnId, int cheDoId)
        {
            const string query = @"
SELECT
    qs.ngay_thang_nam AS Ngay,
    ba.buoian_ten AS Buoi,
    cd.chedo_ten AS CheDo,
    dv.donvi_ten AS DonVi,
    dl.ten_thucpham_chuan AS ThucPham,
    CAST(dl.so_luong * 
        CASE
            WHEN dl.nhom_thucpham = N'SUA' THEN CASE WHEN qs.buoian_id = 1 THEN 1 ELSE 0 END
            ELSE ba.buoian_tletienan
        END * qs.quansoan_soluong AS DECIMAL(18, 2)) AS SoLuong,
    dl.don_vi_tinh AS DonViTinh,
    CAST(dl.so_luong *
        CASE
            WHEN dl.nhom_thucpham = N'SUA' THEN CASE WHEN qs.buoian_id = 1 THEN 1 ELSE 0 END
            ELSE ba.buoian_tletienan
        END * qs.quansoan_soluong * ISNULL(tp.thucpham_giatien, 0) AS DECIMAL(18, 2)) AS ChiPhi
FROM Quan_so_an qs
INNER JOIN Buoi_an ba ON qs.buoian_id = ba.buoian_id
INNER JOIN Che_do cd ON qs.chedo_id = cd.chedo_id
INNER JOIN Don_vi dv ON qs.donvi_id = dv.donvi_id
INNER JOIN Dinh_luong_che_do_chuan dl ON dl.chedo_id = qs.chedo_id
OUTER APPLY
(
    SELECT TOP 1 thucpham_giatien
    FROM Thuc_pham tp
    WHERE tp.thucpham_ten = dl.ten_thucpham_chuan
       OR (dl.ten_thucpham_chuan = N'Thịt xô lọc' AND tp.thucpham_loai = N'THIT')
       OR (dl.ten_thucpham_chuan = N'Thịt lợn nạc' AND (tp.thucpham_ten LIKE N'%Heo%' OR tp.thucpham_ten LIKE N'%lợn%'))
       OR (dl.ten_thucpham_chuan = N'Thịt bò' AND tp.thucpham_ten LIKE N'%Bò%')
       OR (dl.ten_thucpham_chuan = N'Thịt gia cầm' AND (tp.thucpham_ten LIKE N'%Gà%' OR tp.thucpham_loai = N'GIA CAM'))
       OR (dl.ten_thucpham_chuan = N'Cá tươi' AND tp.thucpham_loai = N'CA')
       OR (dl.ten_thucpham_chuan = N'Trứng' AND tp.thucpham_loai = N'TRUNG')
       OR (dl.ten_thucpham_chuan = N'Đậu phụ' AND tp.thucpham_ten LIKE N'%Đậu phụ%')
       OR (dl.ten_thucpham_chuan = N'Rau xanh' AND tp.thucpham_loai = N'RAU')
       OR (dl.ten_thucpham_chuan = N'Hoa quả tươi' AND tp.thucpham_loai = N'TRAI CAY')
       OR (dl.ten_thucpham_chuan = N'Sữa tươi' AND (tp.thucpham_loai = N'SUA' OR tp.thucpham_ten LIKE N'%Sữa%'))
    ORDER BY
       CASE WHEN tp.thucpham_ten = dl.ten_thucpham_chuan THEN 0 ELSE 1 END,
       tp.thucpham_giatien
) tp
WHERE qs.ngay_thang_nam BETWEEN @tungay AND @denngay
  AND qs.donvi_id = @donvi_id
  AND (@buoian_id = 0 OR qs.buoian_id = @buoian_id)
  AND (@chedo_id = 0 OR qs.chedo_id = @chedo_id)
  AND (
        dl.nhom_thucpham <> N'SUA'
        OR qs.buoian_id = 1
      )
ORDER BY qs.ngay_thang_nam, qs.buoian_id, cd.chedo_id, dl.dinhluong_chuan_id;";

            using (SqlConnection conn = DataProvider.Instance.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tungay", tuNgay.Date);
                cmd.Parameters.AddWithValue("@denngay", denNgay.Date);
                cmd.Parameters.AddWithValue("@donvi_id", donViId);
                cmd.Parameters.AddWithValue("@buoian_id", buoiAnId);
                cmd.Parameters.AddWithValue("@chedo_id", cheDoId);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
                return dt;
            }
        }
        public static int CountLSBQS(LSBQS ls)
        {
            SqlConnection conn = DataProvider.Instance.GetConnection();

            SqlCommand cmd =
                new SqlCommand("sp_QuanSoAn_Count", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@tungay", ls.tungay);

            cmd.Parameters.AddWithValue("@denngay", ls.denngay);

            cmd.Parameters.AddWithValue("@donvi", ls.donvi_id);

            cmd.Parameters.AddWithValue("@buoi", ls.buoian_id);

            conn.Open();

            int total =
                Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            return total;
        }

    }
}
