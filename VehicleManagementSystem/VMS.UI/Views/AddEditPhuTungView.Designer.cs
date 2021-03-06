namespace VMS.UI.Views
{
    partial class AddEditPhuTungView
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
            this.cboTaiSan = new System.Windows.Forms.ComboBox();
            this.txtSoKmDaSuDung = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkTinhTrang = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoKmDaSuDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 300);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImage = global::VMS.UI.Properties.Resources.exit;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(707, 243);
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
            this.btnSave.Location = new System.Drawing.Point(646, 243);
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
            this.panel1.Controls.Add(this.cboTaiSan);
            this.panel1.Controls.Add(this.txtSoKmDaSuDung);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkTinhTrang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 234);
            this.panel1.TabIndex = 0;
            // 
            // cboTaiSan
            // 
            this.cboTaiSan.BackColor = System.Drawing.SystemColors.Info;
            this.cboTaiSan.FormattingEnabled = true;
            this.cboTaiSan.Location = new System.Drawing.Point(230, 43);
            this.cboTaiSan.Name = "cboTaiSan";
            this.cboTaiSan.Size = new System.Drawing.Size(258, 28);
            this.cboTaiSan.TabIndex = 0;
            // 
            // txtSoKmDaSuDung
            // 
            this.txtSoKmDaSuDung.DecimalPlaces = 1;
            this.txtSoKmDaSuDung.Location = new System.Drawing.Point(231, 131);
            this.txtSoKmDaSuDung.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txtSoKmDaSuDung.Name = "txtSoKmDaSuDung";
            this.txtSoKmDaSuDung.Size = new System.Drawing.Size(133, 26);
            this.txtSoKmDaSuDung.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(74, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 20);
            this.label15.TabIndex = 48;
            this.label15.Text = "Số Km đã sử dụng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BackColor = System.Drawing.SystemColors.Info;
            this.txtSoLuong.Location = new System.Drawing.Point(231, 88);
            this.txtSoLuong.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(133, 26);
            this.txtSoLuong.TabIndex = 1;
            this.txtSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(74, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 20);
            this.label14.TabIndex = 47;
            this.label14.Text = "Số lượng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(74, 178);
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
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 45;
            this.label4.Text = "Phụ tùng:";
            // 
            // chkTinhTrang
            // 
            this.chkTinhTrang.AutoSize = true;
            this.chkTinhTrang.Checked = true;
            this.chkTinhTrang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTinhTrang.Location = new System.Drawing.Point(230, 178);
            this.chkTinhTrang.Name = "chkTinhTrang";
            this.chkTinhTrang.Size = new System.Drawing.Size(22, 21);
            this.chkTinhTrang.TabIndex = 3;
            this.chkTinhTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTinhTrang.UseVisualStyleBackColor = true;
            // 
            // AddEditPhuTungView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditPhuTungView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM MỚI PHỤ TÙNG";
            this.Load += new System.EventHandler(this.AddEditPhuTungView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditPhuTungView_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoKmDaSuDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTaiSan;
        private System.Windows.Forms.NumericUpDown txtSoKmDaSuDung;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown txtSoLuong;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkTinhTrang;

    }
}