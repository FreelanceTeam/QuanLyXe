using System;
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

        public DataTable GetCCDC()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_ccdc, ten_ccdc FROM dm_cong_cu_dung_cu");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("dm_cong_cu_dung_cu");
            da.Fill(dt);
            return dt;
        }

        public string GetThongTinTaiSanXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT COUNT(ma_xe) AS tong_so_xe, SUM(nguyen_gia) AS tong_nguyen_gia, SUM(gia_tri_con_lai) AS tong_gia_tri_con_lai FROM tai_san_xe");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                int tong_so_xe = int.Parse(dt.Rows[0][0].ToString());
                decimal tong_nguyen_gia = decimal.Parse(dt.Rows[0][1].ToString());
                decimal tong_gia_tri_con_lai = decimal.Parse(dt.Rows[0][2].ToString());

                return string.Format("Tổng số xe: {0}  Tổng nguyên giá: {1}  Tổng giá trị còn lại: {2}", tong_so_xe, tong_nguyen_gia.ToString("N0"), tong_gia_tri_con_lai.ToString("N0"));
            }

            return string.Empty;
        }
    }
}
