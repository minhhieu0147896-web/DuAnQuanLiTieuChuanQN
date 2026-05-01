using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn.BUL;
using DuAn.DTO;



namespace DuAn.GUI.frmfornhvhc
{
    public partial class frmdsqn : Form
    {
        

    
        void LoadCheDo()
        {
            cbochedo.DataSource = B_QN.GetAllCheDo();

            cbochedo.DisplayMember = "chedo_ten";
            cbochedo.ValueMember = "chedo_id";
        }
        void LoadDonvi()
        {
            cbodonvi.DataSource = B_QN.GetAllDonVi();

            cbodonvi.DisplayMember = "donvi_ten";
            cbodonvi.ValueMember = "donvi_id";
        }

        public frmdsqn()
        {
            InitializeComponent();
        }

        private void frmquannhan_Load(object sender, EventArgs e)
        {
            dgvdsqn.AutoGenerateColumns = false;
            dgvdsqn.DataSource= B_QN.getallqn();
            LoadCheDo();
            LoadDonvi();
        }

        private void dgvdsqn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận ",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten=txtten.Text.Trim();
            int donvi=Convert.ToInt32(cbodonvi.SelectedValue);
            int chedo=Convert.ToInt32(cbochedo.SelectedValue);
            quannhan qn = new quannhan(ten, donvi, chedo);
            B_QN.insertQN(qn);
            MessageBox.Show("Bạn dã thêm thành công");
            dgvdsqn.DataSource=B_QN.getallqn();

        }
        int idchon = 0;
        private void dgvdsqn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvdsqn.Rows[e.RowIndex];
           idchon = Convert.ToInt32(row.Cells["colid"].Value);
            txtten.Text = row.Cells["colten"].Value.ToString();
            cbodonvi.Text = row.Cells["coldonvi"].Value.ToString();
            cbochedo.Text = row.Cells["colchedo"].Value.ToString();

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (idchon == 0)
            {
                MessageBox.Show("Vui lòng chọn quân nhân cần sửa");
                return;
            }

            string ten = txtten.Text.Trim();
            int donvi = Convert.ToInt32(cbodonvi.SelectedValue);
            int chedo = Convert.ToInt32(cbochedo.SelectedValue);

            quannhan qn = new quannhan(idchon, ten, donvi, chedo);

            B_QN.UpdateQN(qn);

            MessageBox.Show("Cập nhật thành công");

            dgvdsqn.DataSource = B_QN.getallqn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idchon == 0)
            {
                MessageBox.Show("Vui lòng chọn quân nhân cần xóa");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn chắc chắn muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                B_QN.DeleteQN(idchon);

                MessageBox.Show("Xóa thành công");

                dgvdsqn.DataSource = B_QN.getallqn();

                txtten.Clear();
                idchon = 0;
            }
        }

        private void pnlcrud_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnldien_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
