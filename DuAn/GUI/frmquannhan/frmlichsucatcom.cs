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
using DuAn.BUL;
using System.Data.SqlClient;
using DuAn.DAO;


namespace DuAn.GUI.frmquannhan
{
    public partial class frmlichsucatcom : Form
    {
        private qnlogin qnDangNhap;
        public frmlichsucatcom(qnlogin qn)
        {
            InitializeComponent();
            qnDangNhap = qn;
        }

        private void lbltieude_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
     
        void TinhTongTien(DataTable dt)
        {
            decimal tong = 0;

            foreach (DataRow row in dt.Rows)
            {
                tong += Convert.ToDecimal(row["tiencatcom"]);
            }

            lblsum.Text = tong.ToString("N0") + " VND";
        }
        void LoadLSCC()
        {
            LSCC ls = new LSCC();

            ls.quannhan_id = qnDangNhap.quannhan_id;

            ls.tungay = dtptungay.Value.Date;
            ls.denngay = dtpdenngay.Value.Date;

            DataTable dt = B_LSCC.TraCuu(ls);

            dgvlscc.AutoGenerateColumns = false;
            dgvlscc.DataSource = dt;

            TinhTongTien(dt);
        }
        private void btntracuu_Click(object sender, EventArgs e)
        {
          
           LoadLSCC();


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

        private void dgvlscc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
