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

namespace frmnhanvien
{
    public partial class frm_manhinh_nhanvien : Form
    {
        frmdsthucpham fdstp;
        frmlapthucdon fltd;
        frmbaocaothucpham fbctp;
        frmbaocaoquanso fbcqs;
        frmtinhtpcansudung ftpcsd;

        public frm_manhinh_nhanvien()
        {
            InitializeComponent();
        }



        private void frm_manhinh_nhanvien_Load(object sender, EventArgs e)
        {

        }
        bool hethongExpand = false;
        private void hethongtrasition_Tick(object sender, EventArgs e)
        {
            if (hethongExpand == false)
            {
                hethongcontainer.Height += 5;
                if (hethongcontainer.Height >= 140)
                {
                    hethongtrasition.Stop();
                    hethongExpand = true;
                }
            }
            else
            {
                hethongcontainer.Height -= 5;
                if (hethongcontainer.Height <= 50)
                {
                    hethongtrasition.Stop();
                    hethongExpand = false;
                }
            }
        }
        bool slidebarExpand = true;
        private void slidebartransition_Tick(object sender, EventArgs e)
        {
            if (slidebarExpand)
            {
                slidebar.Width -= 10;
                if (slidebar.Width <= 50)
                {
                    slidebarExpand = false;
                    slidebartransition.Stop();
                    hethongcontainer.Width = slidebar.Width;
                    pndanhsachthucpham.Width = slidebar.Width;
                    baocaocontainer.Width = slidebar.Width;
                    thucdoncontainer.Width = slidebar.Width;


                }
            }
            else
            {
                slidebar.Width += 10;
                if (slidebar.Width >= 170)
                {
                    slidebarExpand = true;
                    slidebartransition.Stop();
                    hethongcontainer.Width = slidebar.Width;
                    pndanhsachthucpham.Width = slidebar.Width;
                    baocaocontainer.Width = slidebar.Width;
                    thucdoncontainer.Width = slidebar.Width;


                }
            }
        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            slidebartransition.Start();
        }

        private void btndstp_Click(object sender, EventArgs e)
        {
            if (fdstp == null)
            {
                fdstp = new frmdsthucpham();
                fdstp.MdiParent = this;

                fdstp.Dock = DockStyle.Fill;
                fdstp.FormClosed += (s, args) => fdstp = null;
                fdstp.Show();
            }
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

        private void btnlapthucdon_Click(object sender, EventArgs e)
        {

            if (fltd == null)
            {
                fltd = new frmlapthucdon();
                fltd.MdiParent = this;

                fltd.Dock = DockStyle.Fill;
                fltd.FormClosed += (s, args) => fltd = null;
                fltd.Show();
            }
        }

        private void btnbcthucpham_Click(object sender, EventArgs e)
        {
            if (fbctp == null)
            {
                fbctp = new frmbaocaothucpham();
                fbctp.MdiParent = this;

                fbctp.Dock = DockStyle.Fill;
                fbctp.FormClosed += (s, args) => fbctp = null;
                fbctp.Show();
            }
        }

        private void btnbcquanso_Click(object sender, EventArgs e)
        {
            if (fbcqs == null)
            {
                fbcqs = new frmbaocaoquanso();
                fbcqs.MdiParent = this;

                fbcqs.Dock = DockStyle.Fill;
                fbcqs.FormClosed += (s, args) => fbcqs = null;
                fbcqs.Show();
            }
        }

        private void btntinhtp_Click(object sender, EventArgs e)
        {
            if (ftpcsd == null)
            {
                ftpcsd = new frmtinhtpcansudung();
                ftpcsd.MdiParent = this;

                ftpcsd.Dock = DockStyle.Fill;
                ftpcsd.FormClosed += (s, args) => ftpcsd = null;
                ftpcsd.Show();
            }
        }

        private void btnhethong_Click(object sender, EventArgs e)
        {
            hethongtrasition.Start();
        }

        bool thucdonExpand = false;
        private void thucdontransition_Tick(object sender, EventArgs e)
        {
            if (thucdonExpand == false)
            {
                thucdoncontainer.Height += 5;
                if (thucdoncontainer.Height >= 140)
                {
                    thucdontransition.Stop();
                    thucdonExpand = true;
                }
            }
            else
            {
                thucdoncontainer.Height -= 5;
                if (thucdoncontainer.Height <= 50)
                {
                    thucdontransition.Stop();
                    thucdonExpand = false;
                }
            }

        }

        private void btnthucdon_Click(object sender, EventArgs e)
        {
            thucdontransition.Start();
        }
        bool baocaoExpand = false;
        private void baocaotransition_Tick(object sender, EventArgs e)
        {
            if (baocaoExpand == false)
            {
                baocaocontainer.Height += 5;
                if (baocaocontainer.Height >= 140)
                {
                    baocaotransition.Stop();
                    baocaoExpand = true;
                }
            }
            else
            {
                baocaocontainer.Height -= 5;
                if (baocaocontainer.Height <= 50)
                {
                    baocaotransition.Stop();
                    baocaoExpand = false;
                }
            }
        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            baocaotransition.Start();
        }

        private void slidebar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
