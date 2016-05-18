using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKiemPresenter
    {
        private readonly IAddEditGiayDangKiemView _view;
        private readonly GiayDangKiemBLL _contextBLL;
        public bool IsNew = true;
        public giay_dang_kiem CurrentGiayDangKiem = null;
        public string MaXe;
        public AddEditGiayDangKiemPresenter(IAddEditGiayDangKiemView view)
        {
            _view = view;
            _contextBLL = new GiayDangKiemBLL();
        }

        public void LoadDonVi()
        {
            _view.LoadDonVi(_contextBLL.GetDonVi());
        }

        public bool Save(giay_dang_kiem entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string ma_giay)
        {
            return _contextBLL.HasExisted(ma_giay);
        }
    }
}
