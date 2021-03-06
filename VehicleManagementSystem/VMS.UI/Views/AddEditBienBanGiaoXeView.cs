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
    public partial class AddEditBienBanGiaoXeView : Form, IAddEditBienBanGiaoXeView
    {
        private readonly AddEditBienBanGiaoXePresenter _presenter;
        public AddEditBienBanGiaoXeView(string ma_xe)
        {
            InitializeComponent();
            _presenter = new AddEditBienBanGiaoXePresenter(this);
            _presenter.MaXe = ma_xe;
        }

        public AddEditBienBanGiaoXeView(bien_ban_giao_xe entity)
            : this(entity.ma_xe)
        {
            _presenter.IsNew = false;
            _presenter.CurrentBienBanGiaoXe = entity;
            this.Text = string.Format("CẬP NHẬT");
        }

        private void AddEditBienBanGiaoXeView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtSoBienBan;
            _presenter.LoadTaiXe();

            if (!_presenter.IsNew)
            {
                SetBienBanGiaoXeToControls(_presenter.CurrentBienBanGiaoXe);
                txtSoBienBan.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bien_ban_giao_xe entity = GetBienBanGiaoXe();

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

        private void AddEditBienBanGiaoXeView_KeyDown(object sender, KeyEventArgs e)
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

        private bien_ban_giao_xe GetBienBanGiaoXe()
        {
            bien_ban_giao_xe entity = new bien_ban_giao_xe();
            entity.ma_xe = _presenter.MaXe;
            entity.so_bien_ban = txtSoBienBan.Text.Trim();
            entity.ngay_bien_ban = dtpNgayBienBan.Value.Date;
            entity.ma_tai_xe = cboTaiXe.SelectedValue.ToString();
            entity.ngay_nhan_xe = dtpNgayNhanXe.Value.Date;
            entity.so_km_bat_dau = txtSoKmBatDau.Value;
            entity.ghi_chu = txtGhiChu.Text.Trim();
            entity.ngay_cap_nhat = DateTime.Now;
            entity.nguoi_cap_nhat = "Admin";
            entity.ngay_tao = DateTime.Now;
            entity.nguoi_tao = "Admin";
            entity.status = chkStatus.Checked ? "Y" : "N";

            return entity;
        }

        private void SetBienBanGiaoXeToControls(bien_ban_giao_xe entity)
        {
            txtSoBienBan.Text = entity.so_bien_ban;
            dtpNgayBienBan.Value = entity.ngay_bien_ban;
            cboTaiXe.SelectedValue = entity.ma_tai_xe;
            dtpNgayNhanXe.Value = entity.ngay_nhan_xe;
            txtSoKmBatDau.Value = entity.so_km_bat_dau;
            txtGhiChu.Text = entity.ghi_chu;
            chkStatus.Checked = entity.status == "Y";
        }
    }
}