using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
using System.Drawing.Printing;
using Microsoft.VisualBasic;
using Classonlinecompany;
namespace online
{
    public partial class kogam : Form
    {
  
        MySqlConnection con = new MySqlConnection(systm.sql);
        systm ob = new systm();
        public kogam()
        {
            InitializeComponent();
            ob.getsum(label3, "select Coalesce(br,0) as 'result' from storagem");
        
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("update storagem set br='"+metroTextBox1.Text+"' where id=1");
            ob.getsum(label3, "select Coalesce(br,0) as 'result' from storagem");
            metroTextBox1.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

         
        }

        private void draw_Load(object sender, EventArgs e)
        {
            //notifyIcon2.ShowBalloonTip(100, Form1.us, "بەخێربێی بۆ سیستەمی کۆمپانیای ئۆنلاین ", ToolTipIcon.Info);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
