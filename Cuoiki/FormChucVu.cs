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
    public partial class FormChucVu: Form
    {
        public FormChucVu()
        {
            InitializeComponent();
            
        }
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Add = false;
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.Black ;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            // Tạo kết nối đến database
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ChucVu", connection);

                // Tạo đối tượng DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Sử dụng phương thức Fill của SqlDataAdapter để đổ dữ liệu từ database vào DataTable
                adapter.Fill(dataTable);

                // Gán dữ liệu từ DataTable vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }
        private void HienThiVaocomboBox()
        {
            SqlConnection conn = DBUtils.GetDBConnection();

            // Viết câu lệnh truy vấn
            string query = "SELECT ChucVu_ID FROM ChucVu";

            // Tạo DataTable
            DataTable dt = new DataTable();

            // Thực thi truy vấn và đổ dữ liệu vào DataTable
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);

            // Đổ dữ liệu vào ComboBox
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ChucVu_ID";
            comboBox1.ValueMember = "ChucVu_ID";
            LoadTheme();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy Row hiện tại
            int r = dataGridView1.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên
            txtTenChucVu.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            if (Add == true)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Lấy thông tin phân quyền từ các control trên form
            string tenCV = txtTenChucVu.Text;

            // Kết nối tới database
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                // Tạo command để gọi thủ tục "ThemPhanQuyen"
                using (SqlCommand command = new SqlCommand("sp_ThemMoiChucVu", connection))
                {
                    //command.CommandType = CommandType.StoredProcedure;

                    // Truyền các tham số cho thủ tục "ThemPhanQuyen"
                    //command.Parameters.AddWithValue("@tenQuyen", tenQuyen);

                    // Thực hiện thủ tục và kiểm tra kết quả
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@ChucVu_TenCV", SqlDbType.NVarChar).Value = tenCV;
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm phân quyền thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm phân quyền thất bại!");
                    }
                }
            }
            LoadTheme();
            HienThiVaocomboBox();
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            int chucVuID;
            if (!int.TryParse(comboBox1.Text, out chucVuID))
            {
                MessageBox.Show("ChucVuID phai la mot so nguyen.");
                return;
            }
            // Kiểm tra User có muốn xóa hàng dữ liệu
            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckYN == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = DBUtils.GetDBConnection())
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("sp_XoaChucVu", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@ChucVu_ID", chucVuID);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Da xoa thanh cong chuc vu co ID = " + chucVuID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi xoa chuc vu: " + ex.Message);
                }
                LoadTheme();
                HienThiVaocomboBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int chucVuID = int.Parse(comboBox1.Text);
                string tenChucVu = txtTenChucVu.Text;

                // Khởi tạo kết nối đến database
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    // Khởi tạo đối tượng SqlCommand để thực thi thủ tục
                    using (SqlCommand command = new SqlCommand("sp_SuaChucVu", connection))
                    {
                        // Thiết lập loại command là StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;

                        // Truyền tham số vào thủ tục
                        command.Parameters.AddWithValue("@ChucVu_ID", chucVuID);
                        command.Parameters.AddWithValue("@ChucVu_TenCV", tenChucVu);

                        // Mở kết nối đến database
                        connection.Open();

                        // Thực thi thủ tục
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra xem có bao nhiêu dòng bị ảnh hưởng
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Sửa thông tin chức vụ thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy chức vụ để sửa.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = DBUtils.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("TimKiemChucVu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số @chucVu_ID vào command
                        cmd.Parameters.Add("@chucVu_ID", SqlDbType.Int).Value = int.Parse(comboBox1.Text);

                        conn.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Hiển thị kết quả trả về trên DataGridView
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            LoadTheme();
            HienThiVaocomboBox();
        }
    }
}
