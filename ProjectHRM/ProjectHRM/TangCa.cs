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
    public partial class TangCa : Form
    {
        SqlConnection con = null;
        string strcon = @"Data Source=LAPTOP-SH0M4EMV\SQLEXPRESS;Initial Catalog=QLNS1;Integrated Security=True";



        private void hienthithongtintangca()
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
            command.CommandText = "LayThongtinTangCa";
            command.Connection = con;
            SqlDataReader reader = command.ExecuteReader();
            listViewTangCa.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lvtangca = new ListViewItem(reader.GetInt32(0) + "");
                lvtangca.SubItems.Add(reader.GetInt32(1) + "");
                lvtangca.SubItems.Add(reader.GetDouble(2) + "");
                lvtangca.SubItems.Add(reader.GetString(3) + "");
                lvtangca.SubItems.Add(reader.GetString(4) + "");
                lvtangca.SubItems.Add(reader.GetInt32(5) + "");
                lvtangca.SubItems.Add(reader.GetInt32(6) + "");

                listViewTangCa.Items.Add(lvtangca);
            }
            reader.Close();
        }

        private void listViewTangCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTangCa.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem liv = listViewTangCa.SelectedItems[0];
            int ma = int.Parse(liv.SubItems[0].Text);
            hienthitheoma(ma);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void hienthitheoma(int ma)
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
            command.CommandText = "tangcatheoid";
            command.Connection = con;
            SqlParameter para = new SqlParameter("@ma_id", SqlDbType.Int);
            para.Value = ma;
            command.Parameters.Add(para);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBoxIDTangCa.Text = reader.GetInt32(0) + "";
                textBoxNgayTangCa.Text = reader.GetInt32(1) + "";
                textBoxSoGioTangCa.Text = reader.GetDouble(2) + "";
                textBoxNhanVien.Text = reader.GetString(3) + "";
                textBoxLoaiTangCa.Text = reader.GetString(4) + "";
                textBoxThangKyCong.Text = reader.GetInt32(5) + "";
                textBoxNamKyCong.Text = reader.GetInt32(6) + "";
            }
            reader.Close();
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
            command.CommandText = "ThemTangCa";
            command.Connection = con;
            command.Parameters.Add("@ngay", SqlDbType.Int).Value = textBoxNgayTangCa.Text;
            command.Parameters.Add("@gio", SqlDbType.Float).Value = textBoxSoGioTangCa.Text;
            command.Parameters.Add("@tennv", SqlDbType.NVarChar).Value = textBoxNhanVien.Text;
            command.Parameters.Add("@tenloaitc", SqlDbType.NVarChar).Value = textBoxLoaiTangCa.Text;
            command.Parameters.Add("@thangkycong", SqlDbType.Int).Value = textBoxThangKyCong.Text;
            command.Parameters.Add("@namkycong", SqlDbType.Int).Value = textBoxNamKyCong.Text;
            try
            {
                int n = command.ExecuteNonQuery();
                MessageBox.Show("Thành Công");
                hienthithongtintangca();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            command.CommandText = "SuaTangCa";
            command.Connection = con;
            command.Parameters.Add("@id", SqlDbType.Int).Value = textBoxIDTangCa.Text;
            command.Parameters.Add("@ngay", SqlDbType.Int).Value = textBoxNgayTangCa.Text;
            command.Parameters.Add("@gio", SqlDbType.Float).Value = textBoxSoGioTangCa.Text;
            command.Parameters.Add("@tennv", SqlDbType.NVarChar).Value = textBoxNhanVien.Text;
            command.Parameters.Add("@tenloaitc", SqlDbType.NVarChar).Value = textBoxLoaiTangCa.Text;
            command.Parameters.Add("@thangkycong", SqlDbType.Int).Value = textBoxThangKyCong.Text;
            command.Parameters.Add("@namkycong", SqlDbType.Int).Value = textBoxNamKyCong.Text;

            try
            {
                int n = command.ExecuteNonQuery();
                MessageBox.Show("Thành Công");
                hienthithongtintangca();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonXoaTangCa_Click(object sender, EventArgs e)
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
            command.CommandText = "XoaTangCa";
            command.Connection = con;
            command.Parameters.Add("@id", SqlDbType.Int).Value = textBoxIDTangCa.Text;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Thanh Cong");
                hienthithongtintangca();

            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void TangCa_Load_1(object sender, EventArgs e)
        {
            hienthithongtintangca();
        }
        public TangCa()
        {
            InitializeComponent();
        }
    }
}
