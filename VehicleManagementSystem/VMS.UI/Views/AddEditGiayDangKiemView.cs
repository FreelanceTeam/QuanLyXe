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
    public partial class AddEditGiayDangKiemView : Form, IAddEditGiayDangKiemView
    {
        private readonly AddEditGiayDangKiemPresenter _addEditGiayDangKiemPresenter;
        public AddEditGiayDangKiemView(string ma_xe)
        {
            InitializeComponent();
            _addEditGiayDangKiemPresenter = new AddEditGiayDangKiemPresenter(this);
            _addEditGiayDangKiemPresenter.MaXe = ma_xe;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClearImage, "Nhấp vào để xoá hình hiện tại !");
        }

        public AddEditGiayDangKiemView(giay_dang_kiem gdk)
            : this(gdk.ma_giay)
        {
            _addEditGiayDangKiemPresenter.IsNew = false;
            _addEditGiayDangKiemPresenter.CurrentGiayDangKiem = gdk;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditGiayDangKiemView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtMaGiay;
            _addEditGiayDangKiemPresenter.LoadDonVi();

            if (!_addEditGiayDangKiemPresenter.IsNew)
            {
                SetGiayDangKiemToControls(_addEditGiayDangKiemPresenter.CurrentGiayDangKiem);
                txtMaGiay.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            giay_dang_kiem gdk = GetGiayDangKiem();

            if (string.IsNullOrEmpty(gdk.ma_giay))
            {
                MessageBox.Show("Mã GĐK không được trống. Vui lòng chọn phụ tùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaGiay;
                return;
            }

            if (_addEditGiayDangKiemPresenter.IsNew && _addEditGiayDangKiemPresenter.CheckGiayDangKiemIfExisted(gdk.ma_giay))
            {
                MessageBox.Show("Mã GĐK đã được sử dụng. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaGiay;
                return;
            }

            bool result = _addEditGiayDangKiemPresenter.SaveGiayDangKiem(gdk);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditGiayDangKiemView_KeyDown(object sender, KeyEventArgs e)
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

        private giay_dang_kiem GetGiayDangKiem()
        {
            giay_dang_kiem gdk = new giay_dang_kiem();
            gdk.ma_xe = _addEditGiayDangKiemPresenter.MaXe;
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

        private void SetGiayDangKiemToControls(giay_dang_kiem gdk)
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