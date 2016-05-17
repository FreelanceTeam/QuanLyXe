using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditBienBanThuHoiPresenter
    {
        private readonly IAddEditBienBanThuHoiView _addEditBienBanThuHoiView;
        private readonly BienBanThuHoiBLL _contextBLL;
        public bool IsNew = true;
        public bien_ban_thu_hoi CurrentBienBanThuHoi = null;
        public string MaXe;
        public AddEditBienBanThuHoiPresenter(IAddEditBienBanThuHoiView addEditBienBanThuHoiView)
        {
            _addEditBienBanThuHoiView = addEditBienBanThuHoiView;
            _contextBLL = new BienBanThuHoiBLL();
        }

        public void LoadDonVi()
        {
            _addEditBienBanThuHoiView.LoadTaiXe(_contextBLL.GetTaiXe());
        }

        public bool Save(bien_ban_thu_hoi entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string ma_giay)
        {
            return _contextBLL.HasExisted(ma_giay);
        }
    }
}
