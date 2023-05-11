using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Cuoiki.Forms
{
    public partial class FormTaiKhoan : Form
    {
        SqlConnection conn = null;
        DataTable dtStore = null;
        SqlDataAdapter adStore = null;
        public FormTaiKhoan()
        {
            InitializeComponent();

        }
        private void Can_Tomau() //Can chinh va to mau
        {
            dtGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtGridView.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }
        private void Load_Data()
        {
            try{
                conn = DBUtils.GetDBConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TaiKhoan", conn);
                adStore = new SqlDataAdapter(cmd);
                dtStore = new DataTable();
                adStore.Fill(dtStore);
                dtGridView.DataSource = dtStore;
                Can_Tomau();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            comboBox2.Visible = false;
            Load_Data();
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().Equals("NhanVien"))
            {
                label1.Visible = true;
                comboBox2.Visible = true;
            }
            else
            {
                label1.Visible = false;
                comboBox2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSoTK.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không được để số tài khoản trống", "Thông báo");
                return;
            }

            if (txtMatKhau.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không được để mật khẩu trống", "Thông báo");
                return;
            }
            if (comboBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không được để phân quyền trống", "Thông báo");
                return;
            }
            if (comboBox1.Text.Trim().Equals("NhanVien") && comboBox2.Text.Trim().Equals(""))
            {
                MessageBox.Show("Không được để loại nhân viên trống", "Thông báo");
                return;
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            try
            {
                SqlCommand cmd1 = new SqlCommand("ThemTaiKhoan", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@SoTK", SqlDbType.VarChar).Value = txtSoTK.Text.Trim();
                cmd1.Parameters.Add("@MatKhau", SqlDbType.VarChar).Value = txtMatKhau.Text.Trim();
                cmd1.Parameters.Add("@PhanQuyen", SqlDbType.Bit).Value = comboBox1.Text.Trim().Equals("Admin") ? 1 : 0;
                if (comboBox1.Text.Trim().Equals("NhanVien"))
                    cmd1.Parameters.Add("@Loai", SqlDbType.Bit).Value = comboBox2.Text.Trim().Equals("ChamCong") ? 0 : 1;
                else
                    cmd1.Parameters.Add("@Loai", SqlDbType.Bit).Value = 0;
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Tạo use thành công", "Thông báo");

                comboBox1.ResetText();
                comboBox2.ResetText();
                txtMatKhau.ResetText();
                txtSoTK.ResetText();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Load_Data();
        }

        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy Row hiện tại
            int r = dtGridView.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên
            txtSoTK.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtMatKhau.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            //txtSoTK.ReadOnly = true;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            label3.Visible = false;
            label1.Visible = false;
            btnAdd.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtSoTK.ReadOnly = false;
            comboBox1.Visible = true;
            comboBox1.Visible = true;
            label3.Visible = true;

            btnAdd.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtSoTK.ResetText();
            txtMatKhau.ResetText();
            comboBox1.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String pass = txtMatKhau.Text.Trim();
            if (pass.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo");
                return;
            }

            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            try
            {
                SqlCommand cmd1 = new SqlCommand("SuaMatKhauTaiKhoanDangNhap", conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@SoTK", SqlDbType.VarChar).Value = txtSoTK.Text.Trim();
                cmd1.Parameters.Add("@MatKhau", SqlDbType.VarChar).Value = pass;
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo");
                if (txtSoTK.Text.Trim().Equals(DBUtils.username))
                {
                    DBUtils.password = pass;
                }
                Load_Data();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnHuy_Click(null, null);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra có phải là tài khoản của người dùng hiện tại không
            if (txtSoTK.Text.Trim().Equals(DBUtils.username))
            {
                MessageBox.Show("Tài khoản đang được đăng nhập bạn không thể xóa!", "Thông báo");
                btnHuy_Click(null, null);
                return;
            }

            // Kiểm tra User có muốn xóa hàng dữ liệu
            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa tài khoản " + txtSoTK.Text.Trim() + " không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckYN == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {
                    SqlCommand cmd1 = new SqlCommand("XoaNguoiDung", conn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@SoTK", SqlDbType.VarChar).Value = txtSoTK.Text.Trim();
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Xóa tài khoản thành công", "Thông báo");
                    Load_Data();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            btnHuy_Click(null, null);
        }
    }
}
