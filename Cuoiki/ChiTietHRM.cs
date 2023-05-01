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

namespace Cuoiki
{
    public partial class ChiTietHRM : Form
    {

        private string nam, thang;

        public ChiTietHRM()
        {
            InitializeComponent();
        }

        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtStore = null;
        SqlDataAdapter adStore = null;
        //
        int ThaoTac, kq, giatri;


        private void Can_Tomau() //Can chinh va to mau
        {

            dtGridView.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }
        void Tk_KyCong()
        {
            // Mở kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string query = "SELECT dbo.TK_KyCong(@Nam, @Thang)";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@Thang", thang);
                kq = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void LoadData()
        {
            // Mở kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            Tk_KyCong();
            try
            {

                if (kq >= 0)
                {
                    SqlCommand cmd1 = new SqlCommand("ThongKeCong", conn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@KyCong", SqlDbType.Int).Value = kq;
                    cmd1.Parameters.Add("@ThaoTac", SqlDbType.Int).Value = ThaoTac;
                    SqlParameter sqlParameter = new SqlParameter("@KetQua", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    cmd1.Parameters.Add(sqlParameter);
                    adStore = new SqlDataAdapter(cmd1);
                    dtStore = new DataTable();
                    adStore.Fill(dtStore);
                    dtGridView.DataSource = dtStore;
                    Can_Tomau();
                }
                else
                {
                    MessageBox.Show("Kỳ công này không tồn tại");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng Ky Cong Chi tiet " + ex.Message, "Lỗi dữ liệu!");
            }
        }
        private void ChitietHRM_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            //Tạo kết nối
            conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM DS_KyCong", conn);
                adStore = new SqlDataAdapter(cmd2);
                dtStore = new DataTable();
                adStore.Fill(dtStore);
                List<string> dsNam = new List<string>();
                foreach (DataRow dr in dtStore.Rows)
                {
                    String value = dr["KyCong_Nam"].ToString();
                    if (!dsNam.Contains(value))
                    {
                        dsNam.Add(value);
                    }
                }
                cbbNam.DataSource = dsNam;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nam = cbbNam.Text.ToString();
            thang = cbbThang.Text.ToString();
            // Mở kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            try
            {
                SqlCommand cmd1 = new SqlCommand();
                string query1 = "SELECT dbo.soNgayTrongThang(@Nam, @Thang)";
                cmd1.Connection = conn;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = query1;
                cmd1.Parameters.AddWithValue("@Nam", nam);
                cmd1.Parameters.AddWithValue("@Thang", "0" + thang);
                giatri = (int)cmd1.ExecuteScalar();
                // Kiểm tra xem người dùng đã nhấn vào ô có ComboBox hay không
                if (e.ColumnIndex >= 3 && e.ColumnIndex <= giatri + 3 && e.RowIndex < dtGridView.Rows.Count - 1 && e.RowIndex != -1)
                {
                    SqlCommand cmd = new SqlCommand();
                    string query = "SELECT dbo.KT_NgayTrongTuan(@Nam, @Thang, @Ngay)";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Ngay", e.ColumnIndex - 2);
                    kq = (int)cmd.ExecuteScalar();
                    // Tạo ComboBox và gắn vào ô tương ứng
                    DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                    if (kq == 1)
                    {
                        comboBoxCell.Items.Add("CN");
                    }
                    else
                    {
                        comboBoxCell.Items.Add("X");
                    }
                    comboBoxCell.Items.Add("V");
                    dtGridView[e.ColumnIndex, e.RowIndex] = comboBoxCell;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(btnUpdate.Enabled == false) {
                btnUpdate.Enabled = true;
            }
            // Kiểm tra xem người dùng đã thay đổi giá trị của ô ComboBox hay không
            if (e.ColumnIndex >= 3 && e.ColumnIndex <= giatri + 3 && e.RowIndex < dtGridView.Rows.Count - 1 && e.RowIndex != -1)
            {
                DataGridViewCell cell = dtGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                try
                {
                    SqlCommand cmd2 = new SqlCommand("CapNhatChamCong", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@NhanVien", SqlDbType.Int).Value = Convert.ToInt32(dtGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cmd2.Parameters.Add("@KyCong", SqlDbType.Int).Value = Convert.ToInt32(dtGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cmd2.Parameters.Add("@Ngay", SqlDbType.Int).Value = e.ColumnIndex - 2;
                    cmd2.Parameters.Add("@GiaTri", SqlDbType.VarChar).Value = cell.Value.ToString().Equals("V") ? "" : "07:00";
                    SqlParameter sqlParameter1 = new SqlParameter("@KetQua", SqlDbType.Int);
                    sqlParameter1.Direction = ParameterDirection.Output;
                    cmd2.Parameters.Add(sqlParameter1);
                    cmd2.ExecuteNonQuery();
                    if ((int)sqlParameter1.Value == 0)
                    {
                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện cập nhật dữ liệu!");
                        return;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            try
            {
                String nam = cbbNam.Text.Trim();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM DS_KyCong WHERE KyCong_Nam = " + nam, conn);
                adStore = new SqlDataAdapter(cmd2);
                dtStore = new DataTable();
                adStore.Fill(dtStore);
                List<string> dsThang = new List<string>();
                foreach (DataRow dr in dtStore.Rows)
                {
                    String value = dr["KyCong_Thang"].ToString();
                    dsThang.Add(value);
                }
                cbbThang.DataSource = dsThang;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ThaoTac = 1;
            LoadData();
            btnUpdate.Enabled = false;
        }

        private void dtGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            nam = cbbNam.Text.ToString();
            thang = cbbThang.Text.ToString();
            ThaoTac = 2;
            LoadData();
        }

        private void btnPhatSinh_Click(object sender, EventArgs e)
        {
            nam = cbbNam.Text.ToString();
            thang = cbbThang.Text.ToString();
            // Mở kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string query = "SELECT dbo.KT_PhatSinhKyCong(@KyCong_ID)";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@KyCong_ID", kq);
                int kq1 = (int)cmd.ExecuteScalar();

                if (kq1 == 0)
                {
                    SqlCommand phatsinh = new SqlCommand("PhatSinhKyCong", conn);
                    phatsinh.CommandType = CommandType.StoredProcedure;
                    phatsinh.Parameters.Add("@KyCong", SqlDbType.Int).Value = kq;
                    phatsinh.ExecuteNonQuery();
                    ThaoTac = 0;
                    LoadData();
                }
                else
                {
                    // Kiểm tra User có muốn xóa hàng dữ liệu
                    DialogResult CheckYN;
                    CheckYN = MessageBox.Show("Có chắc phát sinh trở lại kỳ công này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (CheckYN == DialogResult.Yes)
                    {
                        SqlCommand cmd1 = new SqlCommand("XoaChamCong", conn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.Add("@MaKyCong", SqlDbType.Int).Value = kq;
                        SqlParameter sqlParameter = new SqlParameter("@KetQua", SqlDbType.Int);
                        sqlParameter.Direction = ParameterDirection.Output;
                        cmd1.Parameters.Add(sqlParameter);
                        cmd1.ExecuteNonQuery();
                        if ((int)sqlParameter.Value == 0)
                        {
                            MessageBox.Show("Có lỗi hệ thống không thể thực hiện xóa Chấm Công");
                            return;
                        }
                        SqlCommand cmd2 = new SqlCommand("XoaKCCT", conn);
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@MaKyCong", SqlDbType.Int).Value = kq;
                        SqlParameter sqlParameter1 = new SqlParameter("@KetQua", SqlDbType.Int);
                        sqlParameter1.Direction = ParameterDirection.Output;
                        cmd2.Parameters.Add(sqlParameter1);
                        cmd2.ExecuteNonQuery();
                        if ((int)sqlParameter1.Value == 0)
                        {
                            MessageBox.Show("Có lỗi hệ thống không thể thực hiện xóa Chấm Công");
                            return;
                        }
                        SqlCommand phatsinh1 = new SqlCommand("PhatSinhKyCong", conn);
                        phatsinh1.CommandType = CommandType.StoredProcedure;
                        phatsinh1.Parameters.Add("@KyCong", SqlDbType.Int).Value = kq;
                        phatsinh1.ExecuteNonQuery();
                        ThaoTac = 1;
                        LoadData();
                        MessageBox.Show("Đã thực hiện phát sinh lại kỳ công");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
