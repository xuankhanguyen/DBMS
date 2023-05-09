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
            this.lbIDPhanQuyen = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            // btnSuaPQ
            // 
            this.btnSuaPQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSuaPQ.Location = new System.Drawing.Point(0, 46);
            this.btnSuaPQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaPQ.Name = "btnSuaPQ";
            this.btnSuaPQ.Size = new System.Drawing.Size(106, 23);
            this.btnSuaPQ.TabIndex = 15;
            this.btnSuaPQ.Text = "Sửa";
            this.btnSuaPQ.UseVisualStyleBackColor = true;
            this.btnSuaPQ.Click += new System.EventHandler(this.btnSuaPQ_Click);
            // 
            // btnXoaPQ
            // 
            this.btnXoaPQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXoaPQ.Location = new System.Drawing.Point(0, 23);
            this.btnXoaPQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaPQ.Name = "btnXoaPQ";
            this.btnXoaPQ.Size = new System.Drawing.Size(106, 23);
            this.btnXoaPQ.TabIndex = 14;
            this.btnXoaPQ.Text = "Xóa";
            this.btnXoaPQ.UseVisualStyleBackColor = true;
            this.btnXoaPQ.Click += new System.EventHandler(this.btnXoaPQ_Click);
            // 
            // btnThemPQ
            // 
            this.btnThemPQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThemPQ.Location = new System.Drawing.Point(0, 0);
            this.btnThemPQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemPQ.Name = "btnThemPQ";
            this.btnThemPQ.Size = new System.Drawing.Size(106, 23);
            this.btnThemPQ.TabIndex = 13;
            this.btnThemPQ.Text = "Thêm";
            this.btnThemPQ.UseVisualStyleBackColor = true;
            this.btnThemPQ.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTenQuyen
            // 
            this.txtTenQuyen.Location = new System.Drawing.Point(585, 25);
            this.txtTenQuyen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenQuyen.Name = "txtTenQuyen";
            this.txtTenQuyen.Size = new System.Drawing.Size(100, 22);
            this.txtTenQuyen.TabIndex = 24;
            this.txtTenQuyen.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lbPhanQuyen
            // 
            this.lbPhanQuyen.AutoSize = true;
            this.lbPhanQuyen.Location = new System.Drawing.Point(474, 31);
            this.lbPhanQuyen.Name = "lbPhanQuyen";
            this.lbPhanQuyen.Size = new System.Drawing.Size(78, 16);
            this.lbPhanQuyen.TabIndex = 23;
            this.lbPhanQuyen.Text = "Phân quyền";
            this.lbPhanQuyen.Click += new System.EventHandler(this.lbChucVu_Click);
            // 
            // lbIDPhanQuyen
            // 
            this.lbIDPhanQuyen.AutoSize = true;
            this.lbIDPhanQuyen.Location = new System.Drawing.Point(65, 31);
            this.lbIDPhanQuyen.Name = "lbIDPhanQuyen";
            this.lbIDPhanQuyen.Size = new System.Drawing.Size(20, 16);
            this.lbIDPhanQuyen.TabIndex = 21;
            this.lbIDPhanQuyen.Text = "ID";
            this.lbIDPhanQuyen.Click += new System.EventHandler(this.lbIDChucVu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(689, 355);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 69);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.txtTenQuyen);
            this.splitContainer1.Panel1.Controls.Add(this.lbIDPhanQuyen);
            this.splitContainer1.Panel1.Controls.Add(this.lbPhanQuyen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(799, 454);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 26;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.btnSuaPQ);
            this.splitContainer2.Panel1.Controls.Add(this.btnXoaPQ);
            this.splitContainer2.Panel1.Controls.Add(this.btnThemPQ);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(799, 355);
            this.splitContainer2.SplitterDistance = 106;
            this.splitContainer2.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(125, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 25;
            // 
            // FormPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPhanQuyen";
            this.Text = "Phân quyền";
            this.Load += new System.EventHandler(this.FormPhanQuyen_Load);
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
        private System.Windows.Forms.Button btnSuaPQ;
        private System.Windows.Forms.Button btnXoaPQ;
        private System.Windows.Forms.Button btnThemPQ;
        private System.Windows.Forms.TextBox txtTenQuyen;
        private System.Windows.Forms.Label lbPhanQuyen;
        private System.Windows.Forms.Label lbIDPhanQuyen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}