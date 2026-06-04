using DuAn.BUL;
using DuAn.DAO;
using DuAn.DAO;
using DuAn.DTO;
using DuAn.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            lbldonvi.Text = B_QN.laydonvitheoid(Session.DonViID.Value);
            int chedo1 = B_QN.CountQSCheDo(Session.DonViID.Value, 1);

            int chedo2 = B_QN.CountQSCheDo(Session.DonViID.Value, 2);
            lblqscd1.Text = chedo1.ToString();
            lblqscd2.Text = chedo2.ToString();


        }
        void load_danhsach()
        {
            dgvdanhsach.AutoGenerateColumns = false;
            dgvdanhsach.DataSource = B_thongke_cb.ds_catcom_theongay(Session.DonViID.Value, dtpngay.Value);
        }
        void load_bieudo()
        {
            thongke_tongquan tk = B_thongke_cb.thongke_tongquan(Session.DonViID.Value, dtpngay.Value);

            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Thống kê quân số ngày " + dtpngay.Value.ToString("dd/MM/yyyy"));

            Series an = new Series("QS Ăn")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };
            Series khongan = new Series("QS Không Ăn")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
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

        private void dgvdanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void TaoSheetTheoBuoi(
     ExcelPackage package,
     string sheetName,
     string buoi)
        {
            ExcelWorksheet ws =
                package.Workbook.Worksheets
                .Add(sheetName);

            // LẤY CỘT HIỂN THỊ
            List<int> visibleCols =
                new List<int>();

            for (int i = 0;
                 i < dgvdanhsach.Columns.Count;
                 i++)
            {
                if (dgvdanhsach.Columns[i].Visible)
                {
                    visibleCols.Add(i);
                }
            }

            int totalCol = visibleCols.Count;

            // =====================================
            // TITLE
            // =====================================

            ws.Cells[1, 1].Value =
                "DANH SÁCH QUÂN NHÂN " +
                buoi.ToUpper();

            ws.Cells[1, 1, 1, totalCol]
                .Merge = true;

            ws.Cells[1, 1].Style.Font.Bold =
                true;

            ws.Cells[1, 1].Style.Font.Size =
                18;

            ws.Cells[1, 1].Style.HorizontalAlignment =
                ExcelHorizontalAlignment.Center;

            // =====================================
            // HEADER
            // =====================================

            for (int i = 0;
                 i < visibleCols.Count;
                 i++)
            {
                int dgvCol = visibleCols[i];

                var cell =
                    ws.Cells[3, i + 1];

                cell.Value =
                    dgvdanhsach.Columns[dgvCol]
                    .HeaderText;

                cell.Style.Font.Bold = true;

                cell.Style.Fill.PatternType =
                    ExcelFillStyle.Solid;

                cell.Style.Fill.BackgroundColor
                    .SetColor(Color.LightGreen);

                cell.Style.HorizontalAlignment =
                    ExcelHorizontalAlignment.Center;

                cell.Style.Border.Top.Style =
                    ExcelBorderStyle.Thin;

                cell.Style.Border.Bottom.Style =
                    ExcelBorderStyle.Thin;

                cell.Style.Border.Left.Style =
                    ExcelBorderStyle.Thin;

                cell.Style.Border.Right.Style =
                    ExcelBorderStyle.Thin;
            }

            // =====================================
            // DATA
            // =====================================

            int excelRow = 4;

            foreach (DataGridViewRow dgvRow
                     in dgvdanhsach.Rows)
            {
                if (dgvRow.IsNewRow)
                    continue;

                // TÊN CỘT BUỔI ĂN
                string buaAn =
                    dgvRow.Cells["colbuoian"]
                    .Value?.ToString();

                if (buaAn == buoi)
                {
                    for (int j = 0;
                         j < visibleCols.Count;
                         j++)
                    {
                        int dgvCol = visibleCols[j];

                        var cell =
                            ws.Cells[excelRow, j + 1];

                        cell.Value =
                            dgvRow.Cells[dgvCol]
                            .Value?.ToString();

                        cell.Style.Border.Top.Style =
                            ExcelBorderStyle.Thin;

                        cell.Style.Border.Bottom.Style =
                            ExcelBorderStyle.Thin;

                        cell.Style.Border.Left.Style =
                            ExcelBorderStyle.Thin;

                        cell.Style.Border.Right.Style =
                            ExcelBorderStyle.Thin;

                        cell.Style.HorizontalAlignment =
                            ExcelHorizontalAlignment.Center;
                    }

                    excelRow++;
                }
            }

            // =====================================
            // AUTO FIT
            // =====================================

            ws.Cells[ws.Dimension.Address]
                .AutoFitColumns();
        }
        private void btnxuatexcel_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();

                    sfd.Filter = "Excel Files|*.xlsx";

                    // TỰ ĐỘNG ĐẶT TÊN FILE
                    sfd.FileName = "BaoCao_" +
                                   dtpngay.Value.ToString("dd_MM_yyyy");

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo file = new FileInfo(sfd.FileName);

                        // LICENSE EPPLUS 8
                        ExcelPackage.License.SetNonCommercialPersonal(
                            "Ngo Thanh Xuan Giao");

                        using (ExcelPackage package =
                               new ExcelPackage(file))
                        {
                            // =====================================
                            // SHEET TỔNG HỢP
                            // =====================================

                            ExcelWorksheet ws =
                                package.Workbook.Worksheets
                                .Add("TongHop");

                            // LẤY DANH SÁCH CỘT HIỂN THỊ
                            List<int> visibleCols =
                                new List<int>();

                            for (int i = 0;
                                 i < dgvdanhsach.Columns.Count;
                                 i++)
                            {
                                if (dgvdanhsach.Columns[i].Visible)
                                {
                                    visibleCols.Add(i);
                                }
                            }

                            int totalCol = visibleCols.Count;

                            // =====================================
                            // TITLE
                            // =====================================

                            ws.Cells[1, 1].Value =
                                "BÁO CÁO QUÂN SỐ";

                            ws.Cells[1, 1, 1, totalCol]
                                .Merge = true;

                            ws.Cells[1, 1].Style.Font.Size = 20;

                            ws.Cells[1, 1].Style.Font.Bold = true;

                            ws.Cells[1, 1].Style.HorizontalAlignment =
                                ExcelHorizontalAlignment.Center;

                            ws.Cells[1, 1].Style.VerticalAlignment =
                                ExcelVerticalAlignment.Center;

                            ws.Row(1).Height = 30;

                            // =====================================
                            // THÔNG TIN
                            // =====================================

                            ws.Cells[2, 1].Value =
                                "Đơn vị:";

                            ws.Cells[2, 2].Value =
                                lbldonvi.Text;

                            ws.Cells[3, 1].Value =
                                "Ngày:";

                            ws.Cells[3, 2].Value =
                                dtpngay.Value.ToString("dd/MM/yyyy");

                            ws.Cells[2, 1, 3, 1].Style.Font.Bold =
                                true;

                            // =====================================
                            // HEADER
                            // =====================================

                            for (int i = 0;
                                 i < visibleCols.Count;
                                 i++)
                            {
                                int dgvCol = visibleCols[i];

                                var cell =
                                    ws.Cells[5, i + 1];

                                cell.Value =
                                    dgvdanhsach.Columns[dgvCol]
                                    .HeaderText;

                                cell.Style.Font.Bold = true;

                                cell.Style.Fill.PatternType =
                                    ExcelFillStyle.Solid;

                                cell.Style.Fill.BackgroundColor
                                    .SetColor(Color.LightBlue);

                                cell.Style.HorizontalAlignment =
                                    ExcelHorizontalAlignment.Center;

                                cell.Style.VerticalAlignment =
                                    ExcelVerticalAlignment.Center;

                                cell.Style.Border.Top.Style =
                                    ExcelBorderStyle.Thin;

                                cell.Style.Border.Bottom.Style =
                                    ExcelBorderStyle.Thin;

                                cell.Style.Border.Left.Style =
                                    ExcelBorderStyle.Thin;

                                cell.Style.Border.Right.Style =
                                    ExcelBorderStyle.Thin;
                            }

                            // =====================================
                            // DATA
                            // =====================================

                            int excelRow = 6;

                            for (int i = 0;
                                 i < dgvdanhsach.Rows.Count;
                                 i++)
                            {
                                if (dgvdanhsach.Rows[i].IsNewRow)
                                    continue;

                                for (int j = 0;
                                     j < visibleCols.Count;
                                     j++)
                                {
                                    int dgvCol = visibleCols[j];

                                    var cell =
                                        ws.Cells[excelRow, j + 1];

                                    object value =
                                        dgvdanhsach.Rows[i]
                                        .Cells[dgvCol].Value;

                                    cell.Value = value?.ToString();

                                    // BORDER
                                    cell.Style.Border.Top.Style =
                                        ExcelBorderStyle.Thin;

                                    cell.Style.Border.Bottom.Style =
                                        ExcelBorderStyle.Thin;

                                    cell.Style.Border.Left.Style =
                                        ExcelBorderStyle.Thin;

                                    cell.Style.Border.Right.Style =
                                        ExcelBorderStyle.Thin;

                                    // ALIGN
                                    cell.Style.HorizontalAlignment =
                                        ExcelHorizontalAlignment.Center;

                                    cell.Style.VerticalAlignment =
                                        ExcelVerticalAlignment.Center;
                                }

                                excelRow++;
                            }

                            // =====================================
                            // AUTO FIT
                            // =====================================

                            ws.Cells[ws.Dimension.Address]
                                .AutoFitColumns();

                            // =====================================
                            // EXPORT CHART
                            // =====================================

                            string chartPath =
                                Application.StartupPath +
                                "\\chart.png";

                            chart1.SaveImage(
                                chartPath,
                                ChartImageFormat.Png);

                            FileInfo chartFile =
                                new FileInfo(chartPath);

                            ExcelPicture pic =
                                ws.Drawings.AddPicture(
                                    "ChartQuanSo",
                                    chartFile);

                            // VỊ TRÍ CHART
                            pic.SetPosition(1, 0,
                                            totalCol + 2, 0);

                            pic.SetSize(600, 300);

                            // =====================================
                            // SHEET SÁNG
                            // =====================================

                            TaoSheetTheoBuoi(
                                package,
                                "Sang",
                                "Sáng");

                            // =====================================
                            // SHEET TRƯA
                            // =====================================

                            TaoSheetTheoBuoi(
                                package,
                                "Trua",
                                "Trưa");

                            // =====================================
                            // SHEET CHIỀU
                            // =====================================

                            TaoSheetTheoBuoi(
                                package,
                                "Chieu",
                                "Chiều");

                            // =====================================
                            // SAVE
                            // =====================================

                            package.Save();
                        }

                        MessageBox.Show(
                            "Xuất Excel thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pnltitle_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
