using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayBaoHiemThanXePresenter
    {
        private readonly IAddEditGiayBaoHiemThanXeView _addEditGiayBaoHiemThanXeView;
        private readonly GiayBaoHiemThanXeBLL _contextBLL;
        public bool IsNew = true;
        public giay_bao_hiem_than_xe CurrentGiayBaoHiemThanXe = null;
        public string MaXe;
        public AddEditGiayBaoHiemThanXePresenter(IAddEditGiayBaoHiemThanXeView addEditGiayBaoHiemThanXeView)
        {
            _addEditGiayBaoHiemThanXeView = addEditGiayBaoHiemThanXeView;
            _contextBLL = new GiayBaoHiemThanXeBLL();
        }

        public void LoadDonVi()
        {
            _addEditGiayBaoHiemThanXeView.LoadDonVi(_contextBLL.GetDonVi());
        }

        public bool Save(giay_bao_hiem_than_xe entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string ma_giay)
        {
            return _contextBLL.HasExisted(ma_giay);
        }
    }
}
