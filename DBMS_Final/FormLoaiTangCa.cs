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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Cuoiki.Forms
{
    public partial class FormLoaiTangCa : Form
    {
        public FormLoaiTangCa()
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM LoaiTangCa", connection);

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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTheme();
            HienThiVaocomboBox();

        }
        private void HienThiVaocomboBox()
        {
            try{
            SqlConnection conn = DBUtils.GetDBConnection();

            // Viết câu lệnh truy vấn
            string query = "SELECT LoaiTangCa_ID FROM LoaiTangCa";

            // Tạo DataTable
            DataTable dt = new DataTable();

            // Thực thi truy vấn và đổ dữ liệu vào DataTable
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);

            // Đổ dữ liệu vào ComboBox
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "LoaiTangCa_ID";
            comboBox1.ValueMember = "LoaiTangCa_ID";
            LoadTheme();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị từ các textbox
                
                string tenLoaiTangCa = txtTenLoaiTangCa.Text;
                float heSo = float.Parse(txtHeSo.Text);

                // Khởi tạo connection và command
                using (SqlConnection connection = DBUtils.GetDBConnection())
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    // Thiết lập command để gọi stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_ThemMoiLoaiTangCa";

                    // Thêm các tham số
                    //command.Parameters.AddWithValue("@LoaiTangCa_TenLoai", tenLoaiTangCa);              
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@LoaiTangCa_TenLoai", SqlDbType.NVarChar).Value = tenLoaiTangCa;
                    command.Parameters.AddWithValue("@LoaiTangCa_HeSo", heSo);
                    // Thực thi command
                    command.ExecuteNonQuery();
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm mới loại tăng ca thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mới loại tăng ca: " + ex.Message);
            }
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int loaiTangCaID;
            if (!int.TryParse(comboBox1.Text, out loaiTangCaID))
            {
                MessageBox.Show("LoaiTangCaID phai la mot so nguyen.");
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

                        using (SqlCommand command = new SqlCommand("sp_XoaLoaiTangCa", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@LoaiTangCa_ID", loaiTangCaID);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Da xoa thanh cong loai tang ca co ID = " + loaiTangCaID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi xoa loai tang ca: " + ex.Message);
                }
            }
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void txtLoaiTangCaID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int loaiTangCaID;
            if (!int.TryParse(comboBox1.Text, out loaiTangCaID))
            {
                MessageBox.Show("LoaiTangCaID phai la mot so nguyen.");
                return;
            }

            string tenLoai = txtTenLoaiTangCa.Text;
            float heSo;
            if (!float.TryParse(txtHeSo.Text, out heSo))
            {
                MessageBox.Show("He so phai la mot so thuc.");
                return;
            }

            try
            {
                using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_SuaLoaiTangCa", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@LoaiTangCa_ID", loaiTangCaID);
                        command.Parameters.AddWithValue("@LoaiTangCa_TenLoai", tenLoai);
                        command.Parameters.AddWithValue("@LoaiTangCa_HeSo", heSo);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Da sua thanh cong loai tang ca co ID = " + loaiTangCaID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi sua loai tang ca: " + ex.Message);
            }
            LoadTheme();
            HienThiVaocomboBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string timKiem = textBox1.Text;

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                SqlCommand command = new SqlCommand("TimKiemLoaiTangCa", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    command.Parameters.AddWithValue("@timKiem", timKiem);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                    reader.Close();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}
