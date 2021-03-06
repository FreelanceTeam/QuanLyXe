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
        private readonly AddEditGiayDangKiemPresenter _presenter;
        public AddEditGiayDangKiemView(string ma_xe)
        {
            InitializeComponent();
            _presenter = new AddEditGiayDangKiemPresenter(this);
            _presenter.MaXe = ma_xe;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClearImage, "Nhấp vào để xoá hình hiện tại !");
        }

        public AddEditGiayDangKiemView(giay_dang_kiem entity)
            : this(entity.ma_xe)
        {
            _presenter.IsNew = false;
            _presenter.CurrentGiayDangKiem = entity;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditGiayDangKiemView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtMaGiay;
            _presenter.LoadDonVi();

            if (!_presenter.IsNew)
            {
                SetGiayDangKiemToControls(_presenter.CurrentGiayDangKiem);
                txtMaGiay.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            giay_dang_kiem entity = GetGiayDangKiem();

            if (string.IsNullOrEmpty(entity.ma_giay))
            {
                MessageBox.Show("Mã giấy không được trống. Vui lòng chọn phụ tùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaGiay;
                return;
            }

            if (_presenter.IsNew && _presenter.CheckIfExisted(entity.ma_giay))
            {
                MessageBox.Show("Mã giấy đã được sử dụng. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaGiay;
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

        public void LoadDonVi(DataTable dt)
        {
            cboDonVi.DataSource = dt;
            cboDonVi.DisplayMember = "ten_bp";
            cboDonVi.ValueMember = "ma_bp";
        }

        private giay_dang_kiem GetGiayDangKiem()
        {
            giay_dang_kiem entity = new giay_dang_kiem();
            entity.ma_xe = _presenter.MaXe;
            entity.ma_giay = txtMaGiay.Text.Trim();
            entity.don_vi = cboDonVi.SelectedValue.ToString();
            entity.nhac_nho_truoc_ngay = txtNhacNhoTruocNgay.Value;
            entity.hinh_anh = picHinhAnh.Image == null ? null : ConvertionHelper.ImageToByteArray(picHinhAnh.Image);
            entity.ghi_chu = txtGhiChu.Text.Trim();
            entity.ngay_cap_nhat = DateTime.Now;
            entity.nguoi_cap_nhat = "Admin";
            entity.ngay_tao = DateTime.Now;
            entity.nguoi_tao = "Admin";
            entity.status = chkStatus.Checked ? "Y" : "N";

            return entity;
        }

        private void SetGiayDangKiemToControls(giay_dang_kiem entity)
        {
            txtMaGiay.Text = entity.ma_giay;
            cboDonVi.SelectedValue = entity.don_vi;
            txtNhacNhoTruocNgay.Value = entity.nhac_nho_truoc_ngay;
            if (entity.hinh_anh != null)
            {
                picHinhAnh.Image = ConvertionHelper.ByteArrayToImage(entity.hinh_anh);
                btnClearImage.Visible = true;
            }

            txtGhiChu.Text = entity.ghi_chu;
            chkStatus.Checked = entity.status == "Y";
            if (entity.ngay_cap_lan_dau.HasValue)
            {
                dtpNgayCapDauTien.Value = (DateTime)entity.ngay_cap_lan_dau;
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