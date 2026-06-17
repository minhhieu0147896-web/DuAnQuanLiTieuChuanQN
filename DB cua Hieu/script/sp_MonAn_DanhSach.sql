CREATE PROC [dbo].[sp_MonAn_DanhSach]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        monan_id,
        monan_ten,
        monan_loaimon,
        ISNULL(ghi_chu, '') AS ghi_chu,
        ISNULL(dam, 0) AS dam,
        ISNULL(chat_beo, 0) AS chat_beo,
        ISNULL(chat_xo, 0) AS chat_xo
    FROM Mon_an
    ORDER BY monan_loaimon, monan_ten;
END
GO
