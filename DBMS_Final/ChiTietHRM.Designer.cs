namespace Cuoiki
{
    partial class ChiTietHRM
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cbbThang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbNam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnPhatSinh = new System.Windows.Forms.Button();
            this.dtGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.Tan;
            this.splitContainer2.Panel1.Controls.Add(this.cbbThang);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.cbbNam);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1276, 824);
            this.splitContainer2.SplitterDistance = 56;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // cbbThang
            // 
            this.cbbThang.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbThang.FormattingEnabled = true;
            this.cbbThang.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbbThang.Location = new System.Drawing.Point(631, 0);
            this.cbbThang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbThang.Name = "cbbThang";
            this.cbbThang.Size = new System.Drawing.Size(348, 50);
            this.cbbThang.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(452, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 56);
            this.label2.TabIndex = 24;
            this.label2.Text = "Tháng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbbNam
            // 
            this.cbbNam.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNam.FormattingEnabled = true;
            this.cbbNam.Location = new System.Drawing.Point(160, 0);
            this.cbbNam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbNam.Name = "cbbNam";
            this.cbbNam.Size = new System.Drawing.Size(292, 50);
            this.cbbNam.TabIndex = 23;
            this.cbbNam.SelectedIndexChanged += new System.EventHandler(this.cbbNam_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 56);
            this.label1.TabIndex = 22;
            this.label1.Text = "Năm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.Tan;
            this.splitContainer4.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer4.Panel1.Controls.Add(this.btnXem);
            this.splitContainer4.Panel1.Controls.Add(this.btnPhatSinh);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dtGridView);
            this.splitContainer4.Size = new System.Drawing.Size(1276, 763);
            this.splitContainer4.SplitterDistance = 205;
            this.splitContainer4.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tan;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUpdate.Location = new System.Drawing.Point(0, 224);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(205, 112);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnXem
            // 
            this.btnXem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tan;
            this.btnXem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.Gold;
            this.btnXem.Location = new System.Drawing.Point(0, 112);
            this.btnXem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(205, 112);
            this.btnXem.TabIndex = 15;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnPhatSinh
            // 
            this.btnPhatSinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhatSinh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPhatSinh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tan;
            this.btnPhatSinh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.btnPhatSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhatSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhatSinh.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnPhatSinh.Location = new System.Drawing.Point(0, 0);
            this.btnPhatSinh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPhatSinh.Name = "btnPhatSinh";
            this.btnPhatSinh.Size = new System.Drawing.Size(205, 112);
            this.btnPhatSinh.TabIndex = 14;
            this.btnPhatSinh.Text = "Phát sinh kỳ công";
            this.btnPhatSinh.UseVisualStyleBackColor = true;
            this.btnPhatSinh.Click += new System.EventHandler(this.btnPhatSinh_Click);
            // 
            // dtGridView
            // 
            this.dtGridView.BackgroundColor = System.Drawing.Color.Tan;
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridView.Location = new System.Drawing.Point(0, 0);
            this.dtGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.RowHeadersWidth = 82;
            this.dtGridView.RowTemplate.Height = 33;
            this.dtGridView.Size = new System.Drawing.Size(1067, 763);
            this.dtGridView.TabIndex = 2;
            this.dtGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_CellClick);
            this.dtGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_CellValueChanged);
            this.dtGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtGridView_DataError);
            // 
            // ChiTietHRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1276, 824);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChiTietHRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kỳ công chi tiết";
            this.Load += new System.EventHandler(this.ChitietHRM_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cbbThang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbNam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnPhatSinh;
        private System.Windows.Forms.DataGridView dtGridView;
        private System.Windows.Forms.Button btnUpdate;
    }
}