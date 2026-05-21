$connString = "Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyTieuChuanQuanNhan;Integrated Security=True"
$conn = New-Object System.Data.SqlClient.SqlConnection($connString)
try {
    $conn.Open()
    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Quan_nhan'"
    $adapter = New-Object System.Data.SqlClient.SqlDataAdapter($cmd)
    $dt = New-Object System.Data.DataTable
    $adapter.Fill($dt) | Out-Null
    $dt | Format-Table
} catch {
    Write-Error $_.Exception.Message
} finally {
    $conn.Close()
}
