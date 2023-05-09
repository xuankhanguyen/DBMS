using Cuoiki;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectHRM
{
    public partial class frmHeSoLuong : Form
    {
        public frmHeSoLuong()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các textbox
            string HeSoLuong_Ten = txtTen.Text;
            float HeSoLuong_GiaTri = float.Parse(txtHeSo.Text);
            try{
            // Tạo đối tượng SqlConnection để kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                // Mở kết nối
                conn.Open();
                // Tạo đối tượng SqlCommand để thực thi hàm thủ tục sp_ThemHeSoLuong
                using (SqlCommand cmd = new SqlCommand("sp_ThemHeSoLuong", conn))
                {
                    // Thiết lập kiểu thực thi là hàm thủ tục
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Thêm các tham số vào hàm thủ tục
                    cmd.Parameters.AddWithValue("@HeSoLuong_Ten", HeSoLuong_Ten);
                    cmd.Parameters.AddWithValue("@HeSoLuong_GiaTri", HeSoLuong_GiaTri);
                    // Thực thi hàm thủ tục và nhận kết quả trả về
                    int result = cmd.ExecuteNonQuery();
                    // Kiểm tra kết quả trả về
                    if (result > 0)
                    {
                        // Nếu thành công, hiển thị thông báo và làm mới các textbox
                        MessageBox.Show("Thêm thành công");
                        txtTen.Clear();
                        txtHeSo.Clear();
                    }
                    else
                    {
                        // Nếu thất bại, hiển thị thông báo lỗi
                        MessageBox.Show("Thêm thất bại");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
             LoadTheme();
             }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ textbox
            int HeSoLuong_ID = int.Parse(txtID.Text);
            try{
            // Tạo đối tượng SqlConnection để kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                // Mở kết nối
                conn.Open();
                // Tạo đối tượng SqlCommand để thực thi hàm thủ tục sp_XoaHeSoLuong
                using (SqlCommand cmd = new SqlCommand("sp_XoaHeSoLuong", conn))
                {
                    // Thiết lập kiểu thực thi là hàm thủ tục
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Thêm tham số vào hàm thủ tục
                    cmd.Parameters.AddWithValue("@HeSoLuong_ID", HeSoLuong_ID);
                    // Thực thi hàm thủ tục và nhận kết quả trả về
                    int result = cmd.ExecuteNonQuery();
                    // Kiểm tra kết quả trả về
                    if (result > 0)
                    {
                        // Nếu thành công, hiển thị thông báo và làm mới textbox
                        MessageBox.Show("Xóa thành công");
                        txtID.Clear();
                    }
                    else
                    {
                        // Nếu thất bại, hiển thị thông báo lỗi
                        MessageBox.Show("Xóa thất bại");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
            LoadTheme();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các textbox
            int HeSoLuong_ID = int.Parse(txtID.Text);
            string HeSoLuong_Ten = txtTen.Text;
            float HeSoLuong_GiaTri = float.Parse(txtHeSo.Text);
            try{
            // Tạo đối tượng SqlConnection để kết nối đến cơ sở dữ liệu
            using (SqlConnection conn = DBUtils.GetDBConnection())
            {
                // Mở kết nối
                conn.Open();

                // Tạo đối tượng SqlCommand để thực thi hàm thủ tục sp_SuaHeSoLuong
                using (SqlCommand cmd = new SqlCommand("sp_SuaHeSoLuong", conn))
                {
                    // Thiết lập kiểu thực thi là hàm thủ tục
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Thêm các tham số vào hàm thủ tục
                    cmd.Parameters.AddWithValue("@HeSoLuong_ID", HeSoLuong_ID);
                    cmd.Parameters.AddWithValue("@HeSoLuong_Ten", HeSoLuong_Ten);
                    cmd.Parameters.AddWithValue("@HeSoLuong_GiaTri", HeSoLuong_GiaTri);
                    // Thực thi hàm thủ tục và nhận kết quả trả về
                    int result = cmd.ExecuteNonQuery();
                    // Kiểm tra kết quả trả về
                    if (result > 0)
                    {
                        // Nếu thành công, hiển thị thông báo và làm mới các textbox
                        MessageBox.Show("Sửa thành công");
                        txtID.Clear();
                        txtTen.Clear();
                        txtHeSo.Clear();
                    }
                    else
                    {
                        // Nếu thất bại, hiển thị thông báo lỗi
                        MessageBox.Show("Sửa thất bại");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
            LoadTheme();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTheme()
        {
            try{
            // Tạo kết nối đến database
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HeSoLuong", connection);

                // Tạo đối tượng DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Sử dụng phương thức Fill của SqlDataAdapter để đổ dữ liệu từ database vào DataTable
                adapter.Fill(dataTable);

                // Gán dữ liệu từ DataTable vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHeSoLuong_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
