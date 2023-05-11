﻿using System;
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
    public partial class KyCongHRM : Form
    {
        public KyCongHRM()
        {
            InitializeComponent();
        }
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtStore = null;
        SqlDataAdapter adStore = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Add = false;
        // Phuong thuc dung chung
        void ResetAllTextBox()
        {
            cbbNam.ResetText();
            cbbThang.ResetText();
        }
        void SetBtEdit_On()
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            // Enable các control Add, Edit, Delete, Exit...
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            dtGridView.Enabled = false;
        }
        void SetBtEdit_Off()
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            // Enable các control Add, Edit, Delete, Exit...
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            dtGridView.Enabled = true;
            Add = false;
        }

        private void Can_Tomau() //Can chinh va to mau
        {
            dtGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtGridView.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
        }

        void LoadData()
        {
            ResetAllTextBox();
            SetBtEdit_Off();
            //Tạo kết nối
            try
            {

                conn = DBUtils.GetDBConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DS_KyCong ORDER BY KyCong_Nam ASC", conn);
                adStore = new SqlDataAdapter(cmd);
                dtStore = new DataTable();
                adStore.Fill(dtStore);
                dtGridView.DataSource = dtStore;
                Can_Tomau();
                //
                List<string> Nam = new List<string>();
                foreach (DataRow dr in dtStore.Rows)
                {
                    String value = dr["KyCong_Nam"].ToString();
                    if (!Nam.Contains(value))
                    {
                        Nam.Add(value);
                    }
                }
                cbbNam.DataSource = Nam;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng KyCong: " + ex.Message, "Lỗi dữ liệu!");
            }
        }

        private void KyCongHRM_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy Row hiện tại
            int r = dtGridView.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên
            cbbNam.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            cbbThang.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            if (Add == true)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Add = true;
            // Xóa trống các đối tượng trong Panel
            ResetAllTextBox();
            // Kích hoạt chế độ nhập/sửa dữ liệu
            SetBtEdit_On();
            cbbNam.Focus();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!cbbNam.Text.Trim().Equals("") && !cbbThang.Text.Trim().Equals(""))
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    string Nam = cbbNam.Text.Trim();
                    string Thang = cbbThang.Text.Trim();

                    // kiểm tra tồn tại
                    string query = "SELECT dbo.TK_KyCong(@Nam, @Thang)";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Nam", Nam);
                    cmd.Parameters.AddWithValue("@Thang", Thang);
                    int kq = (int)cmd.ExecuteScalar();
                    if (Add) // Thêm dữ liệu
                    {
                        try
                        {

                            switch (kq)
                            {
                                case -2: // thực hiện thêm
                                    SqlCommand cmd1 = new SqlCommand("ThemKyCong", conn);
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.Add("@Nam", SqlDbType.VarChar).Value = Nam;
                                    cmd1.Parameters.Add("@Thang", SqlDbType.VarChar).Value = Thang;
                                    SqlParameter sqlParameter = new SqlParameter("@KetQua", SqlDbType.Int);
                                    sqlParameter.Direction = ParameterDirection.Output;
                                    cmd1.Parameters.Add(sqlParameter);
                                    cmd1.ExecuteNonQuery();
                                    ResetAllTextBox();
                                    SetBtEdit_Off();
                                    if ((int)sqlParameter.Value == -1)
                                    {
                                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện thêm dữ liệu!");
                                        return;
                                    }
                                    break;
                                case -1:
                                    SqlCommand cmd2 = new SqlCommand("CapNhatTrangThaiKyCong", conn);
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.Add("@Nam", SqlDbType.VarChar).Value = Nam;
                                    cmd2.Parameters.Add("@Thang", SqlDbType.VarChar).Value = Thang;
                                    SqlParameter sqlParameter1 = new SqlParameter("@KetQua", SqlDbType.Int);
                                    sqlParameter1.Direction = ParameterDirection.Output;
                                    cmd2.Parameters.Add(sqlParameter1);
                                    cmd2.ExecuteNonQuery();
                                    ResetAllTextBox();
                                    SetBtEdit_Off();
                                    if ((int)sqlParameter1.Value == 0)
                                    {
                                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện khôi phục dữ liệu!");
                                        return;
                                    }
                                    break;
                                default:
                                    MessageBox.Show("Kỳ công hiện tại đã có rồi");
                                    ResetAllTextBox();
                                    SetBtEdit_Off();
                                    return;
                            }

                            //
                            MessageBox.Show("Đã thêm dữ liệu thành công!");
                            LoadData();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else // sua doi
                    {
                        try
                        {
                            switch (kq)
                            {
                                case -2:
                                    // Thứ tự dòng hiện hành
                                    int r = dtGridView.CurrentCell.RowIndex;// Ma hiện hành
                                    int makycong =
                                    Convert.ToInt32(dtGridView.Rows[r].Cells[0].Value.ToString());
                                    SqlCommand cmd1 = new SqlCommand("CapNhatKyCong", conn);
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.Parameters.Add("@MaKyCong", SqlDbType.Int).Value = makycong;
                                    cmd1.Parameters.Add("@Nam", SqlDbType.Int).Value = Convert.ToInt32(Nam);
                                    cmd1.Parameters.Add("@Thang", SqlDbType.Int).Value = Convert.ToInt32(Thang);
                                    SqlParameter sqlParameter = new SqlParameter("@KetQua", SqlDbType.Int);
                                    sqlParameter.Direction = ParameterDirection.Output;
                                    cmd1.Parameters.Add(sqlParameter);
                                    cmd1.ExecuteNonQuery();
                                    ResetAllTextBox();
                                    SetBtEdit_Off();
                                    if ((int)sqlParameter.Value == -1)
                                    {
                                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện sửa dữ liệu!");
                                        return;
                                    }
                                    LoadData();
                                    // Thông báo
                                    MessageBox.Show("Đã sửa xong!");
                                    break;
                                case -1:
                                    SqlCommand cmd2 = new SqlCommand("CapNhatTrangThaiKyCong", conn);
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.Add("@Nam", SqlDbType.VarChar).Value = Nam;
                                    cmd2.Parameters.Add("@Thang", SqlDbType.VarChar).Value = Thang;
                                    SqlParameter sqlParameter1 = new SqlParameter("@KetQua", SqlDbType.Int);
                                    sqlParameter1.Direction = ParameterDirection.Output;
                                    cmd2.Parameters.Add(sqlParameter1);
                                    cmd2.ExecuteNonQuery();
                                    LoadData();
                                    if ((int)sqlParameter1.Value == 0)
                                    {
                                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện khôi phục dữ liệu!");
                                        return;
                                    }
                                    break;
                                default:
                                    MessageBox.Show("Kỳ công hiện tại đã có rồi");
                                    ResetAllTextBox();
                                    SetBtEdit_Off();
                                    return;
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);// "Không sửa được. Lỗi rồi!");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                // Đóng kết nối
                conn.Close();
            }
            else
            {
                MessageBox.Show("Tháng hoặc năm chưa có. Lỗi rồi!");
                cbbNam.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.SetBtEdit_Off();
            ResetAllTextBox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            dataGridView_CellClick(null, null);
            SetBtEdit_On();
            cbbNam.Focus();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra User có muốn xóa hàng dữ liệu
            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckYN == DialogResult.Yes)
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {
                    // Thứ tự dòng hiện hành
                    int r = dtGridView.CurrentCell.RowIndex;
                    SqlCommand cmd2 = new SqlCommand("CapNhatTrangThaiKyCong", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@Nam", SqlDbType.VarChar).Value = dtGridView.Rows[r].Cells[1].Value.ToString();
                    cmd2.Parameters.Add("@Thang", SqlDbType.VarChar).Value = dtGridView.Rows[r].Cells[2].Value.ToString();
                    SqlParameter sqlParameter1 = new SqlParameter("@KetQua", SqlDbType.Int);
                    sqlParameter1.Direction = ParameterDirection.Output;
                    cmd2.Parameters.Add(sqlParameter1);
                    cmd2.ExecuteNonQuery();
                    if ((int)sqlParameter1.Value == 0)
                    {
                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện xóa dữ liệu!");
                        ResetAllTextBox();
                        SetBtEdit_Off();
                        return;
                    }
                    SqlCommand cmd = new SqlCommand();
                    string query = "SELECT dbo.Find_MaKyCong(@Nam, @Thang)";
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Nam", dtGridView.Rows[r].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@Thang", dtGridView.Rows[r].Cells[2].Value.ToString());
                    int kq = (int)cmd.ExecuteScalar();
                    // Xóa CCTT
                    SqlCommand cmd3 = new SqlCommand("XoaKCCT", conn);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.Add("@MaKyCong", SqlDbType.Int).Value = kq;

                    SqlParameter sqlParameter2 = new SqlParameter("@KetQua", SqlDbType.Int);
                    sqlParameter2.Direction = ParameterDirection.Output;
                    cmd3.Parameters.Add(sqlParameter2);
                    cmd3.ExecuteNonQuery();
                    if ((int)sqlParameter2.Value == 0)
                    {
                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện xóa dữ liệu!");
                        ResetAllTextBox();
                        SetBtEdit_Off();
                        return;
                    }
                    // Xoa ChamCong
                    SqlCommand cmd4 = new SqlCommand("XoaChamCong", conn);
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.Parameters.Add("@MaKyCong", SqlDbType.Int).Value = kq;

                    SqlParameter sqlParameter3 = new SqlParameter("@KetQua", SqlDbType.Int);
                    sqlParameter3.Direction = ParameterDirection.Output;
                    cmd4.Parameters.Add(sqlParameter3);
                    cmd4.ExecuteNonQuery();
                    if ((int)sqlParameter3.Value == 0)
                    {
                        MessageBox.Show("Có lỗi hệ thống không thể thực hiện xóa dữ liệu!");
                        ResetAllTextBox();
                        SetBtEdit_Off();
                        return;
                    }
                    // Xóa tính lương
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "xoaluongtheokycong";
                    command.Connection = conn;

                    command.Parameters.Add("@MaKyCong", SqlDbType.Int).Value = kq;
                    command.ExecuteNonQuery();

                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không xóa được kỳ công hiện hành. " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            SetBtEdit_Off();
        }
    }
}
