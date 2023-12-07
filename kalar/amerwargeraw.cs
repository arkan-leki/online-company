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
namespace online
{
    public partial class amerwargeraw : Form
    {
        systm ob = new systm();
        public amerwargeraw()
        {
            InitializeComponent();
            if (Form1.ty != "ئەدمین")
            {


                pictureBox64.Enabled = false;
                
            }

            ob.table(data29, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%d/%m/%Y') as 'بەروار',cname as 'بریکار' FROM `dawakary_amer_view` where state='قبوڵکراو'");
            ob.sum(label275, data29, 2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox121_Click(object sender, EventArgs e)
        {
         
            ob.table(data29, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%d/%m/%Y') as 'بەروار',cname as 'بریکار' FROM `dawakary_amer_view` where state='قبوڵکراو' and barwar between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
            ob.sum(label275, data29, 2);
        }

        private void data29_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data29);
            ob.sum(label275, data29, 2);
        }

        private void data29_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data29);
            ob.sum(label275, data29, 2);
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
                            ob.insert_del_up("delete from dawakary_amer_view where id='" + id + "'");
                            ob.table(data29, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%d/%m/%Y') as 'بەروار',cname as 'بریکار' FROM `dawakary_amer_view` where state='قبوڵکراو' and barwar between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                            ob.sum(label275, data29, 2);

                        }
                        else
                        {
                            ob.table(data29, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%d/%m/%Y') as 'بەروار',cname as 'بریکار' FROM `dawakary_amer_view` where state='قبوڵکراو' and barwar between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                            ob.sum(label275, data29, 2);

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
                        ob.insert_del_up("update dawakary_amer_view set adad='" + numkart.Text+ "',barwar='" + dateTimePicker63.Text+"' where id='" + id + "'");
                    ob.table(data29, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%d/%m/%Y') as 'بەروار',cname as 'بریکار' FROM `dawakary_amer_view` where state='قبوڵکراو' and barwar between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                    ob.sum(label275, data29, 2);

                }
                    else
                    {
                    ob.table(data29, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%d/%m/%Y') as 'بەروار',cname as 'بریکار' FROM `dawakary_amer_view` where state='قبوڵکراو' and barwar between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
                    ob.sum(label275, data29, 2);

                }
                }
            //}
            //catch (Exception)
            //{


            //}
        }
    }
}
