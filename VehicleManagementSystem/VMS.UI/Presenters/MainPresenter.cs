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
        private readonly IMainView _mainView;
        private readonly VehicleBLL _vehicleBLL;
        public DataTable CurrentVehiclesDataTable;
        public List<tai_san_xe> CurrentVehiclesList;
        public tai_san_xe CurrentVehicle;
        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
            _vehicleBLL = new VehicleBLL();
            CurrentVehicle = null;
        }

        public void LoadVehiclesDataTable()
        {
            CurrentVehiclesDataTable = _vehicleBLL.GetAllVehiclesDataTable();
            CurrentVehiclesList = ConvertionHelper.ToList<tai_san_xe>(CurrentVehiclesDataTable);
            RefreshVehicleDataGrid(true, true, string.Empty);
        }

        public bool DeleteVehicle(string ma_xe)
        {
            return _vehicleBLL.DeleteVehicle(ma_xe);
        }

        public void RefreshVehicleDataGrid(bool isIncludeActive, bool isIncludeInactive, string condition)
        {
            DataView dv = new DataView(CurrentVehiclesDataTable);
            StringBuilder filter = new StringBuilder("(1 = 0");
            if (isIncludeActive)
            {
                filter.Append(" OR status = '1'");
            }
            if (isIncludeInactive)
            {
                filter.Append(" OR status = '0'");
            }
            filter.Append(")");

            if (!string.IsNullOrEmpty(condition))
            {
                filter.Append(string.Format(" AND bien_so LIKE '%{0}%'",condition));
            }

            dv.RowFilter = filter.ToString();
            _mainView.RefreshDataGrid(dv);
        }

        #region Phụ tùng

        public void LoadPhuTungDataTable()
        {
            if (CurrentVehicle != null)
            {
                _mainView.LoadPhuTungDataTable(_vehicleBLL.GetAllPhuTung(CurrentVehicle.ma_xe));
            }
        }

        public bool DeletePhuTung(string ma_tai_san)
        {
            return _vehicleBLL.DeletePhuTung(CurrentVehicle.ma_xe, ma_tai_san);
        }

        #endregion

        #region Giấy đăng ký

        public void LoadGiayDangKy()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.GiayDangKy = _vehicleBLL.GetGiayDangKyByXe(CurrentVehicle.ma_xe);
                _mainView.LoadGiayDangKy(CurrentVehicle.GiayDangKy);
            }
        }

        public bool DeleteGiayDangKy(string ma_giay)
        {
            return _vehicleBLL.DeleteGiayDangKy(ma_giay);
        }

        public bool DeleteGiayDangKyChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _vehicleBLL.DeleteGiayDangKyChiTiet(ma_giay, ngay_cap);
        }

        #endregion

        #region Giấy đăng kiểm

        public void LoadGiayDangKiem()
        {
            if (CurrentVehicle != null)
            {
                CurrentVehicle.GiayDangKiem = _vehicleBLL.GetGiayDangKiemByXe(CurrentVehicle.ma_xe);
                _mainView.LoadGiayDangKiem(CurrentVehicle.GiayDangKiem);
            }
        }

        public bool DeleteGiayDangKiem(string ma_giay)
        {
            return _vehicleBLL.DeleteGiayDangKiem(ma_giay);
        }

        public bool DeleteGiayDangKiemChiTiet(string ma_giay, DateTime ngay_cap)
        {
            return _vehicleBLL.DeleteGiayDangKiemChiTiet(ma_giay, ngay_cap);
        }

        #endregion

    }
}
