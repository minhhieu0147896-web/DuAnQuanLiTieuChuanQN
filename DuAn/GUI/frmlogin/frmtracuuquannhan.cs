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
using DuAn.GUI.frmquannhan;
using DuAn.GUI.frmfornhvhc;
using DuAn.GUI.frmlogin;
using DuAn.GUI.ADMIN;

namespace DuAn.GUI.frmlogin
{
    public partial class frmtracuuquannhan : Form
    {
        public frmtracuuquannhan()
        {
            InitializeComponent();
        }

        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            string maNhapVao = txtma.Text.Trim();

            if (maNhapVao.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                frmAdmin formAdmin = new frmAdmin();
                formAdmin.Show();
                this.Hide();
                return;
            }

            int maqn;

            if (!int.TryParse(maNhapVao, out maqn))
            {
                MessageBox.Show("Mã quân nhân không hợp lệ");

                return;
            }

            qnlogin qn =
                B_QNlogin.GetQuanNhanByMa(maqn);

            if (qn == null)
            {
                MessageBox.Show("Không tìm thấy quân nhân");

                return;
            }

            frm_manhinh_quannhan f =  new frm_manhinh_quannhan();

            f.qnDangNhap = qn;

            f.Show();

            this.Hide();
        }

        private void frmtracuuquannhan_Load(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Bạn có chắc chắn muốn thoát không?",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmmhlogin f = new frmmhlogin();

                f.Show();

                this.Hide();
            }
        }
    }
}
