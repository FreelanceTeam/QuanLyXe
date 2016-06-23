using System;
using System.Collections.Generic;

namespace VMS.DAL.Entity
{
    public class lich_su_khau_hao
    {
        private string _ma_xe;
		private DateTime _ngay_hieu_luc;
        private decimal _nguyen_gia;
		private decimal _gia_tri_khau_hao;
        private decimal _ti_le_khau_hao;
        private decimal _gia_tri_con_lai;
        private decimal _gia_tri_trich_kh_nam;
        private decimal _gia_tri_trich_kh_thang;
        private short _so_thang_da_trich_kh;
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

        public DateTime ngay_hieu_luc
        {
            get { return _ngay_hieu_luc; }
            set { _ngay_hieu_luc = value; }
        }
		
		public string ngay_hieu_luc_str
        {
            get
            {
                return _ngay_hieu_luc.ToString("dd/MM/yyyy");
            }
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

        public decimal gia_tri_trich_kh_nam
        {
            get { return _gia_tri_trich_kh_nam; }
            set { _gia_tri_trich_kh_nam = value; }
        }

        public decimal gia_tri_trich_kh_thang
        {
            get { return _gia_tri_trich_kh_thang; }
            set { _gia_tri_trich_kh_thang = value; }
        }

        public short so_thang_da_trich_kh
        {
            get { return _so_thang_da_trich_kh; }
            set { _so_thang_da_trich_kh = value; }
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
