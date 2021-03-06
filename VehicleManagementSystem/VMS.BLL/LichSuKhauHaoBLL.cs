using System;
using System.Collections.Generic;
using System.Data;
using VMS.DAL;
using VMS.DAL.Entity;

namespace VMS.BLL
{
    public class LichSuKhauHaoBLL : BaseBLL
    {
        private readonly LichSuKhauHaoData _dataContext;

        public LichSuKhauHaoBLL()
        {
            _dataContext = new LichSuKhauHaoData();
        }
		
        public DataTable GetAllAsDataTable(string ma_xe)
        {
            return _dataContext.GetAllAsDataTable(ma_xe);
        }
		
		public List<lich_su_khau_hao> GetAll(string ma_xe)
        {
            return _dataContext.GetAll(ma_xe);
        }

        public lich_su_khau_hao Get(string ma_xe, DateTime ngay_hieu_luc)
        {
            return _dataContext.Get(ma_xe, ngay_hieu_luc);
        }

        public lich_su_khau_hao GetLatest(string ma_xe)
        {
            return _dataContext.GetLatest(ma_xe);
        }

        public bool HasExisted(string ma_xe, DateTime ngay_hieu_luc)
        {
            return _dataContext.HasExisted(ma_xe, ngay_hieu_luc);
        }

        public bool IsInitKhauHao(string ma_xe, DateTime ngay_hieu_luc)
        {
            return _dataContext.IsInitKhauHao(ma_xe, ngay_hieu_luc);
        }

        public bool Save(lich_su_khau_hao entity)
        {
            return _dataContext.Save(entity);
        }

        public bool Delete(string ma_xe, DateTime ngay_hieu_luc)
        {
            return _dataContext.Delete(ma_xe, ngay_hieu_luc);
        }

        public string TinhKhauHaoXe()
        {
            return _dataContext.TinhKhauHaoXe();
        }    
    }
}
