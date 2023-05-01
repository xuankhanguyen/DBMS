namespace Cuoiki.Forms
{
    partial class FormPhanQuyen
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
            this.btnSuaPQ = new System.Windows.Forms.Button();
            this.btnXoaPQ = new System.Windows.Forms.Button();
            this.btnThemPQ = new System.Windows.Forms.Button();
            this.txtTenQuyen = new System.Windows.Forms.TextBox();
            this.lbPhanQuyen = new System.Windows.Forms.Label();
            this.txtIDPQ = new System.Windows.Forms.TextBox();
            this.lbIDPhanQuyen = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSuaPQ
            // 
            this.btnSuaPQ.Location = new System.Drawing.Point(443, 42);
            this.btnSuaPQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaPQ.Name = "btnSuaPQ";
            this.btnSuaPQ.Size = new System.Drawing.Size(75, 23);
            this.btnSuaPQ.TabIndex = 15;
            this.btnSuaPQ.Text = "Sửa";
            this.btnSuaPQ.UseVisualStyleBackColor = true;
            this.btnSuaPQ.Click += new System.EventHandler(this.btnSuaPQ_Click);
            // 
            // btnXoaPQ
            // 
            this.btnXoaPQ.Location = new System.Drawing.Point(281, 42);
            this.btnXoaPQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaPQ.Name = "btnXoaPQ";
            this.btnXoaPQ.Size = new System.Drawing.Size(75, 23);
            this.btnXoaPQ.TabIndex = 14;
            this.btnXoaPQ.Text = "Xóa";
            this.btnXoaPQ.UseVisualStyleBackColor = true;
            this.btnXoaPQ.Click += new System.EventHandler(this.btnXoaPQ_Click);
            // 
            // btnThemPQ
            // 
            this.btnThemPQ.Location = new System.Drawing.Point(119, 42);
            this.btnThemPQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemPQ.Name = "btnThemPQ";
            this.btnThemPQ.Size = new System.Drawing.Size(75, 23);
            this.btnThemPQ.TabIndex = 13;
            this.btnThemPQ.Text = "Thêm";
            this.btnThemPQ.UseVisualStyleBackColor = true;
            this.btnThemPQ.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTenQuyen
            // 
            this.txtTenQuyen.Location = new System.Drawing.Point(572, 114);
            this.txtTenQuyen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenQuyen.Name = "txtTenQuyen";
            this.txtTenQuyen.Size = new System.Drawing.Size(100, 22);
            this.txtTenQuyen.TabIndex = 24;
            this.txtTenQuyen.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lbPhanQuyen
            // 
            this.lbPhanQuyen.AutoSize = true;
            this.lbPhanQuyen.Location = new System.Drawing.Point(461, 120);
            this.lbPhanQuyen.Name = "lbPhanQuyen";
            this.lbPhanQuyen.Size = new System.Drawing.Size(78, 16);
            this.lbPhanQuyen.TabIndex = 23;
            this.lbPhanQuyen.Text = "Phân quyền";
            this.lbPhanQuyen.Click += new System.EventHandler(this.lbChucVu_Click);
            // 
            // txtIDPQ
            // 
            this.txtIDPQ.Location = new System.Drawing.Point(225, 114);
            this.txtIDPQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIDPQ.Name = "txtIDPQ";
            this.txtIDPQ.Size = new System.Drawing.Size(100, 22);
            this.txtIDPQ.TabIndex = 22;
            this.txtIDPQ.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbIDPhanQuyen
            // 
            this.lbIDPhanQuyen.AutoSize = true;
            this.lbIDPhanQuyen.Location = new System.Drawing.Point(114, 120);
            this.lbIDPhanQuyen.Name = "lbIDPhanQuyen";
            this.lbIDPhanQuyen.Size = new System.Drawing.Size(20, 16);
            this.lbIDPhanQuyen.TabIndex = 21;
            this.lbIDPhanQuyen.Text = "ID";
            this.lbIDPhanQuyen.Click += new System.EventHandler(this.lbIDChucVu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(93, 188);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(613, 250);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 42);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // FormPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTenQuyen);
            this.Controls.Add(this.lbPhanQuyen);
            this.Controls.Add(this.txtIDPQ);
            this.Controls.Add(this.lbIDPhanQuyen);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSuaPQ);
            this.Controls.Add(this.btnXoaPQ);
            this.Controls.Add(this.btnThemPQ);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPhanQuyen";
            this.Text = "Phân quyền";
            this.Load += new System.EventHandler(this.FormPhanQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSuaPQ;
        private System.Windows.Forms.Button btnXoaPQ;
        private System.Windows.Forms.Button btnThemPQ;
        private System.Windows.Forms.TextBox txtTenQuyen;
        private System.Windows.Forms.Label lbPhanQuyen;
        private System.Windows.Forms.TextBox txtIDPQ;
        private System.Windows.Forms.Label lbIDPhanQuyen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}