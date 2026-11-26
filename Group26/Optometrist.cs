using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group26
{
    public partial class Optometrist : Form
    {
        public Optometrist()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Optometrist_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookingsDS.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter1.Fill(this.bookingsDS.DataTable1);
            // TODO: This line of code loads data into the 'data.Payments' table. You can move, or remove it, as needed.
            this.paymentsTableAdapter1.Fill(this.data.Payments);
            // TODO: This line of code loads data into the 'data.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter1.Fill(this.data.Patient);

            try
            {// TODO: This line of code loads data into the 'bookingsDS.DataTable2' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.Fill(this.bookingsDS.DataTable2);
            // TODO: This line of code loads data into the 'data.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.data.DataTable1);
            // TODO: This line of code loads data into the 'paymentsDS.Payments' table. You can move, or remove it, as needed.
            this.paymentsTableAdapter.Fill(this.paymentsDS.Payments);
            // TODO: This line of code loads data into the 'paymentsDS.Payments' table. You can move, or remove it, as needed.
            this.paymentsTableAdapter.Fill(this.paymentsDS.Payments);
            // TODO: This line of code loads data into the 'bookingsDS.Bookings' table. You can move, or remove it, as needed.
            this.bookingsTableAdapter.Fill(this.bookingsDS.Bookings);
            // TODO: This line of code loads data into the 'patientsD.Patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.patientsD.Patient);
                //this.dataTable1TableAdapter1.Fill(this.data.DataTable1); // TODO: This line of code loads data into the 'data.DataTable1' table. You can move, or remove it, as needed.
                patientTableAdapter.Fill(patientsD.Patient);
         
                // TODO: This line of code loads data into the 'bookingsDS.DataTable2' table. You can move, or remove it, as needed.
            
                // TODO: This line of code loads data into the 'patientsD.Patient' table. You can move, or remove it, as needed.
                this.patientTableAdapter.Fill(this.patientsD.Patient);
          
            }
            catch(Exception ex)
            {
                

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            patientTableAdapter.FillBy(patientsD.Patient,textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataTable1TableAdapter.FillBy(data.DataTable1, textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.FillBy(this.data.DataTable1,textBox3.Text);
            this.dataTable1TableAdapter.FillBy(data.DataTable1,textBox3.Text);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void optometrist_IDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
