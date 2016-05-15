using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditVehiclePresenter
    {
        private readonly IAddEditVehicleView _addEditVehicleView;
        private readonly VehicleBLL _vehicleBLL;
        public bool IsNew = true;
        public tai_san_xe CurrentVehicle = null;
        public AddEditVehiclePresenter(IAddEditVehicleView addEditVehicleView)
        {
            _addEditVehicleView = addEditVehicleView;
            _vehicleBLL = new VehicleBLL();
        }

        public void LoadLoaiTaiSanXe()
        {
           _addEditVehicleView.LoadLoaiTaiSanXe(_vehicleBLL.GetLoaiTaiSanXe());
        }

        public bool SaveVehicle(tai_san_xe tsx)
        {
            return _vehicleBLL.SaveVehicle(tsx, IsNew);
        }

        public bool CheckMaXeIfExisted(string ma_xe)
        {
            return _vehicleBLL.HasVehicleExisted(ma_xe);
        }

    }
}
