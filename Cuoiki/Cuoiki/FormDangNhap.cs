using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuoiki
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Are you sure about that? ",
                 "Thông báo",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            TrangChuHRM f = new TrangChuHRM();
            f.Show();
            this.Hide();
        }


        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
                txtMatKhau.Focus();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btDangNhap.Focus();
        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
