using frmnhanvien;
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
                frm_manhinh_nhanvien frm = new frm_manhinh_nhanvien();
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
    }
}
