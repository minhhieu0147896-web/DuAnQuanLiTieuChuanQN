using DuAn.BUL;
using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmChiTietNgay : Form
    {
        // Dữ liệu đầu vào
        private readonly DateTime _ngay;
        private readonly int _cheDoId;
        private readonly string _tenCheDo;
        private readonly List<MonAnTheoBuoi> _dsMonTrongNgay;

        public frmChiTietNgay(DateTime ngay, int cheDoId, string tenCheDo,
            List<MonAnTheoBuoi> dsMonTrongNgay)
        {
            _ngay = ngay.Date;
            _cheDoId = cheDoId;
            _tenCheDo = tenCheDo;
            _dsMonTrongNgay = dsMonTrongNgay ?? new List<MonAnTheoBuoi>();

            InitializeComponent();
            btnDong.Click += (s, e) => Close();
            Load += frmChiTietNgay_Load;
        }

        private void frmChiTietNgay_Load(object sender, EventArgs e)
        {
            // Hiển thị tiêu đề
            string thuTiengViet = LayThuTiengViet(_ngay);
            lblTieuDe.Text = string.Format("Chi tiết ngày {0}, {1}",
                thuTiengViet, _ngay.ToString("dd/MM/yyyy"));
            lblCheDo.Text = "Chế độ: " + _tenCheDo;

            // Nạp 2 tab
            HienThiTabMonAn();
            HienThiTabNguyenLieu();
        }

        // =====================================================
        //  TAB 1: DANH SÁCH MÓN ĂN TRONG NGÀY
        // =====================================================

        /// <summary>
        /// Hiển thị tất cả món ăn đã chọn trong ngày (Sáng + Trưa + Chiều)
        /// </summary>
        private void HienThiTabMonAn()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaMon", typeof(int));
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("TenBuoi", typeof(string));
            dt.Columns.Add("LoaiMon", typeof(string));

            foreach (MonAnTheoBuoi mon in _dsMonTrongNgay)
            {
                DataRow row = dt.NewRow();
                row["MaMon"] = mon.MonAnId;
                row["TenMon"] = mon.TenMon;
                row["TenBuoi"] = mon.TenBuoi;
                row["LoaiMon"] = mon.LoaiMon;
                dt.Rows.Add(row);
            }

            dgvMonTrongNgay.DataSource = dt;
        }

        // =====================================================
        //  TAB 2: NGUYÊN LIỆU TỔNG (GỘP TỪ TẤT CẢ MÓN)
        // =====================================================

        /// <summary>
        /// Gọi procedure lấy nguyên liệu từng món, rồi gộp các nguyên liệu trùng tên
        /// </summary>
        private void HienThiTabNguyenLieu()
        {
            // Dictionary gộp nguyên liệu: Key = tên thực phẩm, Value = (định lượng, đơn vị)
            var dictGop = new Dictionary<string, NguyenLieuGop>();

            foreach (MonAnTheoBuoi mon in _dsMonTrongNgay)
            {
                try
                {
                    DataTable dtNL = B_MonAn.LayDanhSachNguyenLieu(mon.MonAnId, _cheDoId);

                    foreach (DataRow row in dtNL.Rows)
                    {
                        string tenTP = row["TenThucPham"].ToString();
                        string donVi = row["DonViTinh"].ToString();
                        double dinhLuong = 0;

                        if (row["DinhLuong"] != DBNull.Value)
                        {
                            double.TryParse(row["DinhLuong"].ToString(),
                                NumberStyles.Any, CultureInfo.InvariantCulture, out dinhLuong);
                        }

                        if (dictGop.ContainsKey(tenTP))
                        {
                            // Cộng dồn định lượng
                            dictGop[tenTP].DinhLuong += dinhLuong;
                        }
                        else
                        {
                            dictGop[tenTP] = new NguyenLieuGop
                            {
                                TenThucPham = tenTP,
                                DinhLuong = dinhLuong,
                                DonViTinh = donVi
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Bỏ qua lỗi từng món, vẫn hiển thị các món còn lại
                    System.Diagnostics.Debug.WriteLine(
                        "Lỗi lấy nguyên liệu món " + mon.TenMon + ": " + ex.Message);
                }
            }

            // Đổ vào DataTable để hiển thị
            DataTable dt = new DataTable();
            dt.Columns.Add("TenThucPham", typeof(string));
            dt.Columns.Add("DinhLuong", typeof(string));
            dt.Columns.Add("DonViTinh", typeof(string));

            foreach (var kvp in dictGop)
            {
                DataRow row = dt.NewRow();
                row["TenThucPham"] = kvp.Value.TenThucPham;
                row["DinhLuong"] = kvp.Value.DinhLuong.ToString("0.####");
                row["DonViTinh"] = kvp.Value.DonViTinh;
                dt.Rows.Add(row);
            }

            dgvNguyenLieuNgay.DataSource = dt;
        }

        // =====================================================
        //  TIỆN ÍCH
        // =====================================================

        /// <summary>
        /// Trả về tên thứ bằng tiếng Việt
        /// </summary>
        private string LayThuTiengViet(DateTime ngay)
        {
            string[] thu = { "Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4",
                             "Thứ 5", "Thứ 6", "Thứ 7" };
            return thu[(int)ngay.DayOfWeek];
        }
    }

    // =====================================================
    //  LỚP HỖ TRỢ (dùng chung trong form)
    // =====================================================

    /// <summary>
    /// DTO chứa thông tin món ăn kèm buổi (Sáng/Trưa/Chiều)
    /// </summary>
    public class MonAnTheoBuoi
    {
        public int MonAnId { get; set; }
        public string TenMon { get; set; }
        public string LoaiMon { get; set; }
        public string TenBuoi { get; set; }
        public double Dam { get; set; }
        public double ChatBeo { get; set; }
        public double ChatXo { get; set; }
    }

    /// <summary>
    /// Dùng để gộp nguyên liệu trùng tên (cộng dồn định lượng)
    /// </summary>
    internal class NguyenLieuGop
    {
        public string TenThucPham { get; set; }
        public double DinhLuong { get; set; }
        public string DonViTinh { get; set; }
    }
}
