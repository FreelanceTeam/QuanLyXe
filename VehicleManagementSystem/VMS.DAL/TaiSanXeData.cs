using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL.Entity;
using VMS.Helper;

namespace VMS.DAL
{
    public class TaiSanXeData
    {
        public TaiSanXeData()
        {
            DataFactory.CreateConnection();
        }

        public List<tai_san_xe> GetAll()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT * FROM tai_san_xe ORDER BY ngay_cap_nhat DESC");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToList<tai_san_xe>(dt);
            }
            return null;
        }

        public DataTable GetAllAsDataTable()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT tsx.*, lts.ten_lts FROM tai_san_xe tsx INNER JOIN dm_loai_tai_san lts ON tsx.ma_lts = lts.ma_lts ORDER BY ngay_cap_nhat DESC");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);

            return dt;
        }

        public tai_san_xe GetByMaXe(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT tsx.*, lts.ten_lts FROM tai_san_xe tsx INNER JOIN dm_loai_tai_san lts ON tsx.ma_lts = lts.ma_lts WHERE tsx.ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<tai_san_xe>(dt.Rows[0]);
            }
            return null;
        }

        public bool HasExisted(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ma_xe FROM tai_san_xe WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool Save(tai_san_xe entity, bool isNew)
        {
            string sqlStr = "sp_TaiSanXe_Insert";
            if (!isNew)
                sqlStr = "sp_TaiSanXe_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = entity.ma_xe;
            cmd.Parameters.Add("@bien_so", SqlDbType.VarChar).Value = entity.bien_so;
            cmd.Parameters.Add("@hang_san_xuat", SqlDbType.NVarChar).Value = entity.hang_san_xuat;
            cmd.Parameters.Add("@loai_xe", SqlDbType.VarChar).Value = entity.loai_xe;
            cmd.Parameters.Add("@ma_lts", SqlDbType.NChar).Value = entity.ma_lts;
            cmd.Parameters.Add("@nam_san_xuat", SqlDbType.SmallInt).Value = entity.nam_san_xuat;
            cmd.Parameters.Add("@so_nam_su_dung", SqlDbType.TinyInt).Value = entity.so_nam_su_dung;
            cmd.Parameters.Add("@so_may", SqlDbType.Char).Value = entity.so_may;
            cmd.Parameters.Add("@so_khung", SqlDbType.Char).Value = entity.so_khung;
            cmd.Parameters.Add("@mau", SqlDbType.NVarChar).Value = entity.mau;
            cmd.Parameters.Add("@binh_nhien_lieu", SqlDbType.NChar).Value = entity.binh_nhien_lieu;
            cmd.Parameters.Add("@loai_nhien_lieu", SqlDbType.NVarChar).Value = entity.loai_nhien_lieu;
            cmd.Parameters.Add("@trong_tai_the_tich", SqlDbType.Decimal).Value = entity.trong_tai_the_tich;
            cmd.Parameters.Add("@trong_tai_khoi_luong", SqlDbType.Decimal).Value = entity.trong_tai_khoi_luong;
            cmd.Parameters.Add("@tong_trong_luong", SqlDbType.Decimal).Value = entity.tong_trong_luong;
            cmd.Parameters.Add("@nguyen_gia", SqlDbType.Decimal).Value = entity.nguyen_gia;
            cmd.Parameters.Add("@ngay_hieu_luc_kh", SqlDbType.DateTime).Value = entity.ngay_hieu_luc_kh;
            cmd.Parameters.Add("@gia_tri_khau_hao", SqlDbType.Decimal).Value = entity.gia_tri_khau_hao;
            cmd.Parameters.Add("@ti_le_khau_hao", SqlDbType.Decimal).Value = entity.ti_le_khau_hao;
            cmd.Parameters.Add("@gia_tri_con_lai", SqlDbType.Decimal).Value = entity.gia_tri_con_lai;
            cmd.Parameters.Add("@hinh_anh", SqlDbType.Image).Value = entity.hinh_anh ?? (object)DBNull.Value;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NVarChar).Value = entity.ghi_chu;
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

        public bool Delete(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_TaiSanXe_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = ma_xe;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public List<string> GetHangXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT DISTINCT hang_san_xuat FROM tai_san_xe ORDER BY 1");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToListString(dt);
            }

            return null;
        }

        public List<string> GetLoaiXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT DISTINCT loai_xe FROM tai_san_xe ORDER BY 1");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToListString(dt);
            }

            return null;
        }

        public List<string> GetMauXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT DISTINCT mau FROM tai_san_xe ORDER BY 1");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToListString(dt);
            }

            return null;
        }

    }
}
