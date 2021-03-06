using System;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditGiayDangKiemChiTietView : Form, IAddEditGiayDangKiemChiTietView
    {
        private readonly AddEditGiayDangKiemChiTietPresenter _presenter;
        public AddEditGiayDangKiemChiTietView(string ma_giay)
        {
            InitializeComponent();
            _presenter = new AddEditGiayDangKiemChiTietPresenter(this);
            _presenter.MaGiay = ma_giay;
        }

        public AddEditGiayDangKiemChiTietView(giay_dang_kiem_ct entity)
            : this(entity.ma_giay)
        {
            _presenter.IsNew = false;
            _presenter.CurrentGiayDangKiemChiTiet = entity;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditGiayDangKiemChiTietView_Load(object sender, EventArgs e)
        {
            ActiveControl = dtpNgayCap;
            if (!_presenter.IsNew)
            {
                SetGiayDangKiemChiTietToControls(_presenter.CurrentGiayDangKiemChiTiet);
                dtpNgayCap.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            giay_dang_kiem_ct entity = GetGiayDangKiemChiTiet();

            if (_presenter.IsNew && _presenter.CheckNgayCapIfExisted(entity.ma_giay, entity.ngay_cap))
            {
                MessageBox.Show(string.Format("Ngày cấp '{0}' đã tồn tại. Vui lòng chọn ngày khác !", entity.ngay_cap.ToString("dd/MM/yyyy")), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayCap;
                return;
            }

            if (_presenter.IsNew && !_presenter.CheckNgayCapValid(entity.ma_giay, entity.ngay_cap))
            {
                MessageBox.Show(string.Format("Ngày cấp mới '{0}' nhỏ hơn ngày cấp cũ. Vui lòng chọn ngày khác !", entity.ngay_cap.ToString("dd/MM/yyyy")), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayCap;
                return;
            }

            if (entity.ngay_cap >= entity.ngay_het_han)
            {
                MessageBox.Show("Ngày hết hạn phải lớn hơn ngày cấp. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayHetHan;
                return;
            }

            bool result = _presenter.Save(entity);
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
            giay_dang_kiem_ct entity = new giay_dang_kiem_ct();
            entity.ma_giay = _presenter.MaGiay;
            entity.ngay_cap = dtpNgayCap.Value.Date;
            entity.ngay_het_han = dtpNgayHetHan.Value.Date;
            entity.ghi_chu = txtGhiChu.Text.Trim();
            entity.ngay_cap_nhat = DateTime.Now;
            entity.nguoi_cap_nhat = "Admin";
            entity.trang_thai = chkTinhTrang.Checked ? "Y" : "N";

            return entity;
        }

        private void SetGiayDangKiemChiTietToControls(giay_dang_kiem_ct entity)
        {
            dtpNgayCap.Value = entity.ngay_cap;
            dtpNgayHetHan.Value = entity.ngay_het_han;
            txtGhiChu.Text = entity.ghi_chu;
            chkTinhTrang.Checked = entity.trang_thai == "Y";
        }
    }
}