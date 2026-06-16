using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using DuAn.BUL;
using DuAn.DTO;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmtinhtpcansudung : Form
    {
        public frmtinhtpcansudung()
        {
            InitializeComponent();
            KhoiTaoForm();
        }

        /// <summary>
        /// Khởi tạo giao diện: đổ dữ liệu ComboBox buổi, set ngày mặc định
        /// </summary>
        private void KhoiTaoForm()
        {
            // Thêm các mục buổi: Tất cả, Sáng, Trưa, Chiều
            cbobuoi.Items.Clear();
            cbobuoi.Items.Add(new BuoiComboItem { HienThi = "Tất cả", BuoiAnId = null });
            cbobuoi.Items.Add(new BuoiComboItem { HienThi = "Sáng",  BuoiAnId = 1 });
            cbobuoi.Items.Add(new BuoiComboItem { HienThi = "Trưa",  BuoiAnId = 2 });
            cbobuoi.Items.Add(new BuoiComboItem { HienThi = "Chiều", BuoiAnId = 3 });
            cbobuoi.DisplayMember = "HienThi";
            cbobuoi.ValueMember = "BuoiAnId";
            cbobuoi.SelectedIndex = 0; // Mặc định chọn "Tất cả"

            // Ngày mặc định là hôm nay
            dateTimePicker1.Value = DateTime.Today;

            // Gán sự kiện cho nút
            btnhienthi.Click += btnhienthi_Click;
            btnluu.Click += btnluu_Click;
        }

        /// <summary>
        /// Nút "Tính thực phẩm": gọi procedure và hiển thị kết quả
        /// </summary>
        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dateTimePicker1.Value.Date;
                BuoiComboItem buoiChon = cbobuoi.SelectedItem as BuoiComboItem;
                int? buoianId = buoiChon?.BuoiAnId; // null nghĩa là Tất cả

                int donviId = Session.DonViID ?? 0;
                if (donviId == 0)
                {
                    MessageBox.Show("Không xác định được đơn vị. Vui lòng đăng nhập lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = B_TinhThucPham.TinhThucPham(ngay, buoianId, donviId);

                HienThiKetQua(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính thực phẩm:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị kết quả lên DataGridView và cập nhật tổng kết
        /// </summary>
        private void HienThiKetQua(DataTable dt)
        {
            dgvlscc.DataSource = null;
            dgvlscc.Columns.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thực phẩm cho ngày/buổi đã chọn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label4.Text = "0";
                lblso.Text = "0";
                return;
            }

            // Tạo cột STT
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "STT";
            colSTT.Name = "colstt";
            colSTT.FillWeight = 8;
            colSTT.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colSTT.Width = 50;

            // Tạo các cột dữ liệu
            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.HeaderText = "Thực phẩm";
            colTen.DataPropertyName = "TenThucPham";
            colTen.FillWeight = 40;

            DataGridViewTextBoxColumn colDonVi = new DataGridViewTextBoxColumn();
            colDonVi.HeaderText = "Đơn vị";
            colDonVi.DataPropertyName = "DonViTinh";
            colDonVi.FillWeight = 15;

            DataGridViewTextBoxColumn colSL = new DataGridViewTextBoxColumn();
            colSL.HeaderText = "Tổng số lượng";
            colSL.DataPropertyName = "TongSoLuong";
            colSL.DefaultCellStyle.Format = "N2";
            colSL.FillWeight = 20;

            DataGridViewTextBoxColumn colTien = new DataGridViewTextBoxColumn();
            colTien.HeaderText = "Tổng tiền";
            colTien.DataPropertyName = "TongTien";
            colTien.DefaultCellStyle.Format = "N0";
            colTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTien.FillWeight = 20;

            dgvlscc.Columns.AddRange(new DataGridViewColumn[] {
                colSTT, colTen, colDonVi, colSL, colTien
            });

            dgvlscc.AutoGenerateColumns = false;
            dgvlscc.DataSource = dt;

            // Đánh số STT
            for (int i = 0; i < dgvlscc.Rows.Count; i++)
                dgvlscc.Rows[i].Cells[0].Value = i + 1;

            // Cập nhật tổng kết
            double tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                double tien;
                if (double.TryParse(row["TongTien"].ToString(),
                    NumberStyles.Any, CultureInfo.InvariantCulture, out tien))
                    tongTien += tien;
            }

            label4.Text = dt.Rows.Count.ToString();
            lblso.Text = tongTien.ToString("N0") + " đ";
        }

        /// <summary>
        /// Nút "Lưu": xuất kết quả ra file Excel (đơn giản: copy vào clipboard)
        /// </summary>
        private void btnluu_Click(object sender, EventArgs e)
        {
            if (dgvlscc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Copy nội dung DataGridView vào clipboard, ngăn cách bằng tab
                dgvlscc.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                dgvlscc.SelectAll();
                DataObject dataObj = dgvlscc.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);

                MessageBox.Show("Đã sao chép dữ liệu vào clipboard.\n"
                    + "Bạn có thể dán (Ctrl+V) vào Excel.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void pnlfilter_Paint(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
    }

    /// <summary>
    /// Item cho ComboBox buổi: lưu cả tên hiển thị và giá trị buoian_id
    /// </summary>
    internal class BuoiComboItem
    {
        public string HienThi { get; set; }
        public int? BuoiAnId { get; set; }
    }
}
