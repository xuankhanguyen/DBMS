using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectHRM
{
    partial class frmNhanVien
    {/// <summary>
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
            this.components = new System.ComponentModel.Container();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.pbHinhAnh = new System.Windows.Forms.PictureBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.dgvDanhSachNhanVien = new System.Windows.Forms.DataGridView();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.chucVuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Cuoiki.DataSet1();
            this.phongBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_load = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtID = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.txtPhongBan = new System.Windows.Forms.TextBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.txtNhanVienID = new System.Windows.Forms.TextBox();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.phongBanTableAdapter = new Cuoiki.DataSet1TableAdapters.PhongBanTableAdapter();
            this.chucVuTableAdapter = new Cuoiki.DataSet1TableAdapters.ChucVuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chucVuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongBanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_huy
            // 
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_huy.Location = new System.Drawing.Point(849, 1);
            this.btn_huy.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(208, 89);
            this.btn_huy.TabIndex = 72;
            this.btn_huy.Text = "Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_sua.Location = new System.Drawing.Point(491, 1);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(215, 89);
            this.btn_sua.TabIndex = 70;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_xoa.Location = new System.Drawing.Point(972, 28);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(180, 60);
            this.btn_xoa.TabIndex = 69;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_them.Location = new System.Drawing.Point(135, 1);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(221, 89);
            this.btn_them.TabIndex = 68;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 51);
            this.label2.TabIndex = 74;
            this.label2.Text = "Họ và tên:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 51);
            this.label3.TabIndex = 75;
            this.label3.Text = "SĐT:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label4.Location = new System.Drawing.Point(16, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 51);
            this.label4.TabIndex = 76;
            this.label4.Text = "CCCD:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label5.Location = new System.Drawing.Point(4, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 51);
            this.label5.TabIndex = 77;
            this.label5.Text = "Giới tính:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label6.Location = new System.Drawing.Point(16, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 51);
            this.label6.TabIndex = 78;
            this.label6.Text = "Địa chỉ:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label7.Location = new System.Drawing.Point(4, 86);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 51);
            this.label7.TabIndex = 79;
            this.label7.Text = "Ngày sinh:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label8.Location = new System.Drawing.Point(4, 162);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 51);
            this.label8.TabIndex = 80;
            this.label8.Text = "Chức vụ:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label9.Location = new System.Drawing.Point(9, 231);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 51);
            this.label9.TabIndex = 81;
            this.label9.Text = "Phòng ban:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHoTen.Location = new System.Drawing.Point(227, 20);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(216, 39);
            this.txtHoTen.TabIndex = 84;
            // 
            // txtSDT
            // 
            this.txtSDT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSDT.Location = new System.Drawing.Point(227, 95);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(216, 39);
            this.txtSDT.TabIndex = 85;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCCCD.Location = new System.Drawing.Point(227, 165);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtCCCD.Multiline = true;
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(216, 39);
            this.txtCCCD.TabIndex = 86;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDiaChi.Location = new System.Drawing.Point(227, 240);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(216, 39);
            this.txtDiaChi.TabIndex = 89;
            // 
            // pbHinhAnh
            // 
            this.pbHinhAnh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbHinhAnh.Location = new System.Drawing.Point(0, 0);
            this.pbHinhAnh.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.pbHinhAnh.Name = "pbHinhAnh";
            this.pbHinhAnh.Size = new System.Drawing.Size(526, 326);
            this.pbHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHinhAnh.TabIndex = 92;
            this.pbHinhAnh.TabStop = false;
            this.pbHinhAnh.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpNgaySinh.Location = new System.Drawing.Point(208, 101);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(282, 31);
            this.dtpNgaySinh.TabIndex = 93;
            // 
            // dgvDanhSachNhanVien
            // 
            this.dgvDanhSachNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachNhanVien.Location = new System.Drawing.Point(0, -3);
            this.dgvDanhSachNhanVien.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvDanhSachNhanVien.Name = "dgvDanhSachNhanVien";
            this.dgvDanhSachNhanVien.RowHeadersWidth = 62;
            this.dgvDanhSachNhanVien.RowTemplate.Height = 33;
            this.dgvDanhSachNhanVien.Size = new System.Drawing.Size(1508, 380);
            this.dgvDanhSachNhanVien.TabIndex = 94;
            this.dgvDanhSachNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachNhanVien_CellClick);
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam ",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(208, 24);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(282, 33);
            this.cboGioiTinh.TabIndex = 95;
            // 
            // cboChucVu
            // 
            this.cboChucVu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboChucVu.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.chucVuBindingSource, "ChucVu_TenCV", true));
            this.cboChucVu.DataSource = this.chucVuBindingSource;
            this.cboChucVu.DisplayMember = "ChucVu_TenCV";
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(203, 175);
            this.cboChucVu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(282, 33);
            this.cboChucVu.TabIndex = 96;
            this.cboChucVu.ValueMember = "ChucVu_ID";
            // 
            // chucVuBindingSource
            // 
            this.chucVuBindingSource.DataMember = "ChucVu";
            this.chucVuBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // phongBanBindingSource
            // 
            this.phongBanBindingSource.DataMember = "PhongBan";
            this.phongBanBindingSource.DataSource = this.dataSet1;
            // 
            // btn_load
            // 
            this.btn_load.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_load.Location = new System.Drawing.Point(1191, -1);
            this.btn_load.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(204, 89);
            this.btn_load.TabIndex = 71;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(1508, 1090);
            this.splitContainer1.SplitterDistance = 401;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 98;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtID);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtHoTen);
            this.splitContainer2.Panel1.Controls.Add(this.txtSDT);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.txtCCCD);
            this.splitContainer2.Panel1.Controls.Add(this.txtDiaChi);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1508, 401);
            this.splitContainer2.SplitterDistance = 467;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Location = new System.Drawing.Point(227, 332);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(128, 39);
            this.txtID.TabIndex = 90;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.txtPhongBan);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.cboGioiTinh);
            this.splitContainer3.Panel1.Controls.Add(this.label9);
            this.splitContainer3.Panel1.Controls.Add(this.cboChucVu);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.dtpNgaySinh);
            this.splitContainer3.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer3.Size = new System.Drawing.Size(1036, 401);
            this.splitContainer3.SplitterDistance = 529;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // txtPhongBan
            // 
            this.txtPhongBan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPhongBan.Location = new System.Drawing.Point(227, 231);
            this.txtPhongBan.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtPhongBan.Multiline = true;
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.Size = new System.Drawing.Size(263, 39);
            this.txtPhongBan.TabIndex = 97;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.pbHinhAnh);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.btn_Browse);
            this.splitContainer6.Size = new System.Drawing.Size(502, 401);
            this.splitContainer6.SplitterDistance = 326;
            this.splitContainer6.SplitterWidth = 6;
            this.splitContainer6.TabIndex = 0;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_Browse.Location = new System.Drawing.Point(0, 0);
            this.btn_Browse.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(526, 69);
            this.btn_Browse.TabIndex = 70;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btn_huy);
            this.splitContainer4.Panel2.Controls.Add(this.btn_load);
            this.splitContainer4.Panel2.Controls.Add(this.btn_sua);
            this.splitContainer4.Panel2.Controls.Add(this.btn_them);
            this.splitContainer4.Size = new System.Drawing.Size(1508, 683);
            this.splitContainer4.SplitterDistance = 572;
            this.splitContainer4.SplitterWidth = 6;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.label1);
            this.splitContainer5.Panel1.Controls.Add(this.txtTimKiem);
            this.splitContainer5.Panel1.Controls.Add(this.txtNhanVienID);
            this.splitContainer5.Panel1.Controls.Add(this.btn_timkiem);
            this.splitContainer5.Panel1.Controls.Add(this.btn_xoa);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.dgvDanhSachNhanVien);
            this.splitContainer5.Size = new System.Drawing.Size(1508, 572);
            this.splitContainer5.SplitterDistance = 186;
            this.splitContainer5.SplitterWidth = 6;
            this.splitContainer5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.Location = new System.Drawing.Point(195, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 51);
            this.label1.TabIndex = 87;
            this.label1.Text = "Nhập ID cần xóa";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(204, 126);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(657, 39);
            this.txtTimKiem.TabIndex = 86;
            // 
            // txtNhanVienID
            // 
            this.txtNhanVienID.Location = new System.Drawing.Point(491, 44);
            this.txtNhanVienID.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.txtNhanVienID.Multiline = true;
            this.txtNhanVienID.Name = "txtNhanVienID";
            this.txtNhanVienID.Size = new System.Drawing.Size(373, 39);
            this.txtNhanVienID.TabIndex = 85;
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_timkiem.Location = new System.Drawing.Point(972, 108);
            this.btn_timkiem.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(180, 60);
            this.btn_timkiem.TabIndex = 70;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // phongBanTableAdapter
            // 
            this.phongBanTableAdapter.ClearBeforeFill = true;
            // 
            // chucVuTableAdapter
            // 
            this.chucVuTableAdapter.ClearBeforeFill = true;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1508, 1096);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.Name = "frmNhanVien";
            this.Text = "Thông tin nhân viên";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chucVuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phongBanBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btn_huy;
        private Button btn_sua;
        private Button btn_xoa;
        private Button btn_them;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtCCCD;
        private TextBox txtDiaChi;
        private PictureBox pbHinhAnh;
        private DateTimePicker dtpNgaySinh;
        private DataGridView dgvDanhSachNhanVien;
        private ComboBox cboGioiTinh;
        private ComboBox cboChucVu;
        private Button btn_load;
        private EventHandler btn_luu_Click;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer6;
        private Button btn_Browse;
        private SplitContainer splitContainer5;
        private Label label1;
        private TextBox txtTimKiem;
        private TextBox txtNhanVienID;
        private Button btn_timkiem;
        private Cuoiki.DataSet1 dataSet1;
        private BindingSource phongBanBindingSource;
        private Cuoiki.DataSet1TableAdapters.PhongBanTableAdapter phongBanTableAdapter;
        private BindingSource chucVuBindingSource;
        private Cuoiki.DataSet1TableAdapters.ChucVuTableAdapter chucVuTableAdapter;
        private TextBox txtPhongBan;
        private TextBox txtID;
    }
}