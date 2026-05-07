using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    internal class thucpham
    {
        public thucpham(string thucpham_ten, decimal thucpham_giatien, string thucpham_donvitinh, decimal thucpham_kcal)
        {
            this.thucpham_ten = thucpham_ten;
            this.thucpham_giatien = thucpham_giatien;
            this.thucpham_donvitinh = thucpham_donvitinh;
            this.thucpham_kcal = thucpham_kcal;
        }

        public thucpham(int thucpham_id, string thucpham_ten, decimal thucpham_giatien, string thucpham_donvitinh, decimal thucpham_kcal)
        {
            this.thucpham_id = thucpham_id;
            this.thucpham_ten = thucpham_ten;
            this.thucpham_giatien = thucpham_giatien;
            this.thucpham_donvitinh = thucpham_donvitinh;
            this.thucpham_kcal = thucpham_kcal;
        }

        // thucpham_id, thucpham_ten,thucpham_giatien,thucpham_donvitinh,thucpham_kcal
        public int thucpham_id { get; set; }
        public string thucpham_ten { get; set; }
        public decimal thucpham_giatien { get; set; }
        public string thucpham_donvitinh { get; set; }
        public decimal thucpham_kcal { get; set; }

    }
}
