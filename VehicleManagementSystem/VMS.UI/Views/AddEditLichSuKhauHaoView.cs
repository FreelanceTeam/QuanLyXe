using System;
using System.Data;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditLichSuKhauHaoView : Form, IAddEditLichSuKhauHaoView
    {
        private readonly AddEditLichSuKhauHaoPresenter _presenter;
        public AddEditLichSuKhauHaoView(string ma_xe)
        {
            InitializeComponent();
            _presenter = new AddEditLichSuKhauHaoPresenter(this);
            _presenter.MaXe = ma_xe;
        }

        private void AddEditLichSuKhauHaoView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtGiaTriKhauHao;
            _presenter.LoadLatestKhauHao();
            if (_presenter.CurrentKhauHao != null)
            {
                txtNguyenGia.Text = _presenter.CurrentKhauHao.nguyen_gia.ToString("N0");
                txtGiaTriConLai.Text = _presenter.CurrentKhauHao.gia_tri_con_lai.ToString("N0");
                txtGiaTriKhauHao.Value = _presenter.CurrentKhauHao.gia_tri_khau_hao;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lich_su_khau_hao entity = GetLichSuKhauHao();

            if (entity.ti_le_khau_hao <= 0)
            {
                MessageBox.Show("Vui lòng nhập tỉ lệ khấu hao !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtTiLeKhauHao;
                return;
            }

            if (_presenter.CurrentKhauHao != null && entity.ti_le_khau_hao == _presenter.CurrentKhauHao.ti_le_khau_hao)
            {
                MessageBox.Show(string.Format("Tỉ lệ khấu phải phải khác với giá trị đang sử dụng({0} %) !", _presenter.CurrentKhauHao.ti_le_khau_hao), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtTiLeKhauHao;
                return;
            }

            if (_presenter.CheckLichSuKhauHaoIfExisted(entity.ma_xe, entity.ngay_hieu_luc))
            {
                MessageBox.Show("Ngày hiệu lực đã được sử dụng. Vui lòng cập nhật lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayHieuLuc;
                return;
            }

            if (_presenter.CurrentKhauHao != null && entity.ngay_hieu_luc < _presenter.CurrentKhauHao.ngay_hieu_luc)
            {
                MessageBox.Show(string.Format("Ngày hiệu lực phải lớn hơn ngày hiệu lực đang sử dụng({0} %) !", _presenter.CurrentKhauHao.ngay_hieu_luc_str), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = dtpNgayHieuLuc;
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

        private void AddEditLichSuKhauHaoView_KeyDown(object sender, KeyEventArgs e)
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

        private lich_su_khau_hao GetLichSuKhauHao()
        {
            lich_su_khau_hao entity = new lich_su_khau_hao();
            entity.ma_xe = _presenter.MaXe;
            entity.ngay_hieu_luc = dtpNgayHieuLuc.Value.Date;
            entity.gia_tri_con_lai = _presenter.CurrentKhauHao != null ? _presenter.CurrentKhauHao.gia_tri_con_lai:0 ;
            entity.gia_tri_khau_hao = txtGiaTriKhauHao.Value;
            entity.ti_le_khau_hao = txtTiLeKhauHao.Value;
            entity.ghi_chu = txtGhiChu.Text;
            entity.ngay_cap_nhat = DateTime.Now;
            entity.nguoi_cap_nhat = "Admin";
            entity.ngay_tao = DateTime.Now;
            entity.nguoi_tao = "Admin";
            entity.status = "Y";
            entity.gia_tri_trich_kh_nam = entity.gia_tri_khau_hao * entity.ti_le_khau_hao / 100;
            entity.gia_tri_trich_kh_thang = 0;
            entity.so_thang_da_trich_kh = 0;
            return entity;
        }

        #region IAddEditLichSuKhauHaoView Members

        #endregion
    }
}