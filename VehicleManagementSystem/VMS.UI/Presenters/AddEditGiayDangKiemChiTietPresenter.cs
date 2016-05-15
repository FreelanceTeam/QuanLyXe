using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKiemChiTietPresenter
    {
        private readonly IAddEditGiayDangKiemChiTietView _addEditGiayDangKiemChiTietView;
        private readonly VehicleBLL _vehicleBLL;
        public bool IsNew = true;
        public giay_dang_kiem_ct CurrentGiayDangKiemChiTiet = null;
        public string MaGiay;
        public AddEditGiayDangKiemChiTietPresenter(IAddEditGiayDangKiemChiTietView addEditGiayDangKiemChiTietView)
        {
            _addEditGiayDangKiemChiTietView = addEditGiayDangKiemChiTietView;
            _vehicleBLL = new VehicleBLL();
        }

        public bool SaveGiayDangKiemChiTiet(giay_dang_kiem_ct gdk)
        {
            return _vehicleBLL.SaveGiayDangKiemChiTiet(gdk, IsNew);
        }

        public bool CheckNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            return _vehicleBLL.HasGiayDangKiemNgayCapValid(ma_giay, ngay_cap);
        }

        public bool CheckNgayCapIfExisted(string ma_giay, DateTime ngay_cap)
        {
            return _vehicleBLL.HasGiayDangKiemNgayCapExisted(ma_giay, ngay_cap);
        }
    }
}
