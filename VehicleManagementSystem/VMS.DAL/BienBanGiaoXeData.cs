using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL.Entity;
using VMS.Helper;

namespace VMS.DAL
{
    public class BienBanGiaoXeData
    {
        public BienBanGiaoXeData()
        {
            DataFactory.CreateConnection();
        }

        public List<bien_ban_giao_xe> GetAll(string ma_xe)
        {
            List<bien_ban_giao_xe> result = new List<bien_ban_giao_xe>();
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_giao_xe bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE ma_xe = '{0}' ORDER BY ngay_nhan_xe DESC", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    bien_ban_giao_xe entity = ConvertionHelper.ToEntity<bien_ban_giao_xe>(row);
                    entity.DetailList = GetDetail(entity.so_bien_ban);
                    result.Add(entity);
                }
                return result;
            }
            return null;
        }

        public DataTable GetAllAsDataTable(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_giao_xe bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE ma_xe = '{0}' ORDER BY ngay_nhan_xe DESC", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe");
            da.Fill(dt);
            return dt;
        }

        public bien_ban_giao_xe GetByMaXe(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT TOP 1 bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_giao_xe bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE ma_xe = '{0}' ORDER BY ngay_nhan_xe DESC", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                bien_ban_giao_xe result = ConvertionHelper.ToEntity<bien_ban_giao_xe>(dt.Rows[0]);
                result.DetailList = GetDetail(result.so_bien_ban);

                return result;
            }
            return null;
        }

        public bien_ban_giao_xe Get(string so_bien_ban)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT TOP 1 bb.*, nv.ma_nv AS ma_tai_xe, nv.ten_nv AS ten_tai_xe FROM x_bien_ban_giao_xe bb INNER JOIN dm_nhan_vien nv ON bb.ma_tai_xe = nv.ma_nv WHERE so_bien_ban = '{0}'", so_bien_ban));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                bien_ban_giao_xe result = ConvertionHelper.ToEntity<bien_ban_giao_xe>(dt.Rows[0]);
                result.DetailList = GetDetail(so_bien_ban);

                return result; 
            }
            return null;
        }

        public DataTable GetDetailAsDataTable(string so_bien_ban)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT bb.*, cc.ten_ccdc FROM x_bien_ban_giao_xe_ct bb INNER JOIN dm_cong_cu_dung_cu cc ON bb.ma_ccdc = cc.ma_ccdc WHERE so_bien_ban = '{0}' ORDER BY cc.ten_ccdc", so_bien_ban));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe_ct");
            da.Fill(dt);
            return dt;
        }

        public List<bien_ban_giao_xe_ct> GetDetail(string so_bien_ban)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT bb.*, cc.ten_ccdc FROM x_bien_ban_giao_xe_ct bb INNER JOIN dm_cong_cu_dung_cu cc ON bb.ma_ccdc = cc.ma_ccdc WHERE so_bien_ban = '{0}' ORDER BY cc.ten_ccdc", so_bien_ban));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe_ct");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToList<bien_ban_giao_xe_ct>(dt);
            }
            return null;
        }

        public bool HasExisted(string so_bien_ban)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT so_bien_ban FROM x_bien_ban_giao_xe WHERE so_bien_ban = '{0}'", so_bien_ban));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool Save(bien_ban_giao_xe entity, bool isNew)
        {
            string sqlStr = "sp_BienBanGiaoXe_Insert";
            if (!isNew)
                sqlStr = "sp_BienBanGiaoXe_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@so_bien_ban", SqlDbType.NChar).Value = entity.so_bien_ban;
            cmd.Parameters.Add("@ngay_bien_ban", SqlDbType.SmallDateTime).Value = entity.ngay_bien_ban;
            cmd.Parameters.Add("@ma_xe", SqlDbType.NChar).Value = entity.ma_xe;
            cmd.Parameters.Add("@ma_tai_xe", SqlDbType.NChar).Value = entity.ma_tai_xe;
            cmd.Parameters.Add("@ngay_nhan_xe", SqlDbType.SmallDateTime).Value = entity.ngay_nhan_xe;
            cmd.Parameters.Add("@so_km_bat_dau", SqlDbType.Decimal).Value = entity.so_km_bat_dau;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NText).Value = entity.ghi_chu;
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
            SqlCommand cmd = DataFactory.CreateCommand("sp_BienBanGiaoXe_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@so_bien_ban", SqlDbType.VarChar).Value = so_bien_ban;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool SaveDetail(bien_ban_giao_xe_ct entity, bool isNew)
        {
            string sqlStr = "sp_BienBanGiaoXe_ChiTiet_Insert";
            if (!isNew)
                sqlStr = "sp_BienBanGiaoXe_ChiTiet_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@so_bien_ban", SqlDbType.NChar).Value = entity.so_bien_ban;
            cmd.Parameters.Add("@ma_ccdc", SqlDbType.NChar).Value = entity.ma_ccdc;
            cmd.Parameters.Add("@so_luong", SqlDbType.TinyInt).Value = entity.so_luong;
            cmd.Parameters.Add("@so_km_da_su_dung", SqlDbType.Decimal).Value = entity.so_km_da_su_dung;
            cmd.Parameters.Add("@trang_thai", SqlDbType.TinyInt).Value = entity.trang_thai;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeleteDetail(string so_bien_ban, string ma_ccdc)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_BienBanGiaoXe_ChiTiet_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@so_bien_ban", SqlDbType.NChar).Value = so_bien_ban;
            cmd.Parameters.Add("@ma_ccdc", SqlDbType.NChar).Value = ma_ccdc;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool HasDetailExisted(string so_bien_ban, string ma_ccdc)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT 1 FROM x_bien_ban_giao_xe_ct WHERE so_bien_ban = '{0}' and ma_ccdc = '{1}'", so_bien_ban, ma_ccdc));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_bien_ban_giao_xe_ct");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }
    }
}
