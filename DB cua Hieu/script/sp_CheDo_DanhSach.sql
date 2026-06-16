ALTER PROCEDURE [dbo].[sp_CheDo_DanhSach]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT chedo_id, chedo_ten, chedo_tienan
    FROM Che_do
    ORDER BY chedo_id;
END
GO
