using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn.GUI.frmlogin;
using DuAn.GUI.frmquannhan;
using DuAn.GUI.frmfornhvhc;
using DuAn.BUL;
using DuAn.DTO;


namespace DuAn.GUI.frmnhanvien
{
    public partial class frmbaocaoquanso : Form
    {
        public frmbaocaoquanso()
        {
            InitializeComponent();
        }
        private void frmbaocaoquanso_Load(object sender, EventArgs e)
        {
            // Gán sự kiện ValueChanged cho dtpTuNgay (chưa có trong Designer, ta gán bằng code)
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;

            // Đặt ngày mặc định là hôm nay
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            dtpDenNgay.MinDate = DateTime.Today;  // khởi tạo MinDate

            // Load dữ liệu cho ComboBox
            LoadDonVi();
            LoadBuoi();
            LoadCheDo();

            // Đăng ký sự kiện nút Tra cứu (nếu chưa có trong Designer)
            btnTraCuu.Click += btnTraCuu_Click;

        }
        // ========== LOAD ĐƠN VỊ ==========
        private void LoadDonVi()
        {
            DataTable dt = B_QN.GetAllDonVi();         // Gọi BUL lấy danh sách đơn vị
            cboDonVi.DataSource = dt;
            cboDonVi.DisplayMember = "donvi_ten";
            cboDonVi.ValueMember = "donvi_id";
            cboDonVi.SelectedIndex = -1;               // Không chọn mặc định
        }

        // ========== LOAD BUỔI (có thêm "Tất cả") ==========
        private void LoadBuoi()
        {
            DataTable dt = B_BQS.loadbuoi();           // Bảng Buoi_an: buoian_id, buoian_ten
            // Thêm dòng "Tất cả" vào đầu DataTable
            DataRow row = dt.NewRow();
            row["buoian_id"] = 0;
            row["buoian_ten"] = "Tất cả";
            dt.Rows.InsertAt(row, 0);
            cboBuoi.DataSource = dt;
            cboBuoi.DisplayMember = "buoian_ten";
            cboBuoi.ValueMember = "buoian_id";
            cboBuoi.SelectedIndex = 0;                 // Mặc định chọn Tất cả
        }

        // ========== LOAD CHẾ ĐỘ (có thêm "Tất cả") ==========
        private void LoadCheDo()
        {
            DataTable dt = B_QN.GetAllCheDo();         // Bảng Che_do: chedo_id, chedo_ten
            DataRow row = dt.NewRow();
            row["chedo_id"] = 0;
            row["chedo_ten"] = "Tất cả";
            dt.Rows.InsertAt(row, 0);
            cboCheDo.DataSource = dt;
            cboCheDo.DisplayMember = "chedo_ten";
            cboCheDo.ValueMember = "chedo_id";
            cboCheDo.SelectedIndex = 0;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvlscc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận ",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void pnlluachon_Paint(object sender, PaintEventArgs e)
        {

        }
        // ========== KIỂM SOÁT NGÀY: TỪ NGÀY THAY ĐỔI ==========
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            // Không cho phép Đến ngày nhỏ hơn Từ ngày
            dtpDenNgay.MinDate = dtpTuNgay.Value;

            // Nếu Đến ngày hiện tại đang nhỏ hơn Từ ngày, tự động gán bằng Từ ngày
            if (dtpDenNgay.Value < dtpTuNgay.Value)
            {
                dtpDenNgay.Value = dtpTuNgay.Value;
            }

        }
        // ========== NÚT TRA CỨU ==========
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn đơn vị chưa
            if (cboDonVi.SelectedValue == null || (int)cboDonVi.SelectedValue <= 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giá trị từ các điều khiển trên form
            DateTime tuNgay = dtpTuNgay.Value.Date;               // Ngày bắt đầu (bỏ phần giờ)
            DateTime denNgay = dtpDenNgay.Value.Date;             // Ngày kết thúc
            int donViId = (int)cboDonVi.SelectedValue;            // Mã đơn vị
            int buoiAnId = (int)cboBuoi.SelectedValue;            // Mã buổi (0 nếu chọn Tất cả)
            int cheDoId = (int)cboCheDo.SelectedValue;            // Mã chế độ (0 nếu chọn Tất cả)

            // Tạo đối tượng tham số cho tầng BUL
            LSBQS ls = new LSBQS
            {
                tungay = tuNgay,
                denngay = denNgay,
                donvi_id = donViId,
                buoian_id = buoiAnId
            };

            // Gọi Business Logic Layer để lấy dữ liệu từ DB
            DataTable dt = B_LSBQS.TraCuu(ls);

            // Nếu có chọn chế độ cụ thể (khác "Tất cả") thì lọc lại DataTable
            if (cheDoId != 0 && dt.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = $"chedo_id = {cheDoId}";
                dt = dt.DefaultView.ToTable();   // Tạo DataTable mới từ các dòng đã lọc
            }

            // QUAN TRỌNG: Tính tổng TRƯỚC khi đổi tên cột (vì tính tổng cần tên cột gốc)
            TinhTong(dt);

            // Gán dữ liệu cho DataGridView
            dgvBaoCao.DataSource = dt;

            // Đổi tên cột cho dễ nhìn (chỉ để hiển thị, làm sau khi đã tính tổng)
            if (dt.Columns.Count > 0)
            {
                dt.Columns["ngay_thang_nam"].ColumnName = "Ngày";
                dt.Columns["buoian_ten"].ColumnName = "Buổi";
                dt.Columns["chedo_ten"].ColumnName = "Chế độ";
                dt.Columns["An"].ColumnName = "Quân số ăn";
                dt.Columns["CatCom"].ColumnName = "Quân số không ăn";
            }
        }

        // ========== TÍNH TỔNG QUÂN SỐ ĂN, CẮT CƠM, SỐ NGÀY ==========
        private void TinhTong(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                lblTongAn.Text = "0";
                lblTongCatCom.Text = "0";
                lblSoNgay.Text = "0";
                return;
            }

            int tongAn = 0;
            int tongCatCom = 0;

            // Duyệt từng dòng, dùng Convert.ToInt32 an toàn với DBNull và kiểu dữ liệu smallint
            foreach (DataRow row in dt.Rows)
            {
                tongAn += Convert.ToInt32(row["An"]);
                tongCatCom += Convert.ToInt32(row["CatCom"]);
            }

            // Đếm số ngày phân biệt (dùng tên cột gốc)
            int soNgay = dt.AsEnumerable()
                           .Select(row => Convert.ToDateTime(row["ngay_thang_nam"]).Date)
                           .Distinct()
                           .Count();

            // Hiển thị kết quả lên các Label
            lblTongAn.Text = tongAn.ToString();
            lblTongCatCom.Text = tongCatCom.ToString();
            lblSoNgay.Text = soNgay.ToString();
        }

        // ========== NÚT THOÁT (ĐÃ CÓ) ==========
        
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}
