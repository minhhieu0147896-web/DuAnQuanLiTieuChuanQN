-- ============================================================
-- Script: Chuyển đổi tất cả inline SQL thành Stored Procedure
-- Dự án: Quản Lý Tiêu Chuẩn Quân Nhân
-- Ngày: 18/06/2026
-- ============================================================
-- Hướng dẫn: Chạy toàn bộ script này trong SQL Server Management Studio
-- trên database QuanLyTieuChuanQuanNhan1
-- ============================================================

-- ============================================================
-- 1. BẢNG Mon_an (Món ăn)
-- ============================================================

-- 1.1 Lấy danh sách loại món (DISTINCT)
IF OBJECT_ID('dbo.sp_MonAn_LayLoaiMon') IS NOT NULL
    DROP PROC dbo.sp_MonAn_LayLoaiMon
GO
CREATE PROC dbo.sp_MonAn_LayLoaiMon
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DISTINCT monan_loaimon
    FROM Mon_an
    WHERE monan_loaimon IS NOT NULL
    ORDER BY monan_loaimon;
END
GO

-- 1.2 Lấy danh sách món ăn theo loại món
IF OBJECT_ID('dbo.sp_MonAn_LayTheoLoaiMon') IS NOT NULL
    DROP PROC dbo.sp_MonAn_LayTheoLoaiMon
GO
CREATE PROC dbo.sp_MonAn_LayTheoLoaiMon
    @LoaiMon NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT monan_id, monan_loaimon, monan_ten,
           ISNULL(dam, 0) AS dam,
           ISNULL(chat_xo, 0) AS chat_xo,
           ISNULL(chat_beo, 0) AS chat_beo
    FROM Mon_an
    WHERE monan_loaimon = @LoaiMon
    ORDER BY monan_ten;
END
GO

-- 1.3 Lấy danh sách món ăn theo nhóm loại món + ghi chú (lọc phía DB trước)
IF OBJECT_ID('dbo.sp_MonAn_LayTheoGhiChu') IS NOT NULL
    DROP PROC dbo.sp_MonAn_LayTheoGhiChu
GO
CREATE PROC dbo.sp_MonAn_LayTheoGhiChu
    @GhiChu NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT monan_id, monan_loaimon, monan_ten,
           ISNULL(dam, 0) AS dam,
           ISNULL(chat_xo, 0) AS chat_xo,
           ISNULL(chat_beo, 0) AS chat_beo
    FROM Mon_an
    WHERE monan_loaimon IS NOT NULL
      AND (@GhiChu IS NULL OR UPPER(LTRIM(RTRIM(ISNULL(ghi_chu, '')))) = UPPER(@GhiChu))
    ORDER BY monan_loaimon, monan_ten;
END
GO

-- 1.4 Tìm món Sữa (dùng cho GetOrCreate)
IF OBJECT_ID('dbo.sp_MonAn_TimSua') IS NOT NULL
    DROP PROC dbo.sp_MonAn_TimSua
GO
CREATE PROC dbo.sp_MonAn_TimSua
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 monan_id, monan_loaimon, monan_ten,
           ISNULL(dam, 0) AS dam,
           ISNULL(chat_xo, 0) AS chat_xo,
           ISNULL(chat_beo, 0) AS chat_beo
    FROM Mon_an
    WHERE monan_loaimon = N'Sua'
       OR monan_ten = N'Sữa'
       OR monan_ten = N'Sua'
    ORDER BY monan_id;
END
GO

-- 1.5 Tìm món Cơm trắng (dùng cho GetOrCreate)
IF OBJECT_ID('dbo.sp_MonAn_TimCom') IS NOT NULL
    DROP PROC dbo.sp_MonAn_TimCom
GO
CREATE PROC dbo.sp_MonAn_TimCom
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 monan_id, monan_loaimon, monan_ten,
           ISNULL(dam, 0) AS dam,
           ISNULL(chat_xo, 0) AS chat_xo,
           ISNULL(chat_beo, 0) AS chat_beo
    FROM Mon_an
    WHERE monan_loaimon = N'Com'
       OR monan_ten = N'Cơm trắng'
       OR monan_ten = N'Cơm'
    ORDER BY monan_id;
END
GO

-- 1.6 Tính tổng dinh dưỡng mục tiêu theo tuần của chế độ
IF OBJECT_ID('dbo.sp_MonAn_TinhDinhDuongTuan') IS NOT NULL
    DROP PROC dbo.sp_MonAn_TinhDinhDuongTuan
