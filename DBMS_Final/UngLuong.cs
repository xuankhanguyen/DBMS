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
    public partial class UngLuong : Form
    {
        SqlConnection con = null;

        private void laynv(string query)
        {
            con = DBUtils.GetDBConnection();
            con.Open();
            List<string> employeeNames = new List<string>();
            SqlCommand command = new SqlCommand(query, con);
            try{
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void hienthithongtinungluong()
        {
            buttonThemUngLuong.Enabled = true;
            buttonSuaUngLuong.Enabled = true;
            buttonXoaUngLuong.Enabled = true;
            buttonLuu.Enabled = false;
            buttonHuy.Enabled = false;
            string query = "SELECT NhanVien_HoTen FROM NhanVien";
            laynv(query);
            if (con == null)
            {
                con = DBUtils.GetDBConnection();
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try{
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
            listViewUngLuong.BackColor = Color.Gray; // đặt màu nền cho control ListView
            foreach (ListViewItem item in listViewUngLuong.Items)
            {
                item.BackColor = Color.LightBlue; // đặt màu nền cho mỗi item
            }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                con = DBUtils.GetDBConnection();
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try{
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
                int day = int.Parse(reader.GetInt32(1) + "");
                comboBoxtienung.Text = reader.GetDouble(2) + "";
                textBoxTrangthaixoa.Text = reader.GetBoolean(3) + "";
                textBoxGhiChu.Text = reader.GetString(4) + "";
                comboBoxnhanvien.Text = reader.GetString(5) + "";
                int year = int.Parse(reader.GetInt32(6) + "");
                int month = int.Parse(reader.GetInt32(7) + "");
                DateTime selecteddate = new DateTime(year, month, day);
                dateTimePickerungluong.Value = selecteddate;
            }
            reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonThemUngLuong_Click(object sender, EventArgs e)
        {
            buttonSuaUngLuong.Enabled = false;
            buttonXoaUngLuong.Enabled = false;
            buttonLuu.Enabled = true;
            buttonHuy.Enabled = true;


        }

        private void buttonSuaUngLuong_Click(object sender, EventArgs e)
        {
            buttonThemUngLuong.Enabled = false;
            buttonXoaUngLuong.Enabled = false;
            buttonLuu.Enabled = true;
            buttonHuy.Enabled = true;


        }

        private void buttonXoaUngLuong_Click(object sender, EventArgs e)
        {
            buttonThemUngLuong.Enabled = false;
            buttonSuaUngLuong.Enabled = false;
            buttonLuu.Enabled = true;
            buttonHuy.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonThemUngLuong.Enabled == true)
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
                command.CommandText = "ThemUngLuong";
                command.Connection = con;
                command.Parameters.Add("@ngay", SqlDbType.Int).Value = dateTimePickerungluong.Value.Day;
                command.Parameters.Add("@tien", SqlDbType.Float).Value = comboBoxtienung.Text;
                command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = textBoxGhiChu.Text;
                command.Parameters.Add("@nhanvien", SqlDbType.NVarChar).Value = comboBoxnhanvien.Text;
                command.Parameters.Add("@nam", SqlDbType.Int).Value = dateTimePickerungluong.Value.Year;
                command.Parameters.Add("@thang", SqlDbType.Int).Value = dateTimePickerungluong.Value.Month;
                try
                {
                    int n = command.ExecuteNonQuery();
                    MessageBox.Show("Thành Công");
                    hienthithongtinungluong();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else if (buttonSuaUngLuong.Enabled == true)
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
                command.CommandText = "SuaUngLuong";
                command.Connection = con;

                command.Parameters.Add("@id", SqlDbType.Int).Value = textBoxIDUngLuong.Text;
                command.Parameters.Add("@ngay", SqlDbType.Int).Value = dateTimePickerungluong.Value.Day;
                command.Parameters.Add("@tien", SqlDbType.Float).Value = comboBoxtienung.Text;
                command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = textBoxGhiChu.Text;
                command.Parameters.Add("@nhanvien", SqlDbType.NVarChar).Value = comboBoxnhanvien.Text;
                command.Parameters.Add("@nam", SqlDbType.Int).Value = dateTimePickerungluong.Value.Year;
                command.Parameters.Add("@thang", SqlDbType.Int).Value = dateTimePickerungluong.Value.Month;
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
            else if (buttonXoaUngLuong.Enabled == true)
            {
                if (con == null)
                {
                    con = DBUtils.GetDBConnection();
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                try
                {
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
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            buttonThemUngLuong.Enabled = true;
            buttonSuaUngLuong.Enabled = true;
            buttonXoaUngLuong.Enabled = true;
            buttonLuu.Enabled = false;
            buttonHuy.Enabled = false;
            MessageBox.Show("Đã hủy thao tác");
        }
        private void UngLuong_Load(object sender, EventArgs e)
        {
            hienthithongtinungluong();
        }
        public UngLuong()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
