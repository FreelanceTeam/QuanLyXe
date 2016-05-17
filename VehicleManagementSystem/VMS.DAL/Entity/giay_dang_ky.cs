using System;
using System.Collections.Generic;

namespace VMS.DAL.Entity
{
    public class giay_dang_ky
    {
        private string _ma_giay;
        private string _ma_xe;        
        private string _don_vi;
        private string _ten_don_vi;
        private DateTime? _ngay_cap_lan_dau;
        private decimal _nhac_nho_truoc_ngay;
        private byte[] _hinh_anh;
        private string _ghi_chu;
        private DateTime _ngay_cap_nhat;
        private string _nguoi_cap_nhat;
        private DateTime _ngay_tao;
        private string _nguoi_tao;
        private string _status;
        private List<giay_dang_ky_ct> _detailList;

        public string ma_giay
        {
            get { return _ma_giay; }
            set { _ma_giay = value; }
        }

        public string ma_xe
        {
            get { return _ma_xe; }
            set { _ma_xe = value; }
        }

        public string don_vi
        {
            get { return _don_vi; }
            set { _don_vi = value; }
        }

        public string ten_don_vi
        {
            get { return _ten_don_vi; }
            set { _ten_don_vi = value; }
        }

        public DateTime? ngay_cap_lan_dau
        {
            get { return _ngay_cap_lan_dau; }
            set { _ngay_cap_lan_dau = value; }
        }

        public decimal nhac_nho_truoc_ngay
        {
            get { return _nhac_nho_truoc_ngay; }
            set { _nhac_nho_truoc_ngay = value; }
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

        public List<giay_dang_ky_ct> DetailList
        {
            get { return _detailList; }
            set { _detailList = value; }
        }
    }
}
