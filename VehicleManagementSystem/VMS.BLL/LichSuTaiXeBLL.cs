using System.Collections.Generic;
using System.Data;
using VMS.DAL;
using VMS.DAL.Entity;

namespace VMS.BLL
{
    public class LichSuTaiXeBLL : BaseBLL
    {
        private readonly LichSuTaiXeData _dataContext;

        public LichSuTaiXeBLL()
        {
            _dataContext = new LichSuTaiXeData();
        }
		
        public DataTable GetAllAsDataTable(string ma_xe)
        {
            return _dataContext.GetAllAsDataTable(ma_xe);
        }
		
		public List<lich_su_tai_xe> GetAll(string ma_xe)
        {
            return _dataContext.GetAll(ma_xe);
        }

        public lich_su_tai_xe Get(string ma_xe, string ma_tai_san)
        {
            return _dataContext.Get(ma_xe, ma_tai_san);
        }

        public bool HasExisted(string ma_xe, string ma_tai_san)
        {
            return _dataContext.HasExisted(ma_xe, ma_tai_san);
        }

        public bool Save(lich_su_tai_xe entity, bool isNew)
        {
            return _dataContext.Save(entity, isNew);
        }

        public bool Delete(string ma_xe, string ma_tai_san)
        {
            return _dataContext.Delete(ma_xe, ma_tai_san);
        }       
    }
}
