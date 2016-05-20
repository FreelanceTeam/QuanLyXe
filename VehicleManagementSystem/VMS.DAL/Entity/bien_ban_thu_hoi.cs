using System;

namespace VMS.DAL.Entity
{
    public class bien_ban_thu_hoi
    {
        private string _so_bien_ban;
        private DateTime _ngay_bien_ban;
        private string _ma_xe;
        private string _ma_tai_xe;
        private string _ten_tai_xe;
        private DateTime _ngay_ket_thuc;
        private decimal _so_km_ket_thuc;
        private string _ly_do_thu_hoi;
        private string _ghi_chu;
        private DateTime _ngay_cap_nhat;
        private string _nguoi_cap_nhat;
        private DateTime _ngay_tao;
        private string _nguoi_tao;
        private string _status;

        public string so_bien_ban
        {
            get { return _so_bien_ban; }
            set { _so_bien_ban = value; }
        }

        public DateTime ngay_bien_ban
        {
            get { return _ngay_bien_ban; }
            set { _ngay_bien_ban = value; }
        }

        public string ngay_bien_ban_str
        {
            get { return _ngay_bien_ban.ToString("dd/MM/yyyy"); }
        }

        public string ma_xe
        {
            get { return _ma_xe; }
            set { _ma_xe = value; }
        }

        public string ma_tai_xe
        {
            get { return _ma_tai_xe; }
            set { _ma_tai_xe = value; }
        }

        public string ten_tai_xe
        {
            get { return _ten_tai_xe; }
            set { _ten_tai_xe = value; }
        }

        public DateTime ngay_ket_thuc
        {
            get { return _ngay_ket_thuc; }
            set { _ngay_ket_thuc = value; }
        }

        public string ngay_ket_thuc_str
        {
            get { return _ngay_ket_thuc.ToString("dd/MM/yyyy"); }
        }

        public decimal so_km_ket_thuc
        {
            get { return _so_km_ket_thuc; }
            set { _so_km_ket_thuc = value; }
        }

        public string ly_do_thu_hoi
        {
            get { return _ly_do_thu_hoi; }
            set { _ly_do_thu_hoi = value; }
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
    }
}
