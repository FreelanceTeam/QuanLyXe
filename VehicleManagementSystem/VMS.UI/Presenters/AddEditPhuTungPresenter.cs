using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditPhuTungPresenter
    {
        private readonly IAddEditPhuTungView _addEditPhuTungView;
        private readonly VehicleBLL _vehicleBLL;
        public bool IsNew = true;
        public phu_tung CurrentPhuTung = null;
        public string MaXe;
        public AddEditPhuTungPresenter(IAddEditPhuTungView addEditPhuTungView)
        {
            _addEditPhuTungView = addEditPhuTungView;
            _vehicleBLL = new VehicleBLL();
        }

        public void LoadPhuTung()
        {
            _addEditPhuTungView.LoadTaiSanMMTB(_vehicleBLL.GetTaiSanMMTB());
        }

        public bool SavePhuTung(phu_tung phuTung)
        {
            return _vehicleBLL.SavePhuTung(phuTung, IsNew);
        }

        public bool CheckPhuTungIfExisted(string ma_xe, string ma_tai_san)
        {
            return _vehicleBLL.HasPhuTungExisted(ma_xe, ma_tai_san);
        }
    }
}
