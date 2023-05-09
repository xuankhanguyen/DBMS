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
    public partial class BangLuong : Form
    {
        DataTable dtStore = null;
        SqlDataAdapter adStore = null;
        public BangLuong()
        {
            InitializeComponent();
        }
        SqlConnection con = null;



        private void hienthithongtinluong()
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
            command.CommandText = "hienthiluong";
            command.Connection = con;
            command.Parameters.Add("@Nam", SqlDbType.Int).Value = cbbNam.Text;
            command.Parameters.Add("@Thang", SqlDbType.Int).Value = cbbThang.Text;

            SqlDataReader reader = command.ExecuteReader();
            listViewUngLuong.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lvungluong = new ListViewItem(reader.GetString(0) + "");
                lvungluong.SubItems.Add(reader.GetInt32(1) + "");
                lvungluong.SubItems.Add(reader.GetInt32(2) + "");
                lvungluong.SubItems.Add(reader.GetDouble(3) + "");
                lvungluong.SubItems.Add(reader.GetDouble(4) + "");
                lvungluong.SubItems.Add(reader.GetDouble(5) + "");
                lvungluong.SubItems.Add(reader.GetDouble(6) + "");
                lvungluong.SubItems.Add(reader.GetDouble(7) + "");
                lvungluong.SubItems.Add(reader.GetDouble(8) + "");
                lvungluong.SubItems.Add(reader.GetDouble(9) + "");


                listViewUngLuong.Items.Add(lvungluong);
            }
            reader.Close();
            listViewUngLuong.BackColor = Color.Gray; // đặt màu nền cho control ListView
            foreach (ListViewItem item in listViewUngLuong.Items)
            {
                item.BackColor = Color.LightBlue; // đặt màu nền cho mỗi item
            }
        }
        private void BangLuong_Load(object sender, EventArgs e)
        {
            //hienthithongtinluong();
            con = DBUtils.GetDBConnection();
            con.Open();
            try
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM DS_KyCong ORDER BY KyCong_Nam ASC", con);
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

        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            try
            {
                String nam = cbbNam.Text.Trim();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM DS_KyCong WHERE KyCong_Nam = " + nam + "ORDER BY KyCong_Thang ASC", con);
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

        private void buttonXem_Click(object sender, EventArgs e)
        {
            hienthithongtinluong();
        }

        private void buttontinhluong_Click(object sender, EventArgs e)
        {
            int makycong;
            SqlCommand cmd = new SqlCommand("SELECT KyCong_MaKyCong FROM KyCong WHERE KyCong_Thang = @Thang AND KyCong_Nam = @Nam", con);
            cmd.Parameters.AddWithValue("@Thang", cbbThang.SelectedItem);
            cmd.Parameters.AddWithValue("@Nam", cbbNam.SelectedItem);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                makycong = dr.GetInt32(0);
            }
            else
            {
                MessageBox.Show("Tháng, Năm Kỳ Công chưa hợp lệ");
                return;
            }
            dr.Close();
            con.Close();
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
            command.CommandText = "TinhLuong";
            command.Connection = con;

            command.Parameters.Add("@MaKyCong", SqlDbType.Int).Value = makycong;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("Thanh Cong");
                hienthithongtinluong();

            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }
    }
}
