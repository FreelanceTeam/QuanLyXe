namespace VMS.DAL.Entity
{
    public class bien_ban_giao_xe_ct
    {
        private string _so_bien_ban;
        private string _ma_ccdc;
        private string _ten_ccdc;
        private byte _so_luong;
        private decimal _so_km_da_su_dung;
        private byte _tinh_trang;

        public string so_bien_ban
        {
            get { return _so_bien_ban; }
            set { _so_bien_ban = value; }
        }

        public string ma_ccdc
        {
            get { return _ma_ccdc; }
            set { _ma_ccdc = value; }
        }

        public string ten_ccdc
        {
            get { return _ten_ccdc; }
            set { _ten_ccdc = value; }
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
    }
}
