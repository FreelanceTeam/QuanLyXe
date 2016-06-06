using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditLichSuTaiXePresenter
    {
        private readonly IAddEditLichSuTaiXeView _view;
        private readonly LichSuTaiXeBLL _contextBLL;
        public bool IsNew = true;
        public lich_su_tai_xe CurrentLichSuTaiXe = null;
        public string MaXe;
        public AddEditLichSuTaiXePresenter(IAddEditLichSuTaiXeView view)
        {
            _view = view;
            _contextBLL = new LichSuTaiXeBLL();
        }

        public void LoadLichSuTaiXe()
        {
            _view.LoadTaiXe(_contextBLL.GetTaiXe());
        }

        public bool Save(lich_su_tai_xe entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckLichSuTaiXeIfExisted(string ma_xe, string ma_tai_xe)
        {
            return _contextBLL.HasExisted(ma_xe, ma_tai_xe);
        }
    }
}
