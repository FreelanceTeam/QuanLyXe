using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL.Entity;
using VMS.Helper;

namespace VMS.DAL
{
    public class BienBanThuHoiData
    {
        public BienBanThuHoiData()
        {
            DataFactory.CreateConnection();
        }


        public DataTable GetAllAsDataTable(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_thu_hoi bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE ma_xe = '{0}' ORDER BY ngay_bien_ban DESC", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_thu_hoi");
            da.Fill(dt);
            return dt;
        }

        public List<bien_ban_thu_hoi> GetAll(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_thu_hoi bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE ma_xe = '{0}' ORDER BY ngay_bien_ban DESC", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_thu_hoi");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToList<bien_ban_thu_hoi>(dt);
            }
            return null;
        }

        public bien_ban_thu_hoi GetByMaXe(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT TOP 1 bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_thu_hoi bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_thu_hoi");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<bien_ban_thu_hoi>(dt.Rows[0]);
            }
            return null;
        }

        public bien_ban_thu_hoi Get(string so_bien_ban)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_thu_hoi bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE so_bien_ban = '{0}'", so_bien_ban));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_thu_hoi");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<bien_ban_thu_hoi>(dt.Rows[0]);
            }
            return null;
        }

        public bool HasExisted(string so_bien_ban)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_bien_ban_thu_hoi WHERE so_bien_ban = '{0}'", so_bien_ban));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_thu_hoi");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool Save(bien_ban_thu_hoi entity, bool isNew)
        {
            string sqlStr = "sp_BienBanThuHoi_Insert";
            if (!isNew)
                sqlStr = "sp_BienBanThuHoi_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@so_bien_ban", SqlDbType.NChar).Value = entity.so_bien_ban;
            cmd.Parameters.Add("@ngay_bien_ban", SqlDbType.SmallDateTime).Value = entity.ngay_bien_ban;
            cmd.Parameters.Add("@ma_xe", SqlDbType.NChar).Value = entity.ma_xe;
            cmd.Parameters.Add("@ma_tai_xe", SqlDbType.NChar).Value = entity.ma_tai_xe;
            cmd.Parameters.Add("@ngay_ket_thuc", SqlDbType.SmallDateTime).Value = entity.ngay_ket_thuc;
            cmd.Parameters.Add("@so_km_ket_thuc", SqlDbType.Decimal).Value = entity.so_km_ket_thuc;
            cmd.Parameters.Add("@ly_do_thu_hoi", SqlDbType.NVarChar).Value = entity.ly_do_thu_hoi;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NVarChar).Value = entity.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.DateTime).Value = entity.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = entity.nguoi_cap_nhat;
            if (isNew)
            {
                cmd.Parameters.Add("@ngay_tao", SqlDbType.DateTime).Value = entity.ngay_tao;
                cmd.Parameters.Add("@nguoi_tao", SqlDbType.NVarChar).Value = entity.nguoi_tao;
            }
            cmd.Parameters.Add("@status", SqlDbType.Char).Value = entity.status;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool Delete(string so_bien_ban)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_BienBanThuHoi_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@so_bien_ban", SqlDbType.NChar).Value = so_bien_ban;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }
    }
}
