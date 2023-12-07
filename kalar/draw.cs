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
namespace online
{
    public partial class draw : Form
    {
       public static double dolar;
        public draw()
        {
            InitializeComponent();
            notifyIcon1.ShowBalloonTip(10, Form1.us, "بەخێربێی بۆ سیستەمی کۆمپانیای ئۆنلاین ", ToolTipIcon.Info);


        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            dolar = Convert.ToDouble(metroTextBox1.Text) / 100;
            Admin ob = new Admin();
            this.Hide();
            ob.Show();
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

            easyHTMLReports1.Clear();
            int i = 0;
            for ( i = 0; i < 40 - 1; i += 10)
            {
                easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                easyHTMLReports1.AddString("<h2  style='color:cyan; '>لیستی موچە</h2>");
                easyHTMLReports1.AddString("<p  style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");
                easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                easyHTMLReports1.AddLineBreak();

                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif; direction:rtl;font-size:14px; border-collapse: collapse;width: 100%;'>");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>#</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;' >ناوی کارمەند</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>پلە</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>موچەی بنەڕەتی</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>ئەمانەت</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>پاداشت</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>سزا</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>کاتژمێری زیادە</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>قەرز دانەوە</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>موچەی کۆتای</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;width:100px;'>ئیمزا</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>تێبینی</th>");
                easyHTMLReports1.AddString("</tr>");
                
                for (int j = i; j < i+10 ; j++)
                {

                    easyHTMLReports1.AddString("<tr  style='border: 1px solid #dddddd; text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>1</td>");

                    easyHTMLReports1.AddString("</tr>");


                }
                easyHTMLReports1.AddString("</table>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>500$</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif; direction:rtl;font-size:14px;width: 100%;'>");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid white;text-align: center;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid white;text-align: center;padding: 8px;'>ژمێریاری</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid white;text-align: center;padding: 8px;' >ووردبین</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid white;text-align: center;padding: 8px;'>بەڕێوبەر</td>");
                easyHTMLReports1.AddString("</tr>");
                easyHTMLReports1.AddString("</table>");
                easyHTMLReports1.NewPage();
            
               
            }
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void draw_Load(object sender, EventArgs e)
        {
            //notifyIcon2.ShowBalloonTip(100, Form1.us, "بەخێربێی بۆ سیستەمی کۆمپانیای ئۆنلاین ", ToolTipIcon.Info);

        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dolar = Convert.ToDouble(metroTextBox1.Text) / 100;
                Admin ob = new Admin();
                this.Hide();
                ob.Show();
            }
        }
    }
}
