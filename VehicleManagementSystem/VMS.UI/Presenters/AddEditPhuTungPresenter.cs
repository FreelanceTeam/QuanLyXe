using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditPhuTungPresenter
    {
        private readonly IAddEditPhuTungView _view;
        private readonly PhuTungBLL _contextBLL;
        public bool IsNew = true;
        public phu_tung CurrentPhuTung = null;
        public string MaXe;
        public AddEditPhuTungPresenter(IAddEditPhuTungView view)
        {
            _view = view;
            _contextBLL = new PhuTungBLL();
        }

        public void LoadPhuTung()
        {
            _view.LoadTaiSanMMTB(_contextBLL.GetTaiSanMMTB());
        }

        public bool Save(phu_tung entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckPhuTungIfExisted(string ma_xe, string ma_tai_san)
        {
            return _contextBLL.HasExisted(ma_xe, ma_tai_san);
        }
    }
}
