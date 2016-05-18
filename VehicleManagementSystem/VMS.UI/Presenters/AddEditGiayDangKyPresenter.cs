using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKyPresenter
    {
        private readonly IAddEditGiayDangKyView _view;
        private readonly GiayDangKyBLL _contextBLL;
        public bool IsNew = true;
        public giay_dang_ky CurrentGiayDangKy = null;
        public string MaXe;
        public AddEditGiayDangKyPresenter(IAddEditGiayDangKyView view)
        {
            _view = view;
            _contextBLL = new GiayDangKyBLL();
        }

        public void LoadDonVi()
        {
            _view.LoadDonVi(_contextBLL.GetDonVi());
        }

        public bool Save(giay_dang_ky entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string ma_giay)
        {
            return _contextBLL.HasExisted(ma_giay);
        }
    }
}
