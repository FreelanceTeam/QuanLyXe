namespace VMS.UI.Views
{
    partial class AddEditLichSuTaiXeView
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
            this.cboTaiXe = new System.Windows.Forms.ComboBox();
            this.txtSoKmKetThuc = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSoKmBatDau = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkTinhTrang = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoKmKetThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoKmBatDau)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 392);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImage = global::VMS.UI.Properties.Resources.exit;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(707, 335);
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
            this.btnSave.Location = new System.Drawing.Point(646, 335);
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
            this.panel1.Controls.Add(this.dtpNgayBatDau);
            this.panel1.Controls.Add(this.dtpNgayKetThuc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboTaiXe);
            this.panel1.Controls.Add(this.txtSoKmKetThuc);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtSoKmBatDau);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkTinhTrang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 326);
            this.panel1.TabIndex = 0;
            // 
            // cboTaiXe
            // 
            this.cboTaiXe.BackColor = System.Drawing.SystemColors.Info;
            this.cboTaiXe.FormattingEnabled = true;
            this.cboTaiXe.Location = new System.Drawing.Point(230, 43);
            this.cboTaiXe.Name = "cboTaiXe";
            this.cboTaiXe.Size = new System.Drawing.Size(252, 28);
            this.cboTaiXe.TabIndex = 0;
            // 
            // txtSoKmKetThuc
            // 
            this.txtSoKmKetThuc.Location = new System.Drawing.Point(231, 135);
            this.txtSoKmKetThuc.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtSoKmKetThuc.Name = "txtSoKmKetThuc";
            this.txtSoKmKetThuc.Size = new System.Drawing.Size(133, 26);
            this.txtSoKmKetThuc.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(74, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 20);
            this.label15.TabIndex = 48;
            this.label15.Text = "Số Km kết thúc:";
            // 
            // txtSoKmBatDau
            // 
            this.txtSoKmBatDau.BackColor = System.Drawing.SystemColors.Window;
            this.txtSoKmBatDau.Location = new System.Drawing.Point(231, 90);
            this.txtSoKmBatDau.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtSoKmBatDau.Name = "txtSoKmBatDau";
            this.txtSoKmBatDau.Size = new System.Drawing.Size(133, 26);
            this.txtSoKmBatDau.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(74, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 20);
            this.label14.TabIndex = 47;
            this.label14.Text = "Số Km bắt đầu:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(74, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 46;
            this.label11.Text = "Trạng thái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tài xế:";
            // 
            // chkTinhTrang
            // 
            this.chkTinhTrang.AutoSize = true;
            this.chkTinhTrang.Checked = true;
            this.chkTinhTrang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTinhTrang.Location = new System.Drawing.Point(230, 270);
            this.chkTinhTrang.Name = "chkTinhTrang";
            this.chkTinhTrang.Size = new System.Drawing.Size(22, 21);
            this.chkTinhTrang.TabIndex = 5;
            this.chkTinhTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTinhTrang.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Ngày kết thúc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Ngày bắt đầu:";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(230, 225);
            this.dtpNgayKetThuc.MaxDate = new System.DateTime(2079, 6, 6, 0, 0, 0, 0);
            this.dtpNgayKetThuc.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(131, 26);
            this.dtpNgayKetThuc.TabIndex = 4;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(230, 180);
            this.dtpNgayBatDau.MaxDate = new System.DateTime(2079, 6, 6, 0, 0, 0, 0);
            this.dtpNgayBatDau.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(131, 26);
            this.dtpNgayBatDau.TabIndex = 3;
            // 
            // AddEditLichSuTaiXeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 392);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditLichSuTaiXeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MỚI TÀI XẾ";
            this.Load += new System.EventHandler(this.AddEditLichSuTaiXeView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditLichSuTaiXeView_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoKmKetThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoKmBatDau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTaiXe;
        private System.Windows.Forms.NumericUpDown txtSoKmKetThuc;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown txtSoKmBatDau;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkTinhTrang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;

    }
}