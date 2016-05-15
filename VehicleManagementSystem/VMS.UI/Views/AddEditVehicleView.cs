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
    public partial class AddEditVehicleView : Form, IAddEditVehicleView
    {
        private AddEditVehiclePresenter _addEditVehiclePresenter;
        public AddEditVehicleView()
        {
            InitializeComponent();
            _addEditVehiclePresenter = new AddEditVehiclePresenter(this);
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnClearImage, "Nhấp vào để xoá hình hiện tại !");
        }

        public AddEditVehicleView(tai_san_xe tsx): this()
        {
            if (tsx != null)
            {
                _addEditVehiclePresenter.IsNew = false;
                _addEditVehiclePresenter.CurrentVehicle = tsx;
                this.Text = "CẬP NHẬT";
            }
        }

        private void AddEditVehicleView_Load(object sender, EventArgs e)
        {
            ActiveControl = txtMaXe;
            _addEditVehiclePresenter.LoadLoaiTaiSanXe();
            LoadLoaiXe();
            LoadHangXe();
            LoadLoaiNhienLieu();
            if (!_addEditVehiclePresenter.IsNew)
            {
                SetTaiSanXeToControls(_addEditVehiclePresenter.CurrentVehicle);
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

            if (_addEditVehiclePresenter.IsNew && _addEditVehiclePresenter.CheckMaXeIfExisted(txtMaXe.Text.Trim()))
            {
                MessageBox.Show("Mã xe đã được sử dụng. Vui lòng nhập lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveControl = txtMaXe;
                return;
            }

            bool result = _addEditVehiclePresenter.SaveVehicle(tsx);
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
            tai_san_xe tsx = new tai_san_xe();
            tsx.ma_xe = txtMaXe.Text.Trim();
            tsx.bien_so = txtBienSo.Text.Trim();
            tsx.hang_san_xuat = cboHangXe.Text;
            tsx.loai_xe = cboLoaiXe.Text;
            tsx.ma_lts = cboLoaiTaiSan.SelectedValue.ToString();
            tsx.nam_san_xuat = short.Parse(txtNamSanXuat.Text);
            tsx.so_nam_su_dung = byte.Parse(txtSoNamSuDung.Text);
            tsx.so_may = txtSoMay.Text.Trim();
            tsx.so_khung = txtSoKhung.Text.Trim();
            tsx.mau = txtMau.Text.Trim();
            tsx.binh_nhien_lieu = txtBinhNhienLieu.Text.Trim();
            tsx.loai_nhien_lieu = cboLoaiNhienLieu.Text;
            tsx.trong_tai_the_tich = txtTheTich.Value;
            tsx.trong_tai_khoi_luong = txtKhoiLuong.Value;
            tsx.tong_trong_luong = txtTongTrongLuong.Value;
            tsx.nguyen_gia = txtNguyenGia.Value;
            tsx.gia_tri_khau_hao = txtGiaTriKhauHao.Value;
            tsx.ti_le_khau_hao = txtTiLeKhauHao.Value;
            tsx.gia_tri_con_lai = txtGiaTriConLai.Value;
            tsx.hinh_anh = picHinhAnh.Image == null? null: ConvertionHelper.ImageToByteArray(picHinhAnh.Image);
            tsx.ghi_chu = txtGhiChu.Text.Trim();
            tsx.ngay_cap_nhat = DateTime.Now;
            tsx.nguoi_cap_nhat = "Admin";
            tsx.ngay_tao = DateTime.Now;
            tsx.nguoi_tao = "Admin";
            tsx.status = chkStatus.Checked ? "0" : "1";

            return tsx;
        }

        private void SetTaiSanXeToControls(tai_san_xe tsx)
        {
            txtMaXe.Text = tsx.ma_xe;
            txtBienSo.Text = tsx.bien_so;
            cboHangXe.SelectedItem = tsx.hang_san_xuat;
            cboLoaiXe.SelectedItem = tsx.loai_xe;
            cboLoaiTaiSan.SelectedValue = tsx.ma_lts;
            txtNamSanXuat.Text = tsx.nam_san_xuat.ToString();
            txtSoNamSuDung.Text = tsx.so_nam_su_dung.ToString();
            txtSoMay.Text = tsx.so_may;
            txtSoKhung.Text = tsx.so_khung;
            txtMau.Text = tsx.mau;
            txtBinhNhienLieu.Text = tsx.binh_nhien_lieu;
            cboLoaiNhienLieu.SelectedItem = tsx.loai_nhien_lieu;
            txtTheTich.Value = tsx.trong_tai_the_tich;
            txtKhoiLuong.Value = tsx.trong_tai_khoi_luong;
            txtTongTrongLuong.Value = tsx.tong_trong_luong;
            txtNguyenGia.Value = tsx.nguyen_gia;
            txtGiaTriKhauHao.Value = tsx.gia_tri_khau_hao;
            txtTiLeKhauHao.Value = tsx.ti_le_khau_hao;
            txtGiaTriConLai.Value = tsx.gia_tri_con_lai;
            if (tsx.hinh_anh != null)
            {
                picHinhAnh.Image = ConvertionHelper.ByteArrayToImage(tsx.hinh_anh);
                btnClearImage.Visible = true;
            }
            txtGhiChu.Text = tsx.ghi_chu;
            chkStatus.Checked = tsx.status == "0";
        }

        private void LoadHangXe()
        {
            string[] hangXe = {"", "BWM", "Ford", "GMC", "Honda", "Hyundai", "Kia", "Mazda", "Mercedes", "Toyota"};
            cboHangXe.Items.AddRange(hangXe);
        }

        private void LoadLoaiXe()
        {
            string[] loaiXe = { "", "Car", "SUV", "Truck" };
            cboLoaiXe.Items.AddRange(loaiXe);
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

        #region IAddEditVehicleView Members

        public void LoadLoaiTaiSanXe(DataTable lstLoaiTaiSan)
        {
            cboLoaiTaiSan.DataSource = lstLoaiTaiSan;
            cboLoaiTaiSan.DisplayMember = "ten_lts";
            cboLoaiTaiSan.ValueMember = "ma_lts";
        }

        #endregion
    }
}