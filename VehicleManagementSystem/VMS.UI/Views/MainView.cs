using System;
using System.Collections.Generic;
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
        private readonly MainPresenter _presenter;
        public MainView()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
            dgvXe.AutoGenerateColumns = false;
            dgvPhuTung.AutoGenerateColumns = false;
            dgvGDKyCT.AutoGenerateColumns = false;
            dgvGDKiemCT.AutoGenerateColumns = false;
            dgvGBTDBCT.AutoGenerateColumns = false;
            dgvGBHNSCT.AutoGenerateColumns = false;
            dgvGBHTXCT.AutoGenerateColumns = false;
            dgvBBGXCT.AutoGenerateColumns = false;
            dgvBBTH.AutoGenerateColumns = false;
            dgvLichSuTaiXe.AutoGenerateColumns = false;
            dgvLichSuKhauHao.AutoGenerateColumns = false;
            (dgvXe.Columns["colHinhAnh"]).DefaultCellStyle.NullValue = null;

            SetupImageViewer(picHinhAnh);
            SetupImageViewer(picGDKy_HinhAnh);
            SetupImageViewer(picGDKiem_HinhAnh);
            SetupImageViewer(picGBTDB_HinhAnh);
            SetupImageViewer(picGBHNS_HinhAnh);
            SetupImageViewer(picGBHTX_HinhAnh);

            ToolTip bbgx = new ToolTip();
            bbgx.SetToolTip(btnHistory_BBGX, "Xem lịch sử biên bản giao xe.");
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            _presenter.LoadVehiclesDataTable();
            _presenter.LoadThongTinXe();
        }

        #region IMainView Members
        public void LoadVehiclesDataTable(DataTable dt)
        {
            dgvXe.DataSource = dt;
        }

        public void RefreshDataGrid(DataView dv)
        {
            dgvXe.DataSource = dv;
        }

        public void LoadPhuTungDataTable(DataTable dt)
        {
            dgvPhuTung.DataSource = dt;
            SetPhuTungButtonsStatus(dt.Rows.Count > 0);
        }

        public void LoadGiayDangKy(giay_dang_ky entity)
        {
            SetGiayDangKyToControls(entity);
            SetGiayDangKyButtonsStatus();
            SetGiayDangKyChiTietButtonsStatus();
        }

        public void LoadGiayDangKiem(giay_dang_kiem entity)
        {
            SetGiayDangKiemToControls(entity);
            SetGiayDangKiemButtonsStatus();
            SetGiayDangKiemChiTietButtonsStatus();
        }

        public void LoadGiayBaoTriDuongBo(giay_bao_tri_duong_bo entity)
        {
            SetGBTDBToControls(entity);
            SetGBTDBButtonsStatus();
            SetGBTDBChiTietButtonsStatus();
        }

        public void LoadGiayBaoHiemNhanSu(giay_bao_hiem_nhan_su entity)
        {
            SetGBHNSToControls(entity);
            SetGBHNSButtonsStatus();
            SetGBHNSChiTietButtonsStatus();
        }

        public void LoadGiayBaoHiemThanXe(giay_bao_hiem_than_xe entity)
        {
            SetGBHTXToControls(entity);
            SetGBHTXButtonsStatus();
            SetGBHTXChiTietButtonsStatus();
        }

        public void LoadBienBanGiaoXe(bien_ban_giao_xe entity)
        {
            SetBBGXToControls(entity);
            SetBBGXButtonsStatus();
            SetBBGXChiTietButtonsStatus();
        }

        public void LoadBienBanThuHoi(List<bien_ban_thu_hoi> list)
        {
            dgvBBTH.DataSource = list;
            SetBBTHButtonsStatus(list != null && list.Count > 0);
        }

        public void SetupImageViewer(PictureBox pictureBox)
        {
            pictureBox.Click += pictureBox_Click;
            pictureBox.MouseHover += pictureBox_MouseHover;
        }

        public void LoadLichSuTaiXe(List<lich_su_tai_xe> list)
        {
            dgvLichSuTaiXe.DataSource = list;
            SetLichSuTaiXeButtonsStatus(list != null && list.Count > 0);
        }

        public void LoadLichSuKhauHao(List<lich_su_khau_hao> list, lich_su_khau_hao current)
        {
            dgvLichSuKhauHao.DataSource = list;
            SetLichSuKhauHaoDataToControls(current);
            SetLichSuKhauHaoButtonsStatus(list != null && list.Count > 0);
        }

        public void LoadThongTinXe(string info)
        {
            lblThongBao.Text = info;
        }

        void pictureBox_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.Cursor = pic.Image != null ? Cursors.Hand : Cursors.Default;
        }

        void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (pic.Image != null)
            {
                ImageViewer dlg = new ImageViewer(pic.Image);
                dlg.ShowDialog();
            }
        }

        private void ShowMessage(string msg, bool isSucess)
        {
            //lblThongBao.ForeColor = isSucess ? Color.Green : Color.Red;
            //lblThongBao.Text = msg;
        }

        #endregion

        #region Main - Thông tin xe

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditVehicleView dlg = new AddEditVehicleView();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập xe mới thành công !", true);
                _presenter.LoadVehiclesDataTable();
                _presenter.LoadThongTinXe();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow != null)
            {
                AddEditVehicleView dlg = new AddEditVehicleView(_presenter.CurrentVehicle);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật xe '{0}' thành công !", _presenter.CurrentVehicle.bien_so), true);
                    _presenter.LoadVehiclesDataTable();
                    _presenter.LoadThongTinXe();
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
                    if (_presenter.DeleteVehicle(ma_xe))
                    {
                        ShowMessage(string.Format("Xoá xe '{0}' thành công !", bien_so), true);
                        _presenter.LoadVehiclesDataTable();
                        _presenter.LoadThongTinXe();
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
            _presenter.RefreshVehicleDataGrid(chkActive.Checked, chkInActive.Checked, txtSearch.Text.Trim());
        }

        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.RefreshVehicleDataGrid(chkActive.Checked, chkInActive.Checked, txtSearch.Text.Trim());
        }

        private void dgvXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow != null)
            {
                dgvXe.CurrentRow.Selected = true;
                string ma_xe = dgvXe.CurrentRow.Cells[1].Value.ToString();
                _presenter.CurrentVehicle = _presenter.CurrentVehiclesList.Find(delegate(tai_san_xe item) { return item.ma_xe == ma_xe; });
                if (_presenter.CurrentVehicle != null)
                {
                    LoadTSXToControls(_presenter.CurrentVehicle);
                    _presenter.LoadLichSuKhauHao();
                    _presenter.LoadLichSuTaiXe();
                    _presenter.LoadPhuTungDataTable();
                    _presenter.LoadGiayDangKy();
                    _presenter.LoadGiayDangKiem();
                    _presenter.LoadGiayBaoTriDuongBo();
                    _presenter.LoadGiayBaoHiemNhanSu();
                    _presenter.LoadGiayBaoHiemThanXe();
                    _presenter.LoadBienBanGiaoXe(true);
                    _presenter.LoadBienBanThuHoi();
                }
            }
        }

        private void dgvXe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_Click(null, null);
            }
        }

        private void LoadTSXToControls(tai_san_xe entity)
        {
            lblBienSo.Text = entity.bien_so;
            lblHangXe.Text = entity.hang_san_xuat;
            lblLoaiXe.Text = entity.loai_xe;
            lblLoaiTaiSan.Text = entity.ten_lts;
            lblNamSanXuat.Text = entity.nam_san_xuat.ToString();
            lblSoNamSuDung.Text = entity.so_nam_su_dung.ToString();
            lblSoMay.Text = entity.so_may;
            lblSoKhung.Text = entity.so_khung;
            lblMau.Text = entity.mau;
            lblBinhNhienLieu.Text = entity.binh_nhien_lieu;
            lblLoaiNhienLieu.Text = entity.loai_nhien_lieu;
            lblTheTich.Text = entity.trong_tai_the_tich.ToString("N0");
            lblKhoiLuong.Text = entity.trong_tai_khoi_luong.ToString("N0");
            lblTongTrongLuong.Text = entity.tong_trong_luong.ToString("N0");
            lblNguyenGia.Text = entity.nguyen_gia.ToString("N0");
            lblNgayHieuLucKH.Text = entity.ti_le_khau_hao > 0 ? entity.ngay_hieu_luc_kh_str : "N/A";
            lblGiaTriKhauHao.Text = entity.gia_tri_khau_hao.ToString("N0");
            lblTiLeKhauHao.Text = entity.ti_le_khau_hao.ToString("N");
            lblGiaTriConLai.Text = entity.gia_tri_con_lai.ToString("N0");
            picHinhAnh.Image = entity.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(entity.hinh_anh) : null;
            lblGhiChu.Text = entity.ghi_chu;
            chkStatus.Checked = entity.status == "0";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _presenter.RefreshVehicleDataGrid(chkActive.Checked, chkInActive.Checked, txtSearch.Text.Trim());
        }

        #endregion

        #region tab Lịch sử khấu hao

        private void btnTinhKhauHao_LSKH_Click(object sender, EventArgs e)
        {
            string result = _presenter.TinhKhauHaoXe();
            if (string.IsNullOrEmpty(result))
            {
                _presenter.LoadThongTinXe();
                MessageBox.Show("Tính khấu hao xe thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format("Có lỗi phát sinh khi tính khấu hao xe '{0}' !", result), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_LSKH_Click(object sender, EventArgs e)
        {
            AddEditLichSuKhauHaoView dlg = new AddEditLichSuKhauHaoView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập tỉ lệ khấu hao mới thành công !", true);
                _presenter.LoadLichSuKhauHao();
            }
        }

        private void btnDelete_LSKH_Click(object sender, EventArgs e)
        {
            if (dgvLichSuKhauHao.CurrentRow != null)
            {
                lich_su_khau_hao entity = (lich_su_khau_hao)dgvLichSuKhauHao.CurrentRow.DataBoundItem;
                if (entity.status == "I")
                {
                    MessageBox.Show("Không thể xoá khấu hao mặc định của xe !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá khấu hao ngày '{0}' ?", entity.ngay_hieu_luc_str),"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_presenter.DeleteKhauHao(entity.ma_xe, entity.ngay_hieu_luc))
                        {
                            ShowMessage(string.Format("Xoá khấu hao ngày '{0}' thành công !", entity.ngay_hieu_luc_str), true);
                            _presenter.LoadLichSuKhauHao();
                        }
                        else
                        {
                            ShowMessage(string.Format("Xoá khấu hao ngày '{0}' thất bại !", entity.ngay_hieu_luc_str),false);
                        }
                    }
                }
            }
        }

        private void dgvLichSuKhauHao_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLichSuKhauHao.CurrentRow != null)
            {
                dgvLichSuKhauHao.CurrentRow.Selected = true;
                SetLichSuKhauHaoButtonsStatus(true);
            }
        }

        private void SetLichSuKhauHaoDataToControls(lich_su_khau_hao entity)
        {
            if (entity == null)
            {
                lblNguyenGia_LSKH.Text = "";
                lblGiaTriConLai_LSKH.Text = "";
                lblGiaTriKhauHao_LSKH.Text = "";
                lblTiLeKhauHao_LSKH.Text = "";
                lblNgayHieuLuc_LSKH.Text = "";
            }
            else
            {
                lblNguyenGia_LSKH.Text = entity.nguyen_gia.ToString("N0");
                lblGiaTriConLai_LSKH.Text = entity.gia_tri_con_lai.ToString("N0");
                lblGiaTriKhauHao_LSKH.Text = entity.gia_tri_khau_hao.ToString("N0");
                lblTiLeKhauHao_LSKH.Text = String.Format("{0} %", entity.ti_le_khau_hao.ToString("N"));
                lblNgayHieuLuc_LSKH.Text = entity.ngay_hieu_luc_str;
            }
        }

        private void SetLichSuKhauHaoButtonsStatus(bool isEnable)
        {
            if (isEnable)
            {
                btnDelete_LSKH.Enabled = true;
                btnDelete_LSKH.BackgroundImage = Resources.delete;
            }
            else
            {
                btnDelete_LSKH.Enabled = false;
                btnDelete_LSKH.BackgroundImage = Resources.delete_disable;
            }
        }

        #endregion

        #region tab Lịch sử tài xế

        private void btnAdd_LSTX_Click(object sender, EventArgs e)
        {
            AddEditLichSuTaiXeView dlg = new AddEditLichSuTaiXeView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập tài xế mới thành công !", true);
                _presenter.LoadLichSuTaiXe();
            }
        }

        private void btnEdit_LSTX_Click(object sender, EventArgs e)
        {
            lich_su_tai_xe entity = (lich_su_tai_xe) dgvLichSuTaiXe.CurrentRow.DataBoundItem;
            int index = dgvLichSuTaiXe.CurrentRow.Index;
            AddEditLichSuTaiXeView dlg = new AddEditLichSuTaiXeView(entity);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật tài xế '{0}' thành công !", entity.ten_tai_xe), true);
                _presenter.LoadLichSuTaiXe();
                dgvLichSuTaiXe.ClearSelection();
                dgvLichSuTaiXe.CurrentCell = dgvLichSuTaiXe[1, index];
                dgvLichSuTaiXe.Rows[index].Selected = true;
            }
        }

        private void btnDelete_LSTX_Click(object sender, EventArgs e)
        {
            if (dgvLichSuTaiXe.CurrentRow != null)
            {
                lich_su_tai_xe entity = (lich_su_tai_xe) dgvLichSuTaiXe.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", entity.ten_tai_xe), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_presenter.DeleteTaiXe(entity.ma_tai_xe))
                    {
                        ShowMessage(string.Format("Xoá '{0}' thành công !", entity.ten_tai_xe), true);
                        _presenter.LoadLichSuTaiXe();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá '{0}' thất bại !", entity.ten_tai_xe), false);
                    }
                }
            }
        }

        private void dgvLichSuTaiXe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLichSuTaiXe.CurrentRow != null)
            {
                dgvLichSuTaiXe.CurrentRow.Selected = true;
                SetLichSuTaiXeButtonsStatus(true);
            }
        }

        private void dgvLichSuTaiXe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_LSTX_Click(null, null);
            }
        }

        private void SetLichSuTaiXeButtonsStatus(bool isEnable)
        {
            if (isEnable)
            {
                btnEdit_LSTX.Enabled = true;
                btnDelete_LSTX.Enabled = true;
                btnEdit_LSTX.BackgroundImage = Resources.edit;
                btnDelete_LSTX.BackgroundImage = Resources.delete;
            }
            else
            {
                btnEdit_LSTX.Enabled = false;
                btnDelete_LSTX.Enabled = false;
                btnEdit_LSTX.BackgroundImage = Resources.edit_disable;
                btnDelete_LSTX.BackgroundImage = Resources.delete_disable;
            }
        }

        #endregion
             
        #region tab Phụ tùng

        private void btnAdd_PhuTung_Click(object sender, EventArgs e)
        {
            if (dgvXe.CurrentRow != null)
            {
                AddEditPhuTungView dlg = new AddEditPhuTungView(_presenter.CurrentVehicle.ma_xe);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage("Nhập phụ tùng mới thành công !", true);
                    _presenter.LoadPhuTungDataTable();
                }
            }
        }

        private void btnEdit_PhuTung_Click(object sender, EventArgs e)
        {
            if (dgvPhuTung.CurrentRow != null)
            {
                DataRow row = ((DataRowView)dgvPhuTung.CurrentRow.DataBoundItem).Row;
                phu_tung entity = ConvertionHelper.ToEntity<phu_tung>(row);
                int index = dgvPhuTung.CurrentRow.Index;
                AddEditPhuTungView dlg = new AddEditPhuTungView(entity);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật phụ tùng '{0}' thành công !", entity.ten_tai_san), true);
                    _presenter.LoadPhuTungDataTable();
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
                    if (_presenter.DeletePhuTung(ma_tai_san))
                    {
                        ShowMessage(string.Format("Xoá '{0}' thành công !", ten_tai_san), true);
                        _presenter.LoadPhuTungDataTable();
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
                btnEdit_PhuTung.Enabled = true;
                btnDelete_PhuTung.Enabled = true;
                btnEdit_PhuTung.BackgroundImage = Resources.edit;
                btnDelete_PhuTung.BackgroundImage = Resources.delete;
            }
            else
            {
                btnEdit_PhuTung.Enabled = false;
                btnDelete_PhuTung.Enabled = false;
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
            if (e.RowIndex != -1)
            {
                btnEdit_PhuTung_Click(null, null);
            }
        }

        #endregion
        
        #region tab Giấy đăng ký

        private void btnAdd_GDKy_Click(object sender, EventArgs e)
        {
            AddEditGiayDangKyView dlg = new AddEditGiayDangKyView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy đăng ký thành công !", true);
                _presenter.LoadGiayDangKy();
            }
        }

        private void btnEdit_GDKy_Click(object sender, EventArgs e)
        {
            AddEditGiayDangKyView dlg = new AddEditGiayDangKyView(_presenter.CurrentVehicle.GiayDangKy);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật giấy đăng ký '{0}' thành công !", _presenter.CurrentVehicle.GiayDangKy.ma_giay), true);
                _presenter.LoadGiayDangKy();
            }
        }

        private void btnDelete_GDKy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", _presenter.CurrentVehicle.GiayDangKy.ma_giay), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_presenter.DeleteGiayDangKy(_presenter.CurrentVehicle.GiayDangKy.ma_giay))
                {
                    ShowMessage(string.Format("Xoá '{0}' thành công !", _presenter.CurrentVehicle.GiayDangKy.ma_giay), true);
                    _presenter.LoadGiayDangKy();
                }
                else
                {
                    ShowMessage(string.Format("Xoá '{0}' thất bại !", _presenter.CurrentVehicle.GiayDangKy.ma_giay), false);
                }
            }
        }

        private void btnAdd_GDKy_CT_Click(object sender, EventArgs e)
        {
            AddEditGiayDangKyChiTietView dlg = new AddEditGiayDangKyChiTietView(_presenter.CurrentVehicle.GiayDangKy.ma_giay);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết giấy đăng ký thành công !", true);
                _presenter.LoadGiayDangKy();
            }
        }

        private void btnEdit_GDKy_CT_Click(object sender, EventArgs e)
        {
            if (dgvGDKyCT.CurrentRow != null)
            {
                giay_dang_ky_ct entity = (giay_dang_ky_ct)dgvGDKyCT.CurrentRow.DataBoundItem;
                int index = dgvGDKyCT.CurrentRow.Index;
                AddEditGiayDangKyChiTietView dlg = new AddEditGiayDangKyChiTietView(entity);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật giấy đăng ký ngày '{0}' thành công !", entity.ngay_cap_str), true);
                    _presenter.LoadGiayDangKy();
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
                giay_dang_ky_ct entity = (giay_dang_ky_ct)dgvGDKyCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá giấy đăng ký ngày '{0}' ?", entity.ngay_cap_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_presenter.DeleteGiayDangKyChiTiet(entity.ma_giay, entity.ngay_cap))
                    {
                        ShowMessage(string.Format("Xoá giấy đăng ký ngày '{0}' thành công !", entity.ngay_cap_str), true);
                        _presenter.LoadGiayDangKy();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá giấy đăng ký ngày '{0}' thất bại !", entity.ngay_cap_str), false);
                    }
                }
            }
        }

        private void dgvGDKyCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_GDKy_CT_Click(null, null);
            }
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
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayDangKy != null)
                {
                    btnEdit_GDKy.Enabled = true;
                    btnDelete_GDKy.Enabled = true;
                    btnEdit_GDKy.BackgroundImage = Resources.edit;
                    btnDelete_GDKy.BackgroundImage = Resources.delete;
                    btnAdd_GDKy.Enabled = false;
                    btnAdd_GDKy.BackgroundImage = Resources.add_disable;
                }
                else
                {
                    btnEdit_GDKy.Enabled = false;
                    btnDelete_GDKy.Enabled = false;
                    btnEdit_GDKy.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKy.BackgroundImage = Resources.delete_disable;
                    btnAdd_GDKy.Enabled = true;
                    btnAdd_GDKy.BackgroundImage = Resources.add;
                }
            }
        }

        private void SetGiayDangKyChiTietButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayDangKy != null)
                {
                    btnAdd_GDKy_CT.Enabled = true;
                    btnAdd_GDKy_CT.BackgroundImage = Resources.add;

                    if (_presenter.CurrentVehicle.GiayDangKy.DetailList != null)
                    {
                        btnEdit_GDKy_CT.Enabled = true;
                        btnDelete_GDKy_CT.Enabled = true;
                        btnEdit_GDKy_CT.BackgroundImage = Resources.edit;
                        btnDelete_GDKy_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_GDKy_CT.Enabled = false;
                        btnDelete_GDKy_CT.Enabled = false;
                        btnEdit_GDKy_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_GDKy_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_GDKy_CT.Enabled = false;
                    btnEdit_GDKy_CT.Enabled = false;
                    btnDelete_GDKy_CT.Enabled = false;
                    btnAdd_GDKy_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_GDKy_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKy_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetGiayDangKyToControls(giay_dang_ky entity)
        {
            if (entity == null)
            {
                lblGDKy_MaGiay.Text = string.Empty;
                lblGDKy_DonVi.Text = string.Empty;
                lblGDKy_NhacNhoTruocNgay.Text = string.Empty;
                picGDKy_HinhAnh.Image = null;
                txtGDKy_GhiChu.Text = string.Empty;
                chkGDKy_Status.Checked = false;
                lblGDKy_NgayCapDauTien.Text = string.Empty;
                dgvGDKyCT.DataSource = null;
            }
            else
            {
                lblGDKy_MaGiay.Text = entity.ma_giay;
                lblGDKy_DonVi.Text = entity.ten_don_vi;
                lblGDKy_NhacNhoTruocNgay.Text = entity.nhac_nho_truoc_ngay.ToString();
                picGDKy_HinhAnh.Image = entity.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(entity.hinh_anh) : null;
                txtGDKy_GhiChu.Text = entity.ghi_chu;
                chkGDKy_Status.Checked = entity.status == "Y";
                lblGDKy_NgayCapDauTien.Text = entity.ngay_cap_lan_dau.HasValue ? entity.ngay_cap_lan_dau.Value.ToString("dd/MM/yyyy") : "N/A";

                dgvGDKyCT.DataSource = entity.DetailList;
            }
        }

        #endregion

        #region tab Giấy đăng kiểm

        private void btnAdd_GDKiem_Click(object sender, EventArgs e)
        {
            AddEditGiayDangKiemView dlg = new AddEditGiayDangKiemView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy đăng kiểm thành công !", true);
                _presenter.LoadGiayDangKiem();
            }
        }

        private void btnEdit_GDKiem_Click(object sender, EventArgs e)
        {
            AddEditGiayDangKiemView dlg = new AddEditGiayDangKiemView(_presenter.CurrentVehicle.GiayDangKiem);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật giấy đăng kiểm '{0}' thành công !", _presenter.CurrentVehicle.GiayDangKiem.ma_giay), true);
                _presenter.LoadGiayDangKiem();
            }
        }

        private void btnDelete_GDKiem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", _presenter.CurrentVehicle.GiayDangKiem.ma_giay), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_presenter.DeleteGiayDangKiem(_presenter.CurrentVehicle.GiayDangKiem.ma_giay))
                {
                    ShowMessage(string.Format("Xoá '{0}' thành công !", _presenter.CurrentVehicle.GiayDangKiem.ma_giay), true);
                    _presenter.LoadGiayDangKiem();
                }
                else
                {
                    ShowMessage(string.Format("Xoá '{0}' thất bại !", _presenter.CurrentVehicle.GiayDangKiem.ma_giay), false);
                }
            }
        }

        private void btnAdd_GDKiem_CT_Click(object sender, EventArgs e)
        {
            AddEditGiayDangKiemChiTietView dlg = new AddEditGiayDangKiemChiTietView(_presenter.CurrentVehicle.GiayDangKiem.ma_giay);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết giấy đăng kiểm thành công !", true);
                _presenter.LoadGiayDangKiem();
            }
        }

        private void btnEdit_GDKiem_CT_Click(object sender, EventArgs e)
        {
            if (dgvGDKiemCT.CurrentRow != null)
            {
                giay_dang_kiem_ct entity = (giay_dang_kiem_ct)dgvGDKiemCT.CurrentRow.DataBoundItem;
                int index = dgvGDKiemCT.CurrentRow.Index;
                AddEditGiayDangKiemChiTietView dlg = new AddEditGiayDangKiemChiTietView(entity);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật giấy đăng kiểm ngày '{0}' thành công !", entity.ngay_cap_str), true);
                    _presenter.LoadGiayDangKiem();
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
                giay_dang_kiem_ct entity = (giay_dang_kiem_ct)dgvGDKiemCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá giấy đăng kiểm ngày '{0}' ?", entity.ngay_cap_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_presenter.DeleteGiayDangKiemChiTiet(entity.ma_giay, entity.ngay_cap))
                    {
                        ShowMessage(string.Format("Xoá giấy đăng kiểm ngày '{0}' thành công !", entity.ngay_cap_str), true);
                        _presenter.LoadGiayDangKiem();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá giấy đăng kiểm ngày '{0}' thất bại !", entity.ngay_cap_str), false);
                    }
                }
            }
        }

        private void dgvGDKiemCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_GDKiem_CT_Click(null, null);
            }
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
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayDangKiem != null)
                {
                    btnEdit_GDKiem.Enabled = true; 
                    btnDelete_GDKiem.Enabled = true;
                    btnEdit_GDKiem.BackgroundImage = Resources.edit;
                    btnDelete_GDKiem.BackgroundImage = Resources.delete;
                    btnAdd_GDKiem.Enabled = false;
                    btnAdd_GDKiem.BackgroundImage = Resources.add_disable;
                }
                else
                {
                    btnEdit_GDKiem.Enabled = false;
                    btnDelete_GDKiem.Enabled = false;
                    btnEdit_GDKiem.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKiem.BackgroundImage = Resources.delete_disable;
                    btnAdd_GDKiem.Enabled = true;
                    btnAdd_GDKiem.BackgroundImage = Resources.add;
                }
            }
        }

        private void SetGiayDangKiemChiTietButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayDangKiem != null)
                {
                    btnAdd_GDKiem_CT.Enabled = true;
                    btnAdd_GDKiem_CT.BackgroundImage = Resources.add;

                    if (_presenter.CurrentVehicle.GiayDangKiem.DetailList != null)
                    {
                        btnEdit_GDKiem_CT.Enabled = true;
                        btnDelete_GDKiem_CT.Enabled = true;
                        btnEdit_GDKiem_CT.BackgroundImage = Resources.edit;
                        btnDelete_GDKiem_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_GDKiem_CT.Enabled = false;
                        btnDelete_GDKiem_CT.Enabled = false;
                        btnEdit_GDKiem_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_GDKiem_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_GDKiem_CT.Enabled = false;
                    btnEdit_GDKiem_CT.Enabled = false;
                    btnDelete_GDKiem_CT.Enabled = false;
                    btnAdd_GDKiem_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_GDKiem_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_GDKiem_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetGiayDangKiemToControls(giay_dang_kiem entity)
        {
            if (entity == null)
            {
                lblGDKiem_MaGiay.Text = string.Empty;
                lblGDKiem_DonVi.Text = string.Empty;
                lblGDKiem_NhacNhoTruocNgay.Text = string.Empty;
                picGDKiem_HinhAnh.Image = null;
                txtGDKiem_GhiChu.Text = string.Empty;
                chkGDKiem_Status.Checked = false;
                lblGDKiem_NgayCapDauTien.Text = string.Empty;
                dgvGDKiemCT.DataSource = null;
            }
            else
            {
                lblGDKiem_MaGiay.Text = entity.ma_giay;
                lblGDKiem_DonVi.Text = entity.ten_don_vi;
                lblGDKiem_NhacNhoTruocNgay.Text = entity.nhac_nho_truoc_ngay.ToString();
                picGDKiem_HinhAnh.Image = entity.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(entity.hinh_anh) : null;
                txtGDKiem_GhiChu.Text = entity.ghi_chu;
                chkGDKiem_Status.Checked = entity.status == "Y";
                lblGDKiem_NgayCapDauTien.Text = entity.ngay_cap_lan_dau.HasValue ? entity.ngay_cap_lan_dau.Value.ToString("dd/MM/yyyy") : "N/A";

                dgvGDKiemCT.DataSource = entity.DetailList;
            }
        }

        #endregion

        #region tab Giấy bảo trì đường bộ

        private void btnAdd_GBTDB_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoTriDuongBoView dlg = new AddEditGiayBaoTriDuongBoView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy bảo trì đường bộ thành công !", true);
                _presenter.LoadGiayBaoTriDuongBo();
            }
        }

        private void btnEdit_GBTDB_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoTriDuongBoView dlg = new AddEditGiayBaoTriDuongBoView(_presenter.CurrentVehicle.GiayBaoTriDuongBo);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật giấy bảo trì đường bộ '{0}' thành công !", _presenter.CurrentVehicle.GiayBaoTriDuongBo.ma_giay), true);
                _presenter.LoadGiayBaoTriDuongBo();
            }
        }

        private void btnDelete_GBTDB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", _presenter.CurrentVehicle.GiayBaoTriDuongBo.ma_giay), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_presenter.DeleteGiayBaoTriDuongBo(_presenter.CurrentVehicle.GiayBaoTriDuongBo.ma_giay))
                {
                    ShowMessage(string.Format("Xoá '{0}' thành công !", _presenter.CurrentVehicle.GiayBaoTriDuongBo.ma_giay), true);
                    _presenter.LoadGiayBaoTriDuongBo();
                }
                else
                {
                    ShowMessage(string.Format("Xoá '{0}' thất bại !", _presenter.CurrentVehicle.GiayBaoTriDuongBo.ma_giay), false);
                }
            }
        }

        private void btnAdd_GBTDB_CT_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoTriDuongBoChiTietView dlg = new AddEditGiayBaoTriDuongBoChiTietView(_presenter.CurrentVehicle.GiayBaoTriDuongBo.ma_giay);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết giấy bảo trì đường bộ thành công !", true);
                _presenter.LoadGiayBaoTriDuongBo();
            }
        }

        private void btnEdit_GBTDB_CT_Click(object sender, EventArgs e)
        {
            if (dgvGBTDBCT.CurrentRow != null)
            {
                giay_bao_tri_duong_bo_ct entity = (giay_bao_tri_duong_bo_ct)dgvGBTDBCT.CurrentRow.DataBoundItem;
                int index = dgvGBTDBCT.CurrentRow.Index;
                AddEditGiayBaoTriDuongBoChiTietView dlg = new AddEditGiayBaoTriDuongBoChiTietView(entity);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật giấy bảo trì đường bộ ngày '{0}' thành công !", entity.ngay_cap_str), true);
                    _presenter.LoadGiayBaoTriDuongBo();
                    dgvGBTDBCT.ClearSelection();
                    dgvGBTDBCT.CurrentCell = dgvGBTDBCT[1, index];
                    dgvGBTDBCT.Rows[index].Selected = true;
                }
            }
        }

        private void btnDelete_GBTDB_CT_Click(object sender, EventArgs e)
        {
            if (dgvGBTDBCT.CurrentRow != null)
            {
                giay_bao_tri_duong_bo_ct entity = (giay_bao_tri_duong_bo_ct)dgvGBTDBCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá giấy bảo trì đường bộ ngày '{0}' ?", entity.ngay_cap_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_presenter.DeleteGiayBaoTriDuongBoChiTiet(entity.ma_giay, entity.ngay_cap))
                    {
                        ShowMessage(string.Format("Xoá giấy bảo trì đường bộ ngày '{0}' thành công !", entity.ngay_cap_str), true);
                        _presenter.LoadGiayBaoTriDuongBo();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá giấy bảo trì đường bộ ngày '{0}' thất bại !", entity.ngay_cap_str), false);
                    }
                }
            }
        }

        private void dgvGBTDBCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_GBTDB_CT_Click(null, null);
            }
        }

        private void dgvGBTDBCT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGBTDBCT.CurrentRow != null)
            {
                dgvGBTDBCT.CurrentRow.Selected = true;
                SetGBTDBButtonsStatus();
            }
        }

        private void SetGBTDBButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayBaoTriDuongBo != null)
                {
                    btnEdit_GBTDB.Enabled = true;
                    btnDelete_GBTDB.Enabled = true;
                    btnEdit_GBTDB.BackgroundImage = Resources.edit;
                    btnDelete_GBTDB.BackgroundImage = Resources.delete;
                    btnAdd_GBTDB.Enabled = false;
                    btnAdd_GBTDB.BackgroundImage = Resources.add_disable;
                }
                else
                {
                    btnEdit_GBTDB.Enabled = false;
                    btnDelete_GBTDB.Enabled = false;
                    btnEdit_GBTDB.BackgroundImage = Resources.edit_disable;
                    btnDelete_GBTDB.BackgroundImage = Resources.delete_disable;
                    btnAdd_GBTDB.Enabled = true;
                    btnAdd_GBTDB.BackgroundImage = Resources.add;
                }
            }
        }

        private void SetGBTDBChiTietButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayBaoTriDuongBo != null)
                {
                    btnAdd_GBTDB_CT.Enabled = true;
                    btnAdd_GBTDB_CT.BackgroundImage = Resources.add;

                    if (_presenter.CurrentVehicle.GiayBaoTriDuongBo.DetailList != null)
                    {
                        btnEdit_GBTDB_CT.Enabled = true;
                        btnDelete_GBTDB_CT.Enabled = true;
                        btnEdit_GBTDB_CT.BackgroundImage = Resources.edit;
                        btnDelete_GBTDB_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_GBTDB_CT.Enabled = false;
                        btnDelete_GBTDB_CT.Enabled = false;
                        btnEdit_GBTDB_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_GBTDB_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_GBTDB_CT.Enabled = false;
                    btnEdit_GBTDB_CT.Enabled = false;
                    btnDelete_GBTDB_CT.Enabled = false;
                    btnAdd_GBTDB_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_GBTDB_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_GBTDB_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetGBTDBToControls(giay_bao_tri_duong_bo entity)
        {
            if (entity == null)
            {
                lblGBTDB_MaGiay.Text = string.Empty;
                lblGBTDB_DonVi.Text = string.Empty;
                lblGBTDB_NhacNhoTruocNgay.Text = string.Empty;
                picGBTDB_HinhAnh.Image = null;
                txtGBTDB_GhiChu.Text = string.Empty;
                chkGBTDB_Status.Checked = false;
                lblGBTDB_NgayCapDauTien.Text = string.Empty;
                dgvGBTDBCT.DataSource = null;
            }
            else
            {
                lblGBTDB_MaGiay.Text = entity.ma_giay;
                lblGBTDB_DonVi.Text = entity.ten_don_vi;
                lblGBTDB_NhacNhoTruocNgay.Text = entity.nhac_nho_truoc_ngay.ToString();
                picGBTDB_HinhAnh.Image = entity.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(entity.hinh_anh) : null;
                txtGBTDB_GhiChu.Text = entity.ghi_chu;
                chkGBTDB_Status.Checked = entity.status == "Y";
                lblGBTDB_NgayCapDauTien.Text = entity.ngay_cap_lan_dau.HasValue ? entity.ngay_cap_lan_dau.Value.ToString("dd/MM/yyyy") : "N/A";

                dgvGBTDBCT.DataSource = entity.DetailList;
            }
        }

        #endregion

        #region tab Giấy bảo hiểm nhân sự

        private void btnAdd_GBHNS_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoHiemNhanSuView dlg = new AddEditGiayBaoHiemNhanSuView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy bảo hiểm nhân sự thành công !", true);
                _presenter.LoadGiayBaoHiemNhanSu();
            }
        }

        private void btnEdit_GBHNS_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoHiemNhanSuView dlg = new AddEditGiayBaoHiemNhanSuView(_presenter.CurrentVehicle.GiayBaoHiemNhanSu);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật giấy bảo hiểm nhân sự '{0}' thành công !", _presenter.CurrentVehicle.GiayBaoHiemNhanSu.ma_giay), true);
                _presenter.LoadGiayBaoHiemNhanSu();
            }
        }

        private void btnDelete_GBHNS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", _presenter.CurrentVehicle.GiayBaoHiemNhanSu.ma_giay), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_presenter.DeleteGiayBaoHiemNhanSu(_presenter.CurrentVehicle.GiayBaoHiemNhanSu.ma_giay))
                {
                    ShowMessage(string.Format("Xoá '{0}' thành công !", _presenter.CurrentVehicle.GiayBaoHiemNhanSu.ma_giay), true);
                    _presenter.LoadGiayBaoHiemNhanSu();
                }
                else
                {
                    ShowMessage(string.Format("Xoá '{0}' thất bại !", _presenter.CurrentVehicle.GiayBaoHiemNhanSu.ma_giay), false);
                }
            }
        }

        private void btnAdd_GBHNS_CT_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoHiemNhanSuChiTietView dlg = new AddEditGiayBaoHiemNhanSuChiTietView(_presenter.CurrentVehicle.GiayBaoHiemNhanSu.ma_giay);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết giấy bảo hiểm nhân sự thành công !", true);
                _presenter.LoadGiayBaoHiemNhanSu();
            }
        }

        private void btnEdit_GBHNS_CT_Click(object sender, EventArgs e)
        {
            if (dgvGBHNSCT.CurrentRow != null)
            {
                giay_bao_hiem_nhan_su_ct entity = (giay_bao_hiem_nhan_su_ct)dgvGBHNSCT.CurrentRow.DataBoundItem;
                int index = dgvGBHNSCT.CurrentRow.Index;
                AddEditGiayBaoHiemNhanSuChiTietView dlg = new AddEditGiayBaoHiemNhanSuChiTietView(entity);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật giấy bảo hiểm nhân sự ngày '{0}' thành công !", entity.ngay_cap_str), true);
                    _presenter.LoadGiayBaoHiemNhanSu();
                    dgvGBHNSCT.ClearSelection();
                    dgvGBHNSCT.CurrentCell = dgvGBHNSCT[1, index];
                    dgvGBHNSCT.Rows[index].Selected = true;
                }
            }
        }

        private void btnDelete_GBHNS_CT_Click(object sender, EventArgs e)
        {
            if (dgvGBHNSCT.CurrentRow != null)
            {
                giay_bao_hiem_nhan_su_ct entity = (giay_bao_hiem_nhan_su_ct)dgvGBHNSCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá giấy bảo hiểm nhân sự ngày '{0}' ?", entity.ngay_cap_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_presenter.DeleteGiayBaoHiemNhanSuChiTiet(entity.ma_giay, entity.ngay_cap))
                    {
                        ShowMessage(string.Format("Xoá giấy bảo hiểm nhân sự ngày '{0}' thành công !", entity.ngay_cap_str), true);
                        _presenter.LoadGiayBaoHiemNhanSu();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá giấy bảo hiểm nhân sự ngày '{0}' thất bại !", entity.ngay_cap_str), false);
                    }
                }
            }
        }

        private void dgvGBHNSCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_GBHNS_CT_Click(null, null);
            }
        }

        private void dgvGBHNSCT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGBHNSCT.CurrentRow != null)
            {
                dgvGBHNSCT.CurrentRow.Selected = true;
                SetGBHNSButtonsStatus();
            }
        }

        private void SetGBHNSButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayBaoHiemNhanSu != null)
                {
                    btnEdit_GBHNS.Enabled = true;
                    btnDelete_GBHNS.Enabled = true;
                    btnEdit_GBHNS.BackgroundImage = Resources.edit;
                    btnDelete_GBHNS.BackgroundImage = Resources.delete;
                    btnAdd_GBHNS.Enabled = false;
                    btnAdd_GBHNS.BackgroundImage = Resources.add_disable;
                }
                else
                {
                    btnEdit_GBHNS.Enabled = false;
                    btnDelete_GBHNS.Enabled = false;
                    btnEdit_GBHNS.BackgroundImage = Resources.edit_disable;
                    btnDelete_GBHNS.BackgroundImage = Resources.delete_disable;
                    btnAdd_GBHNS.Enabled = true;
                    btnAdd_GBHNS.BackgroundImage = Resources.add;
                }
            }
        }

        private void SetGBHNSChiTietButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayBaoHiemNhanSu != null)
                {
                    btnAdd_GBHNS_CT.Enabled = true;
                    btnAdd_GBHNS_CT.BackgroundImage = Resources.add;

                    if (_presenter.CurrentVehicle.GiayBaoHiemNhanSu.DetailList != null)
                    {
                        btnEdit_GBHNS_CT.Enabled = true;
                        btnDelete_GBHNS_CT.Enabled = true;
                        btnEdit_GBHNS_CT.BackgroundImage = Resources.edit;
                        btnDelete_GBHNS_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_GBHNS_CT.Enabled = false;
                        btnDelete_GBHNS_CT.Enabled = false;
                        btnEdit_GBHNS_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_GBHNS_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_GBHNS_CT.Enabled = false;
                    btnEdit_GBHNS_CT.Enabled = false;
                    btnDelete_GBHNS_CT.Enabled = false;
                    btnAdd_GBHNS_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_GBHNS_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_GBHNS_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetGBHNSToControls(giay_bao_hiem_nhan_su entity)
        {
            if (entity == null)
            {
                lblGBHNS_MaGiay.Text = string.Empty;
                lblGBHNS_DonVi.Text = string.Empty;
                lblGBHNS_NhacNhoTruocNgay.Text = string.Empty;
                picGBHNS_HinhAnh.Image = null;
                txtGBHNS_GhiChu.Text = string.Empty;
                chkGBHNS_Status.Checked = false;
                lblGBHNS_NgayCapDauTien.Text = string.Empty;
                dgvGBHNSCT.DataSource = null;
            }
            else
            {
                lblGBHNS_MaGiay.Text = entity.ma_giay;
                lblGBHNS_DonVi.Text = entity.ten_don_vi;
                lblGBHNS_NhacNhoTruocNgay.Text = entity.nhac_nho_truoc_ngay.ToString();
                picGBHNS_HinhAnh.Image = entity.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(entity.hinh_anh) : null;
                txtGBHNS_GhiChu.Text = entity.ghi_chu;
                chkGBHNS_Status.Checked = entity.status == "Y";
                lblGBHNS_NgayCapDauTien.Text = entity.ngay_cap_lan_dau.HasValue ? entity.ngay_cap_lan_dau.Value.ToString("dd/MM/yyyy") : "N/A";

                dgvGBHNSCT.DataSource = entity.DetailList;
            }
        }

        #endregion

        #region tab Giấy bảo hiểm thân xe

        private void btnAdd_GBHTX_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoHiemThanXeView dlg = new AddEditGiayBaoHiemThanXeView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy bảo hiểm thân xe thành công !", true);
                _presenter.LoadGiayBaoHiemThanXe();
            }
        }

        private void btnEdit_GBHTX_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoHiemThanXeView dlg = new AddEditGiayBaoHiemThanXeView(_presenter.CurrentVehicle.GiayBaoHiemThanXe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật giấy bảo hiểm thân xe '{0}' thành công !", _presenter.CurrentVehicle.GiayBaoHiemThanXe.ma_giay), true);
                _presenter.LoadGiayBaoHiemThanXe();
            }
        }

        private void btnDelete_GBHTX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá '{0}' ?", _presenter.CurrentVehicle.GiayBaoHiemThanXe.ma_giay), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_presenter.DeleteGiayBaoHiemThanXe(_presenter.CurrentVehicle.GiayBaoHiemThanXe.ma_giay))
                {
                    ShowMessage(string.Format("Xoá '{0}' thành công !", _presenter.CurrentVehicle.GiayBaoHiemThanXe.ma_giay), true);
                    _presenter.LoadGiayBaoHiemThanXe();
                }
                else
                {
                    ShowMessage(string.Format("Xoá '{0}' thất bại !", _presenter.CurrentVehicle.GiayBaoHiemThanXe.ma_giay), false);
                }
            }
        }

        private void btnAdd_GBHTX_CT_Click(object sender, EventArgs e)
        {
            AddEditGiayBaoHiemThanXeChiTietView dlg = new AddEditGiayBaoHiemThanXeChiTietView(_presenter.CurrentVehicle.GiayBaoHiemThanXe.ma_giay);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết giấy bảo hiểm thân xe thành công !", true);
                _presenter.LoadGiayBaoHiemThanXe();
            }
        }

        private void btnEdit_GBHTX_CT_Click(object sender, EventArgs e)
        {
            if (dgvGBHTXCT.CurrentRow != null)
            {
                giay_bao_hiem_than_xe_ct entity = (giay_bao_hiem_than_xe_ct)dgvGBHTXCT.CurrentRow.DataBoundItem;
                int index = dgvGBHTXCT.CurrentRow.Index;
                AddEditGiayBaoHiemThanXeChiTietView dlg = new AddEditGiayBaoHiemThanXeChiTietView(entity);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật giấy bảo hiểm thân xe ngày '{0}' thành công !", entity.ngay_cap_str), true);
                    _presenter.LoadGiayBaoHiemThanXe();
                    dgvGBHTXCT.ClearSelection();
                    dgvGBHTXCT.CurrentCell = dgvGBHTXCT[1, index];
                    dgvGBHTXCT.Rows[index].Selected = true;
                }
            }
        }

        private void btnDelete_GBHTX_CT_Click(object sender, EventArgs e)
        {
            if (dgvGBHTXCT.CurrentRow != null)
            {
                giay_bao_hiem_than_xe_ct entity = (giay_bao_hiem_than_xe_ct)dgvGBHTXCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá giấy bảo hiểm thân xe ngày '{0}' ?", entity.ngay_cap_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_presenter.DeleteGiayBaoHiemThanXeChiTiet(entity.ma_giay, entity.ngay_cap))
                    {
                        ShowMessage(string.Format("Xoá giấy bảo hiểm thân xe ngày '{0}' thành công !", entity.ngay_cap_str), true);
                        _presenter.LoadGiayBaoHiemThanXe();
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá giấy bảo hiểm thân xe ngày '{0}' thất bại !", entity.ngay_cap_str), false);
                    }
                }
            }
        }

        private void dgvGBHTXCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_GBHTX_CT_Click(null, null);
            }
        }

        private void dgvGBHTXCT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGBHTXCT.CurrentRow != null)
            {
                dgvGBHTXCT.CurrentRow.Selected = true;
                SetGBHTXButtonsStatus();
            }
        }

        private void SetGBHTXButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayBaoHiemThanXe != null)
                {
                    btnEdit_GBHTX.Enabled = true;
                    btnDelete_GBHTX.Enabled = true;
                    btnEdit_GBHTX.BackgroundImage = Resources.edit;
                    btnDelete_GBHTX.BackgroundImage = Resources.delete;
                    btnAdd_GBHTX.Enabled = false;
                    btnAdd_GBHTX.BackgroundImage = Resources.add_disable;
                }
                else
                {
                    btnEdit_GBHTX.Enabled = false;
                    btnDelete_GBHTX.Enabled = false;
                    btnEdit_GBHTX.BackgroundImage = Resources.edit_disable;
                    btnDelete_GBHTX.BackgroundImage = Resources.delete_disable;
                    btnAdd_GBHTX.Enabled = true;
                    btnAdd_GBHTX.BackgroundImage = Resources.add;
                }
            }
        }

        private void SetGBHTXChiTietButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.GiayBaoHiemThanXe != null)
                {
                    btnAdd_GBHTX_CT.Enabled = true;
                    btnAdd_GBHTX_CT.BackgroundImage = Resources.add;

                    if (_presenter.CurrentVehicle.GiayBaoHiemThanXe.DetailList != null)
                    {
                        btnEdit_GBHTX_CT.Enabled = true;
                        btnDelete_GBHTX_CT.Enabled = true;
                        btnEdit_GBHTX_CT.BackgroundImage = Resources.edit;
                        btnDelete_GBHTX_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_GBHTX_CT.Enabled = false;
                        btnDelete_GBHTX_CT.Enabled = false;
                        btnEdit_GBHTX_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_GBHTX_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_GBHTX_CT.Enabled = false;
                    btnEdit_GBHTX_CT.Enabled = false;
                    btnDelete_GBHTX_CT.Enabled = false;
                    btnAdd_GBHTX_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_GBHTX_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_GBHTX_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetGBHTXToControls(giay_bao_hiem_than_xe entity)
        {
            if (entity == null)
            {
                lblGBHTX_MaGiay.Text = string.Empty;
                lblGBHTX_DonVi.Text = string.Empty;
                lblGBHTX_NhacNhoTruocNgay.Text = string.Empty;
                picGBHTX_HinhAnh.Image = null;
                txtGBHTX_GhiChu.Text = string.Empty;
                chkGBHTX_Status.Checked = false;
                lblGBHTX_NgayCapDauTien.Text = string.Empty;
                dgvGBHTXCT.DataSource = null;
            }
            else
            {
                lblGBHTX_MaGiay.Text = entity.ma_giay;
                lblGBHTX_DonVi.Text = entity.ten_don_vi;
                lblGBHTX_NhacNhoTruocNgay.Text = entity.nhac_nho_truoc_ngay.ToString();
                picGBHTX_HinhAnh.Image = entity.hinh_anh != null ? ConvertionHelper.ByteArrayToImage(entity.hinh_anh) : null;
                txtGBHTX_GhiChu.Text = entity.ghi_chu;
                chkGBHTX_Status.Checked = entity.status == "Y";
                lblGBHTX_NgayCapDauTien.Text = entity.ngay_cap_lan_dau.HasValue ? entity.ngay_cap_lan_dau.Value.ToString("dd/MM/yyyy") : "N/A";

                dgvGBHTXCT.DataSource = entity.DetailList;
            }
        }

        #endregion

        #region tab Biên bản giao xe

        private void btnAdd_BBGX_Click(object sender, EventArgs e)
        {
            AddEditBienBanGiaoXeView dlg = new AddEditBienBanGiaoXeView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy biên bản giao xe thành công !", true);
                _presenter.LoadBienBanGiaoXe(true);
            }
        }

        private void btnEdit_BBGX_Click(object sender, EventArgs e)
        {
            AddEditBienBanGiaoXeView dlg = new AddEditBienBanGiaoXeView(_presenter.CurrentVehicle.BienBanGiaoXe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật biên bản giao xe '{0}' thành công !", _presenter.CurrentVehicle.BienBanGiaoXe.so_bien_ban), true);
                _presenter.LoadBienBanGiaoXe(!_presenter.CurrentVehicle.BienBanGiaoXe.IsHistory);
            }
        }

        private void btnDelete_BBGX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá biên bản '{0}' ngày '{1}' ?", _presenter.CurrentVehicle.BienBanGiaoXe.so_bien_ban, _presenter.CurrentVehicle.BienBanGiaoXe.ngay_bien_ban_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_presenter.DeleteBienBanGiaoXe(_presenter.CurrentVehicle.BienBanGiaoXe.so_bien_ban))
                {
                    ShowMessage(string.Format("Xoá biên bản '{0}' ngày '{1}' thành công !", _presenter.CurrentVehicle.BienBanGiaoXe.so_bien_ban, _presenter.CurrentVehicle.BienBanGiaoXe.ngay_bien_ban_str), true);
                    _presenter.LoadBienBanGiaoXe(true);
                }
                else
                {
                    ShowMessage(string.Format("Xoá biên bản '{0}' ngày '{1}' thất bại !", _presenter.CurrentVehicle.BienBanGiaoXe.so_bien_ban, _presenter.CurrentVehicle.BienBanGiaoXe.ngay_bien_ban_str), false);
                }
            }
        }

        private void btnAdd_BBGX_CT_Click(object sender, EventArgs e)
        {
            AddEditBienBanGiaoXeChiTietView dlg = new AddEditBienBanGiaoXeChiTietView(_presenter.CurrentVehicle.BienBanGiaoXe.so_bien_ban);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập chi tiết biên bản giao xe thành công !", true);
                _presenter.LoadBienBanGiaoXe(!_presenter.CurrentVehicle.BienBanGiaoXe.IsHistory);
            }
        }

        private void btnEdit_BBGX_CT_Click(object sender, EventArgs e)
        {
            if (dgvBBGXCT.CurrentRow != null)
            {
                bien_ban_giao_xe_ct entity = (bien_ban_giao_xe_ct)dgvBBGXCT.CurrentRow.DataBoundItem;
                int index = dgvBBGXCT.CurrentRow.Index;
                AddEditBienBanGiaoXeChiTietView dlg = new AddEditBienBanGiaoXeChiTietView(entity);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ShowMessage(string.Format("Cập nhật công cụ dụng cụ '{0}' thành công !", entity.ten_ccdc), true);
                    _presenter.LoadBienBanGiaoXe(!_presenter.CurrentVehicle.BienBanGiaoXe.IsHistory);
                    dgvBBGXCT.ClearSelection();
                    dgvBBGXCT.CurrentCell = dgvBBGXCT[1, index];
                    dgvBBGXCT.Rows[index].Selected = true;
                }
            }
        }

        private void btnDelete_BBGX_CT_Click(object sender, EventArgs e)
        {
            if (dgvBBGXCT.CurrentRow != null)
            {
                bien_ban_giao_xe_ct entity = (bien_ban_giao_xe_ct)dgvBBGXCT.CurrentRow.DataBoundItem;
                if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá công cụ dụng cụ '{0}' ?", entity.ten_ccdc), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_presenter.DeleteBienBanGiaoXeChiTiet(entity.so_bien_ban, entity.ma_ccdc))
                    {
                        ShowMessage(string.Format("Xoá công cụ dụng cụ '{0}' thành công !", entity.ten_ccdc), true);
                        _presenter.LoadBienBanGiaoXe(!_presenter.CurrentVehicle.BienBanGiaoXe.IsHistory);
                    }
                    else
                    {
                        ShowMessage(string.Format("Xoá công cụ dụng cụ '{0}' thất bại !", entity.ten_ccdc), false);
                    }
                }
            }
        }

        private void btnHistory_BBGX_Click(object sender, EventArgs e)
        {
            HistoryBienBanGiaoXeView dlg = new HistoryBienBanGiaoXeView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _presenter.CurrentVehicle.BienBanGiaoXe = dlg.SelectedBBGX;
                _presenter.LoadBienBanGiaoXe(false);
            }
        }

        private void dgvBBGXCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_BBGX_CT_Click(null, null);
            }
        }

        private void dgvBBGXCT_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBBGXCT.CurrentRow != null)
            {
                dgvBBGXCT.CurrentRow.Selected = true;
                SetBBGXButtonsStatus();
            }
        }

        private void SetBBGXButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.BienBanGiaoXe != null)
                {
                    btnEdit_BBGX.Enabled = true;
                    btnDelete_BBGX.Enabled = true;
                    btnEdit_BBGX.BackgroundImage = Resources.edit;
                    btnDelete_BBGX.BackgroundImage = Resources.delete;
                }
                else
                {
                    btnEdit_BBGX.Enabled = false;
                    btnDelete_BBGX.Enabled = false;
                    btnEdit_BBGX.BackgroundImage = Resources.edit_disable;
                    btnDelete_BBGX.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetBBGXChiTietButtonsStatus()
        {
            if (_presenter.CurrentVehicle != null)
            {
                if (_presenter.CurrentVehicle.BienBanGiaoXe != null)
                {
                    btnAdd_BBGX_CT.Enabled = true;
                    btnAdd_BBGX_CT.BackgroundImage = Resources.add;

                    if (_presenter.CurrentVehicle.BienBanGiaoXe.DetailList != null)
                    {
                        btnEdit_BBGX_CT.Enabled = true;
                        btnDelete_BBGX_CT.Enabled = true;
                        btnEdit_BBGX_CT.BackgroundImage = Resources.edit;
                        btnDelete_BBGX_CT.BackgroundImage = Resources.delete;
                    }
                    else
                    {
                        btnEdit_BBGX_CT.Enabled = false;
                        btnDelete_BBGX_CT.Enabled = false;
                        btnEdit_BBGX_CT.BackgroundImage = Resources.edit_disable;
                        btnDelete_BBGX_CT.BackgroundImage = Resources.delete_disable;
                    }
                }
                else
                {
                    btnAdd_BBGX_CT.Enabled = false;
                    btnEdit_BBGX_CT.Enabled = false;
                    btnDelete_BBGX_CT.Enabled = false;
                    btnAdd_BBGX_CT.BackgroundImage = Resources.add_disable;
                    btnEdit_BBGX_CT.BackgroundImage = Resources.edit_disable;
                    btnDelete_BBGX_CT.BackgroundImage = Resources.delete_disable;
                }
            }
        }

        private void SetBBGXToControls(bien_ban_giao_xe entity)
        {
            if (entity == null)
            {
                lblBBGX_SoBienLai.Text = string.Empty;
                lblBBGX_NgayBienban.Text = string.Empty;
                lblBBGX_TaiXe.Text = string.Empty;
                lblBBGX_NgayNhanXe.Text = string.Empty;
                lblBBGX_SoKmBatDau.Text = string.Empty;
                lblBBGX_GhiChu.Text = string.Empty;
                chkBBGX_Status.Checked = false;
                dgvBBGXCT.DataSource = null;
            }
            else
            {
                lblBBGX_SoBienLai.Text = entity.so_bien_ban;
                lblBBGX_NgayBienban.Text = entity.ngay_bien_ban_str;
                lblBBGX_TaiXe.Text = entity.ten_tai_xe;
                lblBBGX_NgayNhanXe.Text = entity.ngay_nhan_xe_str;
                lblBBGX_SoKmBatDau.Text = entity.so_km_bat_dau.ToString("N0");
                lblBBGX_GhiChu.Text = entity.ghi_chu;
                chkBBGX_Status.Checked = entity.status == "Y";
                dgvBBGXCT.DataSource = entity.DetailList;
            }
        }

        #endregion

        #region tab Biên bảo thu hồi

        private void btnAdd_BBTH_Click(object sender, EventArgs e)
        {
            AddEditBienBanThuHoiView dlg = new AddEditBienBanThuHoiView(_presenter.CurrentVehicle.ma_xe);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage("Nhập giấy biên bản thu hồi thành công !", true);
                _presenter.LoadBienBanThuHoi();
            }
        }

        private void btnEdit_BBTH_Click(object sender, EventArgs e)
        {
            int index = dgvBBTH.CurrentRow.Index;
            _presenter.CurrentVehicle.BienBanThuHoi = ((bien_ban_thu_hoi)dgvBBTH.CurrentRow.DataBoundItem);
            AddEditBienBanThuHoiView dlg = new AddEditBienBanThuHoiView(_presenter.CurrentVehicle.BienBanThuHoi);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShowMessage(string.Format("Cập nhật biên bản thu hồi '{0}' thành công !", _presenter.CurrentVehicle.BienBanThuHoi.so_bien_ban), true);
                _presenter.LoadBienBanThuHoi();
                dgvBBTH.ClearSelection();
                dgvBBTH.CurrentCell = dgvBBTH[1, index];
                dgvBBTH.Rows[index].Selected = true;
            }
        }

        private void btnDelete_BBTH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn xoá biên bản '{0}' ngày '{1}' ?", _presenter.CurrentVehicle.BienBanThuHoi.so_bien_ban, _presenter.CurrentVehicle.BienBanThuHoi.ngay_bien_ban_str), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _presenter.CurrentVehicle.BienBanThuHoi = ((bien_ban_thu_hoi)dgvBBTH.CurrentRow.DataBoundItem);
                if (_presenter.DeleteBienBanThuHoi(_presenter.CurrentVehicle.BienBanThuHoi.so_bien_ban))
                {
                    ShowMessage(string.Format("Xoá biên bản '{0}' ngày '{1}' thành công !", _presenter.CurrentVehicle.BienBanThuHoi.so_bien_ban, _presenter.CurrentVehicle.BienBanThuHoi.ngay_bien_ban_str), true);
                    _presenter.LoadBienBanThuHoi();
                }
                else
                {
                    ShowMessage(string.Format("Xoá biên bản '{0}' ngày '{1}' thất bại !", _presenter.CurrentVehicle.BienBanThuHoi.so_bien_ban, _presenter.CurrentVehicle.BienBanThuHoi.ngay_bien_ban_str), false);
                }
            }
        }

        private void SetBBTHButtonsStatus(bool isEnable)
        {
            if (isEnable)
            {
                btnEdit_BBTH.Enabled = true;
                btnDelete_BBTH.Enabled = true;
                btnEdit_BBTH.BackgroundImage = Resources.edit;
                btnDelete_BBTH.BackgroundImage = Resources.delete;
            }
            else
            {
                btnEdit_BBTH.Enabled = false;
                btnDelete_BBTH.Enabled = false;
                btnEdit_BBTH.BackgroundImage = Resources.edit_disable;
                btnDelete_BBTH.BackgroundImage = Resources.delete_disable;
            }
        }

        private void dgvBBTH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                btnEdit_BBTH_Click(null, null);
            }
        }

        private void dgvBBTH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBBTH.CurrentRow != null)
            {
                dgvBBTH.CurrentRow.Selected = true;
                SetBBTHButtonsStatus(true);
            }
        }

        #endregion
    }
}