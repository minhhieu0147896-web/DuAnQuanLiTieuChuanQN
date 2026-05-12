using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DAO;
using DuAn.DTO;
using System.Data;

namespace DuAn.BUL
{
    public class B_QN
    {
        public static DataTable getallqn()
        {
            return D_QN.getQN();
        }
        public static void insertQN(DuAn.DTO.quannhan qn)
        {
             D_QN.insertqn(qn);
        }


        public static DataTable GetAllCheDo()
        {
            return D_QN.GetAllCheDo();
        }

        public static DataTable GetAllDonVi()
        {
            return D_QN .GetAllDonVi();
        }
        public static void UpdateQN(DuAn.DTO.quannhan qn)
        {
             D_QN.UpdateQN(qn);
        }
        public static void DeleteQN(int id)
        {
             D_QN.DeleteQN(id);
        }
        public static DataTable TimKiemQN(int donvi, int chedo)
        {
            return D_QN.TimKiemQN(donvi, chedo);
        }
        public static int checkmaqn(int id)
        {
            return D_QN.checkmaqn(id);
        }
        public static DataTable GetQNPaging(int page,int pagesize)
        {
            return D_QN.GetQNPaging(page,pagesize);
        }
        public static int CountQN()
        {
            return D_QN.CountQN();
        }
        public static DataTable TimKiemQNPaging(int donvi,int chedo,int page,int pagesize)
        {
            return D_QN.TimKiemQNPaging( donvi, chedo,page,pagesize);
        }
        public static int CountTimKiemQN(int donvi, int chedo)
        {
            return D_QN.CountTimKiemQN(donvi, chedo);
        }

        public static int CountQSDonVi(int donvi)
        {
            return D_QN.CountQSDonVi(donvi);
        }
        public static int CountQSCheDo(int donvi, int chedo)
        {
            return D_QN.CountQSCheDo(donvi, chedo);
        }
        public static DataTable TimKiemNhanh(string tukhoa)
        {
            return D_QN.TimKiemNhanh(tukhoa);
        }
    }
}
