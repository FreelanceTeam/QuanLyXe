using System;
using System.Collections.Generic;

namespace VMS.DAL.Entity
{
    public class bien_ban_giao_xe
    {
        private string _so_bien_ban;
        private DateTime _ngay_bien_ban;
        private string _ma_xe;
        private string _ma_tai_xe;
        private string _ten_tai_xe;
        private DateTime _ngay_nhan_xe;
        private decimal _so_km_bat_dau;
        private string _ghi_chu;
        private DateTime _ngay_cap_nhat;
        private string _nguoi_cap_nhat;
        private DateTime _ngay_tao;
        private string _nguoi_tao;
        private string _status;
        private List<bien_ban_giao_xe_ct> _detailList;
        private bool _isHistory = false;

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

        public DateTime ngay_nhan_xe
        {
            get { return _ngay_nhan_xe; }
            set { _ngay_nhan_xe = value; }
        }

        public string ngay_nhan_xe_str
        {
            get { return _ngay_nhan_xe.ToString("dd/MM/yyyy"); }
        }

        public decimal so_km_bat_dau
        {
            get { return _so_km_bat_dau; }
            set { _so_km_bat_dau = value; }
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

        public bool status_bool
        {
            get { return _status == "Y"; }
        }

        public List<bien_ban_giao_xe_ct> DetailList
        {
            get { return _detailList; }
            set { _detailList = value; }
        }

        public bool IsHistory
        {
            get { return _isHistory; }
            set { _isHistory = value; }
        }
    }
}
