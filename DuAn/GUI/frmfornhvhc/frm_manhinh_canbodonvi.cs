using DuAn.GUI.frmfornhvhc;
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
    public partial class frm_manhinh_canbodonvi : Form
    {
        public frm_manhinh_canbodonvi()
        {
            InitializeComponent();
        }

        private void frm_manhinh_canbodonvi_Load(object sender, EventArgs e)
        {
            frmtrangchu f = new frmtrangchu();
            f.MdiParent = this;
          
            this.WindowState = FormWindowState.Maximized;
            f.Show();

        }

        private void báoQuânSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            frmbqs f = new frmbqs();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            frmLSQS f=new frmLSQS();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();   

        }

        private void danhSáchQuânNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
            frmddtc f = new frmddtc();
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtrangchu f = new frmtrangchu();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }
    }
}
