using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classonlinecompany;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel.Controls;
using MySql.Data.MySqlClient;
using NPOI.SS.Formula.Functions;

namespace online
{
    public partial class kartwargeraw : Form
    {
        MySqlConnection con = new MySqlConnection(systm.sql);
        systm ob = new systm();
        public kartwargeraw()
        {
            InitializeComponent();
            if (Form1.ty != "ئەدمین")
            {


                pictureBox64.Enabled = false;
                
            }
           
            ob.table(data29, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', `bid` AS 'کارت',cid as 'بریکار' FROM `balance_roshtu_view`");
            ob.sum(label275, data29, 1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox121_Click(object sender, EventArgs e)
        {
            ob.table(data29, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', `bid` AS 'کارت',cid as 'بریکار' FROM `balance_roshtu_view` where dates between '"+dateTimePicker36.Text+"' and '"+dateTimePicker37.Text+"'");
            ob.sum(label275, data29, 1);
        }

        private void data29_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data29);
            ob.sum(label275, data29, 1);
        }

        private void data29_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data29);
            ob.sum(label275, data29, 1);
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
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارتی وەرگیراوی بریکار</h2>");
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

                            con.Open();
                            MySqlCommand mss = new MySqlCommand("SELECT * FROM `balance_roshto` WHERE `brid`='" + id + "'", con);
                            MySqlDataReader rd = mss.ExecuteReader();
                            String num = "";
                            String bid = "";
                            String cid = "";
                            String wasl = "";
                            String dates = "";
                            if (rd.Read())
                            {
                                num = rd.GetString("num");
                                bid = rd.GetString("bid");
                                cid = rd.GetString("cid");
                                wasl = rd.GetString("wasl");
                                dates = rd.GetString("dates");

                            }
                            con.Close();

                            DateTime myDateTime = DateTime.Parse(dates);
                            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");

                            //ob.insert_del_up("delete from balance_roshtu_view where brid='" + id + "'");
                            ob.insert_del_up("delete from balance_roshto where brid='" + id + "'");
                            ob.insert_del_up("call insert_storage_kart('" + bid + "','" + num + "','" + sqlFormattedDate + "')");
                            ob.insert_del_up("call delete_storage_kart_customer('" + bid + "','" + num + "','" + cid + "')");
                            ob.insert_del_up("delete from dawakary_balance where id='" + id + "'");
                            ob.table(data29, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', `bid` AS 'کارت',cid as 'بریکار' FROM `balance_roshtu_view` where dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                            ob.sum(label275, data29, 1);

                        }
                        else
                        {
                            ob.table(data29, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', `bid` AS 'کارت',cid as 'بریکار' FROM `balance_roshtu_view` where dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                            ob.sum(label275, data29, 1);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (data29.SelectedRows.Count != 0)
                {
                    int i = data29.SelectedRows[0].Index;
                    int id = Convert.ToInt32(data29.Rows[i].Cells[0].Value.ToString());
                  
                    if (MessageBox.Show("دڵنیای لە گۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ob.insert_del_up("update balance_roshto set num='"+numkart.Text+ "',dates='" + dateTimePicker63.Text+"' where brid='" + id + "'");
                        ob.table(data29, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', `bid` AS 'کارت',cid as 'بریکار' FROM `balance_roshtu_view` where dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                        ob.sum(label275, data29, 1);

                    }
                    else
                    {
                        ob.table(data29, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', `bid` AS 'کارت',cid as 'بریکار' FROM `balance_roshtu_view` where dates between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                        ob.sum(label275, data29, 1);

                    }
                }
            //}
            //catch (Exception)
            //{


            //}
        }
    }
}
