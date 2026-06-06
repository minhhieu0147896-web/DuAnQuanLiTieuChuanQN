using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DuAn.DTO
{
    public class quannhan
    {
       private int quannhan_id;
        private string quannhan_hoten;
        private int donvi_id;
        private int chedo_id;
        private string quannhan_capbac;
        private string quannhan_chucvu;
      

        public quannhan( string quannhan_hoten, int donvi_id, int chedo_id)
        {
           
            this.quannhan_hoten = quannhan_hoten;
            this.donvi_id = donvi_id;
            this.chedo_id = chedo_id;
          
        }
        public quannhan(int quannhan_id, string quannhan_hoten, int donvi_id, int chedo_id)
        {
            this.quannhan_id = quannhan_id;
            this.quannhan_hoten = quannhan_hoten;
            this.donvi_id = donvi_id;
            this.chedo_id = chedo_id;
        }
        public quannhan(int quannhan_id, string quannhan_hoten, int donvi_id, int chedo_id, string quannhan_capbac, string quannhan_chucvu)
        {
            this.quannhan_id = quannhan_id;
            this.quannhan_hoten = quannhan_hoten;
            this.donvi_id = donvi_id;
            this.chedo_id = chedo_id;
            this.quannhan_capbac = quannhan_capbac;
            this.quannhan_chucvu = quannhan_chucvu;
        }
        public int Quannhan_id1 { get => quannhan_id; set => quannhan_id = value; }
        public string Quannhan_ten1 { get => quannhan_hoten; set => quannhan_hoten = value; }
        public int Donvi_id1 { get => donvi_id; set => donvi_id = value; }
        public int Chedo_id1 { get => chedo_id; set => chedo_id = value; }
        public string Quannhan_capbac1 { get => quannhan_capbac; set => quannhan_capbac = value; }
        public string Quannhan_chucvu1 { get => quannhan_chucvu; set => quannhan_chucvu = value; }
    }

}
