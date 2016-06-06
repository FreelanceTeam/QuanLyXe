using System;
using System.Collections.Generic;

namespace VMS.DAL.Entity
{
    public class tai_san_xe
    {
        private string _ma_xe;
        private string _bien_so;
        private string _hang_san_xuat;
        private string _loai_xe;
        private string _ma_lts;
        private string _ten_lts;
        private short _nam_san_xuat;
        private byte _so_nam_su_dung;
        private string _so_may;
        private string _so_khung;
        private string _mau;
        private string _binh_nhien_lieu;
        private string _loai_nhien_lieu;
        private decimal _trong_tai_the_tich;
        private decimal _trong_tai_khoi_luong;
        private decimal _tong_trong_luong;
        private decimal _nguyen_gia;
        private decimal _gia_tri_khau_hao;
        private decimal _ti_le_khau_hao;
        private decimal _gia_tri_con_lai;
        private byte[] _hinh_anh;
        private string _ghi_chu;
        private DateTime _ngay_cap_nhat;
        private string _nguoi_cap_nhat;
        private DateTime _ngay_tao;
        private string _nguoi_tao;
        private string _status;

        public string ma_xe
        {
            get { return _ma_xe; }
            set { _ma_xe = value; }
        }

        public string bien_so
        {
            get { return _bien_so; }
            set { _bien_so = value; }
        }

        public string hang_san_xuat
        {
            get { return _hang_san_xuat; }
            set { _hang_san_xuat = value; }
        }

        public string loai_xe
        {
            get { return _loai_xe; }
            set { _loai_xe = value; }
        }

        public string ma_lts
        {
            get { return _ma_lts; }
            set { _ma_lts = value; }
        }

        public string ten_lts
        {
            get { return _ten_lts; }
            set { _ten_lts = value; }
        }

        public short nam_san_xuat
        {
            get { return _nam_san_xuat; }
            set { _nam_san_xuat = value; }
        }

        public byte so_nam_su_dung
        {
            get { return _so_nam_su_dung; }
            set { _so_nam_su_dung = value; }
        }

        public string so_may
        {
            get { return _so_may; }
            set { _so_may = value; }
        }

        public string so_khung
        {
            get { return _so_khung; }
            set { _so_khung = value; }
        }

        public string mau
        {
            get { return _mau; }
            set { _mau = value; }
        }

        public string binh_nhien_lieu
        {
            get { return _binh_nhien_lieu; }
            set { _binh_nhien_lieu = value; }
        }

        public string loai_nhien_lieu
        {
            get { return _loai_nhien_lieu; }
            set { _loai_nhien_lieu = value; }
        }

        public decimal trong_tai_the_tich
        {
            get { return _trong_tai_the_tich; }
            set { _trong_tai_the_tich = value; }
        }

        public decimal trong_tai_khoi_luong
        {
            get { return _trong_tai_khoi_luong; }
            set { _trong_tai_khoi_luong = value; }
        }
        public decimal tong_trong_luong
        {
            get { return _tong_trong_luong; }
            set { _tong_trong_luong = value; }
        }

        public decimal nguyen_gia
        {
            get { return _nguyen_gia; }
            set { _nguyen_gia = value; }
        }

        public decimal gia_tri_khau_hao
        {
            get { return _gia_tri_khau_hao; }
            set { _gia_tri_khau_hao = value; }
        }

        public decimal ti_le_khau_hao
        {
            get { return _ti_le_khau_hao; }
            set { _ti_le_khau_hao = value; }
        }

        public decimal gia_tri_con_lai
        {
            get { return _gia_tri_con_lai; }
            set { _gia_tri_con_lai = value; }
        }

        public byte[] hinh_anh
        {
            get { return _hinh_anh; }
            set { _hinh_anh = value; }
        }

        public string ghi_chu
        {
            get { return _ghi_chu; }
            set { _ghi_chu = value; }
        }

        public DateTime ngay_cap_nhat
        {
            get { return _ngay_cap_nhat; }
            set { _ngay_cap_nhat = value; }
        }

        public string nguoi_cap_nhat
        {
            get { return _nguoi_cap_nhat; }
            set { _nguoi_cap_nhat = value; }
        }

        public DateTime ngay_tao
        {
            get { return _ngay_tao; }
            set { _ngay_tao = value; }
        }

        public string nguoi_tao
        {
            get { return _nguoi_tao; }
            set { _nguoi_tao = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        private giay_dang_ky _giayDangKy;
        public giay_dang_ky GiayDangKy
        {
            get { return _giayDangKy; }
            set { _giayDangKy = value; }
        }

        private giay_dang_kiem _giayDangKiem;
        public giay_dang_kiem GiayDangKiem
        {
            get { return _giayDangKiem; }
            set { _giayDangKiem = value; }
        }


        private giay_bao_tri_duong_bo _giayBaoTriDuongBo;
        public giay_bao_tri_duong_bo GiayBaoTriDuongBo
        {
            get { return _giayBaoTriDuongBo; }
            set { _giayBaoTriDuongBo = value; }
        }

        private giay_bao_hiem_nhan_su _giayBaoHiemNhanSu;
        public giay_bao_hiem_nhan_su GiayBaoHiemNhanSu
        {
            get { return _giayBaoHiemNhanSu; }
            set { _giayBaoHiemNhanSu = value; }
        }

        private giay_bao_hiem_than_xe _giayBaoHiemThanXe;
        public giay_bao_hiem_than_xe GiayBaoHiemThanXe
        {
            get { return _giayBaoHiemThanXe; }
            set { _giayBaoHiemThanXe = value; }
        }

        private bien_ban_giao_xe _bienBanGiaoXe;
        public bien_ban_giao_xe BienBanGiaoXe
        {
            get { return _bienBanGiaoXe; }
            set { _bienBanGiaoXe = value; }
        }

        private bien_ban_thu_hoi _bienBanThuHoi;
        public bien_ban_thu_hoi BienBanThuHoi
        {
            get { return _bienBanThuHoi; }
            set { _bienBanThuHoi = value; }
        }

        private List<lich_su_tai_xe> _taiXeList;
        public List<lich_su_tai_xe> TaiXeList
        {
            get { return _taiXeList; }
            set { _taiXeList = value; }
        }
    }
}
