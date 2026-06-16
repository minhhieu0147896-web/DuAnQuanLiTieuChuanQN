-- ============================================================
-- Script tạo dữ liệu test cho ngày 16/06/2026
-- Dùng để test form frmtinhtpcansudung
-- ============================================================

-- 1. Gán donvi_id = 160 cho user vanphong (Hiếu)
UPDATE [User] SET donvi_id = 160 WHERE user_taikhoan = 'vanphong';

-- 2. Thêm Dinh_luong cho các thực phẩm dùng trong thực đơn (chedo_id = 1)
INSERT INTO Dinh_luong (thucpham_id, chedo_id, dinhluong_soluong)
SELECT DISTINCT ct.thucpham_id, 1, 1.0000
FROM Chi_tiet_mon_an ct
WHERE ct.chedo_id = 1
  AND NOT EXISTS (SELECT 1 FROM Dinh_luong dl WHERE dl.thucpham_id = ct.thucpham_id AND dl.chedo_id = 1);

-- 3. Cập nhật ty_le cho các chi tiết món ăn đang NULL (gán mặc định 0.5)
UPDATE Chi_tiet_mon_an SET ty_le = 0.5000 WHERE chedo_id = 1 AND ty_le IS NULL;

-- 4. Copy Chi_tiet_thuc_don từ ngày 31/05/2026 sang 16/06/2026
--    Dùng thucdon_id = 14 (tuần 25, chedo_id = 1)
INSERT INTO Chi_tiet_thuc_don (thucdon_id, ngay_thang_nam, buoian_id, monan_id)
SELECT 14, '2026-06-16', buoian_id, monan_id
FROM Chi_tiet_thuc_don
WHERE thucdon_id = 8 AND ngay_thang_nam = '2026-05-31';

-- 5. Tạo Quan_so_an cho ngày 16/06/2026
--    Chế độ 1, đơn vị 160, 50 người mỗi buổi
INSERT INTO Quan_so_an (ngay_thang_nam, buoian_id, chedo_id, donvi_id, quansoan_soluong, quansoan_trangthai)
VALUES
    ('2026-06-16', 1, 1, 160, 50, 1),
    ('2026-06-16', 2, 1, 160, 45, 1),
    ('2026-06-16', 3, 1, 160, 40, 1);

-- Kiểm tra kết quả
SELECT 'Dinh_luong da them: ' + CAST(COUNT(*) AS VARCHAR) FROM Dinh_luong WHERE chedo_id = 1;

SELECT 'CTD ngay 16/6: ' + CAST(COUNT(*) AS VARCHAR) FROM Chi_tiet_thuc_don WHERE ngay_thang_nam = '2026-06-16';

SELECT 'QSA ngay 16/6: ' + CAST(COUNT(*) AS VARCHAR) FROM Quan_so_an WHERE ngay_thang_nam = '2026-06-16';

SELECT 'User vanphong donvi: ' + CAST(ISNULL(donvi_id, 0) AS VARCHAR) FROM [User] WHERE user_taikhoan = 'vanphong';
