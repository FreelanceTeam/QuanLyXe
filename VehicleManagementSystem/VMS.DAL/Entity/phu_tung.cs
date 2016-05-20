namespace VMS.DAL.Entity
{
    public class phu_tung
    {
        private string _ma_xe;
        private string _ma_tai_san;
        private string _ten_tai_san;
        private byte _so_luong;
        private decimal _so_km_da_su_dung;
        private byte _tinh_trang;

        public string ma_xe
        {
            get { return _ma_xe; }
            set { _ma_xe = value; }
        }

        public string ma_tai_san
        {
            get { return _ma_tai_san; }
            set { _ma_tai_san = value; }
        }

        public string ten_tai_san
        {
            get { return _ten_tai_san; }
            set { _ten_tai_san = value; }
        }

        public byte so_luong
        {
            get { return _so_luong; }
            set { _so_luong = value; }
        }

        public decimal so_km_da_su_dung
        {
            get { return _so_km_da_su_dung; }
            set { _so_km_da_su_dung = value; }
        }

        public byte tinh_trang
        {
            get { return _tinh_trang; }
            set { _tinh_trang = value; }
        }

        public bool tinh_trang_bool
        {
            get { return _tinh_trang == 1; }
        }
    }
}
