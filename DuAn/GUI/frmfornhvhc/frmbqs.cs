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

namespace DuAn.GUI.frmfornhvhc
{
    public partial class frmbqs : Form
    {
        int currentPage = 1;

        int pageSize = 20;

        int totalPage = 1;
        Dictionary<int, TrangThaiCatCom> dsBaoCom = new Dictionary<int, TrangThaiCatCom>();
        public frmbqs()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            int madv = Convert.ToInt32(cbodonvi.SelectedValue);
            string tukhoa = (txttimkiem != null) ? txttimkiem.Text.Trim() : "";

            dgvbqs.AutoGenerateColumns = false;
            dgvbqs.DataSource = B_BQS.loadbqs(madv, tukhoa, currentPage, pageSize);

            int totalRow = B_BQS.CountBQS(madv, tukhoa);
            totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            lbltrang.Text = currentPage + "/" + totalPage;
            btnnext.Enabled = currentPage < totalPage;
            btnsau.Enabled = currentPage > 1;

            foreach (DataGridViewRow row in dgvbqs.Rows)
            {
                if (row.IsNewRow) continue;

                int maquan = Convert.ToInt32(row.Cells["colMaQN"].Value);
                int chedo = Convert.ToInt32(row.Cells["colchedoid"].Value);

                if (!dsBaoCom.ContainsKey(maquan))
                {
                    dsBaoCom.Add(maquan, new TrangThaiCatCom() { QuannhanID = maquan, CheDoID = chedo, KhongAn = false });
                }
            }

            RestoreCheckBox();
            UpdateTrangThaiPanel();
        }
        void RestoreCheckBox()
        {
            foreach (DataGridViewRow row in dgvbqs.Rows)
            {
                int maquan = Convert.ToInt32(row.Cells["colMaQN"].Value);

                if (dsBaoCom.ContainsKey(maquan))
                {
                    row.Cells["colKan"].Value = dsBaoCom[maquan].KhongAn;
                }
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

            cbodonvi.SelectedIndex = 0;

            cbobuoi.SelectedIndex = 0;
            dtpngay.Value = DateTime.Now;

            cbodonvi.Focus();
            dsBaoCom.Clear();

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

            // thêm dòng chọn đơn vị
            DataRow row = dt.NewRow();
            row["donvi_id"] = 0;
            row["donvi_ten"] = "-- Chọn đơn vị --";

            dt.Rows.InsertAt(row, 0);

            cbodonvi.DataSource = dt;
            cbodonvi.DisplayMember = "donvi_ten";
            cbodonvi.ValueMember = "donvi_id";

            // mặc định chọn dòng đầu
            cbodonvi.SelectedIndex = 0;
        }
        void UpdateTrangThaiPanel()
        {
            int tongQuanSo = 0;

            int chedo1_total = 0;
            int chedo1_an = 0;
            int chedo1_khongan = 0;

            int chedo2_total = 0;
            int chedo2_an = 0;
            int chedo2_khongan = 0;

            foreach (var item in dsBaoCom.Values)
            {
                tongQuanSo++;

                // CHẾ ĐỘ 1
                if (item.CheDoID == 1)
                {
                    chedo1_total++;

                    if (item.KhongAn)
                        chedo1_khongan++;
                    else
                        chedo1_an++;
                }

                // CHẾ ĐỘ 2
                else if (item.CheDoID == 2)
                {
                    chedo2_total++;

                    if (item.KhongAn)
                        chedo2_khongan++;
                    else
                        chedo2_an++;
                }
            }

            // PANEL 1
            lblTongQuanSo.Text =
                $"👥 Tổng quân số: {tongQuanSo}";

            // PANEL 2
            lblCheDo1.Text =
                $"🍱 Chế độ 1: {chedo1_an}/{chedo1_total} | Không ăn: {chedo1_khongan}";

            // PANEL 3
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
                DateTime ngay = dtpngay.Value;
                int mabuoi = Convert.ToInt32(cbobuoi.SelectedValue);
                int madv = Convert.ToInt32(cbodonvi.SelectedValue);

                int kq = B_BQS.KiemTraDaBao(ngay, mabuoi, madv);
                if (kq == 1)
                {
                    MessageBox.Show("Đơn vị này đã báo quân số rồi!");
                    btnluu.Enabled = false;
                    return;
                }

                // Đếm quân số ăn theo chế độ
                Dictionary<int, int> demchedo = new Dictionary<int, int>();

                // Duyệt dữ liệu thật
                foreach (var item in dsBaoCom.Values)
                {
                    if (item.KhongAn == true) // KHÔNG ĂN
                    {
                        catcom cc = new catcom { ngay_thang_nam = ngay, buoian_id = mabuoi, donvi_id = madv, quannhan_id = item.QuannhanID };
                        B_BQS.insertcatcom(cc);
                    }
                    else // CÓ ĂN
                    {
                        if (demchedo.ContainsKey(item.CheDoID)) demchedo[item.CheDoID]++;
                        else demchedo.Add(item.CheDoID, 1);
                    }
                }

                // Insert quân số ăn
                foreach (var item in demchedo)
                {
                    quansoan qsa = new quansoan { chedo_id = item.Key, soluong = item.Value, ngay_thang_nam = ngay, buoian_id = mabuoi, donvi_id = madv };
                    B_BQS.insertqsa(qsa);
                }

                btnluu.Enabled = false;
                MessageBox.Show("Lưu cắt cơm thành công!");
                ResetForm();
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

        }
        private void dgvbqs_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvbqs.IsCurrentCellDirty)
            {
                dgvbqs.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void frmbqs_Load(object sender, EventArgs e)
        {
            LoadBuoi();
            LoadDonvi();
            dgvbqs.DataSource = null;
            dgvbqs.CurrentCellDirtyStateChanged += dgvbqs_CurrentCellDirtyStateChanged;
            dgvbqs.CellValueChanged += dgvbqs_CellValueChanged;
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
                    int maquan = Convert.ToInt32(
                        dgvbqs.Rows[e.RowIndex].Cells["colMaQN"].Value);

                    int chedo = Convert.ToInt32(
                        dgvbqs.Rows[e.RowIndex].Cells["colchedoid"].Value);

                    bool khongan = Convert.ToBoolean(
                        dgvbqs.Rows[e.RowIndex].Cells["colKan"].Value);

                    if (dsBaoCom.ContainsKey(maquan))
                    {
                        dsBaoCom[maquan].KhongAn = khongan;
                    }
                    else
                    {
                        dsBaoCom.Add(maquan,
                            new TrangThaiCatCom()
                            {
                                QuannhanID = maquan,
                                CheDoID = chedo,
                                KhongAn = khongan
                            });
                    }

                    // realtime panel
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
