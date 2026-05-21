using System;

namespace DuAn.DTO
{
    public class ThucDonMauModel
    {
        public int MauId { get; set; }
        public string MauTen { get; set; }
        public string MauMoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        public bool LaMacDinh { get; set; }

        public string HienThiCombo
        {
            get
            {
                string macDinh = LaMacDinh ? " [Mặc định]" : string.Empty;
                return MauTen + macDinh;
            }
        }
    }
}
