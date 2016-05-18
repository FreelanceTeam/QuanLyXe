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
        public string MaGiay;
        public AddEditBienBanGiaoXeChiTietPresenter(IAddEditBienBanGiaoXeChiTietView view)
        {
            _view = view;
            _contextBLL = new BienBanGiaoXeBLL();
        }

        public bool Save(bien_ban_giao_xe_ct gdk)
        {
            return _contextBLL.SaveDetail(gdk, IsNew);
        }

        public bool CheckIfExisted(string so_bien_ban, string ma_ccdc)
        {
            return _contextBLL.HasDetailExisted(so_bien_ban, ma_ccdc);
        }
    }
}
