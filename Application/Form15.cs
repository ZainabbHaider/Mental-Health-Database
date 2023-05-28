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
    public partial class Form15 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form12 = new Form12();
            form12.Closed += (s, args) => this.Close();
            form12.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Login.PorD == "P")
            {
                string sql1 = "delete Appointments where PatientID = (select ID from Patient where username = @user)";
                con.Open();
                cm = new SqlCommand(sql1, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql3 = "delete Patient_Diagnosis_to_symptoms where diagnosisID = (select DiagnosisID from Patient_Diagnosis where PatientID = (select ID from Patient where username = @user))";
                cm = new SqlCommand(sql3, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql2 = "delete Patient_Diagnosis where PatientID = (select ID from Patient where username = @user)";
                cm = new SqlCommand(sql2, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql = "delete patient where username = @username";
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@username", Login.user);
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Successful");
                this.Hide();
                var form1 = new Login();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else if (Login.PorD == "D")
            {
                string sql1 = "delete schedule where MedicalProfessionalID = (select ID from Medical_Professionals where username = @user)";
                con.Open();
                cm = new SqlCommand(sql1, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql = "delete Medical_Professionals where username = @username";
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@username", Login.user);
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Successful");
                this.Hide();
                var form1 = new Login();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Login();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Login.PorD == "P")
            {
                this.Hide();
                var form3 = new Form3();
                form3.Closed += (s, args) => this.Close();
                form3.Show();
            }
            else if (Login.PorD == "D")
            {
                this.Hide();
                var form14 = new Form14();
                form14.Closed += (s, args) => this.Close();
                form14.Show();
            }
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
