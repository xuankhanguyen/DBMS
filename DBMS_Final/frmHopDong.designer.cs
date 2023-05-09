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
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btn_Load = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSoHD
            // 
            this.txtSoHD.Location = new System.Drawing.Point(177, 39);
            this.txtSoHD.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(248, 31);
            this.txtSoHD.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.Location = new System.Drawing.Point(13, 199);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 45);
            this.label9.TabIndex = 28;
            this.label9.Text = "Ngày kết thúc:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(13, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 45);
            this.label5.TabIndex = 27;
            this.label5.Text = "Ngày bắt đầu:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(21, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 45);
            this.label4.TabIndex = 26;
            this.label4.Text = "Số HD:";
            // 
            // txtLanKy
            // 
            this.txtLanKy.Location = new System.Drawing.Point(265, 294);
            this.txtLanKy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtLanKy.Name = "txtLanKy";
            this.txtLanKy.Size = new System.Drawing.Size(225, 31);
            this.txtLanKy.TabIndex = 33;
            this.txtLanKy.TextChanged += new System.EventHandler(this.txtLanKy_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(19, 285);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 45);
            this.label1.TabIndex = 32;
            this.label1.Text = "Lần ký:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(219, 552);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(319, 292);
            this.txtNoiDung.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(13, 542);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 45);
            this.label2.TabIndex = 34;
            this.label2.Text = "Nội dung:";
            // 
            // txtLuongCanBan
            // 
            this.txtLuongCanBan.Location = new System.Drawing.Point(265, 380);
            this.txtLuongCanBan.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtLuongCanBan.Name = "txtLuongCanBan";
            this.txtLuongCanBan.Size = new System.Drawing.Size(225, 31);
            this.txtLuongCanBan.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(13, 369);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 45);
            this.label3.TabIndex = 36;
            this.label3.Text = "Lương căn bản:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(13, 462);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 45);
            this.label6.TabIndex = 38;
            this.label6.Text = "Hệ số lương:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(13, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(210, 45);
            this.label7.TabIndex = 40;
            this.label7.Text = "ID Nhân viên:";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Location = new System.Drawing.Point(265, 112);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(225, 31);
            this.dtpNgayBatDau.TabIndex = 42;
            this.dtpNgayBatDau.ValueChanged += new System.EventHandler(this.dtpNgayBatDau_ValueChanged);
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(265, 208);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(225, 31);
            this.dtpNgayKetThuc.TabIndex = 43;
            this.dtpNgayKetThuc.ValueChanged += new System.EventHandler(this.dtpNgayKetThuc_ValueChanged);
            // 
            // btn_huy
            // 
            this.btn_huy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_huy.Location = new System.Drawing.Point(539, 0);
            this.btn_huy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(189, 107);
            this.btn_huy.TabIndex = 50;
            this.btn_huy.Text = "Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_sua.Location = new System.Drawing.Point(175, 0);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(184, 107);
            this.btn_sua.TabIndex = 47;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_xoa.Location = new System.Drawing.Point(537, 0);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(229, 107);
            this.btn_xoa.TabIndex = 46;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_them.Location = new System.Drawing.Point(0, 0);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(179, 107);
            this.btn_them.TabIndex = 45;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 0);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 62;
            this.dgvNhanVien.RowTemplate.Height = 33;
            this.dgvNhanVien.Size = new System.Drawing.Size(928, 778);
            this.dgvNhanVien.TabIndex = 51;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1499, 994);
            this.splitContainer1.SplitterDistance = 881;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 53;
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
            this.splitContainer2.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer2.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.dtpNgayKetThuc);
            this.splitContainer2.Panel1.Controls.Add(this.txtLuongCanBan);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.dtpNgayBatDau);
            this.splitContainer2.Panel1.Controls.Add(this.txtNoiDung);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.txtLanKy);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1499, 881);
            this.splitContainer2.SplitterDistance = 566;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(265, 462);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(180, 33);
            this.comboBox2.TabIndex = 45;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(265, 31);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 33);
            this.comboBox1.TabIndex = 44;
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
            this.splitContainer4.Panel1.Controls.Add(this.dgvNhanVien);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btn_TimKiem);
            this.splitContainer4.Panel2.Controls.Add(this.textBox1);
            this.splitContainer4.Size = new System.Drawing.Size(928, 881);
            this.splitContainer4.SplitterDistance = 778;
            this.splitContainer4.SplitterWidth = 6;
            this.splitContainer4.TabIndex = 0;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_TimKiem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_TimKiem.Location = new System.Drawing.Point(699, 0);
            this.btn_TimKiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(229, 97);
            this.btn_TimKiem.TabIndex = 55;
            this.btn_TimKiem.Text = "Tìm Kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(27, 26);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(596, 31);
            this.textBox1.TabIndex = 0;
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
            this.splitContainer3.Panel1.Controls.Add(this.btn_sua);
            this.splitContainer3.Panel1.Controls.Add(this.btn_Load);
            this.splitContainer3.Panel1.Controls.Add(this.btn_them);
            this.splitContainer3.Panel1.Controls.Add(this.btn_huy);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btn_xoa);
            this.splitContainer3.Panel2.Controls.Add(this.txtSoHD);
            this.splitContainer3.Panel2.Controls.Add(this.label4);
            this.splitContainer3.Size = new System.Drawing.Size(1499, 107);
            this.splitContainer3.SplitterDistance = 728;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // btn_Load
            // 
            this.btn_Load.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Load.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_Load.Location = new System.Drawing.Point(359, 0);
            this.btn_Load.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(180, 107);
            this.btn_Load.TabIndex = 54;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            // 
            // frmHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 994);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmHopDong";
            this.Text = "Thông tin hợp đồng";
            this.Load += new System.EventHandler(this.frmHopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Label label7;
        private DateTimePicker dtpNgayBatDau;
        private DateTimePicker dtpNgayKetThuc;
        private Button btn_huy;
        private Button btn_sua;
        private Button btn_xoa;
        private Button btn_them;
        private DataGridView dgvNhanVien;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private SplitContainer splitContainer4;
        private Button btn_TimKiem;
        private TextBox textBox1;
        private SplitContainer splitContainer3;
        private Button btn_Load;
    }
}