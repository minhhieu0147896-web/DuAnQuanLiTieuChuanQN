CREATE PROCEDURE [dbo].[sp_TinhThucPham_CanSuDung]
    @ngay      DATE,
    @buoian_id INT = NULL,
    @donvi_id  INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Bảng tạm: số người ăn thực tế theo từng chế độ, từng buổi
    DECLARE @SoNguoiAn TABLE (
        chedo_id INT,
        buoian_id INT,
        so_nguoi INT
    );

    -- Quân số ăn từ Quan_so_an (chỉ lấy trạng thái = 1)
    INSERT INTO @SoNguoiAn (chedo_id, buoian_id, so_nguoi)
    SELECT qsa.chedo_id, qsa.buoian_id, qsa.quansoan_soluong
    FROM Quan_so_an qsa
    WHERE qsa.ngay_thang_nam = @ngay
      AND qsa.donvi_id = @donvi_id
      AND qsa.quansoan_trangthai = 1
      AND (@buoian_id IS NULL OR qsa.buoian_id = @buoian_id);

    -- Trừ số người cắt cơm (Cat_com có trang_thai = 1)
    ;WITH CatComTheoCheDo AS (
        SELECT qn.chedo_id, cc.buoian_id, COUNT(*) AS so_cat
        FROM Cat_com cc
        JOIN Quan_nhan qn ON cc.quannhan_id = qn.quannhan_id
        WHERE cc.ngay_thang_nam = @ngay
          AND cc.donvi_id = @donvi_id
          AND cc.trang_thai = 1
          AND (@buoian_id IS NULL OR cc.buoian_id = @buoian_id)
        GROUP BY qn.chedo_id, cc.buoian_id
    )
    UPDATE sa
    SET sa.so_nguoi = sa.so_nguoi - ISNULL(cc.so_cat, 0)
    FROM @SoNguoiAn sa
    LEFT JOIN CatComTheoCheDo cc
        ON sa.chedo_id = cc.chedo_id
       AND sa.buoian_id = cc.buoian_id;

    -- Kết quả: gộp thực phẩm từ tất cả món ăn trong ngày
    SELECT
        tp.thucpham_ten        AS TenThucPham,
        tp.thucpham_donvitinh  AS DonViTinh,
        SUM(ct.ty_le * dl.dinhluong_soluong * sa.so_nguoi)                     AS TongSoLuong,
        SUM(ct.ty_le * dl.dinhluong_soluong * sa.so_nguoi * tp.thucpham_giatien) AS TongTien
    FROM Chi_tiet_thuc_don ctd
    JOIN Thuc_don td ON ctd.thucdon_id = td.thucdon_id
    JOIN Chi_tiet_mon_an ct
        ON ctd.monan_id = ct.monan_id
       AND td.chedo_id = ct.chedo_id
    JOIN Thuc_pham tp ON ct.thucpham_id = tp.thucpham_id
    JOIN Dinh_luong dl
        ON ct.thucpham_id = dl.thucpham_id
       AND ct.chedo_id = dl.chedo_id
    JOIN @SoNguoiAn sa
        ON td.chedo_id = sa.chedo_id
       AND ctd.buoian_id = sa.buoian_id
    WHERE ctd.ngay_thang_nam = @ngay
      AND (@buoian_id IS NULL OR ctd.buoian_id = @buoian_id)
      AND sa.so_nguoi > 0
    GROUP BY tp.thucpham_id, tp.thucpham_ten, tp.thucpham_donvitinh
    ORDER BY tp.thucpham_ten;

END
GO
