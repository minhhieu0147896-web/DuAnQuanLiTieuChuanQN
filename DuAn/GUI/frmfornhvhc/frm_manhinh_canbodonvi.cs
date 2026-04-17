using DuAn.GUI.frmfornhvhc;
using frmlogin;
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
        frmbqs fbqs;
        frmLSQS flsqs;

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
          
             bool hethongExpand = false;

        private void hethongtrasition_Tick(object sender, EventArgs e)
        {
            if (hethongExpand == false)
            {
                hethongcontainer.Height += 5;
                if (hethongcontainer.Height >= 217)
                {
                    hethongtrasition.Stop();
                    hethongExpand = true;
                }
            }
            else
            {
                hethongcontainer.Height -= 5;
                if (hethongcontainer.Height <= 67)
                {
                    hethongtrasition.Stop();
                    hethongExpand = false;
                }
            }
        }

        private void btnhethong_Click(object sender, EventArgs e)
        {
            hethongtrasition.Start();
        }
        bool quansoExpand = false;
        private void quansotransition_Tick(object sender, EventArgs e)
        {

            if (quansoExpand == false)
            {
                quansocontainer.Height += 5;
                if (quansocontainer.Height >= 217)
                {
                    quansotransition.Stop();
                    quansoExpand = true;
                }
            }
            else
            {
                quansocontainer.Height -= 5;
                if (quansocontainer.Height <= 67)
                {
                    quansotransition.Stop();
                    quansoExpand = false;
                }
            }
        }
        bool slidebarExpand = true;

        private void slidebartransition_Tick(object sender, EventArgs e)
        {
            if (slidebarExpand)
            {
                slidebar.Width -= 10;
                if (slidebar.Width <= 67)
                {
                    slidebarExpand = false;
                    slidebartransition.Stop();
                    hethongcontainer.Width = slidebar.Width;
                    quansocontainer.Width = slidebar.Width;

                }
            }
            else
            {
                slidebar.Width += 10;
                if (slidebar.Width >= 247)
                {
                    slidebarExpand = true;
                    slidebartransition.Stop();
                    hethongcontainer.Width = slidebar.Width;
                    quansocontainer.Width = slidebar.Width;

                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            slidebartransition.Start();
        }

        private void btnquanso_Click(object sender, EventArgs e)
        {
            quansotransition.Start();

        }

        private void slidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnbqs_Click(object sender, EventArgs e)
        {
           
        }

        private void btnlsa_Click(object sender, EventArgs e)
        {
          
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không ?", "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmmhlogin f = new frmmhlogin();
                f.Show();
                this.Hide();

            }
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

        private void hethongcontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnbqs_Click_1(object sender, EventArgs e)
        {
            if (fbqs == null)
            {
                fbqs = new frmbqs();
                fbqs.MdiParent = this;
                fbqs.Dock = DockStyle.Fill;
                fbqs.FormClosed += (s, args) => fbqs = null;
                fbqs.Show();
            }
        }

        private void btnlsa_Click_1(object sender, EventArgs e)
        {
            if (flsqs == null)
            {
                flsqs = new frmLSQS();
                flsqs.MdiParent = this;

                flsqs.Dock = DockStyle.Fill;
           
                flsqs.Show();
            }
        }
    }
}
