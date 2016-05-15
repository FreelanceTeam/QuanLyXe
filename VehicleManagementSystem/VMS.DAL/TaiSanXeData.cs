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

        #region Vehicle

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

        public DataTable GetAllDataTable()
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

        public DataTable GetLoaiTaiSanXe()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_lts, ten_lts FROM dm_loai_tai_san WHERE ma_nts = 'TSXE'");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("dm_loai_tai_san");
            da.Fill(dt);
            return dt;
        }

        public bool HasVehicleExisted(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ma_xe FROM tai_san_xe WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_xe");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool SaveVehicle(tai_san_xe tsx, bool isNew)
        {
            string sqlStr = "sp_TaiSanXe_Insert";
            if (!isNew)
                sqlStr = "sp_TaiSanXe_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = tsx.ma_xe;
            cmd.Parameters.Add("@bien_so", SqlDbType.VarChar).Value = tsx.bien_so;
            cmd.Parameters.Add("@hang_san_xuat", SqlDbType.NVarChar).Value = tsx.hang_san_xuat;
            cmd.Parameters.Add("@loai_xe", SqlDbType.VarChar).Value = tsx.loai_xe;
            cmd.Parameters.Add("@ma_lts", SqlDbType.NChar).Value = tsx.ma_lts;
            cmd.Parameters.Add("@nam_san_xuat", SqlDbType.SmallInt).Value = tsx.nam_san_xuat;
            cmd.Parameters.Add("@so_nam_su_dung", SqlDbType.TinyInt).Value = tsx.so_nam_su_dung;
            cmd.Parameters.Add("@so_may", SqlDbType.Char).Value = tsx.so_may;
            cmd.Parameters.Add("@so_khung", SqlDbType.Char).Value = tsx.so_khung;
            cmd.Parameters.Add("@mau", SqlDbType.NVarChar).Value = tsx.mau;
            cmd.Parameters.Add("@binh_nhien_lieu", SqlDbType.NChar).Value = tsx.binh_nhien_lieu;
            cmd.Parameters.Add("@loai_nhien_lieu", SqlDbType.NVarChar).Value = tsx.loai_nhien_lieu;
            cmd.Parameters.Add("@trong_tai_the_tich", SqlDbType.Decimal).Value = tsx.trong_tai_the_tich;
            cmd.Parameters.Add("@trong_tai_khoi_luong", SqlDbType.Decimal).Value = tsx.trong_tai_khoi_luong;
            cmd.Parameters.Add("@tong_trong_luong", SqlDbType.Decimal).Value = tsx.tong_trong_luong;
            cmd.Parameters.Add("@nguyen_gia", SqlDbType.Decimal).Value = tsx.nguyen_gia;
            cmd.Parameters.Add("@gia_tri_khau_hao", SqlDbType.Decimal).Value = tsx.gia_tri_khau_hao;
            cmd.Parameters.Add("@ti_le_khau_hao", SqlDbType.Decimal).Value = tsx.ti_le_khau_hao;
            cmd.Parameters.Add("@gia_tri_con_lai", SqlDbType.Decimal).Value = tsx.gia_tri_con_lai;
            cmd.Parameters.Add("@hinh_anh", SqlDbType.Image).Value = tsx.hinh_anh ?? (object)DBNull.Value;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NVarChar).Value = tsx.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.DateTime).Value = tsx.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = tsx.nguoi_cap_nhat;
            if (isNew)
            {
                cmd.Parameters.Add("@ngay_tao", SqlDbType.DateTime).Value = tsx.ngay_tao;
                cmd.Parameters.Add("@nguoi_tao", SqlDbType.NVarChar).Value = tsx.nguoi_tao;
            }
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = tsx.status;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeleteVehicle(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_TaiSanXe_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = ma_xe;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        #endregion

        #region Phụ tùng

        public DataTable GetTaiSanMMTB()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_tai_san, ten_tai_san FROM tai_san_may_moc_thiet_bi");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("tai_san_may_moc_thiet_bi");
            da.Fill(dt);
            return dt;
        }

        public DataTable GetAllPhuTung(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT pt.*, ts.ten_tai_san FROM x_phu_tung_kem_theo pt INNER JOIN tai_san_may_moc_thiet_bi ts ON pt.ma_tai_san = ts.ma_tai_san WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_phu_tung_kem_theo");
            da.Fill(dt);
            return dt;
        }

        public phu_tung GetPhuTung(string ma_xe, string ma_tai_san)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT pt.*, ts.ten_tai_san FROM x_phu_tung_kem_theo pt INNER JOIN tai_san_may_moc_thiet_bi ts ON pt.ma_tai_san = ts.ma_tai_san WHERE ma_xe = '{0}' AND ma_tai_san ='{1}'", ma_xe, ma_tai_san));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_phu_tung_kem_theo");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<phu_tung>(dt.Rows[0]);
            }
            return null;
        }

        public bool HasPhuTungExisted(string ma_xe, string ma_tai_san)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_phu_tung_kem_theo WHERE ma_xe = '{0}' AND ma_tai_san ='{1}'", ma_xe, ma_tai_san));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_phu_tung_kem_theo");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool SavePhuTung(phu_tung phuTung, bool isNew)
        {
            string sqlStr = "sp_PhuTung_Insert";
            if (!isNew)
                sqlStr = "sp_PhuTung_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = phuTung.ma_xe;
            cmd.Parameters.Add("@ma_tai_san", SqlDbType.VarChar).Value = phuTung.ma_tai_san;
            cmd.Parameters.Add("@so_luong", SqlDbType.TinyInt).Value = phuTung.so_luong;
            cmd.Parameters.Add("@so_km_da_su_dung", SqlDbType.Decimal).Value = phuTung.so_km_da_su_dung;
            cmd.Parameters.Add("@tinh_trang", SqlDbType.VarChar).Value = phuTung.tinh_trang;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeletePhuTung(string ma_xe, string ma_tai_san)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_PhuTung_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = ma_xe;
            cmd.Parameters.Add("@ma_tai_san", SqlDbType.VarChar).Value = ma_tai_san;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        #endregion

        #region Giấy đăng ký

        public DataTable GetDonVi()
        {
            SqlCommand cmd = DataFactory.CreateCommand("SELECT ma_bp, ten_bp FROM dm_bo_phan");
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("dm_bo_phan");
            da.Fill(dt);
            return dt;
        }

        public giay_dang_ky GetGiayDangKyByXe(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT TOP 1 dk.*, bp.ma_bp AS don_vi, bp.ten_bp AS ten_don_vi FROM x_giay_dang_ky dk INNER JOIN dm_bo_phan bp ON dk.don_vi = bp.ma_bp WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                giay_dang_ky result = ConvertionHelper.ToEntity<giay_dang_ky>(dt.Rows[0]);
                result.GiayDangKyCTList = GetGiayDangKyChiTiet(result.ma_giay);

                return result;
            }
            return null;
        }

        public giay_dang_ky GetGiayDangKy(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT dk.*, bp.ma_bp AS don_vi, bp.ten_bp AS ten_don_vi FROM x_giay_dang_ky dk INNER JOIN dm_bo_phan bp ON dk.don_vi = bp.ma_bp WHERE ma_giay = '{0}'", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                giay_dang_ky result = ConvertionHelper.ToEntity<giay_dang_ky>(dt.Rows[0]);
                result.GiayDangKyCTList = GetGiayDangKyChiTiet(ma_giay);

                return result; 
            }
            return null;
        }

        public DataTable GetGiayDangKyChiTietDataTable(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_giay_dang_ky_ct WHERE ma_giay = '{0}' ORDER BY ngay_cap", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky_ct");
            da.Fill(dt);
            return dt;
        }

        public List<giay_dang_ky_ct> GetGiayDangKyChiTiet(string ma_giay)
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

        public bool HasGiayDangKyExisted(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ma_giay FROM x_giay_dang_ky WHERE ma_giay = '{0}'", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool SaveGiayDangKy(giay_dang_ky gdk, bool isNew)
        {
            string sqlStr = "sp_GiayDangKy_Insert";
            if (!isNew)
                sqlStr = "sp_GiayDangKy_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = gdk.ma_xe;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = gdk.ma_giay;
            cmd.Parameters.Add("@don_vi", SqlDbType.VarChar).Value = gdk.don_vi;
            cmd.Parameters.Add("@ngay_cap_lan_dau", SqlDbType.SmallDateTime).Value = gdk.ngay_cap_lan_dau?? (object)DBNull.Value;
            cmd.Parameters.Add("@nhac_nho_truoc_ngay", SqlDbType.Decimal).Value = gdk.nhac_nho_truoc_ngay;
            cmd.Parameters.Add("@hinh_anh", SqlDbType.Image).Value = gdk.hinh_anh ?? (object)DBNull.Value;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NVarChar).Value = gdk.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.DateTime).Value = gdk.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = gdk.nguoi_cap_nhat;
            if (isNew)
            {
                cmd.Parameters.Add("@ngay_tao", SqlDbType.DateTime).Value = gdk.ngay_tao;
                cmd.Parameters.Add("@nguoi_tao", SqlDbType.NVarChar).Value = gdk.nguoi_tao;
            }
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = gdk.status;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeleteGiayDangKy(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_GiayDangKy_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = ma_giay;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool SaveGiayDangKyChiTiet(giay_dang_ky_ct gdkct, bool isNew)
        {
            string sqlStr = "sp_GiayDangKy_ChiTiet_Insert";
            if (!isNew)
                sqlStr = "sp_GiayDangKy_ChiTiet_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = gdkct.ma_giay;
            cmd.Parameters.Add("@ngay_cap", SqlDbType.SmallDateTime).Value = gdkct.ngay_cap;
            cmd.Parameters.Add("@ngay_het_han", SqlDbType.SmallDateTime).Value = gdkct.ngay_het_han;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NText).Value = gdkct.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.SmallDateTime).Value = gdkct.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = gdkct.nguoi_cap_nhat;
            cmd.Parameters.Add("@trang_thai", SqlDbType.VarChar).Value = gdkct.trang_thai;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeleteGiayDangKyChiTiet(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_GiayDangKy_ChiTiet_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = ma_giay;
            cmd.Parameters.Add("@ngay_cap", SqlDbType.SmallDateTime).Value = ngay_cap;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool HasGiayDangKyNgayCapExisted(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT 1 FROM x_giay_dang_ky_ct WHERE ma_giay = '{0}' and ngay_cap = '{1}'", ma_giay, ngay_cap));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky_ct");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool HasGiayDangKyNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT 1 FROM x_giay_dang_ky_ct WHERE ma_giay = '{0}' and ngay_cap > '{1}'", ma_giay, ngay_cap));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_ky_ct");
            da.Fill(dt);

            return dt.Rows.Count == 0;
        }

        #endregion

        #region Giấy đăng kiểm

        public giay_dang_kiem GetGiayDangKiemByXe(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT TOP 1 dk.*, bp.ma_bp AS don_vi, bp.ten_bp AS ten_don_vi FROM x_giay_dang_kiem dk INNER JOIN dm_bo_phan bp ON dk.don_vi = bp.ma_bp WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_kiem");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                giay_dang_kiem result = ConvertionHelper.ToEntity<giay_dang_kiem>(dt.Rows[0]);
                result.GiayDangKiemCTList = GetGiayDangKiemChiTiet(result.ma_giay);

                return result;
            }
            return null;
        }

        public giay_dang_kiem GetGiayDangKiem(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT dk.*, bp.ma_bp AS don_vi, bp.ten_bp AS ten_don_vi FROM x_giay_dang_kiem dk INNER JOIN dm_bo_phan bp ON dk.don_vi = bp.ma_bp WHERE ma_giay = '{0}'", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_kiem");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                giay_dang_kiem result = ConvertionHelper.ToEntity<giay_dang_kiem>(dt.Rows[0]);
                result.GiayDangKiemCTList = GetGiayDangKiemChiTiet(ma_giay);

                return result;
            }
            return null;
        }

        public DataTable GetGiayDangKiemChiTietDataTable(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_giay_dang_kiem_ct WHERE ma_giay = '{0}' ORDER BY ngay_cap", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_kiem_ct");
            da.Fill(dt);
            return dt;
        }

        public List<giay_dang_kiem_ct> GetGiayDangKiemChiTiet(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_giay_dang_kiem_ct WHERE ma_giay = '{0}' ORDER BY ngay_cap", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_kiem_ct");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return ConvertionHelper.ToList<giay_dang_kiem_ct>(dt);
            }
            return null;
        }

        public bool HasGiayDangKiemExisted(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT ma_giay FROM x_giay_dang_kiem WHERE ma_giay = '{0}'", ma_giay));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_kiem");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool SaveGiayDangKiem(giay_dang_kiem gdk, bool isNew)
        {
            string sqlStr = "sp_GiayDangKiem_Insert";
            if (!isNew)
                sqlStr = "sp_GiayDangKiem_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = gdk.ma_xe;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = gdk.ma_giay;
            cmd.Parameters.Add("@don_vi", SqlDbType.VarChar).Value = gdk.don_vi;
            cmd.Parameters.Add("@ngay_cap_lan_dau", SqlDbType.SmallDateTime).Value = gdk.ngay_cap_lan_dau ?? (object)DBNull.Value;
            cmd.Parameters.Add("@nhac_nho_truoc_ngay", SqlDbType.Decimal).Value = gdk.nhac_nho_truoc_ngay;
            cmd.Parameters.Add("@hinh_anh", SqlDbType.Image).Value = gdk.hinh_anh ?? (object)DBNull.Value;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NVarChar).Value = gdk.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.DateTime).Value = gdk.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = gdk.nguoi_cap_nhat;
            if (isNew)
            {
                cmd.Parameters.Add("@ngay_tao", SqlDbType.DateTime).Value = gdk.ngay_tao;
                cmd.Parameters.Add("@nguoi_tao", SqlDbType.NVarChar).Value = gdk.nguoi_tao;
            }
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = gdk.status;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeleteGiayDangKiem(string ma_giay)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_GiayDangKiem_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = ma_giay;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool SaveGiayDangKiemChiTiet(giay_dang_kiem_ct gdkct, bool isNew)
        {
            string sqlStr = "sp_GiayDangKiem_ChiTiet_Insert";
            if (!isNew)
                sqlStr = "sp_GiayDangKiem_ChiTiet_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = gdkct.ma_giay;
            cmd.Parameters.Add("@ngay_cap", SqlDbType.SmallDateTime).Value = gdkct.ngay_cap;
            cmd.Parameters.Add("@ngay_het_han", SqlDbType.SmallDateTime).Value = gdkct.ngay_het_han;
            cmd.Parameters.Add("@ghi_chu", SqlDbType.NText).Value = gdkct.ghi_chu;
            cmd.Parameters.Add("@ngay_cap_nhat", SqlDbType.SmallDateTime).Value = gdkct.ngay_cap_nhat;
            cmd.Parameters.Add("@nguoi_cap_nhat", SqlDbType.NVarChar).Value = gdkct.nguoi_cap_nhat;
            cmd.Parameters.Add("@trang_thai", SqlDbType.VarChar).Value = gdkct.trang_thai;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool DeleteGiayDangKiemChiTiet(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_GiayDangKiem_ChiTiet_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_giay", SqlDbType.VarChar).Value = ma_giay;
            cmd.Parameters.Add("@ngay_cap", SqlDbType.SmallDateTime).Value = ngay_cap;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool HasGiayDangKiemNgayCapExisted(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT 1 FROM x_giay_dang_kiem_ct WHERE ma_giay = '{0}' and ngay_cap = '{1}'", ma_giay, ngay_cap));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_kiem_ct");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool HasGiayDangKiemNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT 1 FROM x_giay_dang_kiem_ct WHERE ma_giay = '{0}' and ngay_cap > '{1}'", ma_giay, ngay_cap));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_giay_dang_kiem_ct");
            da.Fill(dt);

            return dt.Rows.Count == 0;
        }

        #endregion
    }
}
