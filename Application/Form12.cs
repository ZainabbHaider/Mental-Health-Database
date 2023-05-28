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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MentalHealthDtabase
{
    public partial class Form12 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Form12()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Login.PorD == "P")
            {
                string sql = "update patient SET password = @pass WHERE username = @user and password = @password";
                con.Open();
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@pass", textBox2.Text);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.Parameters.AddWithValue("@password", textBox1.Text);
                cm.ExecuteNonQuery();
                MessageBox.Show("Update Successful");
                con.Close();
            }
            else if (Login.PorD == "D")
            {
                Console.WriteLine("inside if D");
                string sql = "update Medical_Professionals SET password = @pass WHERE username = @user and password = @password";
                con.Open();
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@pass", textBox2.Text);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.Parameters.AddWithValue("@password", textBox1.Text);
                cm.ExecuteNonQuery();
                MessageBox.Show("Update Successful");
                con.Close();
            }
            this.Hide();
            var form15 = new Form15();
            form15.Closed += (s, args) => this.Close();
            form15.Show();



        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form15 = new Form15();
            form15.Closed += (s, args) => this.Close();
            form15.Show();
        }
    }
}
