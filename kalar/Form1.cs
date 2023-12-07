using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;
using System.Globalization;
using Classonlinecompany;
namespace online
{
    public partial class Form1 : MaterialForm
    {
        MySqlConnection con = new MySqlConnection(Classonlinecompany.systm.sql);
        public static String idu = "";
        public static String ty="";
        public static String us = "";
        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //PopupNotifier popup = new PopupNotifier();//ئۆبجێكتێك درووستده‌كه‌ین 
            //popup.Image = Properties.Resources.icon;//PNG وێنه‌یه‌كی بچووك به‌ فۆرماتی  
            //popup.TitleText = "";//نووسینی سه‌ره‌وه‌ تایتل
            //popup.ContentText = "Ibrahim Sherwani !";//نوسینی ناوه‌رۆك
            //popup.TitleColor = Color.Red;//گۆرینی ره‌نگی  تایتل
            //popup.Popup();
            CultureInfo en = new CultureInfo("en-us");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(en);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
           
            MySqlCommand md = new MySqlCommand("Select * FROM loginn WHERE username='" + textBox1.Text + "' AND password='" +textBox2.Text + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    us = textBox1.Text;
                    ty = rd.GetString("types");
                        draw ob = new draw();
                        this.Hide();
                        ob.Show();
                  
                }
            }
            else
            {
                MessageBox.Show("Password Wrong....");
                //textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con.Open();

                MySqlCommand md = new MySqlCommand("Select * FROM loginn WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        us = textBox1.Text;
                        ty = rd.GetString("types");
                        draw ob = new draw();
                        this.Hide();
                        ob.Show();

                    }
                }
                else
                {
                    MessageBox.Show("Password Wrong....");
                }
                con.Close();
            }
        }
    }
}
