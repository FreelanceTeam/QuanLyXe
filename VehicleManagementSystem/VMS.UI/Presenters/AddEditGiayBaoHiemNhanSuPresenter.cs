using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayBaoHiemNhanSuPresenter
    {
        private readonly IAddEditGiayBaoHiemNhanSuView _view;
        private readonly GiayBaoHiemNhanSuBLL _contextBLL;
        public bool IsNew = true;
        public giay_bao_hiem_nhan_su CurrentGiayBaoHiemNhanSu = null;
        public string MaXe;
        public AddEditGiayBaoHiemNhanSuPresenter(IAddEditGiayBaoHiemNhanSuView view)
        {
            _view = view;
            _contextBLL = new GiayBaoHiemNhanSuBLL();
        }

        public void LoadDonVi()
        {
            _view.LoadDonVi(_contextBLL.GetDonVi());
        }

        public bool Save(giay_bao_hiem_nhan_su entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string ma_giay)
        {
            return _contextBLL.HasExisted(ma_giay);
        }
    }
}
