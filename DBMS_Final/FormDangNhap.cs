using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection conn = null;
        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn có chắc chắn muốn thoát? ",
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
            try{
                string user = txtTaiKhoan.Text;
                string pass = txtMatKhau.Text;
                DBUtils.username = "guestHRM";
                DBUtils.password = "guestHRM";
                conn = DBUtils.GetDBConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                string query = "SELECT dbo.Login(@TK, @Pass)";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@TK", user);
                cmd.Parameters.AddWithValue("@Pass", pass);
                int kq = (int)cmd.ExecuteScalar();
           
            switch (kq)
            {
                case -1:
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Thử lại!", "Thông báo");
                    break;
                case 1:
                    DBUtils.username = user;
                    DBUtils.password = pass;
                    TrangChuAdmin admin = new TrangChuAdmin();
                    admin.Show();
                    this.Hide();
                    break;
                case 0:
                    DBUtils.username = user;
                    DBUtils.password = pass;
                    TrangChuHRM trangChuHRM = new TrangChuHRM();
                    trangChuHRM.Show();
                    this.Hide();
                    break;
            }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
