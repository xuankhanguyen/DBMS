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
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectHRM
{
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {// Lấy các thông tin từ các textbox và combobox
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            int lanKy = int.Parse(txtLanKy.Text);
            string noiDung = txtNoiDung.Text;
            float luongCanBan = float.Parse(txtLuongCanBan.Text);
            // Lấy giá trị của combobox heSoLuong
            int heSoLuong = (int)comboBox2.SelectedValue;

            // Lấy giá trị của combobox nhanVien
            int nhanVien = (int)comboBox1.SelectedValue;

            // Sử dụng khối using để đảm bảo đóng kết nối khi không cần thiết
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                // Mở kết nối
                connection.Open();

                // Khởi tạo đối tượng lệnh
                SqlCommand command = new SqlCommand();

                // Gán kết nối cho lệnh
                command.Connection = connection;

                // Thiết lập loại lệnh là thủ tục
                command.CommandType = CommandType.StoredProcedure;

                // Thiết lập tên thủ tục là ThemHopDong
                command.CommandText = "ThemHopDong";

                // Khởi tạo các đối tượng tham số
                SqlParameter[] parameters = new SqlParameter[7];

                // Thiết lập các tên tham số
                parameters[0] = new SqlParameter("@NgayBatDau", ngayBatDau);
                parameters[1] = new SqlParameter("@NgayKetThuc", ngayKetThuc);
                parameters[2] = new SqlParameter("@LanKy", lanKy);
                parameters[3] = new SqlParameter("@NoiDung", noiDung);
                parameters[4] = new SqlParameter("@LuongCanBan", luongCanBan);
                parameters[5] = new SqlParameter("@HeSoLuong", heSoLuong);
                parameters[6] = new SqlParameter("@NhanVien", nhanVien);

                // Thêm các tham số vào lệnh
                command.Parameters.AddRange(parameters);
                // Thực thi lệnh
                command.ExecuteNonQuery();
                try
                {
                    fix();
                    // Hiển thị thông báo thêm thành công
                    MessageBox.Show("Thêm hợp đồng thành công!");
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                LoadData();
                HienThiVaocomboBox();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Lấy số hợp đồng từ textbox
            int soHD = int.Parse(txtSoHD.Text);
            // Khởi tạo đối tượng kết nối
            SqlConnection connection = DBUtils.GetDBConnection();
            // Mở kết nối
            connection.Open();
            // Khởi tạo đối tượng lệnh
            SqlCommand command = new SqlCommand();
            // Gán kết nối cho lệnh
            command.Connection = connection;
            // Thiết lập loại lệnh là thủ tục
            command.CommandType = CommandType.StoredProcedure;
            // Thiết lập tên thủ tục là XoaHopDong
            command.CommandText = "XoaHopDong";
            // Khởi tạo đối tượng tham số
            SqlParameter parameter = new SqlParameter();
            // Thiết lập tên tham số là @SoHD
            parameter.ParameterName = "@SoHD";
            // Thiết lập giá trị tham số là số hợp đồng
            parameter.Value = soHD;
            // Thêm tham số vào lệnh
            command.Parameters.Add(parameter);
            try
            {
                // Thực thi lệnh
                command.ExecuteNonQuery();
                // Hiển thị thông báo xóa thành công
                MessageBox.Show("Xóa hợp đồng thành công!");
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            LoadData();
            HienThiVaocomboBox();
        }

        public void fix()
        {
            // Lấy các thông tin từ các textbox và combobox
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            int lanKy = int.Parse(txtLanKy.Text);
            string noiDung = txtNoiDung.Text;
            float luongCanBan = float.Parse(txtLuongCanBan.Text);
            // Lấy giá trị của combobox heSoLuong
            int heSoLuong = (int)comboBox2.SelectedValue;
            // Lấy giá trị của combobox nhanVien
            int nhanVien = (int)comboBox1.SelectedValue;
            // Sử dụng khối using để đảm bảo đóng kết nối khi không cần thiết
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                SqlCommand cmd = new SqlCommand("TimHopDongLonNhat", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                // Mở kết nối
                connection.Open();
                // Thực thi hàm thủ tục và lấy giá trị trả về
                int hopDongLonNhat = (int)cmd.ExecuteScalar();
                // Đóng kết nối
                connection.Close();
                // Mở kết nối
                connection.Open();
                // Khởi tạo đối tượng lệnh
                SqlCommand command = new SqlCommand();
                // Gán kết nối cho lệnh
                command.Connection = connection;
                // Thiết lập loại lệnh là thủ tục
                command.CommandType = CommandType.StoredProcedure;

                // Thiết lập tên thủ tục là SuaHopDong
                command.CommandText = "SuaHopDong";
                // Khởi tạo các đối tượng tham số
                SqlParameter[] parameters = new SqlParameter[8];
                // Thiết lập các tên tham số
                parameters[0] = new SqlParameter("@SoHD", hopDongLonNhat);
                parameters[1] = new SqlParameter("@NgayBatDau", ngayBatDau);
                parameters[2] = new SqlParameter("@NgayKetThuc", ngayKetThuc);
                parameters[3] = new SqlParameter("@LanKy", lanKy);
                parameters[4] = new SqlParameter("@NoiDung", noiDung);
                parameters[5] = new SqlParameter("@LuongCanBan", luongCanBan);
                parameters[6] = new SqlParameter("@HeSoLuong", heSoLuong);
                parameters[7] = new SqlParameter("@NhanVien", nhanVien);

                // Thêm các tham số vào lệnh
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
                try
                {
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {

            // Lấy các thông tin từ các textbox và combobox
            int soHD = int.Parse(txtSoHD.Text);
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            int lanKy = int.Parse(txtLanKy.Text);
            string noiDung = txtNoiDung.Text;
            float luongCanBan = float.Parse(txtLuongCanBan.Text);
            // Lấy giá trị của combobox heSoLuong
            int heSoLuong = (int)comboBox2.SelectedValue;

            // Lấy giá trị của combobox nhanVien
            int nhanVien = (int)comboBox1.SelectedValue;

            // Sử dụng khối using để đảm bảo đóng kết nối khi không cần thiết
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                // Mở kết nối
                connection.Open();


                // Khởi tạo đối tượng lệnh
                SqlCommand command = new SqlCommand();
                // Gán kết nối cho lệnh
                command.Connection = connection;
                // Thiết lập loại lệnh là thủ tục
                command.CommandType = CommandType.StoredProcedure;
                // Thiết lập tên thủ tục là SuaHopDong
                command.CommandText = "SuaHopDong";
                // Khởi tạo các đối tượng tham số
                SqlParameter[] parameters = new SqlParameter[8];
                // Thiết lập các tên tham số
                parameters[0] = new SqlParameter("@SoHD", soHD);
                parameters[1] = new SqlParameter("@NgayBatDau", ngayBatDau);
                parameters[2] = new SqlParameter("@NgayKetThuc", ngayKetThuc);
                parameters[3] = new SqlParameter("@LanKy", lanKy);
                parameters[4] = new SqlParameter("@NoiDung", noiDung);
                parameters[5] = new SqlParameter("@LuongCanBan", luongCanBan);
                parameters[6] = new SqlParameter("@HeSoLuong", heSoLuong);
                parameters[7] = new SqlParameter("@NhanVien", nhanVien);

                // Thêm các tham số vào lệnh
                command.Parameters.AddRange(parameters);

                try
                {
                    // Thực thi lệnh
                    command.ExecuteNonQuery();
                    // Hiển thị thông báo sửa thành công
                    MessageBox.Show("Sửa hợp đồng thành công!");
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                LoadData();
                HienThiVaocomboBox();
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
         {

            this.Close();
         }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            LoadData();
            HienThiVaocomboBox();

        }
        private void LoadData()
        {
            // Tạo kết nối đến cơ sở dữ liệu SQL Server
            try{
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                // Truy vấn cơ sở dữ liệu để lấy dữ liệu mới nhất
                string query = "SELECT * FROM HopDong";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                // Load dữ liệu vào DataGridView
                dgvNhanVien.DataSource = dataTable;
            }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HienThiVaocomboBox()
        {
            try{
            SqlConnection conn = DBUtils.GetDBConnection();

            // Viết câu lệnh truy vấn
            string query1 = "SELECT NhanVien_ID FROM NhanVien";
            string query2 = "SELECT HeSoLuong_ID FROM HeSoLuong";

            // Tạo DataTable
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            // Thực thi truy vấn và đổ dữ liệu vào DataTable
            SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
            da1.Fill(dt1);
            da2.Fill(dt2);
            // Đổ dữ liệu vào ComboBox
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "NhanVien_ID";
            comboBox1.ValueMember = "NhanVien_ID";
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "HeSoLuong_ID";
            comboBox2.ValueMember = "HeSoLuong_ID";
            LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            // Load lại dữ liệu trong DataGridView
            LoadData();
        }
        private void btn_TimKiem_Click_1(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("TimKiemHopDong", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số @chucVu_ID vào command
                        cmd.Parameters.Add("@SoHD", SqlDbType.Int).Value = int.Parse(textBox1.Text);

                        conn.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Hiển thị kết quả trả về trên DataGridView
                            dgvNhanVien.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgayKetThuc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLanKy_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
