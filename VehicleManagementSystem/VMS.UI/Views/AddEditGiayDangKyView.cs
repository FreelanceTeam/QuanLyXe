using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.Helper;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditGiayDangKyView : Form, IAddEditGiayDangKyView
    {
        private readonly AddEditGiayDangKyPresenter _addEditGiayDangKyPresenter;
        public AddEditGiayDangKyView(string ma_xe)
        {
            InitializeComponent();
            _addEditGiayDangKyPresenter = new AddEditGiayDangKyPresenter(this);
            _addEditGiayDangKyPresenter.MaXe = ma_xe;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClearImage, "Nhấp vào để xoá hình hiện tại !");
        }

        public AddEditGiayDangKyView(giay_dang_ky gdk)
            : this(gdk.ma_giay)
        {
            _addEditGiayDangKyPresenter.IsNew = false;
            _addEditGiayDangKyPresenter.CurrentGiayDangKy = gdk;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditGiayDangKyView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtMaGiay;
            _addEditGiayDangKyPresenter.LoadDonVi();

            if (!_addEditGiayDangKyPresenter.IsNew)
            {
                SetGiayDangKyToControls(_addEditGiayDangKyPresenter.CurrentGiayDangKy);
                txtMaGiay.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            giay_dang_ky gdk = GetGiayDangKy();

            if (string.IsNullOrEmpty(gdk.ma_giay))
            {
                MessageBox.Show("Mã GĐK không được trống. Vui lòng chọn phụ tùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaGiay;
                return;
            }

            if (_addEditGiayDangKyPresenter.IsNew && _addEditGiayDangKyPresenter.CheckGiayDangKyIfExisted(gdk.ma_giay))
            {
                MessageBox.Show("Mã GĐK đã được sử dụng. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaGiay;
                return;
            }

            bool result = _addEditGiayDangKyPresenter.SaveGiayDangKy(gdk);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditGiayDangKyView_KeyDown(object sender, KeyEventArgs e)
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

        public void LoadDonVi(DataTable dtDonVi)
        {
            cboDonVi.DataSource = dtDonVi;
            cboDonVi.DisplayMember = "ten_bp";
            cboDonVi.ValueMember = "ma_bp";
        }

        private giay_dang_ky GetGiayDangKy()
        {
            giay_dang_ky gdk = new giay_dang_ky();
            gdk.ma_xe = _addEditGiayDangKyPresenter.MaXe;
            gdk.ma_giay = txtMaGiay.Text.Trim();
            gdk.don_vi = cboDonVi.SelectedValue.ToString();
            gdk.nhac_nho_truoc_ngay = txtNhacNhoTruocNgay.Value;
            gdk.hinh_anh = picHinhAnh.Image == null ? null : ConvertionHelper.ImageToByteArray(picHinhAnh.Image);
            gdk.ghi_chu = txtGhiChu.Text.Trim();
            gdk.ngay_cap_nhat = DateTime.Now;
            gdk.nguoi_cap_nhat = "Admin";
            gdk.ngay_tao = DateTime.Now;
            gdk.nguoi_tao = "Admin";
            gdk.status = chkStatus.Checked ? "1" : "0";

            return gdk;
        }

        private void SetGiayDangKyToControls(giay_dang_ky gdk)
        {
            txtMaGiay.Text = gdk.ma_giay;
            cboDonVi.SelectedValue = gdk.don_vi;
            txtNhacNhoTruocNgay.Value = gdk.nhac_nho_truoc_ngay;
            if (gdk.hinh_anh != null)
            {
                picHinhAnh.Image = ConvertionHelper.ByteArrayToImage(gdk.hinh_anh);
                btnClearImage.Visible = true;
            }

            txtGhiChu.Text = gdk.ghi_chu;
            chkStatus.Checked = gdk.status == "1";
            if (gdk.ngay_cap_lan_dau.HasValue)
            {
                dtpNgayCapDauTien.Value = (DateTime)gdk.ngay_cap_lan_dau;
                dtpNgayCapDauTien.Visible = true;
                txtNgayCapDauTien.Visible = false;
            }
            else
            {
                dtpNgayCapDauTien.Visible = false;
                txtNgayCapDauTien.Visible = true;
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picHinhAnh.Image = null;
            btnClearImage.Visible = false;
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = new Bitmap(openFileDialog.FileName);
                btnClearImage.Visible = true;
            } 
        }
    }
}