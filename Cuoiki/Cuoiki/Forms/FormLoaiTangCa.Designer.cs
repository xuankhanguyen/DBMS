namespace Cuoiki.Forms
{
    partial class FormLoaiTangCa
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
            this.components = new System.ComponentModel.Container();
            this.lbIDTangCa = new System.Windows.Forms.Label();
            this.txtLoaiTangCaID = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbTenLoai = new System.Windows.Forms.Label();
            this.txtTenLoaiTangCa = new System.Windows.Forms.TextBox();
            this.txtHeSo = new System.Windows.Forms.TextBox();
            this.lbHeSo = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbIDTangCa
            // 
            this.lbIDTangCa.AutoSize = true;
            this.lbIDTangCa.Location = new System.Drawing.Point(99, 71);
            this.lbIDTangCa.Name = "lbIDTangCa";
            this.lbIDTangCa.Size = new System.Drawing.Size(20, 16);
            this.lbIDTangCa.TabIndex = 0;
            this.lbIDTangCa.Text = "ID";
            this.lbIDTangCa.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLoaiTangCaID
            // 
            this.txtLoaiTangCaID.Location = new System.Drawing.Point(208, 65);
            this.txtLoaiTangCaID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLoaiTangCaID.Name = "txtLoaiTangCaID";
            this.txtLoaiTangCaID.Size = new System.Drawing.Size(100, 22);
            this.txtLoaiTangCaID.TabIndex = 1;
            this.txtLoaiTangCaID.TextChanged += new System.EventHandler(this.txtLoaiTangCaID_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(507, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(101, 185);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(603, 254);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbTenLoai
            // 
            this.lbTenLoai.AutoSize = true;
            this.lbTenLoai.Location = new System.Drawing.Point(98, 106);
            this.lbTenLoai.Name = "lbTenLoai";
            this.lbTenLoai.Size = new System.Drawing.Size(80, 16);
            this.lbTenLoai.TabIndex = 9;
            this.lbTenLoai.Text = "Loại tăng ca";
            // 
            // txtTenLoaiTangCa
            // 
            this.txtTenLoaiTangCa.Location = new System.Drawing.Point(208, 106);
            this.txtTenLoaiTangCa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenLoaiTangCa.Name = "txtTenLoaiTangCa";
            this.txtTenLoaiTangCa.Size = new System.Drawing.Size(100, 22);
            this.txtTenLoaiTangCa.TabIndex = 10;
            // 
            // txtHeSo
            // 
            this.txtHeSo.Location = new System.Drawing.Point(208, 149);
            this.txtHeSo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHeSo.Name = "txtHeSo";
            this.txtHeSo.Size = new System.Drawing.Size(100, 22);
            this.txtHeSo.TabIndex = 12;
            // 
            // lbHeSo
            // 
            this.lbHeSo.AutoSize = true;
            this.lbHeSo.Location = new System.Drawing.Point(99, 149);
            this.lbHeSo.Name = "lbHeSo";
            this.lbHeSo.Size = new System.Drawing.Size(43, 16);
            this.lbHeSo.TabIndex = 11;
            this.lbHeSo.Text = "Hệ số";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(599, 106);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Tìm kiếm";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(455, 106);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 14;
            // 
            // FormLoaiTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtHeSo);
            this.Controls.Add(this.lbHeSo);
            this.Controls.Add(this.txtTenLoaiTangCa);
            this.Controls.Add(this.lbTenLoai);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLoaiTangCaID);
            this.Controls.Add(this.lbIDTangCa);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormLoaiTangCa";
            this.Text = "Loại tăng ca";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbIDTangCa;
        private System.Windows.Forms.TextBox txtLoaiTangCaID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbTenLoai;
        private System.Windows.Forms.TextBox txtTenLoaiTangCa;
        private System.Windows.Forms.TextBox txtHeSo;
        private System.Windows.Forms.Label lbHeSo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
    }
}