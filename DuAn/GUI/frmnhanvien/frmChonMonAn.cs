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

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmChonMonAn : Form
    {
        // Thuộc tính lưu món đã chọn, sẽ được form cha đọc sau khi đóng
        public MonAnModel MonDaChon { get; private set; } = null;

        private string loaiMon;
        public frmChonMonAn(string loaimon)
        {
            InitializeComponent();
            this.loaiMon = loaiMon;
        }

        private void frmChonMonAn_Load(object sender, EventArgs e)
        {
            // Hiển thị loại món lên tiêu đề và label
            this.Text = "Chọn món - " + loaiMon;
            lblLoaiMon.Text = "Loại: " + loaiMon;

            // Lấy danh sách món từ DB theo loại
            List<MonAnModel> ds = MonAnDAO.Instance.GetByLoaiMon(loaiMon);

            // Gán vào ListBox
            lstMonAn.DataSource = ds;
            lstMonAn.DisplayMember = "TenMon";  // Hiển thị tên món
            lstMonAn.ValueMember = "MonAnId";   // Giá trị ẩn là ID

            if (ds.Count > 0)
                lstMonAn.SelectedIndex = 0;     // Chọn sẵn dòng đầu
            else
                MessageBox.Show("Không có món nào trong loại này.", "Thông báo");
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (lstMonAn.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một món.");
                return;
            }

            // Lấy đối tượng MonAnModel đang được chọn
            MonDaChon = (MonAnModel)lstMonAn.SelectedItem;

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void lstMonAn_DoubleClick(object sender, EventArgs e)
        {
            btnChon.PerformClick();
        }
    }
}
