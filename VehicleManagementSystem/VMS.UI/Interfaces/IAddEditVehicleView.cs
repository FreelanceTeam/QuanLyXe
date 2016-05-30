using System.Collections.Generic;
using System.Data;

namespace VMS.UI.Interfaces
{
    public interface IAddEditVehicleView
    {
        void LoadLoaiTaiSanXe(DataTable dt);
        void LoadHangXe(List<string> list);
        void LoadLoaiXe(List<string> list);
        void LoadMauXe(List<string> list);
    }
}
