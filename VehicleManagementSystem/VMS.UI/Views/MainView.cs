using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.Helper;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;
using VMS.UI.Properties;

namespace VMS.UI.Views
{
    public partial class MainView : Form, IMainView
    {
        private readonly MainPresenter _mainPresenter;
        public MainView()
        {
            InitializeComponent();
            _mainPresenter = new MainPresenter(this);
            dgvXe.AutoGenerateColumns = false;
            dgvPhuTung.AutoGenerateColumns = false;
            dgvGDKyCT.AutoGenerateColumns = false;
            dgvGDKiemCT.AutoGenerateColumns = false;
            (dgvXe.Columns["colHinhAnh"]).DefaultCellStyle.NullValue = null;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            _mainPresenter.LoadVehiclesDataTable();
        }

        #region IMainView Members
        public void LoadVehiclesDataTable(DataTable dtTaiSanXe)
        {
            dgvXe.DataSource = dtTaiSanXe;
        }

        public void RefreshDataGrid(DataView dvTaiSanXe)
        {
            dgvXe.DataSource = dvTaiSanXe;
        }

        public void ShowImage(Image image)
        {
            ImageViewer dlg = new ImageViewer(image);
            dlg.ShowDialog();
        }

        public void LoadPhuTungDataTable(DataTable dtPhuTung)
        {
            dgvPhuTung.DataSource = dtPhuTung;
            SetPhuTungButtonsStatus(dtPhuTung.Rows.Count > 0);
        }

        public void LoadGiayDangKy(giay_dang_ky gdk)
        {
            SetGiayDangKyToControls(gdk);
            SetGiayDangKyButtonsStatus();
            SetGiayDangKyChiTietButtonsStatus();
        }

        public void LoadGiayDangKiem(giay_dang_kiem gdk)
        {
            SetGiayDangKiemToControls(gdk);
            SetGiayDangKiemButtonsStatus();
            SetGiayDangKiemChiTietButtonsStatus();
        }

        #endregion

