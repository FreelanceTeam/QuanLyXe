using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKyChiTietPresenter
    {
        private readonly IAddEditGiayDangKyChiTietView _addEditGiayDangKyChiTietView;
        private readonly GiayDangKyBLL _contextBLL;
        public bool IsNew = true;
        public giay_dang_ky_ct CurrentGiayDangKyChiTiet = null;
        public string MaGiay;
        public AddEditGiayDangKyChiTietPresenter(IAddEditGiayDangKyChiTietView addEditGiayDangKyChiTietView)
        {
            _addEditGiayDangKyChiTietView = addEditGiayDangKyChiTietView;
            _contextBLL = new GiayDangKyBLL();
        }

        public bool Save(giay_dang_ky_ct entity)
        {
            return _contextBLL.SaveDetail(entity, IsNew);
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
