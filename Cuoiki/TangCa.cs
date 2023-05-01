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

namespace Cuoiki
{
    public partial class TangCa : Form
    {
        SqlConnection con = null;
        private void laynv(string query)
        {
            con = DBUtils.GetDBConnection();
            con.Open();
            List<string> employeeNames = new List<string>();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0) + "";
                employeeNames.Add(name);
            }
            reader.Close();
            con.Close();
            comboBoxnhanvien.Items.AddRange(employeeNames.ToArray());
        }
        private void layloai(string query)
        {
            con = DBUtils.GetDBConnection();
            con.Open();
            List<string> employeeNames = new List<string>();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0) + "";
                employeeNames.Add(name);
            }
            reader.Close();
            con.Close();
            comboBoxloaitangca.Items.AddRange(employeeNames.ToArray());
        }
        private void hienthithongtintangca()
        {
            buttonThemTangCa.Enabled = true;
            buttonSuaTangCa.Enabled = true;
            buttonXoaTangCa.Enabled = true;
            buttonLuu.Enabled = false;
            buttonhuy.Enabled = false;

            string query = "SELECT NhanVien_HoTen FROM NhanVien";
            laynv(query);
            string query1 = "SELECT LoaiTangCa_TenLoai FROM LoaiTangCa";
            layloai(query1);
            if (con == null)
            {
                con = DBUtils.GetDBConnection();
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
            listViewTangCa.BackColor = Color.Gray; // đặt màu nền cho control ListView
            foreach (ListViewItem item in listViewTangCa.Items)
            {
                item.BackColor = Color.LightBlue; // đặt màu nền cho mỗi item
            }
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
                con = DBUtils.GetDBConnection();
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

                int day = int.Parse(reader.GetInt32(1) + "");
                textBoxIDTangCa.Text = reader.GetInt32(0) + "";
                textBoxSoGioTangCa.Text = reader.GetDouble(2) + "";
                comboBoxnhanvien.Text = reader.GetString(3) + "";
                comboBoxloaitangca.Text = reader.GetString(4) + "";
                int month = int.Parse(reader.GetInt32(5) + "");
                int year = int.Parse(reader.GetInt32(6) + "");
                DateTime selecteddate = new DateTime(year, month, day);
                dateTimePickertangca.Value = selecteddate;
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonSuaTangCa.Enabled = false;
            buttonXoaTangCa.Enabled = false;
            buttonLuu.Enabled = true;
            buttonhuy.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonThemTangCa.Enabled = false;
            buttonXoaTangCa.Enabled = false;
            buttonLuu.Enabled = true;
            buttonhuy.Enabled = true;

        }

        private void buttonXoaTangCa_Click(object sender, EventArgs e)
        {
            buttonThemTangCa.Enabled = false;
            buttonSuaTangCa.Enabled = false;
            buttonLuu.Enabled = true;
            buttonhuy.Enabled = true;

        }

        private void TangCa_Load_1(object sender, EventArgs e)
        {
            hienthithongtintangca();


        }
        public TangCa()
        {
            InitializeComponent();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (buttonThemTangCa.Enabled == true)
            {
                if (con == null)
                {
                    con = DBUtils.GetDBConnection();
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ThemTangCa";
                command.Connection = con;
                command.Parameters.Add("@ngay", SqlDbType.Int).Value = dateTimePickertangca.Value.Day;
                command.Parameters.Add("@gio", SqlDbType.Float).Value = textBoxSoGioTangCa.Text;
                command.Parameters.Add("@tennv", SqlDbType.NVarChar).Value = comboBoxnhanvien.Text;
                command.Parameters.Add("@tenloaitc", SqlDbType.NVarChar).Value = comboBoxloaitangca.Text;
                command.Parameters.Add("@thangkycong", SqlDbType.Int).Value = dateTimePickertangca.Value.Month;
                command.Parameters.Add("@namkycong", SqlDbType.Int).Value = dateTimePickertangca.Value.Year;
                try
                {
                    int n = command.ExecuteNonQuery();
                    MessageBox.Show("Thành Công");
                    hienthithongtintangca();

                }
                catch
                {
                    MessageBox.Show("Dữ liệu đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else if (buttonSuaTangCa.Enabled == true)
            {
                if (con == null)
                {
                    con = DBUtils.GetDBConnection();
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SuaTangCa";
                command.Connection = con;
                int idTangCa;
                if (int.TryParse(textBoxIDTangCa.Text, out idTangCa))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = idTangCa;
                }
                else
                {
                    MessageBox.Show("Chọn tăng ca hợp lệ");
                    return;
                }
                command.Parameters.Add("@ngay", SqlDbType.Int).Value = dateTimePickertangca.Value.Day;
                command.Parameters.Add("@gio", SqlDbType.Float).Value = textBoxSoGioTangCa.Text;
                command.Parameters.Add("@tennv", SqlDbType.NVarChar).Value = comboBoxnhanvien.Text;
                command.Parameters.Add("@tenloaitc", SqlDbType.NVarChar).Value = comboBoxloaitangca.Text;
                command.Parameters.Add("@thangkycong", SqlDbType.Int).Value = dateTimePickertangca.Value.Month;
                command.Parameters.Add("@namkycong", SqlDbType.Int).Value = dateTimePickertangca.Value.Year;
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
            else if (buttonXoaTangCa.Enabled == true)
            {
                if (con == null)
                {
                    con = DBUtils.GetDBConnection();
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
                try
                {
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
                catch
                {
                    MessageBox.Show("Khong hop le ");
                }
            }
        }

        private void buttonhuy_Click(object sender, EventArgs e)
        {
            buttonThemTangCa.Enabled = true;
            buttonSuaTangCa.Enabled = true;
            buttonXoaTangCa.Enabled = true;
            buttonLuu.Enabled = false;
            buttonhuy.Enabled = false;
            MessageBox.Show("Đã hủy thao tác");
        }
    }
}
