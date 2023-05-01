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
    public partial class FormChucVu: Form
    {
        public FormChucVu()
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
                    btn.ForeColor = Color.Black ;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadTheme();
            // Tạo kết nối đến database
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ChucVu", connection);

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
            
            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                // Tạo đối tượng SqlCommand và truyền tham số vào
                using (SqlCommand command = new SqlCommand("sp_ThemMoiChucVu", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ChucVu_ID", txtChucVuID.Text);
                    command.Parameters.AddWithValue("@ChucVu_TenCV", txtTenChucVu.Text);

                    // Thực thi thủ tục và xử lý kết quả
                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm chức vụ mới thành công!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi thêm chức vụ mới: " + ex.Message);
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int chucVuID;
            if (!int.TryParse(txtChucVuID.Text, out chucVuID))
            {
                MessageBox.Show("ChucVuID phai la mot so nguyen.");
                return;
            }

            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_XoaChucVu", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ChucVu_ID", chucVuID);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Da xoa thanh cong chuc vu co ID = " + chucVuID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xoa chuc vu: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int chucVuID = int.Parse(txtChucVuID.Text);
                string tenChucVu = txtTenChucVu.Text;

                // Khởi tạo kết nối đến database
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    // Khởi tạo đối tượng SqlCommand để thực thi thủ tục
                    using (SqlCommand command = new SqlCommand("sp_SuaChucVu", connection))
                    {
                        // Thiết lập loại command là StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Truyền tham số vào thủ tục
                        command.Parameters.AddWithValue("@ChucVu_ID", chucVuID);
                        command.Parameters.AddWithValue("@ChucVu_TenCV", tenChucVu);

                        // Mở kết nối đến database
                        connection.Open();

                        // Thực thi thủ tục
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra xem có bao nhiêu dòng bị ảnh hưởng
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sửa thông tin chức vụ thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy chức vụ để sửa.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("TimKiemChucVu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số @chucVu_ID vào command
                        cmd.Parameters.Add("@chucVu_ID", SqlDbType.Int).Value = int.Parse(txtChucVuID.Text);

                        conn.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Hiển thị kết quả trả về trên DataGridView
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
