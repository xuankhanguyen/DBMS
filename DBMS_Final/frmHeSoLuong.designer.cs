using System.Drawing;
using System.Windows.Forms;

namespace ProjectHRM
{
    partial class frmHeSoLuong
    {
        //// <summary>
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txtHeSo = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_huy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(65, 215);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(606, 312);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_sua
            // 
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_sua.Location = new System.Drawing.Point(393, 549);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(123, 41);
            this.btn_sua.TabIndex = 50;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_xoa.Location = new System.Drawing.Point(209, 549);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(134, 41);
            this.btn_xoa.TabIndex = 49;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_them.Location = new System.Drawing.Point(59, 549);
            this.btn_them.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(101, 41);
            this.btn_them.TabIndex = 48;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txtHeSo
            // 
            this.txtHeSo.Location = new System.Drawing.Point(173, 149);
            this.txtHeSo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtHeSo.Multiline = true;
            this.txtHeSo.Name = "txtHeSo";
            this.txtHeSo.Size = new System.Drawing.Size(458, 26);
            this.txtHeSo.TabIndex = 88;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(173, 97);
            this.txtTen.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtTen.Multiline = true;
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(458, 26);
            this.txtTen.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label2.Location = new System.Drawing.Point(59, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 32);
            this.label2.TabIndex = 86;
            this.label2.Text = "Hệ số:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.Location = new System.Drawing.Point(59, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 32);
            this.label1.TabIndex = 85;
            this.label1.Text = "Tên:";
            // 
            // btn_huy
            // 
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_huy.Location = new System.Drawing.Point(566, 549);
            this.btn_huy.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(113, 41);
            this.btn_huy.TabIndex = 89;
            this.btn_huy.Text = "Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label3.Location = new System.Drawing.Point(59, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 32);
            this.label3.TabIndex = 90;
            this.label3.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(173, 36);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(458, 26);
            this.txtID.TabIndex = 91;
            // 
            // frmHeSoLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 616);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.txtHeSo);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmHeSoLuong";
            this.Text = "Hệ số lương";
            this.Load += new System.EventHandler(this.frmHeSoLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_sua;
        private Button btn_xoa;
        private Button btn_them;
        private TextBox txtHeSo;
        private TextBox txtTen;
        private Label label2;
        private Label label1;
        private Button btn_huy;
        private Label label3;
        private TextBox txtID;
    }
}