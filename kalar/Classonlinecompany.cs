using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ADGV;
using MaterialSkin.Controls;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Classonlinecompany
{
    public class systm
    {
        public static string sql = "server=185.166.24.102;port=3307;database=new_system_online;user=u901521484_sahl;password=Onlinecompanysahl$1;Charset=utf8;convert zero datetime=True";
        // public static string sql = "server=127.0.0.1;port=3306;database=new_system_online;user=root;password=root;Charset=utf8;convert zero datetime=True";

        private MySqlConnection con = new MySqlConnection(sql);

        public void sum(System.Windows.Forms.Label l, DataGridView dv, int index)
        {
            try
            {
                l.Text = "0";
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    l.Text = (Convert.ToDouble(l.Text) + Convert.ToDouble(dv.Rows[i].Cells[index].Value)).ToString();
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

        public void adfilter(AdvancedDataGridView d)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = d.DataSource;
            bindingSource.Filter = d.FilterString;
            d.DataSource = bindingSource.DataSource;
        }

        public void adsort(AdvancedDataGridView d)
        {
            try
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = d.DataSource;
                bindingSource.Sort = d.SortString;
                d.DataSource = bindingSource.DataSource;
            }
            catch (Exception)
            {
            }
        }

        public void change_datagridview(DataGridView d, System.Windows.Forms.TextBox v, int ind)
        {
            try
            {
                if (d.SelectedRows.Count != 0)
                {
                    int index = d.SelectedRows[0].Index;
                    v.Text = d.Rows[index].Cells[ind].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void change_datagridviewl(DataGridView d, System.Windows.Forms.Label v, int ind)
        {
            try
            {
                if (d.SelectedRows.Count != 0)
                {
                    int index = d.SelectedRows[0].Index;
                    v.Text = d.Rows[index].Cells[ind].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void change_datagridview_textfild(DataGridView d, MaterialSingleLineTextField v, int ind)
        {
            try
            {
                if (d.SelectedRows.Count != 0)
                {
                    int index = d.SelectedRows[0].Index;
                    v.Text = d.Rows[index].Cells[ind].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void change_datagridview_picker(DataGridView d, DateTimePicker v, int ind)
        {
            try
            {
                if (d.SelectedRows.Count != 0)
                {
                    int index = d.SelectedRows[0].Index;
                    v.Text = d.Rows[index].Cells[ind].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void change_datagridview_combo(DataGridView d, ComboBox v, int ind)
        {
            try
            {
                if (d.SelectedRows.Count != 0)
                {
                    int index = d.SelectedRows[0].Index;
                    v.Text = d.Rows[index].Cells[ind].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void comb(ComboBox cm, string sql, string id, string name)
        {
            con.Open();
            MySqlCommand selectCommand = new MySqlCommand(sql, con);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet);
            cm.DataSource = dataSet.Tables[0];
            cm.ValueMember = id;
            cm.DisplayMember = name;
            cm.AutoCompleteMode = AutoCompleteMode.Suggest;
            cm.AutoCompleteSource = AutoCompleteSource.ListItems;
            con.Close();
        }

        public void count(System.Windows.Forms.Label l, DataGridView dv, int index)
        {
            l.Text = "0";
            int num = 0;
            for (int i = 1; i < dv.Rows.Count; i++)
            {
                num++;
            }

            l.Text = num.ToString();
        }

        public void a(Control.ControlCollection aa)
        {
            foreach (Control item in aa)
            {
                if (item is TextBoxBase)
                {
                    item.Text = string.Empty;
                }
                else
                {
                    a(item.Controls);
                }
            }
        }

        public void aa(Control.ControlCollection aaa)
        {
            foreach (Control item in aaa)
            {
                if (item is TextBoxBase)
                {
                    item.Text = "0";
                }
                else
                {
                    aa(item.Controls);
                }
            }
        }

        public void table(DataGridView databadrivview1, string sql)
        {
            con.Open();
            MySqlCommand selectCommand = new MySqlCommand(sql, con);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet);
            databadrivview1.DataSource = dataSet.Tables[0];
            con.Close();
        }

        public void datagridpropirty(DataGridView data1)
        {
            data1.AutoResizeColumns();
            data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void toexcel(DataGridView dataGridView1)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                application.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                for (int k = 0; k < dataGridView1.Columns.Count; k++)
                {
                    application.Cells[j + 2, k + 1] = dataGridView1.Rows[j].Cells[k].Value.ToString();
                }
            }

            application.Columns.AutoFit();
            application.Visible = true;
        }

        public void FormattingExcelCells(Range range, string HTMLcolorCode, Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = ColorTranslator.ToOle(fontColor);
            if (IsFontbool)
            {
                range.Font.Bold = IsFontbool;
            }
        }

        public void insert_del_up(string sql)
        {
            con.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
            mySqlCommand.ExecuteNonQuery();
            con.Close();
        }

        public void setsepator(System.Windows.Forms.Label l)
        {
            try
            {
                l.Text = $"{double.Parse(l.Text):#,##0.00}";
            }
            catch (Exception)
            {
            }
        }

        public void getsum(System.Windows.Forms.Label ld, string sql)
        {
            try
            {
                con.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    ld.Text = mySqlDataReader.GetString("result");
                }

                con.Close();
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
}
