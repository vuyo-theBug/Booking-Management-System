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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.dS.User);
            // TODO: This line of code loads data into the 'patientsD.Users' table. You can move, or remove it, as needed.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "") {
                userTableAdapter.Insert(textBox2.Text,textBox3.Text, textBox4.Text, textBox5.Text,comboBox1.Text);
                userTableAdapter.Fill(dS.User);
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Text = "";
                textBox4.Clear();
                textBox5.Clear();
            }
            else { 
                MessageBox.Show("Fill all required fields");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userTableAdapter.FillBy1(dS.User,textBox1.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void userDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    textBox6.Text = userDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                    textBox2.Text = userDataGridView.SelectedRows[0].Cells[1].Value.ToString();

                    textBox3.Text = userDataGridView.SelectedRows[0].Cells[2].Value.ToString();

                    textBox4.Text = userDataGridView.SelectedRows[0].Cells[3].Value.ToString();

                    textBox5.Text = userDataGridView.SelectedRows[0].Cells[4].Value.ToString();

                }
            } catch (Exception) {
                MessageBox.Show("Select a row to edit");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userTableAdapter.UpdateQuery(textBox4.Text,textBox5.Text,Convert.ToInt32(textBox6.Text));
            userTableAdapter.Fill(dS.User);
            MessageBox.Show("update successful");
        }
    }
}
