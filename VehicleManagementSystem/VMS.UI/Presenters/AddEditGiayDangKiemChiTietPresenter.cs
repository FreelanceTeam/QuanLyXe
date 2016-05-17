using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayDangKiemChiTietPresenter
    {
        private readonly IAddEditGiayDangKiemChiTietView _addEditGiayDangKiemChiTietView;
        private readonly GiayDangKiemBLL _contextBLL;
        public bool IsNew = true;
        public giay_dang_kiem_ct CurrentGiayDangKiemChiTiet = null;
        public string MaGiay;
        public AddEditGiayDangKiemChiTietPresenter(IAddEditGiayDangKiemChiTietView addEditGiayDangKiemChiTietView)
        {
            _addEditGiayDangKiemChiTietView = addEditGiayDangKiemChiTietView;
            _contextBLL = new GiayDangKiemBLL();
        }

        public bool Save(giay_dang_kiem_ct entity)
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
