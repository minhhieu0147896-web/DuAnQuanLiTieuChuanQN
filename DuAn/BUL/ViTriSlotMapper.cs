using System;

namespace DuAn.BUL
{
    /// <summary>
    /// Ánh xạ vi_tri trong Chi_tiet_tdmau sang category/index khớp BuildKey trên frmLapthucdon2.
    /// </summary>
    public static class ViTriSlotMapper
    {
        public static bool TryMap(int buoiAnId, byte viTri, out string categoryName, out int categoryIndex)
        {
            categoryName = null;
            categoryIndex = 0;

            if (buoiAnId == 1)
            {
                if (viTri == 1)
                {
                    categoryName = "Man";
                    categoryIndex = 0;
                    return true;
                }

                if (viTri == 2)
                {
                    categoryName = "Canh";
                    categoryIndex = 0;
                    return true;
                }

                return false;
            }

            if (viTri >= 1 && viTri <= 4)
            {
                categoryName = "Man";
                categoryIndex = viTri - 1;
                return true;
            }

            if (viTri == 5)
            {
                categoryName = "Canh";
                categoryIndex = 0;
                return true;
            }

            if (viTri == 6)
            {
                categoryName = "Rau";
                categoryIndex = 0;
                return true;
            }

            if (viTri == 7)
            {
                categoryName = "TrangMieng";
                categoryIndex = 0;
                return true;
            }

            return false;
        }

        public static DateTime ThuTrongTuanToDate(byte thuTrongTuan, DateTime weekStart)
        {
            int dayIndex = thuTrongTuan - 2;
            if (dayIndex < 0 || dayIndex > 6)
                return DateTime.MinValue;

            return weekStart.Date.AddDays(dayIndex);
        }

        public static string BuildSlotKey(DateTime date, int buoiAnId, string categoryName, int categoryIndex)
        {
            return string.Format("{0:yyyyMMdd}-{1}-{2}-{3}", date.Date, buoiAnId, categoryName, categoryIndex);
        }
    }
}
