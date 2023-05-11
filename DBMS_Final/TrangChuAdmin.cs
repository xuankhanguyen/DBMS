using Cuoiki.Forms;
using ProjectHRM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuoiki
{
    public partial class TrangChuAdmin : Form
    {
        public TrangChuAdmin()
        {
            InitializeComponent();
        }
        private Form FormMo;
        private void AnMenu() //khởi tạo ẩn ban đầu
        {

            panelHT.Visible = false;
            panel1.Visible = false;
        }
        private void TrangChuHRM_Load(object sender, EventArgs e)
        {

            btclose.Visible = false;
            AnMenu();
        }
        private void Resetall()
        {
            labelTile.Text = "HOME";
            btclose.Visible = false;
            AnMenu();
        }
        private void btclose_Click(object sender, EventArgs e)
        {
            if (FormMo != null)
            {
                FormMo.Close();
            }
            Resetall();
        }
        private void DongMenu() // Ẩn menu
        {

            if (panelHT.Visible == true)
            {
                panelHT.Visible = false;
            }
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
        }
        private void HienMenu(Panel dongmenu) //Hiện menu
        {
            if (dongmenu.Visible == false)
            {
                DongMenu();
                dongmenu.Visible = true;
            }
            else
                dongmenu.Visible = false;
        }


        private void btHT_Click(object sender, EventArgs e)
        {
            HienMenu(panelHT);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            HienMenu(panel1);
        }

        private void MoFormCon(Form formcon, object btsender)
        {
            if (FormMo != null)
            {
                FormMo.Close();
            }
            FormMo = formcon;
            formcon.TopLevel = false;
            formcon.FormBorderStyle = FormBorderStyle.None;
            formcon.Dock = DockStyle.Fill;
            this.splitContainer2.Panel2.Controls.Add(formcon);
            formcon.Show();
            labelTile.Text = formcon.Text;
            btclose.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X + 1, label1.Location.Y);
            if (label1.Location.X > splitContainer3.Panel1.Size.Width)
            {
                label1.Location = new Point(-100, 0);
            }
        }
        private void BtDX_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Bạn có muốn đăng xuất và trở về trang đăng nhập?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                FormDangNhap dangNhap = new FormDangNhap();
                dangNhap.Show();
                this.Hide();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MoFormCon(new FormTaiKhoan(), sender);
        }

        private void TrangChuHRM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
