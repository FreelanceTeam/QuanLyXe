using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKyChiTietPresenter
    {
        private readonly IAddEditGiayDangKyChiTietView _addEditGiayDangKyChiTietView;
        private readonly VehicleBLL _vehicleBLL;
        public bool IsNew = true;
        public giay_dang_ky_ct CurrentGiayDangKyChiTiet = null;
        public string MaGiay;
        public AddEditGiayDangKyChiTietPresenter(IAddEditGiayDangKyChiTietView addEditGiayDangKyChiTietView)
        {
            _addEditGiayDangKyChiTietView = addEditGiayDangKyChiTietView;
            _vehicleBLL = new VehicleBLL();
        }

        public bool SaveGiayDangKyChiTiet(giay_dang_ky_ct gdk)
        {
            return _vehicleBLL.SaveGiayDangKyChiTiet(gdk, IsNew);
        }

        public bool CheckNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            return _vehicleBLL.HasGiayDangKyNgayCapValid(ma_giay, ngay_cap);
        }

        public bool CheckNgayCapIfExisted(string ma_giay, DateTime ngay_cap)
        {
            return _vehicleBLL.HasGiayDangKyNgayCapExisted(ma_giay, ngay_cap);
        }
    }
}
