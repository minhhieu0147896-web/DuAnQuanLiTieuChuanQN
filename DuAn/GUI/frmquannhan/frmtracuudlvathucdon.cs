using DuAn.BUL;
using DuAn.BUL;
using DuAn.DAO; 
using DuAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

namespace DuAn.GUI.frmquannhan
{
    public partial class frmtracuudlvathucdon : Form
    {

        private (DateTime start, DateTime end) GetWeekRange(int year, int week)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;

            DateTime jan4 = new DateTime(year, 1, 4);

            int dayOfWeek = (int)jan4.DayOfWeek;
            if (dayOfWeek == 0) dayOfWeek = 7;

            DateTime week1Start = jan4.AddDays(1 - dayOfWeek);

            DateTime start = week1Start.AddDays((week - 1) * 7);
            DateTime end = start.AddDays(6);

            return (start, end);
        }
        private void UpdateWeekLabel()
        {
            if (cboTuan.SelectedItem == null || cboNam.SelectedItem == null)
                return;

            int week = Convert.ToInt32(cboTuan.Text);
            int year = Convert.ToInt32(cboNam.Text);

            var range = GetWeekRange(year, week);

            string thuStart = GetThuVN(range.start.DayOfWeek);
            string thuEnd = GetThuVN(range.end.DayOfWeek);

            lblTuanInfo.Text =
                $"Từ ngày {range.start:dd/MM/yyyy} ({thuStart}) đến {range.end:dd/MM/yyyy} ({thuEnd})";
        }
        private int GetCurrentWeek()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            return ci.Calendar.GetWeekOfYear(
                DateTime.Now,
                CalendarWeekRule.FirstFourDayWeek,
                DayOfWeek.Monday
            );
        }
        private string GetThuVN(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Monday: return "T2";
                case DayOfWeek.Tuesday: return "T3";
                case DayOfWeek.Wednesday: return "T4";
                case DayOfWeek.Thursday: return "T5";
                case DayOfWeek.Friday: return "T6";
                case DayOfWeek.Saturday: return "T7";
                case DayOfWeek.Sunday: return "CN";
                default: return "";
            }
        }
        void LoadCheDo()
        {
            DataTable dt = B_QN.GetAllCheDo();

            cbochedo.DataSource = dt;
            cbochedo.DisplayMember = "chedo_ten";
            cbochedo.ValueMember = "chedo_id";

            cboCD.DataSource = dt.Copy();
            cboCD.DisplayMember = "chedo_ten";
            cboCD.ValueMember = "chedo_id";
        }

        void LoadTuan()
        {
            cboTuan.Items.Clear();

            for (int i = 1; i <= 52; i++)
            {
                cboTuan.Items.Add(i);
            }

            int currentWeek = GetCurrentWeek();

            if (currentWeek >= 1 && currentWeek <= 52)
                cboTuan.SelectedItem = currentWeek;
            else
                cboTuan.SelectedIndex = 0;
        }
        void LoadNam()
        {
            cboNam.Items.Clear();

            int namHienTai = DateTime.Now.Year;

            for (int i = 2024; i <= namHienTai + 5; i++)
            {
                cboNam.Items.Add(i);
            }

            cboNam.SelectedItem = namHienTai;
        }
        public frmtracuudlvathucdon()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grpdinhluong_Enter(object sender, EventArgs e)
        {

        }

        private void frmtracuudlvathucdon_Load(object sender, EventArgs e)
        {
            LoadCheDo();
            dgvdinhluongchuan.AutoGenerateColumns = false;


            LoadTuan();

            LoadNam();
            UpdateWeekLabel();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboTuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWeekLabel();

        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWeekLabel();
        }

        private void btntracuu_Click(object sender, EventArgs e)
        {
            if (cbochedo.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chế độ!");
                return;
            }

            int chedoID = Convert.ToInt32(cbochedo.SelectedValue);

            DataTable dt = B_TCTD.TraCuuDinhLuong(chedoID);

            dgvdinhluongchuan.DataSource = dt;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return;
            }

            // UI đẹp
            dgvdinhluongchuan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdinhluongchuan.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvdinhluongchuan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void lblTuanInfo_Click(object sender, EventArgs e)
        {

        }

        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                UpdateWeekLabel();
                int chedoID = Convert.ToInt32(cbochedo.SelectedValue);
                int nam = Convert.ToInt32(cboNam.Text);
                int tuan = Convert.ToInt32(cboTuan.Text);

                DataTable dt = B_TCTD.TraCuuThucDon(chedoID, nam, tuan);

                dgvThucDon.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu!");
                    return;
                }
                dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvThucDon.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dgvThucDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvThucDon.RowTemplate.Height = 35;

                // CHỈ SET NẾU CÓ DATA
                dgvThucDon.Columns["colthoigian"].HeaderText = "THỨ - NGÀY";
                dgvThucDon.Columns["colbuoi"].HeaderText = "BUỔI";
                dgvThucDon.Columns["colthucdon"].HeaderText = "MÓN ĂN";

                dgvThucDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThucDon.RowTemplate.Height = 35;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void cboCD_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void cboTuan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void cboNam_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateWeekLabel();
        }

        private void cboTuan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateWeekLabel();
        }

        private void dgvdinhluongchuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvThucDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
