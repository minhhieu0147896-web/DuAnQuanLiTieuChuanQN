CREATE PROC [dbo].[sp_MonAn_Xoa]
    @monan_id INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Xóa nguyên liệu trước (FK constraint)
        DELETE FROM Chi_tiet_mon_an WHERE monan_id = @monan_id;

        -- Xóa món ăn
        DELETE FROM Mon_an WHERE monan_id = @monan_id;

        COMMIT;
        SELECT 1 AS ket_qua;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        SELECT 0 AS ket_qua;
    END CATCH
END
GO
