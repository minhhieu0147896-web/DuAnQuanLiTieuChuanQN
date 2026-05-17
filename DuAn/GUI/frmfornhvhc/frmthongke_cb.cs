using DuAn.DAO;
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
using System.Windows.Forms.DataVisualization.Charting;
using DuAn.BUL;
using DuAn.DTO;
using DuAn.DAO;

namespace DuAn.GUI.frmfornhvhc
{
    public partial class frmthongke_cb : Form
    {
        public frmthongke_cb()
        {
            InitializeComponent();
        }
        void load_thongke()
        {
            thongke_tongquan tk = B_thongke_cb.thongke_tongquan(Session.DonViID.Value, dtpngay.Value);

            lbltongquanso.Text = tk.TongQuanSo.ToString();
            lbldonvi.Text= B_QN.laydonvitheoid(Session.DonViID.Value);
            int chedo1 = B_QN.CountQSCheDo(Session.DonViID.Value, 1);

            int chedo2 = B_QN.CountQSCheDo(Session.DonViID.Value, 2);
            lblqscd1.Text = chedo1.ToString();
            lblqscd2.Text = chedo2.ToString();


        }
        void load_danhsach()
        {
            dgvdanhsach.DataSource = B_thongke_cb.ds_catcom_theongay(Session.DonViID.Value, dtpngay.Value);
        }
        void load_bieudo()
        {
            thongke_tongquan tk = B_thongke_cb.thongke_tongquan(Session.DonViID.Value, dtpngay.Value);

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Thống kê quân số ngày " + dtpngay.Value.ToString("dd/MM/yyyy"));

            Series an = new Series("QS Ăn") { ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true };
            Series khongan = new Series("QS Không Ăn")
            { ChartType = SeriesChartType.Column,IsValueShownAsLabel = true
            }; 

            // Sáng
            an.Points.AddXY("Sáng", tk.AnSang);
            khongan.Points.AddXY("Sáng", tk.KhongAnSang);

            // Trưa
            an.Points.AddXY("Trưa", tk.AnTrua);
            khongan.Points.AddXY("Trưa", tk.KhongAnTrua);

            // Chiều
            an.Points.AddXY("Chiều", tk.AnChieu);
            khongan.Points.AddXY("Chiều", tk.KhongAnChieu);

            chart1.Series.Add(an);
            chart1.Series.Add(khongan);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbldonvi_Click(object sender, EventArgs e)
        {

        }

        private void btntracuu_Click(object sender, EventArgs e)
        {
            load_bieudo();
           
            load_danhsach();
        }

        private void frmthongke_cb_Load(object sender, EventArgs e)
        {
            load_thongke();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
