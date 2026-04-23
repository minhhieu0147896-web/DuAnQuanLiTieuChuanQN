using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAn.DTO
{
    public class ThucDonModel
    {
        public int ThucDonId { get; set; }
        public int UserId { get; set; }
        public int CheDoId { get; set; }
        public string TrangThai { get; set; }
        public int Tuan { get; set; }
        public int Nam { get; set; }
        public DateTime NgayLap { get; set; }
    }
}