GO
CREATE PROC dbo.sp_MonAn_TinhDinhDuongTuan
    @CheDoId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        ISNULL(SUM(so_luong * 7.0 *
            CASE UPPER(LTRIM(RTRIM(nhom_thucpham)))
                WHEN 'TINH BOT' THEN 7.0
                WHEN 'THIT' THEN 20.0
                WHEN 'CA' THEN 19.0
                WHEN 'TRUNG' THEN 13.0
                WHEN 'DAU' THEN 8.0
                WHEN 'RAU' THEN 2.0
                WHEN 'TRAI CAY' THEN 0.8
                WHEN 'SUA' THEN 3.2
                ELSE 0.0
            END / 100.0), 0) AS dam,
        ISNULL(SUM(so_luong * 7.0 *
            CASE UPPER(LTRIM(RTRIM(nhom_thucpham)))
                WHEN 'TINH BOT' THEN 1.3
                WHEN 'DAU' THEN 1.0
                WHEN 'RAU' THEN 2.5
                WHEN 'TRAI CAY' THEN 1.8
                ELSE 0.0
            END / 100.0), 0) AS chat_xo,
        ISNULL(SUM(so_luong * 7.0 *
            CASE UPPER(LTRIM(RTRIM(nhom_thucpham)))
                WHEN 'TINH BOT' THEN 0.6
                WHEN 'THIT' THEN 12.0
                WHEN 'CA' THEN 5.0
                WHEN 'TRUNG' THEN 11.0
                WHEN 'DAU' THEN 4.0
                WHEN 'RAU' THEN 0.2
                WHEN 'TRAI CAY' THEN 0.2
                WHEN 'SUA' THEN 3.5
                ELSE 0.0
            END / 100.0), 0) AS chat_beo
    FROM Dinh_luong_che_do_chuan
    WHERE chedo_id = @CheDoId;
END
GO

-- ============================================================
-- 2. BẢNG Chi_tiet_thuc_don (Chi tiết thực đơn)
-- ============================================================

-- 2.1 Lấy chi tiết thực đơn theo ngày + buổi (có JOIN tên món, tên buổi)
IF OBJECT_ID('dbo.sp_ChiTietThucDon_LayTheoNgayBuoi') IS NOT NULL
    DROP PROC dbo.sp_ChiTietThucDon_LayTheoNgayBuoi
GO
CREATE PROC dbo.sp_ChiTietThucDon_LayTheoNgayBuoi
    @ThucDonId INT,
    @Ngay DATE,
    @BuoiAnId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ctd.thucdon_id, ctd.ngay_thang_nam, ctd.buoian_id, ctd.monan_id,
           m.monan_ten, m.monan_loaimon, b.buoian_ten,
           ISNULL(m.dam, 0) AS dam,
           ISNULL(m.chat_xo, 0) AS chat_xo,
           ISNULL(m.chat_beo, 0) AS chat_beo
    FROM Chi_tiet_thuc_don ctd
    INNER JOIN Mon_an m ON ctd.monan_id = m.monan_id
    INNER JOIN Buoi_an b ON ctd.buoian_id = b.buoian_id
    WHERE ctd.thucdon_id = @ThucDonId
      AND ctd.ngay_thang_nam = @Ngay
      AND ctd.buoian_id = @BuoiAnId
    ORDER BY m.monan_loaimon, m.monan_ten;
END
GO

-- 2.2 Lấy chi tiết thực đơn theo ngày (tất cả buổi)
IF OBJECT_ID('dbo.sp_ChiTietThucDon_LayTheoNgay') IS NOT NULL
    DROP PROC dbo.sp_ChiTietThucDon_LayTheoNgay
GO
CREATE PROC dbo.sp_ChiTietThucDon_LayTheoNgay
    @ThucDonId INT,
    @Ngay DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ctd.thucdon_id, ctd.ngay_thang_nam, ctd.buoian_id, ctd.monan_id,
           m.monan_ten, m.monan_loaimon, b.buoian_ten,
           ISNULL(m.dam, 0) AS dam,
           ISNULL(m.chat_xo, 0) AS chat_xo,
           ISNULL(m.chat_beo, 0) AS chat_beo
    FROM Chi_tiet_thuc_don ctd
    INNER JOIN Mon_an m ON ctd.monan_id = m.monan_id
    INNER JOIN Buoi_an b ON ctd.buoian_id = b.buoian_id
    WHERE ctd.thucdon_id = @ThucDonId
      AND ctd.ngay_thang_nam = @Ngay
    ORDER BY ctd.buoian_id, m.monan_loaimon, m.monan_ten;
