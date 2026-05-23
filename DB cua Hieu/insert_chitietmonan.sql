-- ============================================================
-- Script: Bổ sung Chi_tiet_mon_an cho TẤT CẢ món trong Mon_an
-- Hiện tại chỉ có 4 dòng (monan_id 1→4, chedo_id=1)
-- Script này thêm 61 món còn lại (monan_id 5→65)
-- Mỗi món ánh xạ 1-2 thực phẩm dựa trên tên món + loại món
-- ============================================================

-- ==================== CANH (5→12) ====================
-- 5: Canh bắp cải thịt → Bắp cải(9) + Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (5, 9, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (5, 5, 1, NULL);

-- 6: Canh cà chua thịt → Cà chua(28) + Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (6, 28, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (6, 5, 1, NULL);

-- 7: Canh mùng tơi thịt → Mùng tơi(30) + Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (7, 30, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (7, 5, 1, NULL);

-- 8: Canh ngao chua → Ngao(22) + Cà chua(28)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (8, 22, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (8, 28, 1, NULL);

-- 9: Canh rau dền thịt → Rau dền(31) + Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (9, 31, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (9, 5, 1, NULL);

-- 10: Canh bí đỏ thịt → Bí đỏ(27) + Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (10, 27, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (10, 5, 1, NULL);

-- 11: Canh ngao bầu → Ngao(22) + Bầu(32)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (11, 22, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (11, 32, 1, NULL);

-- 12: Canh ngao bí xanh → Ngao(22) + Bí xanh(26)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (12, 22, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (12, 26, 1, NULL);


-- ==================== TRÁNG MIỆNG (13) ====================
-- 13: TM: Hoa quả → Hoa quả tổng hợp(43)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (13, 43, 1, NULL);


-- ==================== RAU (14→20) ====================
-- 14: Bắp cải luộc → Bắp cải(9)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (14, 9, 1, NULL);

-- 15: Rau muống xào → Rau muống(3)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (15, 3, 1, NULL);

-- 16: Giá xào hỗn hợp → Giá đỗ(25)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (16, 25, 1, NULL);

-- 17: Bí xanh luộc → Bí xanh(26)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (17, 26, 1, NULL);

-- 18: Rau muống luộc → Rau muống(3)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (18, 3, 1, NULL);

-- 19: Bí đỏ xào → Bí đỏ(27)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (19, 27, 1, NULL);

-- 20: Cà tím xào → Cà tím(29)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (20, 29, 1, NULL);


-- ==================== MẶN CHÍNH - BUỔI SÁNG (21→25) ====================
-- 21: Chả nạc rim → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (21, 5, 1, NULL);

-- 22: Thịt sốt cà chua → Thịt Heo(5) + Cà chua(28)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (22, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (22, 28, 1, NULL);

-- 23: Thịt băm xào hành → Thịt Heo(5) + Hành tây(33)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (23, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (23, 33, 1, NULL);

-- 24: Thịt băm sốt cà chua → Thịt Heo(5) + Cà chua(28)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (24, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (24, 28, 1, NULL);

-- 25: Chả rim → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (25, 5, 1, NULL);


-- ==================== MẶN CHÍNH - TRƯA/TỐI (26→64) ====================
-- 26: Thịt kho tàu → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (26, 5, 1, NULL);

-- 27: Thịt chiên lá móc mật → Thịt Heo(5) + Lá móc mật(41)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (27, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (27, 41, 1, NULL);

-- 28: Chả cá sốt cà chua → Cá Tra(6) + Cà chua(28)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (28, 6, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (28, 28, 1, NULL);

-- 29: Tôm nốt rang lá chanh → Tôm(21) + Lá chanh(37)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (29, 21, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (29, 37, 1, NULL);

-- 30: Thịt xào bí xanh → Thịt Heo(5) + Bí xanh(26)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (30, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (30, 26, 1, NULL);

-- 31: Thịt xào cần tỏi tây → Thịt Heo(5) + Cần tây(34)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (31, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (31, 34, 1, NULL);

-- 32: Trứng ốp → Trứng gà(12)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (32, 12, 1, NULL);

-- 33: Gà rán tẩm bột → Thịt Gà(2)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (33, 2, 1, NULL);

-- 34: Giò nạc rim → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (34, 5, 1, NULL);

-- 35: Thịt luộc trộn rau thơm → Thịt Heo(5) + Rau thơm(42)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (35, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (35, 42, 1, NULL);

-- 36: Đậu phụ rán tẩm hành → Đậu phụ(14) + Hành tây(33)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (36, 14, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (36, 33, 1, NULL);

-- 37: Cá đồng om dưa → Cá đồng(23) + Dưa chua(36)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (37, 23, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (37, 36, 1, NULL);

-- 38: Thịt xào thập cẩm → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (38, 5, 1, NULL);

-- 39: Thịt nạc xào xả ớt → Thịt Heo(5) + Sả(38)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (39, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (39, 38, 1, NULL);

-- 40: Nem rán → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (40, 5, 1, NULL);

-- 41: Thịt bò xào hành tây → Thịt Bò(1) + Hành tây(33)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (41, 1, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (41, 33, 1, NULL);

-- 42: Thịt kho củ cải → Thịt Heo(5) + Củ cải(35)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (42, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (42, 35, 1, NULL);

-- 43: Trứng tráng → Trứng gà(12)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (43, 12, 1, NULL);

-- 44: Tôm chiên → Tôm(21)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (44, 21, 1, NULL);

-- 45: Thịt xào hành tây → Thịt Heo(5) + Hành tây(33)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (45, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (45, 33, 1, NULL);

-- 46: Thịt quay → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (46, 5, 1, NULL);

-- 47: Chả giò rế → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (47, 5, 1, NULL);

-- 48: Gà xào gừng → Thịt Gà(2) + Gừng(39)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (48, 2, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (48, 39, 1, NULL);

-- 49: Thịt xào giá đỗ → Thịt Heo(5) + Giá đỗ(25)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (49, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (49, 25, 1, NULL);

-- 50: Ngao luộc → Ngao(22)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (50, 22, 1, NULL);

-- 51: Cá biển rán → Cá biển(24)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (51, 24, 1, NULL);

-- 52: Thịt rang hành → Thịt Heo(5) + Hành tây(33)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (52, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (52, 33, 1, NULL);

-- 53: Đậu sốt cà chua → Đậu phụ(14) + Cà chua(28)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (53, 14, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (53, 28, 1, NULL);

-- 54: Thịt bò kho dưa chua → Thịt Bò(1) + Dưa chua(36)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (54, 1, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (54, 36, 1, NULL);

-- 55: Chả bọc sả → Thịt Heo(5) + Sả(38)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (55, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (55, 38, 1, NULL);

-- 56: Trứng quay → Trứng gà(12)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (56, 12, 1, NULL);

-- 57: Gà om nấm → Thịt Gà(2) + Nấm rơm(20)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (57, 2, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (57, 20, 1, NULL);

-- 58: Thịt luộc trộn lá chanh → Thịt Heo(5) + Lá chanh(37)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (58, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (58, 37, 1, NULL);

-- 59: Đậu rán tẩm hành → Đậu phụ(14) + Hành tây(33)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (59, 14, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (59, 33, 1, NULL);

-- 60: Cá rán → Cá Tra(6)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (60, 6, 1, NULL);

-- 61: Thịt xào ớt → Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (61, 5, 1, NULL);

-- 62: Chả lá lốt → Thịt Heo(5) + Lá lốt(40)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (62, 5, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (62, 40, 1, NULL);

-- 63: Trứng đúc thịt → Trứng gà(12) + Thịt Heo(5)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (63, 12, 1, NULL);
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (63, 5, 1, NULL);

-- 64: Gà rang → Thịt Gà(2)
INSERT INTO Chi_tiet_mon_an (monan_id, thucpham_id, chedo_id, ty_le) VALUES (64, 2, 1, NULL);


-- ==================== SỮA (65) ====================
-- 65: Sữa → Không có thực phẩm "Sữa" trong bảng Thuc_pham
--      Trong code, món này được MonAnDAO.GetOrCreateSua() xử lý riêng
--      Dùng tạm Gạo tẻ(16) làm placeholder nếu cần, hoặc bỏ qua
--      → Bỏ qua (không insert), vì Sữa được tự động thêm bởi code

-- ============================================================
-- KIỂM TRA KẾT QUẢ
-- ============================================================
-- SELECT m.monan_id, m.monan_ten, COUNT(ct.monan_id) AS so_luong_tp
-- FROM Mon_an m
-- LEFT JOIN Chi_tiet_mon_an ct ON m.monan_id = ct.monan_id AND ct.chedo_id = 1
-- GROUP BY m.monan_id, m.monan_ten
-- ORDER BY m.monan_id;
--
-- Kỳ vọng: monan_id 1→64 đều có ít nhất 1 dòng, monan_id 65 (Sữa) không có
