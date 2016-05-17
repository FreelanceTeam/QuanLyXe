using System.Data;
using System.Data.SqlClient;

namespace VMS.DAL
{
    public class BaseData
    {
        public BaseData()
        {
            DataFactory.CreateConnection();
        }

        public DataTable GetLoaiTaiSanXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_lts, ten_lts FROM dm_loai_tai_san WHERE ma_nts = 'TSXE'");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("dm_loai_tai_san");
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTaiSanMMTB()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_tai_san, ten_tai_san FROM tai_san_may_moc_thiet_bi");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_may_moc_thiet_bi");
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDonVi()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_bp, ten_bp FROM dm_bo_phan");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("dm_bo_phan");
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTaiXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_nv AS ma_tai_xe, ten_nv AS ten_tai_xe FROM dm_nhan_vien WHERE ma_lnv ='NVTX'");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("dm_nhan_vien");
            da.Fill(dt);
            return dt;
        }
    }
}
