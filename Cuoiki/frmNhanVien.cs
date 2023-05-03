using Cuoiki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHRM
{
    public partial class frmNhanVien : Form
    {
        private byte[] hinhAnh;
        private DataTable dt;
        public frmNhanVien()
        {
            InitializeComponent();
            // Khởi tạo DataTable và gán cho DataSource của DataGridView
            dt = new DataTable();
            dgvDanhSachNhanVien.DataSource = dt;

            // Đăng ký sự kiện DataSourceChanged của DataGridView
            dgvDanhSachNhanVien.DataSourceChanged += dgvDanhSachNhanVien_DataSourceChanged;
        }
        private SqlConnection conn;
        // Hàm kết nối cơ sở dữ liệu
        private void ConnectToDatabase()
        {
            conn = DBUtils.GetDBConnection();
        }

       
        private void btn_them_Click(object sender, EventArgs e)
        {
          
                try
                {
                    // Tạo chuỗi kết nối đến cơ sở dữ liệu SQL Server
                    string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";

                    // Tạo đối tượng SqlConnection để kết nối đến cơ sở dữ liệu
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Tạo đối tượng SqlCommand để gọi thủ tục "ThemNhanVien"
                        using (SqlCommand command = new SqlCommand("ThemNhanVien", connection))
                        {
                            // Đặt loại lệnh là StoredProcedure
                            command.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số cho thủ tục
                            command.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                            command.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            command.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                            command.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                            command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                            command.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                            command.Parameters.AddWithValue("@ChucVu", cboChucVu.SelectedValue);
                            command.Parameters.AddWithValue("@PhongBan", cboPhongBan.SelectedValue);

                            // Mở kết nối
                            connection.Open();

                            // Thực thi thủ tục
                            command.ExecuteNonQuery();

                            // Hiển thị thông báo thành công
                            MessageBox.Show("Thêm nhân viên thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo chuỗi kết nối đến cơ sở dữ liệu SQL Server
                string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";

                // Tạo đối tượng SqlConnection để kết nối đến cơ sở dữ liệu
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo đối tượng SqlCommand để gọi thủ tục "XoaNhanVien"
                    using (SqlCommand command = new SqlCommand("XoaNhanVien", connection))
                    {
                        // Đặt loại lệnh là StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.AddWithValue("@NhanVienID", txtNhanVienID.Text);

                        // Thêm tham số đầu ra cho thủ tục
                        SqlParameter messageParameter = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                        messageParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(messageParameter);

                        // Mở kết nối
                        connection.Open();

                        // Thực thi thủ tục
                        command.ExecuteNonQuery();

                        // Lấy giá trị của tham số đầu ra @Message
                        string message = messageParameter.Value.ToString();

                        // Hiển thị thông báo
                        MessageBox.Show(message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các control trên form
            int nhanVienID = Convert.ToInt32(txtNhanVienID.Text);
            string hoTen = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string gioiTinh = cboGioiTinh.Text;
            byte[] hinhAnh = null;
            if (pbHinhAnh.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pbHinhAnh.Image.Save(ms, pbHinhAnh.Image.RawFormat);
                hinhAnh = ms.GetBuffer();
            }
            string diaChi = txtDiaChi.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            int chucVu = Convert.ToInt32(cboChucVu.SelectedValue);
            int phongBan = Convert.ToInt32(cboPhongBan.SelectedValue);

            // Kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo đối tượng SqlCommand để gọi thủ tục CapNhatNhanVien
                using (SqlCommand command = new SqlCommand("CapNhatNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số vào SqlCommand
                    command.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@CCCD", cccd);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@PhongBan", phongBan);

                    // Thêm tham số OUTPUT vào SqlCommand
                    SqlParameter messageParameter = new SqlParameter();
                    messageParameter.ParameterName = "@Message";
                    messageParameter.Direction = ParameterDirection.Output;
                    messageParameter.Size = 100;
                    command.Parameters.Add(messageParameter);

                    // Thực thi thủ tục và lấy giá trị của biến @Message trả về
                    command.ExecuteNonQuery();
                    string message = command.Parameters["@Message"].Value.ToString();
                    MessageBox.Show(message);
                }
            }
        }
        
    
        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thông tin của nhân viên từ dòng được chọn
            DataGridViewRow selectedRow = dgvDanhSachNhanVien.Rows[e.RowIndex];
            string maNV = selectedRow.Cells["MaNV"].Value.ToString();
            string hoTen = selectedRow.Cells["HoTen"].Value.ToString();
            string sdt = selectedRow.Cells["SDT"].Value.ToString();
            string cccd = selectedRow.Cells["CCCD"].Value.ToString();
            string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
            string diaChi = selectedRow.Cells["DiaChi"].Value.ToString();
            DateTime ngaySinh = (DateTime)selectedRow.Cells["NgaySinh"].Value;
            int chucVu = (int)selectedRow.Cells["ChucVu"].Value;
            int phongBan = (int)selectedRow.Cells["PhongBan"].Value;

            // Gọi hàm update trong SQL Server để cập nhật thông tin của nhân viên
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CapNhatNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Truyền các giá trị của nhân viên vào các tham số của stored procedure
                    command.Parameters.AddWithValue("@NhanVienID", maNV);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@CCCD", cccd);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@PhongBan", phongBan);

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
        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM NhanVien", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Gán DataTable cho DataSource của DataGridView
                        dgvDanhSachNhanVien.DataSource = dataTable;
                    }
                }
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
           /* // Lấy tên nhân viên từ textbox
            string ten = txt_timkiem.Text;

            // Kết nối tới cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo đối tượng SqlCommand để gọi hàm TimKiemNhanVien
                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.TimKiemNhanVien(@Ten)", connection))
                {
                    // Thêm tham số vào SqlCommand
                    command.Parameters.AddWithValue("@Ten", ten);

                    // Sử dụng SqlDataAdapter để lấy dữ liệu từ SqlDataReader và đổ vào DataTable
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }

                    // Hiển thị kết quả tìm kiếm lên DataGridView
                    dgvDanhSachNhanVien.DataSource = dt;
                }
            }*/
        }

        private void dgvDanhSachNhanVien_DataSourceChanged(object sender, EventArgs e)
        {
            // Tự động cập nhật lại DataGridView mỗi khi có thay đổi dữ liệu trong cơ sở dữ liệu
            dgvDanhSachNhanVien.AutoResizeColumns();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            // Kết nối tới cơ sở dữ liệu và lấy dữ liệu từ bảng NhanVien vào DataTable
            string connectionString = "Data Source=DESKTOP-0VDMSUU\\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM NhanVien", connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    dt.Clear();
                    adapter.Fill(dt);
                }
            }

    }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn tệp
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn đến tệp ảnh được chọn
                    string imagePath = openFileDialog.FileName;

                    // Hiển thị ảnh lên PictureBox
                    pbHinhAnh.Image = Image.FromFile(imagePath);

                    // Đọc dữ liệu ảnh vào mảng byte
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        hinhAnh = new byte[fs.Length];
                        fs.Read(hinhAnh, 0, (int)fs.Length);
                    }
                }
            }
        }
    }
}

