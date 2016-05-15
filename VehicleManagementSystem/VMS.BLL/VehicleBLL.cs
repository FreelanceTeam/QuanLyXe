using System;
using System.Collections.Generic;
using System.Data;
using VMS.DAL;
using VMS.DAL.Entity;

namespace VMS.BLL
{
    public class VehicleBLL
    {
        private readonly TaiSanXeData _taiSanXe;
        public VehicleBLL()
        {
            _taiSanXe = new TaiSanXeData();
        }

        #region Vehicle

        public List<tai_san_xe> GetAllVehicles()
        {
            return _taiSanXe.GetAll();
        }

        public DataTable GetAllVehiclesDataTable()
        {
            return _taiSanXe.GetAllDataTable();
        }

        public tai_san_xe GetVehicle(string ma_xe)
        {
            return _taiSanXe.GetByMaXe(ma_xe);
        }

        public DataTable GetLoaiTaiSanXe()
        {
            return _taiSanXe.GetLoaiTaiSanXe();
        }

        public bool HasVehicleExisted(string ma_xe)
        {
            return _taiSanXe.HasVehicleExisted(ma_xe);
        }

        public bool SaveVehicle(tai_san_xe tsx, bool isNew)
        {
            return _taiSanXe.SaveVehicle(tsx, isNew);
        }

        public bool DeleteVehicle(string ma_xe)
        {
            return _taiSanXe.DeleteVehicle(ma_xe);
        }

        #endregion

        #region Phụ tùng

        public DataTable GetTaiSanMMTB()
        {
            return _taiSanXe.GetTaiSanMMTB();
        }

        public DataTable GetAllPhuTung(string ma_xe)
        {
            return _taiSanXe.GetAllPhuTung(ma_xe);
        }

        public phu_tung GetPhuTung(string ma_xe, string ma_tai_san)
        {
            return _taiSanXe.GetPhuTung(ma_xe, ma_tai_san);
        }

        public bool HasPhuTungExisted(string ma_xe, string ma_tai_san)
        {
            return _taiSanXe.HasPhuTungExisted(ma_xe, ma_tai_san);
        }

        public bool SavePhuTung(phu_tung phuTung, bool isNew)
        {
            return _taiSanXe.SavePhuTung(phuTung, isNew);
        }

        public bool DeletePhuTung(string ma_xe, string ma_tai_san)
        {
            return _taiSanXe.DeletePhuTung(ma_xe, ma_tai_san);
        }

        #endregion

        #region Giấy đăng ký

        public DataTable GetDonVi()
        {
            return _taiSanXe.GetDonVi();
        }

        public giay_dang_ky GetGiayDangKyByXe(string ma_xe)
        {
            return _taiSanXe.GetGiayDangKyByXe(ma_xe);
        }

        public giay_dang_ky GetGiayDangKy(string ma_giay)
        {
            return _taiSanXe.GetGiayDangKy(ma_giay);
        }

        public DataTable GetGiayDangKyChiTietDataTable(string ma_giay)
        {
            return _taiSanXe.GetGiayDangKyChiTietDataTable(ma_giay);
        }

        public List<giay_dang_ky_ct> GetGiayDangKyChiTiet(string ma_giay)
        {
            return _taiSanXe.GetGiayDangKyChiTiet(ma_giay);
        }

        public bool HasGiayDangKyExisted(string ma_giay)
        {
            return _taiSanXe.HasGiayDangKyExisted(ma_giay);
        }

        public bool SaveGiayDangKy(giay_dang_ky gdk, bool isNew)
        {
            return _taiSanXe.SaveGiayDangKy(gdk, isNew);
        }

        public bool DeleteGiayDangKy(string ma_giay)
        {
            return _taiSanXe.DeleteGiayDangKy(ma_giay);
        }

        public bool SaveGiayDangKyChiTiet(giay_dang_ky_ct gdkct, bool isNew)
        {
            return _taiSanXe.SaveGiayDangKyChiTiet(gdkct, isNew);
        }

        public bool DeleteGiayDangKyChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _taiSanXe.DeleteGiayDangKyChiTiet(ma_giay, ngay_cap);
        }

        public bool HasGiayDangKyNgayCapExisted(string ma_giay, DateTime ngay_cap)
        {
            return _taiSanXe.HasGiayDangKyNgayCapExisted(ma_giay, ngay_cap);
        }

        public bool HasGiayDangKyNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            return _taiSanXe.HasGiayDangKyNgayCapValid(ma_giay, ngay_cap);
        }

        #endregion

        #region Giấy đăng kiểm

        public giay_dang_kiem GetGiayDangKiemByXe(string ma_xe)
        {
            return _taiSanXe.GetGiayDangKiemByXe(ma_xe);
        }

        public giay_dang_kiem GetGiayDangKiem(string ma_giay)
        {
            return _taiSanXe.GetGiayDangKiem(ma_giay);
        }

        public DataTable GetGiayDangKiemChiTietDataTable(string ma_giay)
        {
            return _taiSanXe.GetGiayDangKiemChiTietDataTable(ma_giay);
        }

        public List<giay_dang_kiem_ct> GetGiayDangKiemChiTiet(string ma_giay)
        {
            return _taiSanXe.GetGiayDangKiemChiTiet(ma_giay);
        }

        public bool HasGiayDangKiemExisted(string ma_giay)
        {
            return _taiSanXe.HasGiayDangKiemExisted(ma_giay);
        }

        public bool SaveGiayDangKiem(giay_dang_kiem gdk, bool isNew)
        {
            return _taiSanXe.SaveGiayDangKiem(gdk, isNew);
        }

        public bool DeleteGiayDangKiem(string ma_giay)
        {
            return _taiSanXe.DeleteGiayDangKiem(ma_giay);
        }

        public bool SaveGiayDangKiemChiTiet(giay_dang_kiem_ct gdkct, bool isNew)
        {
            return _taiSanXe.SaveGiayDangKiemChiTiet(gdkct, isNew);
        }

        public bool DeleteGiayDangKiemChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _taiSanXe.DeleteGiayDangKiemChiTiet(ma_giay, ngay_cap);
        }

        public bool HasGiayDangKiemNgayCapExisted(string ma_giay, DateTime ngay_cap)
        {
            return _taiSanXe.HasGiayDangKiemNgayCapExisted(ma_giay, ngay_cap);
        }

        public bool HasGiayDangKiemNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            return _taiSanXe.HasGiayDangKiemNgayCapValid(ma_giay, ngay_cap);
        }

        #endregion
    }
}
