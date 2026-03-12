using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmnhanvien
{
    public partial class frm_manhinh_nhanvien : Form
    {
        public frm_manhinh_nhanvien()
        {
            InitializeComponent();
        }

        private void địnhLượngTiêuChuẩnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void danhSáchThựcPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            frmdsthucpham f = new frmdsthucpham();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void lậpThựcĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            frmlapthucdon f = new frmlapthucdon();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tínhThựcPhẩmCầnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            frmtinhtpcansudung f = new frmtinhtpcansudung();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void báoCáoThựcPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            frmbaocaothucpham f = new frmbaocaothucpham();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void báoCáoQuânSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            frmbaocaoquanso f = new frmbaocaoquanso();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
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
