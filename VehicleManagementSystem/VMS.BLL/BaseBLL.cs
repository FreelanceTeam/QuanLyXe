using System.Data;
using VMS.DAL;

namespace VMS.BLL
{
    public class BaseBLL
    {
        private readonly BaseData _baseData;

        public BaseBLL()
        {
            _baseData = new BaseData();
        }

        public DataTable GetLoaiTaiSanXe()
        {
            return _baseData.GetLoaiTaiSanXe();
        }

        public DataTable GetTaiSanMMTB()
        {
            return _baseData.GetTaiSanMMTB();
        }

        public DataTable GetDonVi()
        {
            return _baseData.GetDonVi();
        }

        public DataTable GetTaiXe()
        {
            return _baseData.GetTaiXe();
        }

        public DataTable GetCCDC()
        {
            return _baseData.GetCCDC();
        }
    }
}
