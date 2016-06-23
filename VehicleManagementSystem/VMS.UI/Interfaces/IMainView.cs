using System.Collections.Generic;
using System.Data;
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
        void LoadBienBanThuHoi(List<bien_ban_thu_hoi> list);
        void LoadLichSuTaiXe(List<lich_su_tai_xe> list);
        void LoadLichSuKhauHao(List<lich_su_khau_hao> list, lich_su_khau_hao current);
    }
}
