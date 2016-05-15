using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKiemPresenter
    {
        private readonly IAddEditGiayDangKiemView _addEditGiayDangKiemView;
        private readonly VehicleBLL _vehicleBLL;
        public bool IsNew = true;
        public giay_dang_kiem CurrentGiayDangKiem = null;
        public string MaXe;
        public AddEditGiayDangKiemPresenter(IAddEditGiayDangKiemView addEditGiayDangKiemView)
        {
            _addEditGiayDangKiemView = addEditGiayDangKiemView;
            _vehicleBLL = new VehicleBLL();
        }

        public void LoadDonVi()
        {
            _addEditGiayDangKiemView.LoadDonVi(_vehicleBLL.GetDonVi());
        }

        public bool SaveGiayDangKiem(giay_dang_kiem gdk)
        {
            return _vehicleBLL.SaveGiayDangKiem(gdk, IsNew);
        }

        public bool CheckGiayDangKiemIfExisted(string ma_giay)
        {
            return _vehicleBLL.HasGiayDangKiemExisted(ma_giay);
        }
    }
}
