using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn.BUL;
using System.Data.SqlClient;
using DuAn.DAO;

namespace DuAn.GUI.frmquannhan
{
    public partial class frmtrangchu : Form
    {
        public qnlogin qnDangNhap;
        public frmtrangchu()
        {
            InitializeComponent();
        }

        private void pnlbtn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmtrangchu_Load(object sender, EventArgs e)
        {
            if (qnDangNhap != null)
            {
                lbltieude.Text =
                    "Chào mừng, " +
                    qnDangNhap.quannhan_hoten;

                lbldonvi.Text =
                    "Đơn vị: " +
                    qnDangNhap.donvi_ten;

                lblchedo.Text =
                    "Chế độ: " +
                    qnDangNhap.chedo_ten;
            }
        }

        private void pnllsbqs_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbldonvi_Click(object sender, EventArgs e)
        {

        }
    }
}
