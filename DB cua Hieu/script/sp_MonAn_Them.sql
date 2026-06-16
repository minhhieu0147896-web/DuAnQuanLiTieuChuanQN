ALTER PROCEDURE [dbo].[sp_MonAn_Them]
    @monan_id       INT,
    @monan_ten      NVARCHAR(150),
    @monan_loaimon  NVARCHAR(20),
    @ghi_chu        NVARCHAR(50) = NULL,
    @dam            FLOAT = NULL,
    @chat_beo       FLOAT = NULL,
    @chat_xo        FLOAT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Mon_an (monan_id, monan_ten, monan_loaimon, ghi_chu, dam, chat_beo, chat_xo)
    VALUES (@monan_id, @monan_ten, @monan_loaimon, @ghi_chu, @dam, @chat_beo, @chat_xo);

    -- Trả về số dòng bị ảnh hưởng để kiểm tra thành công
    SELECT @@ROWCOUNT AS RowsAffected;
END
GO
