using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuAn.DTO;

namespace DuAn.DAO
{
    public class BuoiAnDAO
    {
        private static BuoiAnDAO instance;
        public static BuoiAnDAO Instance
        {
            get { instance = new BuoiAnDAO(); return instance; }
            private set => instance = value;
        }
        private BuoiAnDAO() { }

        public List<BuoiAnModel> GetAll()
        {
            List<BuoiAnModel> list = new List<BuoiAnModel>();
            string query = "SELECT buoian_id, buoian_ten, buoian_tletienan FROM Buoi_an ORDER BY buoian_id";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new BuoiAnModel
                {
                    BuoiAnId = Convert.ToInt32(row["buoian_id"]),
                    TenBuoi = row["buoian_ten"].ToString(),
                    TyLeTienAn = Convert.ToDecimal(row["buoian_tletienan"])
                });
            }
            return list;
        }
    }
}
