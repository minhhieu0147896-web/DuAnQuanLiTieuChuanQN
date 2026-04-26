using DuAn.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmfornhvhc
{
    public partial class frmbqs : Form
    {
        public frmbqs()
        {
            InitializeComponent();
        }
        private void LoadComboBoxDonVi()
        {
            DataTable dt = baoquansoDAO.Instance.getdonvi();
            cbodonvi.DataSource = dt;
            cbodonvi.DisplayMember = "donvi_ten";
            cbodonvi.ValueMember = "donvi_id";
            cbodonvi.SelectedIndex = -1;
        }

        private void LoadComboBoxBuoiAn()
        {
            DataTable dt = baoquansoDAO.Instance.getbuoian();
            cbobuoi.DataSource = dt;
            cbobuoi.DisplayMember = "buoian_ten";
            cbobuoi.ValueMember = "buoian_id";
            cbobuoi.SelectedIndex = -1;
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
            if (cbodonvi.SelectedValue == null || cbobuoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị và buổi ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime ngay = dtpngay.Value;
            int buoian_id = Convert.ToInt32(cbobuoi.SelectedValue);
            int donvi_id = Convert.ToInt32(cbodonvi.SelectedValue);
            if (baoquansoDAO.Instance.DaTonTai(ngay, buoian_id, donvi_id))
            {
                MessageBox.Show("Buổi ăn đã được chốt. Không thể lưu thay đổi.", "Đã chốt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Xác nhận
            if (MessageBox.Show(
                  "Chắc chắn chốt quân số?\nSau khi lưu không thể sửa!",
                  "Xác nhận", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning) == DialogResult.No)
                return;
            try
            {
                // Bước 1: Lưu phiếu cắt cơm
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.IsNewRow) continue;
                    bool khongAn = row.Cells["KhongAn"].Value != null &&
                                   Convert.ToBoolean(row.Cells["KhongAn"].Value);
                    if (!khongAn) continue;

                    int maQN = Convert.ToInt32(row.Cells["id"].Value);
                    string lydo = row.Cells["LyDo"].Value?.ToString()
                                  ?? "Không ăn";

                    baoquansoDAO.Instance.insertphieucatcom(
                      maQN, ngay, buoian_id);
                }

            
           
            baoquansoDAO.Instance.insertquansoan(ngay, buoian_id, donvi_id);
            MessageBox.Show("Lưu quân số thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnluu.Enabled = false;
             }
             catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbobuoi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmbqs_Load(object sender, EventArgs e)
        {
            LoadComboBoxBuoiAn();
            LoadComboBoxDonVi();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            if (cbodonvi.SelectedValue == null || cbobuoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị và buổi ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int donvi_id = Convert.ToInt32(cbodonvi.SelectedValue);
            int buoian_id = Convert.ToInt32(cbobuoi.SelectedValue);
            DataTable dt= baoquansoDAO.Instance.getQNtheodonvi(donvi_id);
            if (!dt.Columns.Contains("KhongAn"))
                dt.Columns.Add("KhongAn", typeof(bool))
                           .DefaultValue = false;
            dgvdata.DataSource = dt;
            ConfigureGridColumns();
            bool daChot = baoquansoDAO.Instance
               .DaTonTai(dtpngay.Value, buoian_id, donvi_id);
            btnluu.Enabled = !daChot;
            if (daChot)
                MessageBox.Show("Buổi ăn đã được chốt. Chỉ xem.",
                  "Đã chốt", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
        }
        private void ConfigureGridColumns()
        {
            // Ẩn cột nội bộ
            if (dgvdata.Columns["chedo_id"] != null)
                dgvdata.Columns["chedo_id"].Visible = false;

            dgvdata.Columns["id"].HeaderText = "Mã QN";
            dgvdata.Columns["id"].Width = 70;
            dgvdata.Columns["id"].ReadOnly = true;

            // Cột Không ăn: checkbox
            if (dgvdata.Columns["KhongAn"] is
                DataGridViewCheckBoxColumn cb)
            {
                cb.HeaderText = "Không ăn"; cb.Width = 80;
            }
            
        }

    }
}
