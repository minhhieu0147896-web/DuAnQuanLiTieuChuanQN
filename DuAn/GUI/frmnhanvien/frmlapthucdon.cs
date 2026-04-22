using DuAn.DAO;
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

namespace frmnhanvien
{
    public partial class frmlapthucdon : Form
    {
        public frmlapthucdon()
        {
            InitializeComponent();
            LoadLoaiMon();
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

        private void cboloaimon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiMon.SelectedItem == null)
            {
                cboDanhSachMon.DataSource = null; // Xóa danh sách món cũ
                return;
            }

            string loaiMonDaChon = cboLoaiMon.SelectedItem.ToString();

            // Lấy danh sách món theo loại từ DB
            List<MonAnModel> dsMon = MonAnDAO.Instance.GetByLoaiMon(loaiMonDaChon);

            // Gán vào ComboBox món ăn
            cboDanhSachMon.DataSource = null;                // Reset
            cboDanhSachMon.DataSource = dsMon;               // Gán danh sách mới
            cboDanhSachMon.DisplayMember = "TenMon";         // Hiển thị tên món
            cboDanhSachMon.ValueMember = "MonAnId";          // Giá trị ID

            // Không tự động chọn món nào ban đầu (để trống)
            cboDanhSachMon.SelectedIndex = -1;
        }

        private void cboDanhSachMon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
