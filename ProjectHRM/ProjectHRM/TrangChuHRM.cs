using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHRM
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

        private void btDX_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to return login ?", "Notification", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                //LoginFrom lg = new LoginFrom();
                //lg.Show();
                this.Hide();
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
            MoFormCon(new ChitietHRM(), sender);
        }

        private void buttonbangluong_Click(object sender, EventArgs e)
        {
            BangLuong bl = new BangLuong();
            bl.Show();
        }

        private void buttonungluong_Click(object sender, EventArgs e)
        {
            UngLuong ul = new UngLuong();
            ul.Show();  
        }

        private void buttontangca_Click(object sender, EventArgs e)
        {
            TangCa tc = new TangCa();
            tc.Show();
        }
    }
}
