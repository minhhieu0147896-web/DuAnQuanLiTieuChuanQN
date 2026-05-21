using DuAn.DAO;
using DuAn.DTO;
using System;
using System.Collections.Generic;

namespace DuAn.BUL
{
    public class TemplateFillResult
    {
        public Dictionary<string, MonAnModel> Meals { get; set; } = new Dictionary<string, MonAnModel>();
        public int FilledCount { get; set; }
        public int SkippedNoSlot { get; set; }
        public int SkippedInvalidViTri { get; set; }
        public int SkippedInvalidThu { get; set; }
        public string MauTen { get; set; }
    }

    public static class WeeklyMenuFromTemplateFiller
    {
        public static TemplateFillResult FillFromTemplate(
            int mauId,
            DateTime weekStart,
            IReadOnlyCollection<string> validSlotKeys)
        {
            TemplateFillResult result = new TemplateFillResult();
            HashSet<string> slotSet = validSlotKeys == null
                ? new HashSet<string>()
                : new HashSet<string>(validSlotKeys);

            ThucDonMauModel header = ThucDonMauDAO.Instance.GetAll()
                .Find(x => x.MauId == mauId);
            if (header != null)
                result.MauTen = header.MauTen;

            List<ChiTietTdMauModel> details = ThucDonMauDAO.Instance.GetChiTietByMauId(mauId);

            foreach (ChiTietTdMauModel row in details)
            {
                DateTime date = ViTriSlotMapper.ThuTrongTuanToDate(row.ThuTrongTuan, weekStart);
                if (date == DateTime.MinValue)
                {
                    result.SkippedInvalidThu++;
                    continue;
                }

                if (!ViTriSlotMapper.TryMap(row.BuoiAnId, row.ViTri, out string categoryName, out int categoryIndex))
                {
                    result.SkippedInvalidViTri++;
                    continue;
                }

                string slotKey = ViTriSlotMapper.BuildSlotKey(date, row.BuoiAnId, categoryName, categoryIndex);
                if (!slotSet.Contains(slotKey))
                {
                    result.SkippedNoSlot++;
                    continue;
                }

                result.Meals[slotKey] = new MonAnModel
                {
                    MonAnId = row.MonAnId,
                    TenMon = row.TenMon,
                    LoaiMon = row.LoaiMon,
                    Dam = row.Dam,
                    ChatXo = row.ChatXo,
                    ChatBeo = row.ChatBeo
                };
                result.FilledCount++;
            }

            return result;
        }
    }
}
