using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.Helper;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly TaiSanXeBLL _taiSanXeBLL;
        private readonly PhuTungBLL _phuTungBLL;
        private readonly GiayDangKyBLL _giayDangKyBLL;
        private readonly GiayDangKiemBLL _giayDangKiemBLL;
        private readonly GiayBaoTriDuongBoBLL _giayBaoTriDuongBoBLL;
        private readonly GiayBaoHiemNhanSuBLL _giayBaoHiemNhanSuBLL;
        private readonly GiayBaoHiemThanXeBLL _giayBaoHiemThanXeBLL;
        private readonly BienBanGiaoXeBLL _bienBanGiaoXeBLL;
        private readonly BienBanThuHoiBLL _bienBanThuHoiBLL;
        private readonly LichSuTaiXeBLL _lichSuTaiXeBLL;
        private readonly LichSuKhauHaoBLL _lichSuKhauHaoBLL;

        public DataTable CurrentVehiclesDataTable;
        public List<tai_san_xe> CurrentVehiclesList;
        public tai_san_xe CurrentVehicle;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _taiSanXeBLL = new TaiSanXeBLL();
            _phuTungBLL = new PhuTungBLL();
            _giayDangKyBLL = new GiayDangKyBLL();
            _giayDangKiemBLL = new GiayDangKiemBLL();
            _giayBaoTriDuongBoBLL = new GiayBaoTriDuongBoBLL();
            _giayBaoHiemNhanSuBLL = new GiayBaoHiemNhanSuBLL();
            _giayBaoHiemThanXeBLL = new GiayBaoHiemThanXeBLL();
            _bienBanGiaoXeBLL = new BienBanGiaoXeBLL();
            _bienBanThuHoiBLL = new BienBanThuHoiBLL();
            _lichSuTaiXeBLL = new LichSuTaiXeBLL();
            _lichSuKhauHaoBLL = new LichSuKhauHaoBLL();

            CurrentVehicle = null;
        }

        public void LoadVehiclesDataTable()
        {
            CurrentVehiclesDataTable = _taiSanXeBLL.GetAllAsDataTable();
            CurrentVehiclesList = ConvertionHelper.ToList<tai_san_xe>(CurrentVehiclesDataTable);
            RefreshVehicleDataGrid(true, true, string.Empty);
        }

        public bool DeleteVehicle(string ma_xe)
        {
            return _taiSanXeBLL.Delete(ma_xe);
        }

        public void RefreshVehicleDataGrid(bool isIncludeActive, bool isIncludeInactive, string condition)
        {
            DataView dv = new DataView(CurrentVehiclesDataTable);
            StringBuilder filter = new StringBuilder("(1 = 0");
            if (isIncludeActive)
            {
                filter.Append(" OR status = 'Y'");
            }
            if (isIncludeInactive)
            {
                filter.Append(" OR status = 'N'");
            }
            filter.Append(")");

            if (!string.IsNullOrEmpty(condition))
            {
                filter.Append(string.Format(" AND bien_so LIKE '%{0}%'",condition));
            }

            dv.RowFilter = filter.ToString();
            _view.RefreshDataGrid(dv);
        }

        public void LoadThongTinXe()
        {
            _view.LoadThongTinXe(_taiSanXeBLL.GetThongTinTaiSanXe());
        }

        #region Lịch sử khấu hao

        public void LoadLichSuKhauHao()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.LichSuKhauHaoList = _lichSuKhauHaoBLL.GetAll(CurrentVehicle.ma_xe);
                _view.LoadLichSuKhauHao(CurrentVehicle.LichSuKhauHaoList, GetKhauHaoDangSuDung());
            }
        }

        private lich_su_khau_hao GetKhauHaoDangSuDung()
        {
            lich_su_khau_hao entity = null;
            if (CurrentVehicle.LichSuKhauHaoList != null && CurrentVehicle.LichSuKhauHaoList.Count > 0 )
            {
                entity = CurrentVehicle.LichSuKhauHaoList[0];
                for (int i = 1; i < CurrentVehicle.LichSuKhauHaoList.Count; i++)
                {
                    lich_su_khau_hao temp = CurrentVehicle.LichSuKhauHaoList[i];
                    if (entity.ngay_hieu_luc < temp.ngay_hieu_luc)
                    {
                        entity = temp;
                    }
                }
            }

            return entity;
        }

        public bool DeleteKhauHao(string ma_xe, DateTime ngay_hieu_luc)
        {
            return _lichSuKhauHaoBLL.Delete(CurrentVehicle.ma_xe, ngay_hieu_luc);
        }

        public string TinhKhauHaoXe()
        {
            return _lichSuKhauHaoBLL.TinhKhauHaoXe();
        }

        #endregion

        #region Lịch sử tài xế

        public void LoadLichSuTaiXe()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.TaiXeList = _lichSuTaiXeBLL.GetAll(CurrentVehicle.ma_xe);
                _view.LoadLichSuTaiXe(CurrentVehicle.TaiXeList);
            }
        }

        public bool DeleteTaiXe(string ma_tai_xe)
        {
            return _lichSuTaiXeBLL.Delete(CurrentVehicle.ma_xe, ma_tai_xe);
        }

        #endregion

        #region Phụ tùng

        public void LoadPhuTungDataTable()
        {
            if (CurrentVehicle != null)
            {
                _view.LoadPhuTungDataTable(_phuTungBLL.GetAllAsDataTable(CurrentVehicle.ma_xe));
            }
        }

        public bool DeletePhuTung(string ma_tai_san)
        {
            return _phuTungBLL.Delete(CurrentVehicle.ma_xe, ma_tai_san);
        }

        #endregion

        #region Giấy đăng ký

        public void LoadGiayDangKy()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.GiayDangKy = _giayDangKyBLL.GetByMaXe(CurrentVehicle.ma_xe);
                _view.LoadGiayDangKy(CurrentVehicle.GiayDangKy);
            }
        }

        public bool DeleteGiayDangKy(string ma_giay)
        {
            return _giayDangKyBLL.Delete(ma_giay);
        }

        public bool DeleteGiayDangKyChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _giayDangKyBLL.DeleteDetail(ma_giay, ngay_cap);
        }

        #endregion

        #region Giấy đăng kiểm

        public void LoadGiayDangKiem()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.GiayDangKiem = _giayDangKiemBLL.GetByMaXe(CurrentVehicle.ma_xe);
                _view.LoadGiayDangKiem(CurrentVehicle.GiayDangKiem);
            }
        }

        public bool DeleteGiayDangKiem(string ma_giay)
        {
            return _giayDangKiemBLL.Delete(ma_giay);
        }

        public bool DeleteGiayDangKiemChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _giayDangKiemBLL.DeleteDetail(ma_giay, ngay_cap);
        }

        #endregion

        #region Giấy bảo trì đường bộ

        public void LoadGiayBaoTriDuongBo()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.GiayBaoTriDuongBo = _giayBaoTriDuongBoBLL.GetByMaXe(CurrentVehicle.ma_xe);
                _view.LoadGiayBaoTriDuongBo(CurrentVehicle.GiayBaoTriDuongBo);
            }
        }

        public bool DeleteGiayBaoTriDuongBo(string ma_giay)
        {
            return _giayBaoTriDuongBoBLL.Delete(ma_giay);
        }

        public bool DeleteGiayBaoTriDuongBoChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _giayBaoTriDuongBoBLL.DeleteDetail(ma_giay, ngay_cap);
        }

        #endregion

        #region Giấy bảo hiểm nhân sự

        public void LoadGiayBaoHiemNhanSu()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.GiayBaoHiemNhanSu = _giayBaoHiemNhanSuBLL.GetByMaXe(CurrentVehicle.ma_xe);
                _view.LoadGiayBaoHiemNhanSu(CurrentVehicle.GiayBaoHiemNhanSu);
            }
        }

        public bool DeleteGiayBaoHiemNhanSu(string ma_giay)
        {
            return _giayBaoHiemNhanSuBLL.Delete(ma_giay);
        }

        public bool DeleteGiayBaoHiemNhanSuChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _giayBaoHiemNhanSuBLL.DeleteDetail(ma_giay, ngay_cap);
        }

        #endregion

        #region Giấy bảo hiểm thân xe

        public void LoadGiayBaoHiemThanXe()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.GiayBaoHiemThanXe = _giayBaoHiemThanXeBLL.GetByMaXe(CurrentVehicle.ma_xe);
                _view.LoadGiayBaoHiemThanXe(CurrentVehicle.GiayBaoHiemThanXe);
            }
        }

        public bool DeleteGiayBaoHiemThanXe(string ma_giay)
        {
            return _giayBaoHiemThanXeBLL.Delete(ma_giay);
        }

        public bool DeleteGiayBaoHiemThanXeChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _giayBaoHiemThanXeBLL.DeleteDetail(ma_giay, ngay_cap);
        }

        #endregion

        #region Biên bản giao xe

        public void LoadBienBanGiaoXe(bool isReload)
        {
            if (CurrentVehicle != null)
            {
                if (isReload)
                {
                    CurrentVehicle.BienBanGiaoXe = _bienBanGiaoXeBLL.GetByXe(CurrentVehicle.ma_xe);
                }
                else
                {
                    bool isHistory = false;
                    if (CurrentVehicle.BienBanGiaoXe != null)
                    {
                        isHistory = CurrentVehicle.BienBanGiaoXe.IsHistory;
                        CurrentVehicle.BienBanGiaoXe = _bienBanGiaoXeBLL.Get(CurrentVehicle.BienBanGiaoXe.so_bien_ban);
                    }
                    else
                    {
                        CurrentVehicle.BienBanGiaoXe = _bienBanGiaoXeBLL.GetByXe(CurrentVehicle.ma_xe);
                    }
                    CurrentVehicle.BienBanGiaoXe.IsHistory = isHistory;
                }
                

                _view.LoadBienBanGiaoXe(CurrentVehicle.BienBanGiaoXe);
            }
        }

        public bool DeleteBienBanGiaoXe(string so_bien_ban)
        {
            return _bienBanGiaoXeBLL.Delete(so_bien_ban);
        }

        public bool DeleteBienBanGiaoXeChiTiet(string so_bien_ban, string ma_ccdc)
        {
            return _bienBanGiaoXeBLL.DeleteDetail(so_bien_ban, ma_ccdc);
        }

        #endregion

        #region Giấy Biên bản thu hồi

        public void LoadBienBanThuHoi()
        {
            if (CurrentVehicle != null)
            {
                _view.LoadBienBanThuHoi(_bienBanThuHoiBLL.GetAll(CurrentVehicle.ma_xe));
            }
        }

        public bool DeleteBienBanThuHoi(string so_bien_ban)
        {
            return _bienBanThuHoiBLL.Delete(so_bien_ban);
        }

        #endregion

    }
}
