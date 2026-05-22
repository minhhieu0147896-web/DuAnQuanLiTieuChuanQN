using System;
using System.Data;
using System.Windows.Forms;
using DuAn.BUL;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmThemMonAn : Form
    {
        private DataTable dtChiTiet;  // Bảng dữ liệu tạm chứa nguyên liệu đã thêm

        public frmThemMonAn()
        {
            InitializeComponent();
        }

        private void frmThemMonAn_Load(object sender, EventArgs e)
        {
            KhoiTaoGridChiTiet();
            LoadMaMonMoi();
            LoadComboBoxes();
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
                DataTable dtTP = B_MonAn.LayDanhSachThucPham();
                cboThucPham.DataSource = dtTP;
                cboThucPham.DisplayMember = "thucpham_ten";
                cboThucPham.ValueMember = "thucpham_id";
                cboThucPham.SelectedIndex = dtTP.Rows.Count > 0 ? 0 : -1;

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

        // =====================================================
        //  XỬ LÝ NGUYÊN LIỆU
        // =====================================================

        /// <summary>
        /// Thêm một nguyên liệu vào danh sách
        /// </summary>
        private void btnThemNL_Click(object sender, EventArgs e)
        {
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

            // Parse tỷ lệ (có thể để trống → lưu NULL vào DB)
            object tyLeValue = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(txtTyLe.Text))
            {
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
                tyLeValue = tyLe;
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
            newRow["TyLe"] = tyLeValue;
            dtChiTiet.Rows.Add(newRow);

            // Reset input để nhập tiếp
            txtTyLe.Clear();
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
        /// Lưu món ăn mới vào database
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // ----- Validate dữ liệu nhập -----
            if (!ValidateInput()) return;

            try
            {
                // Lấy dữ liệu từ form
                int monanId = Convert.ToInt32(txtMaMon.Text);
                string tenMon = txtTenMon.Text.Trim();
                string loaiMon = MapLoaiMon(cboLoaiMon.Text);  // Chuyển "Mặn Chính" → "ManChinh"
                string ghiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text)
                    ? null : txtGhiChu.Text.Trim();

                double? dam = ParseNullableDouble(txtDam.Text);
                double? chatBeo = ParseNullableDouble(txtChatBeo.Text);
                double? chatXo = ParseNullableDouble(txtChatXo.Text);

                // ----- 1. INSERT vào Mon_an -----
                B_MonAn.ThemMonAn(monanId, tenMon, loaiMon, ghiChu, dam, chatBeo, chatXo);

                // ----- 2. INSERT từng dòng vào Chi_tiet_mon_an -----
                int ctSuccess = 0;
                foreach (DataRow row in dtChiTiet.Rows)
                {
                    int thucPhamId = Convert.ToInt32(row["ThucPhamId"]);
                    int cheDoId = Convert.ToInt32(row["CheDoId"]);
                    decimal? tyLe = row["TyLe"] == DBNull.Value ? (decimal?)null
                        : Convert.ToDecimal(row["TyLe"]);

                    B_MonAn.ThemChiTietMonAn(monanId, thucPhamId, cheDoId, tyLe);
                    ctSuccess++;
                }

                // ----- 3. Thông báo kết quả -----
                MessageBox.Show(
                    $"Đã thêm món \"{tenMon}\" thành công!\n" +
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

            // Cảnh báo nếu chưa thêm nguyên liệu nào
            if (dtChiTiet.Rows.Count == 0)
            {
                DialogResult dr = MessageBox.Show(
                    "Bạn chưa thêm nguyên liệu nào. Bạn có muốn tiếp tục lưu không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return false;
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
        private double? ParseNullableDouble(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return null;
            if (double.TryParse(text.Trim(), out double val)) return val;
            return null;
        }
    }
}
