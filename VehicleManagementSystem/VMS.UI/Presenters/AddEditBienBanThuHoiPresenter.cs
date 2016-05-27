using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditBienBanThuHoiPresenter
    {
        private readonly IAddEditBienBanThuHoiView _view;
        private readonly BienBanThuHoiBLL _contextBLL;
        public bool IsNew = true;
        public bien_ban_thu_hoi CurrentBienBanThuHoi = null;
        public string MaXe;
        public AddEditBienBanThuHoiPresenter(IAddEditBienBanThuHoiView view)
        {
            _view = view;
            _contextBLL = new BienBanThuHoiBLL();
        }

        public void LoadTaiXe()
        {
            _view.LoadTaiXe(_contextBLL.GetTaiXe());
        }

        public bool Save(bien_ban_thu_hoi entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string so_bien_ban)
        {
            return _contextBLL.HasExisted(so_bien_ban);
        }
    }
}
