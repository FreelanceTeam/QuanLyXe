using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL.Entity;
using VMS.Helper;

namespace VMS.DAL
{
    public class GiayDangKyData
    {
        public GiayDangKyData()
        {
            DataFactory.CreateConnection();
        }
		
        public giay_dang_ky GetByMaXe(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT TOP 1 dk.*, bp.ma_bp AS don_vi, bp.ten_bp AS ten_don_vi FROM x_giay_dang_ky dk INNER JOIN dm_bo_phan bp ON dk.don_vi = bp.ma_bp WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                giay_dang_ky result = ConvertionHelper.ToEntity<giay_dang_ky>(dt.Rows[0]);
                result.DetailList = GetDetail(result.ma_giay);

                return result;
            }
            return null;
        }

        public giay_dang_ky Get(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT dk.*, bp.ma_bp AS don_vi, bp.ten_bp AS ten_don_vi FROM x_giay_dang_ky dk INNER JOIN dm_bo_phan bp ON dk.don_vi = bp.ma_bp WHERE ma_giay = '{0}'", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                giay_dang_ky result = ConvertionHelper.ToEntity<giay_dang_ky>(dt.Rows[0]);
                result.DetailList = GetDetail(ma_giay);

                return result; 
            }
            return null;
        }

        public DataTable GetDetailAsDataTable(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_giay_dang_ky_ct WHERE ma_giay = '{0}' ORDER BY ngay_cap", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky_ct");
            da.Fill(dt);
            return dt;
        }

        public List<giay_dang_ky_ct> GetDetail(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_giay_dang_ky_ct WHERE ma_giay = '{0}' ORDER BY ngay_cap", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky_ct");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToList<giay_dang_ky_ct>(dt);
            }
            return null;
        }

        public bool HasExisted(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ma_giay FROM x_giay_dang_ky WHERE ma_giay = '{0}'", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool Save(giay_dang_ky entity, bool isNew)
        {
            string sqlStr = "sp_GiayDangKy_Insert";
            if (!isNew)
                sqlStr = "sp_GiayDangKy_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = entity.ma_xe;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = entity.ma_giay;
            cmd.Parameters.Add("@don_vi", SqlDbType.VarChar).Value = entity.don_vi;
            cmd.Parameters.Add("@ngay_cap_lan_dau", SqlDbType.SmallDateTime).Value = entity.ngay_cap_lan_dau?? (object)DBNull.Value;
            cmd.Parameters.Add("@nhac_nho_truoc_ngay", SqlDbType.Decimal).Value = entity.nhac_nho_truoc_ngay;
            cmd.Parameters.Add("@hinh_anh", SqlDbType.Image).Value = entity.hinh_anh ?? (object)DBNull.Value;
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

        public bool Delete(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_GiayDangKy_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = ma_giay;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool SaveDetail(giay_dang_ky_ct entity, bool isNew)
        {
            string sqlStr = "sp_GiayDangKy_ChiTiet_Insert";
            if (!isNew)
                sqlStr = "sp_GiayDangKy_ChiTiet_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = entity.ma_giay;
            cmd.Parameters.Add("@ngay_cap", SqlDbType.SmallDateTime).Value = entity.ngay_cap;
            cmd.Parameters.Add("@ngay_het_han", SqlDbType.SmallDateTime).Value = entity.ngay_het_han;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NText).Value = entity.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.SmallDateTime).Value = entity.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = entity.nguoi_cap_nhat;
            cmd.Parameters.Add("@trang_thai", SqlDbType.VarChar).Value = entity.trang_thai;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeleteDetail(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_GiayDangKy_ChiTiet_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = ma_giay;
            cmd.Parameters.Add("@ngay_cap", SqlDbType.SmallDateTime).Value = ngay_cap;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool HasNgayCapExisted(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT 1 FROM x_giay_dang_ky_ct WHERE ma_giay = '{0}' and ngay_cap = '{1}'", ma_giay, ngay_cap));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky_ct");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool HasNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT 1 FROM x_giay_dang_ky_ct WHERE ma_giay = '{0}' and ngay_cap > '{1}'", ma_giay, ngay_cap));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky_ct");
            da.Fill(dt);

            return dt.Rows.Count == 0;
        }
    }
}
