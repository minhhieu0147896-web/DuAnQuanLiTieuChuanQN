using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DuAn.DAO
{
    internal class baoquansoDAO
    {
        private static baoquansoDAO instance;


        public static baoquansoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new baoquansoDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private baoquansoDAO() { }
        // load ds don vi cho cbodonvi
        public DataTable getdonvi()
        {
            string query = @"SELECT donvi_id, donvi_ten FROM dbo.Don_vi";
            return DataProvider.Instance.ExecuteQuery(query);

        }
        // load ds buoi an cho cbobuoi
        public DataTable getbuoian()
        {
            string query = @"SELECT buoian_id, buoian_ten FROM dbo.Buoian";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        //load qn theo donvi
        public DataTable getQNtheodonvi(int donvi_id)
        {
            string query = @"SELECT q.quannhan_id as id, q.quannhan_hovaten as [Ten quan nhan] ,c.chedo_ten as [Che do],c.chedo_id
                            From dbo.quannhan q
                            JOIN dbo.chedo c ON q.chedo_id=c.chedo_id
                            JOIN dbo.don_vi d ON q.donvi_id=d.donvi_id
                            WHERE d.donvi_id=@donvi_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@donvi_id", donvi_id)
            };
            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }


        public bool DaTonTai(DateTime ngay, int buoian_id, int donvi_id)
        {
            string query = @"
        SELECT COUNT(*) 
        FROM dbo.Quan_so_an
        WHERE ngay_thang_nam = @ngay 
        AND buoian_id = @buoian_id
        AND donvi_id = @donvi_id
    ";

            SqlParameter[] p =
            {
        new SqlParameter("@ngay", ngay),
        new SqlParameter("@buoian_id", buoian_id),
        new SqlParameter("@donvi_id", donvi_id)
              };

            object result = DataProvider.Instance.ExecuteScalar(query, p);

            return Convert.ToInt32(result) > 0;
        }
        



        
        public void insertphieucatcom(int quannhan_id, DateTime ngay, int buoian_id)
        {
            string query = @"INSERT INTO dbo.Phieu_cat_com (quannhan_id, ngay, buoian_id)
                            VALUES (@quannhan_id, @ngay, @buoian_id)";
            SqlParameter[] parameters = new SqlParameter[]
                  {
                new SqlParameter("@quannhan_id", quannhan_id),
                new SqlParameter("@ngay", ngay),
                new SqlParameter("@buoian_id", buoian_id)
              };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
        public void insertquansoan(DateTime ngay, int buoian_id, int donvi_id)
        {
            string query = @"INSERT INTO dbo.Quan_so_an (ngay_thang_nam, buoian_id, donvi_id, quansoan_soluong)
                           Select @ngay, @buoian_id, q.chedo_id, q.donvi_id, COUNT(q.quannhan_id) - COUNT(p.quannhan_id)
                           From dbo.Quan_nhan q
                           LEFT JOIN dbo.Phieu_cat_com p
                            ON q.quannhan_id = p.quannhan_id
                            AND p.ngay = @ngay
                            AND p.buoian_id = @buoian_id
                           Where q.donvi_id = @donvi_id
                            Group By q.chedo_id, q.donvi_id";
            SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@ngay", ngay),
                new SqlParameter("@buoian_id", buoian_id),
                new SqlParameter("@donvi_id", donvi_id)
            };
            DataProvider.Instance.ExecuteNonQuery(query, parameters);
        }
        public DataTable Getlichsuan(int quannhan_id, DateTime tungay, DateTime denngay)
        {
            string query = @"SELECT qsa.ngay_thang_nam as [Ngay], b.buoian_ten as [Buoi an], cd.chedo_ten as [Che do],
                            CASE
                                WHEN pcc.phieucatcom_id is not null
                                   then N'cat com' 
                                ELSE 'co an'
                            END AS [Trang thai]
                                       FROM       dbo.Quan_nhan      qn
                JOIN       dbo.Che_do         cd
                               ON qn.chedo_id     = cd.chedo_id
                JOIN       dbo.Quan_so_an     qsa
                               ON qsa.chedo_id    = qn.chedo_id
                               AND qsa.donvi_id   = qn.donvi_id
                JOIN       dbo.Buoi_an        ba
                               ON ba.buoian_id    = qsa.buoian_id
                LEFT JOIN  dbo.Phieu_cat_com  pcc
                               ON pcc.quannhan_id    = @quannhan_id
                               AND pcc.ngay_thang_nam = qsa.ngay_thang_nam
                               AND pcc.buoian_id      = qsa.buoian_id
                WHERE  qn.quannhan_id     = @quannhan_id
                AND    qsa.ngay_thang_nam BETWEEN @tuNgay AND @denNgay
                ORDER BY qsa.ngay_thang_nam DESC, ba.buoian_id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@quannhan_id", quannhan_id),
                new SqlParameter("@tuNgay",      tungay.Date),
                new SqlParameter("@denNgay",     denngay.Date)
            };

            return DataProvider.Instance.ExecuteQuery(query, parameters);
        }
    }
}
