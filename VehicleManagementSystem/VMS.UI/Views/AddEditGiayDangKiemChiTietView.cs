using System;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditGiayDangKiemChiTietView : Form, IAddEditGiayDangKiemChiTietView
    {
        private readonly AddEditGiayDangKiemChiTietPresenter _addEditGiayDangKiemChiTietPresenter;
        public AddEditGiayDangKiemChiTietView(string ma_giay)
        {
            InitializeComponent();
            _addEditGiayDangKiemChiTietPresenter = new AddEditGiayDangKiemChiTietPresenter(this);
            _addEditGiayDangKiemChiTietPresenter.MaGiay = ma_giay;
        }

        public AddEditGiayDangKiemChiTietView(giay_dang_kiem_ct gdk)
            : this(gdk.ma_giay)
        {
            _addEditGiayDangKiemChiTietPresenter.IsNew = false;
            _addEditGiayDangKiemChiTietPresenter.CurrentGiayDangKiemChiTiet = gdk;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditGiayDangKiemChiTietView_Load(object sender, EventArgs e)
        {
            ActiveControl = dtpNgayCap;
            if (!_addEditGiayDangKiemChiTietPresenter.IsNew)
            {
                SetGiayDangKiemChiTietToControls(_addEditGiayDangKiemChiTietPresenter.CurrentGiayDangKiemChiTiet);
                dtpNgayCap.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            giay_dang_kiem_ct gdk = GetGiayDangKiemChiTiet();

            if (_addEditGiayDangKiemChiTietPresenter.IsNew && _addEditGiayDangKiemChiTietPresenter.CheckNgayCapIfExisted(gdk.ma_giay, gdk.ngay_cap))
            {
                MessageBox.Show(string.Format("Ngày cấp '{0}' đã tồn tại. Vui lòng chọn ngày khác !", gdk.ngay_cap.ToString("dd/MM/yyyy")), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayCap;
                return;
            }

            if (_addEditGiayDangKiemChiTietPresenter.IsNew && !_addEditGiayDangKiemChiTietPresenter.CheckNgayCapValid(gdk.ma_giay, gdk.ngay_cap))
            {
                MessageBox.Show(string.Format("Ngày cấp mới '{0}' nhỏ hơn ngày cấp cũ. Vui lòng chọn ngày khác !", gdk.ngay_cap.ToString("dd/MM/yyyy")), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayCap;
                return;
            }

            if (gdk.ngay_cap >= gdk.ngay_het_han)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày cấp. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayHetHan;
                return;
            }

            bool result = _addEditGiayDangKiemChiTietPresenter.SaveGiayDangKiemChiTiet(gdk);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditGiayDangKiemChiTietView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private giay_dang_kiem_ct GetGiayDangKiemChiTiet()
        {
            giay_dang_kiem_ct gdk = new giay_dang_kiem_ct();
            gdk.ma_giay = _addEditGiayDangKiemChiTietPresenter.MaGiay;
            gdk.ngay_cap = dtpNgayCap.Value.Date;
            gdk.ngay_het_han = dtpNgayHetHan.Value.Date;
            gdk.ghi_chu = txtGhiChu.Text.Trim();
            gdk.ngay_cap_nhat = DateTime.Now;
            gdk.nguoi_cap_nhat = "Admin";
            gdk.trang_thai = chkTinhTrang.Checked ? "1" : "0";

            return gdk;
        }

        private void SetGiayDangKiemChiTietToControls(giay_dang_kiem_ct gdk)
        {
            dtpNgayCap.Value = gdk.ngay_cap;
            dtpNgayHetHan.Value = gdk.ngay_het_han;
            txtGhiChu.Text = gdk.ghi_chu;
            chkTinhTrang.Checked = gdk.trang_thai == "1";
        }
    }
}