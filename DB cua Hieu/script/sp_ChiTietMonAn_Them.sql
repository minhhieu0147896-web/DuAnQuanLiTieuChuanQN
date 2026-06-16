ALTER PROCEDURE [dbo].[sp_ChiTietMonAn_Them]
    @monan_id       INT,
    @thucpham_id    INT,
    @chedo_id       INT,
    @ty_le          DECIMAL(8, 4) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra trùng lặp (composite PK: monan_id + thucpham_id + chedo_id)
    IF NOT EXISTS (
        SELECT 1 FROM Chi_tiet_mon_an
        WHERE monan_id = @monan_id AND thucpham_id = @thucpham_id AND chedo_id = @chedo_id
    )
    BEGIN
        INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le)
        VALUES (@monan_id, @thucpham_id, @chedo_id, @ty_le);
    END

    SELECT @@ROWCOUNT AS RowsAffected;
END
GO
