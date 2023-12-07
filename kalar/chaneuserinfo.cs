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
    public partial class chaneuserinfo : Form
    {
        systm ob = new systm();
        public chaneuserinfo()
        {
            InitializeComponent();
            ob.comb(send, "SELECT * FROM customer", "cid", "cname");
            ob.comb(rec, "SELECT * FROM customer", "cid", "cname");
            ob.comb(comboBox2, "SELECT * FROM balance", "bid", "types");
        }

        private void chaneuserinfo_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            try
            {
                ob.insert_del_up("UPDATE `storage_kart_customer` SET `number`=number-('" + Convert.ToDouble(numkart.Text) + "') WHERE `kid`='" + comboBox2.SelectedValue.ToString() + "' and `cus`='" + send.SelectedValue.ToString() + "'");
                ob.insert_del_up("call insert_storage_kart_customer('" + comboBox2.SelectedValue.ToString() + "','" + Convert.ToDouble(numkart.Text) + "','" + rec.SelectedValue.ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')");
                messageboxsuc ms = new messageboxsuc();
                ms.Show();
            }
            catch (Exception)
            {
            }
        }
    }
}
