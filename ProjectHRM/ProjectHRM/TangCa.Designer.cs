namespace ProjectHRM
{
    partial class TangCa
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
            this.listViewTangCa = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNgayTangCa = new System.Windows.Forms.TextBox();
            this.textBoxSoGioTangCa = new System.Windows.Forms.TextBox();
            this.textBoxNhanVien = new System.Windows.Forms.TextBox();
            this.textBoxLoaiTangCa = new System.Windows.Forms.TextBox();
            this.textBoxThangKyCong = new System.Windows.Forms.TextBox();
            this.buttonThemTangCa = new System.Windows.Forms.Button();
            this.buttonSuaTangCa = new System.Windows.Forms.Button();
            this.textBoxIDTangCa = new System.Windows.Forms.TextBox();
            this.labelIDTangCa = new System.Windows.Forms.Label();
            this.buttonXoaTangCa = new System.Windows.Forms.Button();
            this.textBoxNamKyCong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewTangCa
            // 
            this.listViewTangCa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewTangCa.FullRowSelect = true;
            this.listViewTangCa.GridLines = true;
            this.listViewTangCa.HideSelection = false;
            this.listViewTangCa.Location = new System.Drawing.Point(40, 118);
            this.listViewTangCa.Name = "listViewTangCa";
            this.listViewTangCa.Size = new System.Drawing.Size(958, 675);
            this.listViewTangCa.TabIndex = 0;
            this.listViewTangCa.UseCompatibleStateImageBehavior = false;
            this.listViewTangCa.View = System.Windows.Forms.View.Details;
            this.listViewTangCa.SelectedIndexChanged += new System.EventHandler(this.listViewTangCa_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID Tăng Ca";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = " Ngày Tăng Ca";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số Giờ Tăng Ca";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nhân Viên ";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Loại Tăng Ca";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tháng Kỳ Công";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Năm Kỳ Công";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1038, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày Tăng Ca";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1023, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số Giờ Tăng Ca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1038, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhân Viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1023, 482);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Loại Tăng Ca";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1023, 575);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tháng Kỳ Công";
            // 
            // textBoxNgayTangCa
            // 
            this.textBoxNgayTangCa.Location = new System.Drawing.Point(1194, 155);
            this.textBoxNgayTangCa.Name = "textBoxNgayTangCa";
            this.textBoxNgayTangCa.Size = new System.Drawing.Size(238, 31);
            this.textBoxNgayTangCa.TabIndex = 6;
            // 
            // textBoxSoGioTangCa
            // 
            this.textBoxSoGioTangCa.Location = new System.Drawing.Point(1194, 261);
            this.textBoxSoGioTangCa.Name = "textBoxSoGioTangCa";
            this.textBoxSoGioTangCa.Size = new System.Drawing.Size(238, 31);
            this.textBoxSoGioTangCa.TabIndex = 7;
            // 
            // textBoxNhanVien
            // 
            this.textBoxNhanVien.Location = new System.Drawing.Point(1194, 362);
            this.textBoxNhanVien.Name = "textBoxNhanVien";
            this.textBoxNhanVien.Size = new System.Drawing.Size(238, 31);
            this.textBoxNhanVien.TabIndex = 8;
            // 
            // textBoxLoaiTangCa
            // 
            this.textBoxLoaiTangCa.Location = new System.Drawing.Point(1194, 476);
            this.textBoxLoaiTangCa.Name = "textBoxLoaiTangCa";
            this.textBoxLoaiTangCa.Size = new System.Drawing.Size(238, 31);
            this.textBoxLoaiTangCa.TabIndex = 9;
            // 
            // textBoxThangKyCong
            // 
            this.textBoxThangKyCong.Location = new System.Drawing.Point(1194, 569);
            this.textBoxThangKyCong.Name = "textBoxThangKyCong";
            this.textBoxThangKyCong.Size = new System.Drawing.Size(238, 31);
            this.textBoxThangKyCong.TabIndex = 10;
            // 
            // buttonThemTangCa
            // 
            this.buttonThemTangCa.BackColor = System.Drawing.SystemColors.Info;
            this.buttonThemTangCa.Location = new System.Drawing.Point(1024, 711);
            this.buttonThemTangCa.Name = "buttonThemTangCa";
            this.buttonThemTangCa.Size = new System.Drawing.Size(148, 68);
            this.buttonThemTangCa.TabIndex = 11;
            this.buttonThemTangCa.Text = "Thêm Tăng Ca";
            this.buttonThemTangCa.UseVisualStyleBackColor = false;
            this.buttonThemTangCa.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSuaTangCa
            // 
            this.buttonSuaTangCa.BackColor = System.Drawing.SystemColors.Info;
            this.buttonSuaTangCa.Location = new System.Drawing.Point(1236, 711);
            this.buttonSuaTangCa.Name = "buttonSuaTangCa";
            this.buttonSuaTangCa.Size = new System.Drawing.Size(148, 68);
            this.buttonSuaTangCa.TabIndex = 12;
            this.buttonSuaTangCa.Text = "Sửa Tăng Ca";
            this.buttonSuaTangCa.UseVisualStyleBackColor = false;
            this.buttonSuaTangCa.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxIDTangCa
            // 
            this.textBoxIDTangCa.Location = new System.Drawing.Point(1190, 83);
            this.textBoxIDTangCa.Name = "textBoxIDTangCa";
            this.textBoxIDTangCa.ReadOnly = true;
            this.textBoxIDTangCa.Size = new System.Drawing.Size(238, 31);
            this.textBoxIDTangCa.TabIndex = 14;
            // 
            // labelIDTangCa
            // 
            this.labelIDTangCa.AutoSize = true;
            this.labelIDTangCa.Location = new System.Drawing.Point(1034, 83);
            this.labelIDTangCa.Name = "labelIDTangCa";
            this.labelIDTangCa.Size = new System.Drawing.Size(120, 25);
            this.labelIDTangCa.TabIndex = 13;
            this.labelIDTangCa.Text = "ID Tăng Ca";
            // 
            // buttonXoaTangCa
            // 
            this.buttonXoaTangCa.BackColor = System.Drawing.SystemColors.Info;
            this.buttonXoaTangCa.Location = new System.Drawing.Point(1019, 812);
            this.buttonXoaTangCa.Name = "buttonXoaTangCa";
            this.buttonXoaTangCa.Size = new System.Drawing.Size(148, 68);
            this.buttonXoaTangCa.TabIndex = 15;
            this.buttonXoaTangCa.Text = "Xóa Tăng Ca";
            this.buttonXoaTangCa.UseVisualStyleBackColor = false;
            this.buttonXoaTangCa.Click += new System.EventHandler(this.buttonXoaTangCa_Click);
            // 
            // textBoxNamKyCong
            // 
            this.textBoxNamKyCong.Location = new System.Drawing.Point(1194, 647);
            this.textBoxNamKyCong.Name = "textBoxNamKyCong";
            this.textBoxNamKyCong.Size = new System.Drawing.Size(238, 31);
            this.textBoxNamKyCong.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1023, 653);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Năm Kỳ Công";
            // 
            // TangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 892);
            this.Controls.Add(this.textBoxNamKyCong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonXoaTangCa);
            this.Controls.Add(this.textBoxIDTangCa);
            this.Controls.Add(this.labelIDTangCa);
            this.Controls.Add(this.buttonSuaTangCa);
            this.Controls.Add(this.buttonThemTangCa);
            this.Controls.Add(this.textBoxThangKyCong);
            this.Controls.Add(this.textBoxLoaiTangCa);
            this.Controls.Add(this.textBoxNhanVien);
            this.Controls.Add(this.textBoxSoGioTangCa);
            this.Controls.Add(this.textBoxNgayTangCa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewTangCa);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TangCa";
            this.Text = "TangCa";
            this.Load += new System.EventHandler(this.TangCa_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTangCa;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNgayTangCa;
        private System.Windows.Forms.TextBox textBoxSoGioTangCa;
        private System.Windows.Forms.TextBox textBoxNhanVien;
        private System.Windows.Forms.TextBox textBoxLoaiTangCa;
        private System.Windows.Forms.TextBox textBoxThangKyCong;
        private System.Windows.Forms.Button buttonThemTangCa;
        private System.Windows.Forms.Button buttonSuaTangCa;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox textBoxIDTangCa;
        private System.Windows.Forms.Label labelIDTangCa;
        private System.Windows.Forms.Button buttonXoaTangCa;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox textBoxNamKyCong;
        private System.Windows.Forms.Label label6;
    }
}