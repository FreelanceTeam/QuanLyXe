using System;
using System.Collections.Generic;

namespace VMS.DAL.Entity
{
    public class lich_su_tai_xe
    {
        private string _ma_xe;
        private string _ma_tai_xe;
        private string _ten_tai_xe;        
        private decimal _so_km_bat_dau;
		private DateTime? _ngay_bat_dau;
		private decimal _so_km_ket_thuc;
		private DateTime? _ngay_ket_thuc;		
		private string _trang_thai;
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

        public DateTime? ngay_bat_dau
        {
            get { return _ngay_bat_dau; }
            set { _ngay_bat_dau = value; }
        }
		
		public string ngay_bat_dau_str
        {
            get
            {
                if (_ngay_bat_dau.HasValue)
                {
                    return _ngay_bat_dau.Value.ToString("dd/MM/yyyy");
                }
                return string.Empty;
            }
        }

        public decimal so_km_bat_dau
        {
            get { return _so_km_bat_dau; }
            set { _so_km_bat_dau = value; }
        }
		
		public DateTime? ngay_ket_thuc
        {
            get { return _ngay_ket_thuc; }
            set { _ngay_ket_thuc = value; }
        }
		
		public string ngay_ket_thuc_str
        {
            get
            {
                if (_ngay_ket_thuc.HasValue)
                {
                    return _ngay_ket_thuc.Value.ToString("dd/MM/yyyy");
                }
                return string.Empty;
            }
        }

        public decimal so_km_ket_thuc
        {
            get { return _so_km_ket_thuc; }
            set { _so_km_ket_thuc = value; }
        }

        public string trang_thai
        {
            get { return _trang_thai; }
            set { _trang_thai = value; }
        }
		
		public bool trang_thai_bool
        {
            get { return _trang_thai == "Y"; }
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
    }
}
