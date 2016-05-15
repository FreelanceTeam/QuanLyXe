using System.Data;
using System.Drawing;
using VMS.DAL.Entity;

namespace VMS.UI.Interfaces
{
    public interface IMainView
    {
        void LoadVehiclesDataTable(DataTable dtTaiSanXe);
        void RefreshDataGrid(DataView dvTaiSanXe);
        void ShowImage(Image image);
        void LoadPhuTungDataTable(DataTable dtPhutung);
        void LoadGiayDangKy(giay_dang_ky gdk);
        void LoadGiayDangKiem(giay_dang_kiem gdk);
    }
}
