using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class HistoryBienBanGiaoXePresenter
    {
        private readonly IHistoryBienBanGiaoXeView _view;
        private readonly BienBanGiaoXeBLL _contextBLL;
        public string MaXe;
        public HistoryBienBanGiaoXePresenter(IHistoryBienBanGiaoXeView view)
        {
            _view = view;
            _contextBLL = new BienBanGiaoXeBLL();
        }

        public void LoadAllBienBanGiaoXe()
        {
            _view.LoadAllBienBanGiaoXe(_contextBLL.GetAll(MaXe));
        }
    }
}
