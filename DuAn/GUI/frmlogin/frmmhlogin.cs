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
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi DAO để xác thực
            DuAn.DAO.AccountModel acc = DuAn.DAO.AccountDAO.Instance.Login(
                textBox1.Text.Trim(),
                textBox3.Text.Trim()
            );

            if (acc == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Đăng nhập thành công! Xin chào {acc.HoTen}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Phân quyền theo vai_tro
            // Thay số 1/2 cho đúng với giá trị thực tế trong DB của bạn
            if (acc.VaiTro == 1) // QuanNhan
            {
                frmquannhan.frm_manhinh_quannhan frm = new frmquannhan.frm_manhinh_quannhan();
                frm.Show();
            }
            else if (acc.VaiTro == 2) // NhanVien
            {
                frmnhanvien.frm_manhinh_nhanvien frm = new frmnhanvien.frm_manhinh_nhanvien();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Vai trò không hợp lệ!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
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
