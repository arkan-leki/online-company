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
    public partial class qazanjamer : Form
    {
        systm ob = new systm();
        double dolar = draw.dolar;
        public qazanjamer()
        {
            InitializeComponent();
        }

        private void pictureBox145_Click(object sender, EventArgs e)
        {

            label3.Text = "0";
            label4.Text = "0";
            label5.Text = "0";
            label11.Text = "0";
            label10.Text = "0";
            label1.Text = "0";
            ob.getsum(label3, "SELECT sum(amer_hato.`sump`) AS 'result' FROM `amer_hato` where dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            Double ah = Convert.ToDouble(label3.Text) * dolar;
            label3.Text = ah.ToString();
            ob.getsum(label4, "SELECT sum(amer_froshtn.`sump`) AS 'result' FROM `amer_froshtn` where dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            ob.getsum(label5, "SELECT sum(froshtn_amer.`sumprice`) AS 'result' FROM `froshtn_amer` where dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            ob.getsum(label11, "SELECT (sum(amer_froshtn.`spk`)*'"+dolar+"') AS 'result' FROM `amer_froshtn` where dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");

            ob.getsum(label10, "SELECT (sum(froshtn_amer.`psk`)*'" + dolar + "') AS 'result' FROM `froshtn_amer` where dates between '" + dateTimePicker55.Text + "' and '" + dateTimePicker56.Text + "'");
            double frosh = Convert.ToDouble(label4.Text) + Convert.ToDouble(label5.Text);
            double kren = Convert.ToDouble(label11.Text) + Convert.ToDouble(label10.Text);
            label1.Text = (frosh-kren).ToString();
            ob.setsepator(label3);
            ob.setsepator(label4);
            ob.setsepator(label5);
            ob.setsepator(label1);
            ob.setsepator(label11);
            ob.setsepator(label10);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void qazanjamer_Load(object sender, EventArgs e)
        {

        }
    }
}
