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
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.pbHinhAnh = new System.Windows.Forms.PictureBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.dgvDanhSachNhanVien = new System.Windows.Forms.DataGridView();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.cboPhongBan = new System.Windows.Forms.ComboBox();
            this.btn_luu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_huy
            // 
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_huy.Location = new System.Drawing.Point(1157, 768);
            this.btn_huy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(209, 78);
            this.btn_huy.TabIndex = 72;
            this.btn_huy.Text = "Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_sua.Location = new System.Drawing.Point(601, 768);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(215, 78);
            this.btn_sua.TabIndex = 70;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_xoa.Location = new System.Drawing.Point(360, 768);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(173, 78);
            this.btn_xoa.TabIndex = 69;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_them.Location = new System.Drawing.Point(135, 768);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(169, 78);
            this.btn_them.TabIndex = 68;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 51);
            this.label2.TabIndex = 74;
            this.label2.Text = "Họ và tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label3.Location = new System.Drawing.Point(28, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 51);
            this.label3.TabIndex = 75;
            this.label3.Text = "SĐT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label4.Location = new System.Drawing.Point(24, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 51);
            this.label4.TabIndex = 76;
            this.label4.Text = "CCCD:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label5.Location = new System.Drawing.Point(571, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 51);
            this.label5.TabIndex = 77;
            this.label5.Text = "Giới tính:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label6.Location = new System.Drawing.Point(28, 248);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 51);
            this.label6.TabIndex = 78;
            this.label6.Text = "Địa chỉ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label7.Location = new System.Drawing.Point(571, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 51);
            this.label7.TabIndex = 79;
            this.label7.Text = "Ngày sinh:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label8.Location = new System.Drawing.Point(571, 178);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 51);
            this.label8.TabIndex = 80;
            this.label8.Text = "Chức vụ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label9.Location = new System.Drawing.Point(571, 244);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 51);
            this.label9.TabIndex = 81;
            this.label9.Text = "Phòng ban:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label10.Location = new System.Drawing.Point(1237, 318);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 51);
            this.label10.TabIndex = 82;
            this.label10.Text = "Hình ảnh:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(196, 52);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(348, 38);
            this.txtHoTen.TabIndex = 84;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(196, 126);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(348, 38);
            this.txtSDT.TabIndex = 85;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(196, 184);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtCCCD.Multiline = true;
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(348, 38);
            this.txtCCCD.TabIndex = 86;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(196, 248);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(348, 38);
            this.txtDiaChi.TabIndex = 89;
            // 
            // pbHinhAnh
            // 
            this.pbHinhAnh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbHinhAnh.Location = new System.Drawing.Point(1164, 32);
            this.pbHinhAnh.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pbHinhAnh.Name = "pbHinhAnh";
            this.pbHinhAnh.Size = new System.Drawing.Size(307, 268);
            this.pbHinhAnh.TabIndex = 92;
            this.pbHinhAnh.TabStop = false;
            this.pbHinhAnh.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(772, 109);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(335, 31);
            this.dtpNgaySinh.TabIndex = 93;
            // 
            // dgvDanhSachNhanVien
            // 
            this.dgvDanhSachNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachNhanVien.Location = new System.Drawing.Point(33, 372);
            this.dgvDanhSachNhanVien.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvDanhSachNhanVien.Name = "dgvDanhSachNhanVien";
            this.dgvDanhSachNhanVien.RowHeadersWidth = 62;
            this.dgvDanhSachNhanVien.RowTemplate.Height = 33;
            this.dgvDanhSachNhanVien.Size = new System.Drawing.Size(1436, 370);
            this.dgvDanhSachNhanVien.TabIndex = 94;
            this.dgvDanhSachNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachNhanVien_CellClick);
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Location = new System.Drawing.Point(772, 38);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(219, 33);
            this.cboGioiTinh.TabIndex = 95;
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(772, 178);
            this.cboChucVu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(219, 33);
            this.cboChucVu.TabIndex = 96;
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.FormattingEnabled = true;
            this.cboPhongBan.Location = new System.Drawing.Point(772, 251);
            this.cboPhongBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Size = new System.Drawing.Size(219, 33);
            this.cboPhongBan.TabIndex = 97;
            // 
            // btn_luu
            // 
            this.btn_luu.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_luu.Location = new System.Drawing.Point(885, 768);
            this.btn_luu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(204, 78);
            this.btn_luu.TabIndex = 71;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 905);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.cboChucVu);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.dgvDanhSachNhanVien);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.pbHinhAnh);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmNhanVien";
            this.Text = "Thông tin nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.pbHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label label10;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtCCCD;
        private TextBox txtDiaChi;
        private PictureBox pbHinhAnh;
        private DateTimePicker dtpNgaySinh;
        private DataGridView dgvDanhSachNhanVien;
        private ComboBox cboGioiTinh;
        private ComboBox cboChucVu;
        private ComboBox cboPhongBan;
        private Button btn_luu;
    }
}