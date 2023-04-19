namespace ProjectHRM
{
    partial class ChitietHRM
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnPhatSinh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbNam = new System.Windows.Forms.ComboBox();
            this.cbbThang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer1.Panel1.Controls.Add(this.btnXem);
            this.splitContainer1.Panel1.Controls.Add(this.btnPhatSinh);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel2.Controls.Add(this.dtGridView);
            this.splitContainer1.Size = new System.Drawing.Size(638, 428);
            this.splitContainer1.SplitterDistance = 85;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnXem
            // 
            this.btnXem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnXem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnXem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.Yellow;
            this.btnXem.Location = new System.Drawing.Point(360, 46);
            this.btnXem.Margin = new System.Windows.Forms.Padding(2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(185, 35);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnPhatSinh
            // 
            this.btnPhatSinh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPhatSinh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnPhatSinh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnPhatSinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhatSinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhatSinh.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnPhatSinh.Location = new System.Drawing.Point(360, 6);
            this.btnPhatSinh.Margin = new System.Windows.Forms.Padding(2);
            this.btnPhatSinh.Name = "btnPhatSinh";
            this.btnPhatSinh.Size = new System.Drawing.Size(185, 35);
            this.btnPhatSinh.TabIndex = 4;
            this.btnPhatSinh.Text = "Phát sinh kỳ công";
            this.btnPhatSinh.UseVisualStyleBackColor = true;
            this.btnPhatSinh.Click += new System.EventHandler(this.btnPhatSinh_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbbNam);
            this.panel1.Controls.Add(this.cbbThang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 84);
            this.panel1.TabIndex = 10;
            // 
            // cbbNam
            // 
            this.cbbNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNam.FormattingEnabled = true;
            this.cbbNam.Location = new System.Drawing.Point(76, 13);
            this.cbbNam.Margin = new System.Windows.Forms.Padding(2);
            this.cbbNam.Name = "cbbNam";
            this.cbbNam.Size = new System.Drawing.Size(154, 32);
            this.cbbNam.TabIndex = 2;
            // 
            // cbbThang
            // 
            this.cbbThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbbThang.Location = new System.Drawing.Point(76, 48);
            this.cbbThang.Margin = new System.Windows.Forms.Padding(2);
            this.cbbThang.Name = "cbbThang";
            this.cbbThang.Size = new System.Drawing.Size(154, 32);
            this.cbbThang.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tháng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm";
            // 
            // dtGridView
            // 
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridView.Location = new System.Drawing.Point(0, 0);
            this.dtGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.RowHeadersWidth = 82;
            this.dtGridView.RowTemplate.Height = 33;
            this.dtGridView.Size = new System.Drawing.Size(638, 342);
            this.dtGridView.TabIndex = 0;
            this.dtGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_CellClick);
            this.dtGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_CellValueChanged);
            this.dtGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtGridView_DataError);
            // 
            // ChitietHRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(638, 428);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChitietHRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KyCongHRM";
            this.Load += new System.EventHandler(this.ChitietHRM_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dtGridView;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnPhatSinh;
        private System.Windows.Forms.ComboBox cbbThang;
        private System.Windows.Forms.ComboBox cbbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}