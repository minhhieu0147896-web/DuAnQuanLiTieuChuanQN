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
using DuAn.DAO;

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmdsthucpham : Form
    {
        public frmdsthucpham()
        {
            InitializeComponent();
        }
        private void ResetForm()
        {
            // TextBox
         
            txtdonvi.Clear();
            txtgia.Clear();
            txtten.Clear();
            txtkcal.Clear();


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void dgvlscc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
   
            DataGridViewRow row = dgvdstp.Rows[e.RowIndex];
           txtten.Text = row.Cells["colthucpham"].Value.ToString();
            txtdonvi.Text = row.Cells["coldonvi"].Value.ToString();
            txtgia.Text = row.Cells["colgia"].Value.ToString();
            txtkcal.Text = row.Cells["colkcal"].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void frmdsthucpham_Load(object sender, EventArgs e)
        {
            dgvdstp.AutoGenerateColumns = false;

           
            dgvdstp.DataSource = null;
        }

        private void btntracuu_Click(object sender, EventArgs e)
        {
            dgvdstp.DataSource = B_DSTP.getalltp();
        }

        private void button1_Click(object sender, EventArgs e) //them
        {
            string ten = txtten.Text.Trim();
            decimal gia = decimal.Parse(txtgia.Text.Trim());
            string donvi = txtdonvi.Text.Trim();
         decimal kcal = decimal.Parse(txtkcal.Text.Trim());
            thucpham tp = new thucpham(ten, gia, donvi, kcal);
            B_DSTP.inserttp(tp);
            MessageBox.Show("Thêm thành công!");
            ResetForm();
            dgvdstp.DataSource = B_DSTP.getalltp(); 
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string ten = txtten.Text.Trim();
            decimal gia = decimal.Parse(txtgia.Text.Trim());
            string donvi = txtdonvi.Text.Trim();
            decimal kcal = decimal.Parse(txtkcal.Text.Trim());
            int id = Convert.ToInt32(dgvdstp.CurrentRow.Cells["coltpid"].Value);
            thucpham tp = new thucpham(id, ten, gia, donvi, kcal);
            B_DSTP.Updatetp(tp);
            MessageBox.Show("Cập nhật thành công!");
            ResetForm();
            dgvdstp.DataSource = B_DSTP.getalltp();

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            int thucpham_id = Convert.ToInt32(dgvdstp.CurrentRow.Cells["coltpid"].Value);
            DialogResult tb;

            tb = MessageBox.Show
            (
                "Bạn có muốn xóa không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (thucpham_id == 0)
            {
                MessageBox.Show("Vui lòng chọn thực phẩm cần xóa");
                return;
            }

            DialogResult r = MessageBox.Show(
                "Bạn chắc chắn muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                B_DSTP.Deletetp(thucpham_id);

                MessageBox.Show("Xóa thành công");

                dgvdstp.DataSource = B_DSTP.getalltp();
                ResetForm();
              
            }
        }

        private void dgvdstp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvdstp.Rows[e.RowIndex];
            txtten.Text = row.Cells["colthucpham"].Value.ToString();
            txtdonvi.Text = row.Cells["coldonvi"].Value.ToString();
            txtgia.Text = row.Cells["colgia"].Value.ToString();
            txtkcal.Text = row.Cells["colkcal"].Value.ToString();
        }
    }
}
