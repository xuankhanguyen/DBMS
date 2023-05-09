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
using Button = System.Windows.Forms.Button;

namespace Cuoiki.Forms
{
    public partial class FormPhongBan : Form
    {
       
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
                try{
                // Tạo kết nối đến database
                using (SqlConnection connection = DBUtils.GetDBConnection())
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
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            LoadTheme();
            HienThiVaocomboBox();
           
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
            using (SqlConnection conn = DBUtils.GetDBConnection())
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
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void HienThiVaocomboBox()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try{
            // Viết câu lệnh truy vấn
            string query1 = "SELECT PhongBan_MaPB FROM PhongBan";
            string query2 = "SELECT PhongBan_MaPB FROM PhongBan";
            // Tạo DataTable
            DataTable dt1 = new DataTable();

            // Thực thi truy vấn và đổ dữ liệu vào DataTable
            SqlDataAdapter da1 = new SqlDataAdapter(query1, conn);
            da1.Fill(dt1);

            // Đổ dữ liệu vào ComboBox
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "PhongBan_MaPB";
            comboBox1.ValueMember = "PhongBan_MaPB";
            LoadTheme();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int maPB = Convert.ToInt32(comboBox1.Text);

            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
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
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int maPB = int.Parse(comboBox1.Text);
            string tenPB = txtTenPB.Text;
            int truongPhong = int.Parse(txtTruongPhong.Text);
            DateTime tgNhanChuc = dtpNgayNhanChuc.Value;

            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
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
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
             try
            {
                int maPB = int.Parse(comboBox1.Text);
                using (SqlConnection conn = DBUtils.GetDBConnection())
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

            string maPB = comboBox1.Text;
            if (string.IsNullOrEmpty(maPB))
            {
                MessageBox.Show("Vui lòng nhập mã phòng ban cần tìm kiếm!");
                return;
            }
            try
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
