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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectHRM
{
    public partial class frmNhanVien : Form
    {
        private byte[] hinhAnh;
        private DataTable dt;
        int id;
        public frmNhanVien()
        {
            InitializeComponent();
            // Khởi tạo DataTable và gán cho DataSource của DataGridView
            dt = new DataTable();
            dgvDanhSachNhanVien.DataSource = dt;

        }
        // Đối tượng kết nối
        SqlConnection conn = null;       
        private void btn_them_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection =DBUtils.GetDBConnection())
            {
                try { 
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
                    command.Parameters.AddWithValue("@ChucVu", cboChucVu.SelectedItem);
                    command.Parameters.AddWithValue("@PhongBan", txtPhongBan.Text);
                  
                    // Mở kết nối
                    connection.Open();

                    // Thực thi thủ tục
                    command.ExecuteNonQuery();

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Thêm nhân viên thành công!");
                }
                }catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
            LoadData(); 
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                // Tạo đối tượng SqlCommand để gọi thủ tục "XoaNhanVien"
                using (SqlCommand command = new SqlCommand("XoaNhanVien", connection))
                {
                    try
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
                        LoadData();
                    }
                    catch (SqlException ex) {
                    MessageBox.Show(ex.Message);
                    }

                }
            } 
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string gioiTinh = cboGioiTinh.SelectedItem.ToString();
            string diaChi = txtDiaChi.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string chucVu = cboChucVu.SelectedItem.ToString();
            string phongBan = txtPhongBan.Text;

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                try { 
                using (SqlCommand command = new SqlCommand("CapNhatNhanVien", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NhanVienID", id);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@CCCD", cccd);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@PhongBan", phongBan);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!");
                    LoadData();
                }
                }catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
        }
        
    
        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thông tin từ ô được chọn trên DataGridView
            DataGridViewRow row = dgvDanhSachNhanVien.Rows[e.RowIndex];
            id = Convert.ToInt32( row.Cells["NhanVien_ID"].Value.ToString());
            string hoTen = row.Cells["NhanVien_HoTen"].Value.ToString();
            string sdt = row.Cells["NhanVien_SDT"].Value.ToString();
            string cccd = row.Cells["NhanVien_CCCD"].Value.ToString();
            string gioiTinh = row.Cells["NhanVien_GioiTinh"].Value.ToString();
            string diaChi = row.Cells["NhanVien_DiaChi"].Value.ToString();
            DateTime ngaySinh = Convert.ToDateTime(row.Cells["NhanVien_NgaySinh"].Value);
            string chucVu = row.Cells["NhanVien_ChucVu"].Value.ToString();
            string phongBan = row.Cells["NhanVien_PhongBan"].Value.ToString();

            // Hiển thị thông tin lên các TextBox tương ứng
            txtHoTen.Text = hoTen;
            txtSDT.Text = sdt;
            txtCCCD.Text = cccd;
            cboGioiTinh.SelectedItem = gioiTinh;
            txtDiaChi.Text = diaChi;
            dtpNgaySinh.Value = ngaySinh;
            cboChucVu.SelectedItem = chucVu;
            txtPhongBan.Text = phongBan;
        }
        private void LoadData()
        {
            try{
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM v_NhanVien", connection))
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            try{
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ChucVu", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        List<int> IDChucVu = new List<int>();
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            int value = Convert.ToInt32( dr["ChucVu_ID"]);
                            IDChucVu.Add(value);
                        }
                        cboChucVu.DataSource = IDChucVu;
                    }
                }
            }
            LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable TimKiemNhanVien(string ten)
        {
            DataTable dt = new DataTable();
            try{
            using (SqlConnection conn = DBUtils.GetDBConnection())
            using (SqlCommand cmd = new SqlCommand("TimKiemNhanVien", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ten", ten);
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string ten = txtTimKiem.Text;
            DataTable dt = TimKiemNhanVien(ten);
            dgvDanhSachNhanVien.DataSource = dt;
        }

        
        private void btn_load_Click(object sender, EventArgs e)
        {
            try{
            using (SqlConnection connection = DBUtils.GetDBConnection())
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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

