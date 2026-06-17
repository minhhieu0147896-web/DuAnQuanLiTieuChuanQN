CREATE PROC [dbo].[sp_MonAn_LayTheoId]
    @monan_id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Thông tin món ăn
    SELECT
        monan_id,
        monan_ten,
        monan_loaimon,
        ISNULL(ghi_chu, '') AS ghi_chu,
        ISNULL(dam, 0) AS dam,
        ISNULL(chat_beo, 0) AS chat_beo,
        ISNULL(chat_xo, 0) AS chat_xo
    FROM Mon_an
    WHERE monan_id = @monan_id;

    -- Nguyên liệu của món
    SELECT
        ct.thucpham_id,
        tp.thucpham_ten,
        ct.chedo_id,
        cd.chedo_ten,
        ISNULL(ct.ty_le, 0) AS ty_le
    FROM Chi_tiet_mon_an ct
    INNER JOIN Thuc_pham tp ON ct.thucpham_id = tp.thucpham_id
    INNER JOIN Che_do cd ON ct.chedo_id = cd.chedo_id
    WHERE ct.monan_id = @monan_id
    ORDER BY cd.chedo_id, tp.thucpham_ten;
END
GO
