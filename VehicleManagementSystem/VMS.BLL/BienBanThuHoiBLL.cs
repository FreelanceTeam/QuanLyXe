using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VMS.DAL;
using VMS.DAL.Entity;

namespace VMS.BLL
{
    public class BienBanThuHoiBLL : BaseData
    {
        private readonly BienBanThuHoiData _dataContext;
        public BienBanThuHoiBLL()
        {
            _dataContext = new BienBanThuHoiData();
        }

        public DataTable GetAllAsDataTable(string ma_xe)
        {
            return _dataContext.GetAllAsDataTable(ma_xe);
        }

        public List<bien_ban_thu_hoi> GetAll(string ma_xe)
        {
            return _dataContext.GetAll(ma_xe);
        }

        public bien_ban_thu_hoi GetByMaXe(string ma_xe)
        {
            return _dataContext.GetByMaXe(ma_xe);
        }

        public bien_ban_thu_hoi Get(string so_bien_ban)
        {
            return _dataContext.Get(so_bien_ban);
        }

        public bool HasExisted(string so_bien_ban)
        {
            return _dataContext.HasExisted(so_bien_ban);
        }

        public bool Save(bien_ban_thu_hoi entity, bool isNew)
        {
            return _dataContext.Save(entity, isNew);
        }

        public bool Delete(string so_bien_ban)
        {
            return _dataContext.Delete(so_bien_ban);
        }
    }
}
