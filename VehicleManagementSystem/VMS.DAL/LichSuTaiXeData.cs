using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL.Entity;
using VMS.Helper;

namespace VMS.DAL
{
    public class LichSuTaiXeData
    {
        public LichSuTaiXeData()
        {
            DataFactory.CreateConnection();
        }        

        public DataTable GetAllAsDataTable(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ls.*, nv.ten_nv AS ten_tai_xe FROM dm_nhan_vien nv INNER JOIN x_lich_su_tai_xe ls ON nv.ma_nv = ls.ma_tai_xe WHERE ls.ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_tai_xe");
            da.Fill(dt);
            return dt;
        }
		
		public List<lich_su_tai_xe> GetAll(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ls.*, nv.ten_nv AS ten_tai_xe FROM dm_nhan_vien nv INNER JOIN x_lich_su_tai_xe ls ON nv.ma_nv = ls.ma_tai_xe WHERE ls.ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_tai_xe");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToList<lich_su_tai_xe>(dt);
            }
            return null;
        }

        public lich_su_tai_xe Get(string ma_xe, string ma_tai_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ls.*, nv.ten_nv AS ten_tai_xe FROM dm_nhan_vien nv INNER JOIN x_lich_su_tai_xe ls ON nv.ma_nv = ls.ma_tai_xe WHERE ls.ma_xe = '{0}' AND ls.ma_tai_xe ='{1}'", ma_xe, ma_tai_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_tai_xe");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<lich_su_tai_xe>(dt.Rows[0]);
            }
            return null;
        }

        public bool HasExisted(string ma_xe, string ma_tai_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_lich_su_tai_xe WHERE ma_xe = '{0}' AND ma_tai_xe ='{1}'", ma_xe, ma_tai_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_tai_xe");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool Save(lich_su_tai_xe entity, bool isNew)
        {
            string sqlStr = "sp_LichSuTaiXe_Insert";
            if (!isNew)
                sqlStr = "sp_LichSuTaiXe_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = entity.ma_xe;
            cmd.Parameters.Add("@ma_tai_xe", SqlDbType.VarChar).Value = entity.ma_tai_xe;
            cmd.Parameters.Add("@so_km_bat_dau", SqlDbType.Decimal).Value = entity.so_km_bat_dau;
            cmd.Parameters.Add("@so_km_ket_thuc", SqlDbType.Decimal).Value = entity.so_km_ket_thuc;
            cmd.Parameters.Add("@ngay_bat_dau", SqlDbType.SmallDateTime).Value = entity.ngay_bat_dau ?? (object)DBNull.Value;
            cmd.Parameters.Add("@ngay_ket_thuc", SqlDbType.SmallDateTime).Value = entity.ngay_ket_thuc ?? (object)DBNull.Value;
            cmd.Parameters.Add("@trang_thai", SqlDbType.VarChar).Value = entity.trang_thai;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.DateTime).Value = entity.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = entity.nguoi_cap_nhat;
            if (isNew)
            {
                cmd.Parameters.Add("@ngay_tao", SqlDbType.DateTime).Value = entity.ngay_tao;
                cmd.Parameters.Add("@nguoi_tao", SqlDbType.NVarChar).Value = entity.nguoi_tao;
            }
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = entity.status;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool Delete(string ma_xe, string ma_tai_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_LichSuTaiXe_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = ma_xe;
            cmd.Parameters.Add("@ma_tai_xe", SqlDbType.VarChar).Value = ma_tai_xe;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }
    }
}
