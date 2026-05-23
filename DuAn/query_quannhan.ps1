$connString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyTieuChuanQuanNhan;Integrated Security=True"
$conn = New-Object System.Data.SqlClient.SqlConnection($connString)
try {
    $conn.Open()
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "SELECT * FROM [dbo].[Quan_nhan] WHERE quannhan_id = 2024061"
    $adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    $dt = New-Object System.Data.DataTable
    $adapter.Fill($dt) | Out-Null
    $dt | Format-List
} catch {
    Write-Error $_.Exception.Message
} finally {
    $conn.Close()
}
