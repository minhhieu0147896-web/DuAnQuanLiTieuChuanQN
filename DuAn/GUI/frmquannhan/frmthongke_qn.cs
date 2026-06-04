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
using DuAn.DAO;
using DuAn.DTO;
using System.Windows.Forms.DataVisualization.Charting;

namespace DuAn.GUI.frmquannhan
{
    public partial class frmthongke_qn : Form
    {
        qnlogin qn;
        public frmthongke_qn(qnlogin maquannhan)
        {
            InitializeComponent();
                this.qn = maquannhan;
        }
        void loadcbo()
        {
            // tháng
            for (int i = 1; i <= 12; i++)
            {
                cbothang.Items.Add(i);
            }

            // năm
            for (int i = 2024; i <= 2035; i++)
            {
                cbonam.Items.Add(i);
            }

            // chọn hiện tại
            cbothang.Text = DateTime.Now.Month.ToString();

            cbonam.Text = DateTime.Now.Year.ToString();
        }
        void hienthiqn()
        {
            lblquannhan_id.Text = qn.quannhan_id.ToString();

            lblquannhan_hoten.Text = qn.quannhan_hoten;

            lbldonvi_ten.Text = qn.donvi_ten;

            lblchedo_ten.Text = qn.chedo_ten;
            lblchedo_tienan.Text=qn.chedo_tienan.ToString() + " VND";

        }
        void loadchartnam()
        {
            if (qn == null || string.IsNullOrEmpty(cbonam.Text)) return;

            int nam = Convert.ToInt32(cbonam.Text);
            DataTable dt = B_thongkeqn.thongke_nam(qn.quannhan_id, nam);

            chartcot.Series.Clear();
            chartcot.Titles.Clear();
            chartcot.Titles.Add("Thống kê năm " + nam);

            Series an = new Series("Ăn") { ChartType = SeriesChartType.Column, IsValueShownAsLabel = true };
            Series khongan = new Series("Không ăn") { ChartType = SeriesChartType.Column, IsValueShownAsLabel = true };

            foreach (DataRow r in dt.Rows)
            {
                string thang = "T" + r["thang"].ToString();
                an.Points.AddXY(thang, r["sobuoian"]);
                khongan.Points.AddXY(thang, r["sobuoikhongan"]);
            }

            chartcot.Series.Add(an);
            chartcot.Series.Add(khongan);

            chartcot.ChartAreas[0].AxisX.Title = "Tháng";
            chartcot.ChartAreas[0].AxisY.Title = "Số buổi";
            chartcot.Legends[0].Docking = Docking.Bottom;
        }
       
        void loadcharttron(thongkecatcom tk)
        {
            charttron.Series.Clear();
            charttron.Titles.Clear();
            charttron.Titles.Add("Tỷ lệ ăn tháng " + cbothang.Text);

            Series s = new Series();
            s.ChartType = SeriesChartType.Pie;
            s.Points.AddXY("Ăn", tk.sobuoian);
            s.Points.AddXY("Cắt cơm", tk.sobuoikhongan);

            s.IsValueShownAsLabel = true;
            s.Label = "#PERCENT";
            s["PieLabelStyle"] = "Outside"; // Đưa nhãn ra ngoài để không bị đè lên biểu đồ

            charttron.Series.Add(s);
            charttron.Legends[0].Docking = Docking.Bottom;
            charttron.ChartAreas[0].Area3DStyle.Enable3D = true; // Kích hoạt 3D
        }
        void loadthongke()
        {
            int thang = Convert.ToInt32(cbothang.Text);
            int nam = Convert.ToInt32(cbonam.Text);

            thongkecatcom tk = B_thongkeqn.thongke_thang(qn.quannhan_id, thang, nam);

            lbltongbuoi.Text = tk.tongbuoi.ToString();
            lblsobuoian.Text = tk.sobuoian.ToString();
            lblsobuoikhongan.Text = tk.sobuoikhongan.ToString();
            lbltongtien.Text = tk.tongtiencat.ToString("N0") + " VNĐ";
            loadcharttron(tk);
            loadchartnam();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void hoten_Click(object sender, EventArgs e)
        {

        }

        private void tlpthongtin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnltitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmthongke_qn_Load(object sender, EventArgs e)
        {
            hienthiqn();
            loadcbo();
            loadthongke();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btntracuu_Click(object sender, EventArgs e)
        {
            loadthongke();
        }

        private void lblbqs_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartcot_Click(object sender, EventArgs e)
        {

        }
    }
}
