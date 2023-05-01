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

namespace Cuoiki.Forms
{
    public partial class FormTaiKhoan : Form
    {
        public FormTaiKhoan()
        {
            InitializeComponent();

        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.Black;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadTheme();
            // Tạo kết nối đến database
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TaiKhoan", connection);

                // Tạo đối tượng DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Sử dụng phương thức Fill của SqlDataAdapter để đổ dữ liệu từ database vào DataTable
                adapter.Fill(dataTable);

                // Gán dữ liệu từ DataTable vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các textbox
            string soTK = txtSoTK.Text;
            string matKhau = txtMatKhau.Text;
            int phanQuyen = int.Parse(txtPhanQuyen.Text);
            int nhanVien = int.Parse(txtNhanVien.Text);

            // Kết nối đến database

            using (SqlConnection connection = DBUtils.GetDBConnection())

            {
                connection.Open();

                // Tạo command để gọi thủ tục
                SqlCommand command = new SqlCommand("ThemTaiKhoan", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào command
                command.Parameters.AddWithValue("@SoTK", soTK);
                command.Parameters.AddWithValue("@MatKhau", matKhau);
                command.Parameters.AddWithValue("@PhanQuyen", phanQuyen);
                command.Parameters.AddWithValue("@NhanVien", nhanVien);

                // Thực thi thủ tục
                int rowsAffected = command.ExecuteNonQuery();

                // Kiểm tra số bản ghi bị ảnh hưởng
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thêm tài khoản thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản không thành công!");
                }

                // Đóng kết nối
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string soTK = txtSoTK.Text;

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                SqlCommand command = new SqlCommand("XoaTaiKhoan", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SoTK", soTK);

                command.ExecuteNonQuery();

                MessageBox.Show("Đã xóa tài khoản có số tài khoản là " + soTK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // create a new SqlConnection object and open the connection
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    conn.Open();

                    // create a new SqlCommand object and set its properties
                    using (SqlCommand cmd = new SqlCommand("SuaThongTinTaiKhoan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // set the parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@SoTK", txtSoTK.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                        cmd.Parameters.AddWithValue("@PhanQuyen", txtPhanQuyen.Text);
                        cmd.Parameters.AddWithValue("@NhanVien", txtNhanVien.Text);

                        // execute the stored procedure
                        cmd.ExecuteNonQuery();

                        // display a message box indicating the update was successful
                        MessageBox.Show("Cập nhật tài khoản thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                // display a message box with the error message if an exception occurs
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string timKiem = txtTimKiem.Text;
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("TimKiemTaiKhoan", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@timKiem", SqlDbType.VarChar).Value = timKiem;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
            }
        }

        private void txtSoTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