END
GO

-- 2.3 Thêm chi tiết thực đơn (có kiểm tra trùng, trả về 1 nếu thành công, 0 nếu trùng)
IF OBJECT_ID('dbo.sp_ChiTietThucDon_Them') IS NOT NULL
    DROP PROC dbo.sp_ChiTietThucDon_Them
GO
CREATE PROC dbo.sp_ChiTietThucDon_Them
    @ThucDonId INT,
    @Ngay DATE,
    @BuoiAnId INT,
    @MonAnId INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Kiểm tra trùng lặp
    IF EXISTS (
        SELECT 1 FROM Chi_tiet_thuc_don
        WHERE thucdon_id = @ThucDonId
          AND ngay_thang_nam = @Ngay
          AND buoian_id = @BuoiAnId
          AND monan_id = @MonAnId
    )
    BEGIN
        SELECT 0 AS KetQua; -- Đã tồn tại, không thêm
        RETURN;
    END

    -- Thêm mới
    INSERT INTO Chi_tiet_thuc_don (thucdon_id, ngay_thang_nam, buoian_id, monan_id)
    VALUES (@ThucDonId, @Ngay, @BuoiAnId, @MonAnId);

    SELECT 1 AS KetQua; -- Thành công
END
GO

-- 2.4 Xóa một chi tiết thực đơn theo khóa
IF OBJECT_ID('dbo.sp_ChiTietThucDon_Xoa') IS NOT NULL
    DROP PROC dbo.sp_ChiTietThucDon_Xoa
GO
CREATE PROC dbo.sp_ChiTietThucDon_Xoa
    @ThucDonId INT,
    @Ngay DATE,
    @BuoiAnId INT,
    @MonAnId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Chi_tiet_thuc_don
    WHERE thucdon_id = @ThucDonId
      AND ngay_thang_nam = @Ngay
      AND buoian_id = @BuoiAnId
      AND monan_id = @MonAnId;

    SELECT @@ROWCOUNT AS SoDongDaXoa;
END
GO

-- 2.5 Xóa tất cả chi tiết theo thực đơn + ngày + buổi
IF OBJECT_ID('dbo.sp_ChiTietThucDon_XoaTheoNgayBuoi') IS NOT NULL
    DROP PROC dbo.sp_ChiTietThucDon_XoaTheoNgayBuoi
GO
CREATE PROC dbo.sp_ChiTietThucDon_XoaTheoNgayBuoi
    @ThucDonId INT,
    @Ngay DATE,
    @BuoiAnId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Chi_tiet_thuc_don
    WHERE thucdon_id = @ThucDonId
      AND ngay_thang_nam = @Ngay
      AND buoian_id = @BuoiAnId;

    SELECT @@ROWCOUNT AS SoDongDaXoa;
END
GO

-- ============================================================
-- 3. BẢNG Thuc_don (Thực đơn)
-- ============================================================

-- 3.1 Tìm thực đơn theo tuần + năm + chế độ
IF OBJECT_ID('dbo.sp_ThucDon_TimTheoTuanNam') IS NOT NULL
    DROP PROC dbo.sp_ThucDon_TimTheoTuanNam
GO
CREATE PROC dbo.sp_ThucDon_TimTheoTuanNam
    @Tuan INT,
    @Nam INT,
    @CheDoId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT thucdon_id, user_id, chedo_id, trang_thai,
           thucdon_tuan, thucdon_nam, ngay_thang_nam
    FROM Thuc_don
    WHERE thucdon_tuan = @Tuan
      AND thucdon_nam = @Nam
      AND chedo_id = @CheDoId;
END
GO

-- 3.2 Thêm thực đơn mới
IF OBJECT_ID('dbo.sp_ThucDon_Them') IS NOT NULL
    DROP PROC dbo.sp_ThucDon_Them
GO
CREATE PROC dbo.sp_ThucDon_Them
    @Id INT,
    @UserId INT,
    @CheDoId INT,
    @Tuan INT,
    @Nam INT,
    @NgayLap DATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Thuc_don (thucdon_id, user_id, chedo_id, trang_thai,
                          thucdon_tuan, thucdon_nam, ngay_thang_nam)
    VALUES (@Id, @UserId, @CheDoId, N'NhapLieu', @Tuan, @Nam, @NgayLap);
END
GO

