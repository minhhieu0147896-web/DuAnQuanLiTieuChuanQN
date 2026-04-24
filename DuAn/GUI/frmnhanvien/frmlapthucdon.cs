using DuAn.DAO;
using DuAn.DTO;
using frmnhanvien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmnhanvien
{
    public partial class frmlapthucdon : Form
    {
        private int currentUserId = 1;
        private int currentCheDoId = 1;
        private ThucDonModel currentThucDon = null;

        public frmlapthucdon()
        {
            InitializeComponent();

            SetupDataGridView();
            LoadBuoiAn();
            LoadLoaiMon();

            dtpNgay.ValueChanged += dtpNgay_ValueChanged;
            cboBuoi.SelectedIndexChanged += cboBuoi_SelectedIndexChanged;
            cboLoaiMon.SelectedIndexChanged += cboLoaiMon_SelectedIndexChanged;
            btnThemVaoThucDon.Click += btnThemVaoThucDon_Click;
            btnhienthi.Click += btnhienthi_Click;
            btnluu.Click += btnluu_Click;
        }

        private void SetupDataGridView()
        {
            dgvThucDon.AutoGenerateColumns = false;
            dgvThucDon.Columns.Clear();

            dgvThucDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColLoaiMon",
                HeaderText = "Loại món",
                DataPropertyName = "LoaiMon",
                Width = 120
            });
            dgvThucDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColTenMon",
                HeaderText = "Tên món",
                DataPropertyName = "TenMon",
                Width = 250
            });
            dgvThucDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "ColMonAnId",
                DataPropertyName = "MonAnId",
                Visible = false
            });
        }

        private void LoadBuoiAn()
        {
            List<BuoiAnModel> dsBuoi = BuoiAnDAO.Instance.GetAll();
            cboBuoi.DataSource = dsBuoi;
            cboBuoi.DisplayMember = "TenBuoi";
            cboBuoi.ValueMember = "BuoiAnId";
            cboBuoi.SelectedIndex = -1;
        }
        private void LoadLoaiMon()
        {
            List<string> dsLoai = MonAnDAO.Instance.GetAllLoaiMon();
            cboLoaiMon.DataSource = dsLoai;
            cboLoaiMon.SelectedIndex = -1; // Không chọn mục nào ban đầu
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiMon.SelectedItem == null)
            {
                cboDanhSachMon.DataSource = null;
                return;
            }

            string loaiMon = cboLoaiMon.SelectedItem.ToString();
            List<MonAnModel> dsMon = MonAnDAO.Instance.GetByLoaiMon(loaiMon);

            cboDanhSachMon.DataSource = null;
            cboDanhSachMon.DataSource = dsMon;
            cboDanhSachMon.DisplayMember = "TenMon";
            cboDanhSachMon.ValueMember = "MonAnId";
            cboDanhSachMon.SelectedIndex = -1;
        }

        private void cboDanhSachMon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThemVaoThucDon_Click(object sender, EventArgs e)
        {
            if (!(cboBuoi.SelectedValue is int buoianId))
            {
                MessageBox.Show("Vui lòng chọn buổi ăn!", "Thông báo");
                return;
            }
            if (!(cboDanhSachMon.SelectedItem is MonAnModel mon))
            {
                MessageBox.Show("Vui lòng chọn món ăn!", "Thông báo");
                return;
            }

            DateTime ngay = dtpNgay.Value.Date;

            if (currentThucDon == null)
                currentThucDon = ThucDonDAO.Instance.GetOrCreate(currentUserId, currentCheDoId, ngay);

            bool success = ChiTietThucDonDAO.Instance.Insert(
                currentThucDon.ThucDonId,
                ngay,
                buoianId,
                mon.MonAnId
            );

            if (success)
            {
                LoadThucDonChiTiet();
                MessageBox.Show("Đã thêm món vào thực đơn!", "Thành công");
            }
            else
            {
                MessageBox.Show("Món này đã có trong buổi, hoặc xảy ra lỗi!", "Lỗi");
            }

        }

        private void dgvlscc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadThucDonChiTiet();
        }

        private void cboBuoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThucDonChiTiet();

        }

        private void cbocd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pntitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvThucDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            LoadThucDonChiTiet();

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (currentThucDon == null)
            {
                if (dtpNgay.Value != null)
                {
                    DateTime ngay = dtpNgay.Value.Date;
                    currentThucDon = ThucDonDAO.Instance.GetOrCreate(currentUserId, currentCheDoId, ngay);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ngày và buổi trước khi lưu!", "Thông báo");
                    return;
                }
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn lưu thực đơn tuần này không?\nTrạng thái sẽ chuyển thành 'Chờ duyệt'.",
                "Xác nhận lưu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            bool updateResult = ThucDonDAO.Instance.UpdateTrangThai(currentThucDon.ThucDonId, "ChoDuyet");

            if (updateResult)
            {
                currentThucDon.TrangThai = "ChoDuyet";
                MessageBox.Show("Lưu thực đơn tuần thành công! Trạng thái: Chờ duyệt.", "Thành công");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu thực đơn!", "Lỗi");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadThucDonChiTiet()
        {
            // Ép kiểu an toàn với pattern matching
            if (!(cboBuoi.SelectedValue is int buoianId) || dtpNgay.Value == null)
                return;

            DateTime ngay = dtpNgay.Value.Date;

            currentThucDon = ThucDonDAO.Instance.GetOrCreate(currentUserId, currentCheDoId, ngay);

            List<ChiTietThucDonModel> dsChiTiet = ChiTietThucDonDAO.Instance
                .GetByThucDonNgayBuoi(currentThucDon.ThucDonId, ngay, buoianId);

            dgvThucDon.DataSource = null;
            dgvThucDon.DataSource = dsChiTiet;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbltieude_Click(object sender, EventArgs e)
        {

        }

        private void pnlchilfilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblngay_Click(object sender, EventArgs e)
        {

        }

        private void lblchedo_Click(object sender, EventArgs e)
        {

        }

        private void lblbuoi_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlfilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnthemmon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lbldanhsachan_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblloaimon_Click(object sender, EventArgs e)
        {

        }

        private void frmlapthucdon_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ hỏi xác nhận nếu form được đóng bởi hành động của người dùng (nhấn X)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                                                       "Xác nhận thoát",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
            if (dgvThucDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần bỏ trong danh sách!");
                return;
            }

            // Lấy món ăn từ dòng đang chọn
            var selectedRow = dgvThucDon.SelectedRows[0];
            if (selectedRow.DataBoundItem is ChiTietThucDonModel monDuocChon)
            {
                // Xác nhận xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn bỏ món '{monDuocChon.TenMon}'?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Xóa khỏi database
                    bool deleted = ChiTietThucDonDAO.Instance.Delete(
                        currentThucDon.ThucDonId,
                        monDuocChon.Ngay,
                        monDuocChon.BuoiAnId,
                        monDuocChon.MonAnId
                    );

                    if (deleted)
                    {
                        // Load lại DataGridView
                        LoadThucDonChiTiet();
                        MessageBox.Show("Đã xóa món thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa món!");
                    }
                }
            }
        }

        private void btnHD_Click(object sender, EventArgs e)
        {

        }
    }
}
