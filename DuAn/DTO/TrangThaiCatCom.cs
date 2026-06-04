using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    public class TrangThaiCatCom
    {
        
            public int QuannhanID { get; set; }

            public int CheDoID { get; set; }

            public bool KhongAn { get; set; }
        
    }
    public enum TrangThaiCatComEnum 
    {
        BiBoDe = 0,   // phiên cũ, đã bị báo đè
        HieuLuc = 1,   // phiên hiện tại, đang hiệu lực
        DaKhoa = 2    // đã khóa sổ chính thức
    }
}
