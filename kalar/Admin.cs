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
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using static NPOI.HSSF.Util.HSSFColor;
using static Google.Protobuf.WellKnownTypes.Field.Types;
using MySqlX.XDevAPI.Relational;

namespace online
{
    public partial class Admin : Form
    {
        double dolar = online.draw.dolar;
        public static String waslka = "";
        public static String wasla = "";
        public static String waslm = "";
        public static String nawbrekar = "";
        public static String qarzc = "";
        public static String waslda = "";
        public static String wasldk = "";
        public static String ds = "";
        public static String dl = "";
        MySqlConnection con = new MySqlConnection(systm.sql);
        systm ob = new systm();
        public Admin()
        {
            InitializeComponent();

            String amerd = "";
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT `cname` FROM `dawakary_amer_view` WHERE `state`='قبوڵنەکراو' group by cname", con);
            MySqlDataReader rd = md.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    amerd = amerd + " , " + rd.GetString("cname");

                }
                notifyIcon2.ShowBalloonTip(10, Form1.us, "تکایە ئەم بریکارانە داوای ئامێریان کردووە قبوڵی بکەن \n  " + amerd, ToolTipIcon.Warning);

            }
            con.Close();
            String balanced = "";
            con.Open();
            MySqlCommand mdd = new MySqlCommand("SELECT `cname` FROM `dawakary_balance_view` WHERE `state`='قبوڵنەکراو' group by cname", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            if (rdd.HasRows)
            {
                while (rdd.Read())
                {

                    balanced = balanced + " , " + rdd.GetString("cname");

                }
                notifyIcon3.ShowBalloonTip(10, Form1.us, "تکایە ئەم بریکارانە داوای کارتیان کردووە قبوڵی بکەن \n  " + balanced, ToolTipIcon.Warning);

            }
            con.Close();
            if (Form1.ty != "ئەدمین")
            {


                fileToolStripMenuItem.Enabled = false;
                toolStripMenuItem3.Enabled = false;
                qToolStripMenuItem.Enabled = false;
                toolStripMenuItem8.Enabled = false;
                pictureBox163.Enabled = false;
                materialTabControl1.SelectedIndex = 4;

                ob.table(datagridview5, "call select_balance();");
                ob.count(label35, datagridview5, 0);
            }
            else
            {
                ob.table(dataGridView1, "call select_login()");
                ob.count(label50, dataGridView1, 0);
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 1;
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_login('" + names.Text + "','" + pass.Text + "','" + types.Text + "')");
            messageboxsuc os = new messageboxsuc();
            os.Show();
            ob.table(dataGridView1, "call select_login()");
            ob.count(label50, dataGridView1, 0);
            names.Clear();
            pass.Clear();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            names.Text = "";
            pass.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

            Form1 ob = new Form1();
            this.Hide();
            ob.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    names.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    pass.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

                }
            }
            catch (Exception)
            {


            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dataGridView1.SelectedRows.Count != 0)
                    {
                        int i = dataGridView1.SelectedRows[0].Index;
                        int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from loginn where id='" + id + "'");
                            ob.table(dataGridView1, "SELECT `id` AS '#', `username` AS 'ناوی بەکارهێنەر', `password` AS 'ووشەی نهێنی' FROM `loginn`");
                            ob.count(label50, dataGridView1, 0);

                        }
                        else
                        {
                            ob.table(dataGridView1, "SELECT `id` AS '#', `username` AS 'ناوی بەکارهێنەر', `password` AS 'ووشەی نهێنی' FROM `loginn`");
                            ob.count(label50, dataGridView1, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }




        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                ob.insert_del_up("call insert_customer('" + naw.Text + "','" + zh.Text + "','" + metroComboBox1.Text + "','" + ad.Text + "','" + jorebrekar.Text + "','" + username.Text + "','" + password.Text + "','" + comboBox6.Text + "','" + comboBox6.SelectedValue.ToString() + "')");
            }
            else
            {
                ob.insert_del_up("INSERT INTO `customer`(`cname`, `phone`,city, `location`, `types`, `username`, `password`) VALUES ('" + naw.Text + "','" + zh.Text + "','" + metroComboBox1.Text + "','" + ad.Text + "','" + jorebrekar.Text + "','" + username.Text + "','" + password.Text + "')");
            }
            messageboxsuc os = new messageboxsuc();
            os.Show();
            ob.table(dataGridView4, "call select_customer();");
            ob.count(label57, dataGridView4, 0);



        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            naw.Clear();
            zh.Clear();
            ad.Clear();
        }
        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    String id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    ob.insert_del_up("call update_login('" + names.Text + "','" + pass.Text + "','" + types.Text + "','" + id + "')");
                    messageboxsuc ms = new messageboxsuc();
                    ms.Show();
                    ob.table(dataGridView1, "call select_login()");
                    ob.count(label50, dataGridView1, 0);

                }

            }
            catch (Exception)
            {


            }
        }



        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.SelectedRows.Count != 0)
                {
                    int i = dataGridView4.SelectedRows[0].Index;
                    naw.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
                    zh.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
                    ad.Text = dataGridView4.Rows[i].Cells[3].Value.ToString();

                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.SelectedRows.Count != 0)
                {
                    int i = dataGridView4.SelectedRows[0].Index;
                    String id = dataGridView4.Rows[i].Cells[0].Value.ToString();
                    if (checkBox4.Checked == false)
                    {
                        ob.insert_del_up("call update_customer('" + naw.Text + "','" + zh.Text + "','" + metroComboBox1.Text + "','" + ad.Text + "','" + jorebrekar.Text + "','" + id + "','" + username.Text + "','" + password.Text + "','نییە',0)");

                    }
                    else
                    {
                        ob.insert_del_up("call update_customer('" + naw.Text + "','" + zh.Text + "','" + metroComboBox1.Text + "','" + ad.Text + "','" + jorebrekar.Text + "','" + id + "','" + username.Text + "','" + password.Text + "','" + comboBox6.Text + "','" + comboBox6.SelectedValue.ToString() + "')");

                    }
                    messageboxsuc ms = new messageboxsuc();
                    ms.Show();
                    ob.table(dataGridView4, "call select_customer();");
                    ob.count(label57, dataGridView4, 0);
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>بەکارهێنەرەکان</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(dataGridView1, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label50.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void materialSingleLineTextField4_TextChanged(object sender, EventArgs e)
        {
            string searchValue = mst.Text;

            ob.table(dataGridView4, "call select_customer_name('" + searchValue + "');");
            ob.count(label57, dataGridView4, 0);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>بریکارەکان</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(dataGridView4, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label57.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void Backup(string sMySQLDatabase, string sFilePath)
        {

            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {

                    cmd.Connection = con;
                    con.Open();

                    mb.ExportToFile(sFilePath);
                    con.Close();
                }
            }

        }

        private void label113_Click(object sender, EventArgs e)
        {
            String day = DateTime.Now.Day.ToString();
            String month = DateTime.Now.Month.ToString();
            String year = DateTime.Now.Year.ToString();
            String hour = DateTime.Now.Hour.ToString();
            String mint = DateTime.Now.Minute.ToString();
            String second = DateTime.Now.Second.ToString();


            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = day + "-" + month + "-" + year + "________" + hour + "." + mint + "." + second;
            // set filters - this can be done in properties as well
            savefile.Filter = "Text files (*.sql)|*.sql|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    MessageBox.Show("...داتاکان بە سەرکەوتووی پاشەکەوت کرا ");
                Backup("pos", savefile.FileName);
            }
        }
        private void Restore(string sMySQLDatabase, string sFilePath)
        {


            using (MySqlCommand cmd = new MySqlCommand())
            {
                using (MySqlBackup mb = new MySqlBackup(cmd))
                {
                    cmd.Connection = con;
                    con.Open();

                    mb.ImportFromFile(sFilePath);
                    con.Close();
                }
            }

        }
        private void label114_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.FileName = "Filename will be ignored";
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.ShowReadOnly = false;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.ValidateNames = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // openFileDialog1.FileName should contain the folder and a dummy filename



                Restore("dktor", openFileDialog1.FileName);
                MessageBox.Show("...داتاکان بە سەرکەوتووی گەرانەوە");

            }
        }
        private void dataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dataGridView1.DataSource;
            bindingSource1.Filter = this.dataGridView1.FilterString;
            dataGridView1.DataSource = bindingSource1.DataSource;
            ob.count(label50, dataGridView1, 0);
        }

        private void dataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dataGridView1.DataSource;
            bindingSource1.Sort = this.dataGridView1.SortString;
            dataGridView1.DataSource = bindingSource1.DataSource;
            ob.count(label50, dataGridView1, 0);
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    int i = dataGridView1.SelectedRows[0].Index;
                    names.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    pass.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void dataGridView1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dataGridView1.SelectedRows.Count != 0)
                    {
                        int i = dataGridView1.SelectedRows[0].Index;
                        int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_login('" + id + "')");
                            ob.table(dataGridView1, "call select_login()");
                            ob.count(label50, dataGridView1, 0);

                        }
                        else
                        {
                            ob.table(dataGridView1, "call select_login()");
                            ob.count(label50, dataGridView1, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void dataGridView4_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dataGridView4.SelectedRows.Count != 0)
                    {
                        int i = dataGridView4.SelectedRows[0].Index;
                        int id = Convert.ToInt32(dataGridView4.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_customer('" + id + "')");
                            ob.table(dataGridView4, "call select_customer();");
                            ob.count(label57, dataGridView4, 0);

                        }
                        else
                        {
                            ob.table(dataGridView4, "call select_customer();");
                            ob.count(label57, dataGridView4, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }

        }

        private void dataGridView4_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dataGridView4.DataSource;
            bindingSource1.Filter = this.dataGridView4.FilterString;
            dataGridView4.DataSource = bindingSource1.DataSource;
            ob.count(label57, dataGridView4, 0);
        }

        private void dataGridView4_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dataGridView4.DataSource;
            bindingSource1.Sort = this.dataGridView4.SortString;
            dataGridView4.DataSource = bindingSource1.DataSource;
            ob.count(label57, dataGridView4, 0);
        }

        private void datadridview2_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datadridview2.DataSource;
            bindingSource1.Filter = this.datadridview2.FilterString;
            datadridview2.DataSource = bindingSource1.DataSource;
            ob.count(label14, datadridview2, 0);
        }

        private void datadridview2_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datadridview2.DataSource;
            bindingSource1.Sort = this.datadridview2.SortString;
            datadridview2.DataSource = bindingSource1.DataSource;
            ob.count(label14, datadridview2, 0);
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_employee('" + employe_name.Text + "','" + employe_degre.Text + "','" + mobile1.Text + "','" + mobile2.Text + "','" + amanat.Text + "','" + start_barwar.Text + "','" + state.Text + "','" + salary.Text + "')");
            ob.table(datadridview2, "call select_employee();");
            ob.a(this.Controls);
            ob.count(label14, datadridview2, 0);
        }

        private void datadridview2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datadridview2.SelectedRows.Count != 0)
                    {
                        int i = datadridview2.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datadridview2.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_employee('" + id + "')");
                            ob.table(datadridview2, "call select_employee();");
                            ob.count(label14, datadridview2, 0);
                            ob.a(this.Controls);
                        }
                        else
                        {
                            ob.table(datadridview2, "call select_employee();");
                            ob.count(label14, datadridview2, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }

        }

        private void datadridview2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (datadridview2.SelectedRows.Count != 0)
                {
                    int i = datadridview2.SelectedRows[0].Index;
                    employe_name.Text = datadridview2.Rows[i].Cells[1].Value.ToString();
                    employe_degre.Text = datadridview2.Rows[i].Cells[2].Value.ToString();
                    salary.Text = datadridview2.Rows[i].Cells[3].Value.ToString();
                    mobile1.Text = datadridview2.Rows[i].Cells[4].Value.ToString();
                    mobile2.Text = datadridview2.Rows[i].Cells[5].Value.ToString();
                    amanat.Text = datadridview2.Rows[i].Cells[6].Value.ToString();
                    start_barwar.Text = datadridview2.Rows[i].Cells[7].Value.ToString();
                    state.Text = datadridview2.Rows[i].Cells[8].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (datadridview2.SelectedRows.Count != 0)
                {
                    int i = datadridview2.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datadridview2.Rows[i].Cells[0].Value.ToString());


                    ob.insert_del_up("call update_employee('" + employe_name.Text + "','" + employe_degre.Text + "','" + mobile1.Text + "','" + mobile2.Text + "','" + amanat.Text + "','" + start_barwar.Text + "','" + state.Text + "','" + salary.Text + "','" + id + "')");
                    ob.table(datadridview2, "call select_employee();");
                    ob.count(label14, datadridview2, 0);
                    ob.a(this.Controls);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                }
            }
            catch (Exception)
            {


            }
        }

        private void em_name_search_TextChanged(object sender, EventArgs e)
        {
            if (em_name_search.Text != "")
            {
                ob.table(datadridview2, "SELECT `eid` as '#', `ename` as 'ناو', `pla` as 'پلە', `mucha` as 'موچە', `phone1` as 'ژمارەی مۆبایل1', `phone2` as 'ژمارەی مۆبایل2', `amanat` as 'ئەمانەت',DATE_FORMAT(`startdate`, '%Y/%m/%d') as 'بەرواری دەستبەکاربوون', `bar` as 'حاڵەت' FROM `employee` where `ename` like '" + em_name_search.Text + "%'");
                ob.count(label14, datadridview2, 0);
            }
            else
            {

                ob.table(datadridview2, "call select_employee();");
                ob.count(label14, datadridview2, 0);
            }
        }

        private void em_name_code_TextChanged(object sender, EventArgs e)
        {
            if (em_name_code.Text != "")
            {
                ob.table(datadridview2, "call select_employee_id('" + em_name_code.Text + "');");
                ob.count(label14, datadridview2, 0);
            }
            else
            {

                ob.table(datadridview2, "call select_employee();");
                ob.count(label14, datadridview2, 0);
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            ob.table(datadridview2, "call select_employee_day('" + startem.Text + "','" + lastem.Text + "');");
            ob.count(label14, datadridview2, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارمەندەکان</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datadridview2, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label14.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_isp('" + isp_name.Text + "','" + isp_mobile.Text + "','" + isp_address.Text + "')");
            ob.table(dataGridView3, "call select_isp();");
            ob.count(label33, dataGridView3, 0);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
        }

        private void dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (dataGridView3.SelectedRows.Count != 0)
                    {
                        int i = dataGridView3.SelectedRows[0].Index;
                        int id = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_isp('" + id + "')");
                            ob.table(dataGridView3, "call select_isp();");
                            ob.count(label33, dataGridView3, 0);
                            ob.a(this.Controls);
                        }
                        else
                        {
                            ob.table(dataGridView3, "call select_isp();");
                            ob.count(label33, dataGridView3, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.SelectedRows.Count != 0)
                {
                    int i = dataGridView3.SelectedRows[0].Index;
                    int id = Convert.ToInt32(dataGridView3.Rows[i].Cells[0].Value.ToString());


                    ob.insert_del_up("call update_isp('" + isp_name.Text + "','" + isp_mobile.Text + "','" + isp_address.Text + "','" + id + "')");
                    ob.table(dataGridView3, "call select_isp();");
                    ob.count(label33, dataGridView3, 0);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                }
            }
            catch (Exception)
            {


            }
        }

        private void dataGridView3_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dataGridView3.DataSource;
            bindingSource1.Filter = this.dataGridView3.FilterString;
            dataGridView3.DataSource = bindingSource1.DataSource;
            ob.count(label33, dataGridView3, 0);
        }

        private void dataGridView3_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = dataGridView3.DataSource;
            bindingSource1.Sort = this.dataGridView3.SortString;
            dataGridView3.DataSource = bindingSource1.DataSource;
            ob.count(label33, dataGridView3, 0);
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.SelectedRows.Count != 0)
                {
                    int i = dataGridView3.SelectedRows[0].Index;
                    isp_name.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
                    isp_mobile.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
                    isp_address.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();

                }
            }
            catch (Exception)
            {


            }
        }

        private void search_isp_TextChanged(object sender, EventArgs e)
        {
            if (search_isp.Text != "")
            {
                ob.table(dataGridView3, "SELECT `ic` as '#', `name` as 'ناوی کۆمپانیا', `phone` as 'مۆبایل', `location` as 'ناونیشان' FROM `ispcompany` where `name` like '" + search_isp.Text + "%'");
                ob.count(label33, dataGridView3, 0);

            }
            else
            {
                ob.table(dataGridView3, "call select_isp();");
                ob.count(label33, dataGridView3, 0);

            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>Isp</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(dataGridView3, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label33.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_balance('" + kartname.Text + "');");
            ob.table(datagridview5, "call select_balance();");
            ob.count(label35, datagridview5, 0);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
        }

        private void datagridview5_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview5.DataSource;
            bindingSource1.Filter = this.datagridview5.FilterString;
            datagridview5.DataSource = bindingSource1.DataSource;
            ob.count(label35, datagridview5, 0);
        }

        private void datagridview5_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview5.DataSource;
            bindingSource1.Sort = this.datagridview5.SortString;
            datagridview5.DataSource = bindingSource1.DataSource;
            ob.count(label35, datagridview5, 0);
        }

        private void datagridview5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview5.SelectedRows.Count != 0)
                    {
                        int i = datagridview5.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview5.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_balance('" + id + "')");
                            ob.table(datagridview5, "call select_balance();");
                            ob.count(label35, datagridview5, 0);
                        }
                        else
                        {
                            ob.table(datagridview5, "call select_balance();");
                            ob.count(label35, datagridview5, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void search_karname_TextChanged(object sender, EventArgs e)
        {
            if (search_karname.Text != "")
            {
                ob.table(datagridview5, "SELECT `bid` as '#', `types` as 'جۆری باڵانس' FROM `balance` where `types` like '" + search_karname.Text + "%'");
                ob.count(label35, datagridview5, 0);
            }
            else
            {
                ob.table(datagridview5, "call select_balance();");
                ob.count(label35, datagridview5, 0);

            }
        }

        private void pictureBox15_Click_1(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارتەکان</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview5, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label35.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            ob.toexcel(dataGridView1);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            ob.toexcel(dataGridView4);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            ob.toexcel(datadridview2);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            ob.toexcel(dataGridView3);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview5);
        }



        private void pictureBox27_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_amer('" + amername.Text + "')");
            ob.table(datagridview6, "call select_amer();");
            ob.count(label43, datagridview6, 0);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text != "")
            {
                ob.table(datagridview6, "SELECT `aid` as '#', `aname` as 'ناوی ئامێر' FROM `amer` where aname like '" + materialSingleLineTextField1.Text + "%'");
                ob.count(label43, datagridview6, 0);

            }
            else
            {
                ob.table(datagridview6, "call select_amer();");
                ob.count(label43, datagridview6, 0);

            }
        }

        private void datagridview6_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview6);
            ob.count(label43, datagridview6, 0);
        }

        private void datagridview6_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview6);
            ob.count(label43, datagridview6, 0);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێرەکان</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview6, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label43.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview6);
        }

        private void datagridview8_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview8.DataSource;
            bindingSource1.Filter = this.datagridview8.FilterString;
            datagridview8.DataSource = bindingSource1.DataSource;
            ob.count(label51, datagridview8, 0);
        }

        private void datagridview8_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview8.DataSource;
            bindingSource1.Sort = this.datagridview8.SortString;
            datagridview8.DataSource = bindingSource1.DataSource;
            ob.count(label51, datagridview8, 0);
        }

        private void datagridview9_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview9.DataSource;
            bindingSource1.Filter = this.datagridview9.FilterString;
            datagridview9.DataSource = bindingSource1.DataSource;
            ob.count(label59, datagridview9, 0);
        }

        private void datagridview9_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview9.DataSource;
            bindingSource1.Sort = this.datagridview9.SortString;
            datagridview9.DataSource = bindingSource1.DataSource;
            ob.count(label59, datagridview9, 0);
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_cus_company('" + namenetcompany.Text + "','" + phonenetcompany.Text + "','" + addressnetcompany.Text + "')");
            ob.table(datagridview8, "call select_cus_company();");
            ob.count(label51, datagridview8, 0);
            ob.a(this.Controls);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_net_company('" + namecuscompany.Text + "','" + phonecuscompany.Text + "','" + addresscuscompany.Text + "')");
            ob.table(datagridview9, "call select_net_company();");
            ob.count(label59, datagridview9, 0);
            ob.a(this.Controls);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
        }

        private void datagridview8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview8.SelectedRows.Count != 0)
                    {
                        int i = datagridview8.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview8.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_cus_company('" + id + "')");
                            ob.table(datagridview8, "call select_cus_company();");
                            ob.count(label51, datagridview8, 0);
                            ob.a(this.Controls);
                        }
                        else
                        {
                            ob.table(datagridview8, "call select_net_company();");
                            ob.count(label51, datagridview8, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void datagridview9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview9.SelectedRows.Count != 0)
                    {
                        int i = datagridview9.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview9.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_net_company('" + id + "')");
                            ob.table(datagridview9, "call select_net_company();");
                            ob.count(label59, datagridview9, 0);
                            ob.a(this.Controls);
                        }
                        else
                        {
                            ob.table(datagridview9, "call select_cus_company();");
                            ob.count(label59, datagridview9, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridview8_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (datagridview8.SelectedRows.Count != 0)
                {
                    int i = datagridview8.SelectedRows[0].Index;
                    namenetcompany.Text = datagridview8.Rows[i].Cells[1].Value.ToString();
                    phonenetcompany.Text = datagridview8.Rows[i].Cells[2].Value.ToString();
                    addressnetcompany.Text = datagridview8.Rows[i].Cells[3].Value.ToString();

                }
            }
            catch (Exception)
            {


            }
        }

        private void datagridview9_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (datagridview9.SelectedRows.Count != 0)
                {
                    int i = datagridview9.SelectedRows[0].Index;
                    namecuscompany.Text = datagridview9.Rows[i].Cells[1].Value.ToString();
                    phonecuscompany.Text = datagridview9.Rows[i].Cells[2].Value.ToString();
                    addresscuscompany.Text = datagridview9.Rows[i].Cells[3].Value.ToString();

                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridview8.SelectedRows.Count != 0)
                {
                    int i = datagridview8.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridview8.Rows[i].Cells[0].Value.ToString());
                    ob.insert_del_up("call update_cus_company('" + namenetcompany.Text + "','" + phonenetcompany.Text + "','" + addressnetcompany.Text + "','" + id + "')");
                    ob.table(datagridview8, "call select_cus_company();");
                    ob.count(label51, datagridview8, 0);
                    ob.a(this.Controls);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();

                }
            }
            catch (Exception)
            {


            }

        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {

            try
            {
                if (datagridview9.SelectedRows.Count != 0)
                {
                    int i = datagridview9.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridview9.Rows[i].Cells[0].Value.ToString());
                    ob.insert_del_up("call update_net_company('" + namecuscompany.Text + "','" + phonecuscompany.Text + "','" + addresscuscompany.Text + "','" + id + "')");
                    ob.table(datagridview9, "call select_net_company();");
                    ob.count(label59, datagridview9, 0);
                    ob.a(this.Controls);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();

                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview8);
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview9);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کڕیاری باند</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview8, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label51.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>فرۆشیاری ئامێر</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview9, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label59.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void materialSingleLineTextField2_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField2.Text != "")
            {
                ob.table(datagridview8, "SELECT `ccid` AS '#', `name` AS 'ناو', `phone` AS 'ژمارە مۆبایل', `location` AS 'ناونیشان' FROM `cus_company` where `name` like '" + materialSingleLineTextField2.Text + "%'");
                ob.count(label51, datagridview8, 0);

            }
            else
            {
                ob.table(datagridview8, "call select_cus_company();");
                ob.count(label51, datagridview8, 0);


            }
        }

        private void materialSingleLineTextField3_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField3.Text != "")
            {
                ob.table(datagridview8, "call select_cus_company_id('" + materialSingleLineTextField3.Text + "');");
                ob.count(label51, datagridview8, 0);

            }
            else
            {

                ob.table(datagridview8, "call select_cus_company();");
                ob.count(label51, datagridview8, 0);

            }
        }

        private void materialSingleLineTextField5_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField5.Text != "")
            {
                ob.table(datagridview9, "SELECT `ncid` AS '#', `name` AS 'ناوی کۆمپانیا', `phone` AS 'ژمارە مۆبایل', `location` AS 'ناونیشان' FROM `net_company` where `name` like '" + materialSingleLineTextField5.Text + "%'");
                ob.count(label59, datagridview9, 0);

            }
            else
            {
                ob.table(datagridview9, "call select_net_company();");
                ob.count(label59, datagridview9, 0);


            }
        }

        private void materialSingleLineTextField4_TextChanged_2(object sender, EventArgs e)
        {
            if (materialSingleLineTextField4.Text != "")
            {
                ob.table(datagridview9, "call select_net_company_id('" + materialSingleLineTextField4.Text + "');");
                ob.count(label59, datagridview9, 0);

            }
            else
            {

                ob.table(datagridview9, "call select_net_company();");
                ob.count(label59, datagridview9, 0);
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 8;
            ob.comb(companya, "SELECT * FROM net_company", "ncid", "name");
            ob.comb(amer, "SELECT * FROM amer", "aid", "aname");

            ob.table(datagridview10, "call select_amer_hatu_info();");
            ob.sum(label69, datagridview10, 2);
            ob.sum(label71, datagridview10, 3);
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                double resp = Convert.ToDouble(price.Text) / dolar;
                double resm = Convert.ToDouble(money.Text) / dolar;
                ob.insert_del_up("call insert_amer_hatu('" + resp + "','" + number.Text + "','" + barwar_amer_hatu.Text + "','" + amer.SelectedValue.ToString() + "','" + companya.SelectedValue.ToString() + "','" + sump.Text + "','" + resm + "','" + qarz.Text + "','" + waslamer.Text + "','" + textBox6.Text + "','کۆمپانیا')");
            }
            else
            {
                ob.insert_del_up("call insert_amer_hatu('" + price.Text + "','" + number.Text + "','" + barwar_amer_hatu.Text + "','" + amer.SelectedValue.ToString() + "','" + companya.SelectedValue.ToString() + "','" + sump.Text + "','" + money.Text + "','" + qarz.Text + "','" + waslamer.Text + "','" + textBox6.Text + "','کۆمپانیا')");

            }
            ob.insert_del_up("call insert_storage_amer('" + amer.SelectedValue.ToString() + "','" + number.Text + "','" + barwar_amer_hatu.Text + "')");

            if (qarz.Text != "" && qarz.Text != "0")
            {
                ob.insert_del_up("call insert_qarz_net_company('" + qarz.Text + "','" + barwar_amer_hatu.Text + "','" + companya.SelectedValue.ToString() + "')");
            }
            ob.table(datagridview10, "call select_amer_hatu_info();");
            ob.sum(label69, datagridview10, 2);
            ob.sum(label71, datagridview10, 3);
            //ob.a(this.Controls);

            messageboxsuc obb = new messageboxsuc();
            obb.Show();

        }

        private void price_TextChanged(object sender, EventArgs e)
        {

            try
            {

                if (checkBox3.Checked != true)
                {
                    if (price.Text != "" && number.Text != "")
                    {
                        sump.Text = (Convert.ToDouble(price.Text) * Convert.ToDouble(number.Text)).ToString();

                    }
                    else
                    {

                        sump.Text = "0";
                    }


                    sumpd.Text = (Convert.ToDouble(sump.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (price.Text != "" && number.Text != "")
                    {
                        sumpd.Text = (Convert.ToDouble(price.Text) * Convert.ToDouble(number.Text)).ToString();
                        sump.Text = (Convert.ToDouble(sumpd.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        sumpd.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }



        private void number_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked != true)
                {
                    if (price.Text != "" && number.Text != "")
                    {
                        sump.Text = (Convert.ToDouble(price.Text) * Convert.ToDouble(number.Text)).ToString();

                    }
                    else
                    {

                        sump.Text = "0";
                    }


                    sumpd.Text = (Convert.ToDouble(sump.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (price.Text != "" && number.Text != "")
                    {
                        sumpd.Text = (Convert.ToDouble(price.Text) * Convert.ToDouble(number.Text)).ToString();
                        sump.Text = (Convert.ToDouble(sumpd.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        sumpd.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void sump_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (money.Text != "" && sump.Text != "")
                {

                    qarz.Text = (Convert.ToDouble(sump.Text) - Convert.ToDouble(money.Text)).ToString();
                }
                else
                {
                    qarz.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void money_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox3.Checked != true)
                {
                    if (money.Text != "" || sump.Text != "")
                    {

                        qarz.Text = (Convert.ToDouble(sump.Text) - Convert.ToDouble(money.Text)).ToString();
                    }
                    else
                    {
                        qarz.Text = "0";
                    }
                }
                else
                {
                    if (money.Text != "" || sump.Text != "")
                    {
                        double mm = Convert.ToDouble(money.Text) / dolar;
                        qarz.Text = (Convert.ToDouble(sump.Text) - mm).ToString();
                    }
                    else
                    {
                        qarz.Text = "0";
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void datagridview10_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview10.DataSource;
            bindingSource1.Filter = this.datagridview10.FilterString;
            datagridview10.DataSource = bindingSource1.DataSource;
            ob.sum(label69, datagridview10, 2);
            ob.sum(label71, datagridview10, 3);
        }

        private void datagridview10_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview10.DataSource;
            bindingSource1.Sort = this.datagridview10.SortString;
            datagridview10.DataSource = bindingSource1.DataSource;
            ob.sum(label69, datagridview10, 2);
            ob.sum(label71, datagridview10, 3);
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview10);
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێری هاتوو</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview10, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label69.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label71.Text + "</p>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void datagridview10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //try
                //{
                if (datagridview10.SelectedRows.Count != 0)
                {
                    int i = datagridview10.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridview10.Rows[i].Cells[0].Value.ToString());

                    int num = Convert.ToInt32(datagridview10.Rows[i].Cells[2].Value.ToString());
                    double pric = Convert.ToDouble(datagridview10.Rows[i].Cells[3].Value.ToString());
                    if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ob.insert_del_up("call delete_qarz_net_company('" + id + "')");
                        ob.insert_del_up("call delete_amer_hatu('" + id + "')");
                        ob.insert_del_up("call delete_storage_amer('" + amer.SelectedValue.ToString() + "','" + num + "')");

                        ob.table(datagridview10, "call select_amer_hatu_info();");
                        ob.sum(label69, datagridview10, 2);
                        ob.sum(label71, datagridview10, 3);

                    }
                    else
                    {
                        ob.table(datagridview10, "call select_amer_hatu_info();");
                        ob.sum(label69, datagridview10, 2);
                        ob.sum(label71, datagridview10, 3);
                    }
                }
                //}
                //catch (Exception)
                //{


                //}
            }
        }

        private void datagridview10_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (datagridview10.SelectedRows.Count != 0)
                {
                    int i = datagridview10.SelectedRows[0].Index;
                    companya.Text = datagridview10.Rows[i].Cells[8].Value.ToString();
                    amer.Text = datagridview10.Rows[i].Cells[7].Value.ToString();
                    price.Text = datagridview10.Rows[i].Cells[1].Value.ToString();
                    number.Text = datagridview10.Rows[i].Cells[2].Value.ToString();

                    sump.Text = datagridview10.Rows[i].Cells[3].Value.ToString();
                    barwar_amer_hatu.Text = datagridview10.Rows[i].Cells[6].Value.ToString();
                    money.Text = datagridview10.Rows[i].Cells[4].Value.ToString();
                    textBox6.Text = datagridview10.Rows[i].Cells[11].Value.ToString();
                    waslamer.Text = datagridview10.Rows[i].Cells[9].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 9;
            comboBox8.SelectedIndex = 0;
            if (comboBox8.Text == "گشتی")
            {
                ob.table(datagridview11, "SELECT amer.`aid` as '#', `amer`.aname as 'ئامێر',(((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE  amer_garawa_kompanya.state='قبوڵکراو' and `amer_garawa_kompanya`.`aid` = `amer`.`aid`))+((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE (`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND (`amer_garawa`.`state` = 'قبوڵکراو')))) as 'هاتوو',(((SELECT  COALESCE(SUM(`amer_froshtn`.`num`), 0) AS `num` FROM `amer_froshtn` WHERE  `amer_froshtn`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE  amer_bo_koga.state='قبوڵکراو' and `amer_bo_koga`.`aid` = `amer`.`aid`))+((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND amer_garawa_kompanya.state='قبوڵکراو'))) as 'ڕۆشتوو',(((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE  amer_garawa_kompanya.state='قبوڵکراو' and `amer_garawa_kompanya`.`aid` = `amer`.`aid`))-((SELECT  COALESCE(SUM(`amer_froshtn`.`num`), 0) AS `num` FROM `amer_froshtn` WHERE  `amer_froshtn`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE  amer_bo_koga.state='قبوڵکراو' and `amer_bo_koga`.`aid` = `amer`.`aid`))+((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE (`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND (`amer_garawa`.`state` = 'قبوڵکراو'))) -((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND amer_garawa_kompanya.state='قبوڵکراو'))) as 'کۆگا' FROM `amer`");

            }
            else if (comboBox8.Text == "کۆمپانیا")
            {
                ob.table(datagridview11, "SELECT amer.`aid` as '#', `amer`.aname as 'ئامێر',((((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE ((`amer_hato`.`aid` = `amer`.`aid`)))+((SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE ((`amer_garawa_kompanya`.`aid` = `amer`.`aid`))))-((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE ((`amer_bo_koga`.`aid` = `amer`.`aid`)))) FROM `amer`");

            }
            else
            {
                ob.table(datagridview11, "SELECT  `amer`.`aid` AS `aid`,`amer`.`aname` AS `amer`,(((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE ((`amer_hato`.`aid` = `amer`.`aid`) AND (`amer_hato`.`maxzan` = '" + comboBox8.Text + "'))) + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE ((`amer_garawa`.`aid` = `amer`.`aid`) AND (`amer_garawa`.`state` = 'قبوڵکراو') AND (`amer_garawa`.`maxzan` = '" + comboBox8.Text + "')))) - (SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE ((dawakary_amer_view.state='قبوڵکراو') and (`dawakary_amer_view`.`arid` = `amer`.`aid`) AND (`dawakary_amer_view`.`maxzan` = '" + comboBox8.Text + "')))) AS `result` FROM `amer`");

            }
            //else if (comboBox8.Text == "سلێمانی")
            //{
            //    ob.table(datagridview11, "SELECT `aid` as '#', `amer` as 'ئامێر', `result` as 'عەدەد' FROM `kogasl`");
            //}
            //else if (comboBox8.Text == "کەلار")
            //{
            //    ob.table(datagridview11, "SELECT  `amer`.`aid` AS `aid`,`amer`.`aname` AS `amer`,(((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE ((`amer_hato`.`aid` = `amer`.`aid`) AND (`amer_hato`.`maxzan` = '"++"'))) + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE ((`amer_garawa`.`aid` = `amer`.`aid`) AND (`amer_garawa`.`state` = 'قبوڵکراو') AND (`amer_garawa`.`maxzan` = 'کەلار')))) - (SELECT COALESCE(SUM(`amer_roshto`.`num`), 0) AS `num` FROM `amer_roshto` WHERE ((`amer_roshto`.`aid` = `amer`.`aid`) AND (`amer_roshto`.`maxzan` = 'کەلار')))) AS `result` FROM `amer`");
            //}
            //else
            //{
            //    ob.table(datagridview11, "SELECT `aid` as '#', `amer` as 'ئامێر', `result` as 'عەدەد' FROM `kogahaw`");
            //}
            ob.sum(label78, datagridview11, 4);

        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview11);
        }

        private void datagridview11_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview11.DataSource;
            bindingSource1.Filter = this.datagridview11.FilterString;
            datagridview11.DataSource = bindingSource1.DataSource;
            ob.sum(label78, datagridview11, 2);

        }

        private void datagridview11_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview11.DataSource;
            bindingSource1.Sort = this.datagridview11.SortString;
            datagridview11.DataSource = bindingSource1.DataSource;
            ob.sum(label78, datagridview11, 2);

        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کۆگای ئامێر</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview11, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label78.Text + "</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void materialSingleLineTextField7_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField7.Text != "")
            {

                ob.table(datagridview11, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار' FROM `storage_amer_view` where lower(`aname`) like '%" + materialSingleLineTextField7.Text + "%'");
                ob.sum(label78, datagridview11, 2);

            }
            else
            {

                ob.table(datagridview11, "call select_storage_amer();");
                ob.sum(label78, datagridview11, 2);

            }
        }

        private void materialSingleLineTextField6_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField6.Text != "")
            {

                ob.table(datagridview11, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار' FROM `storage_amer_view` where `id` like '" + materialSingleLineTextField6.Text + "%'");
                ob.sum(label78, datagridview11, 2);

            }
            else
            {

                ob.table(datagridview11, "call select_storage_amer();");
                ob.sum(label78, datagridview11, 2);
                dateTimePicker85.Text = DateTime.Now.ToString();
            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 34;
            ob.comb(comboBox14, "SELECT * FROM customer", "cid", "cname");
            //  ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', `barwar` as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت', `wasl` as 'وەسڵ' FROM `dawakary_amer_view`");
            ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',`maxzan` as 'کۆگا',`wasl` as 'وەسڵ', `state` as 'حاڵەت' FROM `dawakary_amer_view` group by wasl");
            ob.count(label365, data36, 2);

        }

        private void datagridview12_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            if (datagridview12.SelectedRows.Count != 0)
            {
                int i = datagridview12.SelectedRows[0].Index;
                int id = Convert.ToInt32(datagridview12.Rows[i].Cells[0].Value.ToString());
                int waslda = Convert.ToInt32(datagridview12.Rows[i].Cells[8].Value.ToString());
                String stat = datagridview12.Rows[i].Cells[5].Value.ToString();
                if (stat != "قبوڵکراو")
                {

                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        MySqlCommand mss = new MySqlCommand("SELECT * FROM `dawakary_amer` WHERE `id`='" + id + "'", con);
                        MySqlDataReader rd = mss.ExecuteReader();
                        String adad = "";
                        String amer = "";
                        String cus = "";
                        String wasl = "";
                        String maxzan = "";
                        while (rd.Read())
                        {
                            adad = rd.GetString("adad");
                            amer = rd.GetString("amer");
                            cus = rd.GetString("cus");
                            wasl = rd.GetString("wasl");
                            maxzan = rd.GetString("maxzan");

                        }
                        con.Close();
                        String numa = "";
                        //String shwen = "";
                        if (maxzan == "هەولێر")
                        {
                            con.Open();

                            MySqlCommand mddd = new MySqlCommand("SELECT  `amer`.`aid` AS `aid`,`amer`.`aname` AS `amer`,(((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE ((`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو' AND (`amer_bo_koga`.`koga` = 'هەولێر'))) + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE ((`amer_garawa`.`aid` = `amer`.`aid`) AND (`amer_garawa`.`state` = 'قبوڵکراو') AND (`amer_garawa`.`maxzan` = 'هەولێر')))) - (SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE ((dawakary_amer_view.state='قبوڵکراو') and (`dawakary_amer_view`.`arid` = `amer`.`aid`) AND (`dawakary_amer_view`.`maxzan` = 'هەولێر')))+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE ((`amer_garawa_kompanya`.`aid` = `amer`.`aid`) AND amer_garawa_kompanya.state='قبوڵکراو' AND (`amer_garawa_kompanya`.`koga` = 'هەولێر')))) AS `num` FROM `amer` where aid='" + amer + "'", con);
                            MySqlDataReader rddd = mddd.ExecuteReader();
                            while (rddd.Read())
                            {
                                numa = rddd.GetString("num");
                            }
                            con.Close();
                        }
                        else if (maxzan == "سلێمانی")
                        {
                            con.Open();
                            MySqlCommand mddd = new MySqlCommand("SELECT  `amer`.`aid` AS `aid`,`amer`.`aname` AS `amer`,(((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE ((`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو' AND (`amer_bo_koga`.`koga` = 'سلێمانی'))) + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE ((`amer_garawa`.`aid` = `amer`.`aid`) AND (`amer_garawa`.`state` = 'قبوڵکراو') AND (`amer_garawa`.`maxzan` = 'سلێمانی')))) - (SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE ((dawakary_amer_view.state='قبوڵکراو') and (`dawakary_amer_view`.`arid` = `amer`.`aid`) AND (`dawakary_amer_view`.`maxzan` = 'سلێمانی')))+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE ((`amer_garawa_kompanya`.`aid` = `amer`.`aid`) AND amer_garawa_kompanya.state='قبوڵکراو' AND (`amer_garawa_kompanya`.`koga` = 'سلێمانی')))) AS `num` FROM `amer` where aid='" + amer + "'", con);
                            MySqlDataReader rddd = mddd.ExecuteReader();
                            while (rddd.Read())
                            {
                                numa = rddd.GetString("num");
                            }
                            con.Close();
                        }
                        else
                        {
                            con.Open();
                            MySqlCommand mddd = new MySqlCommand("SELECT  `amer`.`aid` AS `aid`,`amer`.`aname` AS `amer`,(((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE ((`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو' AND (`amer_bo_koga`.`koga` = 'کەلار'))) + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE ((`amer_garawa`.`aid` = `amer`.`aid`) AND (`amer_garawa`.`state` = 'قبوڵکراو') AND (`amer_garawa`.`maxzan` = 'کەلار')))) - (SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE ((dawakary_amer_view.state='قبوڵکراو') and (`dawakary_amer_view`.`arid` = `amer`.`aid`) AND (`dawakary_amer_view`.`maxzan` = 'کەلار')))+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE ((`amer_garawa_kompanya`.`aid` = `amer`.`aid`) AND amer_garawa_kompanya.state='قبوڵکراو' AND (`amer_garawa_kompanya`.`koga` = 'کەلار')))) AS `num` FROM `amer` where aid='" + amer + "'", con);
                            MySqlDataReader rddd = mddd.ExecuteReader();
                            while (rddd.Read())
                            {
                                numa = rddd.GetString("num");
                            }
                            con.Close();
                        }


                        if (Convert.ToDouble(adad) > Convert.ToDouble(numa))
                        {
                            MessageBox.Show("بڕی ئامێری پێویست لە کۆگایا نییە");
                        }
                        else
                        {

                            ob.insert_del_up("UPDATE `dawakary_amer` SET `state`='قبوڵکراو' WHERE `id`='" + id + "'");
                            // ob.insert_del_up("INSERT INTO `amer_roshto`(`num`,`dates`, `aid`, `cusid`, `wasl`, `qarz`,burj,tebene,price,maxzan) VALUES ('" + adad + "','" + dateTimePicker64.Text + "','" + amer + "','" + cus + "','" + wasl + "',`sump`,'','','0','" + maxzan + "')");
                            //  ob.insert_del_up("call delete_storage_amer('" + amer + "','" + adad + "')");
                            // ob.insert_del_up("call insert_storage_amer_customer('" + amer + "','" + adad + "','" + cus + "','" + dateTimePicker64.Text + "')");
                            ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت',maxzan as 'کۆگا', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                            ob.sum(label87, datagridview12, 2);
                        }
                    }

                    else
                    {
                        ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                        ob.sum(label87, datagridview12, 2);
                    }
                }
            }
            //}
            //catch (Exception)
            //{


            //}

        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 11;
            ob.comb(mushtary, "SELECT * FROM customer", "cid", "cname");
            ob.comb(amerf, "SELECT * FROM amer", "aid", "aname");

            ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid order by arid desc");
            ob.sum(label91, datagridview13, 2);
            ob.sum(label86, datagridview13, 3);
        }

        private void pricef_TextChanged(object sender, EventArgs e)
        {

            if (pricef.Text != "" && numberf.Text != "")
            {
                sumpf.Text = (Convert.ToDouble(pricef.Text) * Convert.ToDouble(numberf.Text)).ToString();

            }
            else
            {

                sumpf.Text = "0";
            }

        }

        private void numberf_TextChanged(object sender, EventArgs e)
        {

            if (pricef.Text != "" && numberf.Text != "")
            {
                sumpf.Text = (Convert.ToDouble(pricef.Text) * Convert.ToDouble(numberf.Text)).ToString();

            }
            else
            {

                sumpf.Text = "0";
            }

        }

        private void sumpf_TextChanged(object sender, EventArgs e)
        {

            if (sumpf.Text != "")
            {

                sumpdf.Text = (Convert.ToDouble(sumpf.Text) / online.draw.dolar).ToString();
            }
            else
            {
                sumpdf.Text = "0";

            }
            if (moneyf.Text != "" && sumpf.Text != "")
            {

                qarzf.Text = (Convert.ToDouble(sumpf.Text) - Convert.ToDouble(moneyf.Text)).ToString();
            }
            else
            {
                qarzf.Text = "0";
            }


        }




        private void moneyf_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (moneyf.Text != "" || sumpf.Text != "")
                {

                    qarzf.Text = (Convert.ToDouble(sumpf.Text) - Convert.ToDouble(moneyf.Text)).ToString();
                }
                else
                {
                    qarzf.Text = "0";
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                MySqlCommand md = new MySqlCommand("SELECT * FROM `storage_amer` WHERE aid='" + amerf.SelectedValue.ToString() + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                int n = 0;
                int num = Convert.ToInt16(numberf.Text);
                double pk = 0;
                double psk = 0;
                while (rd.Read())
                {

                    n = rd.GetInt16("number");
                }
                con.Close();
                if (n < num)
                {
                    MessageBox.Show("بڕی ئامێری پێویست لە کۆگایا نییە");
                }
                else
                {
                    con.Open();
                    MySqlCommand mdd = new MySqlCommand("SELECT price FROM `amer_hato` WHERE aid = '" + amerf.SelectedValue.ToString() + "' order by ahid desc limit 2", con);
                    MySqlDataReader rdd = mdd.ExecuteReader();
                    while (rdd.Read())
                    {
                        pk = pk + Convert.ToDouble(rdd.GetString("price"));
                    }
                    con.Close();

                    pk = pk / 2;
                    psk = pk * Convert.ToDouble(numberf.Text);
                    ob.insert_del_up("INSERT INTO `amer_froshtn`(`price`, `num`, `sump`,pk,spk, `money`, `qarz`, `dates`, `aid`, `cusid`,`wasl`, `burj`, `tebene`) VALUES ('" + pricef.Text + "','" + numberf.Text + "','" + sumpf.Text + "','" + pk + "','" + psk + "','" + moneyf.Text + "','" + qarzf.Text + "','" + dateTimePicker1.Text + "','" + amerf.SelectedValue.ToString() + "','" + mushtary.SelectedValue.ToString() + "','" + waslf.Text + "','" + materialSingleLineTextField33.Text + "','" + textBox7.Text + "')");

                    ob.insert_del_up("call delete_storage_amer('" + amerf.SelectedValue.ToString() + "','" + numberf.Text + "')");
                    ob.insert_del_up("call insert_storage_amer_customer('" + amerf.SelectedValue.ToString() + "','" + numberf.Text + "','" + mushtary.SelectedValue.ToString() + "','" + dateTimePicker1.Text + "')");


                    if (qarzf.Text != "" && qarzf.Text != "0")
                    {
                        ob.insert_del_up("call insert_qarz_customer('" + qarzf.Text + "','" + dateTimePicker1.Text + "','" + mushtary.SelectedValue.ToString() + "',(select max(arid) from `amer_froshtn`))");
                    }
                    ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid order by arid desc");
                    ob.sum(label91, datagridview13, 2);
                    ob.sum(label86, datagridview13, 3);
                    ob.a(this.Controls);

                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                }



            }

            catch (Exception)
            {

            }


        }

        private void datagridview13_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview13.DataSource;
            bindingSource1.Sort = this.datagridview13.SortString;
            datagridview13.DataSource = bindingSource1.DataSource;
            ob.sum(label91, datagridview13, 2);
            ob.sum(label86, datagridview13, 3);
        }

        private void datagridview13_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview13.DataSource;
            bindingSource1.Filter = this.datagridview13.FilterString;
            datagridview13.DataSource = bindingSource1.DataSource;
            ob.sum(label91, datagridview13, 2);
            ob.sum(label86, datagridview13, 3);
        }

        private void datagridview13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview13.SelectedRows.Count != 0)
                    {
                        int i = datagridview13.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview13.Rows[i].Cells[0].Value.ToString());
                        int aid = Convert.ToInt32(datagridview13.Rows[i].Cells[1].Value.ToString());
                        int num = Convert.ToInt32(datagridview13.Rows[i].Cells[2].Value.ToString());
                        double pric = Convert.ToDouble(datagridview13.Rows[i].Cells[3].Value.ToString());
                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `qarz` WHERE `id_amer_roshtu`='" + id + "'");
                            ob.insert_del_up("DELETE FROM `amer_froshtn` WHERE `arid`='" + id + "'");
                            ob.insert_del_up("call insert_storage_amer('" + amerf.SelectedValue.ToString() + "','" + num + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "')");
                            ob.insert_del_up("call delete_storage_amer_customer('" + amerf.SelectedValue.ToString() + "','" + num + "','" + mushtary.SelectedValue.ToString() + "')");

                            ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid order by arid desc");
                            ob.sum(label91, datagridview13, 2);
                            ob.sum(label86, datagridview13, 3);

                        }
                        else
                        {
                            ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid order by arid desc");
                            ob.sum(label91, datagridview13, 2);
                            ob.sum(label86, datagridview13, 3);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridview13_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (datagridview13.SelectedRows.Count != 0)
                {
                    int i = datagridview13.SelectedRows[0].Index;
                    mushtary.Text = datagridview13.Rows[i].Cells[8].Value.ToString();
                    amerf.Text = datagridview13.Rows[i].Cells[7].Value.ToString();
                    pricef.Text = datagridview13.Rows[i].Cells[1].Value.ToString();
                    numberf.Text = datagridview13.Rows[i].Cells[2].Value.ToString();
                    sumpf.Text = datagridview13.Rows[i].Cells[3].Value.ToString();
                    moneyf.Text = datagridview13.Rows[i].Cells[4].Value.ToString();
                    qarzf.Text = datagridview13.Rows[i].Cells[5].Value.ToString();
                    dateTimePicker1.Text = datagridview13.Rows[i].Cells[6].Value.ToString();
                    materialSingleLineTextField33.Text = datagridview13.Rows[i].Cells[9].Value.ToString();
                    waslf.Text = datagridview13.Rows[i].Cells[10].Value.ToString();
                    textBox7.Text = datagridview13.Rows[i].Cells[11].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview13);
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێری فۆرشراو</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview13, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label91.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label86.Text + "</p>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 0;
            ob.table(dataGridView1, "call select_login()");
            ob.count(label50, dataGridView1, 0);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 1;
            ob.table(dataGridView4, "call select_customer();");
            ob.count(label57, dataGridView4, 0);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 2;
            ob.table(datadridview2, "call select_employee();");
            ob.count(label14, datadridview2, 0);
        }

        private void ئامێرەکانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 5;
            ob.table(datagridview6, "call select_amer();");
            ob.count(label43, datagridview6, 0);
        }

        private void کارتەکانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 4;
            ob.table(datagridview5, "call select_balance();");
            ob.count(label35, datagridview5, 0);
        }

        private void iSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 3;
            ob.table(dataGridView3, "call select_isp();");
            ob.count(label33, dataGridView3, 0);
        }

        private void کڕیاریباندToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 6;
            ob.table(datagridview8, "call select_cus_company();");
            ob.count(label51, datagridview8, 0);
        }

        private void کۆمپانیایفۆرشیاریئامێرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 7;
            ob.table(datagridview9, "call select_net_company();");
            ob.count(label59, datagridview9, 0);
        }

        private void zhmaradawakraw_TextChanged(object sender, EventArgs e)
        {

        }

        private void amerdawakraw_TextChanged(object sender, EventArgs e)
        {

        }

        private void brykarname_TextChanged(object sender, EventArgs e)
        {

        }


        private void قەرزیکڕیاریئامێرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 12;
            ob.comb(brekarqarz, "SELECT * FROM customer", "cid", "cname");
            ob.table(datagridview14, "SELECT qarz.`qid` AS '#', qarz.`qarzdinar` AS 'بڕی قەرز',DATE_FORMAT(qarz.`dates`, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', customer.`types` AS 'جۆری بریکار' FROM `qarz` join customer on(customer.`cid`=qarz.cid)");
            ob.sum(label106, datagridview14, 1);

        }

        private void گێڕانەوەیقەرزیکڕیاریئامێرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 13;
            ob.comb(brekargive, "SELECT * FROM customer", "cid", "cname");
            ob.table(datagridview16, "SELECT give_customer.qncid AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid");
            ob.sum(label118, datagridview16, 1);

        }

        private void قەرزیفرۆشیاریئامێرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 14;
            ob.comb(companyaqarz, "SELECT * FROM net_company", "ncid", "name");
            ob.table(datagridview15, "SELECT qarz_net_comp.`qncid` AS '#', qarz_net_comp.`qarzdinar` AS 'بڕی قەرز',DATE_FORMAT(qarz_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.name AS 'کۆمپانیا' FROM `qarz_net_comp`,net_company where qarz_net_comp.ncid=net_company.ncid");
            ob.sum(label113, datagridview15, 1);
        }

        private void گێڕانەوەیقەرزیئامێرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 15;

            ob.comb(companyagive, "SELECT * FROM net_company", "ncid", "name");
            waslfa.Text = DateTime.Now.ToString("yyyyMMdd") + companyagive.SelectedValue.ToString();
            ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`wasl` AS 'ژ.وەسڵ', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid");
            ob.sum(label136, datagridview17, 1);
        }

        private void brekarqarz_Enter(object sender, EventArgs e)
        {
        }

        private void brekarqarz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ob.table(datagridview14, "SELECT qarz.`qid` AS '#', qarz.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz.`dates`, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', customer.`types` AS 'جۆری بریکار' FROM `qarz`,customer where customer.cid=qarz.cid and qarz.cid='" + brekarqarz.SelectedValue.ToString() + "'");
                    ob.sum(label106, datagridview14, 1);
                }
                catch (Exception)
                {


                }
            }
        }

        private void materialSingleLineTextField9_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (materialSingleLineTextField9.Text != "")
                {
                    ob.table(datagridview14, "SELECT qarz.`qid` AS '#', qarz.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz.`dates`, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', customer.`types` AS 'جۆری بریکار' FROM `qarz`,customer where customer.cid=qarz.cid and qarz.`qid` like '" + materialSingleLineTextField9.Text + "%'");
                    ob.sum(label106, datagridview14, 1);
                }
                else
                {

                    ob.table(datagridview14, "SELECT qarz.`qid` AS '#', qarz.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz.`dates`, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', customer.`types` AS 'جۆری بریکار' FROM `qarz` join customer on(customer.`cid`=qarz.cid)");
                    ob.sum(label106, datagridview14, 1);
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            ob.table(datagridview14, "SELECT qarz.`qid` AS '#', qarz.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz.`dates`, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', customer.`types` AS 'جۆری بریکار' FROM `qarz`,customer where customer.cid=qarz.cid and qarz.cid='" + brekarqarz.SelectedValue.ToString() + "' and qarz.`dates` between '" + dateTimePicker3.Text + "' AND '" + dateTimePicker2.Text + "'");
            ob.sum(label106, datagridview14, 1);
        }

        private void companyaqarz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ob.table(datagridview15, "SELECT qarz_net_comp.`qncid` AS '#', qarz_net_comp.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.name AS 'کۆمپانیا' FROM `qarz_net_comp`,net_company where qarz_net_comp.ncid=net_company.ncid and qarz_net_comp.ncid='" + companyaqarz.SelectedValue.ToString() + "'");
                ob.sum(label113, datagridview15, 1);


            }
        }

        private void materialSingleLineTextField8_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField8.Text != "")
            {

                ob.table(datagridview15, "SELECT qarz_net_comp.`qncid` AS '#', qarz_net_comp.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.name AS 'کۆمپانیا' FROM `qarz_net_comp`,net_company where qarz_net_comp.ncid=net_company.ncid and qncid like '" + materialSingleLineTextField8.Text + "%'");
                ob.sum(label113, datagridview15, 1);
            }
            else
            {
                ob.table(datagridview15, "SELECT qarz_net_comp.qncid AS '#', qarz_net_comp.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.name AS 'کۆمپانیا' FROM `qarz_net_comp`,net_company where qarz_net_comp.ncid=net_company.ncid");
                ob.sum(label113, datagridview15, 1);

            }
        }

        private void pictureBox58_Click(object sender, EventArgs e)
        {
            ob.table(datagridview15, "SELECT qarz_net_comp.`qncid` AS '#', qarz_net_comp.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.name AS 'کۆمپانیا' FROM `qarz_net_comp`,net_company where qarz_net_comp.ncid=net_company.ncid and qarz_net_comp.`dates` between '" + dateTimePicker4.Text + "' and '" + dateTimePicker5.Text + "' ");
            ob.sum(label113, datagridview15, 1);
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview15);
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview14);
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>قەرزی بریکار</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview14, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label106.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>قەرزی فرۆشیاری ئامێر</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview15, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label113.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void datagridview14_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview14);
            ob.sum(label106, datagridview14, 1);
        }

        private void datagridview14_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview14);
            ob.sum(label106, datagridview14, 1);
        }

        private void datagridview15_FilterStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview15.DataSource;
            bindingSource1.Filter = this.datagridview15.FilterString;
            datagridview15.DataSource = bindingSource1.DataSource;
            ob.sum(label113, datagridview15, 1);
        }

        private void datagridview15_SortStringChanged(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = datagridview15.DataSource;
            bindingSource1.Sort = this.datagridview15.SortString;
            datagridview15.DataSource = bindingSource1.DataSource;
            ob.sum(label113, datagridview15, 1);
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("INSERT INTO `give_customer`(`qarzdinar`, `dateq`, `dates`, `cid`, `tebene`, `wasl`,ty) VALUES ('" + brqarzbrekar.Text + "','" + dateTimePicker67.Text + "','" + dateTimePicker6.Text + "','" + brekargive.SelectedValue.ToString() + "','" + textBox1.Text + "','" + waslgb.Text + "','کارت')");
            ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid");
            ob.sum(label118, datagridview16, 1);

            messageboxsuc obb = new messageboxsuc();
            obb.Show();
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + brekargive.Text + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cid='" + brekargive.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslgb.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");

            easyHTMLReports1.AddString("</tr>");


            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + textBox1.Text + "</td>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >$" + brqarzbrekar.Text + "</td>");

            easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + dateTimePicker6.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");


            con.Close();
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + brqarzbrekar.Text + "</td>");
            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("</table>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void datagridview16_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview16);
            ob.sum(label118, datagridview16, 1);
        }

        private void datagridview16_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview16);
            ob.sum(label118, datagridview16, 1);
        }

        private void datagridview16_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(datagridview16, brekargive, 4);
            ob.change_datagridview(datagridview16, textBox1, 6);

            ob.change_datagridview_textfild(datagridview16, waslgb, 5);
            ob.change_datagridview_textfild(datagridview16, brqarzbrekar, 1);
            ob.change_datagridview_picker(datagridview16, dateTimePicker6, 3);
            ob.change_datagridview_picker(datagridview16, dateTimePicker67, 2);
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridview16.SelectedRows.Count != 0)
                {
                    int i = datagridview16.SelectedRows[0].Index;
                    String id = datagridview16.Rows[i].Cells[0].Value.ToString();
                    ob.insert_del_up("UPDATE `give_customer` SET `qarzdinar`='" + brqarzbrekar.Text + "',dateq='" + dateTimePicker67.Text + "',`dates`='" + dateTimePicker6.Text + "',`cid`='" + brekargive.SelectedValue.ToString() + "',`tebene`='" + textBox1.Text + "',`wasl`='" + waslgb.Text + "',ty='کارت' WHERE qncid='" + id + "'");
                    ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid");
                    ob.sum(label118, datagridview16, 1);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                    easyHTMLReports1.Clear();
                    easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                    easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

                    easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddString("<h2>" + brekargive.Text + "</h2>");
                    con.Open();
                    MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cid='" + brekargive.SelectedValue.ToString() + "'", con);
                    MySqlDataReader rd = md.ExecuteReader();
                    while (rd.Read())
                    {
                        easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

                    }

                    con.Close();
                    easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
                    easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslgb.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
                    easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >Date</th>");
                    easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>amount</th>");

                    easyHTMLReports1.AddString("</tr>");


                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + textBox1.Text + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >" + dateTimePicker6.Text + "</td>");

                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>$" + brqarzbrekar.Text + "</td>");

                    easyHTMLReports1.AddString("</tr>");


                    con.Close();
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=2>Total:</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + brqarzbrekar.Text + "</td>");
                    easyHTMLReports1.AddString("</tr>");
                    easyHTMLReports1.AddString("</table>");

                    easyHTMLReports1.ShowPrintPreviewDialog();
                }
            }
            catch (Exception)
            {


            }
        }

        private void datagridview16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview16.SelectedRows.Count != 0)
                    {
                        int i = datagridview16.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview16.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from give_customer where qncid='" + id + "'");
                            ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid");
                            ob.sum(label118, datagridview16, 1);

                        }
                        else
                        {
                            ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid");
                            ob.sum(label118, datagridview16, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void materialSingleLineTextField15_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField15.Text != "")
            {
                ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە',DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid and customer.`cname` like '" + materialSingleLineTextField15.Text + "%'");
                ob.sum(label118, datagridview16, 1);
            }
            else
            {

                ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid");
                ob.sum(label118, datagridview16, 1);
            }
        }

        private void materialSingleLineTextField14_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField14.Text != "")
            {
                ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە',  DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid and give_customer.`qncid` like '" + materialSingleLineTextField14.Text + "%'");
                ob.sum(label118, datagridview16, 1);
            }
            else
            {
                ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid");
                ob.sum(label118, datagridview16, 1);

            }
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            ob.table(datagridview16, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.`dateq`, '%Y/%m/%d') AS 'بەرواری گەڕاندنەوە', DATE_FORMAT(give_customer.`dates`, '%Y/%m/%d') AS 'بەرواری تۆمارکردن', customer.`cname` AS 'بریکار', give_customer.`wasl` AS 'ژ.وەسڵ', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid and give_customer.`dates` between '" + dateTimePicker7.Text + "' and '" + dateTimePicker8.Text + "'");
            ob.sum(label118, datagridview16, 1);
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview16);
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'> گێڕانەوەی قەرزی بریکار</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview16, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label118.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("INSERT INTO `give_net_comp`(`qarzdinar`, `dates`, `ncid`, `tebene`, `wasl`) VALUES ('" + brqarzcom.Text + "','" + dateTimePicker11.Text + "','" + companyagive.SelectedValue.ToString() + "','" + textBox2.Text + "','" + waslfa.Text + "')");
            ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`wasl` AS 'ژ.وەسڵ', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid");
            ob.sum(label136, datagridview17, 1);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + companyagive.Text + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `net_company` where ncid='" + companyagive.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslfa.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");

            easyHTMLReports1.AddString("</tr>");


            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + textBox2.Text + "</td>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >$" + brqarzcom.Text + "</td>");

            easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + dateTimePicker11.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");


            con.Close();
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + brqarzcom.Text + "</td>");
            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("</table>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox56_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridview17.SelectedRows.Count != 0)
                {
                    int i = datagridview17.SelectedRows[0].Index;
                    String id = datagridview17.Rows[i].Cells[0].Value.ToString();
                    ob.insert_del_up("UPDATE `give_net_comp` SET `qarzdinar`='" + Convert.ToDouble(brqarzcom.Text) + "',`dates`='" + dateTimePicker11.Text + "',`ncid`='" + companyagive.SelectedValue.ToString() + "',`tebene`='" + textBox2.Text + "',wasl='" + waslfa.Text + "' WHERE `qncid`='" + id + "'");
                    ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`wasl` AS 'ژ.وەسڵ', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid");
                    ob.sum(label136, datagridview17, 1);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                    //easyHTMLReports1.Clear();
                    //easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                    //easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

                    //easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddString("<h2>" + companyagive.Text + "</h2>");
                    //con.Open();
                    //MySqlCommand md = new MySqlCommand("SELECT * FROM `net_company` where ncid='" + companyagive.SelectedValue.ToString() + "'", con);
                    //MySqlDataReader rd = md.ExecuteReader();
                    //while (rd.Read())
                    //{
                    //    easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

                    //}

                    //con.Close();
                    //easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
                    //easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslfa.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
                    //easyHTMLReports1.AddLineBreak();
                    //easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
                    //easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    //easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
                    //easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
                    //easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");

                    //easyHTMLReports1.AddString("</tr>");


                    //easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                    //easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + textBox2.Text + "</td>");
                    //easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >$" + brqarzcom.Text + "</td>");

                    //easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + dateTimePicker11.Text + "</td>");

                    //easyHTMLReports1.AddString("</tr>");


                    //con.Close();
                    //easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    //easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
                    //easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + brqarzcom.Text + "</td>");
                    //easyHTMLReports1.AddString("</tr>");
                    //easyHTMLReports1.AddString("</table>");

                    //easyHTMLReports1.ShowPrintPreviewDialog();
                }
            }
            catch (Exception)
            {


            }
        }

        private void datagridview17_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview17);
            ob.sum(label136, datagridview17, 1);
        }

        private void datagridview17_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview17);
            ob.sum(label136, datagridview17, 1);
        }

        private void datagridview17_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(datagridview17, companyagive, 3);
            ob.change_datagridview(datagridview17, textBox2, 5);
            ob.change_datagridviewl(datagridview17, waslfa, 4);
            ob.change_datagridview_textfild(datagridview17, brqarzcom, 1);
            ob.change_datagridview_picker(datagridview17, dateTimePicker11, 2);
        }

        private void pictureBox54_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview17);
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'> گێڕانەوەی قەرزی فرۆشیاری ئامێر</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview17, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label136.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void datagridview17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview17.SelectedRows.Count != 0)
                    {
                        int i = datagridview17.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview17.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from give_net_comp where qncid='" + id + "'");
                            ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', give_net_comp.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid");
                            ob.sum(label136, datagridview17, 1);

                        }
                        else
                        {
                            ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', give_net_comp.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid");
                            ob.sum(label136, datagridview17, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#',format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', give_net_comp.`wasl` AS 'ژ.وەسڵ', net_company.`name` AS 'بریکار', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid and give_net_comp.`dates` between '" + dateTimePicker9.Text + "' and '" + dateTimePicker10.Text + "'");
            ob.sum(label136, datagridview17, 1);
        }

        private void materialSingleLineTextField11_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField11.Text != "")
            {

                ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`wasl` AS 'ژ.وەسڵ', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid and net_company.`name` like '" + materialSingleLineTextField11.Text + "%'");
                ob.sum(label136, datagridview17, 1);
            }
            else
            {

                ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`wasl` AS 'ژ.وەسڵ', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid");
                ob.sum(label136, datagridview17, 1);
            }
        }

        private void materialSingleLineTextField10_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField10.Text != "")
            {

                ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`wasl` AS 'ژ.وەسڵ', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid and give_net_comp.`qncid` like '" + materialSingleLineTextField10.Text + "%'");
                ob.sum(label136, datagridview17, 1);
            }
            else
            {

                ob.table(datagridview17, "SELECT give_net_comp.`qncid` AS '#', format(give_net_comp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.`name` AS 'بریکار', give_net_comp.`wasl` AS 'ژ.وەسڵ', give_net_comp.`tebene` AS 'تێبینی' FROM `give_net_comp`,net_company where give_net_comp.ncid=net_company.ncid");
                ob.sum(label136, datagridview17, 1);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 16;
            ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` order by mid desc");
            ob.sum(label145, datagridview18, 1);
            ob.getsum(label504, "select difference as 'result' from st");
        }

        private void pictureBox65_Click(object sender, EventArgs e)
        {
            double br = 0;
            con.Open();
            MySqlDataReader rd = new MySqlCommand("select difference from st", con).ExecuteReader();
            while (rd.Read())
            {
                br = Convert.ToDouble(rd.GetString("difference"));
            }
            con.Close();
            if (Convert.ToDouble(materialSingleLineTextField34.Text) <= br)
            {
                ob.insert_del_up("INSERT INTO `masrufat`(`amount`, `zwasl`, `dates`, `comment`) VALUES ('" + materialSingleLineTextField34.Text + "','" + wasl.Text + "','" + dateTimePicker14.Text + "','" + textBox3.Text + "')");
                ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` order by mid desc");
                ob.sum(label145, datagridview18, 1);
                ob.getsum(label504, "select difference as 'result' from st");
                messageboxsuc obb = new messageboxsuc();
                obb.Show();
            }
            else
            {
                MessageBox.Show("...پارەی پێویست لە کۆگا نییە");
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            double brr = 0;
            con.Open();
            MySqlDataReader rd = new MySqlCommand("select difference from st", con).ExecuteReader();
            while (rd.Read())
            {
                brr = Convert.ToDouble(rd.GetString("difference"));
            }
            con.Close();
            try
            {
                if (datagridview18.SelectedRows.Count != 0)
                {
                    int i = datagridview18.SelectedRows[0].Index;
                    String id = datagridview18.Rows[i].Cells[0].Value.ToString();
                    String br = datagridview18.Rows[i].Cells[1].Value.ToString();
                    double nr = Convert.ToDouble(materialSingleLineTextField34.Text) - Convert.ToDouble(br);
                    if (nr < brr)
                    {

                        ob.insert_del_up("UPDATE `masrufat` SET `amount`='" + materialSingleLineTextField34.Text + "',`zwasl`='" + wasl.Text + "',`dates`='" + dateTimePicker14.Text + "',`comment`='" + textBox3.Text + "' WHERE `mid`='" + id + "'");

                        ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` order by mid desc");
                        ob.sum(label145, datagridview18, 1);
                        ob.getsum(label504, "select difference as 'result' from st");
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                    else
                    {
                        MessageBox.Show("...پارەی پێویست لە کۆگایا نییە");
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void datagridview18_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview18);
            ob.sum(label145, datagridview18, 1);
        }

        private void datagridview18_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview18);
            ob.sum(label145, datagridview18, 1);
        }

        private void datagridview18_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(datagridview18, materialSingleLineTextField34, 1);
            ob.change_datagridview_textfild(datagridview18, wasl, 2);
            ob.change_datagridview_picker(datagridview18, dateTimePicker14, 3);
            ob.change_datagridview(datagridview18, textBox3, 4);
        }

        private void datagridview18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview18.SelectedRows.Count != 0)
                    {
                        int i = datagridview18.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview18.Rows[i].Cells[0].Value.ToString());
                        String br = datagridview18.Rows[i].Cells[1].Value.ToString();
                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from masrufat where mid='" + id + "'");
                            ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` order by mid desc");
                            ob.sum(label145, datagridview18, 1);
                        }
                        else
                        {
                            ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` order by mid desc");
                            ob.sum(label145, datagridview18, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void materialSingleLineTextField12_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField12.Text != "")
            {
                ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` where `zwasl` like '" + materialSingleLineTextField12.Text + "%' order by mid desc");
                ob.sum(label145, datagridview18, 1);

            }
            else
            {
                ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` order by mid desc");
                ob.sum(label145, datagridview18, 1);

            }
        }

        private void pictureBox61_Click(object sender, EventArgs e)
        {
            ob.table(datagridview18, "SELECT `mid` AS '#', `amount` AS 'بڕی پارە', `zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', `comment` AS 'تێبینی' FROM `masrufat` where dates between '" + dateTimePicker12.Text + "' and '" + dateTimePicker13.Text + "'");
            ob.sum(label145, datagridview18, 1);
            ob.getsum(label504, "select difference as 'result' from st");
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview18);
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>مەسرەف</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview18, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label145.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void مەسرەفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 17;
            //ob.table(datagridview19, "SELECT masrufatwakel.`mwid` AS '#', sum(masrufatwakel.`amount`) AS 'بڕی پارە',DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d')  AS 'بەروار',customer.cname AS 'بریکار' FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid group by customer.cid");
            //ob.sum(label153, datagridview19, 1);

        }

        private void brekarmasraf_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void zhwasl_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox66_Click(object sender, EventArgs e)
        {

            ob.table(datagridview19, "SELECT masrufatwakel.`mwid` AS '#', sum(masrufatwakel.`amount`) AS 'بڕی پارە',DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d') AS 'بەروار',customer.cname AS 'بریکار' FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid and masrufatwakel.dates between '" + dateTimePicker15.Text + "' and '" + dateTimePicker16.Text + "' group by customer.cid");
            ob.sum(label153, datagridview19, 1);

        }

        private void pictureBox67_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview19);
        }

        private void pictureBox68_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>مەسرەفی وەکیل</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview19, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label153.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("INSERT INTO `balance_hato`(`num`, `dates`, `bid`, `tebene`,price) VALUES ('" + numkart.Text + "','" + dateTimePicker19.Text + "','" + kart.SelectedValue.ToString() + "','" + textBox8.Text + "','0')");
            ob.insert_del_up("call insert_storage_kart('" + kart.SelectedValue.ToString() + "','" + numkart.Text + "','" + dateTimePicker19.Text + "')");
            ob.table(datagridview20, "SELECT balance_hato.`bhid` AS '#', balance_hato.`num` AS 'عەدەد',DATE_FORMAT(DATE_FORMAT(balance_hato.`dates`, '%Y/%m/%d'), '%Y/%m/%d')  AS 'بەروار', balance.`types` AS 'کارت', balance_hato.`tebene` AS 'تێبینی'  FROM `balance_hato`,balance where balance_hato.bid=balance.bid");
            ob.count(label159, datagridview20, 0);


            messageboxsuc obb = new messageboxsuc();
            obb.Show();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 18;
            ob.comb(kart, "SELECT * FROM balance", "bid", "types");
            ob.table(datagridview20, "SELECT balance_hato.`bhid` AS '#', balance_hato.`num` AS 'عەدەد', DATE_FORMAT(DATE_FORMAT(balance_hato.`dates`, '%Y/%m/%d'), '%Y/%m/%d') AS 'بەروار', balance.`types` AS 'کارت', balance_hato.`tebene` AS 'تێبینی'  FROM `balance_hato`,balance where balance_hato.bid=balance.bid");
            ob.count(label159, datagridview20, 0);
        }

        private void datagridview20_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview20);
            ob.count(label159, datagridview20, 0);
        }

        private void datagridview20_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview20);
            ob.count(label159, datagridview20, 0);
        }

        private void datagridview20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview20.SelectedRows.Count != 0)
                    {
                        int i = datagridview20.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview20.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from balance_hato where bhid='" + id + "'");
                            ob.insert_del_up("call delete_storage_kart('" + kart.SelectedValue.ToString() + "','" + numkart.Text + "')");
                            ob.table(datagridview20, "SELECT balance_hato.`bhid` AS '#', balance_hato.`num` AS 'عەدەد', DATE_FORMAT(DATE_FORMAT(balance_hato.`dates`, '%Y/%m/%d'), '%Y/%m/%d') AS 'بەروار', balance.`types` AS 'کارت', balance_hato.`tebene` AS 'تێبینی'  FROM `balance_hato`,balance where balance_hato.bid=balance.bid");
                            ob.count(label159, datagridview20, 0);

                        }
                        else
                        {
                            ob.table(datagridview20, "SELECT balance_hato.`bhid` AS '#', balance_hato.`num` AS 'عەدەد', DATE_FORMAT(balance_hato.`dates`, '%Y/%m/%d') AS 'بەروار', balance.`types` AS 'کارت', balance_hato.`tebene` AS 'تێبینی'  FROM `balance_hato`,balance where balance_hato.bid=balance.bid");
                            ob.count(label159, datagridview20, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview20);
        }

        private void pictureBox72_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارتی هاتوو</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview20, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label159.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox70_Click(object sender, EventArgs e)
        {
            ob.table(datagridview20, "SELECT balance_hato.`bhid` AS '#', balance_hato.`num` AS 'عەدەد', DATE_FORMAT(balance_hato.`dates`, '%Y/%m/%d') AS 'بەروار', balance.`types` AS 'کارت', balance_hato.`tebene` AS 'تێبینی' FROM `balance_hato`,balance where balance_hato.bid=balance.bid and balance_hato.dates between '" + dateTimePicker17.Text + "' and '" + dateTimePicker18.Text + "'");
            ob.count(label159, datagridview20, 0);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 35;

            //     ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', `barwar` as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view`");
            ob.table(data37, "SELECT `id` as '#', sum(`adad`) as 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') as 'بەروار',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` group by wasl");
            ob.sum(label372, data37, 1);
        }

        private void datagridview21_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (datagridview21.SelectedRows.Count != 0)
                {
                    int i = datagridview21.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridview21.Rows[i].Cells[0].Value.ToString());

                    String stat = datagridview21.Rows[i].Cells[5].Value.ToString();
                    if (stat != "قبوڵکراو")
                    {

                        if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            con.Open();
                            MySqlCommand mss = new MySqlCommand("SELECT * FROM `dawakary_balance` WHERE `id`='" + id + "'", con);
                            MySqlDataReader rd = mss.ExecuteReader();
                            String adad = "";
                            String kart = "";
                            String cus = "";
                            String wasl = "";
                            String dates = "";
                            while (rd.Read())
                            {
                                adad = rd.GetString("adad");
                                kart = rd.GetString("kart");
                                cus = rd.GetString("cus");
                                wasl = rd.GetString("wasl");
                                dates = rd.GetString("barwar");

                            }
                            con.Close();
                            String numk = "";
                            con.Open();
                            MySqlCommand mddd = new MySqlCommand("SELECT Coalesce(sum(`number`),0) as num FROM `storage_kart` where kid='" + kart + "'", con);
                            MySqlDataReader rddd = mddd.ExecuteReader();
                            while (rddd.Read())
                            {
                                numk = rddd.GetString("num");
                            }
                            con.Close();

                            if (Convert.ToDouble(adad) > Convert.ToDouble(numk))
                            {
                                MessageBox.Show("بڕی کارتی پێویست لە کۆگایا نییە");
                            }
                            else
                            {
                                ob.insert_del_up("UPDATE `dawakary_balance` SET `state`='قبوڵکراو' WHERE `id`='" + id + "'");
                                ob.insert_del_up("INSERT INTO `balance_roshto`(`num`, `dates`, `bid`, `cid`, `wasl`,tebene)  VALUES ('" + adad + "','" + dateTimePicker63.Text + "','" + kart + "','" + cus + "','" + wasl + "','')");
                                ob.insert_del_up("call delete_storage_kart('" + kart + "','" + adad + "')");
                                ob.insert_del_up("call insert_storage_kart_customer('" + kart + "','" + adad + "','" + cus + "','" + dateTimePicker63.Text + "')");
                                ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl='" + wasldk + "'");
                                ob.sum(label167, datagridview21, 2);
                            }
                        }
                        else
                        {
                            ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl='" + wasldk + "'");

                            ob.sum(label167, datagridview21, 2);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

        }

        private void datagridview21_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview21);
            ob.count(label167, datagridview21, 0);
        }

        private void datagridview21_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview21);
            ob.count(label167, datagridview21, 0);
        }

        private void materialSingleLineTextField16_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField17_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField13_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox73_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview21);
        }

        private void pictureBox74_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + datagridview21.Rows[0].Cells[6].Value.ToString() + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cname='" + datagridview21.Rows[0].Cells[6].Value.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارتی داواکراو</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + datagridview21.Rows[0].Cells[7].Value.ToString() + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br> Salesperson  " + Form1.us + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%; dir:ltr;'>");

            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>حاڵەت</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>تێبینی</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>بەروار</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>عەدەد</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >کارت</th>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>#</th>");





            easyHTMLReports1.AddString("</tr>");
            double sm = 0;
            for (int i = 0; i < datagridview21.Rows.Count - 1; i++)
            {

                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview21.Rows[i].Cells[5].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >" + datagridview21.Rows[i].Cells[4].Value.ToString() + "</td>");

                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview21.Rows[i].Cells[3].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview21.Rows[i].Cells[2].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview21.Rows[i].Cells[1].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + (i + 1) + "</td>");

                easyHTMLReports1.AddString("</tr>");
                sm = sm + Convert.ToDouble(datagridview21.Rows[i].Cells[2].Value.ToString());

            }
            easyHTMLReports1.AddString("</table>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label167.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {


        }
        public static String karti = "";
        private void datagridview20_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(datagridview20, numkart, 1);
            ob.change_datagridview_combo(datagridview20, kart, 3);
            ob.change_datagridview_picker(datagridview20, dateTimePicker19, 2);
            ob.change_datagridview(datagridview20, textBox8, 4);
            karti = kart.SelectedValue.ToString();
        }

        private void datagridview22_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void datagridview22_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview22);
            ob.sum(label174, datagridview22, 2);
        }

        private void datagridview22_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview22);
            ob.sum(label174, datagridview22, 2);
        }

        private void pictureBox75_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview22);

        }

        private void materialSingleLineTextField19_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField19.Text != "")
            {

                ob.table(datagridview22, "SELECT `id` AS '#', `kartn` AS 'کارت', `number` AS 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار' FROM `storage_kart_view` where `kartn` like '%" + materialSingleLineTextField19.Text + "%'");
                ob.sum(label174, datagridview22, 2);

            }
            else
            {

                ob.table(datagridview22, "SELECT `id` AS '#', `kartn` AS 'کارت', `number` AS 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار' FROM `storage_kart_view`");
                ob.sum(label174, datagridview22, 2);
            }
        }

        private void materialSingleLineTextField18_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField18.Text != "")
            {

                ob.table(datagridview22, "SELECT `id` AS '#', `kartn` AS 'کارت', `number` AS 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار' FROM `storage_kart_view` where `id` like '" + materialSingleLineTextField18.Text + "'");
                ob.sum(label174, datagridview22, 2);

            }
            else
            {

                ob.table(datagridview22, "SELECT `id` AS '#', `kartn` AS 'کارت', `number` AS 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار' FROM `storage_kart_view`");
                ob.sum(label174, datagridview22, 2);
            }
        }

        private void pictureBox76_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کۆگای کارت</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview22, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label174.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 21;
            ob.comb(brekar, "SELECT * FROM customer", "cid", "cname");
            ob.comb(balance, "SELECT * FROM balance", "bid", "types");

            ob.table(datagridview23, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `bid` AS 'کارت', `cid` AS 'بریکار', `wasl` AS 'ژ.وەسڵ',tebene as 'تێبینی' FROM `balance_roshtu_view` ");
            ob.sum(label177, datagridview23, 2);
            ob.sum(label173, datagridview23, 3);
        }

        private void priceb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (priceb.Text != "" && numberb.Text != "")
                {
                    sumpb.Text = (Convert.ToDouble(priceb.Text) * Convert.ToDouble(numberb.Text)).ToString();

                }
                else
                {

                    sumpb.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void numberb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (priceb.Text != "" && numberb.Text != "")
                {
                    sumpb.Text = (Convert.ToDouble(priceb.Text) * Convert.ToDouble(numberb.Text)).ToString();

                }
                else
                {

                    sumpb.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void sumpb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (sumpb.Text != "")
                {

                    sumpdb.Text = (Convert.ToDouble(sumpb.Text) / online.draw.dolar).ToString();
                }
                else
                {
                    sumpdb.Text = "0";

                }
                if (moneyb.Text != "" && sumpb.Text != "")
                {

                    qarzb.Text = (Convert.ToDouble(sumpb.Text) - Convert.ToDouble(moneyb.Text)).ToString();
                }
                else
                {
                    qarzb.Text = "0";
                }

            }
            catch (Exception)
            {

            }
        }

        private void moneyb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (moneyb.Text != "" || sumpdb.Text != "")
                {

                    qarzb.Text = (Convert.ToDouble(sumpdb.Text) - Convert.ToDouble(moneyb.Text)).ToString();
                }
                else
                {
                    qarzb.Text = "0";
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox79_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (datagridview23.SelectedRows.Count != 0)
            //    {
            //        int i = datagridview23.SelectedRows[0].Index;
            //        int id = Convert.ToInt32(datagridview23.Rows[i].Cells[0].Value.ToString());
            //        double zhmara = Convert.ToDouble(datagridview23.Rows[i].Cells[2].Value.ToString());
            //        double nrx = Convert.ToDouble(datagridview23.Rows[i].Cells[3].Value.ToString());

            //        con.Open();

            //        MySqlCommand md = new MySqlCommand("SELECT * FROM `storage_kart` WHERE kid='" + balance.SelectedValue.ToString() + "'", con);
            //        MySqlDataReader rd = md.ExecuteReader();
            //        int n = 0;
            //        int num = Convert.ToInt16(numberf.Text);
            //        while (rd.Read())
            //        {

            //            n = rd.GetInt16("number");
            //        }
            //        con.Close();
            //        if (n < num)
            //        {
            //            MessageBox.Show("بڕی ئامێری پێویست لە کۆگایا نییە");
            //        }
            //        else
            //        {
            //            ob.insert_del_up("UPDATE `balance_roshto` SET `price`='" + priceb.Text + "',`num`='" + numberb.Text + "',`sump`='" + sumpb.Text + "',`money`='" + moneyb.Text + "',`qarz`='" + qarzb.Text + "',`dates`='" + barwarb.Text + "',`bid`='" + balance.SelectedValue.ToString() + "',`cid`='" + brekar.SelectedValue.ToString() + "',`wasl`='" + waslkart.Text + "',`tebene`='" + textBox9.Text + "' WHERE `brid`='" + id + "'");
            //            if (zhmara == 0)
            //            {
            //                ob.insert_del_up("call delete_storage_kart('" + balance.SelectedValue.ToString() + "','" + numberb.Text + "')");
            //            }
            //            else
            //            {
            //                double ad = Convert.ToDouble(numberb.Text) - zhmara;
            //                double nr = Convert.ToDouble(sumpb.Text) - nrx;
            //                ob.insert_del_up("call delete_storage_kart('" + balance.SelectedValue.ToString() + "','" + ad + "')");

            //            }
            //            if (qarzb.Text != "" && qarzb.Text != "0")
            //            {

            //                double res = (Convert.ToDouble(qarzb.Text) / draw.dolar);
            //                ob.insert_del_up("call insert_qarz_customer_balance('" + res + "','" + barwarb.Text + "','" + brekar.SelectedValue.ToString() + "',(select max(brid) from `balance_roshto`))");
            //            }

            //            else
            //            {

            //                ob.insert_del_up("UPDATE `qarz` SET `qarzdinar`='" + qarzb.Text + "' WHERE `id_balance_roshtu`='" + id + "'");


            //            }
            //            //ob.sum(label177, datagridview23, 2);
            //            //ob.sum(label173, datagridview23, 3);
            //            //ob.a(this.Controls);

            //            messageboxsuc obb = new messageboxsuc();
            //            obb.Show();

            //        }
            //    }
            //    else
            //    {

            //        con.Open();

            //        MySqlCommand md = new MySqlCommand("SELECT * FROM `storage_kart` WHERE kid='" + balance.SelectedValue.ToString() + "'", con);
            //        MySqlDataReader rd = md.ExecuteReader();
            //        int n = 0;
            //        int num = Convert.ToInt16(numberf.Text);
            //        while (rd.Read())
            //        {

            //            n = rd.GetInt16("number");
            //        }
            //        con.Close();
            //        if (n < num)
            //        {
            //            MessageBox.Show("بڕی ئامێری پێویست لە کۆگایا نییە");
            //        }
            //        else
            //        {
            //            ob.insert_del_up("INSERT INTO `balance_roshto`(`price`, `num`, `sump`, `money`, `qarz`, `dates`, `bid`, `cid`, `wasl`, `tebene`) VALUES ('" + priceb.Text + "','" + numberb.Text + "','" + sumpb.Text + "','" + moneyb.Text + "','" + qarzb.Text + "','" + barwarb.Text + "','" + balance.SelectedValue.ToString() + "','" + brekar.SelectedValue.ToString() + "','" + waslkart.Text + "','"+textBox9.Text+"')");

            //            ob.insert_del_up("call delete_storage_kart('" + balance.SelectedValue.ToString() + "','" + numberb.Text + "')");

            //            double res = (Convert.ToDouble(qarzb.Text) / draw.dolar);
            //            ob.insert_del_up("call insert_qarz_customer_balance('" + res+ "','" + barwarb.Text + "','" + brekar.SelectedValue.ToString() + "',(select max(brid) from `balance_roshto`))");

            //            ob.table(datagridview23, "SELECT `brid` AS '#', `price` AS 'نرخ', `num` AS 'عەدەد', `sump` AS 'کۆی نرخ', `money` AS 'پارەی وەرگیراو', `qarz` AS 'قەرز', `dates` AS 'بەروار', `bid` AS 'کارت', `cid` AS 'بریکار', `wasl` AS 'ژ.وەسڵ', `tebene` AS 'تێبینی' FROM `balance_roshtu_view` ");
            //            ob.sum(label177, datagridview23, 2);
            //            ob.sum(label173, datagridview23, 3);
            //            ob.a(this.Controls);

            //            messageboxsuc obb = new messageboxsuc();
            //            obb.Show();

            //        }


            //    }
            //}
            //catch (Exception )
            //{

            //}

        }

        private void datagridview23_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview23);
            ob.sum(label177, datagridview23, 2);
            ob.sum(label173, datagridview23, 3);
        }

        private void datagridview23_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview23);
            ob.sum(label177, datagridview23, 2);
            ob.sum(label173, datagridview23, 3);
        }

        private void datagridview23_KeyDown(object sender, KeyEventArgs e)
        {
            ////if (e.KeyCode == Keys.Delete)
            ////{
            ////    //try
            ////    //{
            ////        if (datagridview23.SelectedRows.Count != 0)
            ////        {
            ////            int i = datagridview23.SelectedRows[0].Index;
            ////            int id = Convert.ToInt32(datagridview23.Rows[i].Cells[0].Value.ToString());
            ////            int aid = Convert.ToInt32(datagridview23.Rows[i].Cells[1].Value.ToString());
            ////            int num = Convert.ToInt32(datagridview23.Rows[i].Cells[2].Value.ToString());
            ////            double pric = Convert.ToDouble(datagridview23.Rows[i].Cells[3].Value.ToString());
            ////            if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
            ////            {
            ////                ob.insert_del_up("DELETE FROM `qarz` WHERE `id_balance_roshtu`='" + id + "'");
            ////                ob.insert_del_up("DELETE FROM `balance_roshto` WHERE brid='"+id+"'");
            ////                ob.insert_del_up("call insert_storage_kart('" + balance.SelectedValue.ToString() + "','" + num + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "')");

            ////                //ob.table(datagridview23, "SELECT `brid` AS '#', `price` AS 'نرخ', `num` AS 'عەدەد', `sump` AS 'کۆی نرخ', `money` AS 'پارەی وەرگیراو', `qarz` AS 'قەرز', `dates` AS 'بەروار', `bid` AS 'کارت', `cid` AS 'بریکار', `wasl` AS 'ژ.وەسڵ' FROM `balance_roshtu_view` ");
            ////                //ob.sum(label177, datagridview23, 2);
            ////                //ob.sum(label173, datagridview23, 3);

            ////            }
            ////            else
            ////            {
            ////                //ob.table(datagridview23, "SELECT `brid` AS '#', `price` AS 'نرخ', `num` AS 'عەدەد', `sump` AS 'کۆی نرخ', `money` AS 'پارەی وەرگیراو', `qarz` AS 'قەرز', `dates` AS 'بەروار', `bid` AS 'کارت', `cid` AS 'بریکار' FROM `balance_roshtu_view` ");
            ////                //ob.sum(label177, datagridview23, 2);
            ////                //ob.sum(label173, datagridview23, 3);
            ////            }
            ////        }
            ////    //}
            ////    //catch (Exception)
            ////    //{


            ////    //}
            ////}
        }

        private void datagridview23_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (datagridview23.SelectedRows.Count != 0)
                {
                    int i = datagridview23.SelectedRows[0].Index;
                    brekar.Text = datagridview23.Rows[i].Cells[8].Value.ToString();
                    balance.Text = datagridview23.Rows[i].Cells[7].Value.ToString();
                    priceb.Text = datagridview23.Rows[i].Cells[1].Value.ToString();
                    numberb.Text = datagridview23.Rows[i].Cells[2].Value.ToString();
                    sumpb.Text = datagridview23.Rows[i].Cells[3].Value.ToString();
                    moneyb.Text = datagridview23.Rows[i].Cells[4].Value.ToString();
                    qarzb.Text = datagridview23.Rows[i].Cells[5].Value.ToString();
                    barwarb.Text = datagridview23.Rows[i].Cells[6].Value.ToString();
                    waslkart.Text = datagridview23.Rows[i].Cells[7].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox77_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview23);
        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارتی فۆرشراو</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridview23, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label177.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label173.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void datagridview19_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridview19);
            ob.sum(label153, datagridview19, 1);
        }

        private void datagridview19_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridview19);
            ob.sum(label153, datagridview19, 1);
        }

        private void dataGridView4_SelectionChanged_1(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(dataGridView4, naw, 1);
            ob.change_datagridview_textfild(dataGridView4, zh, 2);
            ob.change_datagridview_combo(dataGridView4, metroComboBox1, 3);
            ob.change_datagridview_textfild(dataGridView4, ad, 4);
            ob.change_datagridview_combo(dataGridView4, jorebrekar, 5);
            ob.change_datagridview_textfild(dataGridView4, username, 6);
            ob.change_datagridview_textfild(dataGridView4, password, 7);
            if (dataGridView4.SelectedRows.Count != 0)
            {

                int i = dataGridView4.SelectedRows[0].Index;
                String cus_main = dataGridView4.Rows[i].Cells[8].Value.ToString();
                if (cus_main == "نییە")
                {
                    checkBox4.Checked = false;
                }
                else
                {
                    checkBox4.Checked = true;
                    comboBox6.Text = cus_main;
                }
            }
        }

        private void ڕاپۆرتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 22;
            ob.comb(comboBox1, "SELECT * FROM customer", "cid", "cname");
        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {

            ob.table(datar2, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `bid` AS 'کارت' FROM `balance_roshtu_view` where cc='" + comboBox1.SelectedValue.ToString() + "' and dates between '" + dr1.Text + "' and '" + dr2.Text + "'");
            ob.sum(label201, datar2, 1);

            ob.table(datar3, "SELECT `brid` AS '#', `num` AS 'عەدەد', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', balance.types AS 'جۆری کارت',sumprice AS 'کۆی نرخ' FROM `froshtn_kart`,balance WHERE froshtn_kart.bid=balance.bid and cid='" + comboBox1.SelectedValue.ToString() + "' and dates between '" + dr1.Text + "' and '" + dr2.Text + "'");
            ob.sum(label205, datar3, 1);
            ob.sum(label211, datar3, 4);

            ob.table(datr5, "SELECT give_customer.`qncid` AS '#', give_customer.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_customer.dates, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', give_customer.`tebene` AS 'تێبینی' FROM `give_customer`,customer where give_customer.cid=customer.cid and give_customer.cid='" + comboBox1.SelectedValue.ToString() + "' and dates between '" + dr1.Text + "' and '" + dr2.Text + "'");
            ob.sum(label209, datr5, 1);
            ob.table(datr6, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(masrufatwakel.dates, '%Y/%m/%d') AS 'بەروار',customer.cname AS 'بریکار', masrufatwakel.`comment` AS 'تێبینی' FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid and masrufatwakel.cid='" + comboBox1.SelectedValue.ToString() + "' and dates between '" + dr1.Text + "' and '" + dr2.Text + "'");
            ob.sum(label213, datr6, 1);

            double res = Convert.ToDouble(label211.Text) - Convert.ToDouble(label213.Text);
            label484.Text = (res - Convert.ToDouble(label209.Text)).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label193.Text = DateTime.Now.ToString();
            label429.Text = DateTime.Now.ToString();
        }

        private void pictureBox81_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + brekar.Text + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cid='" + comboBox1.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ڕاپۆرتی کۆتای</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + dr1.Text + " - " + dr2.Text + "</p>");
            easyHTMLReports1.AddLineBreak();


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datar1, "style='width:100%; direction:rtl;'");

            easyHTMLReports1.AddLineBreak();

            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right'>" + label202.Text + "</p>");
            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right;margin-right:50px;'>" + label201.Text + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datar2, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();

            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right'>" + label206.Text + "</p>");
            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right;margin-right:50px;'>" + label205.Text + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datar3, "style='width:100%; direction:rtl;'");

            easyHTMLReports1.AddLineBreak();

            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right'>" + label207.Text + "</p>");
            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right;margin-right:50px;'>" + label211.Text + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datr4, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();

            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right'>" + label210.Text + "</p>");
            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right;margin-right:50px;'>" + label209.Text + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datr5, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();

            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right'>" + label212.Text + "</p>");
            easyHTMLReports1.AddString("<p style='text-align: right; display:inline; float:right;margin-right:50px;'>" + label213.Text + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datr6, "style='width:100%; direction:rtl;'");

            easyHTMLReports1.Print();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 23;
            ob.comb(com, "SELECT * FROM ispcompany", "ic", "name");
            ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', format(`price`,2) AS 'نرخ', format(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic order by mbid desc");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT `nomb` FROM `mb_store`", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                label319.Text = rd.GetString("nomb");

            }

            con.Close();

            ob.sum(label215, datagridbmp, 1);
            ob.sum(label204, datagridbmp, 3);
        }

        private void pictureBox84_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int days = DateTime.DaysInMonth(barwarst.Value.Year, barwarst.Value.Month);
                DateTime start = Convert.ToDateTime(barwarst.Text);
                DateTime finish = Convert.ToDateTime(barwarmbp.Text);
                TimeSpan difference = finish.Subtract(start);
                double sumnrx = 0;
                double nr = 0;
                if (checkBox1.Checked == true)
                {
                    nr = Convert.ToDouble(nrxmbp.Text) / dolar;
                    sumnrx = Convert.ToDouble(adadmbp.Text) * nr;
                }
                else
                {
                    sumnrx = Convert.ToDouble(adadmbp.Text) * Convert.ToDouble(nrxmbp.Text);
                }
                int dif = Convert.ToInt16(difference.Days) + 1;
                if (days != dif)
                {
                    double m = sumnrx / days;
                    sumnrx = m * dif;

                }

                if (checkBox1.Checked == true)
                {

                    ob.insert_del_up("INSERT INTO `mb_buy`(`nomb`, `price`,`sump`, `dates1`, `dates`, `ic`, `wasl`, `tebene`) VALUES ('" + adadmbp.Text + "','" + nr.ToString() + "','" + sumnrx + "','" + barwarst.Text + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "','" + waslb.Text + "','" + textBox5.Text + "')");

                }
                else
                {
                    ob.insert_del_up("INSERT INTO `mb_buy`(`nomb`, `price`,`sump`, `dates1`, `dates`, `ic`, `wasl`, `tebene`) VALUES ('" + adadmbp.Text + "','" + nrxmbp.Text + "','" + sumnrx + "','" + barwarst.Text + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "','" + waslb.Text + "','" + textBox5.Text + "')");

                }
                ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`+'" + adadmbp.Text + "'");
                if (qarzmbp.Checked == true)
                {

                    ob.insert_del_up("INSERT INTO `qarz_isp_comp`(`qarzdinar`, `dates`, `ic`,`mbp`) VALUES ('" + sumnrx + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "',(select max(mbid) as id from mb_buy))");
                    ob.insert_del_up("INSERT INTO `hesab_isp`(`br`, `barwar`, `cid`,`qarzid`) VALUES ('" + sumnrx + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "',(select max(mbid) as id from mb_buy))");

                }

                ob.a(this.Controls);
                ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', format(`price`,2) AS 'نرخ', format(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic order by mbid desc");
                ob.sum(label215, datagridbmp, 1);
                ob.sum(label204, datagridbmp, 3);
                con.Open();
                MySqlCommand md = new MySqlCommand("SELECT `nomb` FROM `mb_store`", con);
                MySqlDataReader rd = md.ExecuteReader();
                while (rd.Read())
                {
                    label319.Text = rd.GetString("nomb");

                }

                con.Close();

            }
        }

        private void datagridbmp_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridbmp);
            ob.sum(label215, datagridbmp, 1);
            ob.sum(label204, datagridbmp, 3);
        }

        private void datagridbmp_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridbmp);
            ob.sum(label215, datagridbmp, 1);
            ob.sum(label204, datagridbmp, 3);
        }

        private void datagridbmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridbmp.SelectedRows.Count != 0)
                    {
                        int i = datagridbmp.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridbmp.Rows[i].Cells[0].Value.ToString());
                        double adad = Convert.ToDouble(datagridbmp.Rows[i].Cells[1].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `hesab_isp` WHERE qarzid='" + id + "'");
                            ob.insert_del_up("DELETE FROM `qarz_isp_comp` WHERE mbp='" + id + "'");
                            ob.insert_del_up("DELETE FROM `mb_buy` WHERE `mbid`='" + id + "'");
                            ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`-'" + adad + "'");
                            ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', format(`price`,2) AS 'نرخ', format(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic order by mbid desc");
                            ob.sum(label215, datagridbmp, 1);
                            ob.sum(label204, datagridbmp, 2);
                            con.Open();
                            MySqlCommand md = new MySqlCommand("SELECT `nomb` FROM `mb_store`", con);
                            MySqlDataReader rd = md.ExecuteReader();
                            while (rd.Read())
                            {
                                label319.Text = rd.GetString("nomb");

                            }

                            con.Close();
                        }
                        else
                        {
                            ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', format(`price`,2) AS 'نرخ', `types` AS 'جۆر', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic");
                            ob.sum(label215, datagridbmp, 1);
                            ob.sum(label204, datagridbmp, 2);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox82_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridbmp);
        }

        private void pictureBox83_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>Buy megabytes</h2>");

            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Invoice</i></h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>#</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >number</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>price</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>sum price</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>From Date</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>To Date</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>ISP</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Invoice Number</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Note</th>");
            easyHTMLReports1.AddString("</tr>");
            double sm = 0;
            for (int i = 0; i < datagridbmp.Rows.Count - 1; i++)
            {

                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[0].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >" + datagridbmp.Rows[i].Cells[1].Value.ToString() + "</td>");

                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>$" + datagridbmp.Rows[i].Cells[2].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>$" + datagridbmp.Rows[i].Cells[3].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[4].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[5].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[6].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[7].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[8].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("</tr>");
                sm = sm + Convert.ToDouble(datagridbmp.Rows[i].Cells[3].Value.ToString());

            }
            easyHTMLReports1.AddString("</table>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>$" + label204.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Total:</p>");


            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void قەرزەکانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 24;
            ob.comb(ispqarz, "SELECT * FROM ispcompany", "ic", "name");
            ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic");
            ob.sum(label228, ispdataqarz, 1);
        }

        private void ispqarz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic and qarz_isp_comp.ic='" + ispqarz.SelectedValue.ToString() + "'");
                    ob.sum(label228, ispdataqarz, 1);
                }
                catch (Exception)
                {


                }
            }
        }

        private void materialSingleLineTextField20_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (materialSingleLineTextField20.Text != "")
                {

                    ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic and qarz_isp_comp.ic like'" + materialSingleLineTextField20.Text + "%'");
                    ob.sum(label228, ispdataqarz, 1);
                }
                else
                {

                    ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic");
                    ob.sum(label228, ispdataqarz, 1);
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox85_Click(object sender, EventArgs e)
        {
            ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic and dates between '" + dateTimePicker20.Text + "' and '" + dateTimePicker21.Text + "'");
            ob.sum(label228, ispdataqarz, 1);
        }

        private void pictureBox86_Click(object sender, EventArgs e)
        {
            ob.toexcel(ispdataqarz);
        }

        private void pictureBox87_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>قەرزی isp</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(ispdataqarz, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label228.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void ispdataqarz_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(ispdataqarz);
            ob.sum(label228, ispdataqarz, 1);
        }

        private void ispdataqarz_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(ispdataqarz);
            ob.sum(label228, ispdataqarz, 1);
        }

        private void گێڕانەوەیقەرزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 25;
            ob.comb(comboBox2, "SELECT * FROM ispcompany", "ic", "name");
            waslisp.Text = DateTime.Now.ToString("yyyyMMdd") + comboBox2.SelectedValue.ToString();
            ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای', give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic");
            ob.sum(label239, givemoneisp, 1);

        }

        private void pictureBox92_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ob.insert_del_up("INSERT INTO `give_isp`(`qarzdinar`, `dates`, `cid`, `tebene`,wasl,wasl2) VALUES ('" + brispgive.Text + "','" + barwarispgive.Text + "','" + comboBox2.SelectedValue.ToString() + "','" + noteispgive.Text + "','" + waslisp.Text + "','" + materialSingleLineTextField54.Text + "')");
                ob.insert_del_up("INSERT INTO `hesab_isp`(`br`, `barwar`, `cid`,`giveid`) VALUES ('" + brispgive.Text + "','" + barwarispgive.Text + "','" + comboBox2.SelectedValue.ToString() + "',(select max(qncid) as id from give_isp))");

                ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای', give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic");
                ob.sum(label239, givemoneisp, 1);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();
                easyHTMLReports1.Clear();
                easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

                easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<h2>" + comboBox2.Text + "</h2>");
                con.Open();
                MySqlCommand md = new MySqlCommand("SELECT * FROM `ispcompany` where ic='" + comboBox2.SelectedValue.ToString() + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                while (rd.Read())
                {
                    easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

                }

                con.Close();
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslisp.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");

                easyHTMLReports1.AddString("</tr>");


                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + noteispgive.Text + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >$" + brispgive.Text + "</td>");

                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + barwarispgive.Text + "</td>");

                easyHTMLReports1.AddString("</tr>");


                con.Close();
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + brispgive.Text + "</td>");
                easyHTMLReports1.AddString("</tr>");
                easyHTMLReports1.AddString("</table>");

                easyHTMLReports1.ShowPrintPreviewDialog();
                ob.a(this.Controls);
            }

        }

        private void givemoneisp_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(givemoneisp);
            ob.sum(label239, givemoneisp, 1);
        }

        private void givemoneisp_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(givemoneisp);
            ob.sum(label239, givemoneisp, 1);
        }

        private void givemoneisp_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(givemoneisp, brispgive, 1);
            ob.change_datagridview_combo(givemoneisp, comboBox2, 3);
            ob.change_datagridview_picker(givemoneisp, barwarispgive, 2);
            ob.change_datagridview(givemoneisp, noteispgive, 6);
            ob.change_datagridviewl(givemoneisp, waslisp, 4);
            ob.change_datagridview_textfild(givemoneisp, materialSingleLineTextField54, 5);
        }

        private void pictureBox91_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //try
                //{
                if (givemoneisp.SelectedRows.Count != 0)
                {
                    int i = givemoneisp.SelectedRows[0].Index;
                    String id = givemoneisp.Rows[i].Cells[0].Value.ToString();
                    ob.insert_del_up("UPDATE `give_isp` SET `qarzdinar`='" + Convert.ToDouble(brispgive.Text) + "',`dates`='" + barwarispgive.Text + "',`cid`='" + comboBox2.SelectedValue.ToString() + "',`tebene`='" + noteispgive.Text + "',wasl='" + waslisp.Text + "',wasl2='" + materialSingleLineTextField54.Text + "' WHERE `qncid`='" + id + "'");
                    ob.insert_del_up("UPDATE `hesab_isp` SET `br`='-" + Convert.ToDouble(brispgive.Text) + "',`barwar`='" + barwarispgive.Text + "',`cid`='" + comboBox2.SelectedValue.ToString() + "' WHERE `giveid`='" + id + "'");

                    ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای', give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic");
                    ob.sum(label239, givemoneisp, 1);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                    easyHTMLReports1.Clear();
                    easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                    easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

                    easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddString("<h2>" + comboBox2.Text + "</h2>");
                    con.Open();
                    MySqlCommand md = new MySqlCommand("SELECT * FROM `ispcompany` where ic='" + comboBox2.SelectedValue.ToString() + "'", con);
                    MySqlDataReader rd = md.ExecuteReader();
                    while (rd.Read())
                    {
                        easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

                    }

                    con.Close();
                    easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
                    easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslisp.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
                    easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
                    easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");

                    easyHTMLReports1.AddString("</tr>");


                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + noteispgive.Text + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >$" + brispgive.Text + "</td>");

                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + barwarispgive.Text + "</td>");

                    easyHTMLReports1.AddString("</tr>");


                    con.Close();
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + brispgive.Text + "</td>");
                    easyHTMLReports1.AddString("</tr>");
                    easyHTMLReports1.AddString("</table>");

                    easyHTMLReports1.ShowPrintPreviewDialog();
                    ob.a(this.Controls);
                }
                //}
                //catch (Exception)
                //{


                //}

            }
        }

        private void givemoneisp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (givemoneisp.SelectedRows.Count != 0)
                    {
                        int i = givemoneisp.SelectedRows[0].Index;
                        int id = Convert.ToInt32(givemoneisp.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `give_isp` WHERE `qncid`='" + id + "'");
                            ob.insert_del_up("DELETE FROM `hesab_isp` WHERE `giveid`='" + id + "'");
                            ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', give_isp.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d')` AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای', give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic");
                            ob.sum(label239, givemoneisp, 1);

                        }
                        else
                        {
                            ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', give_isp.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای', give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic");
                            ob.sum(label239, givemoneisp, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox89_Click(object sender, EventArgs e)
        {
            ob.toexcel(givemoneisp);
        }

        private void pictureBox88_Click(object sender, EventArgs e)
        {

            ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای',  give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic and give_isp.`dates` between '" + dateTimePicker22.Text + "' and '" + dateTimePicker23.Text + "'");
            ob.sum(label239, givemoneisp, 1);
        }

        private void materialSingleLineTextField22_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField22.Text != "")
            {

                ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای',give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic and ispcompany.`name` like '" + materialSingleLineTextField22.Text + "%'");
                ob.sum(label239, givemoneisp, 1);
            }
            else
            {

                ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای',  give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`wasl2` AS ' isp وەسڵی', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic");
                ob.sum(label239, givemoneisp, 1);
            }
        }

        private void materialSingleLineTextField21_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField21.Text != "")
            {
                ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای', give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic and give_isp.`qncid` like '" + materialSingleLineTextField21.Text + "%'");
                ob.sum(label239, givemoneisp, 1);
            }
            else
            {
                ob.table(givemoneisp, "SELECT give_isp.`qncid` AS '#', format(give_isp.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_isp.dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'isp کۆمپانیای', give_isp.`wasl` AS 'ژ.وەسڵ', give_isp.`tebene` AS 'تێبینی' FROM `give_isp`,ispcompany where give_isp.cid=ispcompany.ic");
                ob.sum(label239, givemoneisp, 1);

            }
        }

        private void pictureBox90_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'> گێڕانەوەی قەرزی isp</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(givemoneisp, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label239.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 26;
            ob.comb(cuscom, "SELECT * FROM cus_company", "ccid", "name");
            ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` order by mbids desc");
            ob.sum(label245, datagridcus, 1);
            ob.sum(label243, datagridcus, 3);
        }

        private void pictureBox95_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int days = DateTime.DaysInMonth(dateTimePicker40.Value.Year, dateTimePicker40.Value.Month);

                DateTime start = Convert.ToDateTime(dateTimePicker40.Text);
                DateTime finish = Convert.ToDateTime(barwarfcus.Text);
                TimeSpan difference = finish.Subtract(start);

                double sumnrx = Convert.ToDouble(materialSingleLineTextField51.Text);
                double nrx = 0;

                if (checkBox2.Checked != true)
                {
                    nrx = Convert.ToDouble(nrxfcus.Text);
                }
                else
                {
                    nrx = Convert.ToDouble(nrxfcus.Text) / online.draw.dolar;
                }
                double amou = 0;
                int dif = Convert.ToInt16(difference.Days) + 1;

                if (days != dif)
                {
                    double m = sumnrx / days;
                    amou = m * dif;

                    ob.insert_del_up("INSERT INTO `mb_sell`(`nomb`, `price`, `sump`, `dates1`, `dates`, `ccid`, `wasl`, `tebene`) VALUES ('" + numfcus.Text + "','" + nrx + "','" + amou + "','" + dateTimePicker40.Text + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "','" + zhw.Text + "','" + textBox4.Text + "')");

                    ob.insert_del_up("INSERT INTO `waslmega`( `wasl`, `dis`, `daym`, `days`, `quantity`, `unit`, `amount`,idms) VALUES ('" + zhw.Text + "','" + textBox4.Text + "','" + days + "','" + dif + "','" + numfcus.Text + "','" + nrx + "','" + amou + "',(select max(mbids) as id from mb_sell))");
                    if (qarzfcus.Checked == true)
                    {

                        ob.insert_del_up("INSERT INTO `qarz_cus_comp`(`qarzdinar`, `dates`, `ccid`, `msell`) VALUES  ('" + amou + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "',(select max(mbids) as id from mb_sell))");

                    }
                }
                else
                {

                    ob.insert_del_up("INSERT INTO `mb_sell`(`nomb`, `price`, `sump`, `dates1`, `dates`, `ccid`, `wasl`, `tebene`) VALUES ('" + numfcus.Text + "','" + nrx + "','" + sumnrx + "','" + dateTimePicker40.Text + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "','" + zhw.Text + "','" + textBox4.Text + "')");

                    ob.insert_del_up("INSERT INTO `waslmega`( `wasl`, `dis`, `daym`, `days`, `quantity`, `unit`, `amount`,idms) VALUES ('" + zhw.Text + "','" + textBox4.Text + "','" + days + "','" + dif + "','" + numfcus.Text + "','" + nrx + "','" + sumnrx + "',(select max(mbids) as id from mb_sell))");
                    if (qarzfcus.Checked == true)
                    {

                        ob.insert_del_up("INSERT INTO `qarz_cus_comp`(`qarzdinar`, `dates`, `ccid`, `msell`) VALUES  ('" + sumnrx + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "',(select max(mbids) as id from mb_sell))");

                    }
                }

                ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`-'" + numfcus.Text + "'");


                ob.a(this.Controls);
                ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` order by mbids desc");
                ob.sum(label245, datagridcus, 1);
                ob.sum(label243, datagridcus, 3);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();
            }
        }

        private void datagridcus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridcus.SelectedRows.Count != 0)
                    {
                        int i = datagridcus.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridcus.Rows[i].Cells[0].Value.ToString());
                        double adad = Convert.ToDouble(datagridcus.Rows[i].Cells[1].Value.ToString());
                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `qarz_cus_comp` WHERE msell='" + id + "'");
                            ob.insert_del_up("DELETE FROM `mb_sell` WHERE `mbids`='" + id + "'");
                            ob.insert_del_up("DELETE FROM `waslmega` WHERE `idms`='" + id + "'");
                            ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`+'" + adad + "'");
                            ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', `price` AS 'نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` order by mbids desc");
                            ob.sum(label245, datagridcus, 1);
                            ob.sum(label243, datagridcus, 2);

                        }
                        else
                        {
                            ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', `price` AS 'نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` order by mbids desc");
                            ob.sum(label245, datagridcus, 1);
                            ob.sum(label243, datagridcus, 2);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridcus_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datagridcus);
            ob.sum(label245, datagridcus, 1);
            ob.sum(label243, datagridcus, 3);
        }

        private void datagridcus_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datagridcus);
            ob.sum(label245, datagridcus, 1);
            ob.sum(label243, datagridcus, 3);
        }

        private void pictureBox93_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridcus);
        }

        private void pictureBox94_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>فرۆشتنی مێگابایت</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datagridcus, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label245.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label243.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void tabPage17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + datagridview12.Rows[0].Cells[5].Value.ToString() + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cname='" + datagridview12.Rows[0].Cells[5].Value.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێری داواکراو</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + datagridview12.Rows[0].Cells[7].Value.ToString() + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br> Salesperson  " + Form1.us + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%; dir:ltr;'>");

            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>حاڵەت</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>تێبینی</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>بەروار</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>عەدەد</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >ئامێر</th>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>#</th>");





            easyHTMLReports1.AddString("</tr>");
            double sm = 0;
            for (int i = 0; i < datagridview12.Rows.Count - 1; i++)
            {

                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview12.Rows[i].Cells[6].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >" + datagridview12.Rows[i].Cells[4].Value.ToString() + "</td>");

                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview12.Rows[i].Cells[3].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview12.Rows[i].Cells[2].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview12.Rows[i].Cells[1].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + (i + 1) + "</td>");

                easyHTMLReports1.AddString("</tr>");
                sm = sm + Convert.ToDouble(datagridview12.Rows[i].Cells[2].Value.ToString());

            }
            easyHTMLReports1.AddString("</table>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label87.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            ob.toexcel(datagridview12);
        }

        private void قەرزەکانToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 27;
            ob.comb(cusqarz, "SELECT * FROM cus_company", "ccid", "name");
            ob.table(cusdataqarz, "SELECT `qccid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', cus_company.name AS 'کۆمپانیا' FROM `qarz_cus_comp`,cus_company where qarz_cus_comp.ccid=cus_company.ccid");
            ob.sum(label257, cusdataqarz, 1);
        }

        private void cusqarz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ob.table(cusdataqarz, "SELECT `qccid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', cus_company.name AS 'کۆمپانیا' FROM `qarz_cus_comp`,cus_company where qarz_cus_comp.ccid=cus_company.ccid and qarz_cus_comp.ccid='" + cusqarz.SelectedValue.ToString() + "'");
                    ob.sum(label257, cusdataqarz, 1);
                }
                catch (Exception)
                {


                }
            }
        }

        private void materialSingleLineTextField23_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (materialSingleLineTextField23.Text != "")
                {

                    ob.table(cusdataqarz, "SELECT `qccid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', cus_company.name AS 'کۆمپانیا' FROM `qarz_cus_comp`,cus_company where qarz_cus_comp.ccid=cus_company.ccid and qarz_cus_comp.ccid like'" + materialSingleLineTextField23.Text + "%'");
                    ob.sum(label257, cusdataqarz, 1);
                }
                else
                {

                    ob.table(cusdataqarz, "SELECT `qccid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', cus_company.name AS 'کۆمپانیا' FROM `qarz_cus_comp`,cus_company where qarz_cus_comp.ccid=cus_company.ccid");
                    ob.sum(label257, cusdataqarz, 1);
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox96_Click(object sender, EventArgs e)
        {
            ob.table(cusdataqarz, "SELECT `qccid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', cus_company.name AS 'کۆمپانیا' FROM `qarz_cus_comp`,cus_company where qarz_cus_comp.ccid=cus_company.ccid and dates between '" + dateTimePicker24.Text + "' and '" + dateTimePicker25.Text + "'");
            ob.sum(label257, cusdataqarz, 1);
        }

        private void pictureBox97_Click(object sender, EventArgs e)
        {
            ob.toexcel(cusdataqarz);
        }

        private void pictureBox98_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>قەرزی کڕیاری باند</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(cusdataqarz, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label257.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void cusdataqarz_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(cusdataqarz);
            ob.sum(label257, cusdataqarz, 1);
        }

        private void cusdataqarz_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(cusdataqarz);
            ob.sum(label257, cusdataqarz, 1);
        }

        private void گێڕانەوەیقەرزToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 28;

            ob.comb(givecus, "SELECT * FROM cus_company", "ccid", "name");
            waslcus.Text = DateTime.Now.ToString("yyyyMMdd") + givecus.SelectedValue.ToString();
            ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid");
            ob.sum(label268, givemonecus, 1);
        }

        private void pictureBox103_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ob.insert_del_up("INSERT INTO `give_cus_company`(`qarzdinar`, `dates`, `cid`, `tebene`, `wasl`) VALUES ('" + nrxgivecus.Text + "','" + barwargivcus.Text + "','" + givecus.SelectedValue.ToString() + "','" + notegivecus.Text + "','" + waslcus.Text + "')");

                ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid");
                ob.sum(label268, givemonecus, 1);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();
                easyHTMLReports1.Clear();
                easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

                easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<h2>" + givecus.Text + "</h2>");
                con.Open();
                MySqlCommand md = new MySqlCommand("SELECT * FROM `cus_company` where ccid='" + givecus.SelectedValue.ToString() + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                while (rd.Read())
                {
                    easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

                }

                con.Close();
                easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
                easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslcus.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");

                easyHTMLReports1.AddString("</tr>");


                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + notegivecus.Text + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >$" + nrxgivecus.Text + "</td>");

                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + barwargivcus.Text + "</td>");

                easyHTMLReports1.AddString("</tr>");


                con.Close();
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + nrxgivecus.Text + "</td>");
                easyHTMLReports1.AddString("</tr>");
                easyHTMLReports1.AddString("</table>");

                easyHTMLReports1.ShowPrintPreviewDialog();
                ob.a(this.Controls);
            }
        }

        private void pictureBox102_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //try
                //{
                if (givemonecus.SelectedRows.Count != 0)
                {
                    int i = givemonecus.SelectedRows[0].Index;
                    String id = givemonecus.Rows[i].Cells[0].Value.ToString();
                    ob.insert_del_up("UPDATE `give_cus_company` SET `qarzdinar`='" + Convert.ToDouble(nrxgivecus.Text) + "',`dates`='" + barwargivcus.Text + "',`cid`='" + givecus.SelectedValue.ToString() + "',`tebene`='" + notegivecus.Text + "',wasl='" + waslcus.Text + "' WHERE `qncid`='" + id + "'");

                    ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid");
                    ob.sum(label268, givemonecus, 1);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                    easyHTMLReports1.Clear();
                    easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                    easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

                    easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddString("<h2>" + givecus.Text + "</h2>");
                    con.Open();
                    MySqlCommand md = new MySqlCommand("SELECT * FROM `cus_company` where ccid='" + givecus.SelectedValue.ToString() + "'", con);
                    MySqlDataReader rd = md.ExecuteReader();
                    while (rd.Read())
                    {
                        easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

                    }

                    con.Close();
                    easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Debt repayment</i></h2>");
                    easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslcus.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
                    easyHTMLReports1.AddLineBreak();
                    easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
                    easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
                    easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");

                    easyHTMLReports1.AddString("</tr>");


                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + notegivecus.Text + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >$" + nrxgivecus.Text + "</td>");

                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + barwargivcus.Text + "</td>");

                    easyHTMLReports1.AddString("</tr>");


                    con.Close();
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + nrxgivecus.Text + "</td>");
                    easyHTMLReports1.AddString("</tr>");
                    easyHTMLReports1.AddString("</table>");

                    easyHTMLReports1.ShowPrintPreviewDialog();
                    ob.a(this.Controls);
                }
                //}
                //catch (Exception)
                //{


                //}

            }
        }

        private void givemonecus_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(givemonecus, nrxgivecus, 1);
            ob.change_datagridview_combo(givemonecus, givecus, 3);
            ob.change_datagridview_picker(givemonecus, barwargivcus, 2);
            ob.change_datagridview(givemonecus, notegivecus, 5);
            ob.change_datagridviewl(givemonecus, waslcus, 4);
        }

        private void givemonecus_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(givemonecus);
            ob.sum(label268, givemonecus, 1);
        }

        private void givemonecus_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(givemonecus);
            ob.sum(label268, givemonecus, 1);
        }

        private void pictureBox100_Click(object sender, EventArgs e)
        {
            ob.toexcel(givemonecus);
        }

        private void materialSingleLineTextField25_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField25.Text != "")
            {

                ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid and cus_company.`name` like '" + materialSingleLineTextField25.Text + "%'");
                ob.sum(label268, givemonecus, 1);
            }
            else
            {

                ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid");
                ob.sum(label268, givemonecus, 1);
            }
        }

        private void materialSingleLineTextField24_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField24.Text != "")
            {
                ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid and give_cus_company.`qncid` like '" + materialSingleLineTextField24.Text + "%'");
                ob.sum(label268, givemonecus, 1);
            }
            else
            {
                ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid");
                ob.sum(label268, givemonecus, 1);
            }
        }

        private void pictureBox99_Click(object sender, EventArgs e)
        {
            ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', format(give_cus_company.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_cus_company.dates, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid and give_cus_company.`dates` between '" + dateTimePicker26.Text + "' and '" + dateTimePicker27.Text + "'");
            ob.sum(label268, givemonecus, 1);
        }

        private void pictureBox101_Click(object sender, EventArgs e)
        {
            try
            {
                if (givemonecus.SelectedRows.Count != 0)
                {
                    bool dinar = checkBox6.Checked;
                    double conversionRate = online.draw.dolar; // Make sure this is the current conversion rate
                    easyHTMLReports1.Clear();
                    easyHTMLReports1.AddLineBreak();
                    // Company Header
                    string headerHTML = @"
            <div style='text-align:left; margin-bottom: 20px;'>
                <h1 style='color: #004A8F;'>Online Company Ltd</h1>
                <p>
                    Kalar Bazar<br>
                    Talari M. Mahmoud, 3rd Floor<br>
                    Sulaymaniyah, IRAQ<br>
                    Tel: 07711550366 - 07502478020
                </p>
            </div>";

                    // Initialize items table HTML with headers
                    string itemsTableHTML = @"
            <table style='width: 100%; border-collapse: collapse; margin-top: 20px;'>
                <tr>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Description</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Month</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Invoice</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Paid</th>
                </tr>";
                    int index = givemonecus.SelectedRows[0].Index;
                    string customer = givemonecus.Rows[index].Cells[3].Value.ToString();

                    // Loop through all rows in DataGridView
                    foreach (DataGridViewRow row in givemonecus.Rows)
                    {
                        if (!row.IsNewRow) // Check to avoid processing the new row template
                        {
                            string note = row.Cells[5].Value.ToString();
                            string date = row.Cells[2].Value.ToString();
                            //string customer = row.Cells[3].Value.ToString(); // Assuming this doesn't change per row
                            string receipt = row.Cells[4].Value.ToString();
                            double amount = Convert.ToDouble(row.Cells[1].Value.ToString());
                            string formattedAmount = dinar ? RoundToNearestThreshold(amount * conversionRate).ToString("N0") + " IQD" : "$" + amount.ToString("N2");

                            itemsTableHTML += $@"
                    <tr>
                        <td style='border: 1px solid gray; padding: 8px;'>{note}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{date}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{receipt}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{formattedAmount}</td>
                    </tr>";
                        }
                    }

                    // Close the table HTML
                    itemsTableHTML += "</table>";

                    // Assuming customer name and total amount remain constant for the whole receipt
                    // Add Receipt Title and Date
                    string titleAndDateHTML = $@"
            <div style='display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px;'>
                <div>
                    <h2 style='color: #004A8F;'>Arrived Receipt</h2>
                    <p>Customer: {customer}</p> <!-- Make sure 'customer' is defined outside the loop -->
                </div>
                <p>{DateTime.Now.ToString("yyyy/MM/dd")}</p> <!-- 'receipt' should also be defined -->
            </div>";

                    // Total Amount
                    double total = Convert.ToDouble(label268.Text);
                    string formattedTotal = dinar ? RoundToNearestThreshold(total * conversionRate).ToString("N0") + " IQD" : "$" + total.ToString("N2");
                    string totalAmountHTML = $@"
            <div style='text-align: right; margin-top: 20px;'>
                <p style='color: #004A8F;'><strong>Total:</strong>{formattedTotal}</p>
            </div>";

                    // Combine all parts
                    easyHTMLReports1.AddString(headerHTML);
                    easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top: -160px; margin-right: 20px;'");
                    easyHTMLReports1.AddString(titleAndDateHTML);
                    easyHTMLReports1.AddString(itemsTableHTML); // Use the dynamically generated table
                    easyHTMLReports1.AddString(totalAmountHTML);

                    // Show or export the report
                    easyHTMLReports1.ShowPrintPreviewDialog();
                }
            }
            catch { 
            }

        }

        private void pictureBox104_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label270_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void کارتیفرۆشراویبریکارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 29;

            ob.table(data29, "SELECT `brid` AS '#', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',sum(mbrekar) as 'پارەی بریکار',(sum(`sumprice`)-sum(mbrekar)) as 'ئەنجام',customer.cname as 'بریکار',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid and balance.types!='رصيد' group by wasl");
            ob.sum(label275, data29, 1);
            ob.sum(label277, data29, 4);
            ob.sum(label499, data29, 3);
            ob.setsepator(label275);
            ob.setsepator(label277);
            ob.setsepator(label499);
        }

        private void pictureBox108_Click(object sender, EventArgs e)
        {
        }

        private void data29_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data29);
            ob.sum(label275, data29, 1);
            ob.sum(label277, data29, 4);
            ob.sum(label499, data29, 3);
            ob.setsepator(label275);
            ob.setsepator(label277);
            ob.setsepator(label499);
        }

        private void data29_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data29);
            ob.sum(label275, data29, 1);
            ob.sum(label277, data29, 4);
            ob.sum(label499, data29, 3);
            ob.setsepator(label275);
            ob.setsepator(label277);
            ob.setsepator(label499);
        }

        private void pictureBox106_Click(object sender, EventArgs e)
        {
            ob.toexcel(data29);
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void pictureBox105_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField38.Text != "")
            {
                ob.table(data29, "SELECT `brid` AS '#', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',sum(mbrekar) as 'پارەی بریکار',(sum(`sumprice`)-sum(mbrekar)) as 'ئەنجام',customer.cname as 'بریکار',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid and customer.cname like '" + materialSingleLineTextField38.Text + "%' and dates between '" + dateTimePicker28.Text + "' and '" + dateTimePicker29.Text + "' group by customer.cname");
                ob.sum(label275, data29, 1);
                ob.sum(label277, data29, 4);
                ob.sum(label499, data29, 3);


            }
            else
            {

                ob.table(data29, "SELECT `brid` AS '#', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',sum(mbrekar) as 'پارەی بریکار',(sum(`sumprice`)-sum(mbrekar)) as 'ئەنجام',customer.cname as 'بریکار',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid and dates between '" + dateTimePicker28.Text + "' and '" + dateTimePicker29.Text + "' group by customer.cname");
                ob.sum(label275, data29, 1);
                ob.sum(label277, data29, 4);
                ob.sum(label499, data29, 3);

            }
            ob.setsepator(label275);
            ob.setsepator(label277);
            ob.setsepator(label499);
        }

        private void pictureBox107_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارتی فرۆشراوی بریکار</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(data29, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label275.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label277.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void ڕاپۆرتیفرۆشتنیکارتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 30;
            ob.comb(comboBox4, "SELECT * FROM customer", "cid", "cname");

        }
        double qarzt = 0;
        private void pictureBox109_Click(object sender, EventArgs e)
        {
            ob.table(data30, "SELECT `brid` AS '#', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',(`sumprice`-mbrekar) as 'ئەنجام', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', balance.types AS 'جۆری کارت',(SELECT Coalesce(sum(`num`),0) AS 'sumget' FROM `balance_roshtu_view` where balance_roshtu_view.bbid=froshtn_kart.bid and balance_roshtu_view.cc=froshtn_kart.cid and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "') as 'کارتی وەرگیراو',(select COALESCE(sum(number),0)  from storage_kart_view_customer where storage_kart_view_customer.bid=froshtn_kart.bid and storage_kart_view_customer.cusid=froshtn_kart.cid) as 'کارتی کۆگا',tebene AS 'تێبینی' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid and froshtn_kart.cid='" + comboBox4.SelectedValue.ToString() + "' and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'  " +
                "UNION ALL SELECT  id AS '#',  0 AS 'عەدەد',  0 AS 'نرخ',  0 AS 'کۆی نرخ', 0 AS 'پارەی بریکار', -amount AS 'ئەنجام',  DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار',  'پارەی دراو ' AS 'جۆری کارت',  0 AS 'کارتی وەرگیراو',  0 AS 'کارتی کۆگا',  tebene AS 'تێبینی'  FROM  exchange_balance where kid = " + comboBox4.SelectedValue.ToString() + " and  barwar between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'"+
                "UNION ALL SELECT  id AS '#',  0 AS 'عەدەد',  0 AS 'نرخ',  0 AS 'کۆی نرخ', 0 AS 'پارەی بریکار', amount AS 'ئەنجام',  DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار',  ' پارەئ وەرگیراو' AS 'جۆری کارت',  0 AS 'کارتی وەرگیراو',  0 AS 'کارتی کۆگا',  tebene AS 'تێبینی'  FROM  exchange_balance where cus = " + comboBox4.SelectedValue.ToString() + " and  barwar between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'");
            ob.sum(label286, data30, 1);
            ob.sum(label497, data30, 4);
            ob.sum(label284, data30, 5);
            ob.sum(label374, data30, 9);
            con.Open();
            MySqlCommand mw = new MySqlCommand("SELECT Coalesce(sum(`qarzdinar`),0) as snrx From qarz where cid='" + comboBox4.SelectedValue.ToString() + "' and id_balance_roshtu!=0 and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'", con);
            MySqlDataReader rw = mw.ExecuteReader();
            while (rw.Read())
            {

                qarzt = Convert.ToDouble(rw.GetString("snrx"));

            }
            con.Close();
            con.Open();

            MySqlCommand mget = new MySqlCommand("SELECT Coalesce(sum(`num`),0) AS 'sumget' FROM `balance_roshtu_view` where cc='" + comboBox4.SelectedValue.ToString() + "' and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'", con);
            MySqlDataReader rget = mget.ExecuteReader();
            while (rget.Read())
            {

                label157.Text = rget.GetString("sumget");

            }
            con.Close();
            con.Open();
            MySqlCommand mget22 = new MySqlCommand("SELECT Coalesce(sum(`amount`),0) AS 'sumget' FROM `exchange_balance` where kid='" + comboBox4.SelectedValue.ToString() + "' and barwar between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'", con);
            MySqlDataReader rget22 = mget22.ExecuteReader();
            while (rget22.Read())
            {

                drag.Text = rget22.GetString("sumget");

            }
            con.Close();

            con.Open();
            MySqlCommand mget2 = new MySqlCommand("SELECT Coalesce(sum(`amount`),0) AS 'sumget' FROM `exchange_balance` where cus='" + comboBox4.SelectedValue.ToString() + "' and barwar between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'", con);
            MySqlDataReader rget2 = mget2.ExecuteReader();
            while (rget2.Read())
            {

                warg.Text = rget2.GetString("sumget");

            }
            con.Close();
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT Coalesce(sum(`amount`),0) as snrx From masrufatwakel where state='قبوڵکراو' and cid='" + comboBox4.SelectedValue.ToString() + "' and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {

                label288.Text = rd.GetString("snrx");

            }
            con.Close();
            con.Open();
            MySqlCommand mdd = new MySqlCommand("SELECT Coalesce(sum(`qarzdinar`),0) as sqarz From give_customer where cid='" + comboBox4.SelectedValue.ToString() + "' and ty='کارت' and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            while (rdd.Read())
            {

                label292.Text = rdd.GetString("sqarz");

            }
            con.Close();

            double ss = Convert.ToDouble(label292.Text) + Convert.ToDouble(label288.Text);
            double aged = Convert.ToDouble(warg.Text) - Convert.ToDouble(drag.Text);
            double mawa = Convert.ToDouble(label284.Text)  - ss;
            label290.Text = mawa.ToString();
            label292.Text = (Convert.ToDouble(label292.Text)).ToString();

        }

        private void pictureBox110_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >For information technology<br> Electronic supplies <br> Internet services</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>بریکار/" + comboBox4.Text + "</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");

            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%; direction=rtl'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>#</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>عەدەد</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>نرخ</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>کۆی نرخ</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>پارەی بریکار</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>ئەنجام</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;' >بەروار</th>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: right;padding: 8px;'>جۆری کارت</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;' >کارتی وەرگیراو</th>");

            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;' >کارتی کۆگا</th>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: right;padding: 8px;'>تێبینی</th>");
            easyHTMLReports1.AddString("</tr>");

            con.Open();

            int cou = 1;
            MySqlCommand mdd = new MySqlCommand("SELECT `brid` AS '#', `num` AS 'num', `price` AS 'price', `sumprice` AS 'sumprice',mbrekar,(`sumprice`-mbrekar) as 'anjam', DATE_FORMAT(dates, '%Y/%m/%d') AS 'dates', balance.types AS 'ty',(SELECT Coalesce(sum(`num`),0) AS 'sumget' FROM `balance_roshtu_view` where balance_roshtu_view.bbid=froshtn_kart.bid and balance_roshtu_view.cc=froshtn_kart.cid and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "') as 'war',(select COALESCE(sum(number),0)  from storage_kart_view_customer where storage_kart_view_customer.bid=froshtn_kart.bid and storage_kart_view_customer.cusid=froshtn_kart.cid) as 'koga',tebene AS 'tebene' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid and froshtn_kart.cid='" + comboBox4.SelectedValue.ToString() + "' and dates between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'"
                 +
                "UNION ALL SELECT  id AS '#',  0 AS 'عەدەد',  0 AS 'نرخ',  0 AS 'کۆی نرخ', 0 AS 'پارەی بریکار', -amount AS 'ئەنجام',  DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار',  'پارەی دراو ' AS 'جۆری کارت',  0 AS 'کارتی وەرگیراو',  0 AS 'کارتی کۆگا',  tebene AS 'تێبینی'  FROM  exchange_balance where kid = " + comboBox4.SelectedValue.ToString() + " and  barwar between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'" +
                "UNION ALL SELECT  id AS '#',  0 AS 'عەدەد',  0 AS 'نرخ',  0 AS 'کۆی نرخ', 0 AS 'پارەی بریکار', amount AS 'ئەنجام',  DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار',  ' پارەئ وەرگیراو' AS 'جۆری کارت',  0 AS 'کارتی وەرگیراو',  0 AS 'کارتی کۆگا',  tebene AS 'تێبینی'  FROM  exchange_balance where cus = " + comboBox4.SelectedValue.ToString() + " and  barwar between '" + dateTimePicker30.Text + "' and '" + dateTimePicker31.Text + "'", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            if (rdd.HasRows)
            {
                while (rdd.Read())
                {
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");

                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + cou + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("num") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("price") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("sumprice") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("mbrekar") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("anjam") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;' >" + rdd.GetString("dates") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("ty") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("war") + "</td>");

                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("koga") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("tebene") + "</td>");
                    easyHTMLReports1.AddString("</tr>");
                    cou++;

                }
            }
            con.Close();
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;' >");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی گشتی</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label286.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی نرخ</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label284.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;'>کۆی مەسرەف</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label288.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی کارتی وەرگیراو</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label157.Text + "</td>");
            easyHTMLReports1.AddString("</tr>");

            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی پارەی وەرگیراو</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label292.Text + "</td>");
            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی قەرز</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label290.Text + "</td>");
            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("</table>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Dear Client <br>Please Proceed with the payment within 4 days<br>Online Company accept cash payment delivered to the Kalar Bazar-Sulaymaniyah,IRAQ </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>if you have any question concering this invoice please contact <br>096407729790070 – 096407512330605<br>acc@onlineco.net");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h4 align=center style='font-size:14px;'>   Kalar Bazar - Talari M. Mahmoud -  3nd floor, Sulaymaniyah, IRAQ -    Tel: 07711550366 - 07502478020</h4>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void پێدانیموچەToolStripMenuItem_Click(object sender, EventArgs e)
        {

            materialTabControl1.SelectedIndex = 31;
            ob.comb(karmand, "SELECT * FROM employee", "eid", "ename");
            ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid");
            ob.sum(label303, data31, 3);
            ob.sum(label485, data31, 9);



        }

        private void pictureBox115_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                double sub = Convert.ToDouble(amana.Text) + Convert.ToDouble(sza.Text) + Convert.ToDouble(qarzmucha.Text);
                double sum = Convert.ToDouble(mucha.Text) + Convert.ToDouble(padasht.Text) + Convert.ToDouble(plus.Text);
                double result = sum - sub;
                ob.insert_del_up("INSERT INTO `muchay_employee`(`employee_id`, `br`, `amanat`, `padasht`, `sza`, `plus`, `give`, `mucha`, `dates`, `note`) VALUES ('" + karmand.SelectedValue.ToString() + "','" + mucha.Text + "','" + amana.Text + "','" + padasht.Text + "','" + sza.Text + "','" + plus.Text + "','" + qarzmucha.Text + "','" + result + "','" + barwarmucha.Text + "','" + tebenemucha.Text + "')");
                if (amana.Text != "" && amana.Text != "0")
                {
                    ob.insert_del_up("UPDATE `employee` SET `amanat`=amanat+'" + amana.Text + "' WHERE `eid`='" + karmand.SelectedValue.ToString() + "'");
                }
                ob.aa(this.Controls);
                ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid");
                ob.sum(label303, data31, 3);
                ob.sum(label485, data31, 9);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();

            }
        }

        private void pictureBox114_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (data31.SelectedRows.Count != 0)
                    {
                        int i = data31.SelectedRows[0].Index;
                        String id = data31.Rows[i].Cells[0].Value.ToString();
                        String aman = data31.Rows[i].Cells[4].Value.ToString();
                        double sub = Convert.ToDouble(amana.Text) + Convert.ToDouble(sza.Text) + Convert.ToDouble(qarzmucha.Text);
                        double sum = Convert.ToDouble(mucha.Text) + Convert.ToDouble(padasht.Text) + Convert.ToDouble(plus.Text);
                        double result = sum - sub;
                        ob.insert_del_up("UPDATE `muchay_employee` SET `employee_id`='" + karmand.SelectedValue.ToString() + "',`br`='" + mucha.Text + "',`amanat`='" + amana.Text + "',`padasht`='" + padasht.Text + "',`sza`='" + sza.Text + "',`plus`='" + plus.Text + "',`give`='" + qarzmucha.Text + "',`mucha`='" + result + "',`dates`='" + barwarmucha.Text + "',`note`='" + tebenemucha.Text + "' WHERE  `id`='" + id + "'");
                        if (aman != "" && aman != "0")
                        {
                            double re = Convert.ToDouble(amana.Text) - Convert.ToDouble(aman);

                            ob.insert_del_up("UPDATE `employee` SET `amanat`=amanat+'" + re + "' WHERE `eid`='" + karmand.SelectedValue.ToString() + "'");

                        }



                        //ob.aa(this.Controls);


                        ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid");
                        ob.sum(label303, data31, 3);
                        ob.sum(label485, data31, 9);

                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void data31_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(data31, karmand, 1);
            ob.change_datagridview_textfild(data31, mucha, 3);
            ob.change_datagridview_textfild(data31, amana, 4);
            ob.change_datagridview_textfild(data31, padasht, 5);
            ob.change_datagridview_textfild(data31, sza, 6);
            ob.change_datagridview_textfild(data31, plus, 7);
            ob.change_datagridview_textfild(data31, qarzmucha, 8);
            ob.change_datagridview_picker(data31, barwarmucha, 10);
            ob.change_datagridview(data31, tebenemucha, 11);
        }

        private void data31_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data31);
            ob.sum(label303, data31, 3);
            ob.sum(label485, data31, 9);
        }

        private void data31_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data31);
            ob.sum(label303, data31, 3);
            ob.sum(label485, data31, 9);
        }

        private void data31_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (data31.SelectedRows.Count != 0)
                    {
                        int i = data31.SelectedRows[0].Index;
                        int id = Convert.ToInt32(data31.Rows[i].Cells[0].Value.ToString());
                        double aman = Convert.ToDouble(data31.Rows[i].Cells[4].Value.ToString());
                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `muchay_employee` WHERE `id`='" + id + "'");
                            if (aman != 0)
                            {
                                ob.insert_del_up("UPDATE `employee` SET `amanat`=amanat-'" + aman + "' WHERE `eid`='" + karmand.SelectedValue.ToString() + "'");


                            }
                            ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', `give` AS 'قەرز دانەوە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid");
                            ob.sum(label303, data31, 3);
                            ob.sum(label485, data31, 9);
                            ob.aa(this.Controls);
                        }
                        else
                        {
                            ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', `give` AS 'قەرز دانەوە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid");
                            ob.sum(label303, data31, 3);
                            ob.sum(label485, data31, 9);
                        }
                    }
                }
                catch (Exception)
                {


                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void pictureBox112_Click(object sender, EventArgs e)
        {
            ob.toexcel(data31);
        }

        private void materialSingleLineTextField27_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField27.Text != "")
            {

                ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid and employee.ename like '" + materialSingleLineTextField27.Text + "%'");
                ob.sum(label303, data31, 3);
                ob.sum(label485, data31, 9);
            }
            else
            {

                ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid");
                ob.sum(label303, data31, 3);
                ob.sum(label485, data31, 9);
            }
        }

        private void materialSingleLineTextField26_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField26.Text != "")
            {

                ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid and id like '" + materialSingleLineTextField26.Text + "%'");
                ob.sum(label303, data31, 3);
                ob.sum(label485, data31, 9);
            }
            else
            {

                ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid");
                ob.sum(label303, data31, 3);
                ob.sum(label485, data31, 9);
            }
        }

        private void pictureBox111_Click(object sender, EventArgs e)
        {

            ob.table(data31, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'موچەی بنەڕەتی', muchay_employee.`amanat` AS 'ئەمانەت', `padasht` AS 'پاداشت ', `sza` AS 'سزا', `plus` AS 'کاتژمێری زیادە', `give` AS 'قەرز دانەوە', muchay_employee.`mucha` AS 'موچەی ئێستا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `muchay_employee`,employee where muchay_employee.employee_id=employee.eid and dates between '" + dateTimePicker32.Text + "' and '" + dateTimePicker33.Text + "'");
            ob.sum(label303, data31, 3);
            ob.sum(label485, data31, 9);
        }

        private void pictureBox113_Click(object sender, EventArgs e)
        {

            easyHTMLReports1.Clear();
            int num = 1;
            int i;
            int a = 0;
            double n = Convert.ToDouble(data31.Rows.Count - 1) / 15;

            for (i = 0; i < n; i++)
            {
                easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
                easyHTMLReports1.AddString("<h2  style='color:cyan;'>لیستی موچە</h2>");
                easyHTMLReports1.AddString("<p style='font-size:14px;'>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Sales person#  " + Form1.us + "</p>");
                easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
                easyHTMLReports1.AddLineBreak();

                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif; direction:rtl;font-size:14px; border-collapse: collapse;width: 100%;'>");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>#</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >ناوی کارمەند</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>پلە</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>موچەی بنەڕەتی</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>ئەمانەت</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>پاداشت</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>سزا</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>کاتژمێری زیادە</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>قەرز دانەوە</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>موچەی کۆتای</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;width:70px;'>ئیمزا</th>");
                easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>تێبینی</th>");
                easyHTMLReports1.AddString("</tr>");
                double sm = 0;


                for (int j = a; j < a + 15; j++)
                {
                    if (j == data31.Rows.Count - 1)
                    {
                        break;
                    }
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;'>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:5px;text-align: left; color:white; font-size:14px;'>" + num + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:5px;text-align: left; color:white; font-size:14px;' >" + data31.Rows[j].Cells[1].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px; text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[2].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px; text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[3].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px;text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[4].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px;text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[5].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px; text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[6].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px;text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[7].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px;text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[8].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px;text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[9].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px;text-align: left;color:white; font-size:14px;width:70px;'></td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:5px;text-align: left; color:white; font-size:14px;'>" + data31.Rows[j].Cells[11].Value.ToString() + "</td>");
                    easyHTMLReports1.AddString("</tr>");
                    sm = sm + Convert.ToDouble(data31.Rows[j].Cells[9].Value.ToString());
                    num++;

                }
                easyHTMLReports1.AddString("</table>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
                easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + sm + "</p>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();

                easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif; direction:rtl;font-size:14px;width: 100%;'>");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid white;text-align: center;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid white;text-align: center;padding: 8px;'>ژمێریاری</td>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid white;text-align: center;padding: 8px;'>کارگێڕی</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid white;text-align: center;padding: 8px;' >ووردبین</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid white;text-align: center;padding: 8px;'>بەڕێوبەر</td>");
                easyHTMLReports1.AddString("</tr>");
                easyHTMLReports1.AddString("</table>");
                easyHTMLReports1.NewPage();

                a = a + 15;
            }
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void tabPage32_Click(object sender, EventArgs e)
        {

        }

        private void karmand_SelectedValueChanged(object sender, EventArgs e)
        {
            con.Open();

            MySqlCommand mddd = new MySqlCommand("SELECT * From employee where eid='" + karmand.SelectedValue.ToString() + "'", con);
            MySqlDataReader rddd = mddd.ExecuteReader();
            while (rddd.Read())
            {

                mucha.Text = rddd.GetString("mucha");

            }
            con.Close();
            con.Open();
            double giv = 0;
            double qarz = 0;
            MySqlCommand md = new MySqlCommand("SELECT Coalesce(sum(`give`),0) as gi From muchay_employee where employee_id='" + karmand.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {

                giv = Convert.ToDouble(rd.GetString("gi"));

            }
            con.Close();
            con.Open();
            MySqlCommand mdd = new MySqlCommand("SELECT Coalesce(sum(`br`),0) as sqarz From qarz_employee where employee_id='" + karmand.SelectedValue.ToString() + "'", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            while (rdd.Read())
            {

                qarz = Convert.ToDouble(rdd.GetString("sqarz"));

            }
            con.Close();

            label307.Text = (qarz - giv).ToString();
        }

        private void qarzmucha_TextChanged(object sender, EventArgs e)
        {
            if (qarzmucha.Text != "")
            {

                double giv = Convert.ToDouble(qarzmucha.Text);
                double qarz = Convert.ToDouble(label307.Text);
                if (giv > qarz)
                {
                    MessageBox.Show("پارەی گێڕانەوە زیاترە لە قەرز");
                    qarzmucha.Text = "0";


                }

            }
        }

        private void پێدانیقەرزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 32;
            ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid");
            ob.comb(karmandqarz, "SELECT * FROM employee", "eid", "ename");
            ob.sum(label317, data32, 3);
        }

        private void pictureBox120_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ob.insert_del_up("INSERT INTO `qarz_employee`(`employee_id`, `br`, `dates`, `note`) VALUES ('" + karmandqarz.SelectedValue.ToString() + "','" + brqarz.Text + "','" + barwarqarz.Text + "','" + tebeneqarz.Text + "')");
                ob.a(this.Controls);
                ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid");
                ob.sum(label317, data32, 3);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();

            }
        }

        private void pictureBox119_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (data32.SelectedRows.Count != 0)
                    {
                        int i = data32.SelectedRows[0].Index;
                        String id = data32.Rows[i].Cells[0].Value.ToString();
                        ob.insert_del_up("UPDATE `qarz_employee` SET `employee_id`='" + karmandqarz.SelectedValue.ToString() + "',`br`='" + brqarz.Text + "',`dates`='" + barwarqarz.Text + "',`note`='" + tebeneqarz.Text + "' WHERE  `id`='" + id + "'");
                        ob.a(this.Controls);
                        ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid");
                        ob.sum(label317, data32, 3);
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void data32_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data32);
            ob.sum(label317, data32, 3);
        }

        private void data32_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(data32, karmandqarz, 1);
            ob.change_datagridview_textfild(data32, brqarz, 3);
            ob.change_datagridview_picker(data32, barwarqarz, 4);
            ob.change_datagridview(data32, tebeneqarz, 5);
        }

        private void data32_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (data32.SelectedRows.Count != 0)
                    {
                        int i = data32.SelectedRows[0].Index;
                        int id = Convert.ToInt32(data32.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `qarz_employee` WHERE `id`='" + id + "'");
                            ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid");
                            ob.sum(label317, data32, 3);

                        }
                        else
                        {
                            ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid");
                            ob.sum(label317, data32, 3);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void data32_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data32);
            ob.sum(label317, data32, 3);
        }

        private void pictureBox117_Click(object sender, EventArgs e)
        {
            ob.toexcel(data32);
        }

        private void materialSingleLineTextField29_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField29.Text != "")
            {

                ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid and employee.ename like '" + materialSingleLineTextField29.Text + "%'");
                ob.sum(label317, data32, 3);
            }
            else
            {

                ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid");
                ob.sum(label317, data32, 3);
            }
        }

        private void materialSingleLineTextField28_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField28.Text != "")
            {

                ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid and id like '" + materialSingleLineTextField28.Text + "%'");
                ob.sum(label317, data32, 3);
            }
            else
            {

                ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid");
                ob.sum(label317, data32, 3);
            }
        }

        private void pictureBox116_Click(object sender, EventArgs e)
        {
            ob.table(data32, "SELECT `id` as '#', employee.ename as 'ناوی کارمەند',employee.pla as 'پلە', `br` AS 'بڕی موچە',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', `note` AS 'تێبینی' FROM `qarz_employee`,employee where qarz_employee.employee_id=employee.eid and dates between '" + dateTimePicker34.Text + "' and '" + dateTimePicker35.Text + "'");
            ob.sum(label317, data32, 3);
        }

        private void pictureBox118_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>لیستی موچە</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(data32, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>پێدانی قەرز</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label317.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void salary_TextChanged(object sender, EventArgs e)
        {
            if (salary.Text != "")
            {
                double aman = Convert.ToDouble(salary.Text) / 2;
                amanat.Text = aman.ToString();

            }
        }

        private void ispdataqarz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (ispdataqarz.SelectedRows.Count != 0)
                    {
                        int i = ispdataqarz.SelectedRows[0].Index;
                        int id = Convert.ToInt32(ispdataqarz.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `qarz_isp_comp` WHERE `qicid`='" + id + "'");
                            ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic");
                            ob.sum(label228, ispdataqarz, 1);
                            ob.a(this.Controls);
                        }
                        else
                        {
                            ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic");
                            ob.sum(label228, ispdataqarz, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox121_Click(object sender, EventArgs e)
        {
            ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', format(`price`,2) AS 'نرخ', format(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای',ispcompany.name AS 'isp',wasl AS 'ژ.وەسڵ',tebene as 'تێبینی' FROM mb_buy,ispcompany where mb_buy.ic=ispcompany.ic  and DATE_FORMAT(dates1, '%Y/%m/%d') between '" + dateTimePicker36.Text + "' and '" + dateTimePicker37.Text + "'");
            ob.sum(label215, datagridbmp, 1);
            ob.sum(label204, datagridbmp, 3);

        }

        private void pictureBox122_Click(object sender, EventArgs e)
        {

            ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` and dates1 between '" + dateTimePicker38.Text + "' and '" + dateTimePicker39.Text + "' order by mbids desc");
            ob.sum(label245, datagridcus, 1);
            ob.sum(label243, datagridcus, 3);
        }

        static double RoundToNearestThreshold(double num)
        {
            // Calculate the remainder when divided by 1000 to find how far the number is into its current thousand.
            double remainder = num % 250;
            Console.WriteLine($"Original: {num}, Rounded: {remainder}");
            // Determine the closest threshold (250, 500, 750, or 1000) for the remainder.
            if (remainder < 125) return num - remainder;
            else return num - remainder + 250; // Closer to the next thousand
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool dinar = checkBox5.Checked;
            double conversionRate = online.draw.dolar;
            string currencySymbol = dinar ? "IQD " : "$";

            easyHTMLReports1.Clear();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >for information technology<br> electronic supplies <br> internet services</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + cuscom.Text + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `cus_company` where ccid='" + cuscom.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Invoice</i></h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + dwasl.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br><br> </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >Days Month</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Days Work</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Quantity</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Unit Price</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Amount</th>");
            easyHTMLReports1.AddString("</tr>");

            con.Open();
            double sm = 0;
            MySqlCommand mdd = new MySqlCommand("SELECT `id`, `wasl`, `dis`, `daym`, `days`, `quantity`, `unit`, Truncate(`amount`,2) as 'amount', `idms` FROM `waslmega` where wasl='" + dwasl.Text + "'", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            while (rdd.Read())
            {
                double unitPrice = Convert.ToDouble(rdd.GetString("unit"));
                double amount = Convert.ToDouble(rdd.GetString("amount"));
                string formattedunitPrice = "$" + unitPrice.ToString("N2");
                string formattedamount = "$" + amount.ToString("N2");
                if (dinar)
                {
                    unitPrice *= conversionRate;
                    amount *= conversionRate;
                    unitPrice = RoundToNearestThreshold(unitPrice);
                    amount = RoundToNearestThreshold(amount);
                    formattedunitPrice = unitPrice.ToString("N0") + " IQD";
                    formattedamount = amount.ToString("N0") + " IQD";
                }
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("dis") + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >" + rdd.GetString("daym") + "</td>");

                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("days") + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("quantity") + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + formattedunitPrice + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + formattedamount + "</td>"); easyHTMLReports1.AddString("</tr>");
                sm += Convert.ToDouble(rdd.GetString("amount"));
            }

            con.Close();
            string formattedTotal = "$" + sm.ToString("N2") ;
            if (dinar)
            {
                sm *= conversionRate;
                 formattedTotal = RoundToNearestThreshold(sm).ToString("N0") + " IQD";
            }
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;' colspan=5>Total:</td>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:white; font-size:14px;'>" +  formattedTotal + "</td>");
            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("</table>");

            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + formattedTotal + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Total:</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Dear Client <br>Please Proceed with the payment within 4 days<br>Online Company accept cash payment delivered to the Kalar Bazar-Sulaymaniyah,IRAQ </p>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;color:blue;'> Accountant / " + Form1.us + "<br> </p>");
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>if you have any question concering this invoice please contact <br>096407729790070 – 096407512330605<br>acc@onlineco.net<br>PS:Transfer fees should not effect on the invoice amount</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h4 align=center style='font-size:14px;'>   Kalar Bazar - Talari M. Mahmoud -  3nd floor, Sulaymaniyah, IRAQ -    Tel: 07711550366 - 07502478020</h4>");

            easyHTMLReports1.ShowPrintPreviewDialog();


        }

        private void datagridview6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview6.SelectedRows.Count != 0)
                    {
                        int i = datagridview6.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview6.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `amer` WHERE aid='" + id + "'");
                            ob.table(datagridview6, "call select_amer();");
                            ob.count(label43, datagridview6, 0);

                        }
                        else
                        {
                            ob.table(datagridview6, "call select_amer();");
                            ob.count(label43, datagridview6, 0);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void dwasl_TextChanged(object sender, EventArgs e)
        {
            if (dwasl.Text != "" && dwasl.Text != "0")
            {

                con.Close();
                con.Open();
                MySqlCommand md = new MySqlCommand("SELECT * FROM `mb_sell` where wasl='" + dwasl.Text + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                while (rd.Read())
                {
                    cuscom.SelectedValue = rd.GetString("ccid");

                }
                con.Close();
                ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` and wasl='" + dwasl.Text + "' order by mbids desc");
                ob.sum(label245, datagridcus, 1);
                ob.sum(label243, datagridcus, 3);
            }
            else
            {

                ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` order by mbids desc");
                ob.sum(label245, datagridcus, 1);
                ob.sum(label243, datagridcus, 3);

            }
        }

        private void com_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void waslbs_TextChanged(object sender, EventArgs e)
        {
            if (waslbs.Text != "")
            {
                ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', `price` AS 'نرخ', `sump` AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic and wasl='" + waslbs.Text + "'");
                ob.sum(label215, datagridbmp, 1);
                ob.sum(label204, datagridbmp, 3);

            }
            else
            {
                ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', `price` AS 'نرخ', `sump` AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic");
                ob.sum(label215, datagridbmp, 1);
                ob.sum(label204, datagridbmp, 3);


            }
        }

        private void materialSingleLineTextField30_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField30.Text != "")
            {


                ob.table(datagridview10, "SELECT `ahid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی دراو', `qarz` as 'قەرز', DATE_FORMAT(dates, '%Y/%m/%d') as 'بەروار', `aname` as 'ئامێر', `name` as 'کۆمپانیا', `wasl` as 'وەسڵ',maxzan as 'کۆگا', `tebene` as 'تێبینی' FROM `amer_hatu_info` where wasl like'" + materialSingleLineTextField30.Text + "%'");
                ob.sum(label69, datagridview10, 2);
                ob.sum(label71, datagridview10, 3);


            }
            else
            {
                ob.table(datagridview10, "call select_amer_hatu_info();");
                ob.sum(label69, datagridview10, 2);
                ob.sum(label71, datagridview10, 3);


            }
        }

        private void sumpd_TextChanged(object sender, EventArgs e)
        {
            if (sumpd.Text != "")
            {

                sump.Text = (Convert.ToDouble(sumpd.Text) / online.draw.dolar).ToString();
            }
            else
            {
                sump.Text = "0";

            }
        }

        private void pricef_Click(object sender, EventArgs e)
        {

        }

        private void label101_Click(object sender, EventArgs e)
        {

        }

        private void sumpdf_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField31_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (materialSingleLineTextField31.Text != "")
                {

                    ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(dates, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid and wasl like '" + materialSingleLineTextField31.Text + "%'");

                    mushtary.Text = datagridview13.Rows[0].Cells[8].Value.ToString();
                    ob.sum(label91, datagridview13, 2);
                    ob.sum(label86, datagridview13, 3);

                }
                else
                {

                    ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(dates, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid");
                    ob.sum(label91, datagridview13, 2);
                    ob.sum(label86, datagridview13, 3);
                }
            }
            catch (Exception)
            {

            }
        }

        private void sumpdb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void nrxmbp_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox1.Checked != true)
                {
                    if (adadmbp.Text != "" && nrxmbp.Text != "")
                    {
                        materialSingleLineTextField47.Text = (Convert.ToDouble(nrxmbp.Text) * Convert.ToDouble(adadmbp.Text)).ToString();

                    }
                    else
                    {

                        materialSingleLineTextField47.Text = "0";
                    }


                    materialSingleLineTextField46.Text = (Convert.ToDouble(materialSingleLineTextField47.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (adadmbp.Text != "" && nrxmbp.Text != "")
                    {
                        materialSingleLineTextField46.Text = (Convert.ToDouble(nrxmbp.Text) * Convert.ToDouble(adadmbp.Text)).ToString();
                        materialSingleLineTextField47.Text = (Convert.ToDouble(materialSingleLineTextField46.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        materialSingleLineTextField46.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud  3nd floor <br> Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + mushtary.Text + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cid='" + mushtary.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Invoice</i></h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + materialSingleLineTextField31.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Device</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >Number</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Price</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Amount</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Received money</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Debt</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Date</th>");
            easyHTMLReports1.AddString("</tr>");

            for (int i = 0; i < datagridview13.Rows.Count - 1; i++)
            {
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview13.Rows[i].Cells[7].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;' >" + datagridview13.Rows[i].Cells[2].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview13.Rows[i].Cells[1].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridview13.Rows[i].Cells[3].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + datagridview13.Rows[i].Cells[4].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + datagridview13.Rows[i].Cells[5].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>$" + datagridview13.Rows[i].Cells[6].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("</tr>");

            }



            easyHTMLReports1.AddString("</table>");

            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>$" + label86.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Total:</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label91.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Sum:</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Dear Client <br>Please Proceed with the payment within 4 days<br>Online Company accept cash payment delivered to the Kalar Bazar-Sulaymaniyah,IRAQ </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>if you have any question concering this invoice please contact <br>096407729790070 – 096407512330605<br>acc@onlineco.net");
            easyHTMLReports1.ShowPrintPreviewDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud  3nd floor <br>Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + brekar.Text + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `customer` where cid='" + brekar.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'><i>Invoice</i></h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + waslkartp.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>Your Ref# <br>Our Ref# <br> Credit Terms# <br> Salesperson  " + Form1.us + "<br> Job code </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>balance</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >Number</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Unit Price</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Amount</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Cash</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Debt</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>date</th>");
            easyHTMLReports1.AddString("</tr>");

            for (int i = 0; i < datagridbmp.Rows.Count - 1; i++)
            {

                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[7].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[2].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[1].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[3].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[4].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[5].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + datagridbmp.Rows[i].Cells[6].Value.ToString() + "</td>");
                easyHTMLReports1.AddString("</tr>");

            }

            easyHTMLReports1.AddString("</table>");

            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>$" + label173.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Total:</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label177.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Sum:</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Dear Client <br>Please Proceed with the payment within 4 days<br>Online Company accept cash payment delivered to the Kalar Bazar-Sulaymaniyah,IRAQ </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>if you have any question concering this invoice please contact <br>096407729790070 – 096407512330605<br>acc@onlineco.net");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void waslkartp_TextChanged(object sender, EventArgs e)
        {

        }

        private void givemonecus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (givemonecus.SelectedRows.Count != 0)
                    {
                        int i = givemonecus.SelectedRows[0].Index;
                        int id = Convert.ToInt32(givemonecus.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `give_cus_company` WHERE `qncid`='" + id + "'");
                            ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', give_cus_company.`qarzdinar` AS 'بڕی پارە',DATE_FORMAT(give_cus_company.`dates`, '%Y/%m/%d')  AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid");
                            ob.sum(label268, givemonecus, 1);

                        }
                        else
                        {
                            ob.table(givemonecus, "SELECT give_cus_company.`qncid` AS '#', give_cus_company.`qarzdinar` AS 'بڕی پارە', DATE_FORMAT(give_cus_company.`dates`, '%Y/%m/%d') AS 'بەروار', cus_company.`name` AS 'کۆمپانیا', give_cus_company.`wasl` AS 'ژ.وەسڵ', give_cus_company.`tebene` AS 'تێبینی' FROM `give_cus_company`,cus_company where give_cus_company.cid=cus_company.ccid");
                            ob.sum(label268, givemonecus, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridcus_SelectionChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            ob.change_datagridview_combo(datagridcus, cuscom, 6);
            ob.change_datagridview_textfild(datagridcus, numfcus, 1);
            ob.change_datagridview_textfild(datagridcus, nrxfcus, 2);
            ob.change_datagridview_picker(datagridcus, dateTimePicker40, 4);
            ob.change_datagridview_picker(datagridcus, barwarfcus, 5);
            ob.change_datagridview_textfild(datagridcus, zhw, 7);
            ob.change_datagridview(datagridcus, textBox4, 8);
            try
            {
                if (datagridcus.SelectedRows.Count != 0)
                {
                    int i = datagridcus.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridcus.Rows[i].Cells[0].Value.ToString());
                    con.Open();
                    MySqlCommand md = new MySqlCommand("SELECT * FROM `qarz_cus_comp` WHERE msell='" + id + "'", con);
                    MySqlDataReader rd = md.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            qarzfcus.Checked = true;

                        }
                    }
                    else
                    {

                        qarzfcus.Checked = false;
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {


            }

        }

        private void pictureBox123_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridcus.SelectedRows.Count != 0)
                {
                    int i = datagridcus.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridcus.Rows[i].Cells[0].Value.ToString());
                    double adad = Convert.ToDouble(datagridcus.Rows[i].Cells[1].Value.ToString());
                    if (MessageBox.Show("دڵنیای لە گۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ob.insert_del_up("DELETE FROM `qarz_cus_comp` WHERE msell='" + id + "'");
                        ob.insert_del_up("DELETE FROM `mb_sell` WHERE `mbids`='" + id + "'");
                        ob.insert_del_up("DELETE FROM `waslmega` WHERE `idms`='" + id + "'");
                        ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`+'" + adad + "'");

                        int days = DateTime.DaysInMonth(dateTimePicker40.Value.Year, dateTimePicker40.Value.Month);

                        DateTime start = Convert.ToDateTime(dateTimePicker40.Text);
                        DateTime finish = Convert.ToDateTime(barwarfcus.Text);
                        TimeSpan difference = finish.Subtract(start);
                        double sumnrx = Convert.ToDouble(materialSingleLineTextField51.Text);
                        double nrx = 0;

                        if (checkBox2.Checked != true)
                        {
                            nrx = Convert.ToDouble(nrxfcus.Text);
                        }
                        else
                        {
                            nrx = Convert.ToDouble(nrxfcus.Text) / online.draw.dolar;
                        }
                        double amou = 0;
                        int dif = Convert.ToInt16(difference.Days) + 1;

                        if (days != dif)
                        {
                            double m = sumnrx / days;
                            amou = m * dif;

                            ob.insert_del_up("INSERT INTO `mb_sell`(mbids,`nomb`, `price`, `sump`, `dates1`, `dates`, `ccid`, `wasl`, `tebene`) VALUES ('" + id + "','" + numfcus.Text + "','" + nrx + "','" + amou + "','" + dateTimePicker40.Text + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "','" + zhw.Text + "','" + textBox4.Text + "')");

                            ob.insert_del_up("INSERT INTO `waslmega`( `wasl`, `dis`, `daym`, `days`, `quantity`, `unit`, `amount`,idms) VALUES ('" + zhw.Text + "','" + textBox4.Text + "','" + days + "','" + dif + "','" + numfcus.Text + "','" + nrx + "','" + amou + "','" + id + "')");
                            if (qarzfcus.Checked == true)
                            {

                                ob.insert_del_up("INSERT INTO `qarz_cus_comp`(`qarzdinar`, `dates`, `ccid`, `msell`) VALUES  ('" + amou + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "','" + id + "')");

                            }
                        }
                        else
                        {

                            ob.insert_del_up("INSERT INTO `mb_sell`(mbids,`nomb`, `price`, `sump`, `dates1`, `dates`, `ccid`, `wasl`, `tebene`) VALUES ('" + id + "','" + numfcus.Text + "','" + nrx + "','" + sumnrx + "','" + dateTimePicker40.Text + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "','" + zhw.Text + "','" + textBox4.Text + "')");

                            ob.insert_del_up("INSERT INTO `waslmega`( `wasl`, `dis`, `daym`, `days`, `quantity`, `unit`, `amount`,idms) VALUES ('" + zhw.Text + "','" + textBox4.Text + "','" + days + "','" + dif + "','" + numfcus.Text + "','" + nrx + "','" + sumnrx + "','" + id + "')");
                            if (qarzfcus.Checked == true)
                            {

                                ob.insert_del_up("INSERT INTO `qarz_cus_comp`(`qarzdinar`, `dates`, `ccid`, `msell`) VALUES  ('" + sumnrx + "','" + barwarfcus.Text + "','" + cuscom.SelectedValue.ToString() + "','" + id + "')");

                            }
                        }

                        ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`-'" + numfcus.Text + "'");


                        ob.a(this.Controls);
                        ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` order by mbids desc");
                        ob.sum(label245, datagridcus, 1);
                        ob.sum(label243, datagridcus, 2);

                    }
                    else
                    {
                        ob.table(datagridcus, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', cus_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `mb_sell`,cus_company where mb_sell.`ccid`=cus_company.`ccid` order by mbids desc");
                        ob.sum(label245, datagridcus, 1);
                        ob.sum(label243, datagridcus, 2);
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void datagridbmp_SelectionChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            ob.change_datagridview_combo(datagridbmp, com, 6);
            ob.change_datagridview_textfild(datagridbmp, adadmbp, 1);
            ob.change_datagridview_textfild(datagridbmp, nrxmbp, 2);
            ob.change_datagridview_picker(datagridbmp, barwarst, 4);
            ob.change_datagridview_picker(datagridbmp, barwarmbp, 5);
            ob.change_datagridview_textfild(datagridbmp, waslb, 7);
            ob.change_datagridview(datagridbmp, textBox5, 8);
            try
            {
                if (datagridbmp.SelectedRows.Count != 0)
                {
                    int i = datagridbmp.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridbmp.Rows[i].Cells[0].Value.ToString());
                    con.Open();
                    MySqlCommand md = new MySqlCommand("SELECT * FROM `qarz_isp_comp` WHERE mbp='" + id + "'", con);
                    MySqlDataReader rd = md.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            qarzmbp.Checked = true;

                        }
                    }
                    else
                    {

                        qarzmbp.Checked = false;
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {


            }

        }

        private void adadmbp_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox1.Checked != true)
                {
                    if (adadmbp.Text != "" && nrxmbp.Text != "")
                    {
                        materialSingleLineTextField47.Text = (Convert.ToDouble(nrxmbp.Text) * Convert.ToDouble(adadmbp.Text)).ToString();

                    }
                    else
                    {

                        materialSingleLineTextField47.Text = "0";
                    }


                    materialSingleLineTextField46.Text = (Convert.ToDouble(materialSingleLineTextField47.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (adadmbp.Text != "" && nrxmbp.Text != "")
                    {
                        materialSingleLineTextField46.Text = (Convert.ToDouble(nrxmbp.Text) * Convert.ToDouble(adadmbp.Text)).ToString();
                        materialSingleLineTextField47.Text = (Convert.ToDouble(materialSingleLineTextField46.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        materialSingleLineTextField46.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void pictureBox124_Click(object sender, EventArgs e)
        {
            try
            {
                if (datagridbmp.SelectedRows.Count != 0)
                {
                    int i = datagridbmp.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridbmp.Rows[i].Cells[0].Value.ToString());
                    double adad = Convert.ToDouble(datagridbmp.Rows[i].Cells[1].Value.ToString());

                    if (MessageBox.Show("دڵنیای لە گۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ob.insert_del_up("DELETE FROM `hesab_isp` WHERE qarzid='" + id + "'");
                        ob.insert_del_up("DELETE FROM `qarz_isp_comp` WHERE mbp='" + id + "'");
                        ob.insert_del_up("DELETE FROM `mb_buy` WHERE `mbid`='" + id + "'");
                        ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`-'" + adad + "'");



                        int days = DateTime.DaysInMonth(barwarst.Value.Year, barwarst.Value.Month);
                        DateTime start = Convert.ToDateTime(barwarst.Text);
                        DateTime finish = Convert.ToDateTime(barwarmbp.Text);
                        TimeSpan difference = finish.Subtract(start);
                        double sumnrx = 0;
                        double nr = 0;
                        if (checkBox1.Checked == true)
                        {
                            nr = Convert.ToDouble(nrxmbp.Text) / dolar;
                            sumnrx = Convert.ToDouble(adadmbp.Text) * nr;
                        }
                        else
                        {
                            sumnrx = Convert.ToDouble(adadmbp.Text) * Convert.ToDouble(nrxmbp.Text);
                        }
                        int dif = Convert.ToInt16(difference.Days) + 1;
                        if (days != dif)
                        {
                            double m = sumnrx / days;
                            sumnrx = m * dif;

                        }

                        if (checkBox1.Checked == true)
                        {

                            ob.insert_del_up("INSERT INTO `mb_buy`(mbid,`nomb`, `price`,`sump`, `dates1`, `dates`, `ic`, `wasl`, `tebene`) VALUES ('" + id + "','" + adadmbp.Text + "','" + nr + "','" + sumnrx + "','" + barwarst.Text + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "','" + waslb.Text + "','" + textBox5.Text + "')");

                        }
                        else
                        {
                            ob.insert_del_up("INSERT INTO `mb_buy`(mbid,`nomb`, `price`,`sump`, `dates1`, `dates`, `ic`, `wasl`, `tebene`) VALUES ('" + id + "','" + adadmbp.Text + "','" + nrxmbp.Text + "','" + sumnrx + "','" + barwarst.Text + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "','" + waslb.Text + "','" + textBox5.Text + "')");

                        }
                        ob.insert_del_up("UPDATE `mb_store` SET `nomb`=`nomb`+'" + adadmbp.Text + "'");
                        if (qarzmbp.Checked == true)
                        {

                            ob.insert_del_up("INSERT INTO `qarz_isp_comp`(`qarzdinar`, `dates`, `ic`,`mbp`) VALUES ('" + sumnrx + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "','" + id + "')");
                            ob.insert_del_up("INSERT INTO `hesab_isp`(`br`, `barwar`, `cid`,`qarzid`) VALUES ('" + sumnrx + "','" + barwarmbp.Text + "','" + com.SelectedValue.ToString() + "','" + id + "')");

                        }





                        ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', format(`price`,2) AS 'نرخ', format(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic order by mbid desc");
                        ob.sum(label215, datagridbmp, 1);
                        ob.sum(label204, datagridbmp, 2);
                        con.Open();
                        MySqlCommand md = new MySqlCommand("SELECT `nomb` FROM `mb_store`", con);
                        MySqlDataReader rd = md.ExecuteReader();
                        while (rd.Read())
                        {
                            label319.Text = rd.GetString("nomb");

                        }

                        con.Close();
                    }
                    else
                    {
                        ob.table(datagridbmp, "SELECT `mbid` AS '#', `nomb` AS 'بڕی مێگا', format(`price`,2) AS 'نرخ', `types` AS 'جۆر', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', ispcompany.`name` AS 'کۆمپانیایisp ',wasl as 'ژ.وەسڵ',tebene as 'تێبینی' FROM `mb_buy`,ispcompany where mb_buy.ic=ispcompany.ic");
                        ob.sum(label215, datagridbmp, 1);
                        ob.sum(label204, datagridbmp, 2);
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void materialSingleLineTextField32_TextChanged(object sender, EventArgs e)
        {

        }

        private void datagridview11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview11.SelectedRows.Count != 0)
                    {
                        int i = datagridview11.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview11.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from storage_amer where id='" + id + "'");
                            ob.table(datagridview11, "call select_storage_amer();");
                            ob.sum(label78, datagridview11, 2);


                        }
                        else
                        {
                            ob.table(datagridview11, "call select_storage_amer();");
                            ob.sum(label78, datagridview11, 2);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridview21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview21.SelectedRows.Count != 0)
                    {
                        int i = datagridview21.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview21.Rows[i].Cells[0].Value.ToString());
                        String stat = datagridview21.Rows[i].Cells[5].Value.ToString();

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (stat == "قبوڵکراو")
                            {

                                con.Open();
                                MySqlCommand mss = new MySqlCommand("SELECT * FROM `dawakary_balance` WHERE `id`='" + id + "'", con);
                                MySqlDataReader rd = mss.ExecuteReader();
                                String adad = "";
                                String kart = "";
                                String cus = "";
                                String wasl = "";
                                String dates = "";
                                if (rd.Read())
                                {
                                    adad = rd.GetString("adad");
                                    kart = rd.GetString("kart");
                                    cus = rd.GetString("cus");
                                    wasl = rd.GetString("wasl");
                                    dates = rd.GetString("barwar");

                                }
                                con.Close();

                                // we must delete balance_roshto
                                // print()
                                ob.insert_del_up("delete from balance_roshto where wasl='" + wasl + "'");
                                ob.insert_del_up("call insert_storage_kart('" + kart + "','" + adad + "','" + datagridview21.Rows[i].Cells[3].Value.ToString() + "')");
                                ob.insert_del_up("call delete_storage_kart_customer('" + kart + "','" + adad + "','" + cus + "')");
                                ob.insert_del_up("delete from dawakary_balance where id='" + id + "'");
                            }
                            ob.insert_del_up("delete from dawakary_balance where id='" + id + "'");

                            ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl='" + wasldk + "'");

                            ob.sum(label167, datagridview21, 2);

                        }
                        else
                        {
                            ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl='" + wasldk + "'");

                            ob.sum(label167, datagridview21, 2);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridview14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview14.SelectedRows.Count != 0)
                    {
                        int i = datagridview14.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview14.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from qarz where qid='" + id + "'");
                            ob.table(datagridview14, "SELECT qarz.`qid` AS '#', qarz.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz.dates, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', customer.`types` AS 'جۆری بریکار' FROM `qarz` join customer on(customer.`cid`=qarz.cid)");
                            ob.sum(label106, datagridview14, 1);


                        }
                        else
                        {
                            ob.table(datagridview14, "SELECT qarz.`qid` AS '#', qarz.`qarzdinar` AS 'بڕی قەرز', DATE_FORMAT(qarz.dates, '%Y/%m/%d') AS 'بەروار', customer.`cname` AS 'بریکار', customer.`types` AS 'جۆری بریکار' FROM `qarz` join customer on(customer.`cid`=qarz.cid)");
                            ob.sum(label106, datagridview14, 1);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridview19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview19.SelectedRows.Count != 0)
                    {
                        int i = datagridview19.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview19.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from masrufatwakel where mwid='" + id + "'");
                            ob.table(datagridview19, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ',DATE_FORMAT(masrufatwakel.dates, '%Y/%m/%d') AS 'بەروار',customer.cname AS 'بریکار', masrufatwakel.`comment` AS 'تێبینی' FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid");
                            ob.sum(label153, datagridview19, 1);


                        }
                        else
                        {
                            ob.table(datagridview19, "SELECT masrufatwakel.`mwid` AS '#', masrufatwakel.`amount` AS 'بڕی پارە', masrufatwakel.`zwasl` AS 'ژمارە وەسڵ', DATE_FORMAT(masrufatwakel.`dates`, '%Y/%m/%d') AS 'بەروار',customer.cname AS 'بریکار', masrufatwakel.`comment` AS 'تێبینی' FROM `masrufatwakel`,customer where masrufatwakel.cid=customer.cid");
                            ob.sum(label153, datagridview19, 1);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void data29_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cusdataqarz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (cusdataqarz.SelectedRows.Count != 0)
                    {
                        int i = cusdataqarz.SelectedRows[0].Index;
                        int id = Convert.ToInt32(cusdataqarz.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from qarz_cus_comp where qccid='" + id + "'");
                            ob.table(cusdataqarz, "SELECT `qccid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', cus_company.name AS 'کۆمپانیا' FROM `qarz_cus_comp`,cus_company where qarz_cus_comp.ccid=cus_company.ccid");
                            ob.sum(label257, cusdataqarz, 1);


                        }
                        else
                        {
                            ob.table(cusdataqarz, "SELECT `qccid` AS '#', `qarzdinar` AS 'برێ پارە', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', cus_company.name AS 'کۆمپانیا' FROM `qarz_cus_comp`,cus_company where qarz_cus_comp.ccid=cus_company.ccid");
                            ob.sum(label257, cusdataqarz, 1);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void datagridview15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview15.SelectedRows.Count != 0)
                    {
                        int i = datagridview15.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview15.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from qarz_net_comp where qncid='" + id + "'");
                            ob.table(datagridview15, "SELECT qarz_net_comp.`qncid` AS '#', qarz_net_comp.`qarzdinar` AS 'بڕی قەرز',DATE_FORMAT(qarz_net_comp.`dates`, '%Y/%m/%d')  AS 'بەروار', net_company.name AS 'کۆمپانیا' FROM `qarz_net_comp`,net_company where qarz_net_comp.ncid=net_company.ncid");
                            ob.sum(label113, datagridview15, 1);


                        }
                        else
                        {
                            ob.table(datagridview15, "SELECT qarz_net_comp.`qncid` AS '#', qarz_net_comp.`qarzdinar` AS 'بڕی قەرز',DATE_FORMAT(qarz_net_comp.`dates`, '%Y/%m/%d') AS 'بەروار', net_company.name AS 'کۆمپانیا' FROM `qarz_net_comp`,net_company where qarz_net_comp.ncid=net_company.ncid");
                            ob.sum(label113, datagridview15, 1);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void materialSingleLineTextField32_TextChanged_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField32.Text != "")
            {

                plus.Text = (Convert.ToDouble(materialSingleLineTextField32.Text) * 3000).ToString();

            }
        }

        private void pictureBox125_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox126_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField34_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (materialSingleLineTextField34.Text != "")
                {

                    br.Text = (Convert.ToDouble(materialSingleLineTextField34.Text) / online.draw.dolar).ToString();
                }
                else
                {
                    br.Text = "0";

                }
            }
            catch (Exception)
            {


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ob.table(ispdataqarz, "select `online`.`hesab_isp`.`id` AS `#`,sum(`online`.`hesab_isp`.`br`) AS `بڕی قەرز`,`online`.`ispcompany`.`name` AS `کۆمپانیا` from (`online`.`hesab_isp` join `online`.`ispcompany`) where `online`.`hesab_isp`.`cid` = `online`.`ispcompany`.`ic` and  barwar between '" + dateTimePicker20.Text + "' and '" + dateTimePicker21.Text + "' group by `online`.`hesab_isp`.`cid`");
            //ob.sum(label228, ispdataqarz, 1);
            //easyHTMLReports1.Clear();
            //easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            //easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            //easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>isp Loan</h2>");
            //easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            //easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            //easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>#</th>");
            //easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >amount</th>");
            //easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>company</th>");
            //easyHTMLReports1.AddString("</tr>");

            //for (int i = 0; i < ispdataqarz.Rows.Count - 1; i++)
            //{

            //    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
            //    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + ispdataqarz.Rows[i].Cells[0].Value.ToString() + "</td>");
            //    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + ispdataqarz.Rows[i].Cells[1].Value.ToString() + "</td>");
            //    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:white; font-size:14px;'>" + ispdataqarz.Rows[i].Cells[2].Value.ToString() + "</td>");

            //    easyHTMLReports1.AddString("</tr>");

            //}

            //easyHTMLReports1.AddString("</table>");

            //easyHTMLReports1.AddLineBreak();
            //easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>$" + label228.Text + "</p>");
            //easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Total:</p>");
            //easyHTMLReports1.ShowPrintPreviewDialog();
            //ob.table(ispdataqarz, "SELECT `qicid` AS '#', `qarzdinar` AS 'برێ پارە', `dates` AS 'بەروار', ispcompany.name AS 'isp کۆمپانیای' FROM `qarz_isp_comp`,ispcompany where qarz_isp_comp.ic=ispcompany.ic");
            //ob.sum(label228, ispdataqarz, 1);
        }

        private void tabPage26_Click(object sender, EventArgs e)
        {

        }

        private void کارتیفرۆشراویبریکارToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 33;
            ob.table(data35, "SELECT `brid` AS '#', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',customer.cname as 'بریکار',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid group by froshtn_amer.wasl");
            ob.sum(label359, data35, 2);
            ob.sum(label353, data35, 3);
        }

        private void data35_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data35);
            ob.sum(label359, data35, 2);
            ob.sum(label353, data35, 4);
        }

        private void data35_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data35);
            ob.sum(label359, data35, 2);
            ob.sum(label353, data35, 4);
        }

        private void pictureBox128_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox125_Click_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField40.Text != "")
            {
                ob.table(data35, "SELECT `brid` AS '#', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',customer.cname as 'بریکار',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and customer.cname like '" + materialSingleLineTextField40.Text + "%' and dates between '" + dateTimePicker41.Text + "' and '" + dateTimePicker42.Text + "' group by customer.cname");
                ob.sum(label359, data35, 2);
                ob.sum(label353, data35, 3);

            }
            else
            {

                ob.table(data35, "SELECT `brid` AS '#', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',customer.cname as 'بریکار',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and dates between '" + dateTimePicker41.Text + "' and '" + dateTimePicker42.Text + "' group by customer.cname");
                ob.sum(label359, data35, 2);
                ob.sum(label353, data35, 3);
            }

        }

        private void comboBox5_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void pictureBox127_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud  3nd floor <br>Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێری فرۆشراوی بریکار</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(data35, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label359.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label353.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox126_Click_1(object sender, EventArgs e)
        {
            ob.toexcel(data35);
        }

        private void فرۆشتنیرۆژانەیکارتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void فرۆشراوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 20;

        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void datag23_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            this.Hide();
            ob.Show();
        }

        private void materialSingleLineTextField36_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField37_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField37.Text != "")
            {
                ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid and customer.cname like '" + materialSingleLineTextField37.Text + "%'");
                ob.sum(label91, datagridview13, 2);
                ob.sum(label86, datagridview13, 3);

            }
            else
            {
                ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid");
                ob.sum(label91, datagridview13, 2);
                ob.sum(label86, datagridview13, 3);



            }
        }

        private void materialSingleLineTextField38_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField38.Text != "")
            {
                ob.table(data29, "SELECT `brid` AS '#',wasl as 'ژ.وەسڵ', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام',customer.cname as 'بریکار',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid and customer.cname like '" + materialSingleLineTextField38.Text + "%' group by wasl");
                ob.sum(label275, data29, 1);
                ob.sum(label277, data29, 2);

            }
            else
            {

                ob.table(data29, "SELECT `brid` AS '#',wasl as 'ژ.وەسڵ', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام',customer.cname as 'بریکار',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_kart`,balance,customer WHERE froshtn_kart.bid=balance.bid and froshtn_kart.cid=customer.cid group by wasl");
                ob.sum(label275, data29, 1);
                ob.sum(label277, data29, 2);
            }
            ob.setsepator(label275);
            ob.setsepator(label277);
        }

        private void data29_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (data29.SelectedRows.Count != 0)
                {
                    int i = data29.SelectedRows[0].Index;
                    int id = Convert.ToInt32(data29.Rows[i].Cells[0].Value.ToString());
                    wasla = "";
                    waslka = data29.Rows[i].Cells[5].Value.ToString();
                    ds = dateTimePicker28.Text;
                    dl = dateTimePicker29.Text;
                    detail obb = new detail();
                    obb.Show();
                }
            }

            catch (Exception)
            {


            }
        }

        private void materialSingleLineTextField39_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField40_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField40.Text != "")
            {
                ob.table(data35, "SELECT `brid` AS '#',wasl as 'ژ.وەسڵ', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',customer.cname as 'بریکار',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and customer.cname like '" + materialSingleLineTextField40.Text + "%' group by dates");
                ob.sum(label359, data35, 2);
                ob.sum(label353, data35, 3);

            }
            else
            {

                ob.table(data35, "SELECT `brid` AS '#',wasl as 'ژ.وەسڵ', sum(`num`) AS 'عەدەد',sum(`sumprice`) AS 'کۆی نرخ',customer.cname as 'بریکار',DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid group by dates");
                ob.sum(label359, data35, 2);
                ob.sum(label353, data35, 3);
            }
        }

        private void materialSingleLineTextField41_TextChanged(object sender, EventArgs e)
        {

        }

        private void data35_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (data35.SelectedRows.Count != 0)
                {
                    int i = data35.SelectedRows[0].Index;
                    int id = Convert.ToInt32(data35.Rows[i].Cells[0].Value.ToString());
                    waslka = "";
                    wasla = data35.Rows[i].Cells[3].Value.ToString();
                    ds = dateTimePicker41.Text;
                    dl = dateTimePicker42.Text;
                    detail obb = new detail();
                    obb.Show();
                }
            }

            catch (Exception)
            {


            }
        }

        private void datagridview19_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (datagridview19.SelectedRows.Count != 0)
                {
                    int i = datagridview19.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridview19.Rows[i].Cells[0].Value.ToString());
                    ds = dateTimePicker15.Text;
                    dl = dateTimePicker16.Text;
                    nawbrekar = datagridview19.Rows[i].Cells[3].Value.ToString();
                    masrafdetail obb = new masrafdetail();
                    obb.Show();
                }
            }

            catch (Exception)
            {


            }
        }

        private void brekarmasraf_TextChanged(object sender, EventArgs e)
        {
        }

        private void materialSingleLineTextField42_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField42.Text != "")
            {

                ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',maxzan as 'کۆگا', `wasl` as 'وەسڵ', `state` as 'حاڵەت' FROM `dawakary_amer_view` where wasl like '" + materialSingleLineTextField42.Text + "%' group by wasl");
                ob.sum(label365, data36, 1);
            }
            else
            {

                ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',maxzan as 'کۆگا', `wasl` as 'وەسڵ', `state` as 'حاڵەت' FROM `dawakary_amer_view` group by wasl");
                ob.sum(label365, data36, 1);
            }

        }

        private void materialSingleLineTextField43_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField35_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField35.Text != "")
            {
                ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',maxzan as 'کۆگا', `wasl` as 'وەسڵ', `state` as 'حاڵەت' FROM `dawakary_amer_view` where cname like '" + materialSingleLineTextField35.Text + "%' group by wasl");
                ob.sum(label365, data36, 1);
            }
            else
            {
                ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',maxzan as 'کۆگا', `wasl` as 'وەسڵ', `state` as 'حاڵەت' FROM `dawakary_amer_view` group by wasl");
                ob.sum(label365, data36, 1);

            }
        }

        private void pictureBox129_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField35.Text != "")
            {
                ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',maxzan as 'کۆگا', `wasl` as 'وەسڵ', `state` as 'حاڵەت' FROM `dawakary_amer_view` where cname like '" + materialSingleLineTextField35.Text + "%' and barwar between '" + dateTimePicker43.Text + "' and '" + dateTimePicker44.Text + "' group by wasl");
                ob.sum(label365, data36, 1);
            }
            else
            {
                ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',maxzan as 'کۆگا', `wasl` as 'وەسڵ', `state` as 'حاڵەت' FROM `dawakary_amer_view` where barwar between '" + dateTimePicker43.Text + "' and '" + dateTimePicker44.Text + "' group by wasl");
                ob.sum(label365, data36, 1);

            }
        }

        private void pictureBox128_Click_1(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud  3nd floor <br>Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");
            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێری داواکراو</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(data36, "style='width:100%;  direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label365.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox108_Click_1(object sender, EventArgs e)
        {
            ob.toexcel(data36);
        }

        private void data36_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (data36.SelectedRows.Count != 0)
                {
                    int i = data36.SelectedRows[0].Index;
                    int id = Convert.ToInt32(data36.Rows[i].Cells[0].Value.ToString());
                    String waslda = data36.Rows[i].Cells[5].Value.ToString();
                    String koga = data36.Rows[i].Cells[4].Value.ToString();
                    String cus = data36.Rows[i].Cells[3].Value.ToString();
                    materialTabControl1.SelectedIndex = 10;
                    ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت',maxzan as 'کۆگا', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                    ob.sum(label87, datagridview12, 2);
                    ob.comb(brykarfield, "SELECT * FROM customer", "cid", "cname");
                    ob.comb(amerfield, "SELECT * FROM amer", "aid", "aname");
                    waslfield.Text = waslda;
                    kogafield.ResetText();
                    brykarfield.ResetText();
                    kogafield.SelectedText = koga;
                    comboBox9.SelectedText = koga;
                    brykarfield.SelectedText = cus;
                    barwarf.Text = DateTime.Now.ToString("yyyy/MM/dd");
                }
            }

            catch (Exception)
            {


            }
        }

        private void datagridview12_DockChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField44_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField44.Text != "")
            {
                ob.table(data37, "SELECT `id` as '#', sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where cname like '" + materialSingleLineTextField44.Text + "%' group by wasl");
                ob.sum(label372, data37, 1);

            }
            else
            {

                ob.table(data37, "SELECT `id` as '#', sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` group by wasl");
                ob.sum(label372, data37, 1);
            }
        }

        private void materialSingleLineTextField43_TextChanged_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField43.Text != "")
            {
                ob.table(data37, "SELECT `id` as '#', sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl like '" + materialSingleLineTextField43.Text + "%' group by wasl");
                ob.sum(label372, data37, 1);

            }
            else
            {

                ob.table(data37, "SELECT `id` as '#', sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` group by wasl");
                ob.sum(label372, data37, 1);
            }
        }

        private void pictureBox130_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField44.Text != "")
            {
                ob.table(data37, "SELECT `id` as '#', sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where cname like '" + materialSingleLineTextField44.Text + "%' and barwar between '" + dateTimePicker45.Text + "' and '" + dateTimePicker46.Text + "' group by wasl");
                ob.sum(label372, data37, 1);

            }
            else
            {

                ob.table(data37, "SELECT `id` as '#', sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where barwar between '" + dateTimePicker45.Text + "' and '" + dateTimePicker46.Text + "' group by wasl");
                ob.sum(label372, data37, 1);
            }
        }

        private void data37_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data37);
            ob.sum(label372, data37, 1);
        }

        private void data37_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data37);
            ob.sum(label372, data37, 1);
        }

        private void data37_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (data37.SelectedRows.Count != 0)
                {
                    int i = data37.SelectedRows[0].Index;
                    int id = Convert.ToInt32(data37.Rows[i].Cells[0].Value.ToString());
                    wasldk = data37.Rows[i].Cells[4].Value.ToString();
                    materialTabControl1.SelectedIndex = 19;
                    ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl='" + wasldk + "'");
                    ob.sum(label167, datagridview21, 2);

                }
            }

            catch (Exception)
            {


            }
        }

        private void data36_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data36);
        }

        private void data36_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data36);
        }

        private void datagridview12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datagridview12.SelectedRows.Count != 0)
                    {
                        int i = datagridview12.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datagridview12.Rows[i].Cells[0].Value.ToString());
                        String halat = datagridview12.Rows[i].Cells[6].Value.ToString();
                        double adad = Convert.ToDouble(datagridview12.Rows[i].Cells[2].Value.ToString());
                        String aname = datagridview12.Rows[i].Cells[1].Value.ToString();
                        String cname = datagridview12.Rows[i].Cells[5].Value.ToString();
                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from dawakary_amer where id='" + id + "'");
                            if (halat == "قبوڵکراو")
                            {
                                ob.insert_del_up("UPDATE `storage_amer_view` SET `number`=`number`+'" + adad + "' WHERE `aname`='" + aname + "'");
                                ob.insert_del_up("UPDATE `storage_amer_view_customer` SET `number`=`number`-'" + adad + "' WHERE cusname='" + cname + "' and `amern`='" + aname + "'");

                            }
                            ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                            ob.sum(label87, datagridview12, 2);


                        }
                        else
                        {
                            ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                            ob.sum(label87, datagridview12, 2);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox133_Click(object sender, EventArgs e)
        {

            try
            {
                if (datagridview13.SelectedRows.Count != 0)
                {
                    int i = datagridview13.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridview13.Rows[i].Cells[0].Value.ToString());
                    int aid = Convert.ToInt32(datagridview13.Rows[i].Cells[1].Value.ToString());
                    int num = Convert.ToInt32(datagridview13.Rows[i].Cells[2].Value.ToString());
                    double pric = Convert.ToDouble(datagridview13.Rows[i].Cells[3].Value.ToString());
                    if (MessageBox.Show("دڵنیای لە گۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ob.insert_del_up("DELETE FROM `qarz` WHERE `id_amer_roshtu`='" + id + "'");
                        ob.insert_del_up("DELETE FROM `amer_froshtn` WHERE `arid`='" + id + "'");
                        ob.insert_del_up("DELETE FROM `qarz` WHERE `id_amer_roshtu`='" + id + "'");

                        ob.insert_del_up("call insert_storage_amer('" + amerf.SelectedValue.ToString() + "','" + num + "','" + DateTime.Today.ToString("yyyy/MM/dd") + "')");
                        ob.insert_del_up("call delete_storage_amer_customer('" + amerf.SelectedValue.ToString() + "','" + num + "','" + mushtary.SelectedValue.ToString() + "')");
                        con.Open();

                        MySqlCommand md = new MySqlCommand("SELECT * FROM `storage_amer` WHERE aid='" + amerf.SelectedValue.ToString() + "'", con);
                        MySqlDataReader rd = md.ExecuteReader();
                        int n = 0;
                        int numm = Convert.ToInt16(numberf.Text);
                        while (rd.Read())
                        {

                            n = rd.GetInt16("number");
                        }
                        con.Close();
                        if (n < numm)
                        {
                            MessageBox.Show("بڕی ئامێری پێویست لە کۆگایا نییە");
                        }
                        else
                        {
                            ob.insert_del_up("INSERT INTO `amer_froshtn`(arid,`price`, `num`, `sump`, `money`, `qarz`, `dates`, `aid`, `cusid`,`wasl`, `burj`, `tebene`) VALUES ('" + id + "','" + pricef.Text + "','" + numberf.Text + "','" + sumpf.Text + "','" + moneyf.Text + "','" + qarzf.Text + "','" + dateTimePicker1.Text + "','" + amerf.SelectedValue.ToString() + "','" + mushtary.SelectedValue.ToString() + "','" + waslf.Text + "','" + materialSingleLineTextField33.Text + "','" + textBox7.Text + "')");

                            ob.insert_del_up("call delete_storage_amer('" + amerf.SelectedValue.ToString() + "','" + numberf.Text + "')");
                            ob.insert_del_up("call insert_storage_amer_customer('" + amerf.SelectedValue.ToString() + "','" + numberf.Text + "','" + mushtary.SelectedValue.ToString() + "','" + dateTimePicker1.Text + "')");

                            if (qarzf.Text != "" && qarzf.Text != "0")
                            {

                                ob.insert_del_up("call insert_qarz_customer('" + qarzf.Text + "','" + dateTimePicker1.Text + "','" + mushtary.SelectedValue.ToString() + "','" + id + "')");
                            }
                        }


                        ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid order by arid desc");
                        ob.sum(label91, datagridview13, 2);
                        ob.sum(label86, datagridview13, 3);

                    }
                    else
                    {
                        ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid order by arid desc");
                        ob.sum(label91, datagridview13, 2);
                        ob.sum(label86, datagridview13, 3);
                    }
                }
            }
            catch (Exception)
            {


            }






        }

        private void کارتیگەڕاوەToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 36;
            ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid");
            ob.sum(label378, datakartback, 1);
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 37;
            ob.table(dataamerback, "SELECT `wasl` as  'وەسڵ', sum(`number`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `state` as 'حاڵەت', customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  group by wasl;");
            ob.sum(label385, dataamerback, 2);
            ob.comb(comboBox15, "SELECT * FROM customer", "cid", "cname");
        }

        private void materialSingleLineTextField13_TextChanged_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField13.Text != "")
            {

                ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and customer.cname like '" + materialSingleLineTextField13.Text + "%'");
                ob.sum(label378, datakartback, 1);
            }
            else
            {

                ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid");
                ob.sum(label378, datakartback, 1);
            }
        }

        private void materialSingleLineTextField16_TextChanged_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField16.Text != "")
            {
                ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and wasl like '" + materialSingleLineTextField16.Text + "%'");
                ob.sum(label378, datakartback, 1);

            }
            else
            {
                ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid");
                ob.sum(label378, datakartback, 1);

            }
        }

        private void pictureBox134_Click(object sender, EventArgs e)
        {
            ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and dates between '" + dateTimePicker47.Text + "' and '" + dateTimePicker48.Text + "'");
            ob.sum(label378, datakartback, 1);
        }

        private void datakartback_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(datakartback);
            ob.sum(label378, datakartback, 1);
        }

        private void datakartback_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(datakartback);
            ob.sum(label378, datakartback, 1);
        }

        private void pictureBox135_Click(object sender, EventArgs e)
        {
            ob.toexcel(datakartback);
        }

        private void pictureBox136_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud  3nd <br>floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");
            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>لیستی کارتی گەڕاوە</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(datakartback, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label378.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void materialSingleLineTextField17_TextChanged_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField17.Text != "")
            {
                ob.table(dataamerback, "SELECT `wasl` as  'وەسڵ', sum(`number`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `state` as 'حاڵەت,customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid and customer.cname like '" + materialSingleLineTextField17.Text + "%' group by wasl;");

                ob.sum(label385, dataamerback, 2);
            }
            else
            {
                ob.table(dataamerback, "SELECT `wasl` as  'وەسڵ', sum(`number`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `state` as 'حاڵەت',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  group by wasl;");
                ob.sum(label385, dataamerback, 2);

            }
        }

        private void materialSingleLineTextField45_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField45.Text != "")
            {
                ob.table(dataamerback, "SELECT `wasl` as  'وەسڵ', sum(`number`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `state` as 'حاڵەت',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid and customer.cname like '" + materialSingleLineTextField45.Text + "%' group by wasl;");
                ob.sum(label385, dataamerback, 2);

            }
            else
            {
                ob.table(dataamerback, "SELECT `wasl` as  'وەسڵ', sum(`number`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `state` as 'حاڵەت',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  group by wasl;");
                ob.sum(label385, dataamerback, 2);

            }
        }

        private void pictureBox137_Click(object sender, EventArgs e)
        {
            ob.table(dataamerback, "SELECT `wasl` as  'وەسڵ', sum(`number`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `state` as 'حاڵەت', customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid and barwar between '" + dateTimePicker49.Text + "' and '" + dateTimePicker50.Text + "' group by wasl;");

            ob.sum(label385, dataamerback, 2);
        }

        private void pictureBox139_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud 3nd floor  <br>Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>لیستی ئامێری گەڕاوە</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(dataamerback, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label385.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox138_Click(object sender, EventArgs e)
        {
            ob.toexcel(dataamerback);
        }

        private void dataamerback_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(dataamerback);
            ob.sum(label385, dataamerback, 2);
        }

        private void dataamerback_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(dataamerback);
            ob.sum(label385, dataamerback, 2);
        }

        private void datakartback_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (datakartback.SelectedRows.Count != 0)
                {
                    int i = datakartback.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datakartback.Rows[i].Cells[0].Value.ToString());

                    String stat = datakartback.Rows[i].Cells[6].Value.ToString();
                    if (stat != "قبوڵکراو")
                    {

                        if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            con.Open();
                            MySqlCommand mss = new MySqlCommand("SELECT * FROM `balance_garawa` WHERE `brid`='" + id + "'", con);
                            MySqlDataReader rd = mss.ExecuteReader();
                            String adad = "";
                            String kart = "";
                            String cus = "";
                            String wasl = "";
                            String dates = "";
                            while (rd.Read())
                            {
                                adad = rd.GetString("num");
                                kart = rd.GetString("bid");
                                cus = rd.GetString("cid");
                                wasl = rd.GetString("wasl");
                                dates = rd.GetString("dates");

                            }
                            con.Close();
                            ob.insert_del_up("UPDATE `balance_garawa` SET `state`='قبوڵکراو' WHERE `brid`='" + id + "'");
                            ob.insert_del_up("call insert_storage_kart('" + kart + "','" + adad + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                            ob.insert_del_up("call delete_storage_kart_customer('" + kart + "','" + adad + "','" + cus + "')");
                            ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and dates between '" + dateTimePicker47.Text + "' and '" + dateTimePicker48.Text + "'");
                            ob.sum(label378, datakartback, 1);

                        }
                        else
                        {
                            ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and dates between '" + dateTimePicker47.Text + "' and '" + dateTimePicker48.Text + "'");
                            ob.sum(label378, datakartback, 1);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void datakartback_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (datakartback.SelectedRows.Count != 0)
                    {
                        int i = datakartback.SelectedRows[0].Index;
                        int id = Convert.ToInt32(datakartback.Rows[i].Cells[0].Value.ToString());

                        String stat = datakartback.Rows[i].Cells[6].Value.ToString();
                        if (MessageBox.Show("دڵنیای لە سڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (stat == "قبوڵکراو")
                            {
                                con.Open();
                                MySqlCommand mss = new MySqlCommand("SELECT * FROM `balance_garawa` WHERE `brid`='" + id + "'", con);
                                MySqlDataReader rd = mss.ExecuteReader();
                                String adad = "";
                                String kart = "";
                                String cus = "";
                                String wasl = "";
                                String dates = "";
                                while (rd.Read())
                                {
                                    adad = rd.GetString("num");
                                    kart = rd.GetString("bid");
                                    cus = rd.GetString("cid");
                                    wasl = rd.GetString("wasl");
                                    dates = rd.GetString("dates");

                                }
                                con.Close();
                                ob.insert_del_up("call delete_storage_kart('" + kart + "','" + adad + "')");
                                ob.insert_del_up("call insert_storage_kart_customer('" + kart + "','" + adad + "','" + cus + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                                ob.insert_del_up("DELETE FROM `balance_garawa` WHERE brid='" + id + "'");
                                ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and dates between '" + dateTimePicker47.Text + "' and '" + dateTimePicker48.Text + "'");
                                ob.sum(label378, datakartback, 1);
                            }
                            else
                            {
                                ob.insert_del_up("DELETE FROM `balance_garawa` WHERE brid='" + id + "'");
                                ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and dates between '" + dateTimePicker47.Text + "' and '" + dateTimePicker48.Text + "'");
                                ob.sum(label378, datakartback, 1);
                            }
                        }
                        else
                        {
                            ob.table(datakartback, "SELECT `brid` as '#', `num` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', balance.types as 'کارت',`wasl` as 'وەسڵ', `tebene` as 'تێبینی', `state` as 'حاڵەت',customer.cname as 'بریکار' FROM `balance_garawa`,balance,customer where balance.bid=balance_garawa.bid and balance_garawa.cid=customer.cid and dates between '" + dateTimePicker47.Text + "' and '" + dateTimePicker48.Text + "'");
                            ob.sum(label378, datakartback, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void dataamerback_KeyDown(object sender, KeyEventArgs e)
        {
            /* if (e.KeyCode == Keys.Delete)
             {
                 try
                 {
                     if (dataamerback.SelectedRows.Count != 0)
                     {
                         int i = dataamerback.SelectedRows[0].Index;
                         int id = Convert.ToInt32(dataamerback.Rows[i].Cells[0].Value.ToString());

                         String stat = dataamerback.Rows[i].Cells[5].Value.ToString();
                         if (MessageBox.Show("دڵنیای لە سڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                         {
                             if (stat == "قبوڵکراو")
                             {
                                 con.Open();
                                 MySqlCommand mss = new MySqlCommand("SELECT * FROM `amer_garawa` WHERE `id`='" + id + "'", con);
                                 MySqlDataReader rd = mss.ExecuteReader();
                                 String adad = "";
                                 String amer = "";
                                 String cus = "";
                                 String wasl = "";
                                 String dates = "";
                                 while (rd.Read())
                                 {
                                     adad = rd.GetString("number");
                                     amer = rd.GetString("aid");
                                     cus = rd.GetString("cus");
                                     wasl = rd.GetString("wasl");
                                     dates = rd.GetString("barwar");

                                 }
                                 con.Close();
                                 ob.insert_del_up("call delete_storage_amer('" + amer + "','" + adad + "')");
                                 ob.insert_del_up("call insert_storage_amer_customer('" + amer + "','" + adad + "','" + cus + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                                 ob.insert_del_up("DELETE FROM `amer_garawa` WHERE id='" + id + "'");
                                 ob.table(dataamerback, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid and barwar between '" + dateTimePicker49.Text + "' and '" + dateTimePicker50.Text + "'");
                                 ob.sum(label385, dataamerback, 2);
                             }
                             else
                             {
                                 ob.insert_del_up("DELETE FROM `amer_garawa` WHERE id='" + id + "'");
                                 ob.table(dataamerback, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid");
                                 ob.sum(label385, dataamerback, 2);
                             }
                         }
                         else
                         {
                             ob.table(dataamerback, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid");
                             ob.sum(label385, dataamerback, 2);
                         }
                     }
                 }
                 catch (Exception)
                 {


                 }
             }*/
        }

        private void dataamerback_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataamerback.SelectedRows.Count != 0)
                {
                    int i = dataamerback.SelectedRows[0].Index;
                    // int id = Convert.ToInt32(dataamerback.Rows[i].Cells[0].Value.ToString());
                    String waslda = dataamerback.Rows[i].Cells[0].Value.ToString();
                    String koga = dataamerback.Rows[i].Cells[5].Value.ToString();
                    String amer = dataamerback.Rows[i].Cells[1].Value.ToString();

                    String cus = dataamerback.Rows[i].Cells[4].Value.ToString();
                    String date = dataamerback.Rows[i].Cells[3].Value.ToString();
                    materialTabControl1.SelectedIndex = 50;
                    ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + waslda + "'");
                    ob.sum(label545, advancedDataGridView12, 2);
                    ob.comb(comboBox18, "SELECT * FROM customer", "cid", "cname");
                    ob.comb(comboBox20, "SELECT * FROM amer", "aid", "aname");
                    wasl55.Text = waslda;
                    comboBox20.ResetText();
                    comboBox18.ResetText();
                    comboBox19.ResetText();

                    comboBox19.SelectedText = amer;

                    comboBox19.SelectedText = koga;
                    comboBox18.SelectedText = cus;
                    dateTimePicker86.Text = DateTime.Parse(date).ToString("yyyy/MM/dd");
                }

            }
            catch (Exception)
            {


            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 39;

        }

        private void pictureBox140_Click(object sender, EventArgs e)
        {

            ob.table(advancedDataGridView1, "select types as 'جۆری کارت',(select COALESCE(sum(num),0) From balance_hato WHERE balance_hato.bid=balance.bid and balance_hato.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی هاتوو',(select COALESCE(sum(num),0) From balance_roshto WHERE balance_roshto.bid=balance.bid and balance_roshto.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی ڕۆشتوو بۆ بریکار',(select COALESCE(sum(num),0) From froshtn_kart WHERE froshtn_kart.bid=balance.bid and froshtn_kart.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی فرۆشراو',(select COALESCE(sum(num),0) From froshtn_kart_qarz WHERE froshtn_kart_qarz.bid=balance.bid and froshtn_kart_qarz.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی فرۆشراو بە قەرز',(select COALESCE(sum(number),0) From storage_kart WHERE storage_kart.kid=balance.bid) as 'کارتی کۆگا' from balance where types!='رصيد'");
            //advancedDataGridView1.Rows.Clear();
            //con.Open();
            //double sm = 0;
            //MySqlCommand mdd = new MySqlCommand("select types as 'جۆری کارت',(select COALESCE(sum(num),0) From balance_hato WHERE balance_hato.bid=balance.bid and balance_hato.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی هاتوو',(select COALESCE(sum(num),0) From balance_roshto WHERE balance_roshto.bid=balance.bid and balance_roshto.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی ڕۆشتوو بۆ بریکار',(select COALESCE(sum(num),0) From froshtn_kart WHERE froshtn_kart.bid=balance.bid and froshtn_kart.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی فرۆشراو',(select COALESCE(sum(num),0) From froshtn_kart_qarz WHERE froshtn_kart_qarz.bid=balance.bid and froshtn_kart_qarz.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی فرۆشراو بە قەرز',(select COALESCE(sum(num),0) From balance_garawa WHERE balance_garawa.bid=balance.bid and balance_garawa.dates BETWEEN '" + dateTimePicker51.Text + "' and '" + dateTimePicker52.Text + "') as 'کارتی گەڕاوە',(select COALESCE(sum(number),0) From storage_kart WHERE storage_kart.kid=balance.bid) as 'کارتی کۆگا' from balance where types!='رصيد'", con);
            //int i = 0;
            //MySqlDataReader rdd = mdd.ExecuteReader();
            //while (rdd.Read())
            //{

            //    if (rdd.GetValue(1).ToString() != "0" || rdd.GetValue(2).ToString() != "0" && rdd.GetValue(3).ToString() != "0" && rdd.GetValue(4).ToString() != "0" && rdd.GetValue(5).ToString() != "0")
            //    {
            //        DataGridViewRow row = new DataGridViewRow();

            //        row.CreateCells(advancedDataGridView1);
            //        row.Cells[0].Value = rdd.GetValue(0).ToString();
            //        row.Cells[1].Value = rdd.GetValue(1).ToString();
            //        row.Cells[2].Value = rdd.GetValue(2).ToString();
            //        row.Cells[3].Value = rdd.GetValue(3).ToString();
            //        row.Cells[4].Value = rdd.GetValue(4).ToString();
            //        row.Cells[5].Value = rdd.GetValue(5).ToString();
            //        row.Cells[6].Value = rdd.GetValue(6).ToString();
            //        advancedDataGridView1.Rows.Add(row);

            //    }
            //    i++;
            //}

            //con.Close();
            ob.sum(label399, advancedDataGridView1, 1);
            ob.sum(label397, advancedDataGridView1, 2);
            ob.sum(label395, advancedDataGridView1, 3);
            ob.sum(label389, advancedDataGridView1, 4);

            ob.sum(label387, advancedDataGridView1, 5);
        }

        private void pictureBox141_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud  3nd floor <br>Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئاماری کارتەکان</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView1, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label400.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label399.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label398.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label397.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label396.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label395.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label390.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label389.Text + "</p>");

            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label388.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label387.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 38;
        }

        private void pictureBox142_Click(object sender, EventArgs e)
        {
            if (comboBox10.Text == "گشتی")
            {
                ob.table(advancedDataGridView2, "select aname as 'جۆری ئامێر',(select COALESCE(sum(num),0) From amer_hato WHERE amer_hato.aid=amer.aid and amer_hato.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری هاتوو',(select COALESCE(sum(adad),0) From dawakary_amer_view WHERE dawakary_amer_view.state='قبوڵکراو' and dawakary_amer_view.arid=amer.aid and dawakary_amer_view.barwar BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری ڕۆشتوو بۆ بریکار',(select COALESCE(sum(num),0) From froshtn_amer WHERE froshtn_amer.aid=amer.aid and froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "') as 'ئامێری فرۆشراوی بریکار',((select COALESCE(sum(adad),0) From dawakary_amer_view WHERE dawakary_amer_view.arid=amer.aid and dawakary_amer_view.state='قبوڵکراو' and dawakary_amer_view.barwar BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "')-((select COALESCE(sum(num),0) From froshtn_amer WHERE froshtn_amer.aid=amer.aid and froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "')+(select COALESCE(sum(number),0) From amer_garawa WHERE amer_garawa.state='قبوڵکراو' and amer_garawa.aid=amer.aid and amer_garawa.barwar BETWEEN '" + dateTimePicker53.Text + "' and '" + dateTimePicker54.Text + "'))) as 'کۆگا' from amer");

            }
            else
            {
                ob.table(
                    advancedDataGridView2,
                    @"
    SELECT
        aname AS 'جۆری ئامێر',
        (
(
            SELECT COALESCE(SUM(num), 0)
            FROM amer_hato
            WHERE amer_hato.aid = amer.aid
                AND maxzan = '" + comboBox10.Text + @"'
                AND amer_hato.dates BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
        )
+
(   
            SELECT COALESCE(SUM(number), 0)
            FROM amer_bo_koga
            WHERE amer_bo_koga.aid = amer.aid
                AND koga = '" + comboBox10.Text + @"'
                AND amer_bo_koga.dates BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
        )
) AS 'ئامێری هاتوو',
        (
            SELECT COALESCE(SUM(adad), 0)
            FROM dawakary_amer_view
            WHERE dawakary_amer_view.arid = amer.aid
                AND dawakary_amer_view.state = 'قبوڵکراو'
                AND maxzan = '" + comboBox10.Text + @"'
                AND dawakary_amer_view.barwar BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
        ) AS 'ئامێری داواکراوی بریکار',
        (
            SELECT COALESCE(SUM(num), 0)
            FROM froshtn_amer, customer
            WHERE froshtn_amer.aid = amer.aid
                AND froshtn_amer.sumprice > 0
                AND froshtn_amer.cid = customer.cid
                AND customer.city = '" + comboBox10.Text + @"'
                AND froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
        ) AS 'ئامێری فرۆشراوی بریکار',
 
           FORMAT(
            (
                SELECT COALESCE(SUM(sumprice), 0)
                FROM froshtn_amer, customer
                WHERE froshtn_amer.aid = amer.aid
                    AND froshtn_amer.sumprice > 0
                    AND froshtn_amer.cid = customer.cid
                    AND customer.city = '" + comboBox10.Text + @"'
                    AND froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
            ), 'C'
        ) AS 'کۆی فرۆشراوی بریکار',

        (
            SELECT COALESCE(SUM(num), 0)
            FROM froshtn_amer, customer
            WHERE froshtn_amer.aid = amer.aid
                AND froshtn_amer.sumprice = 0
                AND froshtn_amer.cid = customer.cid
                AND customer.city = '" + comboBox10.Text + @"'
                AND froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
        ) AS 'ئامێری فرۆشراو بە سفر',
        (
                    SELECT COALESCE(SUM(number), 0)
                    FROM amer_garawa
                    WHERE amer_garawa.state = 'قبوڵکراو'
                        AND amer_garawa.aid = amer.aid
                        AND maxzan = '" + comboBox10.Text + @"'
                        AND amer_garawa.barwar BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
        ) AS  'ئامێری گەڕاوەی بریکار',
        (
            (
                SELECT COALESCE(SUM(adad), 0)
                FROM dawakary_amer_view
                WHERE dawakary_amer_view.arid = amer.aid
                    AND dawakary_amer_view.state = 'قبوڵکراو'
                    AND maxzan = '" + comboBox10.Text + @"'
                    AND dawakary_amer_view.barwar BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
            ) -
            (
                (
                    SELECT COALESCE(SUM(num), 0)
                    FROM froshtn_amer, customer
                    WHERE froshtn_amer.aid = amer.aid
                        AND froshtn_amer.cid = customer.cid
                        AND customer.city = '" + comboBox10.Text + @"'
                        AND froshtn_amer.dates BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
                ) +
                (
                    SELECT COALESCE(SUM(number), 0)
                    FROM amer_garawa
                    WHERE amer_garawa.state = 'قبوڵکراو'
                        AND amer_garawa.aid = amer.aid
                        AND maxzan = '" + comboBox10.Text + @"'
                        AND amer_garawa.barwar BETWEEN '" + dateTimePicker53.Text + @"' AND '" + dateTimePicker54.Text + @"'
                )
            )
        ) AS 'کۆگا'
    FROM amer"
                );

            }
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

            ob.sum(label393, advancedDataGridView2, 5);
        }

        private void pictureBox143_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud  3nd floor <br>Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

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
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label413.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label412.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label411.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label410.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label409.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label408.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label405.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label402.Text + "</p>");

            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label394.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label393.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void advancedDataGridView2_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView2);
            ob.sum(label412, advancedDataGridView2, 1);
            ob.sum(label410, advancedDataGridView2, 2);
            ob.sum(label408, advancedDataGridView2, 3);
            ob.sum(label402, advancedDataGridView2, 4);

            ob.sum(label393, advancedDataGridView2, 5);
        }

        private void advancedDataGridView2_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView2);
            ob.sum(label412, advancedDataGridView2, 1);
            ob.sum(label410, advancedDataGridView2, 2);
            ob.sum(label408, advancedDataGridView2, 3);
            ob.sum(label402, advancedDataGridView2, 4);

            ob.sum(label393, advancedDataGridView2, 5);
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView1);
            ob.sum(label399, advancedDataGridView1, 1);
            ob.sum(label397, advancedDataGridView1, 2);
            ob.sum(label395, advancedDataGridView1, 3);
            ob.sum(label389, advancedDataGridView1, 4);

            ob.sum(label387, advancedDataGridView1, 5);
        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView1);
            ob.sum(label399, advancedDataGridView1, 1);
            ob.sum(label397, advancedDataGridView1, 2);
            ob.sum(label395, advancedDataGridView1, 3);
            ob.sum(label389, advancedDataGridView1, 4);

            ob.sum(label387, advancedDataGridView1, 5);
        }

        private void data35_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void data37_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void tabPage41_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 40;
            // ob.getsum(label418, "SELECT sum(masrufatwakel.`amount`) AS 'result' FROM `masrufatwakel`");
            // ob.getsum(label420, "SELECT sum(muchay_employee.`mucha`) AS 'result' FROM `muchay_employee`");
            // ob.getsum(label423, "SELECT sum(masrufat.`amount`) AS 'result' FROM `masrufat`");
            // ob.getsum(label424, "SELECT sum(mb_buy.`sump`) AS 'result' FROM `mb_buy`");
            // double mbb = Convert.ToDouble(label424.Text) * dolar;
            // label432.Text = (Convert.ToDouble(label418.Text) + Convert.ToDouble(label420.Text) + Convert.ToDouble(label423.Text) + mbb).ToString();
            //ob.getsum(label417, "SELECT sum(`sumprice`) AS 'result' FROM `froshtn_kart`");
            //ob.getsum(label431, "SELECT sum(mb_sell.`sump`) AS 'result' FROM `mb_sell`");
            //double mbs = Convert.ToDouble(label431.Text) * dolar;
            //label435.Text = (Convert.ToDouble(label417.Text) + mbs).ToString();
            //label437.Text = (Convert.ToDouble(label435.Text) - Convert.ToDouble(label432.Text)).ToString();
            // ob.setsepator(label418);
            // ob.setsepator(label420);
            // ob.setsepator(label423);
            // ob.setsepator(label424);
            // ob.setsepator(label432);
            // ob.setsepator(label417);
            // ob.setsepator(label431);
            // ob.setsepator(label435);
            // ob.setsepator(label437);
        }

        private void pictureBox145_Click(object sender, EventArgs e)
        {
            label418.Text = "0";
            label423.Text = "0";
            label424.Text = "0";
            label432.Text = "0";
            label417.Text = "0";
            label431.Text = "0";
            label435.Text = "0";
            label437.Text = "0";
            ob.getsum(label423, "SELECT sum(masrufat.`amount`) AS 'result' FROM `masrufat` where dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            ob.getsum(label424, "SELECT sum(mb_buy.`sump`) AS 'result' FROM `mb_buy` where dates1 between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            Double mbb = Convert.ToDouble(label424.Text) * dolar;
            ob.getsum(label417, "SELECT sum(give_customer.`qarzdinar`) AS 'result' FROM `give_customer` where dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            double f = Convert.ToDouble(label417.Text);
            // ob.getsum(label417, "SELECT sum(froshtn_kart_qarz.`sumprice`) AS 'result' FROM `froshtn_kart_qarz` where state='واسڵ' and dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            //  label417.Text = (Convert.ToDouble(label417.Text) + f).ToString();
            ob.getsum(label418, "SELECT sum(masrufatwakel.`amount`) AS 'result' FROM `masrufatwakel` where state='قبوڵکراو' and dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            label432.Text = (Convert.ToDouble(label423.Text) + mbb).ToString();
            ob.getsum(label431, "SELECT sum(mb_sell.`sump`) AS 'result' FROM `mb_sell` where dates1 between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            Double mbs = Convert.ToDouble(label431.Text) * dolar;
            label435.Text = (Convert.ToDouble(label417.Text) + mbs).ToString();
            label437.Text = (Convert.ToDouble(label435.Text) - Convert.ToDouble(label432.Text)).ToString();
            ob.setsepator(label418);

            ob.setsepator(label423);
            ob.setsepator(label424);
            ob.setsepator(label432);
            ob.setsepator(label417);
            ob.setsepator(label431);
            ob.setsepator(label435);
            ob.setsepator(label437);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (e.Value != null)
                    {

                        e.Value = new String('#', e.Value.ToString().Length);
                    }
                    else
                    {

                        e.Value = "";
                    }
                }





            }
            catch (Exception)
            {


            }
        }

        private void data36_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in data36.Rows)
                // do sonmthind

                if (Convert.ToString(row.Cells[6].Value).Equals("قبوڵنەکراو"))
                {
                    if (row.Index <= data36.RowCount - 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
        }

        private void datagridview12_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in datagridview12.Rows)
                // do sonmthind

                if (Convert.ToString(row.Cells[6].Value).Equals("قبوڵنەکراو"))
                {
                    if (row.Index <= datagridview12.RowCount - 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }

        }

        private void datagridview21_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            foreach (DataGridViewRow row in datagridview21.Rows)
                // do sonmthind

                if (Convert.ToString(row.Cells[5].Value).Equals("قبوڵنەکراو"))
                {
                    if (row.Index <= datagridview21.RowCount - 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
        }

        private void datagridview22_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in datagridview22.Rows)
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

        private void datagridview11_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in datagridview11.Rows)
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

        private void قەرزیماوەToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qarzc = "قەرزی کڕیار";
            qarzdetail ob = new qarzdetail();

            ob.Show();
        }

        private void قەرزیماوەToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            qarzc = "قەرزی بریکار";
            qarzdetail ob = new qarzdetail();

            ob.Show();
        }

        private void قەرزیماوەToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            qarzc = "قەرزی ئینتەرنێت";
            qarzdetail ob = new qarzdetail();

            ob.Show();
        }

        private void قەرزیماوەToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void قەرزیماوەToolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            qarzc = "فرۆشیاری ئامێر";
            qarzdetail ob = new qarzdetail();

            ob.Show();
        }

        private void pictureBox148_Click(object sender, EventArgs e)
        {
            if (datagridview10.SelectedRows.Count != 0)
            {
                int i = datagridview10.SelectedRows[0].Index;
                int id = Convert.ToInt32(datagridview10.Rows[i].Cells[0].Value.ToString());

                int num = Convert.ToInt32(datagridview10.Rows[i].Cells[2].Value.ToString());
                double pric = Convert.ToDouble(datagridview10.Rows[i].Cells[3].Value.ToString());
                if (MessageBox.Show("دڵنیای لەگۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ob.insert_del_up("call delete_qarz_net_company('" + id + "')");
                    ob.insert_del_up("call delete_amer_hatu('" + id + "')");
                    ob.insert_del_up("call delete_storage_amer('" + amer.SelectedValue.ToString() + "','" + num + "')");





                    if (checkBox3.Checked == true)
                    {
                        double resp = Convert.ToDouble(price.Text) / dolar;
                        double resm = Convert.ToDouble(money.Text) / dolar;
                        ob.insert_del_up("INSERT INTO `amer_hato`(ahid,`price`, `num`,dates,aid,ncid,`sump`,`money`,`qarz`, `wasl`, `tebene`,maxzan) VALUES('" + id + "','" + resp + "','" + number.Text + "','" + barwar_amer_hatu.Text + "','" + amer.SelectedValue.ToString() + "','" + companya.SelectedValue.ToString() + "','" + sump.Text + "','" + resm + "','" + qarz.Text + "','" + waslamer.Text + "','" + textBox6.Text + "','کۆمپانیا')");
                    }
                    else
                    {
                        ob.insert_del_up("INSERT INTO `amer_hato`(ahid,`price`, `num`,dates,aid,ncid,`sump`,`money`,`qarz`, `wasl`, `tebene`,maxzan) VALUES('" + id + "','" + price.Text + "','" + number.Text + "','" + barwar_amer_hatu.Text + "','" + amer.SelectedValue.ToString() + "','" + companya.SelectedValue.ToString() + "','" + sump.Text + "','" + money.Text + "','" + qarz.Text + "','" + waslamer.Text + "','" + textBox6.Text + "','کۆمپانیا')");

                    }


                    ob.insert_del_up("call insert_storage_amer('" + amer.SelectedValue.ToString() + "','" + number.Text + "','" + barwar_amer_hatu.Text + "')");
                    if (qarz.Text != "" && qarz.Text != "0")
                    {
                        ob.insert_del_up("INSERT INTO `qarz_net_comp`(`qarzdinar`, `dates`, `ncid`, `id_amer_hatu`) VALUES('" + qarz.Text + "','" + barwar_amer_hatu.Text + "','" + companya.SelectedValue.ToString() + "','" + id + "')");
                    }
                    ob.table(datagridview10, "call select_amer_hatu_info();");
                    ob.sum(label69, datagridview10, 2);
                    ob.sum(label71, datagridview10, 3);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                }
                else
                {
                    ob.table(datagridview10, "call select_amer_hatu_info();");
                    ob.sum(label69, datagridview10, 2);
                    ob.sum(label71, datagridview10, 3);
                }
            }
        }

        private void pictureBox149_Click(object sender, EventArgs e)
        {
            if (datagridview20.SelectedRows.Count != 0)
            {
                int i = datagridview20.SelectedRows[0].Index;
                int id = Convert.ToInt32(datagridview20.Rows[i].Cells[0].Value.ToString());
                double num = Convert.ToDouble(datagridview20.Rows[i].Cells[1].Value.ToString());
                if (MessageBox.Show("دڵنیای لەگۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ob.insert_del_up("delete from balance_hato where bhid='" + id + "'");
                    ob.insert_del_up("call delete_storage_kart('" + karti + "','" + num + "')");
                    ob.insert_del_up("INSERT INTO `balance_hato`(`num`, `dates`, `bid`, `tebene`,price) VALUES ('" + numkart.Text + "','" + dateTimePicker19.Text + "','" + kart.SelectedValue.ToString() + "','" + textBox8.Text + "','0')");
                    ob.insert_del_up("call insert_storage_kart('" + kart.SelectedValue.ToString() + "','" + numkart.Text + "','" + dateTimePicker19.Text + "')");
                    ob.table(datagridview20, "SELECT balance_hato.`bhid` AS '#', balance_hato.`num` AS 'عەدەد', DATE_FORMAT(balance_hato.`dates`, '%Y/%m/%d') AS 'بەروار', balance.`types` AS 'کارت', balance_hato.`tebene` AS 'تێبینی'  FROM `balance_hato`,balance where balance_hato.bid=balance.bid");
                    ob.count(label159, datagridview20, 0);


                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();

                }
                else
                {
                    ob.table(datagridview20, "SELECT balance_hato.`bhid` AS '#', balance_hato.`num` AS 'عەدەد', DATE_FORMAT(balance_hato.`dates`, '%Y/%m/%d') AS 'بەروار', balance.`types` AS 'کارت', balance_hato.`tebene` AS 'تێبینی'  FROM `balance_hato`,balance where balance_hato.bid=balance.bid");
                    ob.count(label159, datagridview20, 0);
                }
            }
        }

        private void pictureBox150_Click(object sender, EventArgs e)
        {

            ob.table(advancedDataGridView3, "select types as 'جۆر',(select COALESCE(sum(num),0) From balance_hato WHERE balance_hato.bid=balance.bid and balance_hato.dates BETWEEN '" + dateTimePicker57.Text + "' and '" + dateTimePicker58.Text + "') as 'رصيدى هاتوو',(select COALESCE(sum(num),0) From balance_roshto WHERE balance_roshto.bid=balance.bid and balance_roshto.dates BETWEEN '" + dateTimePicker57.Text + "' and '" + dateTimePicker58.Text + "') as 'رصيدی ڕۆشتوو بۆ بریکار',(select COALESCE(sum(num),0) From froshtn_kart WHERE froshtn_kart.bid=balance.bid and froshtn_kart.dates BETWEEN '" + dateTimePicker57.Text + "' and '" + dateTimePicker58.Text + "') as 'رصيدی فرۆشراو',(select COALESCE(sum(num),0) From froshtn_kart_qarz WHERE froshtn_kart_qarz.bid=balance.bid and froshtn_kart_qarz.dates BETWEEN '" + dateTimePicker57.Text + "' and '" + dateTimePicker58.Text + "') as 'رصيدی فرۆشراو بە قەرز',(select COALESCE(sum(num),0) From balance_garawa WHERE balance_garawa.bid=balance.bid and balance_garawa.dates BETWEEN '" + dateTimePicker57.Text + "' and '" + dateTimePicker58.Text + "') as 'رصيدی گەڕاوە',(select COALESCE(sum(number),0) From storage_kart WHERE storage_kart.kid=balance.bid) as 'رصيدی کۆگا' from balance where types='رصيد'");

            ob.sum(label448, advancedDataGridView3, 1);
            ob.sum(label446, advancedDataGridView3, 2);
            ob.sum(label444, advancedDataGridView3, 3);
            ob.sum(label199, advancedDataGridView3, 4);
            ob.sum(label442, advancedDataGridView3, 5);
            ob.sum(label197, advancedDataGridView3, 6);
        }

        private void ئاماریرصيدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 41;
        }

        private void pictureBox151_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud 3nd floor <br> Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئاماری رصيد</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView3, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label449.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label448.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label447.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label446.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label445.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label444.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label200.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label199.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label443.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label442.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + label198.Text + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label197.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 20;
            ob.table(datagridview22, "SELECT `id` AS '#', `kartn` AS 'کارت', `number` AS 'عەدەد',DATE_FORMAT(`barwar`, '%Y/%m/%d') AS 'بەروار' FROM `storage_kart_view` where kartn!='رصيد'");
            ob.sum(label174, datagridview22, 2);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 42;
            ob.table(advancedDataGridView4, "SELECT `id` AS '#', `kartn` AS 'کارت', `number` AS 'عەدەد',DATE_FORMAT(`barwar`, '%Y/%m/%d') AS 'بەروار' FROM `storage_kart_view` where kartn='رصيد'");
            ob.sum(label454, advancedDataGridView4, 2);
        }

        private void pictureBox153_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud> 3nd floor  <brSulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کۆگای ڕەسید</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView4, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label454.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox152_Click(object sender, EventArgs e)
        {
            ob.toexcel(advancedDataGridView4);
        }

        private void advancedDataGridView4_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView4);
            ob.sum(label454, advancedDataGridView4, 2);
        }

        private void advancedDataGridView4_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView4);
            ob.sum(label454, advancedDataGridView4, 2);
        }

        private void label427_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            chargeuserinfo os = new chargeuserinfo();
            os.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox154_Click(object sender, EventArgs e)
        {
            ob.table(datagridview10, "SELECT `ahid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی دراو', `qarz` as 'قەرز', DATE_FORMAT(dates, '%Y/%m/%d') as 'بەروار', `aname` as 'ئامێر', `name` as 'کۆمپانیا', `wasl` as 'وەسڵ',maxzan as 'کۆگا',  `tebene` as 'تێبینی' FROM `amer_hatu_info` where dates between '" + dateTimePicker59.Text + "' and '" + dateTimePicker60.Text + "'");
            ob.sum(label69, datagridview10, 2);
            ob.sum(label71, datagridview10, 3);
        }

        private void pictureBox155_Click(object sender, EventArgs e)
        {
            ob.table(datagridview13, "SELECT `arid` as '#', `price` as 'نرخ', `num` as 'عەدەد', `sump` as 'کۆی نرخ', `money` as 'پارەی وەرگیراو', `qarz` as 'قەرز', DATE_FORMAT(dates, '%Y/%m/%d') as 'بەروار', amer.aname as 'ئامێر', customer.cname as 'بریکار', `burj` as 'بورج', `wasl` as 'وەسڵ', `tebene` as 'تێبینی' FROM `amer_froshtn`, amer,customer where amer_froshtn.aid=amer.aid and amer_froshtn.cusid=customer.cid and dates between '" + dateTimePicker61.Text + "' and '" + dateTimePicker62.Text + "'");


            ob.sum(label91, datagridview13, 2);
            ob.sum(label86, datagridview13, 3);
        }

        private void pictureBox156_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 34;
        }

        private void pictureBox157_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 35;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox3.Checked != true)
                {
                    if (price.Text != "" && number.Text != "")
                    {
                        sump.Text = (Convert.ToDouble(price.Text) * Convert.ToDouble(number.Text)).ToString();

                    }
                    else
                    {

                        sump.Text = "0";
                    }


                    sumpd.Text = (Convert.ToDouble(sump.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (price.Text != "" && number.Text != "")
                    {
                        sumpd.Text = (Convert.ToDouble(price.Text) * Convert.ToDouble(number.Text)).ToString();
                        sump.Text = (Convert.ToDouble(sumpd.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        sumpd.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void materialSingleLineTextField47_Click(object sender, EventArgs e)
        {

        }

        private void data30_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(data30);
        }

        private void data30_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(data30);
        }

        private void کارتیفرۆشراویبریکاربەقەرزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 43;

            ob.table(advancedDataGridView5, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام', `kryar` AS 'کڕیار',kryar.tel as 'مۆبایل', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی',state AS 'حاڵەت',barwarwasl AS 'بەرواری واسڵکردن' FROM `froshtn_kart_qarz`,balance,customer,kryar WHERE kryar.id=froshtn_kart_qarz.idkryar and froshtn_kart_qarz.bid=balance.bid and customer.cid=froshtn_kart_qarz.cid");
            ob.sum(label474, advancedDataGridView5, 3);
            ob.sum(label469, advancedDataGridView5, 5);
        }

        private void advancedDataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void advancedDataGridView5_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView5);
            ob.sum(label474, advancedDataGridView5, 3);
            ob.sum(label469, advancedDataGridView5, 5);
        }

        private void advancedDataGridView5_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView5);
            ob.sum(label474, advancedDataGridView5, 3);
            ob.sum(label469, advancedDataGridView5, 5);
        }

        private void materialSingleLineTextField49_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField49.Text != "")
            {
                ob.table(advancedDataGridView5, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام', `kryar` AS 'کڕیار',kryar.tel as 'مۆبایل', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی',state AS 'حاڵەت',barwarwasl AS 'بەرواری واسڵکردن' FROM `froshtn_kart_qarz`,balance,customer,kryar WHERE kryar.id=froshtn_kart_qarz.idkryar and froshtn_kart_qarz.bid=balance.bid and customer.cid=froshtn_kart_qarz.cid and customer.cname like '" + materialSingleLineTextField49.Text + "%'");
                ob.sum(label474, advancedDataGridView5, 3);
                ob.sum(label469, advancedDataGridView5, 5);
            }
            else
            {
                ob.table(advancedDataGridView5, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام', `kryar` AS 'کڕیار',kryar.tel as 'مۆبایل', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی',state AS 'حاڵەت',barwarwasl AS 'بەرواری واسڵکردن' FROM `froshtn_kart_qarz`,balance,customer,kryar WHERE kryar.id=froshtn_kart_qarz.idkryar and froshtn_kart_qarz.bid=balance.bid and customer.cid=froshtn_kart_qarz.cid");
                ob.sum(label474, advancedDataGridView5, 3);
                ob.sum(label469, advancedDataGridView5, 5);
            }
        }

        private void materialSingleLineTextField48_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField48.Text != "")
            {
                ob.table(advancedDataGridView5, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام', `kryar` AS 'کڕیار',kryar.tel as 'مۆبایل', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی',state AS 'حاڵەت',barwarwasl AS 'بەرواری واسڵکردن' FROM `froshtn_kart_qarz`,balance,customer,kryar WHERE kryar.id=froshtn_kart_qarz.idkryar and froshtn_kart_qarz.bid=balance.bid and customer.cid=froshtn_kart_qarz.cid and wasl like '" + materialSingleLineTextField48.Text + "%'");
                ob.sum(label474, advancedDataGridView5, 3);
                ob.sum(label469, advancedDataGridView5, 5);
            }
            else
            {
                ob.table(advancedDataGridView5, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام', `kryar` AS 'کڕیار',kryar.tel as 'مۆبایل', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی',state AS 'حاڵەت',barwarwasl AS 'بەرواری واسڵکردن' FROM `froshtn_kart_qarz`,balance,customer,kryar WHERE kryar.id=froshtn_kart_qarz.idkryar and froshtn_kart_qarz.bid=balance.bid and customer.cid=froshtn_kart_qarz.cid");
                ob.sum(label474, advancedDataGridView5, 3);
                ob.sum(label469, advancedDataGridView5, 5);
            }
        }

        private void pictureBox158_Click(object sender, EventArgs e)
        {
            ob.table(advancedDataGridView5, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ',mbrekar as 'پارەی بریکار',result as 'ئەنجام', `kryar` AS 'کڕیار',kryar.tel as 'مۆبایل', DATE_FORMAT(`dates`, '%d/%m/%Y') AS 'بەروار', balance.types AS 'جۆری کارت',tebene AS 'تێبینی',state AS 'حاڵەت',barwarwasl AS 'بەرواری واسڵکردن' FROM `froshtn_kart_qarz`,balance,customer,kryar WHERE kryar.id=froshtn_kart_qarz.idkryar and froshtn_kart_qarz.bid=balance.bid and customer.cid=froshtn_kart_qarz.cid and dates between '" + dateTimePicker65.Text + "' and '" + dateTimePicker66.Text + "'");

            ob.sum(label474, advancedDataGridView5, 3);
            ob.sum(label469, advancedDataGridView5, 5);

        }

        private void pictureBox159_Click(object sender, EventArgs e)
        {
            ob.toexcel(advancedDataGridView5);
        }

        private void pictureBox160_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کارتی فرۆشراوی بریکار بە قەرز</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView5, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label474.Text + "</p>");
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی نرخ</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>$" + label469.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void tabPage23_Click(object sender, EventArgs e)
        {

        }

        private void nrxfcus_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox2.Checked != true)
                {
                    if (nrxfcus.Text != "" && numfcus.Text != "")
                    {
                        materialSingleLineTextField51.Text = (Convert.ToDouble(nrxfcus.Text) * Convert.ToDouble(numfcus.Text)).ToString();

                    }
                    else
                    {

                        materialSingleLineTextField51.Text = "0";
                    }


                    materialSingleLineTextField50.Text = (Convert.ToDouble(materialSingleLineTextField51.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (numfcus.Text != "" && nrxfcus.Text != "")
                    {
                        materialSingleLineTextField50.Text = (Convert.ToDouble(nrxfcus.Text) * Convert.ToDouble(numfcus.Text)).ToString();
                        materialSingleLineTextField51.Text = (Convert.ToDouble(materialSingleLineTextField50.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        materialSingleLineTextField50.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void numfcus_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox2.Checked != true)
                {
                    if (nrxfcus.Text != "" && numfcus.Text != "")
                    {
                        materialSingleLineTextField51.Text = (Convert.ToDouble(nrxfcus.Text) * Convert.ToDouble(numfcus.Text)).ToString();

                    }
                    else
                    {

                        materialSingleLineTextField51.Text = "0";
                    }


                    materialSingleLineTextField50.Text = (Convert.ToDouble(materialSingleLineTextField51.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (numfcus.Text != "" && nrxfcus.Text != "")
                    {
                        materialSingleLineTextField50.Text = (Convert.ToDouble(nrxfcus.Text) * Convert.ToDouble(numfcus.Text)).ToString();
                        materialSingleLineTextField51.Text = (Convert.ToDouble(materialSingleLineTextField50.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        materialSingleLineTextField50.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox1.Checked != true)
                {
                    if (adadmbp.Text != "" && nrxmbp.Text != "")
                    {
                        materialSingleLineTextField47.Text = (Convert.ToDouble(nrxmbp.Text) * Convert.ToDouble(adadmbp.Text)).ToString();

                    }
                    else
                    {

                        materialSingleLineTextField47.Text = "0";
                    }


                    materialSingleLineTextField46.Text = (Convert.ToDouble(materialSingleLineTextField47.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (adadmbp.Text != "" && nrxmbp.Text != "")
                    {
                        materialSingleLineTextField46.Text = (Convert.ToDouble(nrxmbp.Text) * Convert.ToDouble(adadmbp.Text)).ToString();
                        materialSingleLineTextField47.Text = (Convert.ToDouble(materialSingleLineTextField46.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        materialSingleLineTextField46.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (checkBox2.Checked != true)
                {
                    if (nrxfcus.Text != "" && numfcus.Text != "")
                    {
                        materialSingleLineTextField51.Text = (Convert.ToDouble(nrxfcus.Text) * Convert.ToDouble(numfcus.Text)).ToString();

                    }
                    else
                    {

                        materialSingleLineTextField51.Text = "0";
                    }


                    materialSingleLineTextField50.Text = (Convert.ToDouble(materialSingleLineTextField51.Text) * online.draw.dolar).ToString();

                }
                else
                {
                    if (numfcus.Text != "" && nrxfcus.Text != "")
                    {
                        materialSingleLineTextField50.Text = (Convert.ToDouble(nrxfcus.Text) * Convert.ToDouble(numfcus.Text)).ToString();
                        materialSingleLineTextField51.Text = (Convert.ToDouble(materialSingleLineTextField50.Text) / online.draw.dolar).ToString();
                    }
                    else
                    {

                        materialSingleLineTextField50.Text = "0";
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            String day = DateTime.Now.Day.ToString();
            String month = DateTime.Now.Month.ToString();
            String year = DateTime.Now.Year.ToString();
            String hour = DateTime.Now.Hour.ToString();
            String mint = DateTime.Now.Minute.ToString();
            String second = DateTime.Now.Second.ToString();


            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = day + "-" + month + "-" + year + "________" + hour + "." + mint + "." + second;
            // set filters - this can be done in properties as well
            savefile.Filter = "Text files (*.sql)|*.sql|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    Console.WriteLine("backup");
                Backup("pos", savefile.FileName);
                MessageBox.Show("...داتاکان بە سەرکەوتووی پاشەکەوت کرا ");

            }
        }

        private void قازانجیئامێرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qazanjamer obb = new qazanjamer();
            obb.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void datagridview16_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dr1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ڕاپۆرتیفرۆشتنیئامێرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 44;
            ob.comb(comboBox3, "SELECT * FROM customer", "cid", "cname");
        }

        private void pictureBox161_Click(object sender, EventArgs e)
        {
            ob.table(advancedDataGridView6, "SELECT `brid` AS '#', sum(`num`) AS 'ئامێری فرۆشراو', `price` AS 'نرخ', sum(`sumprice`) AS 'کۆی نرخ', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',(SELECT Coalesce(sum(`adad`),0) AS 'sumget' FROM `dawakary_amer_view` where dawakary_amer_view.arid=froshtn_amer.aid and dawakary_amer_view.cid=froshtn_amer.cid and dawakary_amer_view.state='قبوڵکراو' and dawakary_amer_view.barwar between '" + dateTimePicker68.Text + "' and '" + dateTimePicker69.Text + "') as 'ئامێری وەرگیراو',((SELECT Coalesce(sum(`adad`),0) AS 'sumget' FROM `dawakary_amer_view` where dawakary_amer_view.arid=froshtn_amer.aid and dawakary_amer_view.cid=froshtn_amer.cid and dawakary_amer_view.state='قبوڵکراو' and dawakary_amer_view.barwar between '" + dateTimePicker68.Text + "' and '" + dateTimePicker69.Text + "')-(sum(froshtn_amer.num))) as 'کۆگا',tebene AS 'تێبینی' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and froshtn_amer.cid=customer.cid and froshtn_amer.cid='" + comboBox3.SelectedValue.ToString() + "' and dates between '" + dateTimePicker68.Text + "' and '" + dateTimePicker69.Text + "'  group by froshtn_amer.aid");
            ob.sum(label478, advancedDataGridView6, 1);
            ob.sum(label459, advancedDataGridView6, 3);


            ob.sum(label196, advancedDataGridView6, 6);




            con.Open();
            MySqlCommand mdd = new MySqlCommand("SELECT Coalesce(sum(`qarzdinar`),0) as sqarz From give_customer where ty='ئامێر' and  cid='" + comboBox3.SelectedValue.ToString() + "'  and dates between '" + dateTimePicker68.Text + "' and '" + dateTimePicker69.Text + "'", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            while (rdd.Read())
            {

                label421.Text = rdd.GetString("sqarz");

            }
            con.Close();


            double mawa = Convert.ToDouble(label459.Text) - Convert.ToDouble(label421.Text);
            label361.Text = mawa.ToString();
        }

        private void pictureBox162_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>بریکار/" + comboBox3.Text + "</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");

            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%; direction=rtl'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>#</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>عەدەد</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>نرخ</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;'>کۆی نرخ</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;' >بەروار</th>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: right;padding: 8px;'>جۆری ئامێر</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;' >ئامێری وەرگیراو</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;' >ئامێری ماوە</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: right;padding: 8px;' >ئامێری کۆگا</th>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: right;padding: 8px;'>تێبینی</th>");
            easyHTMLReports1.AddString("</tr>");

            con.Open();

            int cou = 1;
            MySqlCommand mdd = new MySqlCommand("SELECT `brid` AS '#', `num` AS 'num', `price` AS 'price', `sumprice` AS 'sumprice', DATE_FORMAT(dates, '%Y/%m/%d') AS 'dates', amer.aname AS 'ty',(SELECT Coalesce(sum(`adad`),0) AS 'sumget' FROM `dawakary_amer_view` where dawakary_amer_view.state='قبوڵکراو' and dawakary_amer_view.arid=froshtn_amer.aid and dawakary_amer_view.cid=froshtn_amer.cid and dawakary_amer_view.barwar between '" + dateTimePicker68.Text + "' and '" + dateTimePicker69.Text + "') as 'war',((SELECT Coalesce(sum(`num`),0) AS 'sumget' FROM `amer_roshto` where amer_roshto.aid=froshtn_amer.aid and amer_roshto.cusid=froshtn_amer.cid and amer_roshto.dates between '" + dateTimePicker68.Text + "' and '" + dateTimePicker69.Text + "')-(froshtn_amer.num)) as 'mawa',(select COALESCE(sum(number),0)  from storage_amer_customer where storage_amer_customer.aid=froshtn_amer.aid and storage_amer_customer.cus=froshtn_amer.cid) as 'koga',tebene AS 'tebene' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and froshtn_amer.cid=customer.cid and froshtn_amer.cid='" + comboBox3.SelectedValue.ToString() + "' and dates between '" + dateTimePicker68.Text + "' and '" + dateTimePicker69.Text + "'", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            if (rdd.HasRows)
            {
                while (rdd.Read())
                {
                    easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");

                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + cou + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("num") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("price") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("sumprice") + "</td>");
                    easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;' >" + rdd.GetString("dates") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("ty") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("war") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("mawa") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("koga") + "</td>");
                    easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: right;padding: 8px; color:white; font-size:14px;'>" + rdd.GetString("tebene") + "</td>");
                    easyHTMLReports1.AddString("</tr>");
                    cou++;

                }
            }
            con.Close();
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;' >");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی گشتی</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label478.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی نرخ</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label459.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");

            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی ئامێری وەرگیراو</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label196.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");

            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی پارەی وەرگیراو</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label421.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: right;padding: 8px;'>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' >کۆی قەرز</td>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: right;padding: 8px; color:white; font-size:14px;' colspan=5>" + label361.Text + "</td>");

            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("</table>");

            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Dear Client <br>Please Proceed with the payment within 4 days<br>Online Company accept cash payment delivered to the Kalar Bazar-Sulaymaniyah,IRAQ </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>if you have any question concering this invoice please contact <br>096407729790070 – 096407512330605<br>acc@onlineco.net");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }
        public static int a = 0;
        private void کۆگایئامێرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = 0;
            kogaa ob = new kogaa();
            ob.Show();
        }

        private void کۆگایکارتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a = 1;
            kogaa ob = new kogaa();
            ob.Show();
        }

        private void کارتیوەرگیراوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kartwargeraw ob = new kartwargeraw();
            ob.Show();
        }

        private void advancedDataGridView6_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView6);
            ob.sum(label478, advancedDataGridView6, 1);
            ob.sum(label459, advancedDataGridView6, 3);


            ob.sum(label196, advancedDataGridView6, 6);

            double mawa = Convert.ToDouble(label459.Text) - Convert.ToDouble(label421.Text);
            label361.Text = mawa.ToString();
        }

        private void advancedDataGridView6_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView6);
            ob.sum(label478, advancedDataGridView6, 1);
            ob.sum(label459, advancedDataGridView6, 3);


            ob.sum(label196, advancedDataGridView6, 6);

            double mawa = Convert.ToDouble(label459.Text) - Convert.ToDouble(label421.Text);
            label361.Text = mawa.ToString();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                comboBox6.Enabled = true;
                ob.comb(comboBox6, "select * from customer", "cid", "cname");
            }
            else
            {
                comboBox6.Enabled = false;
                comboBox6.DataSource = null;
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 45;
            ob.table(advancedDataGridView7, "SELECT `id` as '#', `br` AS 'بڕ', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار', `tebene` AS 'تێبینی' FROM `storagem`");
            ob.sum(label493, advancedDataGridView7, 1);
            ob.getsum(label495, "select difference as 'result' from st");
        }

        private void pictureBox163_Click(object sender, EventArgs e)
        {

            try
            {
                if (datagridview21.SelectedRows.Count != 0)
                {
                    int i = datagridview21.SelectedRows[0].Index;
                    int id = Convert.ToInt32(datagridview21.Rows[i].Cells[0].Value.ToString());

                    if (MessageBox.Show("دڵنیای لە گۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        ob.insert_del_up("update dawakary_balance set adad='" + materialSingleLineTextField39.Text + "' where id='" + id + "'");
                        ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl='" + wasldk + "'");

                        ob.sum(label167, datagridview21, 2);
                        ob.getsum(label495, "select difference as 'result' from st");
                    }
                    else
                    {
                        ob.table(datagridview21, "SELECT `id` as '#', `aname` as 'کارت', `adad` as 'عەدەد', DATE_FORMAT(barwar, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی',`state` as 'حاڵەت',cname as 'بریکار', `wasl` as 'وەسڵ' FROM `dawakary_balance_view` where wasl='" + wasldk + "'");

                        ob.sum(label167, datagridview21, 2);
                        ob.getsum(label495, "select difference as 'result' from st");
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox168_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ob.insert_del_up("INSERT INTO `storagem`(`br`,`barwar`, `tebene`) VALUES ('" + materialSingleLineTextField41.Text + "','" + dateTimePicker72.Text + "','" + textBox10.Text + "')");
                ob.table(advancedDataGridView7, "SELECT `id` as '#', `br` AS 'بڕ', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار', `tebene` AS 'تێبینی' FROM `storagem`");
                ob.sum(label493, advancedDataGridView7, 1);
                ob.getsum(label495, "select difference as 'result' from st");
                messageboxsuc obb = new messageboxsuc();
                obb.Show();
                ob.a(this.Controls);

            }
        }

        private void pictureBox167_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (advancedDataGridView7.SelectedRows.Count != 0)
                    {
                        int i = advancedDataGridView7.SelectedRows[0].Index;
                        String id = advancedDataGridView7.Rows[i].Cells[0].Value.ToString();
                        ob.insert_del_up("UPDATE `storagem` SET `br`='" + materialSingleLineTextField41.Text + "',`barwar`='" + dateTimePicker72.Text + "',`tebene`='" + textBox10.Text + "' WHERE  `id`='" + id + "'");
                        ob.a(this.Controls);
                        ob.table(advancedDataGridView7, "SELECT `id` as '#', `br` AS 'بڕ', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار', `tebene` AS 'تێبینی' FROM `storagem`");
                        ob.sum(label493, advancedDataGridView7, 1);
                        ob.getsum(label495, "select difference as 'result' from st");
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void advancedDataGridView7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("دڵنیای؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (advancedDataGridView7.SelectedRows.Count != 0)
                        {
                            int i = advancedDataGridView7.SelectedRows[0].Index;
                            String id = advancedDataGridView7.Rows[i].Cells[0].Value.ToString();
                            ob.insert_del_up("delete from storagem WHERE  `id`='" + id + "'");
                            ob.a(this.Controls);
                            ob.table(advancedDataGridView7, "SELECT `id` as '#', `br` AS 'بڕ', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار', `tebene` AS 'تێبینی' FROM `storagem`");
                            ob.sum(label493, advancedDataGridView7, 1);
                            ob.getsum(label495, "select difference as 'result' from st");
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

        private void advancedDataGridView7_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView7);
            ob.sum(label493, advancedDataGridView7, 1);
        }

        private void advancedDataGridView7_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView7);
            ob.sum(label493, advancedDataGridView7, 1);
        }

        private void pictureBox164_Click(object sender, EventArgs e)
        {
            ob.table(advancedDataGridView7, "SELECT `id` as '#', `br` AS 'بڕ', DATE_FORMAT(barwar, '%Y/%m/%d') AS 'بەروار', `tebene` AS 'تێبینی' FROM `storagem` where barwar between '" + dateTimePicker70.Text + "' and '" + dateTimePicker71.Text + "'");
            ob.sum(label493, advancedDataGridView7, 1);
        }

        private void advancedDataGridView7_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(advancedDataGridView7, materialSingleLineTextField41, 1);
            ob.change_datagridview_picker(advancedDataGridView7, dateTimePicker72, 2);
            ob.change_datagridview(advancedDataGridView7, textBox10, 3);
        }

        private void pictureBox166_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>کۆگای مەسرەف</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView7, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label493.Text + "</p>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox165_Click(object sender, EventArgs e)
        {
            ob.toexcel(advancedDataGridView7);
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (comboBox8.Text == "گشتی")
            //{
            //    ob.table(datagridview11, "SELECT `aid` as '#', `amer` as 'ئامێر', `result` as 'عەدەد' FROM `koga`");

            //}
            //else if (comboBox8.Text == "سلێمانی")
            //{
            //    ob.table(datagridview11, "SELECT `aid` as '#', `amer` as 'ئامێر', `result` as 'عەدەد' FROM `kogasl`");
            //}
            //else if (comboBox8.Text == "کەلار")
            //{
            //    ob.table(datagridview11, "SELECT `aid` as '#', `amer` as 'ئامێر', `result` as 'عەدەد' FROM `kogakalar`");
            //}
            //else
            //{
            //    ob.table(datagridview11, "SELECT `aid` as '#', `amer` as 'ئامێر', `result` as 'عەدەد' FROM `kogahaw`");
            //}
            if (comboBox8.Text == "گشتی")
            {
                ob.table(datagridview11, "SELECT amer.`aid` as '#', `amer`.aname as 'ئامێر',(((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE  amer_garawa_kompanya.state='قبوڵکراو' and `amer_garawa_kompanya`.`aid` = `amer`.`aid`))+((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE (`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND (`amer_garawa`.`state` = 'قبوڵکراو')))) as 'هاتوو',(((SELECT  COALESCE(SUM(`amer_froshtn`.`num`), 0) AS `num` FROM `amer_froshtn` WHERE  `amer_froshtn`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE  amer_bo_koga.state='قبوڵکراو' and `amer_bo_koga`.`aid` = `amer`.`aid`))+((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND amer_garawa_kompanya.state='قبوڵکراو'))) as 'ڕۆشتوو',(((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE  amer_garawa_kompanya.state='قبوڵکراو' and `amer_garawa_kompanya`.`aid` = `amer`.`aid`))-((SELECT  COALESCE(SUM(`amer_froshtn`.`num`), 0) AS `num` FROM `amer_froshtn` WHERE  `amer_froshtn`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE  amer_bo_koga.state='قبوڵکراو' and `amer_bo_koga`.`aid` = `amer`.`aid`))+((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE (`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND (`amer_garawa`.`state` = 'قبوڵکراو'))) -((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND amer_garawa_kompanya.state='قبوڵکراو'))) as 'کۆگا' FROM `amer`");

            }
            else if (comboBox8.Text == "کۆمپانیا")
            {
                ob.table(datagridview11, "SELECT amer.`aid` as '#', `amer`.aname as 'ئامێر',((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE  amer_garawa_kompanya.state='قبوڵکراو' and `amer_garawa_kompanya`.`aid` = `amer`.`aid`)) as 'هاتوو',((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE  amer_bo_koga.state='قبوڵکراو' and `amer_bo_koga`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_froshtn`.`num`), 0) AS `num` FROM `amer_froshtn` WHERE  `amer_froshtn`.`aid` = `amer`.`aid`)) as 'ڕۆشتوو',((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE  amer_garawa_kompanya.state='قبوڵکراو' and `amer_garawa_kompanya`.`aid` = `amer`.`aid`))-((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE  amer_bo_koga.state='قبوڵکراو' and `amer_bo_koga`.`aid` = `amer`.`aid`)+(SELECT  COALESCE(SUM(`amer_froshtn`.`num`), 0) AS `num` FROM `amer_froshtn` WHERE  `amer_froshtn`.`aid` = `amer`.`aid`)) as 'کۆگا' FROM `amer`");

            }
            else
            {
                ob.table(datagridview11, "SELECT  `amer`.`aid` AS `aid`,`amer`.`aname` AS `amer`,((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE (`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو' AND `amer_bo_koga`.`koga` = '" + comboBox8.Text + "') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND (`amer_garawa`.`state` = 'قبوڵکراو') AND `amer_garawa`.`maxzan` = '" + comboBox8.Text + "')) as 'هاتوو',((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid` AND `dawakary_amer_view`.`maxzan` = '" + comboBox8.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND amer_garawa_kompanya.state='قبوڵکراو' AND `amer_garawa_kompanya`.`koga` = '" + comboBox8.Text + "')) as 'ڕوشتوو',((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE (`amer_bo_koga`.`aid` = `amer`.`aid`) AND amer_bo_koga.state='قبوڵکراو' AND `amer_bo_koga`.`koga` = '" + comboBox8.Text + "') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND (`amer_garawa`.`state` = 'قبوڵکراو') AND `amer_garawa`.`maxzan` = '" + comboBox8.Text + "')) -((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid` AND `dawakary_amer_view`.`maxzan` = '" + comboBox8.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND amer_garawa_kompanya.state='قبوڵکراو' AND `amer_garawa_kompanya`.`koga` = '" + comboBox8.Text + "')) AS `کۆگا` FROM `amer`");

            }
            ob.sum(label78, datagridview11, 4);
        }

        private void pictureBox169_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox169_Click_1(object sender, EventArgs e)
        {
            if (datagridview12.SelectedRows.Count != 0)
            {
                int i = datagridview12.SelectedRows[0].Index;
                int id = Convert.ToInt32(datagridview12.Rows[i].Cells[0].Value.ToString());
                int waslda = Convert.ToInt32(datagridview12.Rows[i].Cells[8].Value.ToString());
                String stat = datagridview12.Rows[i].Cells[5].Value.ToString();
                if (stat != "قبوڵکراو")
                {

                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        String numa = "";
                        con.Open();
                        MySqlCommand mddd = new MySqlCommand("SELECT * FROM `dawakary_get` where id='" + id + "'", con);
                        MySqlDataReader rddd = mddd.ExecuteReader();
                        while (rddd.Read())
                        {
                            numa = rddd.GetString("arid");
                        }
                        con.Close();


                        ob.insert_del_up("UPDATE `dawakary_amer` SET `maxzan`='" + comboBox9.Text + "' WHERE `id`='" + id + "'");

                        ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت',maxzan as 'کۆگا', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                        ob.sum(label87, datagridview12, 2);

                    }

                    else
                    {
                        ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                        ob.sum(label87, datagridview12, 2);
                    }
                }
            }
        }

        private void ئامێریوەرگیراوToolStripMenuItem_Click(object sender, EventArgs e)
        {
            amerwargeraw ob = new amerwargeraw();
            ob.Show();
        }

        private void companyagive_SelectedValueChanged(object sender, EventArgs e)
        {
            if (companyagive.SelectedValue != null)
            {
                waslfa.Text = DateTime.Now.ToString("yyyyMMdd") + companyagive.SelectedValue.ToString();
            }
        }

        private void givecus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (givecus.SelectedValue != null)
            {
                waslcus.Text = DateTime.Now.ToString("yyyyMMdd") + givecus.SelectedValue.ToString();
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                waslisp.Text = DateTime.Now.ToString("yyyyMMdd") + comboBox2.SelectedValue.ToString();
            }
        }

        private void pictureBox170_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text == "گشتی")
            {
                ob.table(datagridview11, "SELECT amer.`aid` as '#', `amer`.aname as 'ئامێر',(((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid` and amer_hato.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "'))+((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND `amer_garawa`.`state` = 'قبوڵکراو' AND  amer_garawa.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "'))) as 'هاتوو',((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid` AND  dawakary_amer_view.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "'))  as 'ڕۆشتوو',((((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid` and amer_hato.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "'))-(SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "'))+((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND `amer_garawa`.`state` = 'قبوڵکراو' AND  amer_garawa.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')) - ((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid` AND  dawakary_amer_view.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "'))) as 'کۆگا' FROM `amer`");

            }
            else if (comboBox8.Text == "کۆمپانیا")
            {
                ob.table(datagridview11, "SELECT amer.`aid` as '#', `amer`.aname as 'ئامێر',((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid` and amer_hato.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')) as 'هاتوو',(SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "') as 'ڕۆشتوو',((SELECT  COALESCE(SUM(`amer_hato`.`num`), 0) AS `num` FROM `amer_hato` WHERE `amer_hato`.`aid` = `amer`.`aid` and amer_hato.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "'))-(SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "') as 'کۆگا' FROM `amer`");

            }
            else
            {
                ob.table(datagridview11, "SELECT  `amer`.`aid` AS `aid`,`amer`.`aname` AS `amer`,((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` AND `amer_bo_koga`.`koga` = '" + comboBox8.Text + "' and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND `amer_garawa`.`state` = 'قبوڵکراو' AND `amer_garawa`.`maxzan` = '" + comboBox8.Text + "' and amer_garawa.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')) as 'هاتوو',((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid` AND `dawakary_amer_view`.`maxzan` = '" + comboBox8.Text + "' and dawakary_amer_view.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND `amer_garawa_kompanya`.`koga` = '" + comboBox8.Text + "' and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')) as 'ڕۆشتوو',((SELECT  COALESCE(SUM(`amer_bo_koga`.`number`), 0) AS `num` FROM `amer_bo_koga` WHERE `amer_bo_koga`.`aid` = `amer`.`aid` AND `amer_bo_koga`.`koga` = '" + comboBox8.Text + "' and amer_bo_koga.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "') + (SELECT  COALESCE(SUM(`amer_garawa`.`number`), 0) AS `num` FROM `amer_garawa` WHERE `amer_garawa`.`aid` = `amer`.`aid` AND `amer_garawa`.`state` = 'قبوڵکراو' AND `amer_garawa`.`maxzan` = '" + comboBox8.Text + "' and amer_garawa.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')) - ((SELECT COALESCE(SUM(`dawakary_amer_view`.`adad`), 0) AS `num` FROM `dawakary_amer_view` WHERE dawakary_amer_view.state='قبوڵکراو' and `dawakary_amer_view`.`arid` = `amer`.`aid` AND `dawakary_amer_view`.`maxzan` = '" + comboBox8.Text + "' and dawakary_amer_view.barwar between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')+(SELECT  COALESCE(SUM(`amer_garawa_kompanya`.`number`), 0) AS `num` FROM `amer_garawa_kompanya` WHERE `amer_garawa_kompanya`.`aid` = `amer`.`aid` AND `amer_garawa_kompanya`.`koga` = '" + comboBox8.Text + "' and amer_garawa_kompanya.dates between '" + dateTimePicker73.Text + "' and '" + dateTimePicker74.Text + "')) AS `کۆگا` FROM `amer`");

            }
            ob.sum(label78, datagridview11, 4);

        }

        private void ئامێریتەلەفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 46;
        }

        private void pictureBox171_Click(object sender, EventArgs e)
        {
            ob.table(advancedDataGridView8, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',tebene AS 'تێبینی',state as 'حاڵەت' FROM `talaf_amer`,amer,customer WHERE talaf_amer.aid=amer.aid and customer.cid=talaf_amer.cid and dates between '" + dateTimePicker75.Text + "' and '" + dateTimePicker76.Text + "'");
            ob.sum(label506, advancedDataGridView8, 3);
        }

        private void advancedDataGridView8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (advancedDataGridView8.SelectedRows.Count != 0)
                    {
                        int i = advancedDataGridView8.SelectedRows[0].Index;
                        int id = Convert.ToInt32(advancedDataGridView8.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("delete from talaf_amer where brid='" + id + "'");
                            ob.table(advancedDataGridView8, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',tebene AS 'تێبینی',state as 'حاڵەت' FROM `talaf_amer`,amer,customer WHERE talaf_amer.aid=amer.aid and customer.cid=talaf_amer.cid and dates between '" + dateTimePicker75.Text + "' and '" + dateTimePicker76.Text + "'");
                            ob.sum(label506, advancedDataGridView8, 3);


                        }
                        else
                        {
                            ob.table(advancedDataGridView8, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',tebene AS 'تێبینی',state as 'حاڵەت' FROM `talaf_amer`,amer,customer WHERE talaf_amer.aid=amer.aid and customer.cid=talaf_amer.cid and dates between '" + dateTimePicker75.Text + "' and '" + dateTimePicker76.Text + "'");
                            ob.sum(label506, advancedDataGridView8, 3);

                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void advancedDataGridView8_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (advancedDataGridView8.SelectedRows.Count != 0)
                {
                    int i = advancedDataGridView8.SelectedRows[0].Index;
                    int id = Convert.ToInt32(advancedDataGridView8.Rows[i].Cells[0].Value.ToString());
                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        ob.insert_del_up("UPDATE `talaf_amer` SET `state`='قبوڵکراو' WHERE brid='" + id + "'");
                        ob.table(advancedDataGridView8, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',tebene AS 'تێبینی',state as 'حاڵەت' FROM `talaf_amer`,amer,customer WHERE talaf_amer.aid=amer.aid and customer.cid=talaf_amer.cid and dates between '" + dateTimePicker75.Text + "' and '" + dateTimePicker76.Text + "'");
                        ob.sum(label506, advancedDataGridView8, 3);


                    }
                    else
                    {


                        ob.table(advancedDataGridView8, "SELECT `brid` AS '#',customer.cname as 'بریکار',`wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',tebene AS 'تێبینی',state as 'حاڵەت' FROM `talaf_amer`,amer,customer WHERE talaf_amer.aid=amer.aid and customer.cid=talaf_amer.cid and dates between '" + dateTimePicker75.Text + "' and '" + dateTimePicker76.Text + "'");
                        ob.sum(label506, advancedDataGridView8, 3);



                    }
                }
            }

            catch (Exception)
            {


            }
        }

        private void advancedDataGridView8_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView8);
            ob.sum(label506, advancedDataGridView8, 3);
        }

        private void advancedDataGridView8_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView8);
            ob.sum(label506, advancedDataGridView8, 3);
        }

        private void pictureBox173_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'>ئامێری تەلەفکراوی وەکیل</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView8, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label506.Text + "</p>");
            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void pictureBox172_Click(object sender, EventArgs e)
        {
            ob.toexcel(advancedDataGridView8);
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 47;
            ob.comb(comboBox7, "select * from amer", "aid", "aname");
            ob.table(advancedDataGridView9, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_bo_koga`,amer where amer.aid=amer_bo_koga.aid");
            ob.sum(label515, advancedDataGridView9, 3);
        }

        private void pictureBox174_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("INSERT INTO `amer_bo_koga`(`aid`, `koga`, `number`, `dates`, `tebene`) VALUES ('" + comboBox7.SelectedValue.ToString() + "','" + comboBox5.Text + "','" + materialSingleLineTextField52.Text + "','" + dateTimePicker77.Text + "','" + textBox11.Text + "')");
            ob.table(advancedDataGridView9, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_bo_koga`,amer where amer.aid=amer_bo_koga.aid");
            ob.sum(label515, advancedDataGridView9, 3);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
            ob.a(materialTabControl1.SelectedTab.Controls);
        }

        private void advancedDataGridView9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (advancedDataGridView9.SelectedRows.Count != 0)
                {
                    int i = advancedDataGridView9.SelectedRows[0].Index;
                    int id = Convert.ToInt32(advancedDataGridView9.Rows[i].Cells[0].Value.ToString());
                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ob.insert_del_up("delete from amer_bo_koga where id='" + id + "'");
                        ob.table(advancedDataGridView9, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_bo_koga`,amer where amer.aid=amer_bo_koga.aid");
                        ob.sum(label515, advancedDataGridView9, 3);
                    }
                    else
                    {
                        ob.table(advancedDataGridView9, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_bo_koga`,amer where amer.aid=amer_bo_koga.aid");
                        ob.sum(label515, advancedDataGridView9, 3);
                    }


                }
            }
        }

        private void pictureBox175_Click(object sender, EventArgs e)
        {
            ob.table(advancedDataGridView9, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_bo_koga`,amer where amer.aid=amer_bo_koga.aid and dates between '" + dateTimePicker78.Text + "' and '" + dateTimePicker79.Text + "'");
            ob.sum(label515, advancedDataGridView9, 3);
        }

        private void pictureBox176_Click(object sender, EventArgs e)
        {
            ob.toexcel(advancedDataGridView9);
        }

        private void pictureBox177_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'> ئەو ئامێرانەی ڕۆشتوون بۆ کۆگا</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView9, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label515.Text + "</p>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void advancedDataGridView9_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView9);
            ob.sum(label515, advancedDataGridView9, 3);
        }

        private void advancedDataGridView9_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView9);
            ob.sum(label515, advancedDataGridView9, 3);
        }

        private void advancedDataGridView9_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(advancedDataGridView9, materialSingleLineTextField52, 3);
            ob.change_datagridview_combo(advancedDataGridView9, comboBox7, 1);
            ob.change_datagridview_combo(advancedDataGridView9, comboBox5, 2);
            ob.change_datagridview_picker(advancedDataGridView9, dateTimePicker77, 4);
            ob.change_datagridview(advancedDataGridView9, textBox11, 5);
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 48;
            ob.comb(comboBox12, "select * from amer", "aid", "aname");
            ob.table(advancedDataGridView10, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_garawa_kompanya`,amer where amer.aid=amer_garawa_kompanya.aid");
            ob.sum(label518, advancedDataGridView10, 3);
        }

        private void pictureBox181_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("INSERT INTO `amer_garawa_kompanya`(`aid`, `koga`, `number`, `dates`, `tebene`) VALUES ('" + comboBox12.SelectedValue.ToString() + "','" + comboBox11.Text + "','" + materialSingleLineTextField53.Text + "','" + dateTimePicker82.Text + "','" + textBox12.Text + "')");
            ob.table(advancedDataGridView10, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_garawa_kompanya`,amer where amer.aid=amer_garawa_kompanya.aid");
            ob.sum(label518, advancedDataGridView10, 3);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
            ob.a(materialTabControl1.SelectedTab.Controls);
        }

        private void advancedDataGridView10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (advancedDataGridView10.SelectedRows.Count != 0)
                {
                    int i = advancedDataGridView10.SelectedRows[0].Index;
                    int id = Convert.ToInt32(advancedDataGridView10.Rows[i].Cells[0].Value.ToString());
                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ob.insert_del_up("delete from amer_garawa_kompanya where id='" + id + "'");
                        ob.table(advancedDataGridView10, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_garawa_kompanya`,amer where amer.aid=amer_garawa_kompanya.aid");
                        ob.sum(label518, advancedDataGridView10, 3);
                    }
                    else
                    {
                        ob.table(advancedDataGridView10, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_garawa_kompanya`,amer where amer.aid=amer_garawa_kompanya.aid");
                        ob.sum(label518, advancedDataGridView10, 3);
                    }


                }
            }
        }

        private void pictureBox178_Click(object sender, EventArgs e)
        {
            ob.table(advancedDataGridView10, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_garawa_kompanya`,amer where amer.aid=amer_garawa_kompanya.aid and dates between '" + dateTimePicker80.Text + "' and '" + dateTimePicker81.Text + "'");
            ob.sum(label518, advancedDataGridView10, 3);
        }

        private void pictureBox179_Click(object sender, EventArgs e)
        {
            ob.toexcel(advancedDataGridView10);
        }

        private void pictureBox180_Click(object sender, EventArgs e)
        {
            easyHTMLReports1.Clear();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >kalar bazar<br> Talari M.Mahmoud <br> 3nd floor Sulaymaniyah,IRAQ <br> Tel:07711550366 - 07502478020</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-110px'> ئەو ئامێرانەی گەڕاونەتەوە بۆ کۆمپانیا</h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>" + DateTime.Now.ToString("yyyy/MM/dd") + "<br>User " + Form1.us + "</p>");


            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddDatagridView(advancedDataGridView10, "style='width:100%; direction:rtl;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>کۆی گشتی</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>" + label518.Text + "</p>");

            easyHTMLReports1.ShowPrintPreviewDialog();
        }

        private void advancedDataGridView10_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView10);
            ob.sum(label518, advancedDataGridView10, 3);
        }

        private void advancedDataGridView10_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView10);
            ob.sum(label518, advancedDataGridView10, 3);
        }

        private void advancedDataGridView10_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(advancedDataGridView10, materialSingleLineTextField53, 3);
            ob.change_datagridview_combo(advancedDataGridView10, comboBox12, 1);
            ob.change_datagridview_combo(advancedDataGridView10, comboBox11, 2);
            ob.change_datagridview_picker(advancedDataGridView10, dateTimePicker82, 4);
            ob.change_datagridview(advancedDataGridView10, textBox12, 5);
        }

        private void advancedDataGridView9_DoubleClick(object sender, EventArgs e)
        {
            if (advancedDataGridView9.SelectedRows.Count != 0)
            {
                int i = advancedDataGridView9.SelectedRows[0].Index;
                int id = Convert.ToInt32(advancedDataGridView9.Rows[i].Cells[0].Value.ToString());

                String stat = advancedDataGridView9.Rows[i].Cells[6].Value.ToString();
                if (stat != "قبوڵکراو")
                {

                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {


                        ob.insert_del_up("UPDATE `amer_bo_koga` SET `state`='قبوڵکراو' WHERE `id`='" + id + "'");

                        ob.table(advancedDataGridView9, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_bo_koga`,amer where amer.aid=amer_bo_koga.aid");
                        ob.sum(label515, advancedDataGridView9, 3);
                    }

                    else
                    {
                        ob.table(advancedDataGridView9, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_bo_koga`,amer where amer.aid=amer_bo_koga.aid");
                        ob.sum(label515, advancedDataGridView9, 3);
                    }
                }
            }
            //}
            //catch (Exception)
            //{


            //}
        }

        private void advancedDataGridView10_DoubleClick(object sender, EventArgs e)
        {
            if (advancedDataGridView10.SelectedRows.Count != 0)
            {
                int i = advancedDataGridView10.SelectedRows[0].Index;
                int id = Convert.ToInt32(advancedDataGridView10.Rows[i].Cells[0].Value.ToString());

                String stat = advancedDataGridView10.Rows[i].Cells[6].Value.ToString();
                if (stat != "قبوڵکراو")
                {

                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {


                        ob.insert_del_up("UPDATE `amer_garawa_kompanya` SET `state`='قبوڵکراو' WHERE `id`='" + id + "'");

                        ob.table(advancedDataGridView10, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_garawa_kompanya`,amer where amer.aid=amer_garawa_kompanya.aid");
                        ob.sum(label518, advancedDataGridView10, 3);
                    }

                    else
                    {
                        ob.table(advancedDataGridView10, "SELECT `id` as '#', amer.`aname` as 'ئامێر',koga as 'کۆگا', `number` as 'عەدەد', DATE_FORMAT(`dates`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی',state as 'حاڵەت' FROM `amer_garawa_kompanya`,amer where amer.aid=amer_garawa_kompanya.aid");
                        ob.sum(label518, advancedDataGridView10, 3);
                    }
                }
            }
        }

        private void pictureBox182_Click(object sender, EventArgs e)
        {
            ob.table(advancedDataGridView11, "SELECT `brid` AS '#', `wasl` AS 'ژ.وەسڵ', `num` AS 'عەدەد', `price` AS 'نرخ', `sumprice` AS 'کۆی نرخ', DATE_FORMAT(`dates`, '%Y/%m/%d') AS 'بەروار', amer.aname AS 'جۆری ئامێر',customer.cname as 'بریکار',(select COALESCE(sum(number),0)  from storage_amer_view_customer where storage_amer_view_customer.aid=froshtn_amer.aid and storage_amer_view_customer.cusid=froshtn_amer.cid) as 'ئامێری ماوە',tebene AS 'تێبینی' FROM `froshtn_amer`,amer,customer WHERE froshtn_amer.aid=amer.aid and customer.cid=froshtn_amer.cid and froshtn_amer.price=0 and  DATE_FORMAT(`dates`, '%Y/%m/%d') between '" + dateTimePicker83.Text + "' and '" + dateTimePicker84.Text + "'");
            ob.sum(label532, advancedDataGridView11, 2);

        }

        private void ئامێریفرۆشراویبریکاربەسفرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 49;
        }

        private void advancedDataGridView11_FilterStringChanged(object sender, EventArgs e)
        {
            ob.adfilter(advancedDataGridView11);
            ob.sum(label532, advancedDataGridView11, 2);
        }

        private void advancedDataGridView11_SortStringChanged(object sender, EventArgs e)
        {
            ob.adsort(advancedDataGridView11);
            ob.sum(label532, advancedDataGridView11, 2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label501_Click(object sender, EventArgs e)
        {

        }

        private void data36_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(data36, comboBox13, 4);
            ob.change_datagridview_combo(data36, comboBox14, 3);
            ob.change_datagridview_picker(data36, dateTimePicker85, 2);
            //ob.change_datagridview(data36, textBox13, 5);
        }

        private void pictureBox146_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (data36.SelectedRows.Count != 0)
                    {
                        int i = data36.SelectedRows[0].Index;
                        String wasl = data36.Rows[i].Cells[5].Value.ToString();
                        string newCid = comboBox14.SelectedValue.ToString();  // Replace with the new value for cname
                        string newMaxzan = comboBox13.Text; // Replace with the new value for maxzan
                        string newBarwar = dateTimePicker85.Text;
                        string updateQuery = "UPDATE dawakary_amer " +
                             "SET `maxzan` = '" + newMaxzan + "'" + ", `cus` = '" + newCid + "', `barwar` = '" + newBarwar + "'" +
                             "WHERE `wasl` = '" + wasl + "'";
                        ob.insert_del_up(updateQuery);
                        //ob.a(this.Controls);
                        ob.table(data36, "SELECT `id` as '#',sum(`adad`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `cname` as 'بریکار',`maxzan` as 'کۆگا',`wasl` as 'وەسڵ',`state` as 'حالەت' FROM `dawakary_amer_view` group by wasl");
                        ob.count(label365, data36, 2);
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void datagridview12_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(datagridview12, amerfield, 1);

            ob.change_datagridview_textfild(datagridview12, waslfield, 8);
            ob.change_datagridview_textfild(datagridview12, addadfield, 2);
            ob.change_datagridview_combo(datagridview12, brykarfield, 5);
            ob.change_datagridview_combo(datagridview12, kogafield, 7);
            ob.change_datagridview_combo(datagridview12, haletbox, 6);

            ob.change_datagridview(datagridview12, textBox13, 4);

            ob.change_datagridview_picker(datagridview12, barwarf, 3);
        }

        private void pictureBox184_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (datagridview12.SelectedRows.Count != 0)
                    {
                        int i = datagridview12.SelectedRows[0].Index;
                        String idToUpdate = datagridview12.Rows[i].Cells[0].Value.ToString();
                        String amerValue = amerfield.SelectedValue.ToString();
                        String adadValue = addadfield.Text;
                        DateTime barwarValue = DateTime.Parse(barwarf.Text);
                        String noteValue = textBox13.Text;
                        String cusValue = brykarfield.SelectedValue.ToString();
                        String waslValue = waslfield.Text;
                        String maxzanValue = kogafield.Text;
                        String halet = haletbox.SelectedText.ToString();

                        // Construct the SQL query
                        String updateQuery = $"UPDATE dawakary_amer SET amer = {amerValue}, adad = {adadValue}, barwar = '{barwarValue.ToString("yyyy-MM-dd")}', " +
                                       $"note = '{noteValue}', cus = {cusValue}, wasl = {waslValue}, maxzan = '{maxzanValue}', state = '{halet}' " +
                                       $"WHERE id = {idToUpdate}";
                        ob.insert_del_up(updateQuery);
                        //ob.a(this.Controls);
                        ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت',maxzan as 'کۆگا', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslValue + "'");
                        ob.sum(label87, datagridview12, 2);
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void pictureBox185_Click(object sender, EventArgs e)
        {
            try
            {

                //int i = datagridview12.SelectedRows[0].Index;
                String amerValue = amerfield.SelectedValue.ToString();
                String adadValue = addadfield.Text;
                DateTime barwarValue = DateTime.Parse(barwarf.Text);
                String noteValue = textBox13.Text;
                String cusValue = brykarfield.SelectedValue.ToString();
                String waslValue = waslfield.Text;
                String maxzanValue = kogafield.Text;
                String halet = haletbox.SelectedText.ToString();
                if (halet == "")
                {
                    halet = "قبوڵنەکراو";
                }

                // Construct the SQL query for INSERT
                String insertQuery = $"INSERT INTO dawakary_amer (amer, adad, barwar, note, cus, wasl, maxzan,state) " +
                                     $"VALUES ({amerValue}, {adadValue}, '{barwarValue.ToString("yyyy-MM-dd")}', " +
                                     $"'{noteValue}', {cusValue}, {waslValue}, '{maxzanValue}', '{halet}')";

                ob.insert_del_up(insertQuery);
                ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', " +
                                        "`note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت',maxzan as 'کۆگا', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` " +
                                        $"WHERE wasl='{waslValue}'");
                ob.sum(label87, datagridview12, 2);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();


            }
            catch (Exception)
            {


            }
        }

        private void pictureBox183_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT wasl FROM new_system_online.dawakary_amer_view ORDER BY wasl DESC LIMIT 1;";


                con.Open();
                MySqlCommand mss = new MySqlCommand(query, con);
                MySqlDataReader rd = mss.ExecuteReader();
                int waslda = 0;
                while (rd.Read())
                {
                    waslda = rd.GetInt32("wasl");
                }
                con.Close();
                waslda += 1;

                string newCid = comboBox14.SelectedValue.ToString();  // Replace with the new value for cname
                string newMaxzan = comboBox13.Text; // Replace with the new value for maxzan
                string newBarwar = dateTimePicker85.Text;
                materialTabControl1.SelectedIndex = 10;
                ob.table(datagridview12, "SELECT `id` as '#', `aname` as 'ئامێر', `adad` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `note` as 'تێبینی', `cname` as 'بریکار', `state` as 'حاڵەت',maxzan as 'کۆگا', `wasl` as 'وەسڵ' FROM `dawakary_amer_view` where wasl='" + waslda + "'");
                ob.sum(label87, datagridview12, 2);
                ob.comb(brykarfield, "SELECT * FROM customer", "cid", "cname");
                ob.comb(amerfield, "SELECT * FROM amer", "aid", "aname");
                waslfield.Text = waslda.ToString();
                kogafield.ResetText();
                brykarfield.ResetText();
                kogafield.SelectedText = newMaxzan;
                comboBox9.SelectedText = newMaxzan;
                brykarfield.SelectedValue = newCid;

            }

            catch (Exception)
            {


            }
        }

        private void pictureBox187_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox186_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 37;
        }

        private void advancedDataGridView12_DoubleClick(object sender, EventArgs e)
        {
            if (advancedDataGridView12.SelectedRows.Count != 0)
            {
                int i = advancedDataGridView12.SelectedRows[0].Index;
                int id = Convert.ToInt32(advancedDataGridView12.Rows[i].Cells[0].Value.ToString());

                String stat = advancedDataGridView12.Rows[i].Cells[5].Value.ToString();
                if (stat != "قبوڵکراو")
                {

                    if (MessageBox.Show("دڵنیای لەقبوڵکردن؟", "قبوڵکردن", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        con.Open();
                        MySqlCommand mss = new MySqlCommand("SELECT * FROM `amer_garawa` WHERE `id`='" + id + "'", con);
                        MySqlDataReader rd = mss.ExecuteReader();
                        String adad = "";
                        String amer = "";
                        String cus = "";
                        String wasl = "";
                        String dates = "";
                        String maxzan = "";
                        while (rd.Read())
                        {
                            adad = rd.GetString("number");
                            amer = rd.GetString("aid");
                            cus = rd.GetString("cus");
                            wasl = rd.GetString("wasl");
                            dates = rd.GetString("barwar");
                            maxzan = rd.GetString("maxzan");
                        }
                        con.Close();
                        ob.insert_del_up("UPDATE `amer_garawa` SET `state`='قبوڵکراو' WHERE `id`='" + id + "'");
                        ob.insert_del_up("call insert_storage_amer('" + amer + "','" + adad + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                        ob.insert_del_up("call delete_storage_amer_customer('" + amer + "','" + adad + "','" + cus + "')");
                        ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + wasl + "'");
                        ob.sum(label545, advancedDataGridView12, 2);

                    }
                    else
                    {
                        ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + wasl + "'");
                        ob.sum(label545, advancedDataGridView12, 2);

                    }
                }
            }
        }

        private void advancedDataGridView12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (advancedDataGridView12.SelectedRows.Count != 0)
                    {
                        int i = advancedDataGridView12.SelectedRows[0].Index;
                        int id = Convert.ToInt32(advancedDataGridView12.Rows[i].Cells[0].Value.ToString());

                        String stat = advancedDataGridView12.Rows[i].Cells[5].Value.ToString();
                        if (MessageBox.Show("دڵنیای لە سڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (stat == "قبوڵکراو")
                            {
                                con.Open();
                                MySqlCommand mss = new MySqlCommand("SELECT * FROM `amer_garawa` WHERE `id`='" + id + "'", con);
                                MySqlDataReader rd = mss.ExecuteReader();
                                String adad = "";
                                String amer = "";
                                String cus = "";
                                String wasl = "";
                                String dates = "";
                                while (rd.Read())
                                {
                                    adad = rd.GetString("number");
                                    amer = rd.GetString("aid");
                                    cus = rd.GetString("cus");
                                    wasl = rd.GetString("wasl");
                                    dates = rd.GetString("barwar");

                                }
                                con.Close();
                                ob.insert_del_up("call delete_storage_amer('" + amer + "','" + adad + "')");
                                ob.insert_del_up("call insert_storage_amer_customer('" + amer + "','" + adad + "','" + cus + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                                ob.insert_del_up("DELETE FROM `amer_garawa` WHERE id='" + id + "'");

                                ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + wasl + "'");
                                ob.sum(label545, advancedDataGridView12, 2);
                            }
                            else
                            {
                                ob.insert_del_up("DELETE FROM `amer_garawa` WHERE id='" + id + "'");
                                ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + wasl + "'");
                                ob.sum(label545, advancedDataGridView12, 2);
                            }
                        }
                        else
                        {
                            ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + wasl + "'");
                            ob.sum(label545, advancedDataGridView12, 2);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox188_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT wasl FROM new_system_online.amer_garawa ORDER BY wasl DESC LIMIT 1;";


                con.Open();
                MySqlCommand mss = new MySqlCommand(query, con);
                MySqlDataReader rd = mss.ExecuteReader();
                int waslda = 0;
                while (rd.Read())
                {
                    waslda = rd.GetInt32("wasl");
                }
                con.Close();
                waslda += 1;

                string newCid = comboBox15.SelectedValue.ToString();  // Replace with the new value for cname
                string newMaxzan = comboBox16.Text; // Replace with the new value for maxzan
                string newBarwar = dateTimePicker87.Text;
                materialTabControl1.SelectedIndex = 50;
                ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + waslda + "'");
                ob.sum(label545, advancedDataGridView12, 2);
                ob.comb(comboBox18, "SELECT * FROM customer", "cid", "cname");
                ob.comb(comboBox20, "SELECT * FROM amer", "aid", "aname");
                wasl55.Text = waslda.ToString();

                comboBox19.SelectedText = newMaxzan;
                comboBox18.SelectedValue = newCid;
                dateTimePicker86.Text = DateTime.Parse(newBarwar).ToString("yyyy/MM/dd");

            }

            catch (Exception)
            {


            }
        }

        private void pictureBox190_Click(object sender, EventArgs e)
        {
            try
            {

                //int i = datagridview12.SelectedRows[0].Index;
                String amerValue = comboBox20.SelectedValue.ToString();
                String adadValue = addad33.Text;
                DateTime barwarValue = DateTime.Parse(dateTimePicker86.Text);
                String noteValue = textBox15.Text;
                String cusValue = comboBox18.SelectedValue.ToString();
                String waslValue = wasl55.Text;
                String maxzanValue = comboBox19.Text;
                String halet = comboBox17.SelectedText.ToString();
                if (halet == "")
                {
                    halet = "قبوڵنەکراو";
                }

                // Construct the SQL query for INSERT
                String insertQuery = $"INSERT INTO amer_garawa (aid, number, barwar, tebene, cus, wasl, maxzan,state) " +
                                     $"VALUES ({amerValue}, {adadValue}, '{barwarValue.ToString("yyyy-MM-dd")}', " +
                                     $"'{noteValue}', {cusValue}, {waslValue}, '{maxzanValue}', '{halet}')";

                ob.insert_del_up(insertQuery);
                ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + waslValue + "'");
                ob.sum(label545, advancedDataGridView12, 2);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();


            }
            catch (Exception)
            {


            }
        }

        private void pictureBox189_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (advancedDataGridView12.SelectedRows.Count != 0)
                    {
                        int i = advancedDataGridView12.SelectedRows[0].Index;
                        String idToUpdate = advancedDataGridView12.Rows[i].Cells[0].Value.ToString();
                        String amerValue = comboBox20.SelectedValue.ToString();
                        String adadValue = addad33.Text;
                        DateTime barwarValue = DateTime.Parse(dateTimePicker86.Text);
                        String noteValue = textBox15.Text;
                        String cusValue = comboBox18.SelectedValue.ToString();
                        String waslValue = wasl55.Text;
                        String maxzanValue = comboBox19.Text;
                        String halet = comboBox17.SelectedText.ToString();
                        if (halet == "")
                        {
                            halet = "قبوڵنەکراو";
                        }
                        // Construct the SQL query
                        String updateQuery = $"UPDATE amer_garawa SET aid = {amerValue}, number = {adadValue}, barwar = '{barwarValue.ToString("yyyy-MM-dd")}', " +
                                       $"tebene = '{noteValue}', cus = {cusValue}, wasl = {waslValue}, maxzan = '{maxzanValue}', state = '{halet}' " +
                                       $"WHERE id = {idToUpdate}";
                        ob.insert_del_up(updateQuery);
                        //ob.a(this.Controls);
                        ob.table(advancedDataGridView12, "SELECT `id` as '#', `aname` as 'ئامێر', `number` as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی', `state` as 'حاڵەت', `wasl` as 'وەسڵ',customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  and  `wasl` = '" + waslValue + "'");
                        ob.sum(label545, advancedDataGridView12, 2);
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void pictureBox187_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (dataamerback.SelectedRows.Count != 0)
                    {
                        int i = dataamerback.SelectedRows[0].Index;
                        String wasl = dataamerback.Rows[i].Cells[0].Value.ToString();
                        string newCid = comboBox15.SelectedValue.ToString();  // Replace with the new value for cname
                        string newMaxzan = comboBox16.Text; // Replace with the new value for maxzan
                        string newBarwar = dateTimePicker87.Text;
                        string updateQuery = "UPDATE amer_garawa " +
                             "SET `maxzan` = '" + newMaxzan + "'" + ", `cus` = '" + newCid + "', `barwar` = '" + newBarwar + "'" +
                             "WHERE `wasl` = '" + wasl + "'";
                        ob.insert_del_up(updateQuery);
                        //ob.a(this.Controls);
                        ob.table(dataamerback, "SELECT `wasl` as  'وەسڵ', sum(`number`) as 'عەدەد', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `state` as 'حاڵەت', customer.cname as 'بریکار',amer_garawa.maxzan as 'کۆگا' FROM `amer_garawa`,amer,customer where amer_garawa.aid=amer.aid and amer_garawa.cus=customer.cid  group by wasl;");
                        ob.sum(label385, dataamerback, 2);
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {


                }

            }
        }

        private void dataamerback_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(dataamerback, comboBox15, 4);
            ob.change_datagridview_combo(dataamerback, comboBox16, 5);
            ob.change_datagridview_picker(dataamerback, dateTimePicker87, 2);
        }

        private void advancedDataGridView12_SelectionChanged(object sender, EventArgs e)
        {

            ob.change_datagridview_textfild(advancedDataGridView12, addad33, 2);
            ob.change_datagridview_textfild(advancedDataGridView12, wasl55, 6);
            ob.change_datagridview_combo(advancedDataGridView12, comboBox17, 5);
            ob.change_datagridview_combo(advancedDataGridView12, comboBox18, 7);
            ob.change_datagridview_combo(advancedDataGridView12, comboBox19, 8);
            ob.change_datagridview_combo(advancedDataGridView12, comboBox20, 1);

            ob.change_datagridview(advancedDataGridView12, textBox15, 4);

            ob.change_datagridview_picker(advancedDataGridView12, dateTimePicker86, 3);

        }

        private void advancedDataGridView12_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in advancedDataGridView12.Rows)
                // do sonmthind

                if (Convert.ToString(row.Cells[5].Value).Equals("قبوڵنەکراو"))
                {
                    if (row.Index <= advancedDataGridView12.RowCount - 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
        }

        private void dataamerback_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dataamerback.Rows)
                // do sonmthind

                if (Convert.ToString(row.Cells[3].Value).Equals("قبوڵنەکراو"))
                {
                    if (row.Index <= dataamerback.RowCount - 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            chaneuserinfo os = new chaneuserinfo();
            os.Show();
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 51;
            ob.table(gwastData, "SELECT `id` as '#', `amount` as 'عەدەد',`kid` as 'نيردەر',`cus` as 'وەرگر', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی' FROM `exchange_balance_view`");
            ob.sum(totalP, gwastData, 1);
            ob.comb(comboBox21, "SELECT * FROM customer", "cid", "cname");
            ob.comb(comboBox22, "SELECT * FROM customer", "cid", "cname");
        }

        private void pictureBox191_Click(object sender, EventArgs e)
        {
            ob.table(gwastData, "SELECT `id` as '#', `amount` as 'عەدەد',`kid` as 'نيردەر',`cus` as 'وەرگر', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی' FROM `exchange_balance_view` where  DATE_FORMAT(`barwar`, '%Y/%m/%d') between '" + startDate.Text + "' and '" + endD.Text + "'");
            ob.sum(totalP, gwastData, 1);
        }

        private void gwastData_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(gwastData, waslgwastnawa, 0);
            ob.change_datagridview_textfild(gwastData, brgwastnawa, 1);
            ob.change_datagridview_combo(gwastData, comboBox21, 2);
            ob.change_datagridview_combo(gwastData, comboBox22, 3);
            ob.change_datagridview(gwastData, textBox14, 5);
            ob.change_datagridview_picker(gwastData, dateTimePicker88, 4);
        }

        private void pictureBox192_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try { 
                    if (gwastData.SelectedRows.Count != 0)
                    {
                        int i = gwastData.SelectedRows[0].Index;
                        String idToUpdate = gwastData.Rows[i].Cells[0].Value.ToString();
                        String kidValue = comboBox21.SelectedValue.ToString();
                        String adadValue = brgwastnawa.Text;
                        DateTime barwarValue = DateTime.Parse(dateTimePicker88.Text);
                        String noteValue = textBox14.Text;
                        String cusValue = comboBox22.SelectedValue.ToString();
                        // Construct the SQL query
                        String updateQuery = $"UPDATE exchange_balance SET kid = {kidValue}, amount = {adadValue}, barwar = '{barwarValue.ToString("yyyy-MM-dd")}', " +
                                       $"tebene = '{noteValue}', cus = {cusValue} " +
                                       $"WHERE id = {idToUpdate}";
                        ob.insert_del_up(updateQuery);
                        //ob.a(this.Controls);
                        ob.table(gwastData, "SELECT `id` as '#', `amount` as 'عەدەد',`kid` as 'نيردەر',`cus` as 'وەرگر', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی' FROM `exchange_balance_view`");
                        ob.sum(totalP, gwastData, 1);
                        messageboxsuc obb = new messageboxsuc();
                        obb.Show();
                    }
                }
                catch (Exception)
                {
                    messageboxfail obb = new messageboxfail();
                    obb.Show();
                }

            }

        }

        private void pictureBox193_Click(object sender, EventArgs e)
        {
            try
            {

                //int i = gwastData.SelectedRows[0].Index;
                String kidValue = comboBox21.SelectedValue.ToString();
                String adadValue = brgwastnawa.Text;
                DateTime barwarValue = DateTime.Parse(dateTimePicker88.Text);
                String noteValue = textBox14.Text;
                String cusValue = comboBox22.SelectedValue.ToString();

                // Construct the SQL query for INSERT
                String insertQuery = $"INSERT INTO exchange_balance (kid, amount, barwar, tebene, cus) " +
                                     $"VALUES ({kidValue}, {adadValue}, '{barwarValue.ToString("yyyy-MM-dd")}', " +
                                     $"'{noteValue}', {cusValue})";

                ob.insert_del_up(insertQuery);

                ob.table(gwastData, "SELECT `id` as '#', `amount` as 'عەدەد',`kid` as 'نيردەر',`cus` as 'وەرگر', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی' FROM `exchange_balance_view`");
                ob.sum(totalP, gwastData, 1);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();


            }
            catch (Exception)
            {
                messageboxfail obb = new messageboxfail();
                obb.Show();
            }
        }

        private void gwastData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (gwastData.SelectedRows.Count != 0)
                    {
                        int i = gwastData.SelectedRows[0].Index;
                        int id = Convert.ToInt32(gwastData.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لە سڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            
                            ob.insert_del_up("DELETE FROM `exchange_balance` WHERE id='" + id + "'");
                            ob.table(gwastData, "SELECT `id` as '#', `amount` as 'عەدەد',`kid` as 'نيردەر',`cus` as 'وەرگر', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی' FROM `exchange_balance_view`");
                            ob.sum(totalP, gwastData, 1);


                        }
                        else
                        {
                            ob.table(gwastData, "SELECT `id` as '#', `amount` as 'عەدەد',`kid` as 'نيردەر',`cus` as 'وەرگر', DATE_FORMAT(`barwar`, '%Y/%m/%d') as 'بەروار', `tebene` as 'تێبینی' FROM `exchange_balance_view`");
                            ob.sum(totalP, gwastData, 1);
                        }
                    }
                }
                catch (Exception)
                {
                    messageboxfail obb = new messageboxfail();
                    obb.Show();

                }
            }

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void datar1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datr4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datr6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datr5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datar2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField5_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label155_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker17_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label167_Click(object sender, EventArgs e)
        {

        }

        private void label168_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker63_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label465_Click(object sender, EventArgs e)
        {

        }

        private void label487_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField39_Click(object sender, EventArgs e)
        {

        }

        private void vipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 52;
            ob.table(vipData, "call select_vip_company();");
            ob.count(label570, vipData, 0);
        }

        private void pictureBox197_Click(object sender, EventArgs e)
        {
            ob.insert_del_up("call insert_vip_company('" + namevipcompany.Text + "','" + phonevipcompany.Text + "','" + addressvipcompany.Text + "')");
            ob.table(vipData, "call select_vip_company();");
            ob.count(label570, vipData, 0);
            ob.a(this.Controls);
            messageboxsuc obb = new messageboxsuc();
            obb.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 52;
            ob.table(vipData, "call select_vip_company();");
            ob.count(label570, vipData, 0);
        }

        private void پێدانیمێگاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 53;
            ob.comb(ccidinput, "SELECT * FROM vip_company", "ccid", "name");
            ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` order by mbids desc");
            ob.sum(label586, vipsellData, 2);
            ob.sum(label588, vipsellData, 3);
        }

        private void pictureBox199_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                double sump = Convert.ToDouble(sumpinput.Text);
                double price = Convert.ToDouble(priceinput.Text);
                double nomb = Convert.ToDouble(nombinput.Text);
                ob.insert_del_up("INSERT INTO `vip_sell`(`nomb`, `price`, `sump`, `dates1`, `dates`, `ccid`, `wasl`, `tebene`) VALUES ('" + nomb + "','" + price + "','" + sump + "','" + dates1input.Text + "','" + datesinput.Text + "','" + ccidinput.SelectedValue.ToString() + "','" + waslinput.Text + "','" + tebeneinput.Text + "')");
                ob.a(this.Controls);
                ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` order by mbids desc");
                ob.sum(label586, vipsellData, 2);
                ob.sum(label588, vipsellData, 3);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();
            }
        }

        private void priceinput_TextChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string currencySymbol = "IQD ";

            easyHTMLReports1.Clear();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h1 style='color:cyan;'>Online Company Ltd</h1>");
            easyHTMLReports1.AddString("<p >For information technology<br> Electronic supplies <br> Internet services</p>");

            easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top:-150px;'");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h2>" + ccidinput.Text + "</h2>");
            con.Open();
            MySqlCommand md = new MySqlCommand("SELECT * FROM `vip_company` where ccid='" + ccidinput.SelectedValue.ToString() + "'", con);
            MySqlDataReader rd = md.ExecuteReader();
            while (rd.Read())
            {
                easyHTMLReports1.AddString("<p>Tel: " + rd.GetString("phone") + "</p>");

            }

            con.Close();
            easyHTMLReports1.AddString("<h2 align=right style='color:cyan; margin-top:-80px'><i>Invoice</i></h2>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;'>Invoice No#   " + walid.Text + "<br>Date#  " + DateTime.Now.ToString("yyyy/MM/dd") + "<br><br> </p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<table style='font-family: arial, sans-serif;font-size:14px; border-collapse: collapse;width: 100%;'>");
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<th  style='border: 1px solid gray;text-align: left;padding: 8px;'>Description</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;' >Start Date</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>End Date</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Amount of internet</th>");
            easyHTMLReports1.AddString("<th style='border: 1px solid gray;text-align: left;padding: 8px;'>Price</th>");
            easyHTMLReports1.AddString("</tr>");

            con.Open();
            double sm = 0;
            MySqlCommand mdd = new MySqlCommand("SELECT `mbids`, `wasl`, `tebene`, `dates1`, `dates`, `price`, `nomb`, Truncate(`sump`,2) as 'amount' FROM `vip_sell` where wasl='" + walid.Text + "'", con);
            MySqlDataReader rdd = mdd.ExecuteReader();
            while (rdd.Read())
            {
                double amount = Convert.ToDouble(rdd.GetString("amount"));
                string formattedamount = amount.ToString("N0") + " IQD";
                string startDate = DateTime.Parse(rdd.GetString("dates1")).ToString("yyyy/MM/dd");
                string endDate = DateTime.Parse(rdd.GetString("dates")).ToString("yyyy/MM/dd");
                easyHTMLReports1.AddString("<tr  style='border: 1px solid gray; text-align: left;padding: 8px;'>");
                easyHTMLReports1.AddString("<td  style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:black; font-size:14px;'>" + rdd.GetString("tebene") + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray; height:10px;text-align: left;padding: 8px; color:black; font-size:14px;' >" + startDate+ "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:black; font-size:14px;'>" + endDate + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px; text-align: left;padding: 8px; color:black; font-size:14px;'>" + rdd.GetString("nomb") + " Megabt" + "</td>");
                easyHTMLReports1.AddString("<td style='border: 1px solid gray;height:10px;text-align: left;padding: 8px; color:black; font-size:14px;'>" + formattedamount + "</td>"); 
                easyHTMLReports1.AddString("</tr>");
                sm += Convert.ToDouble(rdd.GetString("amount"));
            }

            con.Close();
            string formattedTotal = formattedTotal = RoundToNearestThreshold(sm).ToString("N0") + " IQD";
            
            easyHTMLReports1.AddString("<tr  style='border: 1px solid gray;text-align: left;padding: 8px;'>");
            easyHTMLReports1.AddString("<td  style='border: 1px solid gray;text-align: left;padding: 8px; color:black; font-size:14px;' colspan=4>Total:</td>");
            easyHTMLReports1.AddString("<td style='border: 1px solid gray;text-align: left;padding: 8px; color:black; font-size:14px;'>" + formattedTotal + "</td>");
            easyHTMLReports1.AddString("</tr>");
            easyHTMLReports1.AddString("</table>");

            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p  style='border: 1px solid gray;text-align: left;padding: 8px; color:blue; float:right;'>" + formattedTotal + "</p>");
            easyHTMLReports1.AddString("<p style='border: 1px solid gray;text-align: left;padding: 8px; color:blue;  float:right;'>Total:</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>Dear Client <br>Please Proceed with the payment within 4 days<br>Online Company accept cash payment delivered to the Kalar Bazar-Sulaymaniyah,IRAQ </p>");
            easyHTMLReports1.AddString("<p align=right style='font-size:14px;color:blue;'> Accountant / " + Form1.us + "<br> </p>");
            easyHTMLReports1.AddString("<p style='opacity:4; color:transparent; font-size:12px;'>if you have any question concering this invoice please contact <br>096407729790070 – 096407512330605<br>acc@onlineco.net<br>PS:Transfer fees should not effect on the invoice amount</p>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<h4 align=center style='font-size:14px;margin-top:120px'>   Online Company - Barzani Namir Road , Opposite Al Qassab Oil -  Erbil, IRAQ  -    Tel: 07501303445 </h4>");

            easyHTMLReports1.ShowPrintPreviewDialog();


        }

        private void walid_TextChanged(object sender, EventArgs e)
        {
            if (walid.Text != "" && walid.Text != "0")
            {

                con.Close();
                con.Open();
                MySqlCommand md = new MySqlCommand("SELECT * FROM `vip_sell` where wasl='" + walid.Text + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                while (rd.Read())
                {
                    cuscom.SelectedValue = rd.GetString("ccid");

                }
                con.Close();
                ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` and wasl='" + walid.Text + "' order by mbids desc");
                ob.sum(label586, vipsellData, 2);
                ob.sum(label588, vipsellData, 3);
            }
            else
            {

                ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا',DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` order by mbids desc");
                ob.sum(label586, vipsellData, 2);
                ob.sum(label588, vipsellData, 3);

            }
        }

        private void vipsellData_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_combo(vipsellData, ccidinput, 6);
            ob.change_datagridview_textfild(vipsellData, nombinput, 1);
            ob.change_datagridview_textfild(vipsellData, priceinput, 2);
            ob.change_datagridview_textfild(vipsellData, sumpinput, 3);
            ob.change_datagridview_picker(vipsellData, dates1input, 4);
            ob.change_datagridview_picker(vipsellData, datesinput, 5);
            ob.change_datagridview_textfild(vipsellData, waslinput, 7);
            ob.change_datagridview(vipsellData, tebeneinput, 8);
        }

        private void pictureBox198_Click(object sender, EventArgs e)
        {
            try
            {
                if (vipsellData.SelectedRows.Count != 0)
                {
                    int i = vipsellData.SelectedRows[0].Index;
                    int id = Convert.ToInt32(vipsellData.Rows[i].Cells[0].Value.ToString());
                    double adad = Convert.ToDouble(vipsellData.Rows[i].Cells[1].Value.ToString());
                    if (MessageBox.Show("دڵنیای لە گۆڕانکاری؟", "گۆڕانکاری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        double sump = Convert.ToDouble(sumpinput.Text);
                        double price = Convert.ToDouble(priceinput.Text);
                        double nomb = Convert.ToDouble(nombinput.Text);

                        ob.insert_del_up("UPDATE `vip_sell` SET `nomb`='" + nomb + "', `price`='" + price + "', `sump`='" + sump + "', `dates1`='" + dates1input.Text + "', `dates`='" + datesinput.Text + "', `ccid`='" + ccidinput.SelectedValue.ToString() + "', `wasl`='" + waslinput.Text + "', `tebene`='" + tebeneinput.Text + "' WHERE `mbids`='" + id + "'");

                        ob.a(this.Controls);
                        ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` order by mbids desc");
                        ob.sum(label586, vipsellData, 2);
                        ob.sum(label588, vipsellData, 3);

                    }
                    else
                    {
                        ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` order by mbids desc");
                        ob.sum(label586, vipsellData, 2);
                        ob.sum(label588, vipsellData, 3);
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox200_Click(object sender, EventArgs e)
        {
            ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'نرخ', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` and dates1 between '" + dateTimePicker91.Text + "' and '" + dateTimePicker92.Text + "' order by mbids desc");
            ob.sum(label586, vipsellData, 2);
            ob.sum(label588, vipsellData, 3);
        }

        private void vipData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (vipData.SelectedRows.Count != 0)
                {
                    int i = vipData.SelectedRows[0].Index;
                    namevipcompany.Text = vipData.Rows[i].Cells[1].Value.ToString();
                    phonevipcompany.Text = vipData.Rows[i].Cells[2].Value.ToString();
                    addressvipcompany.Text = vipData.Rows[i].Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {


            }
        }

        private void pictureBox196_Click(object sender, EventArgs e)
        {
            try
            {
                if (vipData.SelectedRows.Count != 0)
                {
                    int i = vipData.SelectedRows[0].Index;
                    int id = Convert.ToInt32(vipData.Rows[i].Cells[0].Value.ToString());
                    ob.insert_del_up("call update_vip_company('" + namevipcompany.Text + "','" + phonevipcompany.Text + "','" + addressvipcompany.Text + "','" + id + "')");
                    ob.table(vipData, "call select_vip_company();");
                    ob.count(label570, vipData, 0);
                    ob.a(this.Controls);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();
                }
            }
            catch (Exception)
            {


            }
        }

        private void پپارەوەرگرتنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 54;

            ob.comb(vipcomp, "SELECT * FROM vip_company", "ccid", "name");
            
            ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid");
            ob.sum(label599, givevipData, 1);

        }

        private void datesgivevip_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox206_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ob.insert_del_up("INSERT INTO `give_vip_company`(`qarzdinar`, `dates`, `cid`, `tebene`, `wasl`) VALUES ('" + qarzGiveVip.Text + "','" + datesGivevip.Text + "','" + vipcomp.SelectedValue.ToString() + "','" + tebeneGivevip.Text + "','" + waslgivevip.Text + "')");

                ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid");
                ob.sum(label599, givevipData, 1);
                messageboxsuc obb = new messageboxsuc();
                obb.Show();


                con.Open();
                string customerPhone = "";
                MySqlCommand md = new MySqlCommand("SELECT * FROM `vip_company` where ccid='" + vipcomp.SelectedValue.ToString() + "'", con);
                MySqlDataReader rd = md.ExecuteReader();
                while (rd.Read())
                {
                    customerPhone = rd.GetString("phone");

                }

                con.Close();
                easyHTMLReports1.Clear();
                easyHTMLReports1.AddLineBreak();
                // Company Header
                string headerHTML = @"
            <div style='text-align:left; margin-bottom: 20px;'>
                <h1 style='color:  #004A8F;'>Online Company Ltd</h1>
                <p>
                    Barzani Namir Road<br>
                    Opposite Al Qassab Oil<br>
                    Erbil, IRAQ<br>
                    Tel: 07501303445
                </p>
            </div>";

                // Initialize items table HTML with headers
                string itemsTableHTML = @"
            <table style='width: 100%; border-collapse: collapse; margin-top: 20px;'>
                <tr>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Description</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Date</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Invoice</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Paid</th>
                </tr>";

       
                string formattedAmount = qarzGiveVip.Text + " IQD";

                itemsTableHTML += $@"
                    <tr>
                        <td style='border: 1px solid gray; padding: 8px;'>{tebeneGivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{datesGivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{waslgivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{formattedAmount}</td>
                    </tr>";


                // Close the table HTML
                itemsTableHTML += "</table>";

                // Assuming customer name and total amount remain constant for the whole receipt
                // Add Receipt Title and Date
                string titleAndDateHTML = $@"
                   <div style='display: flex; flex-direction: row; justify-content: space-between; align-items: center; margin-bottom: 20px;'>
                       
                        <div >
                            <h2 style='color: cyan;'>Arrived Receipt</h2>
                            <h4 style='color: #004A8F;'>Customer: {vipcomp.Text}</h4>
                            <p>Tel: {customerPhone}</p>
                        </div> 
                    </div>
                    ";

                // Total Amount
                double total = Convert.ToDouble(qarzGiveVip.Text);
                string formattedTotal = total.ToString("N0") + " IQD";
                string totalAmountHTML = $@"
            <div style='text-align: right; margin-top: 20px;'>
                <h2 style='color: cyan;'><strong>Total:</strong>{formattedTotal}</h2>
            </div>";

                // Combine all parts
                easyHTMLReports1.AddString(headerHTML);
                easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top: -160px; margin-right: 20px;'");
                easyHTMLReports1.AddString(titleAndDateHTML);
                easyHTMLReports1.AddString(itemsTableHTML); // Use the dynamically generated table
                easyHTMLReports1.AddString(totalAmountHTML);


                // Show or export the report
                easyHTMLReports1.ShowPrintPreviewDialog();
                ob.a(this.Controls);


            }
        }

        private void givevipData_SelectionChanged(object sender, EventArgs e)
        {
            ob.change_datagridview_textfild(givevipData, qarzGiveVip, 1);
            ob.change_datagridview_combo(givevipData, vipcomp, 3);
            ob.change_datagridview_picker(givevipData, datesGivevip, 2);
            ob.change_datagridview(givevipData, tebeneGivevip, 5);
            ob.change_datagridview_textfild(givevipData, waslgivevip, 4);
        }

        private void pictureBox204_Click(object sender, EventArgs e)
        {
            try
            {
                if (givevipData.SelectedRows.Count != 0)
                {
                    con.Open();
                    string customerPhone = "";
                    MySqlCommand md = new MySqlCommand("SELECT * FROM `vip_company` where ccid='" + vipcomp.SelectedValue.ToString() + "'", con);
                    MySqlDataReader rd = md.ExecuteReader();
                    while (rd.Read())
                    {
                        customerPhone = rd.GetString("phone");

                    }

                    con.Close();
                    easyHTMLReports1.Clear();
                    easyHTMLReports1.AddLineBreak();
                    // Company Header
                    string headerHTML = @"
                    <div style='text-align:left; margin-bottom: 20px;'>
                        <h1 style='color:  #004A8F;'>Online Company Ltd</h1>
                        <p>
                           Barzani Namir Road<br>
                            Opposite Al Qassab Oil<br>
                            Erbil, IRAQ<br>
                            Tel: 07501303445
                        </p>
                    </div>";

                    // Initialize items table HTML with headers
                    string itemsTableHTML = @"
                    <table style='width: 100%; border-collapse: collapse; margin-top: 20px;'>
                        <tr>
                            <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Description</th>
                            <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Date</th>
                            <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Invoice</th>
                            <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Paid</th>
                        </tr>";


                    string formattedAmount = qarzGiveVip.Text + " IQD";

                    itemsTableHTML += $@"
                    <tr>
                        <td style='border: 1px solid gray; padding: 8px;'>{tebeneGivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{datesGivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{waslgivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{formattedAmount}</td>
                    </tr>";


                    // Close the table HTML
                    itemsTableHTML += "</table>";

                    // Assuming customer name and total amount remain constant for the whole receipt
                    // Add Receipt Title and Date
                    string titleAndDateHTML = $@"
                   <div style='display: flex; flex-direction: row; justify-content: space-between; align-items: center; margin-bottom: 20px;'>
                       
                        <div >
                            <h2 style='color: cyan;'>Arrived Receipt</h2>
                            <h4 style='color: #004A8F;'>Customer: {vipcomp.Text}</h4>
                            <p>Tel: {customerPhone}</p>
                        </div> 
                    </div>
                    ";

                    // Total Amount
                    double total = Convert.ToDouble(qarzGiveVip.Text);
                    string formattedTotal = total.ToString("N0") + " IQD";
                    string totalAmountHTML = $@"
                        <div style='text-align: right; margin-top: 20px;'>
                            <h2 style='color: cyan;'><strong>Total:</strong>{formattedTotal}</h2>
                        </div>";

                    // Combine all parts
                    easyHTMLReports1.AddString(headerHTML);
                    easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top: -160px; margin-right: 20px;'");
                    easyHTMLReports1.AddString(titleAndDateHTML);
                    easyHTMLReports1.AddString(itemsTableHTML); // Use the dynamically generated table
                    easyHTMLReports1.AddString(totalAmountHTML);

                    // Show or export the report
                    easyHTMLReports1.ShowPrintPreviewDialog();
                }
            }
            catch
            {

            }
        }

        private void pictureBox205_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("دڵنیای؟", "هەڵگرتن", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //try
                //{
                if (givevipData.SelectedRows.Count != 0)
                {
                    int i = givevipData.SelectedRows[0].Index;
                    String id = givevipData.Rows[i].Cells[0].Value.ToString();
                    ob.insert_del_up("UPDATE `give_vip_company` SET `qarzdinar`='" + Convert.ToDouble(qarzGiveVip.Text) + "',`dates`='" + datesGivevip.Text + "',`cid`='" + vipcomp.SelectedValue.ToString() + "',`tebene`='" + tebeneGivevip.Text + "',wasl='" + waslgivevip.Text + "' WHERE `qncid`='" + id + "'");

                    ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid");
                    ob.sum(label599, givevipData, 1);
                    messageboxsuc obb = new messageboxsuc();
                    obb.Show();


                    con.Open();
                    string customerPhone = "";
                    MySqlCommand md = new MySqlCommand("SELECT * FROM `vip_company` where ccid='" + vipcomp.SelectedValue.ToString() + "'", con);
                    MySqlDataReader rd = md.ExecuteReader();
                    while (rd.Read())
                    {
                        customerPhone = rd.GetString("phone");

                    }

                    con.Close();
                    easyHTMLReports1.Clear();
                    easyHTMLReports1.AddLineBreak();
                    // Company Header
                    string headerHTML = @"
            <div style='text-align:left; margin-bottom: 20px;'>
                <h1 style='color:  #004A8F;'>Online Company Ltd</h1>
                <p>
                   Barzani Namir Road<br>
                    Opposite Al Qassab Oil<br>
                    Erbil, IRAQ<br>
                    Tel: 07501303445
                </p>
            </div>";

                    // Initialize items table HTML with headers
                    string itemsTableHTML = @"
            <table style='width: 100%; border-collapse: collapse; margin-top: 20px;'>
                <tr>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Description</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Date</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Invoice</th>
                    <th style='border: 1px solid gray; padding: 8px; text-align: left;'>Paid</th>
                </tr>";


                    string formattedAmount = qarzGiveVip.Text + " IQD";

                    itemsTableHTML += $@"
                    <tr>
                        <td style='border: 1px solid gray; padding: 8px;'>{tebeneGivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{datesGivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{waslgivevip.Text}</td>
                        <td style='border: 1px solid gray; padding: 8px;'>{formattedAmount}</td>
                    </tr>";


                    // Close the table HTML
                    itemsTableHTML += "</table>";

                    // Assuming customer name and total amount remain constant for the whole receipt
                    // Add Receipt Title and Date
                    string titleAndDateHTML = $@"
                   <div style='display: flex; flex-direction: row; justify-content: space-between; align-items: center; margin-bottom: 20px;'>
                       
                        <div >
                            <h2 style='color: cyan;'>Arrived Receipt</h2>
                            <h4 style='color: #004A8F;'>Customer: {vipcomp.Text}</h4>
                            <p>Tel: {customerPhone}</p>
                        </div> 
                    </div>
                    ";

                    // Total Amount
                    double total = Convert.ToDouble(qarzGiveVip.Text);
                    string formattedTotal = total.ToString("N0") + " IQD";
                    string totalAmountHTML = $@"
            <div style='text-align: right; margin-top: 20px;'>
                <h2 style='color: cyan;'><strong>Total:</strong>{formattedTotal}</h2>
            </div>";

                    // Combine all parts
                    easyHTMLReports1.AddString(headerHTML);
                    easyHTMLReports1.AddImage(pictureBox1.Image, "width=150; style='float: right; margin-top: -160px; margin-right: 20px;'");
                    easyHTMLReports1.AddString(titleAndDateHTML);
                    easyHTMLReports1.AddString(itemsTableHTML); // Use the dynamically generated table
                    easyHTMLReports1.AddString(totalAmountHTML);

                    // Show or export the report
                    easyHTMLReports1.ShowPrintPreviewDialog();
                    ob.a(this.Controls);
                }
                //}
                //catch (Exception)
                //{


                //}

            }
        }

        private void givevipData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (givevipData.SelectedRows.Count != 0)
                    {
                        int i = givevipData.SelectedRows[0].Index;
                        int id = Convert.ToInt32(givevipData.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `give_vip_company` WHERE `qncid`='" + id + "'");
                            ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid");
                            ob.sum(label599, givevipData, 1);

                        }
                        else
                        {
                            ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid");
                            ob.sum(label599, givevipData, 1);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void vipsellData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (vipsellData.SelectedRows.Count != 0)
                    {
                        int i = vipsellData.SelectedRows[0].Index;
                        int id = Convert.ToInt32(vipsellData.Rows[i].Cells[0].Value.ToString());
                        double adad = Convert.ToDouble(vipsellData.Rows[i].Cells[1].Value.ToString());
                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("DELETE FROM `vip_sell` WHERE `mbids`='" + id + "'");
                            ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` order by mbids desc");
                            ob.sum(label586, vipsellData, 2);
                            ob.sum(label588, vipsellData, 3);

                        }
                        else
                        {
                            ob.table(vipsellData, "SELECT `mbids` AS '#', `nomb` AS 'بڕی مێگا', Truncate(`price`,2) AS 'قازانج', Truncate(`sump`,2) AS 'کۆی نرخ', DATE_FORMAT(dates1, '%Y/%m/%d') AS 'بەرواری سەرەتا', DATE_FORMAT(dates, '%Y/%m/%d') AS 'بەرواری کۆتای', vip_company.`name` AS 'کۆمپانیا', wasl AS 'ژ.وەسڵ', tebene AS 'تێبینی' FROM `vip_sell`,vip_company where vip_sell.`ccid`=vip_company.`ccid` order by mbids desc");
                            ob.sum(label586, vipsellData, 2);
                            ob.sum(label588, vipsellData, 3);
                        }
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        private void pictureBox203_Click(object sender, EventArgs e)
        {
            ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە', DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid and give_vip_company.dates between '" + dateTimePicker89.Text + "' and '" + dateTimePicker90.Text + "'");
            ob.sum(label599, givevipData, 1);
        }

        private void materialSingleLineTextField57_TextChanged(object sender, EventArgs e)
        {
            if (materialSingleLineTextField57.Text != "")
            {
                ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid and give_vip_company.`wasl` like '" + materialSingleLineTextField57.Text + "%'");
                ob.sum(label599, givevipData, 1);
            }
            else
            {
                ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid");
                ob.sum(label599, givevipData, 1);
            }
        }

        private void materialSingleLineTextField58_TextChanged(object sender, EventArgs e)
        {

                if (materialSingleLineTextField58.Text != "")
                {

                    ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid and vip_company.`name` like '" + materialSingleLineTextField58.Text + "%'");
                    ob.sum(label599, givevipData, 1);
                }
                else
                {

                ob.table(givevipData, "SELECT give_vip_company.`qncid` AS '#', format(give_vip_company.`qarzdinar`,2) AS 'بڕی پارە',DATE_FORMAT(give_vip_company.dates, '%Y/%m/%d') AS 'بەروار', vip_company.`name` AS 'کۆمپانیا', give_vip_company.`wasl` AS 'ژ.وەسڵ', give_vip_company.`tebene` AS 'تێبینی' FROM `give_vip_company`,vip_company where give_vip_company.cid=vip_company.ccid");
                ob.sum(label599, givevipData, 1);
                }
            
        }

        private void vipData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (vipData.SelectedRows.Count != 0)
                    {
                        int i = vipData.SelectedRows[0].Index;
                        int id = Convert.ToInt32(vipData.Rows[i].Cells[0].Value.ToString());

                        if (MessageBox.Show("دڵنیای لەسڕینەوە؟", "سڕینەوە", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ob.insert_del_up("call delete_vip_company('" + id + "')");
                            ob.table(vipData, "call select_vip_company();");
                            ob.count(label599, vipData, 0);
                            ob.a(this.Controls);
                        }
                        else
                        {
                            ob.table(vipData, "call select_vip_company();");
                            ob.count(label599, vipData, 0);
                        }
                        con.Close();
                    }
                }
                catch (Exception)
                {


                }

            }
        }
    }
}