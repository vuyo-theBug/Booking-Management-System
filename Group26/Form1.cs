using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e) {
            //SqlConnection con = new SqlConnection("Data Source = 146.230.177.46; Initial Catalog = GroupWst26; Persist Security Info = True; User ID = GroupWst26; Password =zaer2");
            //SqlCommand cmd = new SqlCommand("SELECT User_ID, Name, Surname, Username FROM User WHERE(Password = '"+textBox2.Text+"') AND(Username ='"+textBox2.Text+"' )",con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            userTableAdapter.FillBy(dS.User,textBox1.Text,textBox2.Text,comboBox1.Text);
            if(dataGridView1.Rows.Count > 0) {
                MessageBox.Show("Login Successful");

                if (comboBox1.Text == "Optometrist")
                {
                    Optometrist optom = new Optometrist();
                    optom.Show();
                    this.Hide();

                }
                else if (comboBox1.Text == "Admin")
                {
                    Admin ad = new Admin();
                    ad.Show();
                    this.Hide();

                }
                else if (comboBox1.Text == "Receptionist")
                {
                    Receptionist rec = new Receptionist();
                    rec.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("trying to login");
                }

            } else {
                MessageBox.Show("User name or password incorrect, or try to login as different user ;-)");

            }

            //Admin rec = new Admin();
            //rec.Show();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.User' table. You can move, or remove it, as needed.
            try {
                this.userTableAdapter.Fill(this.dS.User);

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}