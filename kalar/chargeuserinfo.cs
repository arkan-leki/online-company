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
    public partial class chargeuserinfo : Form
    {
        systm ob = new systm();
        public chargeuserinfo()
        {
            InitializeComponent();
            ob.comb(send, "SELECT * FROM customer", "cid", "cname");
            ob.comb(rec, "SELECT * FROM customer", "cid", "cname");
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
                String wakilsend = send.SelectedValue.ToString(); // Sender ID
                String wakilrec = rec.SelectedValue.ToString();   // Receiver ID
                String notetxt = note.Text;          // Note text
                String date = barwar.Text;           // Date
                Double amount = Convert.ToDouble(price.Text); // Assuming 'numkart' is your amount input

                // SQL INSERT statement
                String sql = $"INSERT INTO exchange_balance (kid, cus, amount, barwar, tebene) VALUES ('{wakilsend}', '{wakilrec}', {amount}, '{date}', '{notetxt}')";

                // Execute the SQL statement
                ob.insert_del_up(sql);

                // Show success message
                messageboxsuc ms = new messageboxsuc();
                ms.Show();
            }
            catch (Exception ex)
            {
                // Ideally, handle the exception more gracefully
                MessageBox.Show(ex.Message);
            }

        }


    }
}
