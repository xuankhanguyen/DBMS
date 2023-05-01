using Cuoiki;
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
    public partial class frmHeSoLuong : Form
    {
        public frmHeSoLuong()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            
            string query = "INSERT INTO HeSoLuong (HeSoLuong_Ten, HeSoLuong_GiaTri) VALUES (@Ten, @GiaTri)";

            using (SqlConnection connection = DBUtils.GetDBConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ten", txtTen.Text);
                        command.Parameters.AddWithValue("@GiaTri", float.Parse(txtHeSo.Text));

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm hệ số lương thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm hệ số lương thất bại");
                        }
                    }              
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM HeSoLuong WHERE HeSoLuong_Ten = @TenHeSoLuong";

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenHeSoLuong", txtHeSo.Text);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xoá hệ số lương thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hệ số lương để xoá");
                    }
                }
            
        }
    }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE HeSoLuong SET HeSoLuong_GiaTri = @GiaTri WHERE HeSoLuong_Ten = @TenHeSoLuong";

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GiaTri", float.Parse(txtHeSo.Text));
                    command.Parameters.AddWithValue("@TenHeSoLuong", txtTen.Text);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Sửa đổi hệ số lương thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hệ số lương để sửa đổi");
                    }
                }
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
