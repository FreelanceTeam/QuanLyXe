using System;
using VMS.BLL;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;

namespace VMS.UI.Presenters
{
    public class AddEditGiayBaoHiemThanXeChiTietPresenter
    {
        private readonly IAddEditGiayBaoHiemThanXeChiTietView _addEditGiayBaoHiemThanXeChiTietView;
        private readonly GiayBaoHiemThanXeBLL _contextBLL;
        public bool IsNew = true;
        public giay_bao_hiem_than_xe_ct CurrentGiayBaoHiemThanXeChiTiet = null;
        public string MaGiay;
        public AddEditGiayBaoHiemThanXeChiTietPresenter(IAddEditGiayBaoHiemThanXeChiTietView addEditGiayBaoHiemThanXeChiTietView)
        {
            _addEditGiayBaoHiemThanXeChiTietView = addEditGiayBaoHiemThanXeChiTietView;
            _contextBLL = new GiayBaoHiemThanXeBLL();
        }

        public bool Save(giay_bao_hiem_than_xe_ct gdk)
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
