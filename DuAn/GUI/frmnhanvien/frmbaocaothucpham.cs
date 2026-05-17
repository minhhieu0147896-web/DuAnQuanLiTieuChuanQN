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

namespace DuAn.GUI.frmnhanvien
{
    public partial class frmbaocaothucpham : Form
    {
        public frmbaocaothucpham()
        {
            InitializeComponent();
        }

        private void frmbaocaothucpham_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadFilters();

        }

        private void pnlfilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConfigureGrid()
        {
            dgvlscc.AutoGenerateColumns = true;
            dgvlscc.Columns.Clear();
            dgvlscc.DefaultCellStyle.ForeColor = Color.FromArgb(30, 35, 40);
            dgvlscc.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvlscc.ReadOnly = true;
            dgvlscc.AllowUserToAddRows = false;
            dgvlscc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadFilters()
        {
            dateTimePicker2.ValueChanged += (s, e) => SyncDateRange();
            btnhienthi.Click += btnhienthi_Click;

            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.MinDate = dateTimePicker2.Value.Date;

            DataTable donVi = B_QN.GetAllDonVi();
            comboBox2.DataSource = donVi;
            comboBox2.DisplayMember = "donvi_ten";
            comboBox2.ValueMember = "donvi_id";
            comboBox2.SelectedIndex = donVi.Rows.Count > 0 ? 0 : -1;

            DataTable buoi = B_BQS.loadbuoi();
            DataRow allBuoi = buoi.NewRow();
            allBuoi["buoian_id"] = 0;
            allBuoi["buoian_ten"] = "Tất cả";
            buoi.Rows.InsertAt(allBuoi, 0);
            cbobuoi.DataSource = buoi;
            cbobuoi.DisplayMember = "buoian_ten";
            cbobuoi.ValueMember = "buoian_id";

            DataTable cheDo = B_QN.GetAllCheDo();
            DataRow allCheDo = cheDo.NewRow();
            allCheDo["chedo_id"] = 0;
            allCheDo["chedo_ten"] = "Tất cả";
            cheDo.Rows.InsertAt(allCheDo, 0);
            cbochedo.DataSource = cheDo;
            cbochedo.DisplayMember = "chedo_ten";
            cbochedo.ValueMember = "chedo_id";
        }

        private void SyncDateRange()
        {
            dateTimePicker1.MinDate = dateTimePicker2.Value.Date;
            if (dateTimePicker1.Value.Date < dateTimePicker2.Value.Date)
                dateTimePicker1.Value = dateTimePicker2.Value.Date;
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null || Convert.ToInt32(comboBox2.SelectedValue) <= 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime tuNgay = dateTimePicker2.Value.Date;
            DateTime denNgay = dateTimePicker1.Value.Date;
            int donViId = Convert.ToInt32(comboBox2.SelectedValue);
            int buoiId = Convert.ToInt32(cbobuoi.SelectedValue);
            int cheDoId = Convert.ToInt32(cbochedo.SelectedValue);

            DataTable report = B_LSBQS.TraCuuThucPham(tuNgay, denNgay, donViId, buoiId, cheDoId);
            report.Columns.Add("STT", typeof(int));
            for (int i = 0; i < report.Rows.Count; i++)
                report.Rows[i]["STT"] = i + 1;

            report.Columns["STT"].SetOrdinal(0);
            dgvlscc.DataSource = report;
            FormatReportGrid();
            UpdateSummary(report);
        }

        private void FormatReportGrid()
        {
            if (dgvlscc.Columns.Contains("Ngay"))
                dgvlscc.Columns["Ngay"].HeaderText = "Ngày";
            if (dgvlscc.Columns.Contains("Buoi"))
                dgvlscc.Columns["Buoi"].HeaderText = "Buổi";
            if (dgvlscc.Columns.Contains("CheDo"))
                dgvlscc.Columns["CheDo"].HeaderText = "Chế độ";
            if (dgvlscc.Columns.Contains("DonVi"))
                dgvlscc.Columns["DonVi"].HeaderText = "Đơn vị";
            if (dgvlscc.Columns.Contains("ThucPham"))
                dgvlscc.Columns["ThucPham"].HeaderText = "Thực phẩm";
            if (dgvlscc.Columns.Contains("SoLuong"))
            {
                dgvlscc.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvlscc.Columns["SoLuong"].DefaultCellStyle.Format = "N2";
            }
            if (dgvlscc.Columns.Contains("DonViTinh"))
                dgvlscc.Columns["DonViTinh"].HeaderText = "ĐVT";
            if (dgvlscc.Columns.Contains("ChiPhi"))
            {
                dgvlscc.Columns["ChiPhi"].HeaderText = "Chi phí";
                dgvlscc.Columns["ChiPhi"].DefaultCellStyle.Format = "N0";
            }
        }

        private void UpdateSummary(DataTable report)
        {
            if (report == null || report.Rows.Count == 0)
            {
                label4.Text = "0";
                lblso.Text = "0";
                return;
            }

            int soNgay = report.AsEnumerable()
                .Select(row => Convert.ToDateTime(row["Ngay"]).Date)
                .Distinct()
                .Count();

            decimal tongChiPhi = report.AsEnumerable()
                .Sum(row => row["ChiPhi"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ChiPhi"]));

            label4.Text = soNgay.ToString();
            lblso.Text = tongChiPhi.ToString("N0");
        }
    }
}
