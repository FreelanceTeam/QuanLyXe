using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditLichSuKhauHaoPresenter
    {
        private readonly IAddEditLichSuKhauHaoView _view;
        private readonly LichSuKhauHaoBLL _contextBLL;
        public lich_su_khau_hao CurrentKhauHao = null;
        public string MaXe;
        public AddEditLichSuKhauHaoPresenter(IAddEditLichSuKhauHaoView view)
        {
            _view = view;
            _contextBLL = new LichSuKhauHaoBLL();
        }

        public void LoadLatestKhauHao()
        {
            CurrentKhauHao = _contextBLL.GetLatest(MaXe);
        }

        public bool Save(lich_su_khau_hao entity)
        {
            return _contextBLL.Save(entity);
        }

        public bool CheckLichSuKhauHaoIfExisted(string ma_xe, DateTime ngay_hieu_luc)
        {
            return _contextBLL.HasExisted(ma_xe, ngay_hieu_luc);
        }
    }
}
