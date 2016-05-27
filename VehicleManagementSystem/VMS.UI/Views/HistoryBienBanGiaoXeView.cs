using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VMS.DAL.Entity;
using VMS.UI.Interfaces;
using VMS.UI.Presenters;

namespace VMS.UI.Views
{
    public partial class HistoryBienBanGiaoXeView : Form, IHistoryBienBanGiaoXeView
    {
        private readonly HistoryBienBanGiaoXePresenter _presenter;
        public bien_ban_giao_xe SelectedBBGX;
        public HistoryBienBanGiaoXeView(string ma_xe)
        {
            InitializeComponent();
            _presenter = new HistoryBienBanGiaoXePresenter(this);
            _presenter.MaXe = ma_xe;
            dgvHistoryBBGX.AutoGenerateColumns = false;
        }

        public void LoadAllBienBanGiaoXe(List<bien_ban_giao_xe> list)
        {
            dgvHistoryBBGX.DataSource = list;
        }

        private void HistoryBienBanGiaoXeView_Load(object sender, EventArgs e)
        {
            _presenter.LoadAllBienBanGiaoXe();
        }

        private void dgvHistoryBBGX_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && SelectedBBGX != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvHistoryBBGX_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistoryBBGX.CurrentRow != null)
            {
                dgvHistoryBBGX.CurrentRow.Selected = true;
                SelectedBBGX = ((bien_ban_giao_xe)dgvHistoryBBGX.CurrentRow.DataBoundItem);
                SelectedBBGX.IsHistory = true;
            }
            else
            {
                SelectedBBGX = null;
            }
        }

        private void HistoryBienBanGiaoXeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectedBBGX != null)
                    this.DialogResult = DialogResult.OK;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

        }
    }
}