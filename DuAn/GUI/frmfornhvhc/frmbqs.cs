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
    public partial class frmbqs : Form
    {
        int currentPage = 1;

        int pageSize = 20;

        int totalPage = 1;
        HashSet<int> dsKhongAn = new HashSet<int>();
        Dictionary<int, TrangThaiCatCom> dsBaoCom = new Dictionary<int, TrangThaiCatCom>();
        public frmbqs()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            // =========================
            // LẤY MÃ ĐƠN VỊ
            // =========================

            int madv;

            // ADMIN
            if (Session.VaiTro == 3)
            {
                // chưa chọn đơn vị
                if (cbodonvi.SelectedValue == null)
                    return;

                if (Convert.ToInt32(cbodonvi.SelectedValue) == 0)
                    return;

                madv = Convert.ToInt32(cbodonvi.SelectedValue);
            }

            // USER THƯỜNG
            else
            {
                // chưa có đơn vị
                if (!Session.DonViID.HasValue)
                {
                    MessageBox.Show("Tài khoản chưa được gán đơn vị");

                    return;
                }

                madv = Session.DonViID.Value;
            }

            // =========================
            // TỪ KHÓA TÌM KIẾM
            // =========================

            string tukhoa = "";

            if (txttimkiem != null)
            {
                tukhoa = txttimkiem.Text.Trim();
            }

            // =========================
            // LOAD GRID
            // =========================

            dgvbqs.AutoGenerateColumns = false;

            dgvbqs.DataSource =
                B_BQS.loadbqs(madv, tukhoa, currentPage, pageSize);

            // =========================
            // PHÂN TRANG
            // =========================

            int totalRow =
                B_BQS.CountBQS(madv, tukhoa);

            totalPage =
                (int)Math.Ceiling((double)totalRow / pageSize);

            // tránh chia 0
            if (totalPage <= 0)
                totalPage = 1;

            lbltrang.Text = currentPage + "/" + totalPage;

            btnnext.Enabled = currentPage < totalPage;

            btnsau.Enabled = currentPage > 1;

            // =========================
            // LOAD TRẠNG THÁI CẮT CƠM
            // =========================

         

           
            RestoreCheckBox();
            UpdateTrangThaiPanel();
        }
        void RestoreCheckBox()
        {
            foreach (DataGridViewRow row in dgvbqs.Rows)
            {
                if (row.IsNewRow) continue;
                int maquan = Convert.ToInt32(row.Cells["colMaQN"].Value);

                row.Cells["colKan"].Value = dsKhongAn.Contains(maquan);
            }
        }
        void KiemTraNutLuu()
        {
            DateTime ngay = dtpngay.Value;

            int mabuoi = Convert.ToInt32(cbobuoi.SelectedValue);

            int madv = Convert.ToInt32(cbodonvi.SelectedValue);

            int kq = B_BQS.KiemTraDaBao(ngay, mabuoi, madv);

            if (kq == 1)
            {
                btnluu.Enabled = false;
                MessageBox.Show("Đơn vị này đã báo quân số rồi");
            }
            else
            {
                btnluu.Enabled = true;
            }
        }
        void ResetForm()
        {
            dgvbqs.DataSource = null;

            btnluu.Enabled = true;

            if (Session.VaiTro == 3)
            {
                cbodonvi.SelectedIndex = 0;
            }
            else
            {
                if (Session.VaiTro == 1)
                {
                    cbodonvi.SelectedValue = Session.DonViID;
                }
            }

            cbobuoi.SelectedIndex = 0;
            dtpngay.Value = DateTime.Now;

            cbodonvi.Focus();
            dsKhongAn.Clear();

            UpdateTrangThaiPanel();
        }
        void LoadBuoi()
        {
            DataTable dt = B_BQS.loadbuoi();

            // thêm dòng chọn buổi
            DataRow row = dt.NewRow();
            row["buoian_id"] = 0;
            row["buoian_ten"] = "--Chọn buổi ăn --";

            dt.Rows.InsertAt(row, 0);

            cbobuoi.DataSource = dt;
            cbobuoi.DisplayMember = "buoian_ten";
            cbobuoi.ValueMember = "buoian_id";
        }
        void LoadDonvi()
        {
            DataTable dt = B_QN.GetAllDonVi();

            // CHỈ ADMIN mới có dòng chọn đơn vị
            if (Session.VaiTro == 3)
            {
                DataRow row = dt.NewRow();

                row["donvi_id"] = 0;

                row["donvi_ten"] = "-- Chọn đơn vị --";

                dt.Rows.InsertAt(row, 0);
            }

            cbodonvi.DataSource = dt;

            cbodonvi.DisplayMember = "donvi_ten";

            cbodonvi.ValueMember = "donvi_id";

            // USER THƯỜNG
            if (Session.VaiTro == 1)
            {
                cbodonvi.SelectedValue = Session.DonViID;

                cbodonvi.Enabled = false;
            }
            else
            {
                cbodonvi.SelectedIndex = 0;

                cbodonvi.Enabled = true;
            }
        }
        void UpdateTrangThaiPanel()
        {
            int madv;

            if (Session.VaiTro == 3)
            {
                if (cbodonvi.SelectedValue == null)
                    return;

                if (Convert.ToInt32(cbodonvi.SelectedValue) == 0)
                    return;

                madv = Convert.ToInt32(cbodonvi.SelectedValue);
            }
            else
            {
                madv = Session.DonViID.Value;
            }

            // tổng quân số
            int tongQuanSo = B_QN.CountQSDonVi(madv);

            // tổng từng chế độ
            int chedo1_total = B_QN.CountQSCheDo(madv, 1);

            int chedo2_total = B_QN.CountQSCheDo(madv, 2);

            // đếm không ăn
            int chedo1_khongan = 0;

            int chedo2_khongan = 0;

            // duyệt HASHSET
            foreach (int maquan in dsKhongAn)
            {
                int chedo = B_QN.GetCheDoByMaQN(maquan);

                if (chedo == 1)
                    chedo1_khongan++;

                else if (chedo == 2)
                    chedo2_khongan++;
            }

            // quân số ăn
            int chedo1_an =
                chedo1_total - chedo1_khongan;

            int chedo2_an =
                chedo2_total - chedo2_khongan;

            // label
            lblTongQuanSo.Text =
                $"👥 Tổng quân số: {tongQuanSo}";

            lblCheDo1.Text =
                $"🍱 Chế độ 1: {chedo1_an}/{chedo1_total} | Không ăn: {chedo1_khongan}";

            lblCheDo2.Text =
                $"🍱 Chế độ 2: {chedo2_an}/{chedo2_total} | Không ăn: {chedo2_khongan}";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnluu_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void btnluu_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime ngay = dtpngay.Value.Date;
                int mabuoi = Convert.ToInt32(cbobuoi.SelectedValue);
                int madv = Convert.ToInt32(cbodonvi.SelectedValue);

                // ==========================================
                // KIỂM TRA ĐÃ BÁO CHƯA
                // ==========================================
                int kq = B_BQS.KiemTraDaBao(ngay, mabuoi, madv);
                if (kq == 1)
                {
                    MessageBox.Show("Đơn vị này đã báo quân số rồi!");
                    btnluu.Enabled = false;
                    return;
                }

                // ==========================================
                // INSERT CẮT CƠM
                // ==========================================
                foreach (int maquan in dsKhongAn)
                {
                    catcom cc = new catcom() { ngay_thang_nam = ngay, buoian_id = mabuoi, donvi_id = madv, quannhan_id = maquan };
                    B_BQS.insertcatcom(cc);
                }

                // ==========================================
                // TÍNH QUÂN SỐ ĂN
                // ==========================================
                int chedo1_total = B_QN.CountQSCheDo(madv, 1);
                int chedo2_total = B_QN.CountQSCheDo(madv, 2);
                int chedo1_khongan = 0, chedo2_khongan = 0;

                foreach (int maquan in dsKhongAn)
                {
                    int chedo = B_QN.GetCheDoByMaQN(maquan);
                    if (chedo == 1) chedo1_khongan++;
                    else if (chedo == 2) chedo2_khongan++;
                }

                int chedo1_an = chedo1_total - chedo1_khongan;
                int chedo2_an = chedo2_total - chedo2_khongan;

                // ==========================================
                // INSERT QUÂN SỐ ĂN
                // ==========================================
                quansoan qsa1 = new quansoan() { chedo_id = 1, soluong = chedo1_an, ngay_thang_nam = ngay, buoian_id = mabuoi, donvi_id = madv };
                B_BQS.insertqsa(qsa1);

                quansoan qsa2 = new quansoan() { chedo_id = 2, soluong = chedo2_an, ngay_thang_nam = ngay, buoian_id = mabuoi, donvi_id = madv };
                B_BQS.insertqsa(qsa2);

                // ==========================================
                // THÔNG BÁO & CLEAR
                // ==========================================
                MessageBox.Show("Lưu báo quân số thành công!");
                dsKhongAn.Clear();
                foreach (DataGridViewRow row in dgvbqs.Rows)
                {
                    if (row.IsNewRow) continue;

                    row.Cells["colKan"].Value = false;
                }
                // ==========================================
                // TỰ ĐỘNG CHUYỂN BUỔI
                // ==========================================
                if (mabuoi == 1) // sáng -> trưa
                {
                    cbobuoi.SelectedValue = 2;
                    MessageBox.Show("Tiếp tục báo quân số BUỔI TRƯA");
                }
                else if (mabuoi == 2) // trưa -> chiều
                {
                    cbobuoi.SelectedValue = 3;
                    MessageBox.Show("Tiếp tục báo quân số BUỔI CHIỀU");
                }
                else if (mabuoi == 3) // chiều -> khóa
                {
                    btnluu.Enabled = false;
                    dgvbqs.Enabled = false;
                    MessageBox.Show("Đã hoàn thành báo quân số ngày " + ngay.ToString("dd/MM/yyyy"));
                }

                // ==========================================
                // TẢI LẠI DỮ LIỆU & KIỂM TRA KHÓA
                // ==========================================
                LoadData();
                RestoreCheckBox();
                UpdateTrangThaiPanel();
                KiemTraKhoaBaoQuanSo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlfilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbobuoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbobuoi.SelectedValue == null)
                return;

            if (cbodonvi.SelectedValue == null)
                return;

            if (cbobuoi.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            int madv = Convert.ToInt32(cbodonvi.SelectedValue);

            int mabuoi = Convert.ToInt32(cbobuoi.SelectedValue);

            DateTime ngay = dtpngay.Value.Date;

            int kq = B_BQS.KiemTraDaBao(ngay, mabuoi, madv);

            if (kq == 1)
            {
                btnluu.Enabled = false;

                MessageBox.Show(
                    "Buổi này đã báo quân số rồi!"
                );
            }
            else
            {
                btnluu.Enabled = true;
            }
        }
        private void dgvbqs_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvbqs.IsCurrentCellDirty)
            {
                dgvbqs.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        void KiemTraKhoaBaoQuanSo()
        {
            try
            {
                int madv;

                if (Session.VaiTro == 3)
                {
                    if (cbodonvi.SelectedValue == null)
                        return;

                    madv = Convert.ToInt32(cbodonvi.SelectedValue);
                }
                else
                {
                    madv = Session.DonViID.Value;
                }

                DateTime ngay = dtpngay.Value.Date;

                // kiểm tra đủ 3 buổi chưa
                bool sang =B_BQS.KiemTraDaBao(ngay, 1, madv) == 1;

                bool trua = B_BQS.KiemTraDaBao(ngay, 2, madv) == 1;

                bool chieu =B_BQS.KiemTraDaBao(ngay, 3, madv) == 1;

                // nếu đủ 3 buổi
                if (sang && trua && chieu)
                {
                    btnluu.Enabled = false;

                    dgvbqs.Enabled = false;

                    MessageBox.Show(
                        "Đã báo quân số đầy đủ cho ngày " +
                        ngay.ToString("dd/MM/yyyy"),
                        "Thông báo"
                    );
                }
                else
                {
                    btnluu.Enabled = true;

                    dgvbqs.Enabled = true;
                }
            }
            catch
            {

            }
        }
        private void frmbqs_Load(object sender, EventArgs e)
        {
            LoadBuoi();

            LoadDonvi();

            dgvbqs.DataSource = null;

            dgvbqs.CurrentCellDirtyStateChanged += dgvbqs_CurrentCellDirtyStateChanged;

            dgvbqs.CellValueChanged += dgvbqs_CellValueChanged;

            dgvbqs.AllowUserToAddRows = false;

            // =========================
            // MẶC ĐỊNH NGÀY MAI
            // =========================

            dtpngay.Value = DateTime.Today.AddDays(1);

            // =========================
            // MẶC ĐỊNH BUỔI SÁNG
            // =========================

            cbobuoi.SelectedValue = 1;

            // load luôn
            LoadData();

            KiemTraKhoaBaoQuanSo();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {

            currentPage = 1;

            LoadData();

            KiemTraNutLuu();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void cbodonvi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tlptrangthai_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbltrang_Click(object sender, EventArgs e)
        {

        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

                LoadData();
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage)
            {
                currentPage++;

                LoadData();
            }
        }

        private void dgvbqs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            currentPage = 1;

            LoadData();
        }

        private void dgvbqs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex < 0) return;

                if (dgvbqs.Columns[e.ColumnIndex].Name == "colKan")
                {
                    int maquan = Convert.ToInt32(dgvbqs.Rows[e.RowIndex].Cells["colMaQN"].Value);
                    bool khongan = Convert.ToBoolean(dgvbqs.Rows[e.RowIndex].Cells["colKan"].Value);

                    // Thao tác với danh sách KHÔNG ĂN theo trạng thái checkbox
                    if (khongan) dsKhongAn.Add(maquan);
                    else dsKhongAn.Remove(maquan);

                    UpdateTrangThaiPanel();
                }
            }
        }

        private void lblCheDo2_Click(object sender, EventArgs e)
        {

        }

        private void lblCheDo1_Click(object sender, EventArgs e)
        {

        }
    }
}
