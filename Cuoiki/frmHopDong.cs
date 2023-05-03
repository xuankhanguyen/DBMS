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

namespace ProjectHRM
{
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Lấy các giá trị của hợp đồng từ các control trên giao diện
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            int lanKy = Convert.ToInt32(txtLanKy.Text);
            string noiDung = txtNoiDung.Text;
            float luongCanBan = Convert.ToSingle(txtLuongCanBan.Text);
            int heSoLuong = Convert.ToInt32(txtHeSoLuong.Text);
            int nhanVien = Convert.ToInt32(txtMaNV.Text);

            // Gọi stored procedure ThemHopDong trong SQL Server để thêm hợp đồng mới vào cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ThemHopDong", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Truyền các giá trị của hợp đồng vào các tham số của stored procedure
                    command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    command.Parameters.AddWithValue("@LanKy", lanKy);
                    command.Parameters.AddWithValue("@NoiDung", noiDung);
                    command.Parameters.AddWithValue("@LuongCanBan", luongCanBan);
                    command.Parameters.AddWithValue("@HeSoLuong", heSoLuong);
                    command.Parameters.AddWithValue("@NhanVien", nhanVien);

                    // Khởi tạo biến output để lấy thông báo kết quả từ stored procedure
                    SqlParameter output = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                    output.Direction = ParameterDirection.Output;
                    command.Parameters.Add(output);

                    // Thực thi stored procedure và lấy thông báo kết quả từ biến output
                    command.ExecuteNonQuery();
                    string message = output.Value.ToString();
                    MessageBox.Show(message);
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Lấy số hiệu hợp đồng từ TextBox
            int soHD = int.Parse(txtSoHD.Text);

            // Tạo kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo đối tượng SqlCommand để gọi stored procedure XoaHopDong
                using (SqlCommand command = new SqlCommand("XoaHopDong", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Truyền số hiệu hợp đồng cần xoá vào tham số của stored procedure
                    command.Parameters.AddWithValue("@SoHD", soHD);

                    // Khởi tạo biến output để lấy thông báo kết quả từ stored procedure
                    SqlParameter output = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                    output.Direction = ParameterDirection.Output;
                    command.Parameters.Add(output);

                    // Thực thi stored procedure và lấy thông báo kết quả từ biến output
                    command.ExecuteNonQuery();
                    string message = output.Value.ToString();
                    MessageBox.Show(message);

                    // Xóa nội dung của TextBox và đặt con trỏ vào TextBox đó
                    txtSoHD.Clear();
                    txtSoHD.Focus();
                }
            }
        }

        private DataTable GetData()
        {
            string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM HopDong", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            int soHD = int.Parse(txtSoHD.Text);
            DateTime ngayBatDau = dtpNgayBatDau.Value;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value;
            int lanKy = int.Parse(txtLanKy.Text);
            string noiDung = txtNoiDung.Text;
            float luongCanBan = float.Parse(txtLuongCanBan.Text);
            int heSoLuong = int.Parse(txtHeSoLuong.Text);
           // int nhanVien = int.Parse(txtNhanVien.Text);

            string connectionString = "Data Source=myServerAddress;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SuaHopDong", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SoHD", soHD);
                    command.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    command.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc);
                    command.Parameters.AddWithValue("@LanKy", lanKy);
                    command.Parameters.AddWithValue("@NoiDung", noiDung);
                    command.Parameters.AddWithValue("@LuongCanBan", luongCanBan);
                    command.Parameters.AddWithValue("@HeSoLuong", heSoLuong);
                   // command.Parameters.AddWithValue("@NhanVien", nhanVien);

                    SqlParameter messageParameter = command.Parameters.Add("@Message", SqlDbType.NVarChar, 100);
                    messageParameter.Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    string message = messageParameter.Value.ToString();
                    MessageBox.Show(message);

                    // Refresh lại dữ liệu của DataGridView
                    dgvNhanVien.DataSource = GetData();
                }
            }
        }

        

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNSDataSet.HopDong' table. You can move, or remove it, as needed.
            this.hopDongTableAdapter.Fill(this.qLNSDataSet.HopDong);
            // Tạo kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ bảng HopDong
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HopDong", connection);

                // Tạo đối tượng DataTable để lưu trữ dữ liệu từ bảng HopDong
                DataTable dataTable = new DataTable();

                // Đổ dữ liệu từ bảng HopDong vào DataTable
                adapter.Fill(dataTable);

                // Gán DataTable vào DataSource của DataGridView để hiển thị dữ liệu trên giao diện
                dgvNhanVien.DataSource = dataTable;
            }

        }
        private void LoadData()
        {
            // Tạo kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
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

        private void btn_load_Click(object sender, EventArgs e)
        {
            // Load lại dữ liệu trong DataGridView
            LoadData();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            int soHD = int.Parse(txtSoHD.Text);

            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.TimKiemHopDong(@SoHD)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SoHD", soHD);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvNhanVien.DataSource = dataTable;
                }
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thông tin của ô được chọn
            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
            txtSoHD.Text = row.Cells["HopDong_SoHD"].Value.ToString();
            dtpNgayBatDau.Value = DateTime.Parse(row.Cells["HopDong_NgayBatDau"].Value.ToString());
            dtpNgayKetThuc.Value = DateTime.Parse(row.Cells["HopDong_NgayKetThuc"].Value.ToString());
            txtLanKy.Text = row.Cells["HopDong_LanKy"].Value.ToString();
            txtNoiDung.Text = row.Cells["HopDong_NoiDung"].Value.ToString();
            txtLuongCanBan.Text = row.Cells["HopDong_LuongCanBan"].Value.ToString();
            txtHeSoLuong.Text = row.Cells["HopDong_HeSoLuong"].Value.ToString();
            txtMaNV.Text = row.Cells["HopDong_NhanVien"].Value.ToString();
        }
    }
}
