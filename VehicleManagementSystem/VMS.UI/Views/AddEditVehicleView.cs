using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.Helper;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class AddEditVehicleView : Form, IAddEditVehicleView
    {
        private readonly AddEditVehiclePresenter _presenter;
        public AddEditVehicleView()
        {
            InitializeComponent();
            _presenter = new AddEditVehiclePresenter(this);
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClearImage, "Nhấp vào để xoá hình hiện tại !");
        }

        public AddEditVehicleView(tai_san_xe entity): this()
        {
            if (entity != null)
            {
                _presenter.IsNew = false;
                _presenter.CurrentVehicle = entity;
                this.Text = "CẬP NHẬT";
            }
        }

        private void AddEditVehicleView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtMaXe;
            _presenter.LoadLoaiTaiSanXe();
            _presenter.LoadLoaiXe();
            _presenter.LoadHangXe();
            _presenter.LoadMauXe();
            LoadLoaiNhienLieu();
            if (!_presenter.IsNew)
            {
                SetTaiSanXeToControls(_presenter.CurrentVehicle);
                txtMaXe.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tai_san_xe tsx = GetTaiSanXe();

            if (string.IsNullOrEmpty(tsx.ma_xe))
            {
                MessageBox.Show("Mã xe không được trống. Vui lòng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaXe;
                return;
            }
            if (string.IsNullOrEmpty(tsx.bien_so))
            {
                MessageBox.Show("Biển số xe không được trống. Vui lòng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtBienSo;
                return;
            }
            if (string.IsNullOrEmpty(tsx.hang_san_xuat))
            {
                MessageBox.Show("Vui lòng chọn hãng xe !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = cboHangXe;
                return;
            }

            if (_presenter.IsNew && _presenter.CheckMaXeIfExisted(txtMaXe.Text.Trim()))
            {
                MessageBox.Show("Mã xe đã được sử dụng. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaXe;
                return;
            }

            bool result = _presenter.Save(tsx);
            if (result)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = new Bitmap(openFileDialog.FileName);
                btnClearImage.Visible = true;
            } 
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            picHinhAnh.Image = null;
            btnClearImage.Visible = false;
        }

        private tai_san_xe GetTaiSanXe()
        {
            tai_san_xe entity = new tai_san_xe();
            entity.ma_xe = txtMaXe.Text.Trim();
            entity.bien_so = txtBienSo.Text.Trim();
            entity.hang_san_xuat = cboHangXe.Text;
            entity.loai_xe = cboLoaiXe.Text;
            entity.ma_lts = cboLoaiTaiSan.SelectedValue.ToString();
            entity.nam_san_xuat = short.Parse(txtNamSanXuat.Text);
            entity.so_nam_su_dung = byte.Parse(txtSoNamSuDung.Text);
            entity.so_may = txtSoMay.Text.Trim();
            entity.so_khung = txtSoKhung.Text.Trim();
            entity.mau = cboMau.Text;
            entity.binh_nhien_lieu = txtBinhNhienLieu.Text.Trim();
            entity.loai_nhien_lieu = cboLoaiNhienLieu.Text;
            entity.trong_tai_the_tich = txtTheTich.Value;
            entity.trong_tai_khoi_luong = txtKhoiLuong.Value;
            entity.tong_trong_luong = txtTongTrongLuong.Value;
            entity.nguyen_gia = txtNguyenGia.Value;
            entity.ngay_hieu_luc_kh = dtpNgayHieuLucKH.Value.Date;
            entity.gia_tri_khau_hao = txtGiaTriKhauHao.Value;
            entity.ti_le_khau_hao = txtTiLeKhauHao.Value;
            entity.gia_tri_con_lai = txtGiaTriConLai.Value;
            entity.hinh_anh = picHinhAnh.Image == null? null: ConvertionHelper.ImageToByteArray(picHinhAnh.Image);
            entity.ghi_chu = txtGhiChu.Text.Trim();
            entity.ngay_cap_nhat = DateTime.Now;
            entity.nguoi_cap_nhat = "Admin";
            entity.ngay_tao = DateTime.Now;
            entity.nguoi_tao = "Admin";
            entity.status = chkStatus.Checked ? "N" : "Y";

            return entity;
        }

        private void SetTaiSanXeToControls(tai_san_xe entity)
        {
            txtMaXe.Text = entity.ma_xe;
            txtBienSo.Text = entity.bien_so;
            cboHangXe.SelectedItem = entity.hang_san_xuat;
            cboLoaiXe.SelectedItem = entity.loai_xe;
            cboLoaiTaiSan.SelectedValue = entity.ma_lts;
            txtNamSanXuat.Text = entity.nam_san_xuat.ToString();
            txtSoNamSuDung.Text = entity.so_nam_su_dung.ToString();
            txtSoMay.Text = entity.so_may;
            txtSoKhung.Text = entity.so_khung;
            cboMau.SelectedItem = entity.mau;
            txtBinhNhienLieu.Text = entity.binh_nhien_lieu;
            cboLoaiNhienLieu.SelectedItem = entity.loai_nhien_lieu;
            txtTheTich.Value = entity.trong_tai_the_tich;
            txtKhoiLuong.Value = entity.trong_tai_khoi_luong;
            txtTongTrongLuong.Value = entity.tong_trong_luong;
            txtNguyenGia.Value = entity.nguyen_gia;
            dtpNgayHieuLucKH.Value = entity.ngay_hieu_luc_kh;
            txtGiaTriKhauHao.Value = entity.gia_tri_khau_hao;
            txtTiLeKhauHao.Value = entity.ti_le_khau_hao;
            txtGiaTriConLai.Value = entity.gia_tri_con_lai;
            if (entity.hinh_anh != null)
            {
                picHinhAnh.Image = ConvertionHelper.ByteArrayToImage(entity.hinh_anh);
                btnClearImage.Visible = true;
            }
            txtGhiChu.Text = entity.ghi_chu;
            chkStatus.Checked = entity.status == "N";
        }

        private void LoadLoaiNhienLieu()
        {
            string[] loaiNhienLieu = {"", "Dầu Diesel", "Xăng"};
            cboLoaiNhienLieu.Items.AddRange(loaiNhienLieu);
        }

        private void AddEditVehicleView_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNguyenGia_ValueChanged(object sender, EventArgs e)
        {
            txtGiaTriConLai.Value = txtNguyenGia.Value;
        }

        #region IAddEditVehicleView Members

        public void LoadLoaiTaiSanXe(DataTable dt)
        {
            cboLoaiTaiSan.DataSource = dt;
            cboLoaiTaiSan.DisplayMember = "ten_lts";
            cboLoaiTaiSan.ValueMember = "ma_lts";
        }

        public void LoadHangXe(List<string> list)
        {
            if (list == null)
            {
                list = new List<string>();
                list.Add(string.Empty);
            }
            cboHangXe.Items.AddRange(list.ToArray());
        }

        public void LoadLoaiXe(List<string> list)
        {
            if (list == null)
            {
                list = new List<string>();
                list.Add(string.Empty);
            }
            cboLoaiXe.Items.AddRange(list.ToArray());
        }

        public void LoadMauXe(List<string> list)
        {
            if (list == null)
            {
                list = new List<string>();
                list.Add(string.Empty);
            }
            cboMau.Items.AddRange(list.ToArray());
        }

        #endregion
    }
}