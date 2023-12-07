using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Classonlinecompany;
namespace online
{
    public partial class amaramer : Form
    {
        MySqlConnection con = new MySqlConnection(systm.sql);

        systm ob = new systm();
        public amaramer()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox142_Click(object sender, EventArgs e)
        {
            advancedDataGridView2.Rows.Clear();
            ob.table(advancedDataGridView2, "select aname as 'جۆری ئامێر',(select COALESCE(sum(num),0) From amer_hato WHERE amer_hato.aid=amer.aid and amer_hato.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری هاتوو',(select COALESCE(sum(num),0) From amer_roshto WHERE amer_roshto.aid=amer.aid and amer_roshto.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری ڕۆشتوو بۆ بریکار',(select COALESCE(sum(num),0) From amer_froshtn WHERE amer_froshtn.aid=amer.aid and amer_froshtn.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری فرۆشراو',(select COALESCE(sum(num),0) From froshtn_amer WHERE froshtn_amer.aid=amer.aid and froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری فرۆشراوی بریکار',(select COALESCE(sum(number),0) From amer_garawa WHERE amer_garawa.aid=amer.aid and amer_garawa.barwar BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری گەڕاوە',(select COALESCE(sum(number),0) From storage_amer WHERE storage_amer.aid=amer.aid) as 'ئێستای کۆگا' from amer");
            //con.Open();
            //double sm = 0;
            //MySqlCommand mdd = new MySqlCommand("select aname as 'جۆری ئامێر',(select COALESCE(sum(num),0) From amer_hato WHERE amer_hato.aid=amer.aid and amer_hato.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری هاتوو',(select COALESCE(sum(num),0) From amer_roshto WHERE amer_roshto.aid=amer.aid and amer_roshto.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری ڕۆشتوو بۆ بریکار',(select COALESCE(sum(num),0) From amer_froshtn WHERE amer_froshtn.aid=amer.aid and amer_froshtn.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری فرۆشراو',(select COALESCE(sum(num),0) From froshtn_amer WHERE froshtn_amer.aid=amer.aid and froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری فرۆشراوی بریکار',(select COALESCE(sum(number),0) From amer_garawa WHERE amer_garawa.aid=amer.aid and amer_garawa.barwar BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری گەڕاوە',(select COALESCE(sum(number),0) From storage_amer WHERE storage_amer.aid=amer.aid) as 'ئێستای کۆگا' from amer", con);
            //int i = 0;
            //MySqlDataReader rdd = mdd.ExecuteReader();
            //while (rdd.Read())
            //{

            //    if (rdd.GetValue(1).ToString() != "0" || rdd.GetValue(2).ToString() != "0" && rdd.GetValue(3).ToString() != "0" && rdd.GetValue(4).ToString() != "0" && rdd.GetValue(5).ToString() != "0")
            //    {
            //        DataGridViewRow row = new DataGridViewRow();

            //        row.CreateCells(advancedDataGridView2);
            //        row.Cells[0].Value = rdd.GetValue(0).ToString();
            //        row.Cells[1].Value = rdd.GetValue(1).ToString();
            //        row.Cells[2].Value = rdd.GetValue(2).ToString();
            //        row.Cells[3].Value = rdd.GetValue(3).ToString();
            //        row.Cells[4].Value = rdd.GetValue(4).ToString();
            //        row.Cells[5].Value = rdd.GetValue(5).ToString();
            //        row.Cells[6].Value = rdd.GetValue(6).ToString();
            //        advancedDataGridView2.Rows.Add(row);

            //    }
            //    i++;
            //}

            //con.Close();

            ob.sum(label412, advancedDataGridView2, 1);
            ob.sum(label410, advancedDataGridView2, 2);
            ob.sum(label408, advancedDataGridView2, 3);
            ob.sum(label402, advancedDataGridView2, 4);
            ob.sum(label406, advancedDataGridView2, 5);
            ob.sum(label393, advancedDataGridView2, 6);
        }

        private void pictureBox143_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07713297399-07512330607</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئاماری ئامێرەکان</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView2, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>" + label413.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label412.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>" + label411.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label410.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>" + label409.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label408.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>" + label405.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label402.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>" + label407.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label406.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>" + label394.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label393.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void advancedDataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView2);
            ob.sum(label412, advancedDataGridView2, 1);
            ob.sum(label410, advancedDataGridView2, 2);
            ob.sum(label408, advancedDataGridView2, 3);
            ob.sum(label402, advancedDataGridView2, 4);
            ob.sum(label406, advancedDataGridView2, 5);
            ob.sum(label393, advancedDataGridView2, 6);
        }

        private void advancedDataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView2);
            ob.sum(label412, advancedDataGridView2, 1);
            ob.sum(label410, advancedDataGridView2, 2);
            ob.sum(label408, advancedDataGridView2, 3);
            ob.sum(label402, advancedDataGridView2, 4);
            ob.sum(label406, advancedDataGridView2, 5);
            ob.sum(label393, advancedDataGridView2, 6);
        }
    }
}