-- 3.3 Lấy mã thực đơn tiếp theo (MAX + 1)
IF OBJECT_ID('dbo.sp_ThucDon_LayMaMoi') IS NOT NULL
    DROP PROC dbo.sp_ThucDon_LayMaMoi
GO
CREATE PROC dbo.sp_ThucDon_LayMaMoi
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(MAX(thucdon_id), 0) + 1 FROM Thuc_don;
END
GO

-- 3.4 Cập nhật trạng thái thực đơn
IF OBJECT_ID('dbo.sp_ThucDon_CapNhatTrangThai') IS NOT NULL
    DROP PROC dbo.sp_ThucDon_CapNhatTrangThai
GO
CREATE PROC dbo.sp_ThucDon_CapNhatTrangThai
    @Id INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Thuc_don
    SET trang_thai = @TrangThai
    WHERE thucdon_id = @Id;

    SELECT @@ROWCOUNT AS SoDongDaCapNhat;
END
GO

-- ============================================================
-- 4. BẢNG Thuc_don_mau (Thực đơn mẫu)
-- ============================================================

-- 4.1 Lấy danh sách tất cả thực đơn mẫu
IF OBJECT_ID('dbo.sp_ThucDonMau_DanhSach') IS NOT NULL
    DROP PROC dbo.sp_ThucDonMau_DanhSach
GO
CREATE PROC dbo.sp_ThucDonMau_DanhSach
AS
BEGIN
    SET NOCOUNT ON;
    SELECT mau_id, mau_ten, mau_mo_ta, ngay_tao, nguoi_tao, la_mac_dinh
    FROM Thuc_don_mau
    ORDER BY la_mac_dinh DESC, mau_ten;
END
GO

-- 4.2 Lấy thực đơn mẫu mặc định
IF OBJECT_ID('dbo.sp_ThucDonMau_LayMacDinh') IS NOT NULL
    DROP PROC dbo.sp_ThucDonMau_LayMacDinh
GO
CREATE PROC dbo.sp_ThucDonMau_LayMacDinh
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 mau_id, mau_ten, mau_mo_ta, ngay_tao, nguoi_tao, la_mac_dinh
    FROM Thuc_don_mau
    WHERE la_mac_dinh = 1
    ORDER BY mau_id;
END
GO

-- 4.3 Lấy chi tiết thực đơn mẫu theo mã mẫu
IF OBJECT_ID('dbo.sp_ChiTietTdMau_LayTheoMau') IS NOT NULL
    DROP PROC dbo.sp_ChiTietTdMau_LayTheoMau
GO
CREATE PROC dbo.sp_ChiTietTdMau_LayTheoMau
    @MauId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT c.mau_id, c.thu_trong_tuan, c.buoian_id, c.monan_id,
           c.vi_tri, c.ghi_chu_mau,
           m.monan_ten, m.monan_loaimon,
           ISNULL(m.dam, 0) AS dam,
           ISNULL(m.chat_xo, 0) AS chat_xo,
           ISNULL(m.chat_beo, 0) AS chat_beo
    FROM Chi_tiet_tdmau c
    INNER JOIN Mon_an m ON c.monan_id = m.monan_id
    WHERE c.mau_id = @MauId
    ORDER BY c.thu_trong_tuan, c.buoian_id, c.vi_tri;
END
GO

-- ============================================================
-- 5. BẢNG Buoi_an (Bữa ăn)
-- ============================================================

-- 5.1 Lấy danh sách tất cả bữa ăn
IF OBJECT_ID('dbo.sp_BuoiAn_DanhSach') IS NOT NULL
    DROP PROC dbo.sp_BuoiAn_DanhSach
GO
CREATE PROC dbo.sp_BuoiAn_DanhSach
AS
BEGIN
    SET NOCOUNT ON;
    SELECT buoian_id, buoian_ten, buoian_tletienan
    FROM Buoi_an
    ORDER BY buoian_id;
END
GO

-- ============================================================
-- 6. BẢNG Don_vi (Đơn vị)
-- ============================================================

-- 6.1 Lấy tên đơn vị theo ID
IF OBJECT_ID('dbo.sp_DonVi_LayTen') IS NOT NULL
    DROP PROC dbo.sp_DonVi_LayTen
GO
CREATE PROC dbo.sp_DonVi_LayTen
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT donvi_ten FROM Don_vi WHERE donvi_id = @Id;
END
GO

-- ============================================================
-- KẾT THÚC SCRIPT
-- ============================================================
PRINT '>>> Đã tạo xong tất cả stored procedure! <<<';
