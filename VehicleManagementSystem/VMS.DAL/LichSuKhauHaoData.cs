using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL.Entity;
using VMS.Helper;

namespace VMS.DAL
{
    public class LichSuKhauHaoData
    {
        public LichSuKhauHaoData()
        {
            DataFactory.CreateConnection();
        }        

        public DataTable GetAllAsDataTable(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ls.*, tsx.nguyen_gia FROM tai_san_xe tsx INNER JOIN x_lich_su_khau_hao ls ON tsx.ma_xe = ls.ma_xe WHERE ls.ma_xe = '{0}' ORDER BY ngay_hieu_luc desc", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_khau_hao");
            da.Fill(dt);
            return dt;
        }
		
		public List<lich_su_khau_hao> GetAll(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ls.*, tsx.nguyen_gia FROM tai_san_xe tsx INNER JOIN x_lich_su_khau_hao ls ON tsx.ma_xe = ls.ma_xe WHERE ls.ma_xe = '{0}' ORDER BY ngay_hieu_luc desc", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_khau_hao");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToList<lich_su_khau_hao>(dt);
            }
            return null;
        }

        public lich_su_khau_hao Get(string ma_xe, DateTime ngay_hieu_luc)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ls.*, tsx.nguyen_gia FROM tai_san_xe tsx INNER JOIN x_lich_su_khau_hao ls ON tsx.ma_xe = ls.ma_xe WHERE ls.ma_xe = '{0}' AND ls.ngay_hieu_luc ='{1}'", ma_xe, ngay_hieu_luc));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_khau_hao");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<lich_su_khau_hao>(dt.Rows[0]);
            }
            return null;
        }

        public lich_su_khau_hao GetLatest(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT TOP 1 ls.*, tsx.nguyen_gia FROM tai_san_xe tsx INNER JOIN x_lich_su_khau_hao ls ON tsx.ma_xe = ls.ma_xe WHERE ls.ma_xe = '{0}' ORDER BY ngay_hieu_luc desc", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_khau_hao");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<lich_su_khau_hao>(dt.Rows[0]);
            }
            return null;
        }

        public bool HasExisted(string ma_xe, DateTime ngay_hieu_luc)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_lich_su_khau_hao WHERE ma_xe = '{0}' AND ngay_hieu_luc ='{1}'", ma_xe, ngay_hieu_luc));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_khau_hao");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool IsInitKhauHao(string ma_xe, DateTime ngay_hieu_luc)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_lich_su_khau_hao WHERE ma_xe = '{0}' AND ngay_hieu_luc ='{1}' AND status = 'I'", ma_xe, ngay_hieu_luc));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_lich_su_khau_hao");
            da.Fill(dt);

            return dt.Rows.Count == 1;
        }

        public bool Save(lich_su_khau_hao entity)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_LichSuKhauHao_Insert");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = entity.ma_xe;
            cmd.Parameters.Add("@ngay_hieu_luc", SqlDbType.SmallDateTime).Value = entity.ngay_hieu_luc;
            cmd.Parameters.Add("@gia_tri_khau_hao", SqlDbType.Decimal).Value = entity.gia_tri_khau_hao;
            cmd.Parameters.Add("@ti_le_khau_hao", SqlDbType.Decimal).Value = entity.ti_le_khau_hao;
			cmd.Parameters.Add("@gia_tri_con_lai", SqlDbType.Decimal).Value = entity.gia_tri_con_lai;
			cmd.Parameters.Add("@gia_tri_trich_kh_nam", SqlDbType.Decimal).Value = entity.gia_tri_trich_kh_nam;
			cmd.Parameters.Add("@gia_tri_trich_kh_thang", SqlDbType.Decimal).Value = entity.gia_tri_trich_kh_thang;
			cmd.Parameters.Add("@so_thang_da_trich_kh", SqlDbType.Decimal).Value = entity.so_thang_da_trich_kh;			
            cmd.Parameters.Add("@ghi_chu", SqlDbType.VarChar).Value = entity.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.DateTime).Value = entity.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = entity.nguoi_cap_nhat;
			cmd.Parameters.Add("@ngay_tao", SqlDbType.DateTime).Value = entity.ngay_tao;
			cmd.Parameters.Add("@nguoi_tao", SqlDbType.NVarChar).Value = entity.nguoi_tao;
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = entity.status;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool Delete(string ma_xe, DateTime ngay_hieu_luc)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_LichSuKhauHao_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = ma_xe;
            cmd.Parameters.Add("@ngay_hieu_luc", SqlDbType.SmallDateTime).Value = ngay_hieu_luc;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public string TinhKhauHaoXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_xe, bien_so FROM tai_san_xe");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);
            
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    cmd = DataFactory.CreateCommand("ts_TinhKhauHaoXe");
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cMa_xe", SqlDbType.VarChar).Value = row[0].ToString();
                    DataFactory.ExecuteNonQuery(cmd);
                }
                catch (Exception)
                {
                    return row[1].ToString();
                }
               
            }

            return string.Empty;
        }
    }
}
