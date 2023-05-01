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
    public partial class frmHopDong : Form
    {
        public frmHopDong()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO HopDong(HopDong_NgayBatDau, HopDong_NgayKetThuc, HopDong_LanKy, HopDong_NoiDung, HopDong_LuongCanBan, HopDong_HeSoLuong, HopDong_NhanVien) " 
                +
                           "VALUES (@NgayBatDau, @NgayKetThuc, @LanKy, @NoiDung, @LuongCanBan, @HeSoLuong, @NhanVien)";

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value);
                    command.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value);
                    command.Parameters.AddWithValue("@LanKy", int.Parse(txtLanKy.Text));
                    command.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                    command.Parameters.AddWithValue("@LuongCanBan", float.Parse(txtLuongCanBan.Text));
                    command.Parameters.AddWithValue("@HeSoLuong", int.Parse(txtHeSoLuong.Text));
                    command.Parameters.AddWithValue("@NhanVien", int.Parse(txtMaNV.Text));

                    try
                    {
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm hợp đồng thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm hợp đồng không thành công");
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Lỗi trùng khóa
                        {
                            MessageBox.Show("Nhân viên đã ký hợp đồng trong thời gian này");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi thêm hợp đồng: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM HopDong WHERE HopDong_SoHD = @SoHD";

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SoHD", int.Parse(txtSoHD.Text));

                    try
                    {
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xoá hợp đồng thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hợp đồng để xoá");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi xoá hợp đồng: " + ex.Message);
                    }
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string query = "UPDATE HopDong SET HopDong_NgayBatDau = @NgayBatDau, HopDong_NgayKetThuc = @NgayKetThuc, HopDong_LanKy = @LanKy," +
                " HopDong_NoiDung = @NoiDung, HopDong_LuongCanBan = @LuongCanBan, HopDong_HeSoLuong = @HeSoLuong, HopDong_NhanVien = @NhanVien WHERE HopDong_SoHD = @SoHD";

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SoHD", int.Parse(txtSoHD.Text));
                    command.Parameters.AddWithValue("@NgayBatDau", dtpNgayBatDau.Value);
                    command.Parameters.AddWithValue("@NgayKetThuc", dtpNgayKetThuc.Value);
                    command.Parameters.AddWithValue("@LanKy", int.Parse(txtLanKy.Text));
                    command.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                    command.Parameters.AddWithValue("@LuongCanBan", float.Parse(txtLuongCanBan.Text));
                    command.Parameters.AddWithValue("@HeSoLuong", int.Parse(txtHeSoLuong.Text));
                    command.Parameters.AddWithValue("@NhanVien", int.Parse(txtMaNV.Text));

                    try
                    {
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cập nhật hợp đồng thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hợp đồng để cập nhật");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật hợp đồng: " + ex.Message);
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
