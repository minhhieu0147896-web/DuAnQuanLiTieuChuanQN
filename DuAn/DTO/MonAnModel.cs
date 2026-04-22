using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    public class MonAnModel
    {
       
        
    public int MonAnId { get; set; }
    public string LoaiMon { get; set; }
    public string TenMon { get; set; } // Nếu cột trong DB là "monan_roim" thì tên property giữ vậy nhưng ánh xạ đúng tên cột
                                               // Có thể thêm đơn giá, kcal nếu có trong bảng (hiện chưa thấy)
     
    }
}
