namespace VMS.UI.Views
{
    partial class AddEditLichSuKhauHaoView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpNgayHieuLuc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTiLeKhauHao = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtGiaTriKhauHao = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtNguyenGia = new System.Windows.Forms.TextBox();
            this.txtGiaTriConLai = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiLeKhauHao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTriKhauHao)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 427);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImage = global::VMS.UI.Properties.Resources.exit;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(707, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 54);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackgroundImage = global::VMS.UI.Properties.Resources.save;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(646, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 54);
            this.btnSave.TabIndex = 1;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.txtGiaTriConLai);
            this.panel1.Controls.Add(this.txtNguyenGia);
            this.panel1.Controls.Add(this.txtGhiChu);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpNgayHieuLuc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTiLeKhauHao);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtGiaTriKhauHao);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 361);
            this.panel1.TabIndex = 0;
            // 
            // dtpNgayHieuLuc
            // 
            this.dtpNgayHieuLuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayHieuLuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayHieuLuc.Location = new System.Drawing.Point(234, 207);
            this.dtpNgayHieuLuc.MaxDate = new System.DateTime(2079, 6, 6, 0, 0, 0, 0);
            this.dtpNgayHieuLuc.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpNgayHieuLuc.Name = "dtpNgayHieuLuc";
            this.dtpNgayHieuLuc.Size = new System.Drawing.Size(172, 26);
            this.dtpNgayHieuLuc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Ngày hiệu lực:";
            // 
            // txtTiLeKhauHao
            // 
            this.txtTiLeKhauHao.DecimalPlaces = 2;
            this.txtTiLeKhauHao.Location = new System.Drawing.Point(234, 164);
            this.txtTiLeKhauHao.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtTiLeKhauHao.Name = "txtTiLeKhauHao";
            this.txtTiLeKhauHao.Size = new System.Drawing.Size(174, 26);
            this.txtTiLeKhauHao.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(94, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 20);
            this.label15.TabIndex = 48;
            this.label15.Text = "Tỉ lệ khấu hao:";
            // 
            // txtGiaTriKhauHao
            // 
            this.txtGiaTriKhauHao.BackColor = System.Drawing.SystemColors.Window;
            this.txtGiaTriKhauHao.Location = new System.Drawing.Point(234, 121);
            this.txtGiaTriKhauHao.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtGiaTriKhauHao.Name = "txtGiaTriKhauHao";
            this.txtGiaTriKhauHao.Size = new System.Drawing.Size(174, 26);
            this.txtGiaTriKhauHao.TabIndex = 2;
            this.txtGiaTriKhauHao.ThousandsSeparator = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(94, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 20);
            this.label14.TabIndex = 47;
            this.label14.Text = "Giá trị khấu hao:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Giá trị còn lại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 54;
            this.label3.Text = "Nguyên giá:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BackColor = System.Drawing.Color.White;
            this.txtGhiChu.Location = new System.Drawing.Point(234, 253);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(291, 88);
            this.txtGhiChu.TabIndex = 5;
            // 
            // txtNguyenGia
            // 
            this.txtNguyenGia.BackColor = System.Drawing.SystemColors.Window;
            this.txtNguyenGia.Location = new System.Drawing.Point(234, 35);
            this.txtNguyenGia.Name = "txtNguyenGia";
            this.txtNguyenGia.ReadOnly = true;
            this.txtNguyenGia.Size = new System.Drawing.Size(174, 26);
            this.txtNguyenGia.TabIndex = 0;
            // 
            // txtGiaTriConLai
            // 
            this.txtGiaTriConLai.BackColor = System.Drawing.SystemColors.Window;
            this.txtGiaTriConLai.Location = new System.Drawing.Point(234, 78);
            this.txtGiaTriConLai.Name = "txtGiaTriConLai";
            this.txtGiaTriConLai.ReadOnly = true;
            this.txtGiaTriConLai.Size = new System.Drawing.Size(174, 26);
            this.txtGiaTriConLai.TabIndex = 1;
            // 
            // AddEditLichSuKhauHaoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 427);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditLichSuKhauHaoView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MỚI TỈ LỆ KHẤU HAO";
            this.Load += new System.EventHandler(this.AddEditLichSuKhauHaoView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditLichSuKhauHaoView_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiLeKhauHao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiaTriKhauHao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown txtTiLeKhauHao;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown txtGiaTriKhauHao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayHieuLuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtGiaTriConLai;
        private System.Windows.Forms.TextBox txtNguyenGia;

    }
}