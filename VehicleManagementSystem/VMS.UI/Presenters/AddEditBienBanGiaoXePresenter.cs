using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditBienBanGiaoXePresenter
    {
        private readonly IAddEditBienBanGiaoXeView _addEditBienBanGiaoXeView;
        private readonly BienBanGiaoXeBLL _contextBLL;
        public bool IsNew = true;
        public bien_ban_giao_xe CurrentBienBanGiaoXe = null;
        public string MaXe;
        public AddEditBienBanGiaoXePresenter(IAddEditBienBanGiaoXeView addEditBienBanGiaoXeView)
        {
            _addEditBienBanGiaoXeView = addEditBienBanGiaoXeView;
            _contextBLL = new BienBanGiaoXeBLL();
        }

        public void LoadDonVi()
        {
            _addEditBienBanGiaoXeView.LoadTaiXe(_contextBLL.GetTaiXe());
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
