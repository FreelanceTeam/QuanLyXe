using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayBaoTriDuongBoPresenter
    {
        private readonly IAddEditGiayBaoTriDuongBoView _view;
        private readonly GiayBaoTriDuongBoBLL _contextBLL;
        public bool IsNew = true;
        public giay_bao_tri_duong_bo CurrentGiayBaoTriDuongBo = null;
        public string MaXe;
        public AddEditGiayBaoTriDuongBoPresenter(IAddEditGiayBaoTriDuongBoView view)
        {
            _view = view;
            _contextBLL = new GiayBaoTriDuongBoBLL();
        }

        public void LoadDonVi()
        {
            _view.LoadDonVi(_contextBLL.GetDonVi());
        }

        public bool Save(giay_bao_tri_duong_bo entity)
        {
            return _contextBLL.Save(entity, IsNew);
        }

        public bool CheckIfExisted(string ma_giay)
        {
            return _contextBLL.HasExisted(ma_giay);
        }
    }
}
