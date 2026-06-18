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
        void load_thang()
        {
            // Thêm vào Load event
            for (int i = 1; i <= 12; i++)
                cboThangBC.Items.Add(i);         // cboThangBC = combobox tháng bạn kéo thả
            cboThangBC.SelectedItem = DateTime.Today.Month;
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
            load_thang();
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

        private class QNRow
        {
            public int STT; public string HoTen, CapBac, ChucVu;
            public decimal TienAn;
            public bool[,] CatCom;      // [ngay, buoi]
            public decimal[] TyLe = new decimal[4]; // index 1,2,3
        }
      

        private void btnxuatexcel1_Click(object sender, EventArgs e)
        {
            if (cboThangBC.SelectedItem == null)
            { MessageBox.Show("Vui lòng chọn tháng!"); return; }

            int donvi_id = Convert.ToInt32(Session.DonViID ?? 0);
            int thang = Convert.ToInt32(cboThangBC.SelectedItem);
            int nam = DateTime.Today.Year;
            int soNgay = DateTime.DaysInMonth(nam, thang);

            DataTable dtRaw = B_thongke_cb.BaoCaoCatComThang(donvi_id, thang, nam);
            if (dtRaw == null || dtRaw.Rows.Count == 0)
            { MessageBox.Show("Không có dữ liệu tháng này!"); return; }

            var dict = new Dictionary<int, QNRow>();
            foreach (DataRow row in dtRaw.Rows)
            {
                int qnId = Convert.ToInt32(row["quannhan_id"]);
                if (!dict.ContainsKey(qnId))
                    dict[qnId] = new QNRow
                    {
                        STT = dict.Count + 1,
                        HoTen = row["quannhan_hoten"].ToString(),
                        CapBac = row["quannhan_capbac"].ToString(),
                        ChucVu = row["quannhan_chucvu"].ToString(),
                        TienAn = Convert.ToDecimal(row["chedo_tienan"]),
                        CatCom = new bool[soNgay + 1, 4]
                    };

                if (row["ngay_thang_nam"] != DBNull.Value)
                {
                    int ngay = Convert.ToDateTime(row["ngay_thang_nam"]).Day;
                    int buoi = Convert.ToInt32(row["buoian_id"]);
                    decimal tl = Convert.ToDecimal(row["buoian_tletienan"]);
                    dict[qnId].CatCom[ngay, buoi] = true;
                    dict[qnId].TyLe[buoi] = tl;
                }
            }

            XuatExcelThang(dict, thang, nam, soNgay, donvi_id); // ← gọi hàm chung
        }

      
        private void XuatExcelThang(Dictionary<int, QNRow> dict, int thang, int nam, int soNgay, int donvi_id)
        {
            string tenDV = "";
            using (var conn = DataProvider.Instance.GetConnection())
            {
                conn.Open();
                var cmd = new System.Data.SqlClient.SqlCommand("sp_DonVi_LayTen", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", donvi_id);
                tenDV = cmd.ExecuteScalar()?.ToString() ?? "";
            }

            var sfd = new SaveFileDialog
            {
                Filter = "Excel|*.xlsx",
                FileName = $"BaoCaoCatCom_Thang{thang}_{nam}_{tenDV}.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            ExcelPackage.License.SetNonCommercialPersonal("Ngo Thanh Xuan Giao");

            using (var pkg = new ExcelPackage(new FileInfo(sfd.FileName)))
            {
                var ws = pkg.Workbook.Worksheets.Add("BC Cắt Cơm");
                ws.Cells.Style.Font.Name = "Times New Roman";
                ws.Cells.Style.Font.Size = 7;

                int r = 1;
                int lastCol = 4 + soNgay * 3 + 2;
                int colNgStart = 5;
                int colNgEnd = 4 + soNgay * 3;
                int colSBC = colNgEnd + 1;
                int colTien = colNgEnd + 2;

                ws.Cells[r, 1].Value = $"ĐƠN VỊ: {tenDV}";
                ws.Cells[r, 1].Style.Font.Bold = true;
                r++;

                ws.Cells[r, 1, r, lastCol].Merge = true;
                ws.Cells[r, 1].Value = $"BÁO CÁO CẮT CƠM HÀNG BUỔI CỦA QUÂN NHÂN THÁNG {thang} NĂM {nam}";
                ws.Cells[r, 1].Style.Font.Bold = true;
                ws.Cells[r, 1].Style.Font.Size = 13;
                ws.Cells[r, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                r += 2;

                ws.Cells[r, 1, r + 2, 1].Merge = true; ws.Cells[r, 1].Value = "STT";
                ws.Cells[r, 2, r + 2, 2].Merge = true; ws.Cells[r, 2].Value = "HỌ VÀ TÊN";
                ws.Cells[r, 3, r + 2, 3].Merge = true; ws.Cells[r, 3].Value = "CẤP BẬC";
                ws.Cells[r, 4, r + 2, 4].Merge = true; ws.Cells[r, 4].Value = "CHỨC VỤ";
                foreach (int col in new[] { 1, 2, 3, 4 })
                {
                    ws.Cells[r, col, r + 2, col].Style.Font.Bold = true;
                    ws.Cells[r, col, r + 2, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                ws.Cells[r, colNgStart, r, colNgEnd].Merge = true;
                ws.Cells[r, colNgStart].Value = "SỐ CẮT CƠM THEO BUỔI TRONG THÁNG";
                ws.Cells[r, colNgStart].Style.Font.Bold = true;
                ws.Cells[r, colNgStart].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[r, colSBC, r + 2, colSBC].Merge = true; ws.Cells[r, colSBC].Value = "SỐ BUỔI CẮT";
                ws.Cells[r, colTien, r + 2, colTien].Merge = true; ws.Cells[r, colTien].Value = "TIỀN CẮT CƠM";
                ws.Cells[r, colSBC].Style.Font.Bold = true; ws.Cells[r, colSBC].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[r, colTien].Style.Font.Bold = true; ws.Cells[r, colTien].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                for (int ng = 1; ng <= soNgay; ng++)
                {
                    int c = colNgStart + (ng - 1) * 3;
                    ws.Cells[r + 1, c, r + 1, c + 2].Merge = true;
                    ws.Cells[r + 1, c].Value = ng.ToString();
                    ws.Cells[r + 1, c].Style.Font.Bold = true;
                    ws.Cells[r + 1, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[r + 2, c].Value = "S"; ws.Cells[r + 2, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[r + 2, c + 1].Value = "T"; ws.Cells[r + 2, c + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[r + 2, c + 2].Value = "C"; ws.Cells[r + 2, c + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                r += 3;

                int dataRowStart = r;
                foreach (var kv in dict)
                {
                    var qn = kv.Value;
                    ws.Cells[r, 1].Value = qn.STT;
                    ws.Cells[r, 2].Value = qn.HoTen;
                    ws.Cells[r, 3].Value = qn.CapBac;
                    ws.Cells[r, 4].Value = qn.ChucVu;

                    int tongCat = 0; decimal tongTien = 0;
                    for (int ng = 1; ng <= soNgay; ng++)
                    {
                        int c = colNgStart + (ng - 1) * 3;
                        ws.Cells[r, c].Value = qn.CatCom[ng, 1] ? "x" : "-";
                        ws.Cells[r, c + 1].Value = qn.CatCom[ng, 2] ? "x" : "-";
                        ws.Cells[r, c + 2].Value = qn.CatCom[ng, 3] ? "x" : "-";
                        ws.Cells[r, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[r, c + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[r, c + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        if (qn.CatCom[ng, 1]) { tongCat++; tongTien += qn.TienAn * qn.TyLe[1]; }
                        if (qn.CatCom[ng, 2]) { tongCat++; tongTien += qn.TienAn * qn.TyLe[2]; }
                        if (qn.CatCom[ng, 3]) { tongCat++; tongTien += qn.TienAn * qn.TyLe[3]; }
                    }
                    ws.Cells[r, colSBC].Value = tongCat;
                    ws.Cells[r, colTien].Value = tongTien;
                    ws.Cells[r, colTien].Style.Numberformat.Format = "#,##0";
                    r++;
                }

                // Tổng cộng theo buổi
                ws.Cells[r, 1, r, 4].Merge = true;
                ws.Cells[r, 1].Value = "TỔNG CỘNG THEO BUỔI";
                ws.Cells[r, 1].Style.Font.Bold = true;
                for (int ng = 1; ng <= soNgay; ng++)
                {
                    int c = colNgStart + (ng - 1) * 3;
                    string lS = ExcelCellAddress.GetColumnLetter(c);
                    string lT = ExcelCellAddress.GetColumnLetter(c + 1);
                    string lC = ExcelCellAddress.GetColumnLetter(c + 2);
                    ws.Cells[r, c].Formula = $"COUNTIF({lS}{dataRowStart}:{lS}{r - 1},\"x\")";
                    ws.Cells[r, c + 1].Formula = $"COUNTIF({lT}{dataRowStart}:{lT}{r - 1},\"x\")";
                    ws.Cells[r, c + 2].Formula = $"COUNTIF({lC}{dataRowStart}:{lC}{r - 1},\"x\")";
                }
                ws.Cells[r, colSBC].Formula = $"SUM({ExcelCellAddress.GetColumnLetter(colSBC)}{dataRowStart}:{ExcelCellAddress.GetColumnLetter(colSBC)}{r - 1})";
                ws.Cells[r, colTien].Formula = $"SUM({ExcelCellAddress.GetColumnLetter(colTien)}{dataRowStart}:{ExcelCellAddress.GetColumnLetter(colTien)}{r - 1})";
                ws.Cells[r, colTien].Style.Numberformat.Format = "#,##0";
                r++;

                // Tổng cộng trong ngày
                ws.Cells[r, 1, r, 4].Merge = true;
                ws.Cells[r, 1].Value = "TỔNG CỘNG TRONG NGÀY";
                ws.Cells[r, 1].Style.Font.Bold = true;
                for (int ng = 1; ng <= soNgay; ng++)
                {
                    int c = colNgStart + (ng - 1) * 3;
                    ws.Cells[r, c, r, c + 2].Merge = true;
                    string prev = (r - 1).ToString();
                    ws.Cells[r, c].Formula = $"{ExcelCellAddress.GetColumnLetter(c)}{prev}+{ExcelCellAddress.GetColumnLetter(c + 1)}{prev}+{ExcelCellAddress.GetColumnLetter(c + 2)}{prev}";
                    ws.Cells[r, c].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                r++;

                // Tổng cộng trong tháng
                ws.Cells[r, 1, r, 4].Merge = true;
                ws.Cells[r, 1].Value = "TỔNG CỘNG TRONG THÁNG";
                ws.Cells[r, 1].Style.Font.Bold = true;
                string colTienLetter = ExcelCellAddress.GetColumnLetter(colTien);
                ws.Cells[r, colNgStart, r, colNgEnd].Merge = true;
                ws.Cells[r, colNgStart].Formula = $"SUM({colTienLetter}{dataRowStart}:{colTienLetter}{r - 3})";
                ws.Cells[r, colNgStart].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[r, colSBC].Formula = $"SUM({ExcelCellAddress.GetColumnLetter(colSBC)}{dataRowStart}:{ExcelCellAddress.GetColumnLetter(colSBC)}{r - 3})";
                ws.Cells[r, colTien].Formula = $"SUM({colTienLetter}{dataRowStart}:{colTienLetter}{r - 3})";
                ws.Cells[r, colTien].Style.Numberformat.Format = "#,##0";
                r += 2;

                // Ghi chú
                ws.Cells[r, 1].Value = "Ghi chú: S: Buổi sáng    T: Buổi trưa    C: Buổi chiều    x: Cắt cơm    -: Không cắt";
                r += 2;

                // Chữ ký
                ws.Cells[r, lastCol - 1].Value = $"Ngày {DateTime.Today.Day} tháng {thang} năm {nam}";
                ws.Cells[r, lastCol - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                r++;
                ws.Cells[r, 1].Value = "NGƯỜI LẬP BIỂU"; ws.Cells[r, 1].Style.Font.Bold = true;
                ws.Cells[r, lastCol / 2].Value = "ĐẠI ĐỘI TRƯỞNG"; ws.Cells[r, lastCol / 2].Style.Font.Bold = true;

                ws.Column(1).Width = 4; ws.Column(2).Width = 18;
                ws.Column(3).Width = 10; ws.Column(4).Width = 12;
                for (int c = colNgStart; c <= colNgEnd; c++) ws.Column(c).Width = 2.0;
                ws.Column(colSBC).Width = 7; ws.Column(colTien).Width = 12;

                ws.PrinterSettings.Orientation = eOrientation.Landscape;
                ws.PrinterSettings.PaperSize = ePaperSize.A3;
                ws.PrinterSettings.FitToPage = true;
                ws.PrinterSettings.FitToWidth = 1;
                ws.PrinterSettings.FitToHeight = 0;

                pkg.Save();
                MessageBox.Show("Xuất thành công!\n" + sfd.FileName, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(sfd.FileName);
            }
        }
    }
}
