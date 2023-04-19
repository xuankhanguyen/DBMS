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

namespace QLNV
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        // Chuỗi kết nối
        string strConnectionString = @"Data Source=DESKTOP-0VDMSUU\SQLEXPRESS;Initial Catalog=QLNS1;Integrated Security=True";
        //Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtNhanVien
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;

        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
        void LoadData()
        {
            try
            {
                // Khởi động connection
                conn = new SqlConnection(strConnectionString);
                // Vận chuyển dữ liệu vào DataTable dtNhanVien
                // daNhanVien = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                // Đưa dữ liệu lên DataGridView
                dgvNhanVien.DataSource = dtNhanVien;
                // Xóa trống các đối tượng trong Panel
                this.txtMaNV.ResetText();
                this.txtHoTen.ResetText();
                this.txtGioiTinh.ResetText();
                this.dtNgaySinh.ResetText();
                this.txtChucVu.ResetText();
                this.txtDiaChi.ResetText();
                this.txtPhongBan.ResetText();
                // Không cho thao tác trên nút Lưu 
                this.btn_luu.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa 
                this.btn_them.Enabled = true;
                this.btn_sua.Enabled = true;
                this.btn_xoa.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NhanVien.Lỗi rồi!!!");
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.txtGioiTinh.ResetText();
            this.dtNgaySinh.ResetText();
            this.txtChucVu.ResetText();
            this.txtSDT.ResetText();
            this.txtDiaChi.ResetText();
            this.txtPhongBan.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy 
            this.btn_luu.Enabled = true;
            this.btn_huy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btn_them.Enabled = false;
            this.btn_sua.Enabled = false;
            this.btn_xoa.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaNV.Focus();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lấy thứ tự record hiện hành
                int r = dgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaNV của record hiện hành
                string strMaNV =
                dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete From NhanVien Where MaNV = '" + strMaNV + "'");
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã xóa thành công!");
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Đã xảy ra lỗi rồi!!!");
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            // Thứ tự dòng hiện hành
            int r = dgvNhanVien.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.txtGioiTinh.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.dtNgaySinh.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            this.txtChucVu.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            this.txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[8].Value.ToString();
            this.txtPhongBan.Text = dgvNhanVien.Rows[r].Cells[9].Value.ToString();
            // Cho thao tác trên các nút Lưu / Hủy
            this.btn_luu.Enabled = true;
            this.btn_huy.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Sua
            this.btn_them.Enabled = false;
            this.btn_sua.Enabled = false;
            this.btn_xoa.Enabled = false;
            // Đưa con trỏ đến TextField txtMaKH
            this.txtMaNV.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            conn.Open();
            // Thêm dữ liệu
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert Into NhanVien Values(" + "'" +
                    this.txtMaNV.Text.ToString() + "','" +
                    this.txtHoTen.Text.ToString() + "','" +
                    this.txtGioiTinh.Text.ToString() + "','" +
                    this.dtNgaySinh.Value.ToString("yyyy-MM-dd") + "','" +
                    this.txtChucVu.Text.ToString() + "','" +
                    this.txtSDT.Text.ToString() + "','" +
                    this.txtDiaChi.Text.ToString() + "','" +
                    this.txtPhongBan.Text.ToString() + "','" +"");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            if (!Them)
            {
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Thứ tự dòng hiện hành
                    int r = dgvNhanVien.CurrentCell.RowIndex;
                    // MaKH hiện hành
                    string strMaNV = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
                    // Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update NhanVien Set HoTen = '" + this.txtHoTen.Text.ToString() 
                        + "', GioiTinh ='" + this.txtGioiTinh.Text.ToString() + "', , NgSinh = '" + this.dtNgaySinh.Value.ToString("yyyy-MM-dd") 
                        + "', ChucVu = '" + this.txtChucVu.Text.ToString() 
                        + "', SĐT = '" + this.txtSDT.Text.ToString() + "', DiaChi = '" + this.txtDiaChi.Text.ToString() + "', PhongBan = '" 
                        + this.txtPhongBan.Text.ToString() +  "' Where MaNV = '" + strMaNV + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            // Đóng kết nối
            conn.Close();
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {

            // Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.txtGioiTinh.ResetText();
            this.dtNgaySinh.ResetText();
            this.txtChucVu.ResetText();
            this.txtSDT.ResetText();
            this.txtDiaChi.ResetText();
            this.txtPhongBan.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btn_them.Enabled = true;
            this.btn_sua.Enabled = true;
            this.btn_xoa.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btn_luu.Enabled = false;
            this.btn_huy.Enabled = false;
        }
    }
}
