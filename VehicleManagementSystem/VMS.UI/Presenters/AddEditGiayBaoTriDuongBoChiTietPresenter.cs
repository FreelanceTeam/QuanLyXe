using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayBaoTriDuongBoChiTietPresenter
    {
        private readonly IAddEditGiayBaoTriDuongBoChiTietView _addEditGiayBaoTriDuongBoChiTietView;
        private readonly GiayBaoTriDuongBoBLL _contextBLL;
        public bool IsNew = true;
        public giay_bao_tri_duong_bo_ct CurrentGiayBaoTriDuongBoChiTiet = null;
        public string MaGiay;
        public AddEditGiayBaoTriDuongBoChiTietPresenter(IAddEditGiayBaoTriDuongBoChiTietView addEditGiayBaoTriDuongBoChiTietView)
        {
            _addEditGiayBaoTriDuongBoChiTietView = addEditGiayBaoTriDuongBoChiTietView;
            _contextBLL = new GiayBaoTriDuongBoBLL();
        }

        public bool Save(giay_bao_tri_duong_bo_ct gdk)
        {
            return _contextBLL.SaveDetail(gdk, IsNew);
        }

        public bool CheckNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            return _contextBLL.HasNgayCapValid(ma_giay, ngay_cap);
        }

        public bool CheckNgayCapIfExisted(string ma_giay, DateTime ngay_cap)
        {
            return _contextBLL.HasNgayCapExisted(ma_giay, ngay_cap);
        }
    }
}
