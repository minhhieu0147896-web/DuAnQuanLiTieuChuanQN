ALTER PROCEDURE [dbo].[sp_ThucPham_DanhSach]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        thucpham_id,
        thucpham_ten,
        thucpham_loai,
        thucpham_donvitinh,
        thucpham_giatien,
        thucpham_kcal
    FROM Thuc_pham
    ORDER BY thucpham_loai, thucpham_ten;
END
GO
