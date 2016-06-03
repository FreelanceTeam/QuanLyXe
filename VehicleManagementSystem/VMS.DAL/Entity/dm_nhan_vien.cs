using System;

namespace VMS.DAL.Entity
{
    public class dm_nhan_vien
    {
        private string _ma_nv;
        private string _ten_nv;
        private string _dia_chi;
        private string _dien_thoai;
        private string _chuc_vu;
        private string _ma_bp;
		private string _ten_bp;
		private string _ma_lnv;		
        private string _so_cmnd;
        private string _noi_cap;
        private DateTime? _ngay_cap;
        private string _so_gplx;
        private DateTime? _ngay_cap_gplx;		
        private decimal _luong_co_ban;
        private decimal _luong_thu_viec;
        private decimal _luong_chuyen_can;
        private decimal _luong_bao_hiem;
        private decimal _phan_tram_bao_hiem;
        private decimal _phan_tram_dn;		
        private byte[] _hinh_anh;
		private short _tinh_trang_work;		
		private DateTime? _ngay_lam_viec;
		private DateTime? _ngay_nghi_viec;
        private DateTime _ngay_cap_nhat;
        private string _nguoi_cap_nhat;
        private DateTime _ngay_tao;
        private string _nguoi_tao;
        private string _status;

        public string ma_nv
        {
            get { return _ma_nv; }
            set { _ma_nv = value; }
        }

        public string ten_nv
        {
            get { return _ten_nv; }
            set { _ten_nv = value; }
        }

        public string dia_chi
        {
            get { return _dia_chi; }
            set { _dia_chi = value; }
        }

        public string dien_thoai
        {
            get { return _dien_thoai; }
            set { _dien_thoai = value; }
        }

        public string chuc_vu
        {
            get { return _chuc_vu; }
            set { _chuc_vu = value; }
        }

        public string ma_bp
        {
            get { return _ma_bp; }
            set { _ma_bp = value; }
        }
		
		public string ten_bp
        {
            get { return _ten_bp; }
            set { _ten_bp = value; }
        }
		
		public string ma_lnv
        {
            get { return _ma_lnv; }
            set { _ma_lnv = value; }
        }

        public string so_cmnd
        {
            get { return _so_cmnd; }
            set { _so_cmnd = value; }
        }

        public string noi_cap
        {
            get { return _noi_cap; }
            set { _noi_cap = value; }
        }

        public DateTime? ngay_cap
        {
            get { return _ngay_cap; }
            set { _ngay_cap = value; }
        }

        public string ngay_cap_str
        {
            get
            {
                if (_ngay_cap.HasValue)
                {
                    return _ngay_cap.Value.ToString("dd/MM/yyyy");
                }
                return string.Empty;
            }
        }

        public string so_gplx
        {
            get { return _so_gplx; }
            set { _so_gplx = value; }
        }

        public DateTime? ngay_cap_gplx
        {
            get { return _ngay_cap_gplx; }
            set { _ngay_cap_gplx = value; }
        }

        public string ngay_cap_gplx_str
        {
            get 
            {
                if (_ngay_cap_gplx.HasValue)
                {
                    return _ngay_cap_gplx.Value.ToString("dd/MM/yyyy"); 
                }
                return string.Empty;
            }
        }

        public decimal luong_co_ban
        {
            get { return _luong_co_ban; }
            set { _luong_co_ban = value; }
        }
        public string luong_co_ban_str
        {
            get { return _luong_co_ban.ToString("N0"); }
        }

        public decimal luong_thu_viec
        {
            get { return _luong_thu_viec; }
            set { _luong_thu_viec = value; }
        }
        public string luong_thu_viec_str
        {
            get { return _luong_thu_viec.ToString("N0"); }
        }

        public decimal luong_chuyen_can
        {
            get { return _luong_chuyen_can; }
            set { _luong_chuyen_can = value; }
        }
        public string luong_chuyen_can_str
        {
            get { return _luong_chuyen_can.ToString("N0"); }
        }

        public decimal luong_bao_hiem
        {
            get { return _luong_bao_hiem; }
            set { _luong_bao_hiem = value; }
        }
        public string luong_bao_hiem_str
        {
            get { return _luong_bao_hiem.ToString("N0"); }
        }

        public decimal phan_tram_bao_hiem
        {
            get { return _phan_tram_bao_hiem; }
            set { _phan_tram_bao_hiem = value; }
        }

        public decimal phan_tram_dn
        {
            get { return _phan_tram_dn; }
            set { _phan_tram_dn = value; }
        }

        public byte[] hinh_anh
        {
            get { return _hinh_anh; }
            set { _hinh_anh = value; }
        }

        public short tinh_trang_work
        {
            get { return _tinh_trang_work; }
            set { _tinh_trang_work = value; }
        }

        public bool tinh_trang_work_bool
        {
            get { return _tinh_trang_work == 1; }
        }
		
		public DateTime? ngay_lam_viec
        {
            get { return _ngay_lam_viec; }
            set { _ngay_lam_viec = value; }
        }

        public string ngay_lam_viec_str
        {
            get
            {
                if (_ngay_lam_viec.HasValue)
                {
                    return _ngay_lam_viec.Value.ToString("dd/MM/yyyy");
                }
                return string.Empty;
            }
        }
		
		public DateTime? ngay_nghi_viec
        {
            get { return _ngay_nghi_viec; }
            set { _ngay_nghi_viec = value; }
        }

        public string ngay_nghi_viec_str
        {
            get
            {
                if (_ngay_nghi_viec.HasValue)
                {
                    return _ngay_nghi_viec.Value.ToString("dd/MM/yyyy");
                }
                return string.Empty;
            }
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
    }
}
