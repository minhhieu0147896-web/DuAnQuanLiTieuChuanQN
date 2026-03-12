using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmquannhan
{
    public partial class frmquannhan : Form
    {
        public frmquannhan()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tiêuChuẩnĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtracuutieuchuanan f = new frmtracuutieuchuanan();
            f.MdiParent = this;
            f.Show();
        }

        private void lịchSửCắtCơmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmlichsucatcom f = new frmlichsucatcom();
            f.MdiParent = this;
            f.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận ",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
