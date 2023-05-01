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
    public partial class TrangChuHRM : Form
    {
        private Form FormMo;
        public TrangChuHRM()
        {
            InitializeComponent();
        }
        private void AnMenu() //khởi tạo ẩn ban đầu
        {
            panelUp.Visible = false;
            panelRe.Visible = false;
            panelSYS.Visible = false;
            panelHT.Visible = false;
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
            if (panelUp.Visible == true)
            {
                panelUp.Visible = false;
            }
            if (panelRe.Visible == true)
            {
                panelRe.Visible = false;
            }
            if (panelSYS.Visible == true)
            {
                panelSYS.Visible = false;
            }
            if(panelHT.Visible == true)
            {
                panelHT.Visible = false;
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

        private void btUp_Click(object sender, EventArgs e)
        {
            HienMenu(panelUp);
        }

        private void btRE_Click(object sender, EventArgs e)
        {
            HienMenu(panelRe);
        }

        private void btHT_Click(object sender, EventArgs e)
        {
            HienMenu(panelSYS);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            HienMenu(panelHT);
        }

        private void btDX_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to return login ?", "Notification", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                //LoginFrom lg = new LoginFrom();
                //lg.Show();
                this.Close();
            }

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

    

        private void btTT_Click(object sender, EventArgs e)
        {
            MoFormCon(new KyCongHRM(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoFormCon(new ChiTietHRM(), sender);
        }

        private void buttonbangluong_Click(object sender, EventArgs e)
        {
            MoFormCon(new BangLuong(), sender);

        }

        private void buttonungluong_Click(object sender, EventArgs e)
        {
            MoFormCon(new UngLuong(), sender);

        }

        private void buttontangca_Click(object sender, EventArgs e)
        {
            MoFormCon(new TangCa(), sender);

        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmNhanVien(), sender);
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmHopDong(), sender);
        }

        private void btnHSLuong_Click(object sender, EventArgs e)
        {
            MoFormCon(new frmHeSoLuong(), sender);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Location.X + 1, label1.Location.Y);
            if (label1.Location.X > splitContainer3.Panel1.Size.Width)
            {
                label1.Location = new Point(-100, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
