using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VMS.DAL.Entity;

namespace VMS.UI.Interfaces
{
    public interface IMainView
    {
        void LoadVehiclesDataTable(DataTable dt);
        void RefreshDataGrid(DataView dv);
        void SetupImageViewer(PictureBox pictureBox);
        void LoadPhuTungDataTable(DataTable dt);
        void LoadGiayDangKy(giay_dang_ky entity);
        void LoadGiayDangKiem(giay_dang_kiem entity);
        void LoadGiayBaoTriDuongBo(giay_bao_tri_duong_bo entity);
        void LoadGiayBaoHiemNhanSu(giay_bao_hiem_nhan_su entity);
        void LoadGiayBaoHiemThanXe(giay_bao_hiem_than_xe entity);
        void LoadBienBanGiaoXe(bien_ban_giao_xe entity);
        void LoadBienBanThuHoiDataTable(DataTable dt);
    }
}
