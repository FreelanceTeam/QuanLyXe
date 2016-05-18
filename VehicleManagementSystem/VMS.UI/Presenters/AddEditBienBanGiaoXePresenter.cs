using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditBienBanGiaoXePresenter
    {
        private readonly IAddEditBienBanGiaoXeView _view;
        private readonly BienBanGiaoXeBLL _contextBLL;
        public bool IsNew = true;
        public bien_ban_giao_xe CurrentBienBanGiaoXe = null;
        public string MaXe;
        public AddEditBienBanGiaoXePresenter(IAddEditBienBanGiaoXeView view)
        {
            _view = view;
            _contextBLL = new BienBanGiaoXeBLL();
        }

        public void LoadDonVi()
        {
            _view.LoadTaiXe(_contextBLL.GetTaiXe());
        }

        public bool Save(bien_ban_giao_xe entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string ma_giay)
        {
            return _contextBLL.HasExisted(ma_giay);
        }
    }
}
