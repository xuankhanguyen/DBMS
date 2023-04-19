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
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
        }
        bool Them;
        // Chuỗi kết nối
        string strConnectionString = @"Data Source=DESKTOP-0VDMSUU\SQLEXPRESS;Initial Catalog=QLNS1;Integrated Security=True";
        //Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào DataTable dtNhanVien
        SqlDataAdapter daNhanVien = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtSoHD.ResetText();
            this.dtNgayBatDau.ResetText();
            this.dtNgayKetThuc.ResetText();
            this.txtLanKy.ResetText();
            this.txtNoiDung.ResetText();
            this.txtLuongCanBan.ResetText();
            this.txtHeSoLuong.ResetText();
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
               // cmd.CommandText = System.String.Concat("Delete From NhanVien Where MaNV = '" + strMaNV + "'");
                
                cmd.CommandType = CommandType.Text;
                // Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                // Cập nhật lại DataGridView
               // LoadData();
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
            this.txtSoHD.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.dtNgayBatDau.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.dtNgayKetThuc.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
            this.txtNoiDung.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            this.txtLanKy.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            this.txtLuongCanBan.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            this.txtHeSoLuong.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
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
                    this.txtSoHD.Text.ToString() + "','" +
                    this.dtNgayBatDau.Value.ToString("yyyy-MM-dd") + "','" +
                    this.dtNgayKetThuc.Value.ToString("yyyy-MM-dd") + "','" +
                    this.txtNoiDung.Text.ToString() + "','" +
                    this.txtLanKy.Text.ToString() + "','" +
                    this.txtLuongCanBan.Text.ToString() + "','" +
                    this.txtHeSoLuong.Text.ToString() + "','" + "");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                   // LoadData();
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
                    cmd.CommandText = System.String.Concat("Update NhanVien Set NhanVien_ID = '" + this.txtMaNV.Text.ToString()
                        + "', SOHD ='" + this.txtSoHD.Text.ToString() 
                        + "', NgayBatDau = '"  + this.dtNgayBatDau.Value.ToString("yyyy-MM-dd")
                        + "', NgayKetThuc = '" + this.dtNgayKetThuc.Value.ToString("yyyy-MM-dd")
                        + "', NoiDung = '" + this.txtNoiDung.Text.ToString()
                        + "', LanKy = '" +this.txtLanKy.Text.ToString()
                        + "', LuongCanBan = '" + this.txtLuongCanBan.Text.ToString() 
                        + "', HeSoLuong = '"+ this.txtHeSoLuong.Text.ToString() + "' Where MaNV = '" + strMaNV + "'");
                    // Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                   // LoadData();
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
            this.txtSoHD.ResetText();
            this.dtNgayBatDau.ResetText();
            this.dtNgayKetThuc.ResetText();
            this.txtLanKy.ResetText();
            this.txtNoiDung.ResetText();
            this.txtLuongCanBan.ResetText();
            this.txtHeSoLuong.ResetText();
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
