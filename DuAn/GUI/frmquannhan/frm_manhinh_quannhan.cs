using DuAn.DTO;
using DuAn.GUI.frmfornhvhc;
using DuAn.GUI.frmlogin;
using DuAn.GUI.frmquannhan;
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
        frmthongke_qn fthongke;
        frmtracuudlvathucdon frmtracuudlvathucdon;
        public qnlogin qnDangNhap { get; set; }
        public frm_manhinh_quannhan()
        {
            InitializeComponent();
        }
        void CloseAllChildForms()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }
        private void frm_manhinh_quannhan_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            CloseAllChildForms();
            DuAn.GUI.frmquannhan.frmtrangchu f = new DuAn.GUI.frmquannhan.frmtrangchu(qnDangNhap);
            f.MdiParent = this;
           

            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void btnquanso_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            flscc = new frmlichsucatcom(qnDangNhap);
            flscc.MdiParent = this;
            flscc.Dock = DockStyle.Fill;
            flscc.FormClosed += (s, args) => flscc = null;
            flscc.Show();
            
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
        private void slidebarstransition_Tick(object sender, EventArgs e)
        {
            if (slidebarExpand)
            {
                slidebar.Width -= 10;
                if (slidebar.Width <= 50)
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
                if (slidebar.Width >= 170)
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

        private void hethongcontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void slidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            fthongke = new frmthongke_qn(qnDangNhap);
            fthongke.MdiParent = this;
            fthongke.Dock = DockStyle.Fill;
            fthongke.Show();
            fthongke.FormClosed += (s, args) => fthongke = null;
            fthongke.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btntracuu_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            frmtracuudlvathucdon = new frmtracuudlvathucdon();
            frmtracuudlvathucdon.MdiParent = this;
            frmtracuudlvathucdon.Dock = DockStyle.Fill;
            frmtracuudlvathucdon.FormClosed += (s, args) => frmtracuudlvathucdon = null;
            frmtracuudlvathucdon.Show();

        }
    }
}







