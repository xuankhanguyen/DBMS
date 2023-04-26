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

namespace ProjectHRM
{
    public partial class UngLuong : Form
    {
        SqlConnection con = null;
        string strcon = @"Data Source=LAPTOP-SH0M4EMV\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";

        private void hienthithongtinungluong()
        {
            if (con == null)
            {
                con = new SqlConnection(strcon);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "LayThongtinUngLuong";
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();
            listViewUngLuong.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lvungluong = new ListViewItem(reader.GetInt32(0) + "");
                lvungluong.SubItems.Add(reader.GetInt32(1) + "");
                lvungluong.SubItems.Add(reader.GetDouble(2) + "");
                lvungluong.SubItems.Add(reader.GetBoolean(3) + "");
                lvungluong.SubItems.Add(reader.GetString(4) + "");
                lvungluong.SubItems.Add(reader.GetString(5) + "");
                lvungluong.SubItems.Add(reader.GetInt32(6) + "");
                lvungluong.SubItems.Add(reader.GetInt32(7) + "");

                listViewUngLuong.Items.Add(lvungluong);
            }
            reader.Close();
        }

        private void listViewUngLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUngLuong.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem liv = listViewUngLuong.SelectedItems[0];
            int ma = int.Parse(liv.SubItems[0].Text);
            hienthiungluongtheoma(ma);
        }
        private void hienthiungluongtheoma(int ma)
        {
            if (con == null)
            {
                con = new SqlConnection(strcon);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ungluongtheoid";
            command.Connection = con;
            SqlParameter para = new SqlParameter("@ma_id", SqlDbType.Int);
            para.Value = ma;
            command.Parameters.Add(para);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBoxIDUngLuong.Text = reader.GetInt32(0) + "";
                textBoxNgayUngLuong.Text = reader.GetInt32(1) + "";
                textBoxSotienungluong.Text = reader.GetDouble(2) + "";
                textBoxTrangthaixoa.Text = reader.GetBoolean(3) + "";
                textBoxGhiChu.Text = reader.GetString(4) + "";
                textBoxNhanVien.Text = reader.GetString(5) + "";
                textBoxNam.Text = reader.GetInt32(6) + "";
                textBoxThang.Text = reader.GetInt32(7) + "";

            }
            reader.Close();
        }

        private void buttonThemUngLuong_Click(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new SqlConnection(strcon);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ThemUngLuong";
            command.Connection = con;
            command.Parameters.Add("@ngay", SqlDbType.Int).Value = textBoxNgayUngLuong.Text;
            command.Parameters.Add("@tien", SqlDbType.Float).Value = textBoxSotienungluong.Text;
            command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = textBoxGhiChu.Text;
            command.Parameters.Add("@nhanvien", SqlDbType.NVarChar).Value = textBoxNhanVien.Text;
            command.Parameters.Add("@nam", SqlDbType.Int).Value = textBoxNam.Text;
            command.Parameters.Add("@thang", SqlDbType.Int).Value = textBoxThang.Text;
            SqlParameter ketqua = command.Parameters.Add("@ketqua", SqlDbType.Int);
            ketqua.Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            object resultObj = ketqua.Value;
            if (resultObj != DBNull.Value)
            {
                int result = (int)resultObj;
                if (result == 1)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Giá trị  không hợp lệ");
            }
            hienthithongtinungluong();

        }

        private void buttonSuaUngLuong_Click(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new SqlConnection(strcon);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SuaUngLuong";
            command.Connection = con;

            command.Parameters.Add("@id", SqlDbType.Int).Value = textBoxIDUngLuong.Text;
            command.Parameters.Add("@ngay", SqlDbType.Int).Value = textBoxNgayUngLuong.Text;
            command.Parameters.Add("@tien", SqlDbType.Float).Value = textBoxSotienungluong.Text;
            command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = textBoxGhiChu.Text;
            command.Parameters.Add("@nhanvien", SqlDbType.NVarChar).Value = textBoxNhanVien.Text;
            command.Parameters.Add("@nam", SqlDbType.Int).Value = textBoxNam.Text;
            command.Parameters.Add("@thang", SqlDbType.Int).Value = textBoxThang.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Thanh Cong");
                hienthithongtinungluong();

            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void buttonXoaUngLuong_Click(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new SqlConnection(strcon);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "XoaUngLuong";
            command.Connection = con;
            command.Parameters.Add("@id", SqlDbType.Int).Value = textBoxIDUngLuong.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Thanh Cong");
                hienthithongtinungluong();

            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new SqlConnection(strcon);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "LuuXoaUngLuong";
            command.Connection = con;
            command.Parameters.Add("@id", SqlDbType.Int).Value = textBoxIDUngLuong.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Thanh Cong");
                hienthithongtinungluong();

            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new SqlConnection(strcon);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "HuyXoaUngLuong";
            command.Connection = con;
            command.Parameters.Add("@id", SqlDbType.Int).Value = textBoxIDUngLuong.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Thanh Cong");
                hienthithongtinungluong();

            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }
        private void UngLuong_Load(object sender, EventArgs e)
        {
            hienthithongtinungluong();
        }
        public UngLuong()
        {
            InitializeComponent();
        }

    }
}