        #region Main - Thông tin xe
        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            AddEditVehicleView dlg = new AddEditVehicleView();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập xe mới thành công !", true);
                _mainPresenter.LoadVehiclesDataTable();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow != null)
            {
                lblThongBao.Text = string.Empty;
                AddEditVehicleView dlg = new AddEditVehicleView(_mainPresenter.CurrentVehicle);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật xe '{0}' thành công !", _mainPresenter.CurrentVehicle.bien_so), true);
                    _mainPresenter.LoadVehiclesDataTable();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow != null)
            {
                string ma_xe = dgvXe.CurrentRow.Cells[1].Value.ToString();
                string bien_so = dgvXe.CurrentRow.Cells[2].Value.ToString();
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá xe '{0}' ?", bien_so), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_mainPresenter.DeleteVehicle(ma_xe))
                    {
                        ShowMessage(string.Format("Xoá xe '{0}' thành công !", bien_so), true);
                        _mainPresenter.LoadVehiclesDataTable();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá xe '{0}' thất bại !", bien_so), false);
                    }
                }
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            _mainPresenter.RefreshVehicleDataGrid(chkActive.Checked, chkInActive.Checked, txtSearch.Text.Trim());
        }

        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            _mainPresenter.RefreshVehicleDataGrid(chkActive.Checked, chkInActive.Checked, txtSearch.Text.Trim());
        }

        private void dgvXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow != null)
            {
                dgvXe.CurrentRow.Selected = true;
                string ma_xe = dgvXe.CurrentRow.Cells[1].Value.ToString();
                _mainPresenter.CurrentVehicle = _mainPresenter.CurrentVehiclesList.Find(delegate(tai_san_xe item) { return item.ma_xe == ma_xe; });
                if (_mainPresenter.CurrentVehicle != null)
                {
                    LoadTSXToControls(_mainPresenter.CurrentVehicle);
                    _mainPresenter.LoadPhuTungDataTable();
                    _mainPresenter.LoadGiayDangKy();
                    _mainPresenter.LoadGiayDangKiem();
                }
            }
        }

        private void dgvXe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void ShowMessage(string msg, bool isSucess)
        {
            lblThongBao.ForeColor = isSucess ? Color.Green : Color.Red;
            lblThongBao.Text = msg;
        }

        private void LoadTSXToControls(tai_san_xe tsx)
        {
            lblBienSo.Text = tsx.bien_so;
            lblHangXe.Text = tsx.hang_san_xuat;
            lblLoaiXe.Text = tsx.loai_xe;
            lblLoaiTaiSan.Text = tsx.ten_lts;
            lblNamSanXuat.Text = tsx.nam_san_xuat.ToString();
            lblSoNamSuDung.Text = tsx.so_nam_su_dung.ToString();
            lblSoMay.Text = tsx.so_may;
            lblSoKhung.Text = tsx.so_khung;
            lblMau.Text = tsx.mau;
            lblBinhNhienLieu.Text = tsx.binh_nhien_lieu;
            lblLoaiNhienLieu.Text = tsx.loai_nhien_lieu;
            lblTheTich.Text = tsx.trong_tai_the_tich.ToString("N");
            lblKhoiLuong.Text = tsx.trong_tai_khoi_luong.ToString("N");
            lblTongTrongLuong.Text = tsx.tong_trong_luong.ToString("N");
            lblNguyenGia.Text = tsx.nguyen_gia.ToString("N");
            lblGiaTriKhauHao.Text = tsx.gia_tri_khau_hao.ToString("N");
            lblTiLeKhauHao.Text = tsx.ti_le_khau_hao.ToString("N");
            lblGiaTriConLai.Text = tsx.gia_tri_con_lai.ToString("N");
            picHinhAnh.Image = tsx.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(tsx.hinh_anh) : null;
            lblGhiChu.Text = tsx.ghi_chu;
            chkStatus.Checked = tsx.status == "0";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _mainPresenter.RefreshVehicleDataGrid(chkActive.Checked, chkInActive.Checked, txtSearch.Text.Trim());
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            if (picHinhAnh.Image != null)
            {
                ShowImage(picHinhAnh.Image);
            }
        }

        private void picHinhAnh_MouseHover(object sender, EventArgs e)
        {
            picHinhAnh.Cursor = picHinhAnh.Image != null ? Cursors.Hand : Cursors.Default;
        }

        #endregion
             
        #region tab Phụ tùng

        private void btnAdd_PhuTung_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow != null)
            {
                lblThongBao.Text = string.Empty;
                AddEditPhuTungView dlg = new AddEditPhuTungView(_mainPresenter.CurrentVehicle.ma_xe);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage("Nhập phụ tùng mới thành công !", true);
                    _mainPresenter.LoadPhuTungDataTable();
                }
            }
        }

        private void btnEdit_PhuTung_Click(object sender, EventArgs e)
        {
            if (dgvPhuTung.CurrentRow != null)
            {
                lblThongBao.Text = string.Empty;
                DataRow row = ((DataRowView)dgvPhuTung.CurrentRow.DataBoundItem).Row;
                phu_tung phuTung = ConvertionHelper.ToEntity<phu_tung>(row);
                int index = dgvPhuTung.CurrentRow.Index;
                AddEditPhuTungView dlg = new AddEditPhuTungView(phuTung);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật phụ tùng '{0}' thành công !", phuTung.ten_tai_san), true);
                    _mainPresenter.LoadPhuTungDataTable();
                    dgvPhuTung.ClearSelection();
                    dgvPhuTung.CurrentCell = dgvPhuTung[1, index];
                    dgvPhuTung.Rows[index].Selected = true;
                }
            }
        }

        private void btnDelete_PhuTung_Click(object sender, EventArgs e)
        {
            if (dgvPhuTung.CurrentRow != null)
            {
                string ma_tai_san = dgvPhuTung.CurrentRow.Cells[0].Value.ToString();
                string ten_tai_san = dgvPhuTung.CurrentRow.Cells[1].Value.ToString();
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", ten_tai_san), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_mainPresenter.DeletePhuTung(ma_tai_san))
                    {
                        ShowMessage(string.Format("Xoá '{0}' thành công !", ten_tai_san), true);
                        _mainPresenter.LoadPhuTungDataTable();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá '{0}' thất bại !", ten_tai_san), false);
                    }
                }
            }
        }

        private void SetPhuTungButtonsStatus(bool isEnable)
        {
            if (isEnable)
            {
                btnEdit_PhuTung.Enabled =  btnDelete_PhuTung.Enabled = true;
                btnEdit_PhuTung.BackgroundImage = Resources.edit;
                btnDelete_PhuTung.BackgroundImage = Resources.delete;
            }
            else
            {
                btnEdit_PhuTung.Enabled = btnDelete_PhuTung.Enabled = false;
                btnEdit_PhuTung.BackgroundImage = Resources.edit_disable;
                btnDelete_PhuTung.BackgroundImage = Resources.delete_disable;
            }
        }

        private void dgvPhuTung_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhuTung.CurrentRow != null)
            {
                dgvPhuTung.CurrentRow.Selected = true;
                SetPhuTungButtonsStatus(true);
            }
        }

        private void dgvPhuTung_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_PhuTung_Click(null, null);
        }

        #endregion
        
        #region tab Giấy đăng ký

        private void btnAdd_GDKy_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            AddEditGiayDangKyView dlg = new AddEditGiayDangKyView(_mainPresenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy đăng ký thành công !", true);
                _mainPresenter.LoadGiayDangKy();
            }
        }

        private void btnEdit_GDKy_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            AddEditGiayDangKyView dlg = new AddEditGiayDangKyView(_mainPresenter.CurrentVehicle.GiayDangKy);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật giấy đăng ký '{0}' thành công !", _mainPresenter.CurrentVehicle.GiayDangKy.ma_giay), true);
                _mainPresenter.LoadGiayDangKy();
            }
        }

        private void btnDelete_GDKy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", _mainPresenter.CurrentVehicle.GiayDangKy.ma_giay), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_mainPresenter.DeleteGiayDangKy(_mainPresenter.CurrentVehicle.GiayDangKy.ma_giay))
                {
                    ShowMessage(string.Format("Xoá '{0}' thành công !", _mainPresenter.CurrentVehicle.GiayDangKy.ma_giay), true);
                    _mainPresenter.LoadGiayDangKy();
                }
                else
                {
                    ShowMessage(string.Format("Xoá '{0}' thất bại !", _mainPresenter.CurrentVehicle.GiayDangKy.ma_giay), false);
                }
            }
        }

        private void btnAdd_GDKy_CT_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            AddEditGiayDangKyChiTietView dlg = new AddEditGiayDangKyChiTietView(_mainPresenter.CurrentVehicle.GiayDangKy.ma_giay);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết giấy đăng ký thành công !", true);
                _mainPresenter.LoadGiayDangKy();
            }
        }

        private void btnEdit_GDKy_CT_Click(object sender, EventArgs e)
        {
            if (dgvGDKyCT.CurrentRow != null)
            {
                lblThongBao.Text = string.Empty;
                giay_dang_ky_ct gdkct = (giay_dang_ky_ct)dgvGDKyCT.CurrentRow.DataBoundItem;
                int index = dgvGDKyCT.CurrentRow.Index;
                AddEditGiayDangKyChiTietView dlg = new AddEditGiayDangKyChiTietView(gdkct);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật giấy đăng ký ngày '{0}' thành công !", gdkct.ngay_cap), true);
                    _mainPresenter.LoadGiayDangKy();
                    dgvGDKyCT.ClearSelection();
                    dgvGDKyCT.CurrentCell = dgvGDKyCT[1, index];
                    dgvGDKyCT.Rows[index].Selected = true;
                }
            }
        }

        private void btnDelete_GDKy_CT_Click(object sender, EventArgs e)
        {
            if (dgvGDKyCT.CurrentRow != null)
            {
                lblThongBao.Text = string.Empty;
                giay_dang_ky_ct gdkct = (giay_dang_ky_ct)dgvGDKyCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá giấy đăng ký ngày '{0}' ?", gdkct.ngay_cap_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_mainPresenter.DeleteGiayDangKyChiTiet(gdkct.ma_giay, gdkct.ngay_cap))
                    {
                        ShowMessage(string.Format("Xoá giấy đăng ký ngày '{0}' thành công !", gdkct.ngay_cap_str), true);
                        _mainPresenter.LoadGiayDangKy();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá giấy đăng ký ngày '{0}' thất bại !", gdkct.ngay_cap_str), false);
                    }
                }
            }
        }

        private void dgvGDKyCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_GDKy_CT_Click(null, null);
        }

        private void dgvGDKyCT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGDKyCT.CurrentRow != null)
            {
                dgvGDKyCT.CurrentRow.Selected = true;
                SetGiayDangKyChiTietButtonsStatus();
            }
        }

        private void SetGiayDangKyButtonsStatus()
        {
            if (_mainPresenter.CurrentVehicle != null)
            {
                if (_mainPresenter.CurrentVehicle.GiayDangKy != null)
                {
                    btnEdit_GDKy.Enabled = btnDelete_GDKy.Enabled = true;
                    btnEdit_GDKy.BackgroundImage = Resources.edit;
                    btnDelete_GDKy.BackgroundImage = Resources.delete;
                    btnAdd_GDKy.Enabled = false;
                    btnAdd_GDKy.BackgroundImage = Resources.add_disable;
                }
                else
                {
                    btnEdit_GDKy.Enabled = btnDelete_GDKy.Enabled = false;
                    btnEdit_GDKy.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKy.BackgroundImage = Resources.delete_disable;
                    btnAdd_GDKy.Enabled = true;
                    btnAdd_GDKy.BackgroundImage = Resources.add;
                }
            }
        }

        private void SetGiayDangKyChiTietButtonsStatus()
        {
            if (_mainPresenter.CurrentVehicle != null)
            {
                if (_mainPresenter.CurrentVehicle.GiayDangKy != null)
                {
                    btnAdd_GDKy_CT.Enabled = true;
                    btnAdd_GDKy_CT.BackgroundImage = Resources.add;

                    if (_mainPresenter.CurrentVehicle.GiayDangKy.GiayDangKyCTList != null)
                    {
                        btnEdit_GDKy_CT.Enabled = btnDelete_GDKy_CT.Enabled = true;
                        btnEdit_GDKy_CT.BackgroundImage = Resources.edit;
                        btnDelete_GDKy_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_GDKy_CT.Enabled = btnDelete_GDKy_CT.Enabled = false;
                        btnEdit_GDKy_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_GDKy_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_GDKy_CT.Enabled = btnEdit_GDKy_CT.Enabled = btnDelete_GDKy_CT.Enabled = false;
                    btnAdd_GDKy_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_GDKy_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKy_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetGiayDangKyToControls(giay_dang_ky gdk)
        {
            if (gdk == null)
            {
                lblGDKy_MaGiay.Text = string.Empty;
                lblGDKy_DonVi.Text = string.Empty;
                lblGDKy_NhacNhoTruocNgay.Text = string.Empty;
                picGDKy_HinhAnh.Image = null;
                lblGDKy_GhiChu.Text = string.Empty;
                chkGDKy_Status.Checked = false;
                lblGDKy_NgayCapDauTien.Text = string.Empty;
                dgvGDKyCT.DataSource = null;
            }
            else
            {
                lblGDKy_MaGiay.Text = gdk.ma_giay;
                lblGDKy_DonVi.Text = gdk.ten_don_vi;
                lblGDKy_NhacNhoTruocNgay.Text = gdk.nhac_nho_truoc_ngay.ToString();
                picGDKy_HinhAnh.Image = gdk.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(gdk.hinh_anh) : null;
                lblGDKy_GhiChu.Text = gdk.ghi_chu;
                chkGDKy_Status.Checked = gdk.status == "1";
                lblGDKy_NgayCapDauTien.Text = gdk.ngay_cap_lan_dau.HasValue ? gdk.ngay_cap_lan_dau.Value.ToString("dd/MM/yyyy") : "N/A";

                dgvGDKyCT.DataSource = gdk.GiayDangKyCTList;
            }
        }

        private void picGDKy_HinhAnh_Click(object sender, EventArgs e)
        {
            if (picGDKy_HinhAnh.Image != null)
            {
                ShowImage(picGDKy_HinhAnh.Image);
            }
        }

        private void picGDKy_HinhAnh_MouseHover(object sender, EventArgs e)
        {
            picGDKy_HinhAnh.Cursor = picGDKy_HinhAnh.Image != null ? Cursors.Hand : Cursors.Default;
        }

        #endregion

        #region tab Giấy đăng kiểm

        private void btnAdd_GDKiem_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            AddEditGiayDangKiemView dlg = new AddEditGiayDangKiemView(_mainPresenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy đăng kiểm thành công !", true);
                _mainPresenter.LoadGiayDangKiem();
            }
        }

        private void btnEdit_GDKiem_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            AddEditGiayDangKiemView dlg = new AddEditGiayDangKiemView(_mainPresenter.CurrentVehicle.GiayDangKiem);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật giấy đăng kiểm '{0}' thành công !", _mainPresenter.CurrentVehicle.GiayDangKiem.ma_giay), true);
                _mainPresenter.LoadGiayDangKiem();
            }
        }

        private void btnDelete_GDKiem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", _mainPresenter.CurrentVehicle.GiayDangKiem.ma_giay), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_mainPresenter.DeleteGiayDangKiem(_mainPresenter.CurrentVehicle.GiayDangKiem.ma_giay))
                {
                    ShowMessage(string.Format("Xoá '{0}' thành công !", _mainPresenter.CurrentVehicle.GiayDangKiem.ma_giay), true);
                    _mainPresenter.LoadGiayDangKiem();
                }
                else
                {
                    ShowMessage(string.Format("Xoá '{0}' thất bại !", _mainPresenter.CurrentVehicle.GiayDangKiem.ma_giay), false);
                }
            }
        }

        private void btnAdd_GDKiem_CT_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            AddEditGiayDangKiemChiTietView dlg = new AddEditGiayDangKiemChiTietView(_mainPresenter.CurrentVehicle.GiayDangKiem.ma_giay);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết giấy đăng kiểm thành công !", true);
                _mainPresenter.LoadGiayDangKiem();
            }
        }

        private void btnEdit_GDKiem_CT_Click(object sender, EventArgs e)
        {
            if (dgvGDKiemCT.CurrentRow != null)
            {
                lblThongBao.Text = string.Empty;
                giay_dang_kiem_ct gdkct = (giay_dang_kiem_ct)dgvGDKiemCT.CurrentRow.DataBoundItem;
                int index = dgvGDKiemCT.CurrentRow.Index;
                AddEditGiayDangKiemChiTietView dlg = new AddEditGiayDangKiemChiTietView(gdkct);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật giấy đăng kiểm ngày '{0}' thành công !", gdkct.ngay_cap), true);
                    _mainPresenter.LoadGiayDangKiem();
                    dgvGDKiemCT.ClearSelection();
                    dgvGDKiemCT.CurrentCell = dgvGDKiemCT[1, index];
                    dgvGDKiemCT.Rows[index].Selected = true;
                }
            }
        }

        private void btnDelete_GDKiem_CT_Click(object sender, EventArgs e)
        {
            if (dgvGDKiemCT.CurrentRow != null)
            {
                lblThongBao.Text = string.Empty;
                giay_dang_kiem_ct gdkct = (giay_dang_kiem_ct)dgvGDKiemCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá giấy đăng kiểm ngày '{0}' ?", gdkct.ngay_cap_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_mainPresenter.DeleteGiayDangKiemChiTiet(gdkct.ma_giay, gdkct.ngay_cap))
                    {
                        ShowMessage(string.Format("Xoá giấy đăng kiểm ngày '{0}' thành công !", gdkct.ngay_cap_str), true);
                        _mainPresenter.LoadGiayDangKiem();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá giấy đăng kiểm ngày '{0}' thất bại !", gdkct.ngay_cap_str), false);
                    }
                }
            }
        }

        private void dgvGDKiemCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit_GDKiem_CT_Click(null, null);
        }

        private void dgvGDKiemCT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGDKiemCT.CurrentRow != null)
            {
                dgvGDKiemCT.CurrentRow.Selected = true;
                SetGiayDangKiemChiTietButtonsStatus();
            }
        }

        private void SetGiayDangKiemButtonsStatus()
        {
            if (_mainPresenter.CurrentVehicle != null)
            {
                if (_mainPresenter.CurrentVehicle.GiayDangKiem != null)
                {
                    btnEdit_GDKiem.Enabled = btnDelete_GDKiem.Enabled = true;
                    btnEdit_GDKiem.BackgroundImage = Resources.edit;
                    btnDelete_GDKiem.BackgroundImage = Resources.delete;
                    btnAdd_GDKiem.Enabled = false;
                    btnAdd_GDKiem.BackgroundImage = Resources.add_disable;
                }
                else
                {
                    btnEdit_GDKiem.Enabled = btnDelete_GDKiem.Enabled = false;
                    btnEdit_GDKiem.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKiem.BackgroundImage = Resources.delete_disable;
                    btnAdd_GDKiem.Enabled = true;
                    btnAdd_GDKiem.BackgroundImage = Resources.add;
                }
            }
        }

        private void SetGiayDangKiemChiTietButtonsStatus()
        {
            if (_mainPresenter.CurrentVehicle != null)
            {
                if (_mainPresenter.CurrentVehicle.GiayDangKiem != null)
                {
                    btnAdd_GDKiem_CT.Enabled = true;
                    btnAdd_GDKiem_CT.BackgroundImage = Resources.add;

                    if (_mainPresenter.CurrentVehicle.GiayDangKiem.GiayDangKiemCTList != null)
                    {
                        btnEdit_GDKiem_CT.Enabled = btnDelete_GDKiem_CT.Enabled = true;
                        btnEdit_GDKiem_CT.BackgroundImage = Resources.edit;
                        btnDelete_GDKiem_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_GDKiem_CT.Enabled = btnDelete_GDKiem_CT.Enabled = false;
                        btnEdit_GDKiem_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_GDKiem_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_GDKiem_CT.Enabled = btnEdit_GDKiem_CT.Enabled = btnDelete_GDKiem_CT.Enabled = false;
                    btnAdd_GDKiem_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_GDKiem_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKiem_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetGiayDangKiemToControls(giay_dang_kiem gdk)
        {
            if (gdk == null)
            {
                lblGDKiem_MaGiay.Text = string.Empty;
                lblGDKiem_DonVi.Text = string.Empty;
                lblGDKiem_NhacNhoTruocNgay.Text = string.Empty;
                picGDKiem_HinhAnh.Image = null;
                lblGDKiem_GhiChu.Text = string.Empty;
                chkGDKiem_Status.Checked = false;
                lblGDKiem_NgayCapDauTien.Text = string.Empty;
                dgvGDKiemCT.DataSource = null;
            }
            else
            {
                lblGDKiem_MaGiay.Text = gdk.ma_giay;
                lblGDKiem_DonVi.Text = gdk.ten_don_vi;
                lblGDKiem_NhacNhoTruocNgay.Text = gdk.nhac_nho_truoc_ngay.ToString();
                picGDKiem_HinhAnh.Image = gdk.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(gdk.hinh_anh) : null;
                lblGDKiem_GhiChu.Text = gdk.ghi_chu;
                chkGDKiem_Status.Checked = gdk.status == "1";
                lblGDKiem_NgayCapDauTien.Text = gdk.ngay_cap_lan_dau.HasValue ? gdk.ngay_cap_lan_dau.Value.ToString("dd/MM/yyyy") : "N/A";

                dgvGDKiemCT.DataSource = gdk.GiayDangKiemCTList;
            }
        }

        private void picGDKiem_HinhAnh_Click(object sender, EventArgs e)
        {
            if (picGDKiem_HinhAnh.Image != null)
            {
                ShowImage(picGDKiem_HinhAnh.Image);
            }
        }

        private void picGDKiem_HinhAnh_MouseHover(object sender, EventArgs e)
        {
            picGDKiem_HinhAnh.Cursor = picGDKiem_HinhAnh.Image != null ? Cursors.Hand : Cursors.Default;
        }

        #endregion

        #region tab Giấy bảo trì đường bộ
        #endregion

        #region tab Giấy bảo hiểm nhân sự
        #endregion

        #region tab Giấy bảo hiểm thân xe
        #endregion

        #region tab Biên bản giao xe
        #endregion

        #region tab Biên bảo thu hồi
        #endregion

    }
}