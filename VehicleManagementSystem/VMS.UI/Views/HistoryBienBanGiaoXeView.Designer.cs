namespace VMS.UI.Views
{
    partial class HistoryBienBanGiaoXeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHistoryBBGX = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryBBGX)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistoryBBGX
            // 
            this.dgvHistoryBBGX.AllowUserToAddRows = false;
            this.dgvHistoryBBGX.AllowUserToDeleteRows = false;
            this.dgvHistoryBBGX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistoryBBGX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryBBGX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn31,
            this.Column13,
            this.dataGridViewTextBoxColumn32,
            this.Column14,
            this.dataGridViewTextBoxColumn34,
            this.Column16,
            this.dataGridViewCheckBoxColumn7});
            this.dgvHistoryBBGX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryBBGX.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoryBBGX.MultiSelect = false;
            this.dgvHistoryBBGX.Name = "dgvHistoryBBGX";
            this.dgvHistoryBBGX.ReadOnly = true;
            this.dgvHistoryBBGX.RowTemplate.Height = 20;
            this.dgvHistoryBBGX.ShowCellErrors = false;
            this.dgvHistoryBBGX.ShowCellToolTips = false;
            this.dgvHistoryBBGX.ShowEditingIcon = false;
            this.dgvHistoryBBGX.ShowRowErrors = false;
            this.dgvHistoryBBGX.Size = new System.Drawing.Size(1314, 576);
            this.dgvHistoryBBGX.TabIndex = 10;
            this.dgvHistoryBBGX.TabStop = false;
            this.dgvHistoryBBGX.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistoryBBGX_CellDoubleClick);
            this.dgvHistoryBBGX.SelectionChanged += new System.EventHandler(this.dgvHistoryBBGX_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "so_bien_ban";
            this.dataGridViewTextBoxColumn31.HeaderText = "Số biên bản";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "ngay_bien_ban_str";
            this.Column13.HeaderText = "Ngày biên bản";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "ten_tai_xe";
            this.dataGridViewTextBoxColumn32.HeaderText = "Tài xế";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 150;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "ngay_nhan_xe_str";
            this.Column14.HeaderText = "Ngày nhận xe";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "so_km_bat_dau";
            this.dataGridViewTextBoxColumn34.HeaderText = "Số Km bắt đầu";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn34.Width = 120;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "ghi_chu";
            this.Column16.HeaderText = "Ghi chú";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 120;
            // 
            // dataGridViewCheckBoxColumn7
            // 
            this.dataGridViewCheckBoxColumn7.DataPropertyName = "status_bool";
            this.dataGridViewCheckBoxColumn7.HeaderText = "Trạng thái";
            this.dataGridViewCheckBoxColumn7.Name = "dataGridViewCheckBoxColumn7";
            this.dataGridViewCheckBoxColumn7.ReadOnly = true;
            this.dataGridViewCheckBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn7.Width = 80;
            // 
            // HistoryBienBanGiaoXeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 576);
            this.Controls.Add(this.dgvHistoryBBGX);
            this.KeyPreview = true;
            this.Name = "HistoryBienBanGiaoXeView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LỊCH SỬ BIÊN BẢN GIAO XE";
            this.Load += new System.EventHandler(this.HistoryBienBanGiaoXeView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HistoryBienBanGiaoXeView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryBBGX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistoryBBGX;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn7;
    }
}