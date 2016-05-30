using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditVehiclePresenter
    {
        private readonly IAddEditVehicleView _view;
        private readonly TaiSanXeBLL _contextBLL;
        public bool IsNew = true;
        public tai_san_xe CurrentVehicle = null;
        public AddEditVehiclePresenter(IAddEditVehicleView view)
        {
            _view = view;
            _contextBLL = new TaiSanXeBLL();
        }

        public void LoadLoaiTaiSanXe()
        {
           _view.LoadLoaiTaiSanXe(_contextBLL.GetLoaiTaiSanXe());
        }

        public bool Save(tai_san_xe entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckMaXeIfExisted(string ma_xe)
        {
            return _contextBLL.HasExisted(ma_xe);
        }

        public void LoadHangXe()
        {
            _view.LoadHangXe(_contextBLL.GetHangXe());
        }

        public void LoadLoaiXe()
        {
            _view.LoadLoaiXe(_contextBLL.GetLoaiXe());
        }

        public void LoadMauXe()
        {
            _view.LoadMauXe(_contextBLL.GetMauXe());
        }

    }
}
