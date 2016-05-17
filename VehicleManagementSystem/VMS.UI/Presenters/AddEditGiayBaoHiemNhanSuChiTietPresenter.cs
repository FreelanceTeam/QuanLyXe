using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayBaoHiemNhanSuChiTietPresenter
    {
        private readonly IAddEditGiayBaoHiemNhanSuChiTietView _addEditGiayBaoHiemNhanSuChiTietView;
        private readonly GiayBaoHiemNhanSuBLL _contextBLL;
        public bool IsNew = true;
        public giay_bao_hiem_nhan_su_ct CurrentGiayBaoHiemNhanSuChiTiet = null;
        public string MaGiay;
        public AddEditGiayBaoHiemNhanSuChiTietPresenter(IAddEditGiayBaoHiemNhanSuChiTietView addEditGiayBaoHiemNhanSuChiTietView)
        {
            _addEditGiayBaoHiemNhanSuChiTietView = addEditGiayBaoHiemNhanSuChiTietView;
            _contextBLL = new GiayBaoHiemNhanSuBLL();
        }

        public bool Save(giay_bao_hiem_nhan_su_ct gdk)
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
