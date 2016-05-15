using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKyPresenter
    {
        private readonly IAddEditGiayDangKyView _addEditGiayDangKyView;
        private readonly VehicleBLL _vehicleBLL;
        public bool IsNew = true;
        public giay_dang_ky CurrentGiayDangKy = null;
        public string MaXe;
        public AddEditGiayDangKyPresenter(IAddEditGiayDangKyView addEditGiayDangKyView)
        {
            _addEditGiayDangKyView = addEditGiayDangKyView;
            _vehicleBLL = new VehicleBLL();
        }

        public void LoadDonVi()
        {
            _addEditGiayDangKyView.LoadDonVi(_vehicleBLL.GetDonVi());
        }

        public bool SaveGiayDangKy(giay_dang_ky gdk)
        {
            return _vehicleBLL.SaveGiayDangKy(gdk, IsNew);
        }

        public bool CheckGiayDangKyIfExisted(string ma_giay)
        {
            return _vehicleBLL.HasGiayDangKyExisted(ma_giay);
        }
    }
}
