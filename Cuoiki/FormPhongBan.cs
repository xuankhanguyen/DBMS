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
    public partial class FormPhongBan : Form
    {
        private string connectionString = "Data Source=DESKTOP-H2SC4QA\\MSSQLSERVER02;Initial Catalog=QLNS;Integrated Security=True";
        public FormPhongBan()
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

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            LoadTheme();
            // Tạo kết nối đến database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PhongBan", connection);

                // Tạo đối tượng DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Sử dụng phương thức Fill của SqlDataAdapter để đổ dữ liệu từ database vào DataTable
                adapter.Fill(dataTable);

                // Gán dữ liệu từ DataTable vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Set custom format for DateTimePicker
                    dtpNgayNhanChuc.Format = DateTimePickerFormat.Custom;
                    dtpNgayNhanChuc.CustomFormat = "MM/dd/yyyy";
                    SqlCommand cmd = new SqlCommand("sp_ThemPhongBan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenPB", txtTenPB.Text);
                    cmd.Parameters.AddWithValue("@TruongPhong", int.Parse(txtTruongPhong.Text));
                    cmd.Parameters.AddWithValue("@TG_NhanChuc", dtpNgayNhanChuc.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm phòng ban thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            int maPB = Convert.ToInt32(txtMaPB.Text);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("sp_XoaPhongBan", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@MaPB", SqlDbType.Int).Value = maPB;

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa phòng ban thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa phòng ban thất bại: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int maPB = int.Parse(txtMaPB.Text);
            string tenPB = txtTenPB.Text;
            int truongPhong = int.Parse(txtTruongPhong.Text);
            DateTime tgNhanChuc = dtpNgayNhanChuc.Value;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_CapNhatPhongBan", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaPB", maPB);
                    command.Parameters.AddWithValue("@TenPB", tenPB);
                    command.Parameters.AddWithValue("@TruongPhong", truongPhong);
                    command.Parameters.AddWithValue("@TG_NhanChuc", tgNhanChuc);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin phòng ban thành công!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin phòng ban: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
             try
            {
                int maPB = int.Parse(txtMaPB.Text);
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("TimKiemPhongBan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@maPB", maPB);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            /*
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("ThongKePhongBanTheoNgay", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số @PhongBan_TG_NhanChuc vào stored procedure
                    cmd.Parameters.Add("@ngay", SqlDbType.Date).Value = dtpNgayNhanChuc.Value;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/

            string maPB = txtMaPB.Text;
            if (string.IsNullOrEmpty(maPB))
            {
                MessageBox.Show("Vui lòng nhập mã phòng ban cần tìm kiếm!");
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("ThongKeNhanVienTheoPhongBan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maPB", maPB);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
