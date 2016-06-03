namespace VMS.DAL.Entity
{
    public class phu_tung
    {
        private string _ma_xe;
        private string _ma_tai_san;
        private string _ten_tai_san;
        private byte _so_luong;
        private decimal _so_km_da_su_dung;
        private byte _trang_thai;

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

        public byte trang_thai
        {
            get { return _trang_thai; }
            set { _trang_thai = value; }
        }

        public bool trang_thai_bool
        {
            get { return _trang_thai == 1; }
        }
    }
}
