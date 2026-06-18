using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace DuAn.GUI.ADMIN
{
    public partial class frmAdmin : Form
    {
        private ThucDonModel thucDonDangChon;

        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadDanhSachCheDo();
            HienThiTrangThaiMacDinh();
        }

        private void LoadDanhSachCheDo()
        {
            DataTable bangCheDo = D_MonAn.LayDanhSachCheDo();

            cboCheDo.DataSource = bangCheDo;
            cboCheDo.DisplayMember = "chedo_ten";
            cboCheDo.ValueMember = "chedo_id";
        }

        private void HienThiTrangThaiMacDinh()
        {
            lblTrangThai.Text = "Chưa tải thực đơn";
            lblTrangThai.ForeColor = System.Drawing.Color.DimGray;
            btnDuyet.Enabled = false;
        }

        private void btnTaiThucDon_Click(object sender, EventArgs e)
        {
            TaiThucDon();
        }

        private void TaiThucDon()
        {
            int cheDoId = Convert.ToInt32(cboCheDo.SelectedValue);
            int nam = dtpTuan.Value.Year;
            int tuan = LaySoTuan(dtpTuan.Value);

            thucDonDangChon = ThucDonDAO.Instance.GetByTuanNamCheDo(tuan, nam, cheDoId);

            if (thucDonDangChon == null)
            {
                dgvThucDon.DataSource = null;
                lblTrangThai.Text = "Không tìm thấy thực đơn của tuần này";
                lblTrangThai.ForeColor = System.Drawing.Color.Red;
                btnDuyet.Enabled = false;
                return;
            }

            if (thucDonDangChon.TrangThai != "ChoDuyet")
            {
                dgvThucDon.DataSource = null;
                lblTrangThai.Text = "Thực đơn tuần này không ở trạng thái Chờ duyệt";
                lblTrangThai.ForeColor = System.Drawing.Color.OrangeRed;
                btnDuyet.Enabled = false;
                return;
            }

            DataTable bangThucDon = D_TCTD.TraCuuThucDon(cheDoId, nam, tuan);
            dgvThucDon.DataSource = bangThucDon;

            lblTrangThai.Text = "Trạng thái: " + DoiTenTrangThai(thucDonDangChon.TrangThai);
            lblTrangThai.ForeColor = System.Drawing.Color.DarkBlue;

            btnDuyet.Enabled = true;
        }

        private int LaySoTuan(DateTime ngay)
        {
            GregorianCalendar lich = new GregorianCalendar();

            return lich.GetWeekOfYear(
                ngay,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday);
        }

        private string DoiTenTrangThai(string trangThai)
        {
            if (trangThai == "NhapLieu")
                return "Nhập liệu";

            if (trangThai == "ChoDuyet")
                return "Chờ duyệt";

            if (trangThai == "DaDuyet")
                return "Đã duyệt";

            return trangThai;
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (thucDonDangChon == null)
            {
                MessageBox.Show("Bạn chưa tải thực đơn.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn duyệt thực đơn này không?",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            bool thanhCong = ThucDonDAO.Instance.DuyetThucDon(thucDonDangChon.ThucDonId);

            if (thanhCong)
            {
                MessageBox.Show("Duyệt thực đơn thành công.");
                TaiThucDon();
            }
            else
            {
                MessageBox.Show("Duyệt thực đơn thất bại.");
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DuAn.GUI.frmlogin.frmmhlogin f = new DuAn.GUI.frmlogin.frmmhlogin();
            f.Show();
            this.Hide();
        }
    }
}
