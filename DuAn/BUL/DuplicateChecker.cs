using System;
using System.Collections.Generic;
using System.Globalization;
using DuAn.DTO;

namespace DuAn.BUL
{
    public enum DuplicateStatus
    {
        None,
        WarningDaySpan,
        WarningFreq,
        BlockedSameMeal,
        BlockedSameDay
    }

    public static class DuplicateChecker
    {
        public static bool IsBlocked(DuplicateStatus status)
        {
            return status == DuplicateStatus.BlockedSameMeal
                || status == DuplicateStatus.BlockedSameDay;
        }

        public static DuplicateStatus GetStatus(
            int monAnId,
            string loaiMon,
            DateTime targetDate,
            int targetBuoiId,
            Dictionary<string, MonAnModel> selectedMeals,
            string excludeSlotKey = null)
        {
            if (selectedMeals == null || selectedMeals.Count == 0)
                return DuplicateStatus.None;

            bool isSameMeal = false;
            bool isSameDayOtherMeal = false;
            bool isConsecutive = false;
            int currentFreq = 0;

            foreach (var entry in selectedMeals)
            {
                if (entry.Value == null || entry.Value.MonAnId != monAnId)
                    continue;

                if (!string.IsNullOrEmpty(excludeSlotKey)
                    && string.Equals(entry.Key, excludeSlotKey, StringComparison.Ordinal))
                    continue;

                string[] parts = entry.Key.Split('-');
                if (parts.Length < 2)
                    continue;

                if (!DateTime.TryParseExact(parts[0], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime mealDate))
                    continue;

                if (!int.TryParse(parts[1], out int mealBuoiId))
                    continue;

                if (mealDate.Date == targetDate.Date)
                {
                    if (mealBuoiId == targetBuoiId)
                        isSameMeal = true;
                    else
                        isSameDayOtherMeal = true;
                }

                int daysDiff = Math.Abs((mealDate.Date - targetDate.Date).Days);
                if (daysDiff == 1)
                    isConsecutive = true;

                currentFreq++;
            }

            if (isSameMeal)
                return DuplicateStatus.BlockedSameMeal;

            if (isSameDayOtherMeal)
                return DuplicateStatus.BlockedSameDay;

            if (isConsecutive)
                return DuplicateStatus.WarningDaySpan;

            string normLoai = loaiMon?.ToLowerInvariant().Trim() ?? string.Empty;
            int maxFreq = 3;

            if (normLoai.Contains("manchinh") || normLoai == "man" || normLoai == "mặn" || normLoai == "mặn chính")
                maxFreq = 2;

            if (currentFreq >= maxFreq)
                return DuplicateStatus.WarningFreq;

            return DuplicateStatus.None;
        }

        public static string GetStatusMessage(DuplicateStatus status, string loaiMon)
        {
            switch (status)
            {
                case DuplicateStatus.BlockedSameMeal:
                    return "Chặn: Đã có trong buổi này";
                case DuplicateStatus.BlockedSameDay:
                    return "Chặn: Đã dùng hôm nay";
                case DuplicateStatus.WarningDaySpan:
                    return "Cảnh báo: Vừa ăn hôm qua/ngày mai";
                case DuplicateStatus.WarningFreq:
                    string normLoai = loaiMon?.ToLowerInvariant().Trim() ?? string.Empty;
                    int maxFreq = (normLoai.Contains("manchinh") || normLoai == "man" || normLoai == "mặn" || normLoai == "mặn chính") ? 2 : 3;
                    return "Lưu ý: Đã đạt giới hạn " + maxFreq + " lần/tuần";
                default:
                    return "Khuyên dùng";
            }
        }
    }
}
