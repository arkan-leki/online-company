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
    public partial class detail : MaterialForm
    {
        MySqlConnection con = new MySqlConnection(systm.sql);
      
        systm ob = new systm();
        public detail()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                String waslka = Admin.waslka;
          String wasla = Admin.wasla;
       
            if (waslka != "")
            {

                label274.Text = "وردەکاری کارتی فرۆشراو";
                ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', balance.types AS 'جۆری کارت',customer.cname as 'بریکار',(select COALESCE(sum(number),0)  from storage_kart_view_customer where storage_kart_view_customer.bid=froshtn_kart.bid and storage_kart_view_customer.cusid=froshtn_kart.cid) as 'کارتی ماوە',tebene AS 'تێبینی' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and customer.cid=froshtn_kart.cid and  customer.cname='" + waslka + "' and DATE_FORMAT(`dates`, '%Y/%m/%d') between '"+Admin.ds+"' and '"+ Admin.dl +"'");
                ob.sum(label275, data29, 2);
                ob.sum(label277, data29, 4);
            }
            if (wasla != "")
            {

                label274.Text = "وردەکاری ئامێری فرۆشراو";
             ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',customer.cname as 'بریکار',(select COALESCE(sum(number),0)  from storage_amer_view_customer where storage_amer_view_customer.aid=froshtn_amer.aid and storage_amer_view_customer.cusid=froshtn_amer.cid) as 'ئامێری ماوە',tebene AS 'تێبینی' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and customer.cname='" + wasla + "' and DATE_FORMAT(`dates`, '%Y/%m/%d') between '" + Admin.ds + "' and '" + Admin.dl + "'");
                ob.sum(label275, data29, 2);
                ob.sum(label277, data29, 4);
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
             String waslka = Admin.waslka;
             String wasla = Admin.wasla;
             if (waslka != "")
             {
                 if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     try
                     {
                         if (data29.SelectedRows.Count != 0)
                         {


                             int i = data29.SelectedRows[0].Index;
                             String id = data29.Rows[i].Cells[0].Value.ToString();
                             String adad = data29.Rows[i].Cells[1].Value.ToString();
                             ob.insert_del_up("UPDATE `froshtn_kart` SET `price`='" + nn.Text + "',`sumprice`=num*price WHERE `brid`='" + id + "'");
                             ob.a(this.Controls);
                             ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی' FROM `froshtn_kart`,balance WHERE froshtn_kart.bid=balance.bid and  wasl='" + waslka + "'");
                             ob.sum(label275, data29, 2);
                             ob.sum(label277, data29, 4);
                             messageboxsuc obb = new messageboxsuc();
                             obb.Show();
                         }
                     }
                     catch (Exception)
                     {


                     }

                 }
             }
             if (wasla != "")
             {

                 if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     try
                     {
                         if (data29.SelectedRows.Count != 0)
                         {
                             int i = data29.SelectedRows[0].Index;
                             String id = data29.Rows[i].Cells[0].Value.ToString();
                             String adad = data29.Rows[i].Cells[2].Value.ToString();
                             ob.insert_del_up("UPDATE `froshtn_amer` SET `price`='" + nn.Text + "',`sumprice`=num*price WHERE `brid`='" + id + "'");
                             ob.a(this.Controls);
                             ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',customer.cname as 'بریکار',tebene AS 'تێبینی' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and wasl='" + wasla + "'");
                             ob.sum(label275, data29, 2);
                             ob.sum(label277, data29, 4);
                             messageboxsuc obb = new messageboxsuc();
                             obb.Show();
                         }
                     }
                     catch (Exception)
                     {


                     }

                 }


             }
        }

        private void pictureBox107_Click(object sender, EventArgs e)
        {
            String waslka = Admin.waslka;
            String wasla = Admin.wasla;
            if (waslka != "")
            {
                easyHTMLReports1.Clear();
                easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07736955644-07512330607<br>User:"+Form1.us+"</p>");

                easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                con.Open();
                MySqlCommand mdc = new MySqlCommand("SELECT customer.cname as c FROM `froshtn_kart`,customer WHERE customer.cid=froshtn_kart.cid and  wasl='" + waslka + "' limit 1",con);
                MySqlDataReader rdc = mdc.ExecuteReader();
                while(rdc.Read()){
                    easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>"+rdc.GetString("c")+"</h2>");

                    
                }
                con.Close();
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");


                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%; direction=rtl'>");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>#</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>وەسڵ</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>عەدەد</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>نرخ</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>کۆی نرخ</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: right;padding: 8px;' >بەروار</th>");
                easyHTMLReports1.AddString("<th  style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>جۆری کارت</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: right;padding: 8px;' >کارتی ماوە</th>");
                easyHTMLReports1.AddString("<th  style='border: 1px solid #dddddd;text-align: right;padding: 8px;'>تێبینی</th>");
                easyHTMLReports1.AddString("</tr>");

                con.Open();

                int cou = 1;
                MySqlCommand mdd = new MySqlCommand("SELECT wasl,`num`, `price`, `sumprice` , DATE_FORMAT(`dates`, '%Y/%m/%d') as dates , balance.types as ty,(select COALESCE(sum(number),0)  from storage_kart_customer where storage_kart_customer.kid=froshtn_kart.bid and storage_kart_customer.cus=froshtn_kart.cid) as 'mawa',tebene FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid and customer.cname='" + waslka + "' and DATE_FORMAT(`dates`, '%Y/%m/%d') between '" + Admin.ds + "' and '" + Admin.dl + "'", con);
                MySqlDataReader rdd = mdd.ExecuteReader();
                if (rdd.HasRows)
                {
                    while (rdd.Read())
                    {
                        easyHTMLReports1.AddString("<tr  style='border: 1px solid #dddddd; text-align: left;padding: 8px;'>");
                        string str = rdd.GetString("dates");
                        easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + cou + "</td>");
                        easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("wasl") + "</td>");
                        easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("num") + "</td>");
                        easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("price") + "</td>");
                        easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("sumprice") + "</td>");
                        easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;' >" + rdd.GetString("dates") + "</td>");
                        easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("ty") + "</td>");
                        easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("mawa") + "</td>");
                        easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("tebene") + "</td>");
                        easyHTMLReports1.AddString("</tr>");
                        cou++;

                    }
                }
                con.Close();
                easyHTMLReports1.AddString("</table>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label277.Text + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Dear Client <br>Please Proceed with the payment within 4 days<br>Online Company accept cash payment delivered to the Kalar Bazar-Sulaymaniyah,IRAQ or<br>Bank transfer to IQ account with the following details</p>");
                easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Bank Name:Trade Bank of republic of Iraq <br>Account Name:Online Co.<br>Account Number IQD:0023-008889-001<br>Account Number USD:0023-008889-002</p>");
                easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>if you have any question concering this invoice please contact <br>Ayub Rashid Abdulqader<br>009647736955644-009647711551194<br>acc@onlineco.net-gharib@onlineco.net<br>PS:Transfer fees should not effect on the invoice amount</p>");
                easyHTMLReports1.ShowPrintPreviewDialog();
            }
            if (wasla != "")
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
                easyHTMLReports1.AddString("<h2>" + data29.Rows[0].Cells[7].Value.ToString() + "</h2>");
                con.Open();
                MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cname='" + data29.Rows[0].Cells[7].Value.ToString() + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                while (rd.Read())
                {
                    easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

                }

                con.Close();
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێری فرۆشراوی بریکار</h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + data29.Rows[0].Cells[1].Value.ToString() + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br> Salesperson  " + Form1.us + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%; dir:ltr;'>");

                easyHTMLReports1.AddString("<tr  style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>تێبینی</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>ماوە</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>بەروار</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>کۆی نرخ</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>نرخ</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>عەدەد</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;' >ئامێر</th>");
                easyHTMLReports1.AddString("<th  style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>#</th>");





                easyHTMLReports1.AddString("</tr>");

                for (int i = 0; i < data29.Rows.Count - 1; i++)
                {

                    easyHTMLReports1.AddString("<tr  style='border: 1px solid #dddddd; text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + data29.Rows[i].Cells[9].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + data29.Rows[i].Cells[8].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + data29.Rows[i].Cells[5].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >" + data29.Rows[i].Cells[4].Value.ToString() + "</td>");

                    easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + data29.Rows[i].Cells[3].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + data29.Rows[i].Cells[2].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + data29.Rows[i].Cells[6].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid #dddddd;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + (i + 1) + "</td>");

                    easyHTMLReports1.AddString("</tr>");

                }
                easyHTMLReports1.AddString("</table>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label277.Text + "</p>");
                easyHTMLReports1.ShowPrintPreviewDialog();
            }
        }

        private void pictureBox106_Click(object sender, EventArgs e)
        {
            ob.toexcel(data29);
        }

        private void data29_KeyDown(object sender, KeyEventArgs e)
        {
             String waslka = Admin.waslka;
             String wasla = Admin.wasla;
             if (waslka != "")
             {
                 if (e.KeyCode == Keys.Delete)
                 {
                     try
                     {
                         if (data29.SelectedRows.Count != 0)
                         {
                             int i = data29.SelectedRows[0].Index;
                             int id = Convert.ToInt32(data29.Rows[i].Cells[0].Value.ToString());

                             if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                             {
                                 ob.insert_del_up("delete from froshtn_kart where brid='" + id + "'");
                                 ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی' FROM `froshtn_kart`,balance WHERE froshtn_kart.bid=balance.bid and  wasl='" + waslka + "'");
                                 ob.sum(label275, data29, 2);
                                 ob.sum(label277, data29, 4);


                             }
                             else
                             {
                                 ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی' FROM `froshtn_kart`,balance WHERE froshtn_kart.bid=balance.bid and  wasl='" + waslka + "'");
                                 ob.sum(label275, data29, 2);
                                 ob.sum(label277, data29, 4);

                             }
                         }
                     }
                     catch (Exception)
                     {


                     }
                 }
             }
             if (waslka != "")
             {
                 if (e.KeyCode == Keys.Delete)
                 {
                     try
                     {
                         if (data29.SelectedRows.Count != 0)
                         {
                             int i = data29.SelectedRows[0].Index;
                             int id = Convert.ToInt32(data29.Rows[i].Cells[0].Value.ToString());

                             if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                             {
                                 ob.insert_del_up("delete from froshtn_amer where brid='" + id + "'");
                                 ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',customer.cname as 'بریکار',tebene AS 'تێبینی' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and wasl='" + wasla + "'");
                                 ob.sum(label275, data29, 2);
                                 ob.sum(label277, data29, 4);


                             }
                             else
                             {
                                 ob.table(data29, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',customer.cname as 'بریکار',tebene AS 'تێبینی' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and wasl='" + wasla + "'");
                                 ob.sum(label275, data29, 2);
                                 ob.sum(label277, data29, 4);

                             }
                         }
                     }
                     catch (Exception)
                     {


                     }
                 }
             }
        }

        private void data29_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data29);
            ob.sum(label275, data29, 2);
            ob.sum(label277, data29, 4);
        }

        private void data29_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data29);
            ob.sum(label275, data29, 2);
            ob.sum(label277, data29, 4);
        }
    }
}
