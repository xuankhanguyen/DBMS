using Cuoiki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private SqlConnection conn;
        // Hàm kết nối cơ sở dữ liệu
        private void ConnectToDatabase()
        {
            conn = DBUtils.GetDBConnection();
        }

        public byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void LoadDanhSachNhanVien()
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                string query = "SELECT * FROM NhanVien WHERE NhanVien_TrangThaiXoa = 0;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dgvDanhSachNhanVien.DataSource = dataTable;
                dgvDanhSachNhanVien.Columns["NhanVien_ID"].HeaderText = "ID";
                dgvDanhSachNhanVien.Columns["NhanVien_HoTen"].HeaderText = "Họ tên";
                dgvDanhSachNhanVien.Columns["NhanVien_SDT"].HeaderText = "Số điện thoại";
                dgvDanhSachNhanVien.Columns["NhanVien_CCCD"].HeaderText = "CCCD";
                dgvDanhSachNhanVien.Columns["NhanVien_GioiTinh"].HeaderText = "Giới tính";
                dgvDanhSachNhanVien.Columns["NhanVien_HinhAnh"].Visible = false;
                dgvDanhSachNhanVien.Columns["NhanVien_TrangThaiXoa"].Visible = false;
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string gioiTinh = cboGioiTinh.Text;
            byte[] hinhAnh = ConvertImageToByteArray(pbHinhAnh.Image);
            string diaChi = txtDiaChi.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            int chucVu = Convert.ToInt32(cboChucVu.SelectedValue);
            int phongBan = Convert.ToInt32(cboPhongBan.SelectedValue);
            
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                string query = "INSERT INTO NhanVien (NhanVien_HoTen, NhanVien_SDT, NhanVien_CCCD, NhanVien_GioiTinh, NhanVien_HinhAnh, " +
                    "NhanVien_DiaChi, NhanVien_NgaySinh, NhanVien_ChucVu, NhanVien_PhongBan)" +
                    " VALUES (@HoTen, @SDT, @CCCD, @GioiTinh, @HinhAnh, @DiaChi, @NgaySinh, @ChucVu, @PhongBan);";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HoTen", hoTen);
                command.Parameters.AddWithValue("@SDT", sdt);
                command.Parameters.AddWithValue("@CCCD", cccd);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                command.Parameters.AddWithValue("@ChucVu", chucVu);
                command.Parameters.AddWithValue("@PhongBan", phongBan);

                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại");
                }
            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM NhanVien WHERE NhanVien_Ten = @TenNhanVien";

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenNhanVien", txtHoTen.Text);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá nhân viên thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để xoá");
                    }
                }
            }
        }
        private byte[] GetImageData()
        {
            if (pbHinhAnh.Image == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream())
            {
               pbHinhAnh.Image.Save(ms, pbHinhAnh.Image.RawFormat);
                return ms.ToArray();
            }
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string gioiTinh = cboGioiTinh.Text;
            byte[] hinhAnh = ConvertImageToByteArray(pbHinhAnh.Image);
            string diaChi = txtDiaChi.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            int chucVu = Convert.ToInt32(cboChucVu.SelectedValue);
            int phongBan = Convert.ToInt32(cboPhongBan.SelectedValue);

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                string query = "UPDATE NhanVien SET NhanVien_HoTen = @HoTen, NhanVien_SDT = @SDT, NhanVien_CCCD = @CCCD, " +
                    "NhanVien_GioiTinh = @GioiTinh, NhanVien_HinhAnh = @HinhAnh, NhanVien_DiaChi = @DiaChi, " +
                    "NhanVien_NgaySinh = @NgaySinh, NhanVien_ChucVu = @ChucVu, NhanVien_PhongBan = @PhongBan WHERE NhanVien_ID = @ID;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HoTen", hoTen);
                command.Parameters.AddWithValue("@SDT", sdt);
                command.Parameters.AddWithValue("@CCCD", cccd);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                command.Parameters.AddWithValue("@ChucVu", chucVu);
                command.Parameters.AddWithValue("@PhongBan", phongBan);

                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công");
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thất bại");
                }
            }
        }
        private void LuuNhanVien(string hoTen, string sdt, string cccd, string gioiTinh, byte[] hinhAnh, string diaChi, DateTime ngaySinh, int chucVu, int phongBan)
        {
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                string query = "INSERT INTO NhanVien (NhanVien_HoTen, NhanVien_SDT, NhanVien_CCCD, NhanVien_GioiTinh, " +
                    "NhanVien_HinhAnh, NhanVien_DiaChi, NhanVien_NgaySinh, NhanVien_ChucVu, NhanVien_PhongBan) " +
                               "VALUES (@HoTen, @SDT, @CCCD, @GioiTinh, @HinhAnh, @DiaChi, @NgaySinh, @ChucVu, @PhongBan)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@SDT", sdt);
                    command.Parameters.AddWithValue("@CCCD", cccd);
                    command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    command.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                    command.Parameters.AddWithValue("@DiaChi", diaChi);
                    command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@PhongBan", phongBan);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các controls trên form
            string hoTen = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string cccd = txtCCCD.Text;
            string gioiTinh = cboGioiTinh.Text;
            byte[] hinhAnh = GetImageData();
            string diaChi = txtDiaChi.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            int chucVu = cboChucVu.SelectedIndex + 1; // Chú ý: index trong ComboBox bắt đầu từ 0
            int phongBan = cboPhongBan.SelectedIndex + 1;

            // Gọi hàm để lưu thông tin nhân viên vào CSDL
            LuuNhanVien(hoTen, sdt, cccd, gioiTinh, hinhAnh, diaChi, ngaySinh, chucVu, phongBan);

            // Hiển thị thông báo thành công
            MessageBox.Show("Lưu thông tin nhân viên thành công!");
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu người dùng click vào một dòng trên DataGridView
            if (e.RowIndex >= 0)
            {
                // Lấy ra dòng được click
                DataGridViewRow row = dgvDanhSachNhanVien.Rows[e.RowIndex];

                // Xoá dòng khỏi nguồn dữ liệu của DataGridView
                dgvDanhSachNhanVien.Rows.Remove(row);
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}

