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
    public partial class FormPhanQuyen : Form
    {
        private string connectionString = "Data Source=DESKTOP-H2SC4QA\\MSSQLSERVER02;Initial Catalog=QLNS;Integrated Security=True";
        public FormPhanQuyen()
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
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            //label4.ForeColor = ThemeColor.SecondaryColor;
            //label5.ForeColor = ThemeColor.PrimaryColor;
        }

        private void FormPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadTheme();
            // Tạo kết nối đến database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ database
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PhanQuyen", connection);

                // Tạo đối tượng DataTable để lưu trữ dữ liệu
                DataTable dataTable = new DataTable();

                // Sử dụng phương thức Fill của SqlDataAdapter để đổ dữ liệu từ database vào DataTable
                adapter.Fill(dataTable);

                // Gán dữ liệu từ DataTable vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private void lbIDChucVu_Click(object sender, EventArgs e)
        {

        }

        private void lbChucVu_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin phân quyền từ các control trên form
            string tenQuyen = txtTenQuyen.Text;

            // Kết nối tới database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo command để gọi thủ tục "ThemPhanQuyen"
                using (SqlCommand command = new SqlCommand("ThemMoiPhanQuyen", connection))
                {
                    //command.CommandType = CommandType.StoredProcedure;

                    // Truyền các tham số cho thủ tục "ThemPhanQuyen"
                    //command.Parameters.AddWithValue("@tenQuyen", tenQuyen);

                    // Thực hiện thủ tục và kiểm tra kết quả

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@TenQuyen", SqlDbType.NVarChar).Value = tenQuyen;
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
        }

        private void btnXoaPQ_Click(object sender, EventArgs e)
        {
            // Check that the PhanQuyen ID textbox is not empty or null
            if (string.IsNullOrEmpty(txtIDPQ.Text))
            {
                MessageBox.Show("Vui lòng nhập ID Phân Quyền cần xóa.");
                return;
            }
            int phanQuyenID;
            if (!int.TryParse(txtIDPQ.Text, out phanQuyenID))
            {
                MessageBox.Show("PhanQuyenID phai la mot so nguyen.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("XoaPhanQuyen", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PhanQuyen_ID", phanQuyenID);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Da xoa thanh cong phan quyen co ID = " + phanQuyenID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi xoa phan quyen: " + ex.Message);
            }
        }

        private void btnSuaPQ_Click(object sender, EventArgs e)
        {
            int phanQuyenID;
            if (!int.TryParse(txtIDPQ.Text, out phanQuyenID))
            {
                MessageBox.Show("PhanQuyenID phai la mot so nguyen.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("CapNhatPhanQuyen", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PhanQuyen_ID", phanQuyenID);
                        command.Parameters.AddWithValue("@TenQuyen", txtTenQuyen.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Da cap nhat thanh cong phan quyen co ID = " + phanQuyenID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi cap nhat phan quyen: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
              
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("TimKiemPhanQuyen", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@phanQuyen_ID", SqlDbType.Int).Value = !string.IsNullOrEmpty(txtIDPQ.Text) ? Convert.ToInt32(txtIDPQ.Text) : (object)DBNull.Value;
                        cmd.Parameters.Add("@phanQuyen_TenQuyen", SqlDbType.NVarChar, 20).Value = !string.IsNullOrEmpty(txtTenQuyen.Text) ? txtTenQuyen.Text : (object)DBNull.Value;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
