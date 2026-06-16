ALTER PROCEDURE [dbo].[sp_MonAn_LayMaMoi]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(MAX(monan_id), 0) + 1 AS MaMoi FROM Mon_an;
END
GO
