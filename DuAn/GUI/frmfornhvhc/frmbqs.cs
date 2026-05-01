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

namespace frmfornhvhc
{
    public partial class frmbqs : Form
    {
        public frmbqs()
        {
            InitializeComponent();
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
        }
        void LoadBuoi()
        {
            cbobuoi.DataSource = B_BQS.loadbuoi();

            cbobuoi.DisplayMember = "buoian_ten";
            cbobuoi.ValueMember = "buoian_id";
        }
        void LoadDonvi()
        {
            cbodonvi.DataSource = B_QN.GetAllDonVi();

            cbodonvi.DisplayMember = "donvi_ten";
            cbodonvi.ValueMember = "donvi_id";
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


                Dictionary<int, int> demchedo = new Dictionary<int, int>();

                foreach (DataGridViewRow row in dgvbqs.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool khongan = false;

                    if (row.Cells["colKan"].Value != null)
                    {
                        khongan = Convert.ToBoolean(row.Cells["colKan"].Value);
                    }
                    int maquan =
                    Convert.ToInt32(
                        row.Cells["colMaQN"].Value
                    );

                    int chedo_id =
                        Convert.ToInt32(
                            row.Cells["colCheDoID"].Value
                        );

                    if (khongan == true)
                    {
                        catcom cc = new catcom();

                        cc.ngay_thang_nam = ngay;
                        cc.buoian_id = mabuoi;
                        cc.donvi_id = madv;
                        cc.quannhan_id = maquan;
                        B_BQS.insertcatcom(cc);
                    }
                    else
                    {
                        if (demchedo.ContainsKey(chedo_id))
                        {
                            demchedo[chedo_id]++;
                        }
                        else
                        {
                            demchedo.Add(chedo_id, 1);
                        }
                    }
                    foreach (var item in demchedo)
                    {
                        quansoan qsa = new quansoan();
                        qsa.chedo_id = item.Key;
                        qsa.soluong = item.Value;
                        qsa.ngay_thang_nam = ngay;
                        qsa.buoian_id = mabuoi;
                        qsa.donvi_id = madv;
                        B_BQS.insertqsa(qsa);
                    }
                    btnluu.Enabled = false;
                    MessageBox.Show("Lưu cắt cơm thành công!");
                    ResetForm();
                }
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

        private void frmbqs_Load(object sender, EventArgs e)
        {
            LoadBuoi();
            LoadDonvi();
            dgvbqs.DataSource = null;
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            int madv = Convert.ToInt32(cbodonvi.SelectedValue);

            dgvbqs.AutoGenerateColumns = false;

            dgvbqs.DataSource = B_BQS.loadbqs(madv);
            KiemTraNutLuu();
        }
    }
}
