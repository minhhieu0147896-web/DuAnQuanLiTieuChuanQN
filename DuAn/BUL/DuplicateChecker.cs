using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DuAn.DTO;

namespace DuAn.BUL
{
    public enum DuplicateStatus
    {
        None,
        WarningDaySpan,
        WarningFreq,
        BlockedSameDay
    }

    public static class DuplicateChecker
    {
        public static DuplicateStatus GetStatus(
            int monAnId,
            string loaiMon,
            DateTime targetDate,
            int targetBuoiId,
            Dictionary<string, MonAnModel> selectedMeals)
        {
            if (selectedMeals == null || selectedMeals.Count == 0)
                return DuplicateStatus.None;

            bool isSameDay = false;
            bool isConsecutive = false;
            int currentFreq = 0;

            foreach (var entry in selectedMeals)
            {
                if (entry.Value == null || entry.Value.MonAnId != monAnId)
                    continue;

                // Tách Key dạng: yyyyMMdd-buoiAnId-category-index
                string[] parts = entry.Key.Split('-');
                if (parts.Length < 2)
                    continue;

                if (!DateTime.TryParseExact(parts[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime mealDate))
                    continue;

                if (!int.TryParse(parts[1], out int mealBuoiId))
                    continue;

                // 1. Kiểm tra TRÙNG CÙNG NGÀY (Khác buổi ăn, cùng ngày)
                if (mealDate.Date == targetDate.Date)
                {
                    if (mealBuoiId != targetBuoiId)
                    {
                        isSameDay = true;
                    }
                }

                // 2. Kiểm tra TRÙNG NGÀY LIÊN TIẾP (Giãn cách chính xác 1 ngày)
                int daysDiff = Math.Abs((mealDate.Date - targetDate.Date).Days);
                if (daysDiff == 1)
                {
                    isConsecutive = true;
                }

                // 3. Đếm tần suất xuất hiện trong tuần
                currentFreq++;
            }

            // Đánh giá theo thứ tự ưu tiên: Trùng cùng ngày (Chặn cứng) > Trùng ngày liên tiếp (Cảnh báo) > Quá tần suất tuần (Cảnh báo)
            if (isSameDay)
                return DuplicateStatus.BlockedSameDay;

            if (isConsecutive)
                return DuplicateStatus.WarningDaySpan;

            // Xác định tần suất tối đa dựa trên nhóm loại món
            string normLoai = loaiMon?.ToLowerInvariant().Trim() ?? string.Empty;
            int maxFreq = 3; // Mặc định cho Canh, Rau, TrangMieng, Sua...

            if (normLoai.Contains("manchinh") || normLoai == "man" || normLoai == "mặn" || normLoai == "mặn chính")
            {
                maxFreq = 2; // Món mặn chính tối đa 2 lần/tuần
            }

            if (currentFreq >= maxFreq)
                return DuplicateStatus.WarningFreq;

            return DuplicateStatus.None;
        }

        public static string GetStatusMessage(DuplicateStatus status, string loaiMon)
        {
            switch (status)
            {
                case DuplicateStatus.BlockedSameDay:
                    return "Chặn: Đã dùng hôm nay";
                case DuplicateStatus.WarningDaySpan:
                    return "Lưu ý: Vừa ăn hôm qua/ngày mai";
                case DuplicateStatus.WarningFreq:
                    string normLoai = loaiMon?.ToLowerInvariant().Trim() ?? string.Empty;
                    int maxFreq = (normLoai.Contains("manchinh") || normLoai == "man" || normLoai == "mặn" || normLoai == "mặn chính") ? 2 : 3;
                    return $"Lưu ý: Đã đạt giới hạn {maxFreq} lần/tuần";
                default:
                    return "Khuyên dùng";
            }
        }
    }
}
