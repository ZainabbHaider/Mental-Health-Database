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

namespace MentalHealthDtabase
{
    public partial class Form8 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public string PatientName { get; set; }
        public string EmailAddress { get; set; }
        public string contactNumber { get; set; }
        public string Doctor { get; set; }
        public string Fees { get; set; }
        public Form8()
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

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load_1(object sender, EventArgs e)
        {
            con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select Fees from Medical_Professionals where Name = @Doctor";
            cm.Parameters.AddWithValue("@Doctor", Doctor);
            //cm.Parameters.Add();
            cm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            da1.Fill(dt1);
            con.Close();
            string fee = (dt1.Rows[0].ItemArray[0].ToString());
            label7.Text = PatientName;
            label8.Text = EmailAddress;
            label13.Text = contactNumber;
            label10.Text = Doctor;
            label12.Text = fee;
            label11.Text = Form4.Date + " " + Form4.Time;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form15 = new Form15();
            form15.Closed += (s, args) => this.Close();
            form15.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form7 = new Form7();
            form7.Closed += (s, args) => this.Close();
            form7.Show();
        }
    }
}
