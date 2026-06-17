CREATE PROC [dbo].[sp_BaoCaoQuanSo]
    @tungay    DATE,
    @denngay   DATE,
    @donvi_id  INT,
    @buoian_id INT
AS
BEGIN
    SET NOCOUNT ON;

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
    INNER JOIN Che_do  cd ON qs.chedo_id  = cd.chedo_id
    INNER JOIN Don_vi  dv ON qs.donvi_id  = dv.donvi_id
    WHERE qs.ngay_thang_nam BETWEEN @tungay AND @denngay
      AND qs.donvi_id = @donvi_id
      AND (@buoian_id = 0 OR qs.buoian_id = @buoian_id)
    ORDER BY qs.ngay_thang_nam, qs.buoian_id, cd.chedo_id;
END
GO
