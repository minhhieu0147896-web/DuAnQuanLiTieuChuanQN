CREATE PROC [dbo].[sp_MonAn_CapNhat]
    @monan_id       INT,
    @monan_ten      NVARCHAR(200),
    @monan_loaimon  NVARCHAR(200),
    @ghi_chu        NVARCHAR(500) = NULL,
    @dam            FLOAT = NULL,
    @chat_beo       FLOAT = NULL,
    @chat_xo        FLOAT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Mon_an
    SET monan_ten = @monan_ten,
        monan_loaimon = @monan_loaimon,
        ghi_chu = @ghi_chu,
        dam = @dam,
        chat_beo = @chat_beo,
        chat_xo = @chat_xo
    WHERE monan_id = @monan_id;

    -- Xóa nguyên liệu cũ, thêm lại mới
    DELETE FROM Chi_tiet_mon_an WHERE monan_id = @monan_id;
END
GO
