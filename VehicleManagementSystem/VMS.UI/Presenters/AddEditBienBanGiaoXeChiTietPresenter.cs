using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditBienBanGiaoXeChiTietPresenter
    {
        private readonly IAddEditBienBanGiaoXeChiTietView _view;
        private readonly BienBanGiaoXeBLL _contextBLL;
        public bool IsNew = true;
        public bien_ban_giao_xe_ct CurrentBienBanGiaoXeChiTiet = null;
        public string SoBienBan;
        public AddEditBienBanGiaoXeChiTietPresenter(IAddEditBienBanGiaoXeChiTietView view)
        {
            _view = view;
            _contextBLL = new BienBanGiaoXeBLL();
        }

        public void LoadCCDC()
        {
            _view.LoadCCDC(_contextBLL.GetCCDC());
        }

        public bool Save(bien_ban_giao_xe_ct entity)
        {
            return _contextBLL.SaveDetail(entity, IsNew);
        }

        public bool CheckIfExisted(string so_bien_ban, string ma_ccdc)
        {
            return _contextBLL.HasDetailExisted(so_bien_ban, ma_ccdc);
        }
    }
}
