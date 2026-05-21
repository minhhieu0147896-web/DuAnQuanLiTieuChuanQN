$connString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyTieuChuanQuanNhan;Integrated Security=True"
$conn = New-Object System.Data.SqlClient.SqlConnection($connString)
try {
    $conn.Open()
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = @"
IF NOT EXISTS (
    SELECT 1 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'User' AND COLUMN_NAME = 'donvi_id'
)
BEGIN
    ALTER TABLE [dbo].[User] ADD [donvi_id] INT NULL;
END
"@
    $cmd.ExecuteNonQuery() | Out-Null
    
    $cmd.CommandText = @"
UPDATE u
SET u.donvi_id = q.donvi_id
FROM [dbo].[User] u
JOIN [dbo].[Quan_nhan] q ON u.quannhan_id = q.quannhan_id
WHERE u.donvi_id IS NULL;
"@
    $rows = $cmd.ExecuteNonQuery()
    Write-Host "Da cap nhat thanh cong. So dong anh huong: $rows"
} catch {
    Write-Error $_.Exception.Message
} finally {
    $conn.Close()
}
