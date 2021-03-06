using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL;
using VMS.DAL.Entity;

namespace VMS.BLL
{
    public class BienBanGiaoXeBLL : BaseData
    {
        private readonly BienBanGiaoXeData _dataContext;
        public BienBanGiaoXeBLL()
        {
            _dataContext = new BienBanGiaoXeData();
        }

        public List<bien_ban_giao_xe> GetAll(string ma_xe)
        {
            return _dataContext.GetAll(ma_xe);
        }

        public DataTable GetAllAsDataTable(string ma_xe)
        {
            return _dataContext.GetAllAsDataTable(ma_xe);
        }

        public bien_ban_giao_xe GetByXe(string ma_xe)
        {
            return _dataContext.GetByMaXe(ma_xe);
        }

        public bien_ban_giao_xe Get(string so_bien_ban)
        {
            return _dataContext.Get(so_bien_ban);
        }

        public DataTable GetDetailAsDataTable(string so_bien_ban)
        {
            return _dataContext.GetDetailAsDataTable(so_bien_ban);
        }

        public List<bien_ban_giao_xe_ct> GetDetail(string so_bien_ban)
        {
            return _dataContext.GetDetail(so_bien_ban);
        }

        public bool HasExisted(string so_bien_ban)
        {
            return _dataContext.HasExisted(so_bien_ban);
        }

        public bool Save(bien_ban_giao_xe entity, bool isNew)
        {
            return _dataContext.Save(entity, isNew);
        }

        public bool Delete(string so_bien_ban)
        {
            return _dataContext.Delete(so_bien_ban);
        }

        public bool SaveDetail(bien_ban_giao_xe_ct entity, bool isNew)
        {
            return _dataContext.SaveDetail(entity, isNew);
        }

        public bool DeleteDetail(string so_bien_ban, string ma_ccdc)
        {
            return _dataContext.DeleteDetail(so_bien_ban, ma_ccdc);
        }

        public bool HasDetailExisted(string so_bien_ban, string ma_ccdc)
        {
            return _dataContext.HasDetailExisted(so_bien_ban, ma_ccdc);
        }
    }
}
