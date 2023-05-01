namespace Cuoiki
{
    partial class BangLuong
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
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewUngLuong = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tiền Phụ Cấp";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tiền Ứng Lương";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tiền Tăng Ca";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Lương Ngày Chủ Nhật";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lương Ngày Thường";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kỳ Công Năm";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kỳ Công Tháng";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nhân Viên";
            this.columnHeader1.Width = 150;
            // 
            // listViewUngLuong
            // 
            this.listViewUngLuong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewUngLuong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewUngLuong.Font = new System.Drawing.Font("Cambria", 12F);
            this.listViewUngLuong.FullRowSelect = true;
            this.listViewUngLuong.GridLines = true;
            this.listViewUngLuong.HideSelection = false;
            this.listViewUngLuong.Location = new System.Drawing.Point(0, 391);
            this.listViewUngLuong.Name = "listViewUngLuong";
            this.listViewUngLuong.Size = new System.Drawing.Size(1749, 576);
            this.listViewUngLuong.TabIndex = 38;
            this.listViewUngLuong.UseCompatibleStateImageBehavior = false;
            this.listViewUngLuong.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Lương Nhân Được";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Thực lãnh";
            this.columnHeader10.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1744, 382);
            this.panel1.TabIndex = 39;
            // 
            // BangLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1749, 967);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewUngLuong);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BangLuong";
            this.Text = "Bảng Lương";
            this.Load += new System.EventHandler(this.BangLuong_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewUngLuong;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel panel1;
    }
}