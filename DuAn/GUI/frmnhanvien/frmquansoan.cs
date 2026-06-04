using DuAn.BUL;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmquansoan : Form
    {
        private System.Windows.Forms.Timer _timerKhoaSo;
        public frmquansoan()
        {
            InitializeComponent();
        }
        void LoadBuoi()
        {
            DataTable dt = B_BQS.loadbuoi();

            // thêm dòng chọn buổi
            DataRow row = dt.NewRow();
            row["buoian_id"] = 0;
            row["buoian_ten"] = "--Chọn tất cả --";

            dt.Rows.InsertAt(row, 0);

            cbobuoi.DataSource = dt;
            cbobuoi.DisplayMember = "buoian_ten";
            cbobuoi.ValueMember = "buoian_id";
        }
        void LoadDonvi()
        {
            DataTable dt = B_QN.GetAllDonVi();
            DataRow row = dt.NewRow();
            row["donvi_id"] = 0;
            row["donvi_ten"] = "--Chọn đơn vị --";

            dt.Rows.InsertAt(row, 0);

            cbodonvi.DataSource = dt;
            cbodonvi.DisplayMember = "donvi_ten";
            cbodonvi.ValueMember = "donvi_id";

        }
        private void CapNhatTrangThaiNut()
        {
            int donvi_id = GetDonViID();
            bool coThe = B_QuanSoAn.CoTheChinhSua(dtpngay.Value.Date, donvi_id);
            bool daKhoa = B_QuanSoAn.IsKhoaSo(dtpngay.Value.Date, donvi_id);

            btnchotso.Enabled = coThe;
            btnchotso.BackColor = coThe
                ? Color.FromArgb(46, 204, 133)
                : Color.Gray;

            if (daKhoa)
                btnchotso.Text = "     ĐÃ CHỐT SỔ\r\n     Dữ liệu đã khóa";
            else if (!coThe && DateTime.Now.Hour >= 19)
                btnchotso.Text = "     TỰ ĐỘNG CHỐT\r\n     Quá giờ 19:00";
            else
                btnchotso.Text = "     CHỐT SỔ\r\n     Xác nhận và khóa dữ liệu";
        }
        private void BatTimer()
        {
            _timerKhoaSo = new System.Windows.Forms.Timer();
            _timerKhoaSo.Interval = 60000;
            _timerKhoaSo.Tick += (s, e) => CapNhatTrangThaiNut();
            _timerKhoaSo.Start();
        }
        private int GetDonViID()
        {
            if (cbodonvi.SelectedValue == null) return 0;
            return Convert.ToInt32(cbodonvi.SelectedValue);
        }
        private void HienThi()
        {
            DateTime ngay = dtpngay.Value.Date;
            int donvi_id = GetDonViID();

            // Bảng TRÁI
            DataTable dtTrai = B_QuanSoAn.QuanSoAnTheoDonVi(donvi_id, ngay);
            dgvcatcom.DataSource = dtTrai;
            if (dtTrai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return;
            }

            // Bảng PHẢI
            DataTable dtPhai = B_QuanSoAn.ChiTietCatCom(donvi_id, ngay);          
            dgvqsa.DataSource = dtPhai;
            if (dtPhai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return;
            }
            dgvcatcom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvqsa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 4 ô thống kê
            thongke_quansoan tk = B_QuanSoAn.ThongKeQuanSoAn(donvi_id, ngay);
            lbltqs_ht.Text = tk.TongQuanSo.ToString();
            lbldka_ht.Text = tk.DangKyAn.ToString();
            lbldkka_ht.Text = tk.DangKyKhongAn.ToString();
            lbltongdonvi_ht.Text = tk.TongDonVi.ToString();

            CapNhatTrangThaiNut();
        }

        private void cbobuoi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlfilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmquansoan_Load(object sender, EventArgs e)
        {
            LoadBuoi();
            LoadDonvi();
            dgvcatcom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            dgvqsa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvcatcom.AutoGenerateColumns = false;
            dgvqsa.AutoGenerateColumns = false;
            dtpngay.Value = DateTime.Today;
            BatTimer();

        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnchotso_Click(object sender, EventArgs e)
        {
            int donvi_id = GetDonViID();
            string tenDV = donvi_id == 0 ? "tất cả đơn vị" : cbodonvi.Text;

            var cf = MessageBox.Show(
                $"Xác nhận CHỐT SỔ ngày {dtpngay.Value:dd/MM/yyyy} - {tenDV}?\n\n" +
                "Sau khi chốt, dữ liệu sẽ bị khóa!",
                "Xác nhận chốt sổ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (cf != DialogResult.Yes) return;

            int nguoi_khoa = Session.UserID; // theo đúng class Session của project

            int ketQua = B_QuanSoAn.ChotSo(dtpngay.Value.Date, donvi_id, nguoi_khoa);

            if (ketQua == 1)
            {
                MessageBox.Show("Chốt sổ thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThi();
            }
            else if (ketQua == 0)
            {
                MessageBox.Show("Ngày này đã được chốt sổ trước đó!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi chốt sổ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerKhoaSo?.Stop();
            _timerKhoaSo?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
