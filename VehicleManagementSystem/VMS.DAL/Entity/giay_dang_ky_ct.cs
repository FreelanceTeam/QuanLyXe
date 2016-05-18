using System;

namespace VMS.DAL.Entity
{
    public class giay_dang_ky_ct
    {
        private string _ma_giay;
        private DateTime _ngay_cap;
        private DateTime _ngay_het_han;
        private string _ghi_chu;
        private DateTime _ngay_cap_nhat;
        private string _nguoi_cap_nhat;
        private string _trang_thai;

        public string ma_giay
        {
            get { return _ma_giay; }
            set { _ma_giay = value; }
        }

        public DateTime ngay_cap
        {
            get { return _ngay_cap; }
            set { _ngay_cap= value; }
        }

        public DateTime ngay_het_han
        {
            get { return _ngay_het_han; }
            set { _ngay_het_han = value; }
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

        public string trang_thai
        {
            get { return _trang_thai; }
            set { _trang_thai = value; }
        }

        public bool trang_thai_bool
        {
            get { return _trang_thai == "1"; }
        }

        public string ngay_cap_str
        {
            get { return _ngay_cap.ToString("dd/MM/yyyy"); }
        }

        public string ngay_het_han_str
        {
            get { return _ngay_het_han.ToString("dd/MM/yyyy"); }
        }
    }
}
