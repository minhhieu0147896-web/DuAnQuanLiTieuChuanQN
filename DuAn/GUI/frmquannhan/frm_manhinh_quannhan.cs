using frmfornhvhc;
using frmlogin;
using frmquannhan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn.GUI.frmquannhan
{
    public partial class frm_manhinh_quannhan : Form
    {
        frmlichsucatcom flscc;
        public frm_manhinh_quannhan()
        {
            InitializeComponent();
        }

        private void frm_manhinh_quannhan_Load(object sender, EventArgs e)
        {
       
        }

        private void btnquanso_Click(object sender, EventArgs e)
        {
            if (flscc == null)
            {
                flscc = new frmlichsucatcom();
                flscc.MdiParent = this;

                flscc.Dock = DockStyle.Fill;
                flscc.FormClosed += (s, args) => flscc = null;
                flscc.Show();
            }
        }

        private void btnhethong_Click(object sender, EventArgs e)
        {
            hethongtrasition.Start();

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
        bool slidebarExpand = true;
        private void slidebarstransition_Tick(object sender, EventArgs e)
        {
            if (slidebarExpand)
            {
                slidebar.Width -= 10;
                if (slidebar.Width <= 67)
                {
                    slidebarExpand = false;
                    slidebartransition.Stop();
                    hethongcontainer.Width = slidebar.Width;
                    pnlichsucatcom.Width = slidebar.Width;
                 

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
                    pnlichsucatcom.Width = slidebar.Width;


                }
            }
        }
     

        private void btnHam_Click(object sender, EventArgs e)
        {
            slidebartransition.Start();
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

        private void btnthoat_Click_1(object sender, EventArgs e)
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







