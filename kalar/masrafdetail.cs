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
    public partial class masrafdetail : MaterialForm
    {
        MySqlConnection con = new MySqlConnection(systm.sql);
      
        systm ob = new systm();
        public masrafdetail()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                String waslm = Admin.waslm;
            String naw = Admin.nawbrekar;
            if ( naw !="")
            {
                label1.Text = naw;
              

                ob.table(data29, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ',DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d')  AS 'بەروار', masrufatwakel.`comment` AS 'تێبینی',state AS 'حاڵەت'  FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid and customer.cname='"+naw+ "' and masrufatwakel.dates between '" + Admin.ds + "' and '" + Admin.dl + "'");
                ob.sum(label275, data29, 1);
               
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
            String naw = Admin.nawbrekar;
            if (naw != "") { 
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
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>وردەکاری مەسروفاتی بریکار</h2>");
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan;'>"+label1.Text+"</h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddDatagridView(data29, "style='width:100%; direction:rtl;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
                easyHTMLReports1.AddString("<p style='border: 1px solid #dddddd;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");            
                easyHTMLReports1.ShowPrintPreviewDialog();
            }
        }

        private void pictureBox106_Click(object sender, EventArgs e)
        {
            ob.toexcel(data29);
        }

        private void data29_KeyDown(object sender, KeyEventArgs e)
        {
            String naw = Admin.nawbrekar;
            if (naw != "")
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
                                 ob.insert_del_up("delete from masrufatwakel where mwid='" + id + "'");
                                ob.table(data29, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ',DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d')  AS 'بەروار', masrufatwakel.`comment` AS 'تێبینی',state AS 'حاڵەت'  FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid and customer.cname='" + naw + "' and masrufatwakel.dates between '" + Admin.ds + "' and '" + Admin.dl + "'");
                                ob.sum(label275, data29, 1);

                            }
                             else
                             {
                                ob.table(data29, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ',DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d')  AS 'بەروار', masrufatwakel.`comment` AS 'تێبینی',state AS 'حاڵەت'  FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid and customer.cname='" + naw + "' and masrufatwakel.dates between '" + Admin.ds + "' and '" + Admin.dl + "'");
                                ob.sum(label275, data29, 1);


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
            try
            {
                if (data29.SelectedRows.Count != 0)
                {
                    int i = data29.SelectedRows[0].Index;
                    int id = Convert.ToInt32(data29.Rows[i].Cells[0].Value.ToString());
                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        String naw = Admin.nawbrekar;
                        if (naw != "")
                        {
                            ob.insert_del_up("UPDATE `masrufatwakel` SET `state`='قبوڵکراو' WHERE mwid='" + id + "'");
                            ob.table(data29, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ',DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d')  AS 'بەروار', masrufatwakel.`comment` AS 'تێبینی',state AS 'حاڵەت'  FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid and customer.cname='" + naw + "' and masrufatwakel.dates between '" + Admin.ds + "' and '" + Admin.dl + "'");
                            ob.sum(label275, data29, 1);

                        }
                    }
                    else
                    {
                        String naw = Admin.nawbrekar;
                        if (naw != "")
                        {

                            ob.table(data29, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ',DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d')  AS 'بەروار', masrufatwakel.`comment` AS 'تێبینی',state AS 'حاڵەت'  FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid and customer.cname='" + naw + "' and masrufatwakel.dates between '" + Admin.ds + "' and '" + Admin.dl + "'");
                            ob.sum(label275, data29, 1);

                        }

                    }
                }
            }

            catch (Exception)
            {


            }
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
    }
}
