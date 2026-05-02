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

namespace frmfornhvhc
{
    public partial class frmLSQS : Form
    {
        public frmLSQS()
        {
            InitializeComponent();
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
            LSBQS ls = new LSBQS();

            ls.tungay = dtptungay.Value;
            ls.denngay = dtpdenngay.Value;
            ls.donvi_id = Convert.ToInt32(cbodonvi.SelectedValue);
            ls.buoian_id = Convert.ToInt32(cbobuoi.SelectedValue);

            DataTable dt = B_LSBQS.TraCuu(ls);

            dgvlsbqs.AutoGenerateColumns = false;
            dgvlsbqs.DataSource = dt;
        }

        private void pnlluachon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLSQS_Load(object sender, EventArgs e)
        {
            LoadBuoi();
            LoadDonvi();
        }
    }
}
