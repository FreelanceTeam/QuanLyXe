using System;
using System.Data;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditLichSuTaiXeView : Form, IAddEditLichSuTaiXeView
    {
        private readonly AddEditLichSuTaiXePresenter _presenter;
        public AddEditLichSuTaiXeView(string ma_xe)
        {
            InitializeComponent();
            _presenter = new AddEditLichSuTaiXePresenter(this);
            _presenter.MaXe = ma_xe;
            dtpNgayBatDau.Value = new DateTime(1900, 1, 1);
            dtpNgayKetThuc.Value = new DateTime(1900, 1, 1);
        }

        public AddEditLichSuTaiXeView(lich_su_tai_xe entity)
            : this(entity.ma_xe)
        {
            if (entity != null)
            {
                _presenter.IsNew = false;
                _presenter.CurrentLichSuTaiXe = entity;
                this.Text = string.Format("CẬP NHẬT '{0}'", entity.ten_tai_xe);
            }
        }

        private void AddEditLichSuTaiXeView_Load(object sender, EventArgs e)
        {
            ActiveControl = cboTaiXe;
            _presenter.LoadLichSuTaiXe();

            if (!_presenter.IsNew)
            {
                SetLichSuTaiXeToControls(_presenter.CurrentLichSuTaiXe);
                cboTaiXe.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lich_su_tai_xe entity = GetLichSuTaiXe();

            if (string.IsNullOrEmpty(entity.ma_tai_xe))
            {
                MessageBox.Show("Tài xế không được trống. Vui lòng chọn tài xế !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = cboTaiXe;
                return;
            }

            if (_presenter.IsNew && _presenter.CheckLichSuTaiXeIfExisted(entity.ma_xe, entity.ma_tai_xe))
            {
                MessageBox.Show("Tài xế đã được sử dụng. Vui lòng cập nhật lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = cboTaiXe;
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

        private void AddEditLichSuTaiXeView_KeyDown(object sender, KeyEventArgs e)
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

        private lich_su_tai_xe GetLichSuTaiXe()
        {
            lich_su_tai_xe entity = new lich_su_tai_xe();
            entity.ma_xe = _presenter.MaXe;
            entity.ma_tai_xe = cboTaiXe.SelectedValue.ToString();
            entity.so_km_bat_dau = txtSoKmBatDau.Value;
            entity.so_km_ket_thuc = txtSoKmKetThuc.Value;
            entity.ngay_bat_dau = dtpNgayBatDau.Value.Date == dtpNgayBatDau.MinDate ? (DateTime?) null : dtpNgayBatDau.Value.Date;
            entity.ngay_ket_thuc = dtpNgayKetThuc.Value.Date == dtpNgayKetThuc.MinDate ? (DateTime?)null : dtpNgayKetThuc.Value.Date;
            entity.trang_thai = (chkTinhTrang.Checked ? "Y" : "N");
            entity.ngay_cap_nhat = DateTime.Now;
            entity.nguoi_cap_nhat = "Admin";
            entity.ngay_tao = DateTime.Now;
            entity.nguoi_tao = "Admin";
            entity.status = "Y";

            return entity;
        }

        private void SetLichSuTaiXeToControls(lich_su_tai_xe entity)
        {
            cboTaiXe.SelectedValue = entity.ma_tai_xe;
            txtSoKmBatDau.Value = entity.so_km_bat_dau;
            txtSoKmKetThuc.Value = entity.so_km_ket_thuc;
            dtpNgayBatDau.Value = entity.ngay_bat_dau.HasValue ? entity.ngay_bat_dau.Value : dtpNgayBatDau.MinDate;
            dtpNgayKetThuc.Value = entity.ngay_ket_thuc.HasValue ? entity.ngay_ket_thuc.Value : dtpNgayKetThuc.MinDate;
            chkTinhTrang.Checked = entity.trang_thai == "Y";
        }

        #region IAddEditLichSuTaiXeView Members

        public void LoadTaiXe(DataTable dt)
        {
            cboTaiXe.DataSource = dt;
            cboTaiXe.DisplayMember = "ten_tai_xe";
            cboTaiXe.ValueMember = "ma_tai_xe";
        }

        #endregion
    }
}