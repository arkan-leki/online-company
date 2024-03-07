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
    public partial class qarzdetail : MaterialForm
    {
        MySqlConnection con = new MySqlConnection(systm.sql);
      
        systm ob = new systm();
        public qarzdetail()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                String qarzc = Admin.qarzc;

                if (qarzc == "قەرزی کڕیار")
            {

                ob.table(data29, "SELECT `ccid` as '#', `name` as 'ناو', format(`qarz`,2) as 'قەرز', format(`wargeraw`,2) as 'پارە دراو',format(qarz-wargeraw,2) as 'ماوە' FROM `qarz_mawa`");
                ob.sum(label275, data29, 2);
                ob.sum(label1, data29, 3);
                ob.sum(label3, data29, 4);
            } if (qarzc == "قەرزی بریکار")
                {
                label322.Visible = true;
                label321.Visible = true;
               dateTimePicker36.Visible = true;
                dateTimePicker37.Visible = true;
                pictureBox121.Visible = true;
                ob.table(data29, "SELECT `ccid` as '#', `name` as 'ناو', format(`qarz`,2) as 'قەرز', format(`wargeraw`,2) as 'پارە دراو',format(`recive`,2) as 'پارە وەرگیراو',format(`send`,2) as 'پارە نێردراو',format((qarz-wargeraw+recive-send),2) as 'ماوە' FROM `qarz_customer`");
                ob.sum(label275, data29, 2);
                ob.sum(label1, data29, 3);
                ob.sum(label3, data29, 4);
            }

                if (qarzc == "قەرزی ئینتەرنێت")
                {

                    ob.table(data29, "SELECT `ccid` as '#', `name` as 'ناو', format(`qarz`,2) as 'قەرز', format(`wargeraw`,2) as 'پارە دراو',format((qarz-wargeraw),2) as 'ماوە' FROM `qarz_isp`");
                    ob.sum(label275, data29, 2);
                ob.sum(label1, data29, 3);
                ob.sum(label3, data29, 4);
            }

                if (qarzc == "فرۆشیاری ئامێر")
                {

                    ob.table(data29, "SELECT `ccid` as '#', `name` as 'ناو', format(`qarz`,2) as 'قەرز', format(`wargeraw`,2) as 'پارە دراو',format((qarz-wargeraw),2) as 'ماوە' FROM `qarz_net`");
                    ob.sum(label275, data29, 2);
                ob.sum(label1, data29, 3);
                ob.sum(label3, data29, 4);
            }
            ob.setsepator(label275);
            ob.setsepator(label1);
            ob.setsepator(label3);
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
            String qarz = Admin.qarzc;

            if (qarz == "قەرزی کڕیار")
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
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>وردەکاری قەرزی کڕیاری باند</h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddDatagridView(data29, "style='width:100%; direction:rtl;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی قەرز</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی پارەی دراو</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label1.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی قەرزی ماوە</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label3.Text + "</p>");
                easyHTMLReports1.ShowPrintPreviewDialog();
            }
            if (qarz == "قەرزی بریکار")
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
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>وردەکاری قەرزی بریکار</h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddDatagridView(data29, "style='width:100%; direction:rtl;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی قەرز</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی پارەی دراو</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label1.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی قەرزی ماوە</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label3.Text + "</p>");
                easyHTMLReports1.ShowPrintPreviewDialog();

            }

            if (qarz == "قەرزی ئینتەرنێت")
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
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>  isp وردەکاری قەرزی</h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddDatagridView(data29, "style='width:100%; direction:rtl;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی قەرز</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی پارەی دراو</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label1.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی قەرزی ماوە</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label3.Text + "</p>");
                easyHTMLReports1.ShowPrintPreviewDialog();
            }

            if (qarz == "فرۆشیاری ئامێر")
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
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>وردەکاری قەرزی فرۆشیاری ئامێر</h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddDatagridView(data29, "style='width:100%; direction:rtl;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی قەرز</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی پارەی دراو</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label1.Text + "</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی قەرزی ماوە</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label3.Text + "</p>");
                easyHTMLReports1.ShowPrintPreviewDialog();
            }
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
            ob.sum(label1, data29, 3);
            ob.sum(label3, data29, 4);
            ob.setsepator(label275);
            ob.setsepator(label1);
            ob.setsepator(label3);
        }

        private void data29_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data29);
            ob.sum(label275, data29, 2);
            ob.sum(label1, data29, 3);
            ob.sum(label3, data29, 4);
        
        ob.setsepator(label275);
            ob.setsepator(label1);
            ob.setsepator(label3);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void data29_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox121_Click(object sender, EventArgs e)
        {
            ob.table(data29, "select `customer`.`cid` AS `#`,`customer`.`cname` AS `ناو`" +
                           ",(      (select coalesce(sum(`sumprice`-mbrekar),0) from `new_system_online`.`froshtn_kart` where (`new_system_online`.`froshtn_kart`.`cid` = `new_system_online`.`customer`.`cid`) and (dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'))" +
                           "-(select coalesce(sum(`new_system_online`.`masrufatwakel`.`amount`),0) from `new_system_online`.`masrufatwakel` where `new_system_online`.`masrufatwakel`.`cid` = `new_system_online`.`customer`.`cid` and `new_system_online`.`masrufatwakel`.`state` = 'قبوڵکراو' and (`new_system_online`.`masrufatwakel`.dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'))) " +
                           "AS `قەرز`," +
                           "(select coalesce(sum(`new_system_online`.`give_customer`.`qarzdinar`),0) from `new_system_online`.`give_customer` where (`new_system_online`.`give_customer`.`cid` = `new_system_online`.`customer`.`cid`) and (dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "')) AS `پارە دراو`, " +
                           "(select coalesce(sum(`new_system_online`.`exchange_balance`.`amount`),0) from `new_system_online`.`exchange_balance` where (`new_system_online`.`exchange_balance`.`cus` = `new_system_online`.`customer`.`cid`) and (barwar between '" + dateTimePicker36.Text +"' and '" + dateTimePicker37.Text + "')) AS `پارە وەرگیراو`," +
                           "(select coalesce(sum(`new_system_online`.`exchange_balance`.`amount`),0) from `new_system_online`.`exchange_balance` where (`new_system_online`.`exchange_balance`.`kid` = `new_system_online`.`customer`.`cid`) and (barwar between '" + dateTimePicker36.Text +"' and '" + dateTimePicker37.Text + "')) AS `پارە نێردراو`," +
                           "(" +
                           "(" +
                           "(select coalesce(sum(`sumprice`-mbrekar),0) from `new_system_online`.`froshtn_kart` where (`new_system_online`.`froshtn_kart`.`cid` = `new_system_online`.`customer`.`cid`) and (dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'))-(select coalesce(sum(`new_system_online`.`masrufatwakel`.`amount`),0) from `new_system_online`.`masrufatwakel` where `new_system_online`.`masrufatwakel`.`cid` = `new_system_online`.`customer`.`cid` and `new_system_online`.`masrufatwakel`.`state` = 'قبوڵکراو' and (dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "')))" +
                           "-(select coalesce(sum(`new_system_online`.`give_customer`.`qarzdinar`),0) from `new_system_online`.`give_customer` where (`new_system_online`.`give_customer`.`cid` = `new_system_online`.`customer`.`cid`) and (dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'))" +
                           "+(select coalesce(sum(`new_system_online`.`exchange_balance`.`amount`),0) from `new_system_online`.`exchange_balance` where (`new_system_online`.`exchange_balance`.`cus` = `new_system_online`.`customer`.`cid`) and (barwar between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'))" +
                           "-(select coalesce(sum(`new_system_online`.`exchange_balance`.`amount`),0) from `new_system_online`.`exchange_balance` where (`new_system_online`.`exchange_balance`.`kid` = `new_system_online`.`customer`.`cid`) and (barwar between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'))" +
                           ") as 'ماوە'" +
                           " from `new_system_online`.`customer`");

            ob.sum(label275, data29, 2);
            ob.sum(label1, data29, 3);
            ob.sum(label3, data29, 4);
        }
    }
}
