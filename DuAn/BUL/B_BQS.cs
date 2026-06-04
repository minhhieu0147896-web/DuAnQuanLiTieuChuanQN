using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.BUL
{
    internal class B_BQS
    {
        public static DataTable loadbuoi()
        {
            return DAO.D_BQS.LoadBuoi();
        }
        public static DataTable loadbqs(int madv)
        {
            return DAO.D_BQS.LoadBaoQuanSo(madv);
        }
        public static void insertcatcom(DTO.catcom cc)
        {
            DAO.D_BQS.InsertCatCom(cc);
        }
        public static void insertqsa(DTO.quansoan qsa)
        {
            DAO.D_BQS.InsertQuanSoAn(qsa);
        }
        public static bool KiemTraDaBao(DateTime ngay, int mabuoi, int madv)
        {
            return DAO.D_BQS.KiemTraDaBao(ngay, mabuoi, madv);
        }
        public static DataTable loadbqs(int donvi, string tukhoa, int page, int pagesize)
        {
            return D_BQS.loadbqs(donvi, tukhoa, page, pagesize);
        }

        public static int CountBQS(int donvi, string tukhoa)
        {
            return D_BQS.CountBQS(donvi, tukhoa);
        }
        public static List<int> LayDSCatComHienTai(DateTime ngay, int mabuoi, int madv)
            => D_BQS.LayDSCatComHienTai(ngay, mabuoi, madv);

        // ──────────────────────────────────────────────────
        // Kiểm tra khóa sổ (2 tầng)
        // Tầng 1: giờ tự động >= 19:00
        // Tầng 2: bảng Khoa_so (khóa thủ công)
        // ──────────────────────────────────────────────────
        public static bool KiemTraDaKhoa(DateTime ngay, int madv)
        {
            if (DateTime.Now.Hour >= 19) return true;
            return D_BQS.KiemTraDaKhoaSo(ngay, madv);
        }

        // ──────────────────────────────────────────────────
        // LƯU BÁO QUÂN SỐ — nghiệp vụ chính
        // Hỗ trợ báo lần đầu VÀ báo đè (sửa lại)
        // ──────────────────────────────────────────────────
        public static (bool ok, string thongBao) LuuBaoQuanSo(
            DateTime ngay,
            int mabuoi,
            int madv,
            HashSet<int> dsKhongAn,          // danh sách QN cắt cơm
            Func<int, int> getCheDoByMaQN,     // lấy chế độ của QN
            Func<int, int, int> countQSCheDo)   // đếm QS theo đơn vị + chế độ
        {
            // ── Kiểm tra khóa ─────────────────────────────
            if (KiemTraDaKhoa(ngay, madv))
                return (false, "Sổ đã bị khóa, không thể sửa!");

            bool daBaoCu = KiemTraDaBao(ngay, mabuoi, madv);

            // ── Nếu đã báo: vô hiệu hóa phiên cũ (1→0) ──
            if (daBaoCu)
                D_BQS.VoHieuHoaCatCom(ngay, mabuoi, madv);

            // ── Insert Cat_com mới (trang_thai=1) ─────────
            foreach (int maquan in dsKhongAn)
            {
                D_BQS.InsertCatCom(new catcom
                {
                    ngay_thang_nam = ngay,
                    buoian_id = mabuoi,
                    donvi_id = madv,
                    quannhan_id = maquan,
                    trang_thai = (int)TrangThaiCatComEnum.HieuLuc
                });
            }

            // ── Tính + UPSERT Quan_so_an ──────────────────
            for (int chedo = 1; chedo <= 2; chedo++)
            {
                int total = countQSCheDo(madv, chedo);
                int khongan = dsKhongAn.Count(mq => getCheDoByMaQN(mq) == chedo);

                D_BQS.UpsertQuanSoAn(new quansoan
                {
                    ngay_thang_nam = ngay,
                    buoian_id = mabuoi,
                    chedo_id = chedo,
                    donvi_id = madv,
                 soluong = total - khongan
                });
            }

            string msg = daBaoCu
                ? "Đã sửa lại báo quân số thành công!"
                : "Lưu báo quân số thành công!";

            return (true, msg);
        }

        // ──────────────────────────────────────────────────
        // KHÓA SỔ THỦ CÔNG (hậu cần nhấn nút)
        // ──────────────────────────────────────────────────
        public static (bool ok, string thongBao) KhoaSoThuCong(
            DateTime ngay, int madv, int nguoiKhoa)
        {
            if (KiemTraDaKhoa(ngay, madv))
                return (false, "Sổ đã khóa rồi!");

            D_BQS.KhoaSo(ngay, madv, nguoiKhoa, "Khóa thủ công");
            return (true, "Đã khóa sổ thành công!");
        }

        // ──────────────────────────────────────────────────
        // KHÓA SỔ TỰ ĐỘNG (gọi từ Timer 19:00)
        // ──────────────────────────────────────────────────
        public static void KhoaSoTuDong(DateTime ngay, int madv)
        {
            if (!D_BQS.KiemTraDaKhoaSo(ngay, madv))
                D_BQS.KhoaSo(ngay, madv, 0, "Tự động khóa lúc 19:00");
        }

        // ──────────────────────────────────────────────────
        // Kiểm tra đủ 3 buổi chưa
        // ──────────────────────────────────────────────────
        public static bool KiemTraDu3Buoi(DateTime ngay, int madv)
        {
            bool sang = KiemTraDaBao(ngay, 1, madv);
            bool trua = KiemTraDaBao(ngay, 2, madv);
            bool chieu = KiemTraDaBao(ngay, 3, madv);
            return sang && trua && chieu;
        }
    }


    }

