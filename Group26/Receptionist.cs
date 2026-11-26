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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
        }

        private int zz = 0;

        private void Receptionist_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'data.Payments' table. You can move, or remove it, as needed.
            this.paymentsTableAdapter1.Fill(this.data.Payments);
            bookingsTableAdapter.Fill(bookingsDS.Bookings);
            patientTableAdapter.Fill(patientsD.Patient);
            paymentsTableAdapter.Fill(paymentsDS.Payments);
            dataTable2TableAdapter.Fill(bookingsDS.DataTable2);
            monthCalendar1.MinDate = DateTime.Now;

            zz = 1;
            textBox10.Text = "";
            textBox9.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "") {
                patientTableAdapter.Insert(textBox2.Text, textBox3.Text, maskedTextBox1.Text, textBox4.Text, maskedTextBox2.Text, textBox5.Text);
                patientTableAdapter.Fill(patientsD.Patient);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                maskedTextBox2.Clear();
                maskedTextBox1.Clear();
            }
            else {
                MessageBox.Show("fill all missing fields!");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            patientTableAdapter.FillBy(patientsD.Patient,textBox1.Text);
        }

        private void Bookings(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            patientTableAdapter.FillBy(patientsD.Patient, textBox6.Text);


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        int amount = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text!="") { listBox1.Items.Add(comboBox2.Text); } 
            else { MessageBox.Show("select atleast one service"); }
            
            if (comboBox2.Text == "Eye Test") {
                amount += 350;
                textBox8.Text = amount.ToString();

            }else if (comboBox2.Text == "Single Vision")
            {
                amount += 690;
                textBox8.Text = amount.ToString();
            }
            else if (comboBox2.Text == "Bifocals")
            {
                amount += 1060;
                textBox8.Text = amount.ToString();
            }
            else if (comboBox2.Text == "Multifocals")
            {
                amount += 1390;
                textBox8.Text = amount.ToString();
            }
            else if (comboBox2.Text == "Consultation")
            {
                amount += 0;
                textBox8.Text = amount.ToString();
            }
            comboBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox8.Text = "";
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
  
            if (listBox1.GetItemText(listBox1.SelectedItem) == "Eye Test")
            {
                amount -= 350;
                
                textBox8.Text = amount.ToString();

            }
            else if (listBox1.GetItemText(listBox1.SelectedItem) == "Single Vision")
            {
                amount -= 690;
                textBox8.Text = amount.ToString();
            }
            else if (listBox1.GetItemText(listBox1.SelectedItem) == "Bifocals")
            {
                amount -= 1060;
                textBox8.Text = amount.ToString();
            }
            else if (listBox1.GetItemText(listBox1.SelectedItem) == "Multifocals")
            {
                amount -= 1390;
                textBox8.Text = amount.ToString();
            }
            else if (listBox1.GetItemText(listBox1.SelectedItem) == "Consultation")
            {
                amount -= 0;
                textBox8.Text = amount.ToString();
            }
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No items on the List or select item to remove");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string services = "";
            for (int i=0;i<listBox1.Items.Count;i++)
            {
                services = services + listBox1.GetItemText(listBox1.Items[i])+ ", ";
            }

            bookingsTableAdapter.FillBy(bookingsDS.Bookings, monthCalendar1.SelectionEnd.ToShortDateString(), comboBox1.Text);
            if (dataGridView3.Rows.Count > 0) {
                MessageBox.Show("slot already booked");
                bookingsTableAdapter.Fill(bookingsDS.Bookings);

            }
            else
            {
                try
                {
                    String s = comboBox1.Text;
                    String S = monthCalendar1.SelectionStart.ToShortDateString();
                    S = S + " " + s.Substring(8);
                    DateTime D = Convert.ToDateTime(S);

                    if (D < DateTime.Now)
                    {
                        MessageBox.Show(" Can not book this slot, ");
                    }
                    else
                    {
                        DateTime d = D.AddMinutes(-30);
                        String time = d.ToString().Substring(10) + "-" + D.ToString().Substring(10);
                     
                        bookingsTableAdapter.Insert(Convert.ToInt32(label15.Text), D.ToString().Substring(0,10), time, services, Convert.ToDecimal(textBox8.Text), "Booked Successfully-Unpaid");
                        bookingsTableAdapter.Fill(bookingsDS.Bookings);
                        MessageBox.Show("successfully booked");
                    }
                }
                catch (Exception ec)
                {
                   
                    MessageBox.Show(ec.Message);
                }
            }



        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    label15.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                }
            } catch (Exception) {
                MessageBox.Show("select a patient from gridview");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            patientTableAdapter.UpdateQuery(maskedTextBox1.Text,textBox4.Text,textBox5.Text,Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox7.Text));
            this.patientTableAdapter.Fill(this.patientsD.Patient);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    textBox7.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    maskedTextBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    maskedTextBox2.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                    textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("select a row to edit");
            }
            
        }

        

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    textBox10.Text = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();

                    textBox9.Text = dataGridView5.SelectedRows[0].Cells[7].Value.ToString();

                }

            }
            catch (Exception)
            {
                

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (zz < 2)
            {
                try
                {
                    if (Convert.ToInt32(textBox9.Text) > Convert.ToInt32(textBox11.Text))
                    {
                        MessageBox.Show("Insufficient funds");
                        double ans = Convert.ToInt32(textBox9.Text) - Convert.ToInt32(textBox11.Text);
                        textBox12.Text = ans.ToString();
                       
                    }

                    else
                    {
                        textBox12.Text = (Convert.ToInt32(textBox11.Text) - Convert.ToInt32(textBox9.Text)).ToString();
                        paymentsTableAdapter.Insert(Convert.ToInt32(textBox10.Text), Convert.ToDecimal(textBox11.Text), Convert.ToDecimal(textBox12.Text));
                        paymentsTableAdapter.Fill(paymentsDS.Payments);
                        dataTable1TableAdapter1.Fill(data.DataTable1);
                        MessageBox.Show("Payment Successful !!");
                        paymentsTableAdapter.Fill(paymentsDS.Payments);

                    }
                }
                catch (Exception)
                {

                }
                zz += 1;
            }
            else
            {
                MessageBox.Show("Payment already made.");
            }

            
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            double chnge = Convert.ToDouble(textBox11.Text) - Convert.ToDouble(textBox9.Text);

          
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
