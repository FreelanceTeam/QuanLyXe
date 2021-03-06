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
    public partial class AddEditBienBanThuHoiView : Form, IAddEditBienBanThuHoiView
    {
        private readonly AddEditBienBanThuHoiPresenter _presenter;
        public AddEditBienBanThuHoiView(string ma_xe)
        {
            InitializeComponent();
            _presenter = new AddEditBienBanThuHoiPresenter(this);
            _presenter.MaXe = ma_xe;
        }

        public AddEditBienBanThuHoiView(bien_ban_thu_hoi entity)
            : this(entity.ma_xe)
        {
            _presenter.IsNew = false;
            _presenter.CurrentBienBanThuHoi = entity;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditBienBanThuHoiView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtSoBienBan;
            _presenter.LoadTaiXe();

            if (!_presenter.IsNew)
            {
                SetBienBanThuHoiToControls(_presenter.CurrentBienBanThuHoi);
                txtSoBienBan.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bien_ban_thu_hoi entity = GetBienBanThuHoi();

            if (string.IsNullOrEmpty(entity.so_bien_ban))
            {
                MessageBox.Show("Số biên bản không được trống. Vui lòng chọn phụ tùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtSoBienBan;
                return;
            }

            if (_presenter.IsNew && _presenter.CheckIfExisted(entity.so_bien_ban))
            {
                MessageBox.Show("Số biên bản đã được sử dụng. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtSoBienBan;
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

        private void AddEditBienBanThuHoiView_KeyDown(object sender, KeyEventArgs e)
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

        public void LoadTaiXe(DataTable dt)
        {
            cboTaiXe.DataSource = dt;
            cboTaiXe.DisplayMember = "ten_tai_xe";
            cboTaiXe.ValueMember = "ma_tai_xe";
        }

        private bien_ban_thu_hoi GetBienBanThuHoi()
        {
            bien_ban_thu_hoi entity = new bien_ban_thu_hoi();
            entity.ma_xe = _presenter.MaXe;
            entity.so_bien_ban = txtSoBienBan.Text.Trim();
            entity.ngay_bien_ban = dtpNgayBienBan.Value.Date;
            entity.ma_tai_xe = cboTaiXe.SelectedValue.ToString();
            entity.ngay_ket_thuc = dtpNgayKetThuc.Value.Date;
            entity.so_km_ket_thuc = txtSoKmKetThuc.Value;
            entity.ly_do_thu_hoi = txtLyDoThuHoi.Text.Trim();
            entity.ghi_chu = txtGhiChu.Text.Trim();
            entity.ngay_cap_nhat = DateTime.Now;
            entity.nguoi_cap_nhat = "Admin";
            entity.ngay_tao = DateTime.Now;
            entity.nguoi_tao = "Admin";
            entity.status = chkStatus.Checked ? "Y" : "N";

            return entity;
        }

        private void SetBienBanThuHoiToControls(bien_ban_thu_hoi entity)
        {
            txtSoBienBan.Text = entity.so_bien_ban;
            dtpNgayBienBan.Value = entity.ngay_bien_ban;
            cboTaiXe.SelectedValue = entity.ma_tai_xe;
            dtpNgayKetThuc.Value = entity.ngay_ket_thuc;
            txtSoKmKetThuc.Value = entity.so_km_ket_thuc;
            txtLyDoThuHoi.Text = entity.ly_do_thu_hoi;
            txtGhiChu.Text = entity.ghi_chu;
            chkStatus.Checked = entity.status == "Y";
        }
    }
}