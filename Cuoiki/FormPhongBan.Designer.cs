using System.Windows.Forms;

namespace Cuoiki.Forms
{
    partial class FormPhongBan
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
            this.lbMaPB = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtMaPB = new System.Windows.Forms.TextBox();
            this.txtTenPB = new System.Windows.Forms.TextBox();
            this.txtTruongPhong = new System.Windows.Forms.TextBox();
            this.dtpNgayNhanChuc = new System.Windows.Forms.DateTimePicker();
            this.lbTenPB = new System.Windows.Forms.Label();
            this.lbTruongPhong = new System.Windows.Forms.Label();
            this.lbTGNhanChuc = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMaPB
            // 
            this.lbMaPB.AutoSize = true;
            this.lbMaPB.Location = new System.Drawing.Point(56, 19);
            this.lbMaPB.Name = "lbMaPB";
            this.lbMaPB.Size = new System.Drawing.Size(20, 16);
            this.lbMaPB.TabIndex = 12;
            this.lbMaPB.Text = "ID";
            this.lbMaPB.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 46);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtMaPB
            // 
            this.txtMaPB.Location = new System.Drawing.Point(209, 19);
            this.txtMaPB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaPB.Name = "txtMaPB";
            this.txtMaPB.Size = new System.Drawing.Size(100, 22);
            this.txtMaPB.TabIndex = 19;
            // 
            // txtTenPB
            // 
            this.txtTenPB.Location = new System.Drawing.Point(209, 60);
            this.txtTenPB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenPB.Name = "txtTenPB";
            this.txtTenPB.Size = new System.Drawing.Size(100, 22);
            this.txtTenPB.TabIndex = 20;
            // 
            // txtTruongPhong
            // 
            this.txtTruongPhong.Location = new System.Drawing.Point(577, 19);
            this.txtTruongPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTruongPhong.Name = "txtTruongPhong";
            this.txtTruongPhong.Size = new System.Drawing.Size(100, 22);
            this.txtTruongPhong.TabIndex = 21;
            // 
            // dtpNgayNhanChuc
            // 
            this.dtpNgayNhanChuc.Location = new System.Drawing.Point(577, 60);
            this.dtpNgayNhanChuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayNhanChuc.Name = "dtpNgayNhanChuc";
            this.dtpNgayNhanChuc.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayNhanChuc.TabIndex = 23;
            this.dtpNgayNhanChuc.Value = new System.DateTime(2023, 4, 20, 0, 0, 0, 0);
            // 
            // lbTenPB
            // 
            this.lbTenPB.AutoSize = true;
            this.lbTenPB.Location = new System.Drawing.Point(56, 60);
            this.lbTenPB.Name = "lbTenPB";
            this.lbTenPB.Size = new System.Drawing.Size(100, 16);
            this.lbTenPB.TabIndex = 24;
            this.lbTenPB.Text = "Tên Phòng Ban";
            // 
            // lbTruongPhong
            // 
            this.lbTruongPhong.AutoSize = true;
            this.lbTruongPhong.Location = new System.Drawing.Point(424, 19);
            this.lbTruongPhong.Name = "lbTruongPhong";
            this.lbTruongPhong.Size = new System.Drawing.Size(91, 16);
            this.lbTruongPhong.TabIndex = 25;
            this.lbTruongPhong.Text = "Trưởng phòng";
            // 
            // lbTGNhanChuc
            // 
            this.lbTGNhanChuc.AutoSize = true;
            this.lbTGNhanChuc.Location = new System.Drawing.Point(425, 62);
            this.lbTGNhanChuc.Name = "lbTGNhanChuc";
            this.lbTGNhanChuc.Size = new System.Drawing.Size(126, 16);
            this.lbTGNhanChuc.TabIndex = 26;
            this.lbTGNhanChuc.Text = "Thời gian nhận chức";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(765, 396);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(0, 69);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 23);
            this.button4.TabIndex = 28;
            this.button4.Text = "Tìm kiếm";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(0, 92);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 23);
            this.button5.TabIndex = 29;
            this.button5.Text = "Thống kê";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtMaPB);
            this.splitContainer1.Panel1.Controls.Add(this.lbTGNhanChuc);
            this.splitContainer1.Panel1.Controls.Add(this.lbMaPB);
            this.splitContainer1.Panel1.Controls.Add(this.dtpNgayNhanChuc);
            this.splitContainer1.Panel1.Controls.Add(this.lbTruongPhong);
            this.splitContainer1.Panel1.Controls.Add(this.txtTenPB);
            this.splitContainer1.Panel1.Controls.Add(this.lbTenPB);
            this.splitContainer1.Panel1.Controls.Add(this.txtTruongPhong);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(871, 504);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 30;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button5);
            this.splitContainer2.Panel1.Controls.Add(this.button4);
            this.splitContainer2.Panel1.Controls.Add(this.button3);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(871, 396);
            this.splitContainer2.SplitterDistance = 102;
            this.splitContainer2.TabIndex = 0;
            // 
            // FormPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 505);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPhongBan";
            this.Text = "Phòng ban nhân viên";
            this.Load += new System.EventHandler(this.FormPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbMaPB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMaPB;
        private System.Windows.Forms.TextBox txtTenPB;
        private System.Windows.Forms.TextBox txtTruongPhong;
        private System.Windows.Forms.DateTimePicker dtpNgayNhanChuc;
        private System.Windows.Forms.Label lbTenPB;
        private System.Windows.Forms.Label lbTruongPhong;
        private System.Windows.Forms.Label lbTGNhanChuc;
        private DataGridViewCellEventHandler dataGridView1_CellContentClick;
        private DataGridView dataGridView1;
        private Button button4;
        private Button button5;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
    }
}