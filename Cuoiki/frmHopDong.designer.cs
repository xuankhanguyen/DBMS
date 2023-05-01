using System.Drawing;
using System.Windows.Forms;

namespace ProjectHRM
{
    partial class frmHopDong
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
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLanKy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLuongCanBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.txtHeSoLuong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoHD
            // 
            this.txtSoHD.Location = new System.Drawing.Point(205, 86);
            this.txtSoHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(287, 26);
            this.txtSoHD.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.Location = new System.Drawing.Point(46, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 32);
            this.label9.TabIndex = 28;
            this.label9.Text = "Ngày kết thúc:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(46, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 32);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ngày bắt đầu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(46, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 32);
            this.label4.TabIndex = 26;
            this.label4.Text = "Số HD:";
            // 
            // txtLanKy
            // 
            this.txtLanKy.Location = new System.Drawing.Point(205, 242);
            this.txtLanKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLanKy.Name = "txtLanKy";
            this.txtLanKy.Size = new System.Drawing.Size(287, 26);
            this.txtLanKy.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(46, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 32;
            this.label1.Text = "Lần ký:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(205, 294);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(287, 56);
            this.txtNoiDung.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(46, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 32);
            this.label2.TabIndex = 34;
            this.label2.Text = "Nội dung:";
            // 
            // txtLuongCanBan
            // 
            this.txtLuongCanBan.Location = new System.Drawing.Point(229, 378);
            this.txtLuongCanBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLuongCanBan.Name = "txtLuongCanBan";
            this.txtLuongCanBan.Size = new System.Drawing.Size(260, 26);
            this.txtLuongCanBan.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(46, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 32);
            this.label3.TabIndex = 36;
            this.label3.Text = "Lương căn bản:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(46, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 32);
            this.label6.TabIndex = 38;
            this.label6.Text = "Hệ số lương:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(205, 38);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(287, 26);
            this.txtMaNV.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(46, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 32);
            this.label7.TabIndex = 40;
            this.label7.Text = "ID Nhân viên:";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Location = new System.Drawing.Point(205, 138);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(287, 26);
            this.dtpNgayBatDau.TabIndex = 42;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(205, 188);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(287, 26);
            this.dtpNgayKetThuc.TabIndex = 43;
            // 
            // btn_huy
            // 
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_huy.Location = new System.Drawing.Point(1023, 525);
            this.btn_huy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(172, 51);
            this.btn_huy.TabIndex = 50;
            this.btn_huy.Text = "Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_sua.Location = new System.Drawing.Point(720, 525);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(172, 51);
            this.btn_sua.TabIndex = 47;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_xoa.Location = new System.Drawing.Point(462, 525);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(172, 51);
            this.btn_xoa.TabIndex = 46;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_them.Location = new System.Drawing.Point(193, 525);
            this.btn_them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(172, 51);
            this.btn_them.TabIndex = 45;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(532, 44);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 62;
            this.dgvNhanVien.RowTemplate.Height = 33;
            this.dgvNhanVien.Size = new System.Drawing.Size(899, 442);
            this.dgvNhanVien.TabIndex = 51;
            // 
            // txtHeSoLuong
            // 
            this.txtHeSoLuong.Location = new System.Drawing.Point(205, 435);
            this.txtHeSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHeSoLuong.Name = "txtHeSoLuong";
            this.txtHeSoLuong.Size = new System.Drawing.Size(287, 26);
            this.txtHeSoLuong.TabIndex = 52;
            // 
            // frmHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 607);
            this.Controls.Add(this.txtHeSoLuong);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.dtpNgayBatDau);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLuongCanBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLanKy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoHD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmHopDong";
            this.Text = "Thông tin hợp đồng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtSoHD;
        private Label label9;
        private Label label5;
        private Label label4;
        private TextBox txtLanKy;
        private Label label1;
        private TextBox txtNoiDung;
        private Label label2;
        private TextBox txtLuongCanBan;
        private Label label3;
        private Label label6;
        private TextBox txtMaNV;
        private Label label7;
        private DateTimePicker dtpNgayBatDau;
        private DateTimePicker dtpNgayKetThuc;
        private Button btn_huy;
        private Button btn_sua;
        private Button btn_xoa;
        private Button btn_them;
        private DataGridView dgvNhanVien;
        private TextBox txtHeSoLuong;
    }
}