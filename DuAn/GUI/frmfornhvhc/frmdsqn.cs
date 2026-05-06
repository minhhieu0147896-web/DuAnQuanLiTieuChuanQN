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
            DataTable dt = B_QN.GetAllCheDo();

            // thêm dòng mặc định
            DataRow row = dt.NewRow();
            row["chedo_id"] = 0;
            row["chedo_ten"] = "Tất cả chế độ";

            dt.Rows.InsertAt(row, 0);

            cbochedo.DataSource = dt;
            cbochedo.DisplayMember = "chedo_ten";
            cbochedo.ValueMember = "chedo_id";

            // mặc định chọn dòng đầu
            cbochedo.SelectedIndex = 0;
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
        private void ResetForm()
        {
            // TextBox
            txtmaqn.Clear();
            txtten.Clear();

            // ComboBox (về trạng thái chưa chọn)
            cbodonvi.SelectedIndex = 0;
            cbochedo.SelectedIndex = 0;

            // Nếu có checkbox/radio thì reset luôn (nếu có)
            // chkSomething.Checked = false;

            // Focus lại ô đầu tiên cho đẹp UX
            txtmaqn.Focus();
        }
        public frmdsqn()
        {
            InitializeComponent();
        }

        private void frmquannhan_Load(object sender, EventArgs e)
        {
            dgvdsqn.AutoGenerateColumns = false;
      
            LoadCheDo();
            LoadDonvi();
            dgvdsqn.DataSource = null;
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
            string inputmaqn= txtmaqn.Text.Trim();
            if (string.IsNullOrWhiteSpace(inputmaqn))
            {
                MessageBox.Show("Mã quân nhân không được để trống");
                txtmaqn.Focus();
                return;

            }
            if (!int.TryParse(inputmaqn, out int maqn))
            {
                MessageBox.Show("Mã quân nhân phải là số");
                txtmaqn.Focus();
                return;
            }
            if (B_QN.checkmaqn(maqn) == 1)
            {
                MessageBox.Show("Mã quân nhân đã tồn tại, vui lòng nhập mã khác");
                txtmaqn.Focus();
                return;
            }    

                int donvi = Convert.ToInt32(cbodonvi.SelectedValue);
                int chedo = Convert.ToInt32(cbochedo.SelectedValue);
                quannhan qn = new quannhan(maqn, ten, donvi, chedo);
                B_QN.insertQN(qn);
                MessageBox.Show("Bạn đã thêm thành công");
                dgvdsqn.DataSource = B_QN.getallqn();
            
        }
        int maqn_cu = 0;
      
        private void dgvdsqn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvdsqn.Rows[e.RowIndex];
           maqn_cu = Convert.ToInt32(row.Cells["colid"].Value);
            txtmaqn.Text = maqn_cu.ToString();
            txtten.Text = row.Cells["colten"].Value.ToString();
            cbodonvi.Text = row.Cells["coldonvi"].Value.ToString();
            cbochedo.Text = row.Cells["colchedo"].Value.ToString();

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (maqn_cu == 0)
            {
                MessageBox.Show("Vui lòng chọn quân nhân cần sửa");
                return;
            }
           

            string ten = txtten.Text.Trim();
            int donvi = Convert.ToInt32(cbodonvi.SelectedValue);
            int chedo = Convert.ToInt32(cbochedo.SelectedValue);

            quannhan qn = new quannhan(maqn_cu,ten, donvi, chedo);

            B_QN.UpdateQN(qn);
          

            MessageBox.Show("Cập nhật thành công");

            dgvdsqn.DataSource = B_QN.getallqn();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maqn_cu == 0)
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
                B_QN.DeleteQN(maqn_cu);

                MessageBox.Show("Xóa thành công");

                dgvdsqn.DataSource = B_QN.getallqn();

               ResetForm();
               maqn_cu = 0;
            }
        }

        private void pnlcrud_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnldien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbodonvi.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị");
                return;
            }

            int donvi = Convert.ToInt32(cbodonvi.SelectedValue);
            int chedo = Convert.ToInt32(cbochedo.SelectedValue);

            dgvdsqn.DataSource = B_QN.TimKiemQN(donvi, chedo);
        
         }

        private void cbodonvi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnreset_Click_1(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
