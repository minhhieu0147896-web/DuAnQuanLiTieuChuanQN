using DuAn.BUL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn.DAO;
using DuAn.DTO;
using DuAn.BUL;
using DuAn;

namespace DuAn.GUI.frmfornhvhc
{
    public partial class frmLSQS : Form
    {
        int page = 1;
        int pagesize = 10;
        int totalpage = 0;
        public frmLSQS()
        {
            InitializeComponent();
        }
        void LoadBuoi()
        {
          
            DataTable dt = B_BQS.loadbuoi();

            // thêm dòng chọn buổi
            DataRow row = dt.NewRow();
            row["buoian_id"] = 0;
            row["buoian_ten"] = "-- Tất cả buổi --";

            dt.Rows.InsertAt(row, 0);

            cbobuoi.DataSource = dt;
            cbobuoi.DisplayMember = "buoian_ten";
            cbobuoi.ValueMember = "buoian_id";

            // mặc định chọn dòng đầu
            cbobuoi.SelectedIndex = 0;
        }
        void LoadDonvi()
        {
            DataTable dt = B_QN.GetAllDonVi();

            cbodonvi.DataSource = dt;

            cbodonvi.DisplayMember = "donvi_ten";

            cbodonvi.ValueMember = "donvi_id";

            // tự động theo session
            if (Session.DonViID.HasValue)
            {
                cbodonvi.SelectedValue =
                    Session.DonViID.Value;

                // khóa combobox
                cbodonvi.Enabled = false;
            }
        }
        void LoadPage()
        {
            try
            {
                LSBQS ls = new LSBQS();

                ls.tungay = dtptungay.Value;

                ls.denngay = dtpdenngay.Value;

                ls.donvi_id =
                    Convert.ToInt32(cbodonvi.SelectedValue);

                ls.buoian_id =
                    Convert.ToInt32(cbobuoi.SelectedValue);

                // lấy dữ liệu paging
                DataTable dt =
                    B_LSBQS.TraCuu(ls, page, pagesize);

                dgvlsbqs.AutoGenerateColumns = false;

                dgvlsbqs.DataSource = dt;

                // ================= TÍNH TỔNG TRANG =================
                int tongdong = B_LSBQS.CountLSBQS(ls);

               

                totalpage =
                    (int)Math.Ceiling((double)tongdong / pagesize);

                // tránh bị 0 trang
                if (totalpage == 0)
                {
                    totalpage = 1;
                }

                // ================= HIỂN THỊ =================
                lbltrang.Text =
                    "Trang " + page + "/" + totalpage;

                btnsau.Enabled = page > 1;

                btnnext.Enabled = page < totalpage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi load dữ liệu: " + ex.Message);
            }
        }
      
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ucgiaodienchinh1_Load(object sender, EventArgs e)
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

        private void btntracuu_Click(object sender, EventArgs e)
        {
            page = 1;
            LoadPage();

        }

        private void pnlluachon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLSQS_Load(object sender, EventArgs e)
        {
            LoadBuoi();

            LoadDonvi();

            dgvlsbqs.AutoGenerateColumns = false;

            // tự tra cứu theo đơn vị
            if (Session.DonViID.HasValue)
            {
                page = 1;

                LoadPage();
            }
        }

        private void cbobuoi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbodonvi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (page >= totalpage)
            {
                MessageBox.Show(
                    "Đây là trang cuối cùng",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            page++;

            LoadPage();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            if (page <= 1)
            {
                MessageBox.Show(
                    "Đây là trang đầu tiên",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            page--;

            LoadPage();
        }

        private void dgvlsbqs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
