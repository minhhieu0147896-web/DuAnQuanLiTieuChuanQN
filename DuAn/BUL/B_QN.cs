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
        D_QN dal = new D_QN();

        public DataTable GetAllCheDo()
        {
            return dal.GetAllCheDo();
        }

        public DataTable GetAllDonVi()
        {
            return dal.GetAllDonVi();
        }
        public static void UpdateQN(DuAn.DTO.quannhan qn)
        {
            D_QN.UpdateQN(qn);
        }
            public static void DeleteQN(int id)
            {
                D_QN.DeleteQN(id);
        }

    }
}
