using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL;
using VMS.DAL.Entity;

namespace VMS.BLL
{
    public class GiayBaoHiemNhanSuBLL : BaseData
    {
        private readonly GiayBaoHiemNhanSuData _dataContext;
        public GiayBaoHiemNhanSuBLL()
        {
            _dataContext = new GiayBaoHiemNhanSuData();
        }
		
        public giay_bao_hiem_nhan_su GetByMaXe(string ma_xe)
        {
            return _dataContext.GetByMaXe(ma_xe);
        }

        public giay_bao_hiem_nhan_su Get(string ma_giay)
        {
            return _dataContext.Get(ma_giay);
        }

        public DataTable GetDetailAsDataTable(string ma_giay)
        {
            return _dataContext.GetDetailAsDataTable(ma_giay);
        }

        public List<giay_bao_hiem_nhan_su_ct> GetDetail(string ma_giay)
        {
            return _dataContext.GetDetail(ma_giay);
        }

        public bool HasExisted(string ma_giay)
        {
            return _dataContext.HasExisted(ma_giay);
        }

        public bool Save(giay_bao_hiem_nhan_su entity, bool isNew)
        {
            return _dataContext.Save(entity, isNew);
        }

        public bool Delete(string ma_giay)
        {
            return _dataContext.Delete(ma_giay);
        }

        public bool SaveDetail(giay_bao_hiem_nhan_su_ct entity, bool isNew)
        {
            return _dataContext.SaveDetail(entity, isNew);
        }

        public bool DeleteDetail(string ma_giay, DateTime ngay_cap)
        {
            return _dataContext.DeleteDetail(ma_giay, ngay_cap);
        }

        public bool HasNgayCapExisted(string ma_giay, DateTime ngay_cap)
        {
            return _dataContext.HasNgayCapExisted(ma_giay, ngay_cap);
        }

        public bool HasNgayCapValid(string ma_giay, DateTime ngay_cap)
        {
            return _dataContext.HasNgayCapValid(ma_giay, ngay_cap);
        }
    }
}
