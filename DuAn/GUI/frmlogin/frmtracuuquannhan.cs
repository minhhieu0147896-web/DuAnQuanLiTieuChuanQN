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
            int maqn;

            if (!int.TryParse(txtma.Text, out maqn))
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
    }
}
