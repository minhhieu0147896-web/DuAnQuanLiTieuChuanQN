using frmnhanvien;
using frmquannhan;
using frmfornhvhc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn.GUI.frmquannhan;

namespace frmlogin
{
    public partial class frmmhlogin : Form
    {
        public frmmhlogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Gainsboro;
            textBox3.BackColor = Color.Gainsboro;

            textBox1.ForeColor = Color.Black;
            textBox3.ForeColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               frm_manhinh_canbodonvi frm = new frm_manhinh_canbodonvi();
              //  frm_manhinh_canbodonvi  frm = new frm_manhinh_canbodonvi();
                frm.Show();
                this.Hide();

                // connect form login vs form khac o day
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result==DialogResult.Yes)
            {
                Close();
            }
                       
        }

        private void frmlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận ",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else if( result == DialogResult.Yes)
            {
                e.Cancel = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            pnlogin.BackColor = Color.FromArgb(120, 0, 0, 0);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 30;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(pnlogin.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(pnlogin.Width - radius, pnlogin.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, pnlogin.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            pnlogin.Region = new Region(path);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
              //  frm_manhinh_quannhan frm = new frm_manhinh_quannhan();
              //  frm_manhinh_canbodonvi frm = new frm_manhinh_canbodonvi();
                frm_manhinh_nhanvien frm = new frm_manhinh_nhanvien();
                frm.Show();
                this.Hide();

                // connect form login vs form khac o day
            }
        }

        private void lbldangnhap_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
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
