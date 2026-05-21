namespace DuAn.DTO
{
    public class ChiTietTdMauModel
    {
        public int MauId { get; set; }
        public byte ThuTrongTuan { get; set; }
        public int BuoiAnId { get; set; }
        public int MonAnId { get; set; }
        public byte ViTri { get; set; }
        public string GhiChuMau { get; set; }
        public string TenMon { get; set; }
        public string LoaiMon { get; set; }
        public double Dam { get; set; }
        public double ChatXo { get; set; }
        public double ChatBeo { get; set; }
    }
}
