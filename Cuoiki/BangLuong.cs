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
            hienthithongtinluong();
        }
    }
}
