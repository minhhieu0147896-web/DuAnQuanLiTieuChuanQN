using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DuAn.BUL;
using System.Globalization;
using System.Text;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmThemMonAn : Form
    {
        private DataTable dtChiTiet;  // Bảng dữ liệu tạm chứa nguyên liệu đã thêm
        private DataTable dtThucPhamNguon;
        private bool dangLocThucPham;
        private int tabHienTai = 0;     // 0 = Thêm, 1 = Sửa, 2 = Xóa
        private int monanIdDangChon;    // ID món đang sửa hoặc đang xem để xóa

        public frmThemMonAn()
        {
            InitializeComponent();
            cboThucPham.TextUpdate += cboThucPham_TextUpdate;
            cboThucPham.Leave += cboThucPham_Leave;
            cboThucPham.KeyDown += cboThucPham_KeyDown;
        }

        private void frmThemMonAn_Load(object sender, EventArgs e)
        {
            KhoiTaoGridChiTiet();
            LoadMaMonMoi();
            LoadComboBoxes();
            ChuyenTab(0); // Mặc định tab Thêm
        }

        // =====================================================
        //  KHỞI TẠO GIAO DIỆN
        // =====================================================

        /// <summary>
        /// Tạo DataTable làm nguồn cho DataGridView chi tiết nguyên liệu
        /// </summary>
        private void KhoiTaoGridChiTiet()
        {
            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("Stt", typeof(int));
            dtChiTiet.Columns.Add("ThucPhamId", typeof(int));
            dtChiTiet.Columns.Add("ThucPhamTen", typeof(string));
            dtChiTiet.Columns.Add("CheDoId", typeof(int));
            dtChiTiet.Columns.Add("CheDoTen", typeof(string));
            dtChiTiet.Columns.Add("TyLe", typeof(decimal));

            dgvChiTiet.Columns.Clear();
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.DataSource = dtChiTiet;

            // Cột Stt
            DataGridViewTextBoxColumn colStt = new DataGridViewTextBoxColumn();
            colStt.DataPropertyName = "Stt";
            colStt.HeaderText = "Stt";
            colStt.Width = 40;
            colStt.ReadOnly = true;
            dgvChiTiet.Columns.Add(colStt);

            // Cột Thực phẩm
            DataGridViewTextBoxColumn colTP = new DataGridViewTextBoxColumn();
            colTP.DataPropertyName = "ThucPhamTen";
            colTP.HeaderText = "Thực phẩm";
            colTP.Width = 250;
            colTP.ReadOnly = true;
            dgvChiTiet.Columns.Add(colTP);

            // Cột Chế độ
            DataGridViewTextBoxColumn colCD = new DataGridViewTextBoxColumn();
            colCD.DataPropertyName = "CheDoTen";
            colCD.HeaderText = "Chế độ";
            colCD.Width = 120;
            colCD.ReadOnly = true;
            dgvChiTiet.Columns.Add(colCD);

            // Cột Tỷ lệ
            DataGridViewTextBoxColumn colTL = new DataGridViewTextBoxColumn();
            colTL.DataPropertyName = "TyLe";
            colTL.HeaderText = "Tỷ lệ";
            colTL.Width = 100;
            colTL.ReadOnly = true;
            colTL.DefaultCellStyle.Format = "N4";
            dgvChiTiet.Columns.Add(colTL);
        }

        /// <summary>
        /// Lấy mã món ăn mới và hiển thị lên txtMaMon
        /// </summary>
        private void LoadMaMonMoi()
        {
            try
            {
                int maMoi = B_MonAn.LayMaMoi();
                txtMaMon.Text = maMoi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lấy mã món mới: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaMon.Text = "?";
            }
        }

        /// <summary>
        /// Load dữ liệu cho ComboBox: Thực phẩm, Chế độ
        /// </summary>
        private void LoadComboBoxes()
        {
            try
            {
                // ComboBox Thực phẩm
                dtThucPhamNguon = B_MonAn.LayDanhSachThucPham();
                cboThucPham.DropDownStyle = ComboBoxStyle.DropDown;
                cboThucPham.AutoCompleteMode = AutoCompleteMode.None;
                BindThucPham(dtThucPhamNguon);
                cboThucPham.SelectedIndex = dtThucPhamNguon.Rows.Count > 0 ? 0 : -1;

                // ComboBox Chế độ
                DataTable dtCD = B_MonAn.LayDanhSachCheDo();
                cboCheDo.DataSource = dtCD;
                cboCheDo.DisplayMember = "chedo_ten";
                cboCheDo.ValueMember = "chedo_id";
                cboCheDo.SelectedIndex = dtCD.Rows.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboThucPham_TextUpdate(object sender, EventArgs e)
        {
            if (dangLocThucPham || dtThucPhamNguon == null)
                return;

            string tuKhoa = cboThucPham.Text;
            int viTriConTro = cboThucPham.SelectionStart;
            DataTable ketQua = LocThucPham(tuKhoa);

            dangLocThucPham = true;
            try
            {
                BindThucPham(ketQua);
                cboThucPham.Text = tuKhoa;
                cboThucPham.SelectionStart = Math.Min(viTriConTro, cboThucPham.Text.Length);
                cboThucPham.SelectionLength = 0;
                cboThucPham.DroppedDown = ketQua.Rows.Count > 0;
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                dangLocThucPham = false;
            }
        }

        private void cboThucPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChonThucPhamTheoTenDangNhap(true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cboThucPham_Leave(object sender, EventArgs e)
        {
            ChonThucPhamTheoTenDangNhap(false);
        }

        private void BindThucPham(DataTable data)
        {
            cboThucPham.DataSource = null;
            cboThucPham.DisplayMember = "thucpham_ten";
            cboThucPham.ValueMember = "thucpham_id";
            cboThucPham.DataSource = data;
        }

        private DataTable LocThucPham(string tuKhoa)
        {
            if (dtThucPhamNguon == null)
                return new DataTable();

            if (string.IsNullOrWhiteSpace(tuKhoa))
                return dtThucPhamNguon.Copy();

            string tuKhoaChuanHoa = ChuanHoaChuoi(tuKhoa);
            DataTable ketQua = dtThucPhamNguon.Clone();

            foreach (DataRow row in dtThucPhamNguon.Rows)
            {
                string tenThucPham = Convert.ToString(row["thucpham_ten"]);
                if (ChuanHoaChuoi(tenThucPham).Contains(tuKhoaChuanHoa))
                    ketQua.ImportRow(row);
            }

            return ketQua;
        }

        private bool ChonThucPhamTheoTenDangNhap(bool hienThongBaoLoi)
        {
            if (dtThucPhamNguon == null || string.IsNullOrWhiteSpace(cboThucPham.Text))
                return false;

            string tenDangNhap = ChuanHoaChuoi(cboThucPham.Text);
            DataRow dongKhop = null;

            foreach (DataRow row in dtThucPhamNguon.Rows)
            {
                string tenThucPham = ChuanHoaChuoi(Convert.ToString(row["thucpham_ten"]));
                if (tenThucPham == tenDangNhap)
                {
                    dongKhop = row;
                    break;
                }
            }

            if (dongKhop == null)
            {
                if (hienThongBaoLoi)
                {
                    MessageBox.Show("Thực phẩm này chưa có trong cơ sở dữ liệu. Vui lòng chọn thực phẩm có sẵn trong danh sách.",
                        "Không tìm thấy thực phẩm",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    LamTrongCboThucPham();
                }

                return false;
            }

            dangLocThucPham = true;
            try
            {
                BindThucPham(dtThucPhamNguon);
                cboThucPham.SelectedValue = Convert.ToInt32(dongKhop["thucpham_id"]);
                cboThucPham.SelectionStart = cboThucPham.Text.Length;
                cboThucPham.SelectionLength = 0;
            }
            finally
            {
                dangLocThucPham = false;
            }

            return true;
        }

        private void LamTrongCboThucPham()
        {
            dangLocThucPham = true;
            try
            {
                BindThucPham(dtThucPhamNguon);
                cboThucPham.SelectedIndex = -1;
                cboThucPham.Text = string.Empty;
                cboThucPham.DroppedDown = false;
            }
            finally
            {
                dangLocThucPham = false;
            }
        }

        private static string ChuanHoaChuoi(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            string formD = value.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            foreach (char c in formD)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                    builder.Append(c);
            }

            return builder.ToString()
                .Replace("đ", "d")
                .Normalize(NormalizationForm.FormC);
        }

        // =====================================================
        //  XỬ LÝ NGUYÊN LIỆU
        // =====================================================

        /// <summary>
        /// Thêm một nguyên liệu vào danh sách
        /// </summary>
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (!ChonThucPhamTheoTenDangNhap(false)
                && !string.IsNullOrWhiteSpace(cboThucPham.Text))
            {
                MessageBox.Show("Thực phẩm này chưa có trong cơ sở dữ liệu. Vui lòng chọn thực phẩm có sẵn trong danh sách.",
                    "Không tìm thấy thực phẩm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                LamTrongCboThucPham();
                cboThucPham.Focus();
                return;
            }

            // Validate chọn thực phẩm
            if (cboThucPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thực phẩm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboThucPham.Focus();
                return;
            }

            // Validate chọn chế độ
            if (cboCheDo.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chế độ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCheDo.Focus();
                return;
            }

            int thucPhamId = Convert.ToInt32(cboThucPham.SelectedValue);
            string thucPhamTen = cboThucPham.Text;
            int cheDoId = Convert.ToInt32(cboCheDo.SelectedValue);
            string cheDoTen = cboCheDo.Text;

            // Parse tỷ lệ
            if (string.IsNullOrWhiteSpace(txtTyLe.Text))
            {
                MessageBox.Show("Vui lòng nhập tỷ lệ nguyên liệu.\nVí dụ: 0.5 nghĩa là 50%.",
                    "Thiếu tỷ lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTyLe.Focus();
                return;
            }

            if (!decimal.TryParse(txtTyLe.Text, out decimal tyLe))
            {
                MessageBox.Show("Tỷ lệ phải là số thập phân hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTyLe.Focus();
                return;
            }

            // Validate: ty_le phải > 0 và <= 1 (theo CHECK constraint CHK_CTMA_TyLe)
            if (tyLe <= 0 || tyLe > 1)
            {
                MessageBox.Show("Tỷ lệ phải lớn hơn 0 và không vượt quá 1.\nVí dụ: 0.5 nghĩa là 50%.",
                    "Tỷ lệ không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTyLe.Focus();
                return;
            }

            // Kiểm tra trùng: cùng thực phẩm + chế độ đã có trong lưới chưa
            foreach (DataRow row in dtChiTiet.Rows)
            {
                if (Convert.ToInt32(row["ThucPhamId"]) == thucPhamId &&
                    Convert.ToInt32(row["CheDoId"]) == cheDoId)
                {
                    MessageBox.Show("Nguyên liệu này đã tồn tại trong danh sách.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Thêm vào DataTable
            DataRow newRow = dtChiTiet.NewRow();
            newRow["Stt"] = dtChiTiet.Rows.Count + 1;
            newRow["ThucPhamId"] = thucPhamId;
            newRow["ThucPhamTen"] = thucPhamTen;
            newRow["CheDoId"] = cheDoId;
            newRow["CheDoTen"] = cheDoTen;
            newRow["TyLe"] = tyLe;
            dtChiTiet.Rows.Add(newRow);

            // Reset input để nhập tiếp
            txtTyLe.Clear();
            BindThucPham(dtThucPhamNguon);
            if (dtThucPhamNguon != null && dtThucPhamNguon.Rows.Count > 0)
                cboThucPham.SelectedIndex = 0;
            cboThucPham.Focus();
        }

        /// <summary>
        /// Xóa dòng nguyên liệu đang chọn khỏi danh sách
        /// </summary>
        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xóa khỏi DataTable, DGV tự cập nhật
            DataRowView drv = (DataRowView)dgvChiTiet.CurrentRow.DataBoundItem;
            dtChiTiet.Rows.Remove(drv.Row);

            // Cập nhật lại số Stt
            for (int i = 0; i < dtChiTiet.Rows.Count; i++)
                dtChiTiet.Rows[i]["Stt"] = i + 1;
        }

        // =====================================================
        //  LƯU & HỦY
        // =====================================================

        /// <summary>
        /// Lưu món ăn (Thêm mới hoặc Cập nhật tùy theo tab)
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // ----- Validate dữ liệu nhập -----
            if (!ValidateInput()) return;

            try
            {
                int monanId = Convert.ToInt32(txtMaMon.Text);
                string tenMon = txtTenMon.Text.Trim();
                string loaiMon = MapLoaiMon(cboLoaiMon.Text);
                string ghiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text)
                    ? null : txtGhiChu.Text.Trim();
                double dam = ParseRequiredDouble(txtDam.Text);
                double chatBeo = ParseRequiredDouble(txtChatBeo.Text);
                double chatXo = ParseRequiredDouble(txtChatXo.Text);

                if (tabHienTai == 0) // Tab Thêm: INSERT
                {
                    B_MonAn.ThemMonAn(monanId, tenMon, loaiMon, ghiChu, dam, chatBeo, chatXo);
                }
                else // Tab Sửa: UPDATE (sp_MonAn_CapNhat đã xóa nguyên liệu cũ)
                {
                    B_MonAn.CapNhatMonAn(monanId, tenMon, loaiMon, ghiChu, dam, chatBeo, chatXo);
                }

                // INSERT từng dòng nguyên liệu (dùng chung cho cả Thêm và Sửa)
                int ctSuccess = 0;
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    int thucPhamId = Convert.ToInt32(row["ThucPhamId"]);
                    int cheDoId = Convert.ToInt32(row["CheDoId"]);
                    decimal tyLe = Convert.ToDecimal(row["TyLe"]);

                    B_MonAn.ThemChiTietMonAn(monanId, thucPhamId, cheDoId, tyLe);
                    ctSuccess++;
                }

                string hanhDong = tabHienTai == 0 ? "thêm" : "cập nhật";
                MessageBox.Show(
                    $"Đã {hanhDong} món \"{tenMon}\" thành công!\n" +
                    $"{ctSuccess}/{dtChiTiet.Rows.Count} nguyên liệu đã được lưu.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu món ăn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hủy bỏ - đóng form
        /// </summary>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =====================================================
        //  HÀM HỖ TRỢ
        // =====================================================

        /// <summary>
        /// Validate dữ liệu trước khi lưu
        /// </summary>
        private bool ValidateInput()
        {
            // Tên món không được trống
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return false;
            }

            // Phải chọn loại món
            if (cboLoaiMon.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại món.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiMon.Focus();
                return false;
            }

            if (!ValidateRequiredDouble(txtDam.Text, "Đạm", txtDam)) return false;
            if (!ValidateRequiredDouble(txtChatBeo.Text, "Chất béo", txtChatBeo)) return false;
            if (!ValidateRequiredDouble(txtChatXo.Text, "Chất xơ", txtChatXo)) return false;

            // Phải có ít nhất một nguyên liệu
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Món ăn phải có ít nhất một nguyên liệu.",
                    "Thiếu nguyên liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboThucPham.Focus();
                return false;
            }

            foreach (DataRow row in dtChiTiet.Rows)
            {
                if (row["ThucPhamId"] == DBNull.Value
                    || row["CheDoId"] == DBNull.Value
                    || row["TyLe"] == DBNull.Value
                    || Convert.ToDecimal(row["TyLe"]) <= 0
                    || Convert.ToDecimal(row["TyLe"]) > 1)
                {
                    MessageBox.Show("Danh sách nguyên liệu có dữ liệu chưa hợp lệ. Mỗi nguyên liệu phải có thực phẩm, chế độ và tỷ lệ trong khoảng 0 đến 1.",
                        "Nguyên liệu không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Chuyển đổi tên hiển thị loại món sang giá trị lưu trong DB
        /// VD: "Mặn Chính" → "ManChinh", "Tráng Miệng" → "TrangMieng"
        /// </summary>
        private string MapLoaiMon(string hienThi)
        {
            switch (hienThi)
            {
                case "Mặn Chính":   return "ManChinh";
                case "Canh":        return "Canh";
                case "Rau":         return "Rau";
                case "Tráng Miệng": return "TrangMieng";
                case "Sữa":         return "Sua";
                default:            return hienThi;
            }
        }

        /// <summary>
        /// Parse string sang double? (nullable)
        /// </summary>
        private double ParseRequiredDouble(string text)
        {
            double.TryParse(text.Trim(), out double val);
            return val;
        }

        private bool ValidateRequiredDouble(string text, string fieldName, Control control)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Vui lòng nhập " + fieldName + ".",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                control.Focus();
                return false;
            }

            if (!double.TryParse(text.Trim(), out double value) || value < 0)
            {
                MessageBox.Show(fieldName + " phải là số không âm.",
                    "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                control.Focus();
                return false;
            }

            return true;
        }

        // =====================================================
        //  TAB: CHUYỂN TAB + TÌM KIẾM + SỬA + XÓA
        // =====================================================

        /// <summary>
        /// Chuyển tab: 0=Thêm, 1=Sửa, 2=Xóa
        /// </summary>
        private void ChuyenTab(int tab)
        {
            tabHienTai = tab;

            // Highlight nút tab đang chọn
            Color colorActive = Color.FromArgb(46, 204, 133);  // xanh lá
            Color colorInactive = Color.FromArgb(100, 100, 100); // xám
            btnTabThem.BackColor = tab == 0 ? colorActive : colorInactive;
            btnTabSua.BackColor = tab == 1 ? colorActive : colorInactive;
            btnTabXoa.BackColor = tab == 2 ? colorActive : colorInactive;

            // Ẩn/hiện ô tìm kiếm và nút xóa
            txtTimKiem.Visible = (tab == 1 || tab == 2);
            btnXoaMon.Visible = (tab == 2);
            btnLuu.Visible = (tab != 2);  // Ẩn nút LƯU ở tab Xóa

            // Đổi tiêu đề form
            string[] titles = { "THÊM MÓN ĂN MỚI", "SỬA MÓN ĂN", "XÓA MÓN ĂN" };
            lblTitle.Text = titles[tab];

            // Reset form
            txtTimKiem.Text = "";
            txtTimKiem.ForeColor = Color.Gray;
            txtTimKiem.Text = "🔍 Tìm món ăn...";

            if (tab == 0) // Tab Thêm: reset form để thêm mới
            {
                LoadMaMonMoi();
                txtMaMon.ReadOnly = false;
                txtTenMon.Clear();
                cboLoaiMon.SelectedIndex = -1;
                txtGhiChu.Clear();
                txtDam.Clear();
                txtChatBeo.Clear();
                txtChatXo.Clear();
                dtChiTiet.Rows.Clear();
                btnLuu.Text = "LƯU";
                monanIdDangChon = 0;
            }
            else // Tab Sửa / Xóa: khóa mã món
            {
                txtMaMon.ReadOnly = true;
                btnLuu.Text = "LƯU";
            }
        }

        private void btnTabThem_Click(object sender, EventArgs e)
        {
            ChuyenTab(0);
        }

        private void btnTabSua_Click(object sender, EventArgs e)
        {
            ChuyenTab(1);
        }

        private void btnTabXoa_Click(object sender, EventArgs e)
        {
            ChuyenTab(2);
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "🔍 Tìm món ăn...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "🔍 Tìm món ăn...";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Khi gõ text tìm kiếm → lọc và hiển thị món gợi ý
        /// </summary>
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(tuKhoa) || tuKhoa == "🔍 Tìm món ăn...")
                return;

            try
            {
                DataTable ketQua = B_MonAn.TimKiemMonAn(tuKhoa);

                if (ketQua.Rows.Count == 1)
                {
                    // Chỉ có 1 kết quả → khôi phục grid rồi load thẳng lên form
                    KhoiTaoGridChiTiet();
                    int monanId = Convert.ToInt32(ketQua.Rows[0]["monan_id"]);
                    LoadMonAnLenForm(monanId);
                }
                else if (ketQua.Rows.Count > 1)
                {
                    // Nhiều kết quả → hiển thị danh sách để chọn qua DataGridView tạm
                    HienThiKetQuaTimKiem(ketQua);
                }
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi tìm kiếm
            }
        }

        /// <summary>
        /// Load thông tin món ăn lên form từ ID
        /// </summary>
        private void LoadMonAnLenForm(int monanId)
        {
            try
            {
                DataSet ds = B_MonAn.LayMonAnTheoId(monanId);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy món ăn này.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow monAn = ds.Tables[0].Rows[0];
                monanIdDangChon = monanId;

                // Hiển thị thông tin món
                txtMaMon.Text = monAn["monan_id"].ToString();
                txtTenMon.Text = monAn["monan_ten"].ToString();

                // Map loại món từ DB sang hiển thị
                string loaiDB = monAn["monan_loaimon"].ToString();
                cboLoaiMon.Text = MapLoaiMonNguoc(loaiDB);

                txtGhiChu.Text = monAn["ghi_chu"].ToString();
                txtDam.Text = Convert.ToDouble(monAn["dam"]).ToString("0.##");
                txtChatBeo.Text = Convert.ToDouble(monAn["chat_beo"]).ToString("0.##");
                txtChatXo.Text = Convert.ToDouble(monAn["chat_xo"]).ToString("0.##");

                // Load nguyên liệu
                dtChiTiet.Rows.Clear();
                int stt = 1;
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    dtChiTiet.Rows.Add(
                        stt++,
                        Convert.ToInt32(row["thucpham_id"]),
                        row["thucpham_ten"].ToString(),
                        Convert.ToInt32(row["chedo_id"]),
                        row["chedo_ten"].ToString(),
                        Convert.ToDecimal(row["ty_le"])
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load món ăn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị danh sách kết quả tìm kiếm lên DataGridView để người dùng chọn
        /// </summary>
        private void HienThiKetQuaTimKiem(DataTable ketQua)
        {
            // Dùng DataGridView hiện tại để hiển thị danh sách món tìm được
            // Lưu DataTable tạm để sau khi chọn xong có thể khôi phục
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.AutoGenerateColumns = true;
            dgvChiTiet.DataSource = ketQua;

            // Gán sự kiện double-click để chọn món
            dgvChiTiet.CellDoubleClick -= DgvTimKiem_CellDoubleClick;
            dgvChiTiet.CellDoubleClick += DgvTimKiem_CellDoubleClick;
        }

        private void DgvTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int monanId = Convert.ToInt32(dgvChiTiet.Rows[e.RowIndex].Cells["monan_id"].Value);

            // Khôi phục DataGridView về trạng thái nguyên liệu TRƯỚC KHI load
            KhoiTaoGridChiTiet();

            // Sau đó mới load dữ liệu món vào dtChiTiet
            LoadMonAnLenForm(monanId);
        }

        /// <summary>
        /// Map loại món từ DB (vd: "ManChinh") → hiển thị (vd: "Mặn Chính")
        /// </summary>
        private string MapLoaiMonNguoc(string loaiDB)
        {
            switch (loaiDB)
            {
                case "ManChinh":    return "Mặn Chính";
                case "Canh":        return "Canh";
                case "Rau":         return "Rau";
                case "TrangMieng":  return "Tráng Miệng";
                case "Sua":         return "Sữa";
                case "Com":         return "Cơm";
                default:            return loaiDB;
            }
        }

        /// <summary>
        /// Nút XÓA MÓN ĂN (tab Xóa)
        /// </summary>
        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (monanIdDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa bằng cách tìm kiếm.",
                    "Chưa chọn món", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenMon = txtTenMon.Text;
            var xacNhan = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa món \"{tenMon}\"?\n\nTất cả nguyên liệu của món này cũng sẽ bị xóa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (xacNhan != DialogResult.Yes) return;

            try
            {
                bool ok = B_MonAn.XoaMonAn(monanIdDangChon);

                if (ok)
                {
                    MessageBox.Show($"Đã xóa món \"{tenMon}\" thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể xóa món ăn. Có thể món đang được sử dụng.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa món ăn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
