CREATE PROC [dbo].[sp_BaoCaoThucPham]
    @tungay    DATE,
    @denngay   DATE,
    @donvi_id  INT,
    @buoian_id INT,
    @chedo_id  INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        qs.ngay_thang_nam AS Ngay,
        ba.buoian_ten      AS Buoi,
        cd.chedo_ten       AS CheDo,
        dv.donvi_ten       AS DonVi,
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
    INNER JOIN Che_do  cd ON qs.chedo_id  = cd.chedo_id
    INNER JOIN Don_vi  dv ON qs.donvi_id  = dv.donvi_id
    INNER JOIN Dinh_luong_che_do_chuan dl ON dl.chedo_id = qs.chedo_id
    OUTER APPLY
    (
        SELECT TOP 1 thucpham_giatien
        FROM Thuc_pham tp
        WHERE tp.thucpham_ten = dl.ten_thucpham_chuan
           OR (dl.ten_thucpham_chuan = N'Thịt xô lọc'   AND tp.thucpham_loai = N'THIT')
           OR (dl.ten_thucpham_chuan = N'Thịt lợn nạc'  AND (tp.thucpham_ten LIKE N'%Heo%' OR tp.thucpham_ten LIKE N'%lợn%'))
           OR (dl.ten_thucpham_chuan = N'Thịt bò'       AND tp.thucpham_ten LIKE N'%Bò%')
           OR (dl.ten_thucpham_chuan = N'Thịt gia cầm'  AND (tp.thucpham_ten LIKE N'%Gà%' OR tp.thucpham_loai = N'GIA CAM'))
           OR (dl.ten_thucpham_chuan = N'Cá tươi'       AND tp.thucpham_loai = N'CA')
           OR (dl.ten_thucpham_chuan = N'Trứng'          AND tp.thucpham_loai = N'TRUNG')
           OR (dl.ten_thucpham_chuan = N'Đậu phụ'       AND tp.thucpham_ten LIKE N'%Đậu phụ%')
           OR (dl.ten_thucpham_chuan = N'Rau xanh'       AND tp.thucpham_loai = N'RAU')
           OR (dl.ten_thucpham_chuan = N'Hoa quả tươi'   AND tp.thucpham_loai = N'TRAI CAY')
           OR (dl.ten_thucpham_chuan = N'Sữa tươi'       AND (tp.thucpham_loai = N'SUA' OR tp.thucpham_ten LIKE N'%Sữa%'))
        ORDER BY
           CASE WHEN tp.thucpham_ten = dl.ten_thucpham_chuan THEN 0 ELSE 1 END,
           tp.thucpham_giatien
    ) tp
    WHERE qs.ngay_thang_nam BETWEEN @tungay AND @denngay
      AND qs.donvi_id = @donvi_id
      AND (@buoian_id = 0 OR qs.buoian_id = @buoian_id)
      AND (@chedo_id = 0  OR qs.chedo_id  = @chedo_id)
      AND (
            dl.nhom_thucpham <> N'SUA'
            OR qs.buoian_id = 1
          )
    ORDER BY qs.ngay_thang_nam, qs.buoian_id, cd.chedo_id, dl.dinhluong_chuan_id;
END
GO
