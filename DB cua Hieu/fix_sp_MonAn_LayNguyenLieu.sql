DROP PROCEDURE [dbo].[sp_MonAn_LayNguyenLieu];
GO

CREATE PROCEDURE [dbo].[sp_MonAn_LayNguyenLieu]
    @monan_id INT,
    @chedo_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        tp.thucpham_ten        AS TenThucPham,
        ct.ty_le * 1000        AS DinhLuong,
        N'g'                   AS DonViTinh
    FROM Chi_tiet_mon_an ct
    INNER JOIN Thuc_pham tp ON ct.thucpham_id = tp.thucpham_id
    WHERE ct.monan_id = @monan_id
      AND ct.chedo_id = @chedo_id
    ORDER BY tp.thucpham_ten;

END
GO
