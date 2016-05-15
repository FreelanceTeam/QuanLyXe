using System;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditGiayDangKyChiTietView : Form, IAddEditGiayDangKyChiTietView
    {
        private readonly AddEditGiayDangKyChiTietPresenter _addEditGiayDangKyChiTietPresenter;
        public AddEditGiayDangKyChiTietView(string ma_giay)
        {
            InitializeComponent();
            _addEditGiayDangKyChiTietPresenter = new AddEditGiayDangKyChiTietPresenter(this);
            _addEditGiayDangKyChiTietPresenter.MaGiay = ma_giay;
        }

        public AddEditGiayDangKyChiTietView(giay_dang_ky_ct gdk)
            : this(gdk.ma_giay)
        {
            _addEditGiayDangKyChiTietPresenter.IsNew = false;
            _addEditGiayDangKyChiTietPresenter.CurrentGiayDangKyChiTiet = gdk;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditGiayDangKyChiTietView_Load(object sender, EventArgs e)
        {
            ActiveControl = dtpNgayCap;
            if (!_addEditGiayDangKyChiTietPresenter.IsNew)
            {
                SetGiayDangKyChiTietToControls(_addEditGiayDangKyChiTietPresenter.CurrentGiayDangKyChiTiet);
                dtpNgayCap.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            giay_dang_ky_ct gdk = GetGiayDangKyChiTiet();

            if (_addEditGiayDangKyChiTietPresenter.IsNew && _addEditGiayDangKyChiTietPresenter.CheckNgayCapIfExisted(gdk.ma_giay, gdk.ngay_cap))
            {
                MessageBox.Show(string.Format("Ngày cấp '{0}' đã tồn tại. Vui lòng chọn ngày khác !", gdk.ngay_cap.ToString("dd/MM/yyyy")), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayCap;
                return;
            }

            if (_addEditGiayDangKyChiTietPresenter.IsNew && !_addEditGiayDangKyChiTietPresenter.CheckNgayCapValid(gdk.ma_giay, gdk.ngay_cap))
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

            bool result = _addEditGiayDangKyChiTietPresenter.SaveGiayDangKyChiTiet(gdk);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditGiayDangKyChiTietView_KeyDown(object sender, KeyEventArgs e)
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

        private giay_dang_ky_ct GetGiayDangKyChiTiet()
        {
            giay_dang_ky_ct gdk = new giay_dang_ky_ct();
            gdk.ma_giay = _addEditGiayDangKyChiTietPresenter.MaGiay;
            gdk.ngay_cap = dtpNgayCap.Value.Date;
            gdk.ngay_het_han = dtpNgayHetHan.Value.Date;
            gdk.ghi_chu = txtGhiChu.Text.Trim();
            gdk.ngay_cap_nhat = DateTime.Now;
            gdk.nguoi_cap_nhat = "Admin";
            gdk.trang_thai = chkTinhTrang.Checked ? "1" : "0";

            return gdk;
        }

        private void SetGiayDangKyChiTietToControls(giay_dang_ky_ct gdk)
        {
            dtpNgayCap.Value = gdk.ngay_cap;
            dtpNgayHetHan.Value = gdk.ngay_het_han;
            txtGhiChu.Text = gdk.ghi_chu;
            chkTinhTrang.Checked = gdk.trang_thai == "1";
        }
    }
}