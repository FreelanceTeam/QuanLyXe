using System.Data;
using VMS.DAL;
using VMS.DAL.Entity;

namespace VMS.BLL
{
    public class PhuTungBLL : BaseBLL
    {
        private readonly PhuTungData _dataContext;

        public PhuTungBLL()
        {
            _dataContext = new PhuTungData();
        }
		
        public DataTable GetAllAsDataTable(string ma_xe)
        {
            return _dataContext.GetAllAsDataTable(ma_xe);
        }

        public phu_tung Get(string ma_xe, string ma_tai_san)
        {
            return _dataContext.Get(ma_xe, ma_tai_san);
        }

        public bool HasExisted(string ma_xe, string ma_tai_san)
        {
            return _dataContext.HasExisted(ma_xe, ma_tai_san);
        }

        public bool Save(phu_tung phuTung, bool isNew)
        {
            return _dataContext.Save(phuTung, isNew);
        }

        public bool Delete(string ma_xe, string ma_tai_san)
        {
            return _dataContext.Delete(ma_xe, ma_tai_san);
        }       
    }
}
