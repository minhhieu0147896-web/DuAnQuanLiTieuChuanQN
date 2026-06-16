using System;
using System.Data;
using DuAn.DAO;

namespace DuAn.BUL
{
    /// <summary>
    /// BUL tính toán thực phẩm cần sử dụng
    /// </summary>
    internal class B_TinhThucPham
    {
        public static DataTable TinhThucPham(DateTime ngay, int? buoianId, int donviId)
        {
            return D_TinhThucPham.TinhThucPham(ngay, buoianId, donviId);
        }
    }
}
