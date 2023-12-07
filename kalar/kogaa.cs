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
using Classonlinecompany;

namespace online
{
    public partial class kogaa : MaterialForm
    {
        MySqlConnection con = new MySqlConnection(systm.sql);
      
        systm ob = new systm();
        public kogaa()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        
          
            int a=Admin.a;
            if (a == 0)
            {
              label274.Text = "کۆگای ئامێری بریکار";
            //   ob.table(data29, "SELECT `amern` AS 'ئامێر', `number` AS 'عەدەد' FROM `storage_amer_view_customer` where cusid='" + companyagive.SelectedValue.ToString() + "'");
            //    ob.sum(label275, data29, 1);
           }
            else
            {
              label274.Text = "کۆگای کارتی بریکار";
                label416.Visible = false;
                dateTimePicker53.Visible = false;
                dateTimePicker54.Visible = false;
                label415.Visible = false;
            //  ob.table(data29, "SELECT `kartn` AS 'کارت', `number` AS 'عەدەد' FROM `storage_kart_view_customer` where cusid='" + companyagive.SelectedValue.ToString() + "'");
            //    ob.sum(label275, data29, 1);
          }
         



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
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
            this.Close();
          
        }

        private void pictureBox108_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox107_Click(object sender, EventArgs e)
        {
           
                easyHTMLReports1.Clear();
                easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07736955644-07512330607</p>");

                easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
            int a = Admin.a;
            if (a == 0)
            {
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کۆگای ئامێری بریکار</h2>");
            }
            else
            {
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کۆگای کارتی بریکار</h2>");
            }
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan;'>" + companyagive.Text + "</h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddDatagridView(data29, "style='width:100%; direction:rtl;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
                easyHTMLReports1.ShowPrintPreviewDialog();
            
        }

        private void pictureBox106_Click(object sender, EventArgs e)
        {
            ob.toexcel(data29);
        }

        private void data29_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void data29_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data29);
            ob.sum(label275, data29, 2);
           
        }

        private void data29_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data29);
            ob.sum(label275, data29, 2);
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void data29_DoubleClick(object sender, EventArgs e)
        {
         
        }

        private void data29_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void data29_DoubleClick_1(object sender, EventArgs e)
        {
           
        }

        private void data29_FilterStringChanged_1(object sender, EventArgs e)
        {
            ob.adfilter(data29);
            ob.sum(label275, data29, 1);
        }

        private void data29_SortStringChanged_1(object sender, EventArgs e)
        {
            ob.adsort(data29);
            ob.sum(label275, data29, 1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void data29_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in data29.Rows)
                {
                    // do sonmthind

                    if (Convert.ToInt32(row.Cells[2].Value) <= 10 && Convert.ToInt32(row.Cells[2].Value) > 0 && row.Cells[2].Value != null)
                    {

                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.ForeColor = Color.White;

                    }
                    else if (Convert.ToInt32(row.Cells[2].Value) == 0 && row.Cells[2].Value != null)
                    {

                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void companyagive_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void companyagive_KeyDown(object sender, KeyEventArgs e)
        {
            
              
            
        }

        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {
         
            ob.comb(companyagive, "SELECT * FROM customer where city='"+comboBox1.Text+"'", "cid", "cname");
        }

        private void pictureBox142_Click(object sender, EventArgs e)
        {
            if (companyagive.SelectedValue != null)
            {
                int a = Admin.a;
                if (a == 0)
                {

                    //ob.table(data29, "SELECT `amern` AS 'ئامێر', `number` AS 'عەدەد' FROM `storage_amer_view_customer` where cusid='" + companyagive.SelectedValue.ToString() + "'");
                    //ob.sum(label275, data29, 1);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("call kogass('" + companyagive.SelectedValue.ToString() + "','"+dateTimePicker53.Text+"','"+dateTimePicker54.Text+"')", con); ;
                    MySqlDataAdapter dt = new MySqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    dt.Fill(DS);

                    data29.DataSource = DS.Tables[0];

                    con.Close();

                }
                else
                {
                    ob.table(data29, "SELECT `kartn` AS 'کارت', `number` AS 'عەدەد' FROM `storage_kart_view_customer` where cusid='" + companyagive.SelectedValue.ToString() + "'");
                    ob.sum(label275, data29, 1);
                }
            }
        }
    }
}
