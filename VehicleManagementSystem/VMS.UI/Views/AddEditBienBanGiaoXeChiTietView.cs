using System;
using System.Data;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditBienBanGiaoXeChiTietView : Form, IAddEditBienBanGiaoXeChiTietView
    {
        private readonly AddEditBienBanGiaoXeChiTietPresenter _presenter;
        public AddEditBienBanGiaoXeChiTietView(string so_bien_ban)
        {
            InitializeComponent();
            _presenter = new AddEditBienBanGiaoXeChiTietPresenter(this);
            _presenter.SoBienBan = so_bien_ban;
        }

        public AddEditBienBanGiaoXeChiTietView(bien_ban_giao_xe_ct entity)
            : this(entity.so_bien_ban)
        {
            if (entity != null)
            {
                _presenter.IsNew = false;
                _presenter.CurrentBienBanGiaoXeChiTiet = entity;
                this.Text = string.Format("CẬP NHẬT '{0}'", entity.ten_ccdc);
            }
        }

        private void AddEditBienBanGiaoXeChiTietView_Load(object sender, EventArgs e)
        {
            ActiveControl = cboCCDC;
            _presenter.LoadCCDC();

            if (!_presenter.IsNew)
            {
                SetBienBanGiaoXeChiTietToControls(_presenter.CurrentBienBanGiaoXeChiTiet);
                cboCCDC.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bien_ban_giao_xe_ct entity = GetBienBanGiaoXeChiTiet();

            if (string.IsNullOrEmpty(entity.ma_ccdc))
            {
                MessageBox.Show("Công cụ dụng cụ không được trống. Vui lòng chọn phụ tùng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = cboCCDC;
                return;
            }
            if (entity.so_luong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0. Vui lòng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtSoLuong;
                return;
            }

            if (_presenter.IsNew && _presenter.CheckIfExisted(entity.so_bien_ban, entity.ma_ccdc))
            {
                MessageBox.Show("Công cụ dụng cụ đã được sử dụng. Vui lòng cập nhật lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = cboCCDC;
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

        private void AddEditBienBanGiaoXeChiTietView_KeyDown(object sender, KeyEventArgs e)
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

        private bien_ban_giao_xe_ct GetBienBanGiaoXeChiTiet()
        {
            bien_ban_giao_xe_ct entity = new bien_ban_giao_xe_ct();
            entity.so_bien_ban = _presenter.SoBienBan;
            entity.ma_ccdc = cboCCDC.SelectedValue.ToString();
            entity.so_luong = byte.Parse(txtSoLuong.Text);
            entity.so_km_da_su_dung = txtSoKmDaSuDung.Value;
            entity.trang_thai = (byte) (chkTinhTrang.Checked ? 1 : 0);

            return entity;
        }

        private void SetBienBanGiaoXeChiTietToControls(bien_ban_giao_xe_ct entity)
        {
            cboCCDC.SelectedValue = entity.ma_ccdc;
            txtSoLuong.Value = entity.so_luong;
            txtSoKmDaSuDung.Value = entity.so_km_da_su_dung;
            chkTinhTrang.Checked = entity.trang_thai == 1;
        }

        #region IAddEditBienBanGiaoXeChiTietView Members

        public void LoadCCDC(DataTable dt)
        {
            cboCCDC.DataSource = dt;
            cboCCDC.DisplayMember = "ten_ccdc";
            cboCCDC.ValueMember = "ma_ccdc";
        }

        #endregion
    }
}