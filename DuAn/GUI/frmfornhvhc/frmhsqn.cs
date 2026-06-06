using DuAn.BUL;
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

namespace DuAn.GUI.frmfornhvhc
{
    public partial class frmhsqn : Form
    {
        private int _maqn;
        public frmhsqn(int maqn)
        {
            InitializeComponent();
            _maqn = maqn;
            
        }
        void LoadHoSo()
        {
            DataTable dt = B_QN.GetHoSoQN(_maqn);
            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];

            lblhoten.Text = row["quannhan_hoten"].ToString();
            lbldv_ht.Text = row["donvi_ten"].ToString();
            lbcd_ht.Text = row["chedo_ten"].ToString();
            lblcb_ht.Text = row["quannhan_capbac"].ToString();
            lblcv_ht.Text = row["quannhan_chucvu"].ToString();
            lblta_ht.Text = string.Format("{0:N0} đ/ngày",
                                  Convert.ToDecimal(row["tienan"]));
           
            lblma_ht.Text = "QN" + row["quannhan_id"].ToString();
          
        }
        void TinhTongTien(DataTable dt)
        {
            decimal tong = 0;

            foreach (DataRow row in dt.Rows)
            {
                tong += Convert.ToDecimal(row["tiencatcom"]);
            }

            lblsum.Text = tong.ToString("N0") + " VND";
        }
        void LoadLSCC()
        {
            LSCC ls = new LSCC();

            ls.quannhan_id = _maqn;

            ls.tungay = dtptu.Value.Date;
            ls.denngay = dtpden.Value.Date;

            DataTable dt = B_LSCC.TraCuu(ls);

            dgvlscc.AutoGenerateColumns = false;
            dgvlscc.DataSource = dt;

            TinhTongTien(dt);
        }
        private void frmhsqn_Load(object sender, EventArgs e)
        {
            LoadHoSo();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntracuu_Click(object sender, EventArgs e)
        {
            LoadLSCC();
        }
    }
}
